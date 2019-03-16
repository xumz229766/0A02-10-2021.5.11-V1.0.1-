using System.Collections.Generic;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
using Motion.LSAps;
namespace desay
{
    /// <summary>
    /// 左C轴模块
    /// </summary>
    public class MiddleC : ThreadPart
    {
        private LeftCAlarm m_Alarm;
        public MiddleC(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
            Global.Alarms.Add(new Alarm(() => m_Alarm == LeftCAlarm.初始化故障) { AlarmLevel = AlarmLevels.None, Name = LeftCAlarm.初始化故障.ToString() });
            Global.Alarms.AddRange(LeftCAxis.Alarms);
            Global.Alarms.AddRange(RightCAxis.Alarms);
            Global.Alarms.AddRange(PushCylinder.Alarms);
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }
        /// <summary>
        /// 左C轴
        /// </summary>
        public StepAxis LeftCAxis { get; set; }
        /// <summary>
        /// 右轴
        /// </summary>
        public StepAxis RightCAxis { get; set; }
        /// <summary>
        /// 推进气缸
        /// </summary>
        public SingleCylinder PushCylinder { get; set; }
        public override void Running(RunningModes runningMode)
        {
            var step = 0;
            double pos1 = 0;
            double pos2 = 0;
            while (true)
            {
                Thread.Sleep(10);
                PushCylinder.Condition.External = externalSign;
                #region  //自动流程
                if (stationOperate.Running)
                {
                    switch (step)
                    {
                        case 0://判断是否有料
                            if (Marking.MiddleCAxisHaveProduct) step = 30;
                            else step = 10;
                            break;
                        case 10://判断C轴推出气缸状态是否在原点，然后将C轴移动1穴位置
                            if (LeftCAxis.IsInPosition(Position.Instance.Caxis[1].Startangle)
                                && RightCAxis.IsInPosition(Position.Instance.Caxis[2].Startangle)) step = 20;
                            else
                            if (PushCylinder.OutOriginStatus)
                            {
                                if (!LeftCAxis.IsInPosition(Position.Instance.Caxis[1].Startangle))
                                    LeftCAxis.MoveTo(Position.Instance.Caxis[1].Startangle, AxisParameter.Instance.C2VlowVelocityCurve);
                                if (!RightCAxis.IsInPosition(Position.Instance.Caxis[2].Startangle))
                                    RightCAxis.MoveTo(Position.Instance.Caxis[2].Startangle, AxisParameter.Instance.C3VlowVelocityCurve);
                                step = 20;
                            }
                            break;
                        case 20://C轴到达接料位置，等待来料标志置位
                            if (LeftCAxis.IsInPosition(Position.Instance.Caxis[1].Startangle)
                                && RightCAxis.IsInPosition(Position.Instance.Caxis[2].Startangle))
                            {
                                Marking.MiddleMoveFinish = true;
                                if (stationOperate.SingleRunning) Thread.Sleep(100);
                                step = 30;
                            }
                            break;
                        case 30://判断放好料、等待来料标志为false,推出气缸为ON
                            if (!Marking.CleanMachineProduct && (!Marking.MiddleMoveFinish || stationOperate.SingleRunning)
                                && PushCylinder.Condition.IsOnCondition)
                            {

                                pos1 = Position.Instance.Caxis[1].holes[Marking.MiddleCcellNum].angle;
                                pos2 = Position.Instance.Caxis[2].holes[Marking.MiddleCcellNum].angle;
                                Marking.MiddleCAxisHaveProduct = true;
                                PushCylinder.Set();
                                LeftCAxis.MoveTo(pos1, AxisParameter.Instance.C2VlowVelocityCurve);
                                RightCAxis.MoveTo(pos2, AxisParameter.Instance.C3VlowVelocityCurve);
                                step = 40;
                            }
                            break;
                        case 40://推出气缸到位，C轴准备好标志置位
                            if (PushCylinder.OutMoveStatus
                                && LeftCAxis.IsInPosition(pos1)
                                && RightCAxis.IsInPosition(pos2))
                            {
                                Marking.LeftCAxis2Finish = true;
                                Marking.RightCAxis1Finish = true;
                                if (stationOperate.SingleRunning) Thread.Sleep(100);
                                step = 50;
                            }
                            break;
                        case 50://判断C轴准备好标志复位，穴数+1
                            if ((!Marking.LeftCAxis2Finish && !Marking.RightCAxis1Finish) || stationOperate.SingleRunning)
                            {
                                //判断是否废料清除
                                if (Marking.CleanMachineProduct)
                                {
                                    Marking.MiddleCAxisHaveProduct = false;
                                    step = 90;
                                }
                                else
                                {
                                    Marking.MiddleCcellNum++;
                                    if (Marking.MiddleCcellNum <= Position.Instance.HoleNumber) step = 80;
                                    else step = 90;
                                }
                            }
                            break;
                        case 80://C轴移动到下一穴，C轴准备好标志置位。
                            pos1 = Position.Instance.Caxis[1].holes[Marking.MiddleCcellNum].angle;
                            pos2 = Position.Instance.Caxis[2].holes[Marking.MiddleCcellNum].angle;
                            LeftCAxis.MoveTo(pos1, AxisParameter.Instance.C2VlowVelocityCurve);
                            RightCAxis.MoveTo(pos2, AxisParameter.Instance.C3VlowVelocityCurve);
                            if (LeftCAxis.IsInPosition(pos1) && RightCAxis.IsInPosition(pos2))
                            {
                                Marking.LeftCAxis2Finish = true;
                                Marking.RightCAxis1Finish = true;
                                Thread.Sleep(20);
                                step = 50;
                            }
                            break;
                        case 90://C轴准备好标志复位，推出气缸为OFF
                            if (((!Marking.LeftCAxis2Finish && !Marking.RightCAxis1Finish) || stationOperate.SingleRunning)
                                && PushCylinder.Condition.IsOffCondition)
                            {
                                PushCylinder.Reset();
                                LeftCAxis.MoveTo(Position.Instance.Caxis[1].Startangle, AxisParameter.Instance.C2VlowVelocityCurve);
                                RightCAxis.MoveTo(Position.Instance.Caxis[2].Startangle, AxisParameter.Instance.C3VlowVelocityCurve);
                                step = 100;
                            }
                            break;
                        case 100://推出气缸到达
                            if (LeftCAxis.IsInPosition(Position.Instance.Caxis[1].Startangle) &&
                                RightCAxis.IsInPosition(Position.Instance.Caxis[2].Startangle)
                                && PushCylinder.OutOriginStatus)
                            {
                                Marking.watchCT2.Stop();
                                Marking.watchCT2Value = Marking.watchCT2.ElapsedMilliseconds / 1000.0;
                                Marking.MiddleCAxisHaveProduct = false;
                                step = 110;
                            }
                            break;
                        default:
                            Marking.MiddleCcellNum = 0;
                            step = 0;
                            stationOperate.RunningSign = false;
                            break;
                    }
                }
                #endregion

                #region 初始化流程
                if (stationInitialize.Running)
                {
                    switch (stationInitialize.Flow)
                    {
                        case 0:
                            stationInitialize.InitializeDone = false;
                            stationOperate.RunningSign = false;
                            step = 0;
                            Marking.MiddleCcellNum = 0;

                            Marking.MiddleMoveFinish = false;
                            Marking.LeftCAxis2Finish = false;
                            Marking.RightCAxis1Finish = false;
                            LeftCAxis.Stop();
                            stationInitialize.Flow = 10;
                            break;
                        case 10:
                            if (PushCylinder.Condition.IsOffCondition)
                            {
                                PushCylinder.InitExecute();
                                PushCylinder.Reset();
                                stationInitialize.Flow = 20;
                            }
                            break;
                        case 20:
                            LeftCAxis.BackHome();
                            RightCAxis.BackHome();
                            Thread.Sleep(300);
                            stationInitialize.Flow = 30;
                            break;
                        case 30:
                            if (LeftCAxis.CheckHomeDone(500) == 0 || RightCAxis.CheckHomeDone(500) == 0)
                            {
                                stationInitialize.Flow = 40;
                            }
                            else
                            {
                                stationInitialize.InitializeDone = false; ;
                                stationInitialize.Flow = -1;
                            }
                            break;
                        case 40:
                            if (PushCylinder.OutOriginStatus)
                            {
                                stationInitialize.InitializeDone = true;
                                stationInitialize.Flow = 50;
                            }
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                //故障清除
                if (externalSign.AlarmReset) m_Alarm = LeftCAlarm.无消息;
            }
        }

    }
}
