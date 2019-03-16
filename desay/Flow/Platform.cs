using System;
using System.Collections.Generic;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
using Motion.LSAps;
using System.ToolKit;
namespace desay
{
    /// <summary>
    /// XYZ平台模组
    /// </summary>
    public class Platform : ThreadPart
    {
        private PlateformAlarm m_Alarm;

        public Platform(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }

        #region 属性
        /// <summary>
        /// X轴
        /// </summary>
        public ServoAxis Xaxis { get; set; }
        /// <summary>
        /// Y轴
        /// </summary>
        public ServoAxis Yaxis { get; set; }
        /// <summary>
        /// Z轴
        /// </summary>
        public ServoAxis Zaxis { get; set; }
        /// <summary>
        /// 左右1#气缸
        /// </summary>
        public SingleCylinder2 Left1Cylinder { get; set; }
        /// <summary>
        /// 左右2#气缸
        /// </summary>
        public SingleCylinder2 Left2Cylinder { get; set; }
        /// <summary>
        /// 左1#吸笔吸气电磁阀
        /// </summary>
        public VacuoBrokenCylinder Left1InhaleCylinder { get; set; }
        /// <summary>
        /// 左2#吸笔吸气电磁阀
        /// </summary>
        public VacuoBrokenCylinder Left2InhaleCylinder { get; set; }
        /// <summary>
        /// 右1#吸笔吸气电磁阀
        /// </summary>
        public VacuoBrokenCylinder Right1InhaleCylinder { get; set; }
        /// <summary>
        /// 右2#吸笔吸气电磁阀
        /// </summary>
        public VacuoBrokenCylinder Right2InhaleCylinder { get; set; }
        /// <summary>
        /// 取放盘上下气缸
        /// </summary>
        public SingleCylinder GetTrayCylinder { get; set; }
        /// <summary>
        /// 摆盘卡紧气缸
        /// </summary>
        public SingleCylinder LockCylinder { get; set; }
        #endregion
        private bool GettingPlate, PuttingPlate;
        public override void Running(RunningModes runningMode)
        {
            var step = 0;
            Point3D<int> pos = new Point3D<int>() ;
            while (true)
            {
                Thread.Sleep(10);
                Left1Cylinder.Condition.External = externalSign;
                Left2Cylinder.Condition.External = externalSign;
                Left1InhaleCylinder.Condition.External = externalSign;
                Left2InhaleCylinder.Condition.External = externalSign;
                Right1InhaleCylinder.Condition.External = externalSign;
                Right2InhaleCylinder.Condition.External = externalSign;
                GetTrayCylinder.Condition.External = externalSign;
                LockCylinder.Condition.External = externalSign;
                //Y轴安全位置判断
                if (Yaxis.IsAlarmed || (Yaxis.CurrentPos < Product.SafePosition.Y
                    && Yaxis.IsDone) || !Yaxis.IsServon)
                    Marking.YMoveToNoInSafePostioin = true;
                else Marking.YMoveToNoInSafePostioin = false;

                #region 自动流程
                if (stationOperate.Running)
                {
                    switch (step)
                    {
                        case 0:
                            if (Marking.HavePlateInPlateform)
                            {
                                if (LockCylinder.OutOriginStatus
                                    && GetTrayCylinder.OutOriginStatus)
                                    step = 130;
                                else m_Alarm = PlateformAlarm.卡紧气缸或取放盘气缸没有复位;
                            }
                            else
                            {
                                if (!Marking.HaveTraySensorSheild)
                                {
                                    if (IO14Points.DI8.Value || IO14Points.DI9.Value || IO14Points.DI10.Value || IO14Points.DI11.Value)
                                        m_Alarm = PlateformAlarm.台面上已有承盘设置报错;
                                    else step = 10;
                                }
                                else step = 10;
                                
                            }
                            break;
                        case 10://判断气缸是否在原点，Z轴是否在安全位置
                            if (GetTrayCylinder.OutOriginStatus)
                            {
                                GettingPlate = true;
                                if (!Zaxis.IsInPosition(Product.SafePosition.Z))
                                    Zaxis.MoveTo(Product.SafePosition.Z, AxisParameter.ZvelocityCure);
                                step = 20;
                            }
                            break;
                        case 20://检测Z轴是否到达安全位置，判断Y轴是否在安全位置
                            if (Zaxis.IsInPosition(Product.SafePosition.Z))
                            {
                                if (!Yaxis.IsInPosition(Product.SafePosition.Y))
                                    Yaxis.MoveTo(Product.SafePosition.Y, AxisParameter.YvelocityCure);
                                step = 30;
                            }
                            break;
                        case 30://检测Y轴是否到达安全位置,卡紧气缸为ON
                            if (Yaxis.IsInPosition(Product.SafePosition.Y) && LockCylinder.Condition.IsOnCondition)
                            {
                                //Thread.Sleep(20);
                                LockCylinder.Set();
                                step = 40;
                            }
                            break;
                        case 40://判断M轴是否移动，仓储是否准备好
                            if (LockCylinder.OutMoveStatus && ((Marking.MIsNoMoving && Marking.StoreFinish)
                                ||stationOperate.SingleRunning))
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisGetPlateSpeed };
                                Yaxis.MoveTo(Position.GetFirstGetPosition, velocityCure);
                                step = 50;
                            }
                            break;
                        case 50://判断Y轴是否到达首次取Tray位置，取放料盘气缸为ON
                            if (Yaxis.IsInPosition(Position.GetFirstGetPosition) && GetTrayCylinder.Condition.IsOnCondition)
                            {
                                GetTrayCylinder.Set();
                                step = 60;
                            }
                            break;
                        case 60://取放料盘气缸到位，Y轴移动首次放Tray盘位置
                            if (GetTrayCylinder.OutMoveStatus)
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisGetPlateSpeed };
                                Yaxis.MoveTo(Position.GetFirstPutPosition, velocityCure);
                                step = 70;
                            }
                            break;
                        case 70://判断Y轴是否到达首次放Tray盘位置,取放料盘气缸为OFF
                            if (Yaxis.IsInPosition(Position.GetFirstPutPosition) && GetTrayCylinder.Condition.IsOffCondition)
                            {
                                GetTrayCylinder.Reset();
                                step = 80;
                            }
                            break;
                        case 80://取放料盘气缸到位，Y轴移动二次放Tray盘位置
                            if (GetTrayCylinder.OutOriginStatus)
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisGetPlateSpeed };
                                Yaxis.MoveTo(Position.GetSecondGetPosition, velocityCure);
                                step = 90;
                            }
                            break;
                        case 90://判断Y轴是否到达二次取Tray位置，取放料盘气缸为ON
                            if (Yaxis.IsInPosition(Position.GetSecondGetPosition) && GetTrayCylinder.Condition.IsOnCondition)
                            {
                                GetTrayCylinder.Set();
                                step = 100;
                            }
                            break;
                        case 100://判断取放盘气缸到位，Y轴移动二次放Tray盘位置
                            if (GetTrayCylinder.OutMoveStatus)
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisGetPlateSpeed };
                                Yaxis.MoveTo(Position.GetSecondPutPosition, velocityCure);
                                step = 110;
                            }
                            break;
                        case 110://判断Y轴是否到达二次放Tray盘位置,卡紧气缸为OFF，取放盘气缸为OFF
                            if (Yaxis.IsInPosition(Position.GetSecondPutPosition) && LockCylinder.Condition.IsOffCondition)
                            {
                                LockCylinder.Reset();
                                GetTrayCylinder.Reset();
                                step = 120;
                            }
                            break;
                        case 120://卡紧气缸，取放盘气缸到达
                            if (LockCylinder.OutOriginStatus && GetTrayCylinder.OutOriginStatus
                                && ((IO14Points.DI8.Value && IO14Points.DI9.Value)||Marking.HaveTraySensorSheild))
                            {
                                Marking.PlateIndex = 1;
                                Marking.TrayIndex = 1;
                                Marking.HavePlateInPlateform = true;
                                step = 130;
                            }
                            break;
                        case 130://判断Z轴是否在安全位置
                            GettingPlate = false;
                            if (!Zaxis.IsInPosition(Product.SafePosition.Z))
                                Zaxis.MoveTo(Product.SafePosition.Z, AxisParameter.ZvelocityCure);
                            try
                            {
                                pos = Plate.GetPosition(Marking.PlateIndex, Marking.TrayIndex);
                            }
                            catch(Exception ex)
                            {
                                m_Alarm = PlateformAlarm.坐标计算失败Tray盘设置出错;
                            }
                            step = 140;
                            break;
                        case 140://XY轴移动取产品位置
                            if (Zaxis.IsInPosition(Product.SafePosition.Z)&&
                                ((Position.InhaleLeft1OpenClose&& Left1Cylinder.Condition.IsOffCondition)||
                                (!Position.InhaleLeft1OpenClose && Left1Cylinder.Condition.IsOnCondition)) &&
                                ((Position.InhaleLeft2OpenClose && Left2Cylinder.Condition.IsOffCondition) ||
                                (!Position.InhaleLeft2OpenClose && Left2Cylinder.Condition.IsOnCondition)))
                            {
                                if (Position.InhaleLeft1OpenClose) Left1Cylinder.Reset();
                                else Left1Cylinder.Set();
                                if (Position.InhaleLeft2OpenClose) Left2Cylinder.Reset();
                                else Left2Cylinder.Set();
                                if (!Marking.LeftCut1Done && !Marking.LeftCut2Done 
                                    && !Marking.RightCut1Done && !Marking.RightCut2Done)
                                {
                                    Xaxis.MoveTo(Position.GetProductPosition.X, AxisParameter.XvelocityCure);
                                    Yaxis.MoveTo(Position.GetProductPosition.Y, AxisParameter.YvelocityCure);
                                    step = 150;
                                }
                                else step = 270;
                            }
                            break;
                        case 150://XY到达取产品位置,判断左右剪切是否准备好
                            var status0 = Xaxis.IsInPosition(Position.GetProductPosition.X);
                            var status1 = Yaxis.IsInPosition(Position.GetProductPosition.Y);
                            if (status0 && status1 &&
                                ((Position.InhaleLeft1OpenClose&& Left1Cylinder.OutOriginStatus) 
                                ||(!Position.InhaleLeft1OpenClose && Left1Cylinder.OutMoveStatus)) &&
                                ((Position.InhaleLeft2OpenClose && Left2Cylinder.OutOriginStatus)
                                || (!Position.InhaleLeft2OpenClose && Left2Cylinder.OutMoveStatus)))
                            {
                                if ((Marking.LeftCut1Finish && Marking.LeftCut2Finish && Marking.RightCut1Finish && Marking.RightCut2Finish)
                                    || stationOperate.SingleRunning)
                                {
                                    Zaxis.MoveTo(Position.GetProductPosition.Z, AxisParameter.ZvelocityCure);
                                    step = 160;
                                }
                            }
                            break;
                        case 160://判断Z轴到达，左右吸笔为ON
                            if (Zaxis.IsInPosition(Position.GetProductPosition.Z))
                            {
                                Left1InhaleCylinder.Set();
                                Left2InhaleCylinder.Set();
                                Right1InhaleCylinder.Set();
                                Right2InhaleCylinder.Set();
                                step = 170;
                            }
                            break;
                        case 170://判断左右吸笔到位，吸笔吸气标志输出
                            if (Left1InhaleCylinder.OutMoveStatus&&Left2InhaleCylinder.OutMoveStatus
                                &&Right1InhaleCylinder.OutMoveStatus&&Right2InhaleCylinder.OutMoveStatus)
                            {
                                Marking.XYZLeftInhale1Sign = true;
                                Marking.XYZLeftInhale2Sign = true;
                                Marking.XYZRightInhale1Sign = true;
                                Marking.XYZRightInhale2Sign = true;
                                step = 180;
                            }
                            break;
                        case 180://等待左右剪切清除吸笔吸气输出标志，Z轴移动安全位置
                            if ((!Marking.XYZLeftInhale1Sign && !Marking.XYZLeftInhale2Sign && !Marking.XYZRightInhale1Sign 
                                && !Marking.XYZRightInhale2Sign) || stationOperate.SingleRunning)
                            {
                                Zaxis.MoveTo(Product.SafePosition.Z, AxisParameter.ZvelocityCure);
                                step = 190;
                            }
                            break;
                        case 190://Z轴到达安全位置，XY移动对应点位置,吸笔左右气缸为ON
                            if (Zaxis.IsInPosition(Product.SafePosition.Z) &&
                                ((Position.InhaleLeft1OpenClose && Left1Cylinder.Condition.IsOnCondition) ||
                                (!Position.InhaleLeft1OpenClose && Left1Cylinder.Condition.IsOffCondition)) &&
                                ((Position.InhaleLeft2OpenClose && Left2Cylinder.Condition.IsOnCondition) ||
                                (!Position.InhaleLeft2OpenClose && Left2Cylinder.Condition.IsOffCondition)))
                            {
                                Marking.LeftCut1Finish = false;
                                Marking.LeftCut2Finish = false;
                                Marking.RightCut1Finish = false;
                                Marking.RightCut2Finish = false;
                                if (Position.InhaleLeft1OpenClose) Left1Cylinder.Set();
                                else Left1Cylinder.Reset();
                                if (Position.InhaleLeft2OpenClose) Left2Cylinder.Set();
                                else Left2Cylinder.Reset();
                                Xaxis.MoveTo(pos.X, AxisParameter.XvelocityCure);
                                Yaxis.MoveTo(pos.Y, AxisParameter.YvelocityCure);
                                step = 200;
                            }
                            break;
                        case 200://XY到达对应点位置，吸笔左右气缸到达，Z轴移动对应点位置
                            if (Xaxis.IsInPosition(pos.X)&& Yaxis.IsInPosition(pos.Y)&& 
                                ((!Position.InhaleLeft1OpenClose && Left1Cylinder.OutOriginStatus)
                                || (Position.InhaleLeft1OpenClose && Left1Cylinder.OutMoveStatus)) &&
                                ((!Position.InhaleLeft2OpenClose && Left2Cylinder.OutOriginStatus)
                                || (Position.InhaleLeft2OpenClose && Left2Cylinder.OutMoveStatus)))
                            {
                                Zaxis.MoveTo(pos.Z, AxisParameter.ZvelocityCure);
                                step = 220;
                            }
                            break;
                        case 220://Z轴到达对应点位置，左右吸笔为OFF，破真空
                            if (Zaxis.IsInPosition(pos.Z))
                            {
                                Thread.Sleep(Product.ZAxisInTrayStopTime <= 0 ? 100 : Product.ZAxisInTrayStopTime);
                                Left1InhaleCylinder.Reset();
                                Left2InhaleCylinder.Reset();
                                Right1InhaleCylinder.Reset();
                                Right2InhaleCylinder.Reset();
                                step = 230;
                            }
                            break;
                        case 230://左右吸笔到达
                            if (Left1InhaleCylinder.OutOriginStatus&&Left2InhaleCylinder.OutOriginStatus
                                &&Right1InhaleCylinder.OutOriginStatus&&Right2InhaleCylinder.OutOriginStatus)
                            {
                                Zaxis.MoveTo(Product.SafePosition.Z, AxisParameter.ZvelocityCure);
                                step = 240;
                            }
                            break;
                        case 240://Z轴到达安全位置，吸笔左右气缸为OFF
                            if (Zaxis.IsInPosition(Product.SafePosition.Z))
                            { 
                                Marking.PlateIndex += 1;
                                //var Num = Position.MainTrayColumnNum * Position.MainTrayRowNum;
                                if (Marking.PlateIndex <= Position.TrayCellNum) step = 130;
                                else step = 260;
                            }
                            break;
                        case 260://承盘大于设定值，Tray盘计数+1
                            Marking.TrayIndex += 1;
                            if (Marking.TrayIndex <= Position.SubTray.EndPos)
                            {
                                Marking.PlateIndex = 1;
                                step = 130;
                            }
                            else step = 270;
                            break;
                        case 270://Tray盘大于设定值，判断仓储轴是否动作,卡紧气缸为ON
                            if((Marking.MIsNoMoving || stationOperate.SingleRunning) && LockCylinder.Condition.IsOnCondition)
                            {
                                PuttingPlate = true;
                                LockCylinder.Set();
                                step = 280;
                            }
                            break;
                        case 280://判断卡紧气缸气缸到位，Y轴移动二次放Tray盘位置
                            if (LockCylinder.OutMoveStatus)
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisPutPlateSpeed };
                                Yaxis.MoveTo(Position.PutFirstGetPosition, velocityCure);
                                step = 290;
                            }
                            break;
                        case 290://判断Y轴是否到达二次放Tray盘位置,取放盘气缸为ON
                            if (Yaxis.IsInPosition(Position.PutFirstGetPosition) && GetTrayCylinder.Condition.IsOnCondition)
                            {
                                GetTrayCylinder.Set();
                                step = 300;
                            }
                            break;
                        case 300://判断取放盘气缸到位，Y轴移动二次取Tray盘位置
                            if (GetTrayCylinder.OutMoveStatus)
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisPutPlateSpeed };
                                Yaxis.MoveTo(Position.PutFirstPutPosition, velocityCure);
                                step = 310;
                            }
                            break;
                        case 310://判断Y轴是否到达二次取Tray盘位置,取放盘气缸为OFF
                            if (Yaxis.IsInPosition(Position.PutFirstPutPosition) && GetTrayCylinder.Condition.IsOffCondition)
                            {
                                GetTrayCylinder.Reset();
                                step = 320;
                            }
                            break;
                        case 320://判断取放盘气缸到位，Y轴移动首次放Tray盘位置
                            if (GetTrayCylinder.OutOriginStatus)
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisPutPlateSpeed };
                                Yaxis.MoveTo(Position.PutSecondGetPosition, velocityCure);
                                step = 330;
                            }
                            break;
                        case 330://判断Y轴是否到达首次放Tray盘位置,取放料气缸为ON
                            if (Yaxis.IsInPosition(Position.PutSecondGetPosition) && GetTrayCylinder.Condition.IsOnCondition)
                            {
                                GetTrayCylinder.Set();
                                step = 340;
                            }
                            break;
                        case 340://判断取放盘气缸到位，Y轴移动首次取Tray盘位置
                            if (GetTrayCylinder.OutMoveStatus)
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisPutPlateSpeed };
                                Yaxis.MoveTo(Position.PutSecondPutPosition, velocityCure);
                                step = 350;
                            }
                            break;
                        case 350://判断Y轴是否到达首次取Tray盘位置,取放料气缸为Off
                            if (Yaxis.IsInPosition(Position.PutSecondPutPosition) && GetTrayCylinder.Condition.IsOffCondition)
                            {
                                GetTrayCylinder.Reset();
                                step = 360;
                            }
                            break;
                        case 360://判断取放盘气缸到位，Y轴移动安全位置
                            if (GetTrayCylinder.OutOriginStatus)
                            {
                                var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisPutPlateSpeed };
                                Yaxis.MoveTo(Product.SafePosition.Y, velocityCure);
                                step = 370;
                            }
                            break;
                        case 370://判断Y轴是否到达安全位置,复位取Tray完成信号、仓储准备好信号
                            if (Yaxis.IsInPosition(Product.SafePosition.Y)&&(!IO14Points.DI8.Value 
                                && !IO14Points.DI9.Value && !IO14Points.DI10.Value && !IO14Points.DI11.Value)
                                ||Marking.HaveTraySensorSheild)
                            {
                                Marking.ForceInPlate = false;
                                Marking.LeftCut1Done = false;
                                Marking.LeftCut2Done = false;
                                Marking.RightCut1Done = false;
                                Marking.RightCut2Done = false;
                                Marking.HavePlateInPlateform = false;
                                Marking.StoreFinish = false;
                                step = 380;
                            }
                            break;
                        default:
                            PuttingPlate = false;
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
                        case 0:   //清除所有标志位的状态
                            stationInitialize.InitializeDone = false;
                            stationOperate.RunningSign = false;
                            step = 0;
                            Xaxis.Stop();
                            Yaxis.Stop();
                            Zaxis.Stop();
                            if (!Xaxis.IsAlarmed && !Yaxis.IsAlarmed && !Zaxis.IsAlarmed)
                            {
                                Xaxis.IsServon = true;
                                Yaxis.IsServon = true;
                                Zaxis.IsServon = true;
                                stationInitialize.Flow = 10;
                            }
                            break;
                        case 10:  //复位所有气缸的动作
                            Left1Cylinder.InitExecute();
                            Left1Cylinder.Reset();
                            Left2Cylinder.InitExecute();
                            Left2Cylinder.Reset();
                            Left1InhaleCylinder.InitExecute();
                            Left1InhaleCylinder.Reset();
                            Left2InhaleCylinder.InitExecute();
                            Left2InhaleCylinder.Reset();
                            Right1InhaleCylinder.InitExecute();
                            Right1InhaleCylinder.Reset();
                            Right2InhaleCylinder.InitExecute();
                            Right2InhaleCylinder.Reset();
                            GetTrayCylinder.InitExecute();
                            GetTrayCylinder.Reset();
                            LockCylinder.InitExecute();
                            LockCylinder.Reset();
                            stationInitialize.Flow = 20;
                            break;
                        case 20:    //判断所有气缸到位，启动Z轴回原点
                            if (Left1Cylinder.OutOriginStatus&&Left2Cylinder.OutOriginStatus
                                &&Left1InhaleCylinder.OutOriginStatus&&Left2InhaleCylinder.OutOriginStatus
                                &&Right1InhaleCylinder.OutOriginStatus&&Right2InhaleCylinder.OutOriginStatus
                                &&LockCylinder.OutOriginStatus&&GetTrayCylinder.OutOriginStatus)
                                stationInitialize.Flow = 40;
                            break;
                        case 40:  //若Z轴在原点位异常，启动Z轴寸动循环
                            if (Zaxis.IsOrigin)
                            {
                                Zaxis.MoveDelta(15000, AxisParameter.ZvelocityCure);
                                stationInitialize.Flow = 50;
                            }
                            else
                                stationInitialize.Flow = 60;
                            break;
                        case 50://判断Z轴是否动作完成
                            if (Zaxis.IsDone)
                            {
                                stationInitialize.Flow = 60;
                                Thread.Sleep(30);
                            }
                            break;
                        case 60://启动Z轴回原点
                            Global.apsController.BackHome(Zaxis.NoId);
                            stationInitialize.Flow = 70;
                            break;
                        case 70://判断Z轴回原点是否完成，Z轴移动安全位置
                            if (Global.apsController.CheckHomeDone(Zaxis.NoId, 10.0) == 0)
                            {
                                Thread.Sleep(30);
                                Zaxis.MoveTo(Product.SafePosition.Z, AxisParameter.ZvelocityCure);
                                stationInitialize.Flow = 80;
                            }
                            else  //异常处理
                            {
                                stationInitialize.InitializeDone = false; ;
                                stationInitialize.Flow = -1;
                            }
                            break;
                        case 80://判断Z轴是否到达安全位置
                            if (Zaxis.IsInPosition(Product.SafePosition.Z))
                            {
                                Global.apsController.BackHome(Xaxis.NoId);
                                Global.apsController.BackHome(Yaxis.NoId);
                                stationInitialize.Flow = 90;
                            }
                            break;
                        case 90://判断XY轴是否异常，为0,正常，为1：原点异常，为<0：故障
                            var resultX = Global.apsController.CheckHomeDone(Xaxis.NoId, 10.0);
                            var resultY = Global.apsController.CheckHomeDone(Yaxis.NoId, 10.0);
                            if (resultX == 0 && resultY == 0) stationInitialize.Flow = 130;
                            else if (resultX == 1 || resultY == 1)
                            {
                                Xaxis.Stop();
                                Yaxis.Stop();
                                Thread.Sleep(20);
                                stationInitialize.Flow = 100;
                            }
                            else//异常处理
                            {
                                stationInitialize.InitializeDone = false; ;
                                stationInitialize.Flow = -1;
                            }
                            break;
                        case 100:  //若XY轴在原点位异常，启动Z轴寸动循环
                            var velocityCure = new VelocityCurve() { Maxvel = AxisParameter.YAxisPutPlateSpeed };
                            if (Xaxis.IsOrigin) Xaxis.MoveDelta(25000, velocityCure);
                            if (Yaxis.IsOrigin) Yaxis.MoveDelta(25000, velocityCure);
                            stationInitialize.Flow = 110;
                            break;
                        case 110:
                            if (Xaxis.IsDone && Yaxis.IsDone)
                            {
                                stationInitialize.Flow = 120;
                                Thread.Sleep(50);
                            }
                            break;
                        case 120:
                            Global.apsController.BackHome(Xaxis.NoId);
                            Global.apsController.BackHome(Yaxis.NoId);
                            stationInitialize.Flow = 130;
                            break;
                        case 130:
                            if (Global.apsController.CheckHomeDone(Xaxis.NoId, 10.0) == 0 &&
                                Global.apsController.CheckHomeDone(Yaxis.NoId, 10.0) == 0)
                            {
                                var velocityCure2 = new VelocityCurve() { Maxvel = AxisParameter.YAxisPutPlateSpeed };
                                Thread.Sleep(30);
                                Xaxis.MoveTo(Product.SafePosition.X, velocityCure2);
                                Yaxis.MoveTo(Product.SafePosition.Y, velocityCure2);
                                stationInitialize.Flow = 140;
                            }
                            else
                            {
                                stationInitialize.InitializeDone = false; 
                                stationInitialize.Flow = -1;
                            }
                            break;
                        case 140:
                            if (Xaxis.IsInPosition(Product.SafePosition.X) && Yaxis.IsInPosition(Product.SafePosition.Y))
                            {
                                stationInitialize.InitializeDone = true; 
                                stationInitialize.Flow = 150;
                            }
                            break;
                        default:
                            break;
                    }
                }
                #endregion

                //故障清除
                if (externalSign.AlarmReset) m_Alarm = PlateformAlarm.无消息;
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
                list.Add(new Alarm(() => m_Alarm == PlateformAlarm.初始化故障) { AlarmLevel = AlarmLevels.None, Name = PlateformAlarm.初始化故障.ToString() });
                list.Add(new Alarm(() => m_Alarm == PlateformAlarm.卡紧气缸或取放盘气缸没有复位)
                {
                    AlarmLevel = AlarmLevels.Error,
                    Name = PlateformAlarm.卡紧气缸或取放盘气缸没有复位.ToString()
                });
                list.Add(new Alarm(() => m_Alarm == PlateformAlarm.台面上已有承盘设置报错)
                {
                    AlarmLevel = AlarmLevels.Error,
                    Name = PlateformAlarm.台面上已有承盘设置报错.ToString()
                });
                list.Add(new Alarm(() => m_Alarm == PlateformAlarm.坐标计算失败Tray盘设置出错)
                {
                    AlarmLevel = AlarmLevels.Error,
                    Name = PlateformAlarm.坐标计算失败Tray盘设置出错.ToString()
                });
                list.Add(new Alarm(() => stationOperate.Running ? 
                (GettingPlate||PuttingPlate)? false:(Marking.HavePlateInPlateform ?
                !(IO14Points.DI8.Value & IO14Points.DI9.Value)&!Marking.HaveTraySensorSheild 
                :(IO14Points.DI8.Value | IO14Points.DI9.Value)) : false)
                {
                    AlarmLevel = AlarmLevels.Error,
                    Name = "台面有盘感应异常！"
                });
                return list;
            }
        }
    }
}
