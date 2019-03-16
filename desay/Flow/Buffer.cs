using System.Collections.Generic;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
namespace desay
{
    /// <summary>
    /// 缓冲模组
    /// </summary>
    public class Buffer:ThreadPart
    {
        private BufferAlarm m_Alarm;
        public Buffer(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }
        /// <summary>
        /// 前后气缸
        /// </summary>
        public SingleCylinder FrontCylinder { get; set; }
        /// <summary>
        /// 上下气缸
        /// </summary>
        public SingleCylinder DownCylinder { get; set; }
        /// <summary>
        /// 夹子气缸
        /// </summary>
        public SingleCylinder GripperCylinder { get; set; }
        public override void Running(RunningModes runningMode)
        {
            var step = 0;
            while (true)
            {
                Thread.Sleep(10);
                FrontCylinder.Condition.External = externalSign;
                DownCylinder.Condition.External = externalSign;
                GripperCylinder.Condition.External = externalSign;
                #region  //自动流程
                if (stationOperate.Running)
                {
                    switch (step)
                    {
                        case 0:
                            if (true) step = 10;
                            break;
                        case 10:
                            if((Marking.NoRodFinish|| stationOperate.SingleRunning)
                                && FrontCylinder.OutOriginStatus && DownCylinder.OutOriginStatus
                                && GripperCylinder.OutOriginStatus && FrontCylinder.Condition.IsOnCondition)
                            {
                                FrontCylinder.Set();
                                step = 20;
                            }                                
                            break;
                        case 20:
                            if (FrontCylinder.OutMoveStatus && DownCylinder.Condition.IsOnCondition)
                            {
                                DownCylinder.Set();
                                step = 30;
                            }
                            break;
                        case 30:
                            if (DownCylinder.OutMoveStatus && GripperCylinder.Condition.IsOnCondition)
                            {
                                GripperCylinder.Set();
                                step = 40;
                            }
                            break;
                        case 40:
                            if (GripperCylinder.OutMoveStatus && DownCylinder.Condition.IsOffCondition)
                            {
                                DownCylinder.Reset();
                                step = 50;
                            }
                            break;
                        case 50:
                            if (DownCylinder.OutOriginStatus && FrontCylinder.Condition.IsOffCondition)
                            {
                                FrontCylinder.Reset();
                                step = 60;
                            }
                            break;
                        case 60:
                            if (FrontCylinder.OutOriginStatus)
                            {
                                Marking.NoRodFinish = false;
                                step = 70;
                            }
                            break;
                        case 70:
                            if (((!Marking.FeederHaveProduct &&Marking.FeederReady)|| stationOperate.SingleRunning) 
                                && IO10Points.DI10.Value && DownCylinder.Condition.IsOnCondition)
                            {
                                DownCylinder.Set();
                                step = 80;
                            }
                            break;
                        case 80:
                            if (DownCylinder.OutMoveStatus && GripperCylinder.Condition.IsOffCondition)
                            {
                                GripperCylinder.Reset();
                                step = 90;
                            }
                            break;
                        case 90:
                            if (GripperCylinder.OutOriginStatus && DownCylinder.Condition.IsOffCondition)
                            {
                                DownCylinder.Reset();
                                step = 100;
                            }
                            break;
                        case 100:
                            if (DownCylinder.OutOriginStatus)
                            {
                                Marking.BufferFinish = true;
                                step = 110;
                            }
                            break;
                        case 110:
                            if (Marking.CleanMachineProduct)
                            {
                                if (Marking.CleanSign[0]) Marking.CleanSign[1] = true;
                                step = 120;
                            }
                            else step = 120;
                            break;
                        default:
                            stationOperate.RunningSign = false;
                            step = 0;
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
                            Marking.BufferFinish = false;
                            stationInitialize.Flow = 10;
                            break;
                        case 10:
                            if (DownCylinder.Condition.IsOffCondition)
                            {
                                DownCylinder.InitExecute();
                                DownCylinder.Reset();
                                stationInitialize.Flow = 20;
                            }
                            break;
                        case 20:
                            if (DownCylinder.OutOriginStatus && FrontCylinder.Condition.IsOffCondition)
                            {
                                FrontCylinder.InitExecute();
                                FrontCylinder.Reset();
                                GripperCylinder.InitExecute();
                                GripperCylinder.Reset();
                                stationInitialize.Flow = 30;
                            }
                            break;
                        case 30:
                            if (FrontCylinder.OutOriginStatus && GripperCylinder.OutOriginStatus)
                            {
                                stationInitialize.InitializeDone = true;
                                stationInitialize.Flow = 40;
                            }
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                //故障清除
                if (externalSign.AlarmReset) m_Alarm = BufferAlarm.无消息;
            }
        }
        /// <summary>
        /// 流程报警集合
        /// </summary>
        public IList<Alarm> Alarms
        {
            get
            {
                var list = new List<Alarm>();
                list.Add(new Alarm(() => m_Alarm == BufferAlarm.初始化故障) { AlarmLevel = AlarmLevels.None, Name = BufferAlarm.初始化故障.ToString() });
                return list;
            }
        }
    }
}
