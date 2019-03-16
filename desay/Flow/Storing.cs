using System;
using System.Collections.Generic;
using System.Diagnostics;
using Motion.Enginee;
using Motion.Interfaces;
using System.Threading;
namespace desay
{
    /// <summary>
    /// 仓储模块
    /// </summary>
    public class Storing : ThreadPart
    {
        private StoreAlarm m_Alarm;
        public Storing(External ExternalSign, StationInitialize stationIni, StationOperate stationOpe)
        {
            externalSign = ExternalSign;
            stationInitialize = stationIni;
            stationOperate = stationOpe;
        }
        public StationInitialize stationInitialize { get; set; }
        public StationOperate stationOperate { get; set; }
        public External externalSign { get; set; }
        /// <summary>
        /// 仓储升降轴
        /// </summary>
        public StepAxis MAxis { get; set; }
        public override void Running(RunningModes runningMode)
        {
            var step = 0;
            //var cellNum = 0;
            var pos = new Product.StorePos();
            var autoDoorButton = false;
            var buttonPulse1 = false;
            var buttonPulse2 = false;
            var strtime1 = new Stopwatch();
            var strtime2 = new Stopwatch();
            strtime1.Start();
            strtime2.Start();
            while (true)
            {
                Thread.Sleep(10);
                if (MAxis.IsDone && (MAxis.IsInPosition(Product.CellLayerPosition[0].Position) ||
                    MAxis.IsInPosition(Product.CellLayerPosition[1].Position) ||
                    MAxis.IsInPosition(Product.CellLayerPosition[2].Position) ||
                    MAxis.IsInPosition(Product.CellLayerPosition[3].Position)))
                    Marking.MIsNoMoving = true;
                else Marking.MIsNoMoving = false;
                #region  //自动流程
                if (stationOperate.Running)
                {
                    switch (step)
                    {
                        case 0://判断各层承盘准备情况
                            if ((Product.CellLayerPosition[0].Enable && Product.CellLayerPosition[0].Status == 1)
                                || (Product.CellLayerPosition[1].Enable && Product.CellLayerPosition[1].Status == 1)
                                || (Product.CellLayerPosition[2].Enable && Product.CellLayerPosition[2].Status == 1)
                                || (Product.CellLayerPosition[3].Enable && Product.CellLayerPosition[3].Status == 1))
                            {
                                for (var i = 0; i < Marking.LayerNum-1; i++)
                                    Product.CellLayerPosition[i].Status = 3;
                                step = 10;
                            }
                            else Marking.PlateLittle = true;
                            break;
                        case 10://判断Y轴是否移动，仓储完成信号是否清除。
                            if (!Marking.YMoveToNoInSafePostioin && 
                                (!Marking.StoreFinish || stationOperate.SingleRunning) && IO15Points.DI12.Value)
                            {
                                pos = Product.CellLayerPosition[Marking.LayerNum-1];
                                Thread.Sleep(20);
                                if (pos.Enable && pos.Status == 1)
                                {
                                    MAxis.MoveTo(Product.CellLayerPosition[Marking.LayerNum-1].Position, AxisParameter.MvelocityCure);
                                    step = 20;
                                }
                                else step = 30;
                            }
                            break;
                        case 20:
                            if (MAxis.IsInPosition(Product.CellLayerPosition[Marking.LayerNum-1].Position))
                            {
                                Marking.StoreFinish = true;
                                Product.CellLayerPosition[Marking.LayerNum-1].Status = 2;
                                step = 30;
                            }
                            break;
                        case 30:
                            if (!Marking.StoreFinish||stationOperate.SingleRunning)
                            {
                                Product.CellLayerPosition[Marking.LayerNum-1].Status = 3;
                                step = 40;
                            }
                            break;
                        case 40:
                            Marking.LayerNum += 1;
                            if (Marking.LayerNum >= 4) Marking.PlateLittle = true;
                            step = 50;
                            break;
                        case 50:
                            if (Marking.LayerNum < 5) step = 10;
                            else step = 60;
                            break;
                        default:
                            stationOperate.RunningSign = false;
                            Marking.LayerNum = 1;
                            Marking.StoreFinish = false;
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
                            Marking.LayerNum = 1;
                            Product.CellLayerPosition[0].Status = 0;
                            Product.CellLayerPosition[1].Status = 0;
                            Product.CellLayerPosition[2].Status = 0;
                            Product.CellLayerPosition[3].Status = 0;
                            Marking.StoreFinish = false;
                            MAxis.Stop();
                            Thread.Sleep(20);
                            stationInitialize.Flow = 10;
                            break;
                        case 10:  //若M轴在原点位异常，启动Z轴寸动循环
                            if (MAxis.IsOrigin)
                            {
                                MAxis.MoveDelta(1000, AxisParameter.MvelocityCure);
                                stationInitialize.Flow = 20;
                            }
                            else
                                stationInitialize.Flow = 30;
                            break;
                        case 20://判断M轴是否动作完成
                            if (MAxis.IsDone)
                            {
                                stationInitialize.Flow = 30;
                                Thread.Sleep(20);
                            }
                            break;
                        case 30://启动M轴回原点
                            Global.apsController.BackHome(MAxis.NoId);
                            stationInitialize.Flow = 40;
                            break;
                        case 40:
                            var result = Global.apsController.CheckHomeDone(MAxis.NoId, 20.0);
                            if (result == 0)
                            {
                                stationInitialize.InitializeDone = true;
                                stationInitialize.Flow = 50;
                            }
                            if (result < 0)
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
                if (externalSign.AlarmReset) m_Alarm = StoreAlarm.无消息;
                if (IO10Points.DI3.Value) m_Alarm = StoreAlarm.设备气压低故障;
                #region 自动门控制程序

                if (Product.AutoDoorSheild)
                {
                    if (autoDoorButton)
                    {
                        if (!buttonPulse1&&IO15Points.DI13.Value)
                        {
                            autoDoorButton = false;
                            buttonPulse1 = true;
                        }
                    }
                    else
                    {
                        if (!buttonPulse1&&IO15Points.DI13.Value)
                        {
                            autoDoorButton = true;
                            buttonPulse1 = true;
                        }
                    }
                    
                    if (!IO15Points.DI12.Value||(!IO14Points.DI14.Value && !autoDoorButton))
                    {
                        autoDoorButton = false;
                        IO12Points.DO3.Value = true;
                        IO12Points.DO4.Value = false;
                    }
                    if (!IO14Points.DI15.Value && autoDoorButton)
                    {
                        IO12Points.DO4.Value = true;
                        IO12Points.DO3.Value = false;
                    }
                }
                else
                {
                    if (!IO15Points.DI12.Value)
                    {
                        strtime1.Restart();
                        autoDoorButton = false;
                        IO12Points.DO3.Value = false;
                        IO12Points.DO4.Value = false;
                    }
                    else
                    {
                        if (!buttonPulse1&&IO15Points.DI13.Value)
                        {
                            autoDoorButton = true;
                            strtime1.Restart();
                            buttonPulse1 = true;
                        }
                        if (!IO14Points.DI15.Value && !IO12Points.DO4.Value && !autoDoorButton)
                        {
                            //检查是否超时
                            strtime1.Stop();
                            if (strtime1.ElapsedMilliseconds / 1000.0 > Product.AutoDoorCloseDelay)
                            {
                                IO12Points.DO3.Value = false;
                                IO12Points.DO4.Value = true;
                            }
                            strtime1.Start();
                        }
                        if (IO14Points.DI15.Value && !autoDoorButton)
                        {
                            strtime1.Restart();
                        }
                        if (autoDoorButton)
                        {
                            if (!IO14Points.DI14.Value)
                            {
                                IO12Points.DO3.Value = true;
                                IO12Points.DO4.Value = false;
                            }
                            else
                            {
                                autoDoorButton = false;
                            }
                        }
                    }
                }
                if (!IO15Points.DI13.Value) buttonPulse1 = false;
                if(Marking.PlateLittle&&IO15Points.DI13.Value)
                {
                    if(!buttonPulse2) strtime2.Restart();
                    buttonPulse2 = true;
                    //检查是否超时
                    strtime2.Stop();
                    if (strtime2.ElapsedMilliseconds / 1000.0 > 5.0)
                    {
                        Product.CellLayerPosition[0].Status = 1;
                        Product.CellLayerPosition[1].Status = 1;
                        Product.CellLayerPosition[2].Status = 1;
                        Product.CellLayerPosition[3].Status = 1;
                        Marking.PlateLittle = false;
                    }
                    strtime2.Start();
                }
                #endregion
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
                list.Add(new Alarm(() => m_Alarm == StoreAlarm.初始化故障) { AlarmLevel = AlarmLevels.None, Name = StoreAlarm.初始化故障.ToString() });
                list.Add(new Alarm(() => m_Alarm == StoreAlarm.设备气压低故障) { AlarmLevel = AlarmLevels.Error, Name = StoreAlarm.设备气压低故障.ToString() });
                return list;
            }
        }
    }
}
