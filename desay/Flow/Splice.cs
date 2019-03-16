using System.Collections.Generic;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
using System.Diagnostics;
namespace desay
{
    /// <summary>
    /// 接料模组
    /// </summary>
    public class Splice:ThreadPart
    {
        private SpliceAlarm m_Alarm;
        private readonly Stopwatch _watch = new Stopwatch();
        public Splice(External ExternalSign,StationInitialize stationIni,StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }
        /// <summary>
        /// 无杆接料气缸
        /// </summary>
        public DoubleCylinder NoRodFeedCylinder { get; set; }
        public override void Running(RunningModes runningMode)
        {
            var step = 0;
            while (true)
            {
                Thread.Sleep(10);
                NoRodFeedCylinder.Condition.External = externalSign;
                #region  //自动流程
                if (stationOperate.Running)
                {
                    switch (step)
                    {
                        case 0:
                            if (Marking.CleanMachineProduct && !Marking.CleanSign[0]) step = 30;
                            if (!Marking.CleanMachineProduct) step = 10;
                            break;
                        case 10:
                            if (!Marking.CleanMachineProduct&&(IO10Points.DI2.Value||Marking.SensorSheild)&&!Marking.NoRodFinish 
                                && NoRodFeedCylinder.Condition.IsOnCondition)
                            {
                                NoRodFeedCylinder.Set();
                                step = 20;
                            }
                            if (Marking.CleanMachineProduct) step = 30;
                            break;
                        case 20:
                            if (NoRodFeedCylinder.OutMoveStatus&&(!IO10Points.DI2.Value || Marking.SensorSheild)
                                && NoRodFeedCylinder.Condition.IsOffCondition)
                            {
                                NoRodFeedCylinder.Reset();
                                step = 30;
                            }
                            break;
                        case 30:
                            if(NoRodFeedCylinder.OutOriginStatus)
                            {
                                Marking.NoRodFinish = true;
                                step = 40;
                            }
                            break;
                        case 40:
                            if (!Marking.NoRodFinish|| stationOperate.SingleRunning)
                            {                                
                                if (Marking.CleanMachineProduct) Marking.CleanSign[0] = true;
                                step = 50;
                            }
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
                            Marking.NoRodFinish = false;
                            stationInitialize.Flow = 10;
                            break;
                        case 10:
                            if (NoRodFeedCylinder.Condition.IsOffCondition)
                            {
                                NoRodFeedCylinder.InitExecute();
                                NoRodFeedCylinder.Reset();
                                stationInitialize.Flow = 20;
                            }
                            break;
                        case 20:
                            if (NoRodFeedCylinder.OutOriginStatus)
                            {
                                stationInitialize.InitializeDone = true;
                                stationInitialize.Flow = 30;
                            }
                            break;
                        default:
                            break;
                    }
                }
                #endregion
                //故障清除
                if (externalSign.AlarmReset) m_Alarm = SpliceAlarm.无消息;
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
                list.Add(new Alarm(() => m_Alarm == SpliceAlarm.初始化故障)
                {
                    AlarmLevel = AlarmLevels.None,
                    Name = SpliceAlarm.初始化故障.ToString()
                });
                list.Add(new Alarm(() => m_Alarm == SpliceAlarm.无杆气缸回原点超时)
                {
                    AlarmLevel = AlarmLevels.Error,
                    Name = SpliceAlarm.无杆气缸回原点超时.ToString()
                });
                list.Add(new Alarm(() => m_Alarm == SpliceAlarm.无杆气缸上升时感应超时)
                {
                    AlarmLevel = AlarmLevels.Error,
                    Name = SpliceAlarm.无杆气缸上升时感应超时.ToString()
                });
                list.Add(new Alarm(() => m_Alarm == SpliceAlarm.无杆气缸下降时感应超时)
                {
                    AlarmLevel = AlarmLevels.Error,
                    Name = SpliceAlarm.无杆气缸下降时感应超时.ToString()
                });
                return list;
            }
        }
    }
}
