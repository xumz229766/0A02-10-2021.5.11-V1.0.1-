using System.Collections.Generic;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
namespace desay
{
    /// <summary>
    /// 进料模块
    /// </summary>
    public class Feeder : ThreadPart
    {
        private FeederAlarm m_Alarm;
        public Feeder(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }
        /// <summary>
        /// 进料气缸
        /// </summary>
        public SingleCylinder FeederCylinder { get; set; }  
        private int FailCount;   
        /// <summary>
        /// 流程控制
        /// </summary>
        /// <param name="runningMode"></param>
        public override void Running(RunningModes runningMode)
        {
            var step = 0;
            FailCount = 0;
            while (true)
            {
                Thread.Sleep(10);
                FeederCylinder.Condition.External = externalSign;
                #region  //自动流程
                if (stationOperate.Running)
                {
                    switch (step)
                    {
                        case 0:
                            if (Marking.FeederHaveProduct) step = 20;
                            else step = 10;
                            break;
                        case 10://判断进料气缸是否在原点，给出模组准备好信号
                            if (FeederCylinder.OutOriginStatus)
                            {
                                Marking.FeederReady = true;
                                step = 20;
                            }
                            break;
                        case 20://判断缓冲放料完成、移料等待标志。进料气缸为ON
                            if (((Marking.BufferFinish && !Marking.FeederHaveProduct) 
                                || (!Marking.BufferFinish && Marking.FeederHaveProduct)|| stationOperate.SingleRunning)
                                &&FeederCylinder.Condition.IsOnCondition)
                            {
                                FeederCylinder.Set();
                                Marking.FeederHaveProduct = true;
                                Marking.BufferFinish = false;
                                Marking.FeederReady = false;
                                step = 30;
                            }
                            break;
                        case 30://进料气缸到位动点，复位进料等待、置位进料准备标志
                            if (FeederCylinder.OutMoveStatus)
                            {
                                if (IO11Points.DI14.Value||Marking.HaveProductSensorSheild||Marking.CleanMachineProduct)
                                {
                                    Marking.FeederFinish = true;
                                    FailCount = 0;                                 
                                }
                                else
                                {
                                    Marking.FeederHaveProduct = false;
                                    FailCount++;
                                }
                                step = 40;
                            }
                            break;
                        case 40://判断移料等待信号，进料气缸为OFF
                            if (((!Marking.FeederFinish&& Marking.FeederHaveProduct)||!Marking.FeederHaveProduct 
                                || stationOperate.SingleRunning)&& FeederCylinder.Condition.IsOffCondition)
                            {
                                Marking.FeederHaveProduct = false;
                                FeederCylinder.Reset();
                                step = 50;
                            }
                            break;
                        case 50:
                            if (FeederCylinder.OutOriginStatus)
                            {
                                if (Marking.CleanMachineProduct)
                                    if (Marking.CleanSign[1])
                                        Marking.CleanSign[2] = true;
                                step = 60;
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
                        case 0://复位初始化、等待、准备标志
                            stationInitialize.InitializeDone = false;
                            stationOperate.RunningSign = false;
                            step = 0;
                            Marking.FeederFinish = false;
                            Marking.FeederReady = false;
                            Marking.FeederHaveProduct = false;
                            stationInitialize.Flow = 10;
                            break;
                        case 10://判断状态
                            if (FeederCylinder.Condition.IsOffCondition)
                            {
                                FeederCylinder.InitExecute();
                                FeederCylinder.Reset();
                                stationInitialize.Flow = 20;
                            }
                            break;
                        case 20://复位完成，置位初始化标志
                            if (FeederCylinder.OutOriginStatus)
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
                if (externalSign.AlarmReset)
                {
                    FailCount = 0;
                    m_Alarm = FeederAlarm.无消息;
                }
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
                list.Add(new Alarm(() => m_Alarm == FeederAlarm.初始化故障)
                {
                    AlarmLevel = AlarmLevels.None,
                    Name = FeederAlarm.初始化故障.ToString()
                });
                list.Add(new Alarm(() => FailCount >= Product.FeederFailCount)
                {
                    AlarmLevel = AlarmLevels.Error,
                    Name = string.Format("进料光纤有{0}次以上产品丢失或感应不良！",Product.FeederFailCount)
                });
                return list;
            }
        }
    }
}
