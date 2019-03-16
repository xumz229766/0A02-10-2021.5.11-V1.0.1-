using System.Collections.Generic;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
namespace desay
{
    /// <summary>
    /// 移动模组
    /// </summary>
    public class Move : ThreadPart
    {
        private MoveAlarm m_Alarm;
        public Move(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }
        /// <summary>
        /// 左右气缸
        /// </summary>
        public SingleCylinder2 LeftCylinder { get; set; }
        /// <summary>
        /// 上下气缸
        /// </summary>
        public SingleCylinder DownCylinder { get; set; }
        /// <summary>
        /// 夹子气缸
        /// </summary>
        public SingleCylinder GripperCylinder { get; set; }
        /// <summary>
        /// 废料夹子气缸
        /// </summary>
        public SingleCylinder WasteGripperCylinder { get; set; }
        /// <summary>
        /// 气剪前后气缸
        /// </summary>
        public SingleCylinder AirCutFrontCylinder { get; set; }
        /// <summary>
        /// 气剪气缸
        /// </summary>
        public SingleCylinder AirCutCylinder { get; set; }
        public override void Running(RunningModes runningMode)
        {
            var step = 0;
            var Cell8Sign = false;
            while (true)
            {
                Thread.Sleep(10);
                LeftCylinder.Condition.External = externalSign;
                DownCylinder.Condition.External = externalSign;
                GripperCylinder.Condition.External = externalSign;
                WasteGripperCylinder.Condition.External = externalSign;
                AirCutFrontCylinder.Condition.External = externalSign;
                AirCutCylinder.Condition.External = externalSign;
                #region  //自动流程
                if (stationOperate.Running)
                {
                    switch (step)
                    {
                        case 0://判断蜂窝穴数
                            Marking.watchCT1.Restart();
                            Marking.watchCT2.Restart();
                            Marking.watchCT3.Restart();
                            step = 10;
                            break;
                        case 10://判断进料完成，左右C轴是否有料，移料上下气缸为ON
                            if ((((Marking.FeederFinish || (Marking.CleanMachineProduct && Marking.CleanSign[2]&&!Marking.CleanProductDone))
                                &&!Marking.LeftCAxisHaveProduct&& !Marking.MiddleCAxisHaveProduct && !Marking.RightCAxisHaveProduct
                                && Marking.LeftMoveFinish && Marking.MiddleMoveFinish&& Marking.RightMoveFinish) ||stationOperate.SingleRunning)
                                && LeftCylinder.OutOriginStatus&&DownCylinder.OutOriginStatus&&GripperCylinder.OutOriginStatus
                                && AirCutFrontCylinder.OutOriginStatus&& DownCylinder.Condition.IsOnCondition)
                            {
                                DownCylinder.Set();
                                step = 20;
                            }
                            break;
                        case 20://移料上下气缸到位，移料夹子为ON
                            if (DownCylinder.OutMoveStatus && GripperCylinder.Condition.IsOnCondition
                                && WasteGripperCylinder.Condition.IsOnCondition)
                            {
                                GripperCylinder.Set();
                                WasteGripperCylinder.Set();
                                step = 30;
                            }
                            break;
                        case 30://移料夹子到位，移料上下为OFF
                            if (GripperCylinder.OutMoveStatus&&WasteGripperCylinder.OutMoveStatus
                                && DownCylinder.Condition.IsOffCondition)
                            {
                                DownCylinder.Reset();
                                step = 40;
                            }
                            break;
                        case 40://移料上下到位，移料左右为ON
                            if (DownCylinder.OutOriginStatus) Marking.FeederFinish = false;
                            if ((!Marking.FeederFinish || stationOperate.SingleRunning)
                                && DownCylinder.OutOriginStatus && LeftCylinder.Condition.IsOnCondition)
                            {
                                LeftCylinder.Set();
                                step = 50;
                            }
                            break;
                        case 50://移料左右到位，移料上下为ON
                            if (LeftCylinder.OutMoveStatus && ((Marking.LeftMoveFinish && Marking.MiddleMoveFinish 
                                && Marking.RightMoveFinish) || stationOperate.SingleRunning))
                            {
                                DownCylinder.Set();
                                step = 60;
                            }
                            break;
                        case 60://移料上下到位，移料夹子为OFF
                            if (DownCylinder.OutMoveStatus && GripperCylinder.Condition.IsOffCondition
                                && (Product.AirCutSheild ? WasteGripperCylinder.Condition.IsOffCondition : true))
                            {
                                GripperCylinder.Reset();
                                if (Product.AirCutSheild) WasteGripperCylinder.Reset();
                                step = 70;
                            }
                            break;
                        case 70://移料夹子到位，移料上下为OFF
                            if (GripperCylinder.OutOriginStatus&&(Product.AirCutSheild?WasteGripperCylinder.OutOriginStatus:true)
                                && DownCylinder.Condition.IsOffCondition)
                            {
                                DownCylinder.Reset();
                                step = 71;
                            }
                            break;
                        case 71:
                            if (!Product.AirCutSheild&&DownCylinder.OutOriginStatus && AirCutFrontCylinder.Condition.IsOnCondition)
                            {
                                if (!Marking.CleanMachineProduct)
                                {
                                    Marking.LeftMoveFinish = false;
                                    Marking.MiddleMoveFinish = false;
                                    Marking.RightMoveFinish = false;
                                }
                                AirCutFrontCylinder.Set();
                                step = 72;
                            }
                            if (Product.AirCutSheild && DownCylinder.OutOriginStatus)
                            {
                                if (!Marking.CleanMachineProduct)
                                {
                                    Marking.LeftMoveFinish = false;
                                    Marking.MiddleMoveFinish = false;
                                    Marking.RightMoveFinish = false;
                                }
                                step = 80;
                            }
                            break;
                        case 72:
                            if (AirCutFrontCylinder.OutMoveStatus && AirCutCylinder.Condition.IsOnCondition)
                            {
                                AirCutCylinder.Set();
                                step = 73;
                            }
                            break;
                        case 73:
                            if(AirCutCylinder.OutMoveStatus&&AirCutCylinder.Condition.IsOffCondition)
                            {
                                AirCutCylinder.Reset();
                                step = 74;
                            }
                            break;
                        case 74:
                            if(AirCutCylinder.OutOriginStatus&&AirCutFrontCylinder.Condition.IsOffCondition)
                            {
                                AirCutFrontCylinder.Reset();
                                step = 75;
                            }
                            break;
                        case 75:
                            if(AirCutFrontCylinder.OutOriginStatus && WasteGripperCylinder.Condition.IsOffCondition)
                            {
                                WasteGripperCylinder.Reset();
                                step = 80;
                            }
                            break;
                        case 80://移料上下到位，判断蜂窝是8穴还是16穴，移料左右为OFF
                            if (WasteGripperCylinder.OutOriginStatus && LeftCylinder.Condition.IsOffCondition)
                            {
                                LeftCylinder.Reset();
                                step = 90;
                            }
                            break;
                        case 90://移料左右到位
                            if (LeftCylinder.OutOriginStatus)
                            {
                                if (Marking.CleanMachineProduct)
                                {
                                    if (Marking.CleanSign[2] && Marking.CleanSign[3] && Marking.CleanSign[4] && Marking.CleanSign[5] && Marking.CleanSign[6]) Marking.CleanSign[7] = true;
                                    if (Marking.CleanSign[2] && Marking.CleanSign[3] && Marking.CleanSign[4] && Marking.CleanSign[5]) Marking.CleanSign[6] = true;
                                    if (Marking.CleanSign[2] && Marking.CleanSign[3] && Marking.CleanSign[4]) Marking.CleanSign[5] = true;
                                    if (Marking.CleanSign[2] && Marking.CleanSign[3] && !Marking.CleanSign[4]) Marking.CleanSign[4] = true;
                                    if (Marking.CleanSign[2] && !Marking.CleanSign[3]) Marking.CleanSign[3] = true;
                                    if (Marking.CleanSign[2] && Marking.CleanSign[7]) Marking.CleanProductDone = true;
                                }
                                step = 100;                               
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
                            Marking.LeftMoveFinish = false;
                            Marking.MiddleMoveFinish = false;
                            Marking.RightMoveFinish = false;
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
                            if (DownCylinder.OutOriginStatus && LeftCylinder.Condition.IsOffCondition)
                            {
                                LeftCylinder.InitExecute();
                                LeftCylinder.Reset();
                                GripperCylinder.InitExecute();
                                GripperCylinder.Reset();
                                WasteGripperCylinder.InitExecute();
                                WasteGripperCylinder.Reset();
                                AirCutFrontCylinder.InitExecute();
                                AirCutFrontCylinder.Reset();
                                AirCutCylinder.InitExecute();
                                AirCutCylinder.Reset();
                                stationInitialize.Flow = 30;
                            }
                            break;
                        case 30:
                            if (LeftCylinder.OutOriginStatus  && GripperCylinder.OutOriginStatus &&
                                WasteGripperCylinder.OutOriginStatus&& AirCutFrontCylinder.OutOriginStatus
                                && AirCutCylinder.OutOriginStatus)
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
                if (externalSign.AlarmReset) m_Alarm = MoveAlarm.无消息;
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
                list.Add(new Alarm(() => m_Alarm == MoveAlarm.初始化故障) { AlarmLevel = AlarmLevels.None, Name = MoveAlarm.初始化故障.ToString() });
                return list;
            }
        }
    }
}
