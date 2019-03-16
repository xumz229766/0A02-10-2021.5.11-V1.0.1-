using System.Collections.Generic;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
using Motion.LSAps;
namespace desay
{
    /// <summary>
    /// 右剪切模块
    /// </summary>
    public class RightCut1 : ThreadPart
    {
        private RightCutAlarm m_Alarm;
        public RightCut1(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }
        /// <summary>
        /// 剪切轴
        /// </summary>
        public ServoAxis CutAxis { get; set; }
        /// <summary>
        /// 前后气缸
        /// </summary>
        public SingleCylinder FrontCylinder { get; set; }
        /// <summary>
        /// 上下气缸
        /// </summary>
        public SingleCylinder DownCylinder { get; set; }
        /// <summary>
        /// 夹爪气缸
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
                #region 自动流程
                if (stationOperate.Running)
                {
                    switch (step)
                    {
                        case 0://判断是否有料
                            if (Marking.RightCut1HaveProduct) step = 210;
                            else step = 10;
                            break;
                        case 10://前后气缸为ON
                            if (DownCylinder.OutOriginStatus&&FrontCylinder.OutOriginStatus
                                &&GripperCylinder.OutOriginStatus && FrontCylinder.Condition.IsOnCondition)
                            {
                                FrontCylinder.Set();
                                step = 20;
                            }
                            break;
                        case 20://判断蜂窝该穴位是否屏蔽
                            if (FrontCylinder.OutMoveStatus && (Marking.RightCAxis1Finish
                                || stationOperate.SingleRunning))
                            {
                                if (Position.RightCAxis1Celloffset[Marking.RightCcellNum-1].Enable) step = 30;
                                else
                                {
                                    Thread.Sleep(10);
                                    FrontCylinder.Reset();
                                    step = 110;
                                }
                            }
                            break;
                        case 30://上下气缸到位，夹子气缸为ON
                            if (GripperCylinder.Condition.IsOffCondition)
                            {
                                GripperCylinder.Set();
                                step = 40;
                            }
                            break;
                        case 40://夹子气缸到位,伺服1#移动到剪切，启动运行
                            if (GripperCylinder.OutMoveStatus)
                            {
                                CutAxis.MoveTo(Position.RightCut1CutPosition, AxisParameter.RightCut1velocityCure);
                                step = 50;
                            }
                            break;
                        case 50://伺服1#到位，判断是否扭力剪切
                            if (CutAxis.IsInPosition(Position.RightCut1CutPosition))
                            {
                                Thread.Sleep(20);
                                if (Position.PosTorsion) step = 60;
                                else step = 70;
                            }
                            break;
                        case 60://启动伺服1#扭力剪切控制
                            IO13Points.DO2.Value = true;
                            if (IO12Points.DI14.Value)
                            {
                                IO13Points.DO2.Value = false;
                                Thread.Sleep(10);
                                step = 70;
                            }
                            break;
                        case 70://伺服1#移动0位置。
                            CutAxis.MoveTo(0, AxisParameter.RightCut1velocityCure);
                            step = 80;
                            break;
                        case 80://伺服1#到位。
                            if (CutAxis.IsInPosition(0))
                            {
                                Product.RightCut1Count++;
                                Thread.Sleep(20);
                                step = 90;
                            }
                            break;                        
                        case 90://判断剪切前后气缸off条件
                            if (FrontCylinder.Condition.IsOffCondition)
                            {
                                Product.Right1ProductTotal++;
                                Marking.RightCut1Num = Marking.MiddleCcellNum;
                                FrontCylinder.Reset();
                                step = 100;
                            }
                            break;
                        case 100://前后气缸到位，上下气缸为ON
                            if (FrontCylinder.OutOriginStatus && DownCylinder.Condition.IsOnCondition)
                            {
                                DownCylinder.Set();
                                step = 110;
                            }
                            break;
                        case 110://上下气缸到位，判断是否烫刀，前后气缸为On
                            if (DownCylinder.OutMoveStatus)
                            {
                                if (Product.Right1HotCut)
                                {
                                    if (FrontCylinder.Condition.IsOnCondition)
                                    {
                                        FrontCylinder.Set();
                                        step = 120;
                                    }
                                }
                                else step = 130;
                            }
                            break;
                        case 120://前后气缸到位，前后气缸为OFF
                            if (FrontCylinder.OutMoveStatus && FrontCylinder.Condition.IsOffCondition)
                            {
                                FrontCylinder.Reset();
                                step = 130;
                            }
                            break;
                        case 130://前后气缸到位，输出完成状态
                            if (FrontCylinder.OutOriginStatus)
                            {
                                Marking.RightCAxis1Finish = false;
                                Marking.RightCut1Finish = true;
                                step = 140;
                            }
                            break;
                        case 140://判断切料准备好，吸笔吸气标志状态，夹子气缸为OFF
                            if ((Marking.XYZRightInhale1Sign || stationOperate.SingleRunning)
                                && GripperCylinder.Condition.IsOffCondition)
                            {
                                GripperCylinder.Reset();
                                step = 150;
                            }
                            break;
                        case 150://夹子气缸到位，切料准备状态复位
                            if (GripperCylinder.OutOriginStatus)
                            {
                                Marking.XYZRightInhale1Sign = false;
                                if (Marking.RightCut1Num >= Position.TrayCellNum && Marking.ForceInPlate) Marking.RightCut1Done = true;
                                step = 160;
                            }
                            break;
                        case 160://判断吸笔吸气状态
                            if ((!Marking.RightCut1Finish || stationOperate.SingleRunning)
                                && DownCylinder.Condition.IsOffCondition)
                            {
                                Marking.RightCut1HaveProduct = false;
                                DownCylinder.Reset();
                                step = 170;
                            }
                            break;
                        case 170://判断吸笔吸气状态
                            if (DownCylinder.OutOriginStatus) step = 180;
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
                            Marking.RightCut1HaveProduct = false;
                            Marking.RightCut1Finish = false;
                            Marking.RightCut1Done = false;
                            IO13Points.DO2.Value = false;
                            CutAxis.Stop();
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
                            Thread.Sleep(10);
                            CutAxis.IsServon = true;
                            if (FrontCylinder.OutOriginStatus && GripperCylinder.OutOriginStatus)
                            {
                                Thread.Sleep(10);
                                stationInitialize.Flow = 40;
                            }
                            break;
                        case 40:
                            var _isOrigin1 = false;
                            if (CutAxis.IsOrigin)
                            {
                                _isOrigin1 = true;
                                CutAxis.MoveDelta(10000, AxisParameter.RightCut1velocityCure);
                            }
                            if (!_isOrigin1) stationInitialize.Flow = 60;
                            else stationInitialize.Flow = 50;
                            break;
                        case 50:
                            if (CutAxis.IsDone)
                            {
                                stationInitialize.Flow = 60;
                                Thread.Sleep(20);
                            }
                            break;
                        case 60:
                            Global.apsController.BackHome(CutAxis.NoId);
                            stationInitialize.Flow = 70;
                            break;
                        case 70:
                            var result1 = Global.apsController.CheckHomeDone(CutAxis.NoId, 20.0);
                            if (result1 == 0)
                            {
                                stationInitialize.InitializeDone = true;
                                stationInitialize.Flow = 80;
                            }
                            else if (result1 < 0)
                            {
                                stationInitialize.InitializeDone = false; ;
                                stationInitialize.Flow = -1;
                            }
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                //故障清除
                if (externalSign.AlarmReset) m_Alarm = RightCutAlarm.无消息;
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
                list.Add(new Alarm(() => m_Alarm == RightCutAlarm.初始化故障) { AlarmLevel = AlarmLevels.None, Name = RightCutAlarm.初始化故障.ToString() });
                return list;
            }
        }
    }
}
