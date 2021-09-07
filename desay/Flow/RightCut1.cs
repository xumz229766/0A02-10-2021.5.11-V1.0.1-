﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Enginee;
using System.Interfaces;
using System.Threading;
namespace desay
{
    /// <summary>
    /// 右剪切模块
    /// </summary>
    public class RightCut1 : ThreadPart
    {
        private Right1CutAlarm m_Alarm;
        public List<Alarm> Alarms;
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
        public StepAxis CutAxis { get; set; }
        /// <summary>
        /// 前后气缸
        /// </summary>
        public SingleCylinder FrontCylinder { get; set; }
        /// <summary>
        /// 上下气缸
        /// </summary>
        public SingleCylinder OverturnCylinder { get; set; }
        /// <summary>
        /// 夹爪气缸
        /// </summary>
        public SingleCylinder GripperCylinder { get; set; }
        /// <summary>
        ///烫刀次数
        /// </summary>
        private int HotCutCount;

        /// <summary>
        /// 回待机位
        /// </summary>
        public int homeWaitStep = 0;
        public override void Running(RunningModes runningMode)
        {
            try
            {
                var step = 0;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                while (true)
                {
                    Thread.Sleep(10);

                    #region 自动流程
                    if (stationOperate.Running)
                    {
                        switch (step)
                        {
                            case 0://判断是否有料
                                if (CutAxis.IsInPosition(Position.Instance.PosCut[2].Origin))
                                {
                                    step = 10;
                                }
                                else
                                {
                                    CutAxis.MoveTo(Position.Instance.PosCut[2].Origin, AxisParameter.Instance.Cut3VelocityCurve);
                                }
                                break;
                            case 10://前后气缸为ON
                                if (FrontCylinder.OutOriginStatus && OverturnCylinder.OutOriginStatus
                                    && GripperCylinder.OutOriginStatus && GripperCylinder.Condition.IsOnCondition && Marking.CAxisFinish)
                                {
                                    FrontCylinder.Set();
                                    Marking.CutSheild[2] = false;
                                    step = 20;
                                }
                                break;
                            case 20://判断蜂窝该穴位是否屏蔽
                                if (FrontCylinder.OutMoveStatus)
                                {
                                    if (0 == Config.Instance.CaxisCount[2]) { Marking.CutCount[2] = 0; }
                                    if (!Position.Instance.Caxis[2].IsSheild && !Position.Instance.C3axisSheild[Marking.CutCount[2]])
                                    {
                                        step = 30;
                                    }
                                    else
                                    {
                                        Thread.Sleep(10);
                                        FrontCylinder.Reset();
                                        step = 160;
                                    }
                                }
                                break;
                            case 30://上下气缸到位，夹子气缸为ON
                                if (GripperCylinder.Condition.IsOffCondition)
                                {
                                    Marking.CutSheild[2] = true;
                                    GripperCylinder.Set();
                                    step = 40;
                                }
                                break;
                            case 40://夹子气缸到位,判断是否扭力剪切
                                if (GripperCylinder.OutMoveStatus)
                                {
                                    if (!Position.Instance.Caxis[2].PosTorsion)
                                    {
                                        step = 60;
                                    }
                                    else
                                    {
                                        step = 50;
                                    }
                                }
                                break;
                            case 50://启动伺服3#扭力剪切控制
                                if (CutAxis.TorqueControl(Position.Instance.PosCut[2].Move, Config.Instance.PressCut[2], Position.Instance.PosCutEnd[2], 3000, AxisParameter.Instance.Cut3VelocityCurve))
                                {
                                    step = 80;
                                }
                                else //扭力止动
                                {
                                    m_Alarm = Right1CutAlarm.Z3力矩剪切未切断;
                                    FrontCylinder.Reset();
                                    step = 150;
                                }
                                break;
                            case 60://伺服3#移动到剪切，启动运行
                                if (Position.Instance.PosCutEnd[2] > Position.Instance.PosCut[2].Move)
                                {
                                    CutAxis.MoveToExtern(Position.Instance.PosCut[2].Move, Position.Instance.PosCutEnd[2], AxisParameter.Instance.Cut3VelocityCurve);
                                    step = 80;
                                }
                                else
                                {
                                    m_Alarm = Right1CutAlarm.Z3闭合位需大于缓冲位;
                                    step = 150;
                                }
                                break;
                            case 80://伺服3#到位。
                                if (CutAxis.IsInPosition(Position.Instance.PosCutEnd[2]))
                                {
                                    stopwatch.Restart();
                                    step = 90;
                                }
                                break;
                            case 90://剪切闭合延时 判断是否烫修及烫修模式
                                if (stopwatch.ElapsedMilliseconds >= Delay.Instance.CutDelay[2])
                                {
                                    if (Position.Instance.Caxis[2].HotCut)
                                    {
                                        HotCutCount = 0;
                                        step = 100;
                                    }
                                    else
                                    {
                                        FrontCylinder.Reset();
                                        step = 140;
                                    }
                                }
                                break;
                            case 100:
                                if (Position.Instance.Caxis[2].ControlOpen)
                                {
                                    FrontCylinder.Condition.NoOriginShield = true;
                                    stopwatch.Restart();
                                    IoPoints.T1DO18.Value = false;
                                }
                                else
                                {
                                    FrontCylinder.Reset();
                                }
                                step = 110;
                                break;
                            case 110:
                                if (Position.Instance.Caxis[2].ControlOpen)
                                {
                                    if (stopwatch.ElapsedMilliseconds >= Position.Instance.Caxis[2].JourneyControl && !IoPoints.T2IN5.Value)
                                    {
                                        FrontCylinder.Set();
                                        step = 130;
                                    }
                                }
                                else if (FrontCylinder.OutOriginStatus)
                                {
                                    OverturnCylinder.Set();
                                    step = 120;
                                }
                                break;
                            case 120:
                                if (OverturnCylinder.OutMoveStatus)
                                {
                                    FrontCylinder.Set();
                                    stopwatch.Restart();
                                    step = 130;
                                }
                                break;
                            case 130:
                                if (FrontCylinder.OutMoveStatus && stopwatch.ElapsedMilliseconds >= Position.Instance.Caxis[2].HotCutTime)
                                {
                                    HotCutCount++;
                                    if (HotCutCount >= Position.Instance.Caxis[2].HotCutCount)
                                    {
                                        if (Position.Instance.Caxis[2].ControlOpen)
                                        {
                                            FrontCylinder.Condition.NoOriginShield = false;
                                        }
                                        FrontCylinder.Reset();
                                        step = 140;
                                    }
                                    else
                                    {
                                        step = 100;
                                    }
                                }
                                break;
                            case 140:
                                if (Position.Instance.OverturnOpen[2])
                                {
                                    OverturnCylinder.Set();
                                }
                                step = 150;
                                break;
                            case 150:
                                CutAxis.MoveTo(Position.Instance.PosCut[2].Origin, AxisParameter.Instance.Cut3VelocityCurve);
                                step = 155;
                                break;
                            case 155:
                                if (Position.Instance.OverturnOpen[2])
                                {
                                    if (OverturnCylinder.OutMoveStatus)
                                    {
                                        step = 160;
                                    }
                                }
                                else
                                {
                                    step = 160;
                                }
                                break;
                            case 160:
                                if (CutAxis.IsInPosition(Position.Instance.PosCut[2].Origin) && FrontCylinder.OutOriginStatus)
                                {
                                    Marking.RightCut1Finish = true;
                                    step = 170;
                                }
                                break;
                            case 170://判断切料准备好，吸笔吸气标志状态，夹子气缸为OFF
                                if (Marking.XYZRightInhale1Sign && GripperCylinder.Condition.IsOffCondition)
                                {
                                    GripperCylinder.Reset();
                                    step = 180;
                                }
                                break;
                            case 180:
                                if (GripperCylinder.OutOriginStatus && GripperCylinder.Condition.IsOnCondition)
                                {
                                    Marking.XYZCut3Finish = true;
                                    step = 190;
                                }
                                break;
                            case 190://夹子气缸到位，切料准备状态复位
                                if (!Marking.XYZRightInhale1Sign)
                                {
                                    if (Position.Instance.OverturnOpen[2])
                                    {
                                        OverturnCylinder.Reset();
                                    }
                                    Marking.XYZCut3Finish = false;
                                    step = 200;
                                }
                                break;
                            case 200://判断吸笔吸气状态
                                if (!Marking.XYZRightInhale1Sign && OverturnCylinder.OutOriginStatus && Marking.ZUpTrayLensFinish[2])
                                {
                                    Marking.ZUpTrayLensFinish[2] = false;
                                    step = 210;
                                }
                                break;
                            case 210://前后气缸到位，输出完成状态
                                if (CutAxis.IsInPosition(Position.Instance.PosCut[2].Origin))
                                {
                                    Config.Instance.CutaxisCount[2]++;
                                    Config.Instance.CutaxisCountTotal[2]++;

                                    Marking.RightCut1Finish = false;
                                    Marking.CutCount[2]++;
                                    step = 220;
                                }
                                break;
                            default:
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
                                Marking.CutCount[2] = 0;
                                Marking.CAxisFinish = false;
                                Marking.RightCut1Finish = false;
                                Marking.RightCut1Done = false;
                                Marking.RightCut1HaveProduct = false;
                                FrontCylinder.InitExecute(); FrontCylinder.Reset();
                                m_Alarm = Right1CutAlarm.Z3前后气缸复位中;
                                stationInitialize.Flow = 10;
                                break;
                            case 10:
                                if (FrontCylinder.OutOriginStatus)
                                {
                                    OverturnCylinder.InitExecute(); OverturnCylinder.Reset();
                                    m_Alarm = Right1CutAlarm.Z3翻转气缸复位中;
                                    stationInitialize.Flow = 15;
                                }
                                break;
                            case 15:
                                if (OverturnCylinder.OutOriginStatus)
                                {
                                    GripperCylinder.InitExecute(); GripperCylinder.Reset();
                                    m_Alarm = Right1CutAlarm.Z3夹爪气缸复位中;
                                    stationInitialize.Flow = 20;
                                }
                                break;
                            case 20:
                                if (GripperCylinder.OutOriginStatus)
                                {
                                    m_Alarm = Right1CutAlarm.Z3剪切轴复位中;
                                    CutAxis.IsServon = true;
                                    Thread.Sleep(500);
                                    stationInitialize.Flow = 25;
                                }
                                break;
                            case 25:
                                if (CutAxis.IsDone && CutAxis.IsInPosition(CutAxis.CurrentPos))
                                {
                                    stationInitialize.Flow = 30;
                                }
                                else
                                {
                                    CutAxis.Stop();
                                }
                                break;
                            case 30:
                                CutAxis.BackHome();
                                stationInitialize.Flow = 40;
                                Thread.Sleep(200);
                                break;
                            case 40:
                                Thread.Sleep(10);
                                if (CutAxis.IsInPosition(0))
                                {
                                    CutAxis.MoveTo(Position.Instance.PosCut[2].Origin, AxisParameter.Instance.Cut3VelocityCurve);
                                    stationInitialize.Flow = 50;
                                }
                                break;
                            case 50:
                                Thread.Sleep(10);
                                if (CutAxis.IsInPosition(Position.Instance.PosCut[2].Origin))
                                {
                                    m_Alarm = Right1CutAlarm.无消息;
                                    stationInitialize.InitializeDone = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion

                    #region  回初始位
                    if (externalSign.GoRristatus)
                    {
                        switch (homeWaitStep)
                        {
                            case 0:
                                step = 0;
                                Marking.CutCount[2] = Global.BigTray.CurrentPos;
                                Marking.CAxisFinish = false;
                                Marking.RightCut1Finish = false;
                                Marking.RightCut1Done = false;
                                Marking.RightCut1HaveProduct = false;
                                CutAxis.IsServon = true;
                                Thread.Sleep(500);
                                CutAxis.MoveTo(Position.Instance.PosCut[2].Origin, AxisParameter.Instance.Cut3VelocityCurve);
                                homeWaitStep = 10;
                                break;
                            case 10:
                                if (CutAxis.IsInPosition(Position.Instance.PosCut[2].Origin))
                                {
                                    OverturnCylinder.InitExecute(); OverturnCylinder.Reset();
                                    FrontCylinder.InitExecute(); FrontCylinder.Reset();
                                    GripperCylinder.InitExecute(); GripperCylinder.Reset();
                                    Marking.equipmentHomeWaitState[6] = true;
                                    homeWaitStep = 20;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    #endregion

                    #region 故障清除
                    if (externalSign.AlarmReset && !stationInitialize.Running)
                    {
                        m_Alarm = Right1CutAlarm.无消息;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// 气缸状态集合
        /// </summary>
        public IList<ICylinderStatusJugger> CylinderStatus
        {
            get
            {
                var list = new List<ICylinderStatusJugger>();
                list.Add(FrontCylinder);
                list.Add(OverturnCylinder);
                list.Add(GripperCylinder);
                return list;
            }
        }

        public void AddAlarms()
        {
            try
            {
                Alarms = new List<Alarm>();
                Alarms.Add(new Alarm(() => m_Alarm == Right1CutAlarm.Z3力矩剪切未切断) { AlarmLevel = AlarmLevels.Error, Name = Right1CutAlarm.Z3力矩剪切未切断.ToString() });
                Alarms.Add(new Alarm(() => m_Alarm == Right1CutAlarm.Z3前后气缸复位中) { AlarmLevel = AlarmLevels.None, Name = Right1CutAlarm.Z3前后气缸复位中.ToString() });
                Alarms.Add(new Alarm(() => m_Alarm == Right1CutAlarm.Z3翻转气缸复位中) { AlarmLevel = AlarmLevels.None, Name = Right1CutAlarm.Z3翻转气缸复位中.ToString() });
                Alarms.Add(new Alarm(() => m_Alarm == Right1CutAlarm.Z3夹爪气缸复位中) { AlarmLevel = AlarmLevels.None, Name = Right1CutAlarm.Z3夹爪气缸复位中.ToString() });
                Alarms.Add(new Alarm(() => m_Alarm == Right1CutAlarm.Z3剪切轴复位中) { AlarmLevel = AlarmLevels.None, Name = Right1CutAlarm.Z3剪切轴复位中.ToString() });
                Alarms.AddRange(CutAxis.Alarms);
                Alarms.AddRange(FrontCylinder.Alarms);
                Alarms.AddRange(OverturnCylinder.Alarms);
                Alarms.AddRange(GripperCylinder.Alarms);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
