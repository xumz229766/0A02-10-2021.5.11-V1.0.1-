using System.Collections.Generic;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
using Motion.LSAps;
namespace desay
{
    /// <summary>
    /// 右C轴模块
    /// </summary>
    public class RightC : ThreadPart
    {
        private RightCAlarm m_Alarm;
        public RightC(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
            Global.Alarms.Add(new Alarm(() => m_Alarm == RightCAlarm.初始化故障) { AlarmLevel = AlarmLevels.None, Name = RightCAlarm.初始化故障.ToString() });
            Global.Alarms.AddRange(CAxis.Alarms);
            Global.Alarms.AddRange(PushCylinder.Alarms);
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
                            Marking.watchCT3.Restart();
                            if (Marking.RightCAxisHaveProduct) step = 30;
                            else step = 10;
                            break;
                        case 10://判断C轴推出气缸状态是否在原点，然后将C轴移动1穴位置
                            if (CAxis.IsInPosition(Position.Instance.Caxis[3].Startangle)) step = 20;
                            else       
                            if (PushCylinder.OutOriginStatus)
                            {
                                CAxis.MoveTo(Position.Instance.Caxis[3].Startangle, AxisParameter.Instance.C4VlowVelocityCurve);
                                step = 20;
                            }
                            break;
                        case 20://C轴到达1穴位置，等待来料标志置位
                            if (CAxis.IsInPosition(Position.Instance.Caxis[3].Startangle))
                            {
                                Marking.RightMoveFinish = true;
                                step = 30;
                            }
                            break;
                        case 30://判断移料模组是否放好料，等待来料标志复位
                            if (!Marking.CleanMachineProduct && (!Marking.RightMoveFinish || stationOperate.SingleRunning) 
                                && PushCylinder.Condition.IsOnCondition)
                            {                             
                                pos = Position.Instance.Caxis[3].holes[Marking.MiddleCcellNum].angle;
                                Marking.RightCAxisHaveProduct = true;
                                PushCylinder.Set();
                                CAxis.MoveTo(pos, AxisParameter.Instance.C4VlowVelocityCurve);
                                step = 40;
                            }
                            break;
                        case 40://推出气缸到位，C轴准备好标志置位
                            if (PushCylinder.OutMoveStatus && CAxis.IsInPosition(pos))
                            {
                                Marking.RightCAxis2Finish = true;
                                if (stationOperate.SingleRunning) Thread.Sleep(100);
                                step = 50;
                            }
                            break;
                        case 50://判断C轴准备好标志复位，穴数+1
                            if (!Marking.RightCAxis2Finish || stationOperate.SingleRunning)
                            {
                                //判断是否废料清除
                                if (Marking.CleanMachineProduct)
                                {
                                    Marking.RightCAxisHaveProduct = false;
                                    step = 90;
                                }
                                else
                                {
                                    Marking.RightCcellNum++;
                                    if (Marking.RightCcellNum <= Position.Instance.HoleNumber) step = 80;
                                    else step = 90;
                                }
                            }
                            break;
                        case 80://C轴移动到下一穴，C轴准备好标志置位。                           
                            pos = Position.Instance.Caxis[3].holes[Marking.MiddleCcellNum].angle; 
                            CAxis.MoveTo(pos, AxisParameter.Instance.C4VlowVelocityCurve);
                            if (CAxis.IsInPosition(pos))
                            {
                                Marking.RightCAxis2Finish = true;
                                Thread.Sleep(20);
                                step = 50;
                            }
                            break;
                        case 90://C轴准备好标志复位，推出气缸为OFF
                            if ((!Marking.RightCAxis2Finish || stationOperate.SingleRunning)
                                && PushCylinder.Condition.IsOffCondition)
                            {
                                PushCylinder.Reset();
                                CAxis.MoveTo(Position.Instance.Caxis[3].Startangle, AxisParameter.Instance.C4VlowVelocityCurve);
                                step = 100;
                            }
                            break;
                        case 100://推出气缸到达
                            if (CAxis.IsInPosition(Position.Instance.Caxis[3].Startangle) &&PushCylinder.OutOriginStatus)
                            {
                                Marking.watchCT3.Stop();
                                Marking.watchCT3Value = Marking.watchCT3.ElapsedMilliseconds / 1000.0;
                                Marking.RightCAxisHaveProduct = false;
                                step = 110;
                            }
                            break;
                        default:
                            Marking.RightCcellNum = 0;
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
                            Marking.RightCcellNum = 0;                          
                            Marking.LeftMoveFinish = false;
                            Marking.RightCAxis2Finish = false;
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
                            Thread.Sleep(300);                           ;
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
                if (externalSign.AlarmReset) m_Alarm = RightCAlarm.无消息;
            }
        }
      
    }
}
