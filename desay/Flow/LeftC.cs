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
    public class LeftC : ThreadPart
    {
        private LeftCAlarm m_Alarm;
        public LeftC(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
            Global.Alarms.Add(new Alarm(() => m_Alarm == LeftCAlarm.初始化故障) { AlarmLevel = AlarmLevels.None, Name = LeftCAlarm.初始化故障.ToString() });
            Global.Alarms.AddRange(PushCylinder.Alarms);
            Global.Alarms.AddRange(CAxis.Alarms);
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }
        /// <summary>
        /// C轴
        /// </summary>
        public StepAxis CAxis { get; set; }
        /// <summary>
        /// 推进气缸 
        /// </summary>
        public SingleCylinder PushCylinder { get; set; }
        public override void Running(RunningModes runningMode)
        {
            var step = 0;
            double pos = 0;
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
                            Marking.watchCT1.Restart();
                            if (Marking.LeftCAxisHaveProduct)
                            { step = 30; }
                            else step = 10;
                            break;
                        case 10://判断C轴推出气缸状态是否在原点，然后将C轴移动1穴位置
                            if (CAxis.IsInPosition(Position.Instance.Caxis[0].Startangle)) step = 20;
                            else
                            if (PushCylinder.OutOriginStatus)
                            {
                                CAxis.MoveTo(Position.Instance.Caxis[0].Startangle, AxisParameter.Instance.C1VelocityCurve);
                                step = 20;
                            }
                            break;
                        case 20://C轴到达接料位置，等待来料标志置位
                            if (CAxis.IsInPosition(Position.Instance.Caxis[0].Startangle))
                            {
                                Marking.LeftMoveFinish = true;
                                if (stationOperate.SingleRunning) Thread.Sleep(100);
                                step = 30;
                            }
                            break;
                        case 30://判断放好料、等待来料标志为false,推出气缸为ON
                            if (!Marking.CleanMachineProduct && (!Marking.LeftMoveFinish || stationOperate.SingleRunning)
                                && PushCylinder.Condition.IsOnCondition)
                            {
                                pos = Position.Instance.Caxis[0].holes[Marking.LeftCcellNum].angle;
                                PushCylinder.Set();
                                CAxis.MoveTo(pos, AxisParameter.Instance.C1VelocityCurve);
                                step = 40;
                            }
                            break;
                        case 40://推出气缸到位，C轴准备好标志置位
                            if (PushCylinder.OutMoveStatus && CAxis.IsInPosition(pos))
                            {
                                Marking.LeftCAxis1Finish = true;
                                if (stationOperate.SingleRunning) Thread.Sleep(100);
                                step = 50;
                            }
                            break;
                        case 50://判断C轴准备好标志复位，穴数+1
                            if (!Marking.LeftCAxis1Finish || stationOperate.SingleRunning)
                            {
                                //判断是否废料清除
                                if (Marking.CleanMachineProduct)
                                {
                                    Marking.LeftCAxisHaveProduct = false;
                                    step = 90;
                                }
                                else
                                {
                                    Marking.LeftCcellNum++;
                                    if (Marking.LeftCcellNum <= Position.Instance.HoleNumber) step = 80;
                                    else step = 90;
                                }
                            }
                            break;
                        case 80://C轴移动到下一穴，C轴准备好标志置位。                           
                            pos = Position.Instance.Caxis[0].holes[Marking.LeftCcellNum].angle;
                            CAxis.MoveTo(pos, AxisParameter.Instance.C1VelocityCurve);
                            step = 81;
                            break;
                        case 81:
                            if (CAxis.IsInPosition(pos))
                            {
                                Marking.LeftCAxis1Finish = true;
                                Thread.Sleep(20);
                                step = 50;
                            }
                            break;
                        case 90://C轴准备好标志复位，推出气缸为OFF
                            if ((!Marking.LeftCAxis1Finish || stationOperate.SingleRunning)
                                && PushCylinder.Condition.IsOffCondition)
                            {
                                PushCylinder.Reset();
                                CAxis.MoveTo(Position.Instance.Caxis[0].Startangle, AxisParameter.Instance.C1VelocityCurve);
                                step = 100;
                            }
                            break;
                        case 100://推出气缸到达
                            if (CAxis.IsInPosition(Position.Instance.Caxis[0].Startangle) && PushCylinder.OutOriginStatus)
                            {
                                Marking.watchCT1.Stop();
                                Marking.watchCT1Value = Marking.watchCT1.ElapsedMilliseconds / 1000.0;
                                Marking.LeftCAxisHaveProduct = false;
                                step = 110;
                            }
                            break;
                        default:
                            Marking.LeftCcellNum = 0;
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
                            Marking.LeftCcellNum = 0;
                            Marking.LeftMoveFinish = false;
                            Marking.LeftCAxis1Finish = false;
                            CAxis.Stop();
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
                            CAxis.BackHome();
                            stationInitialize.Flow = 30;
                            break;
                        case 30:
                            if (CAxis.CheckHomeDone(500) == 0)
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
