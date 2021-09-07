using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Interfaces;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace System.AdvantechAps
{
    /// <summary>
    ///     雷赛总线运动控制卡控制器。修改于2019.6.17 Finley Jiang
    /// </summary>
    public class ApsController : Automatic, ISwitchController, IMotionController, INeedInitialization, IDisposable
    {
        private readonly List<uint> m_Axises;
        private readonly List<ushort> m_Devices;
        private bool _disposed;
        private bool _isInitialized;
        short deviceCount = 0;
        public bool IsLoadXmlFile { get; private set; }

        public ApsController()
        {
            //_cardNos = cardNos;
            m_Axises = new List<uint>();
            m_Devices = new List<ushort>();
        }

        #region Implementation of INeedInitialization

        public void Initialize()
        {
            if (!_isInitialized)
            {
                _isInitialized = InitializeCard();
            }
        }

        //加载配置文件
        public bool LoadParamFromFile(string CardEniName, string CardIniName, string AxisIniName)
        {
            if (!_isInitialized) return false;

            string strTemp;
            if(0 != NetworkError())
            {
                for (ushort cardno = 0; cardno < deviceCount; cardno++)
                {
                    FileStream fa = new FileStream(CardEniName, FileMode.Open);
                    StreamReader sa = new StreamReader(fa);
                    string sta = sa.ReadToEnd();
                    sa.Close();
                    fa.Close();
                    byte[] buffer = Encoding.UTF8.GetBytes(sta);
                    byte[] fileincontrol = Encoding.UTF8.GetBytes("");
                    ushort filetype = 201;
                    short cardeniret = LTDMC.dmc_download_memfile(cardno, buffer, (uint)buffer.Length, fileincontrol, filetype);

                    FileStream fs = new FileStream(CardIniName, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    string str = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();
                    buffer = Encoding.UTF8.GetBytes(str);                   
                    filetype = 201;
                    LTDMC.nmc_set_cycletime(cardno, 2, 2000);      //设置总线周期
                    short cardiniret = LTDMC.dmc_download_memfile(cardno, buffer, (uint)buffer.Length, fileincontrol, filetype);
                    if (cardeniret != 0 || cardiniret != 0)
                    {
                        strTemp = "运动控制卡总线配置错误: [0x" + Convert.ToString(cardeniret, 16) + "]";
                        ShowMessages(strTemp, (uint)cardiniret);
                        return false;
                    }

                    LTDMC.dmc_soft_reset(cardno);
                    LTDMC.dmc_board_close();
                    for (int i = 0; i < 15; i++)//总线卡软件复位耗时15s左右
                    {
                        Application.DoEvents();
                        Thread.Sleep(1000);
                    }
                    LTDMC.dmc_board_init();
                }
            }

            ushort _num = 0;
            ushort[] cardids = new ushort[8];
            uint[] cardtypes = new uint[8];
            short ret = LTDMC.dmc_get_CardInfList(ref _num, cardtypes, cardids);
            if (ret != 0)
            {
                strTemp = "打开文件失败: [0x" + Convert.ToString(ret, 16) + "]";
                ShowMessages(strTemp, (uint)deviceCount);
            }
            m_Axises.Clear();
            m_Devices.Clear();
            for (ushort i = 0; i < deviceCount; i++)
            {
                m_Devices.Add(i);
                uint AxisTotalNumer = 0;
                var Axis = LTDMC.nmc_get_total_axes(i, ref AxisTotalNumer);

                if (0 < AxisTotalNumer)
                {
                    for (uint j = 0; j < AxisTotalNumer; j++)
                    {
                        m_Axises.Add(j);
                        LTDMC.nmc_set_offset_pos(m_Devices[i], (ushort)j, 0);      //设置编码器映射
                        LTDMC.dmc_set_equiv(m_Devices[i], (ushort)j, 1);
                    }
                }
                else
                {
                    strTemp = "未找到轴: [0x" + Convert.ToString(AxisTotalNumer, 16) + "]";
                    ShowMessages(strTemp, (uint)deviceCount);
                }
            }
            //short axisiniret = LTDMC.dmc_download_configfile(m_Devices[0], AxisIniName);
            //if (axisiniret != 0)
            //{
            //    strTemp = "运动控制卡轴配置错误: [0x" + Convert.ToString(axisiniret, 16) + "]";
            //    ShowMessages(strTemp, (uint)axisiniret);
            //    return false;
            //}

            return true;
        }

        //设置设备参数
        public void SetEquipmentParam(double[] SoftNlimit, double[] SoftPlimit)
        {
            if (!_isInitialized) return;

            SetSoftLimit(0, (int)(SoftNlimit[0] / 0.001), (int)(SoftPlimit[0] / 0.001));//Y轴
            SetSoftLimit(1, (int)(SoftNlimit[1] / 0.001), (int)(SoftPlimit[1] / 0.001));//X轴
            SetSoftLimit(2, (int)(SoftNlimit[2] / 0.001), (int)(SoftPlimit[2] / 0.001));//Z轴
            SetSoftLimit(3, (int)(SoftNlimit[3] / 0.01), (int)(SoftPlimit[3] / 0.01));//C1轴
            SetSoftLimit(4, (int)(SoftNlimit[4] / 0.01), (int)(SoftPlimit[4] / 0.01));//C2轴
            SetSoftLimit(5, (int)(SoftNlimit[5] / 0.01), (int)(SoftPlimit[5] / 0.01));//C3轴
            SetSoftLimit(6, (int)(SoftNlimit[6] / 0.01), (int)(SoftPlimit[6] / 0.01));//C4轴
            SetSoftLimit(7, (int)(SoftNlimit[7] / 0.001), (int)(SoftPlimit[7] / 0.001));//P1轴
            SetSoftLimit(8, (int)(SoftNlimit[8] / 0.001), (int)(SoftPlimit[8] / 0.001));//P2轴
            SetSoftLimit(9, (int)(SoftNlimit[9] / 0.001), (int)(SoftPlimit[9] / 0.001));//P3轴
            SetSoftLimit(10, (int)(SoftNlimit[10] / 0.001), (int)(SoftPlimit[10] / 0.001));//P4轴
            SetSoftLimit(11, (int)(SoftNlimit[11] / 0.001), (int)(SoftPlimit[11] / 0.001));//剪切1#轴
            SetSoftLimit(12, (int)(SoftNlimit[12] / 0.001), (int)(SoftPlimit[12] / 0.001));//剪切2#轴
            SetSoftLimit(13, (int)(SoftNlimit[13] / 0.001), (int)(SoftPlimit[13] / 0.001));//剪切3#轴
            SetSoftLimit(14, (int)(SoftNlimit[14] / 0.001), (int)(SoftPlimit[14] / 0.001));//剪切4#轴
            SetSoftLimit(15, (int)(SoftNlimit[15] / 0.0001), (int)(SoftPlimit[15] / 0.0001));//M轴
        }

        //初始化板卡
        private bool InitializeCard()
        {
            string strTemp;
            deviceCount = LTDMC.dmc_board_init();
            if (deviceCount <= 0)
            {
                strTemp = "初始化控制失败: [0x" + Convert.ToString(deviceCount, 16) + "]";
                ShowMessages(strTemp, (uint)deviceCount);
                return false;
            }
            for (ushort i = 0; i < deviceCount; i++)
            {
                m_Devices.Add(i);
            }
            return true;
        }

        public void Dispose()
        {
            if (!_isInitialized) return;

            m_Devices.Clear();
            m_Axises.Clear();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        /// <summary>
        /// 设置比较事件
        /// </summary>
        /// <param name="axisNo">轴号</param>
        /// <param name="AxCmpSrc">比较源，0:理论位置，1:实际位置</param>
        /// <param name="AxCmpMethod">比较方法，0:>=,1:小于=,2:=</param>
        /// <param name="AxCmpPulseLogic">高低电平，0:低,1:高</param>
        /// <param name="AxCmpEnable">禁用启用比较功能，0:禁用，1:启用</param>
        public void SetCompareEvent(int axisNo, uint AxCmpSrc, uint AxCmpMethod, uint AxCmpPulseLogic, uint AxCmpEnable)
        {
            if (!_isInitialized) return;

            //UInt32 Result;
            //String strTemp;
            //UInt32[] AxEnableEvtArray = new UInt32[8];
            //UInt32[] GpEnableEvt = new UInt32[8];
            //AxEnableEvtArray[axisNo] |= (UInt32)EventType.EVT_AX_COMPARED;
            ////Enable motion event
            //Result = Motion.mAcm_EnableMotionEvent(m_Devices[0], AxEnableEvtArray, GpEnableEvt, 8, 3);
            //if (Result != (uint)ErrorCode.SUCCESS)
            //{
            //    strTemp = "EnableMotionEvent Filed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
            //    ShowMessages(strTemp, Result);
            //    return;
            //}
            //Result = Motion.mAcm_SetU32Property(m_Axises[axisNo], (uint)PropertyID.CFG_AxCmpSrc, AxCmpSrc);
            //if (Result != (uint)ErrorCode.SUCCESS)
            //{
            //    strTemp = "Set Property-CFG_AxCmpSrc Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
            //    ShowMessages(strTemp, Result);
            //    return;
            //}
            //Result = Motion.mAcm_SetU32Property(m_Axises[axisNo], (uint)PropertyID.CFG_AxCmpMethod, AxCmpMethod);
            //if (Result != (uint)ErrorCode.SUCCESS)
            //{
            //    strTemp = "Set Property-AxCmpMethod Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
            //    ShowMessages(strTemp, Result);
            //    return;
            //}
            //Result = Motion.mAcm_SetU32Property(m_Axises[axisNo], (uint)PropertyID.CFG_AxCmpPulseLogic, AxCmpPulseLogic);
            //if (Result != (uint)ErrorCode.SUCCESS)
            //{
            //    strTemp = "Set Property-AxCmpMethod Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
            //    ShowMessages(strTemp, Result);
            //    return;
            //}
            //Result = Motion.mAcm_SetU32Property(m_Axises[axisNo], (uint)PropertyID.CFG_AxCmpPulseWidth, 4);
            //if (Result != (uint)ErrorCode.SUCCESS)
            //{
            //    strTemp = "Set Property-AxCmpMethod Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
            //    ShowMessages(strTemp, Result);
            //    return;
            //}
            //Result = Motion.mAcm_SetU32Property(m_Axises[axisNo], (uint)PropertyID.CFG_AxCmpEnable, AxCmpEnable);
            //if (Result != (uint)ErrorCode.SUCCESS)
            //{
            //    strTemp = "Set Property-AxCmpEnable Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
            //    ShowMessages(strTemp, Result);
            //    return;
            //}
        }

        public void SetComparePosition(int axisNo, List<double> CmpData)
        {
            if (!_isInitialized) return;

            UInt32 Result;
            int ArrayCount = 0;
            string strTemp;
            var i = 0;
            ArrayCount = CmpData.Count;
            double[] TableArray = new double[ArrayCount];
            foreach (var list in CmpData)
            {
                TableArray[i] = list;
                i++;
            }
            SetCompareEvent(axisNo, 1, 1, 1, 1);
            //Set compare data list for the specified axis
            //Result = Motion.mAcm_AxSetCmpTable(m_Axises[axisNo], TableArray, ArrayCount);
            //if (Result != (uint)ErrorCode.SUCCESS)
            //{
            //    strTemp = "Set Compare Table Failed With Error Code[0x" + Convert.ToString(Result, 16) + "]";
            //    ShowMessages(strTemp, Result);
            //}
        }

        #region 获取当前轴的 IO 信号

        /// <summary>
        ///     是否报警
        /// </summary>
        /// <returns></returns>
        public bool IsAlm(int axisNo)
        {
            if (!_isInitialized) return false;

            return (((int)AxisStatus(axisNo) >> (int)0) & 1) == 1;
        }
        /// <summary>
        ///     出现错误停止
        /// </summary>
        /// <returns></returns>
        public bool IsErr(int axisNo)
        {
            if (!_isInitialized) return false;

            ushort status = 0;
            LTDMC.nmc_get_axis_state_machine(m_Devices[0], (ushort)m_Axises[axisNo], ref status);
            return (status == 6 || status == 7) ? true : false;
        }

        /// <summary>
        /// 错误复位
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public bool ResetErr(int axisNo)
        {
            if (!_isInitialized) return false;

            short Result = LTDMC.nmc_clear_axis_errcode(m_Devices[0], (ushort)m_Axises[axisNo]);
            return Result == 0 ? true : false;

        }
        /// <summary>
        ///     是否到达正限位
        /// </summary>
        /// <returns></returns>
        public bool IsPel(int axisNo)
        {
            if (!_isInitialized) return false;

            if (11 == axisNo || 12 == axisNo || 13 == axisNo || 14 == axisNo || 15 == axisNo)
            {
                return (((int)AxisStatus(axisNo) >> (int)1) & 1) == 1;
            }
            else
            {
                return (((int)AxisStatus(axisNo) >> (int)6) & 1) == 1;
            }
        }
        /// <summary>
        ///     是否到达负限位
        /// </summary>
        /// <returns></returns>
        public bool IsMel(int axisNo)
        {
            if (!_isInitialized) return false;

            if (11 == axisNo || 12 == axisNo || 13 == axisNo || 14 == axisNo || 15 == axisNo)
            {
                return (((int)AxisStatus(axisNo) >> (int)2) & 1) == 1;
            }
            {
                return (((int)AxisStatus(axisNo) >> (int)7) & 1) == 1;
            }
        }

        /// <summary>
        ///     是否在轴原点
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public bool IsOrg(int axisNo)
        {
            if (!_isInitialized) return false;

            if (11 == axisNo || 12 == axisNo || 13 == axisNo || 14 == axisNo || 15 == axisNo)
            {
                return (((int)AxisStatus(axisNo) >> (int)4) & 1) == 1;
            }
            else
            {
                double dunitPos = 0;
                LTDMC.dmc_get_position_unit(m_Devices[0], (ushort)m_Axises[axisNo], ref dunitPos); //读取指定轴指令位置值
                if (0 == dunitPos)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        ///     是否急停
        /// </summary>
        /// <returns></returns>
        public bool IsEmg(int axisNo)
        {
            if (!_isInitialized) return false;

            return (((int)AxisStatus(axisNo) >> (int)3) & 1) == 1;
        }
        /// <summary>
        /// 是否在轴Z相
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public bool IsSZ(int axisNo)
        {
            if (!_isInitialized) return false;

            return (((int)AxisStatus(axisNo) >> (int)9) & 1) == 1;
        }
        /// <summary>
        /// 是否在轴Z相
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public bool IsINP(int axisNo)
        {
            if (!_isInitialized) return false;

            return (((int)AxisStatus(axisNo) >> (int)8) & 1) == 1;
        }
        /// <summary>
        ///     获取电机励磁状态。
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public bool GetServo(int axisNo)
        {
            if (!_isInitialized) return false;

            if (11 == axisNo || 12 == axisNo || 13 == axisNo || 14 == axisNo || 15 == axisNo)
            {
                var ret = LTDMC.dmc_get_sevon_enable(m_Devices[0], (ushort)m_Axises[axisNo]);
                return ret == 1 ? true : false;
            }
            else
            {
                ushort AxisServo = 0;
                var ret = LTDMC.nmc_get_axis_state_machine(m_Devices[0], (ushort)m_Axises[axisNo], ref AxisServo);
                return AxisServo == 4 ? true : false;
            }
        }
        #endregion
        /// <summary>
        ///     获取轴当前位置
        /// </summary>
        /// <param name="axisNo">轴标识</param>
        /// <returns>当前位置</returns>
        public int GetCurrentCommandPosition(int axisNo)
        {
            if (!_isInitialized) return 1;

            double pos = 0;
            var ret = LTDMC.dmc_get_position_unit(m_Devices[0], (ushort)m_Axises[axisNo], ref pos);
            return (int)pos;
        }
        /// <summary>
        /// 获取编码器计数
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public int GetCurrentFeedbackPosition(int axisNo)
        {
            if (!_isInitialized) return 1;

            double pos = 0;
            var ret = LTDMC.dmc_get_encoder_unit(m_Devices[0], (ushort)m_Axises[axisNo], ref pos);
            return (int)pos;
        }
        /// <summary>
        /// 获取当前速度
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public int GetCurrentCommandSpeed(int axisNo)
        {
            if (!_isInitialized) return 1;

            double speed = 0;
            var ret = LTDMC.dmc_read_current_speed_unit(m_Devices[0], (ushort)m_Axises[axisNo], ref speed);
            return (int)speed;
        }
        public int GetCurrentFeedbackSpeed(int axisNo)
        {
            if (!_isInitialized) return 1;

            //var speed = 0.0;
            //var ret = Motion.mAcm_AxGetActVelocity(m_Axises[axisNo], ref speed);
            //return ret == (uint)ErrorCode.SUCCESS ? (int)speed : 0;
            return 0;
        }
        /// <summary>
        ///     设置指令位置计数器计数值
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="position"></param>
        public void SetCommandPosition(int axisNo, double position)
        {
            if (!_isInitialized) return;

            int ret = LTDMC.dmc_set_position_unit(m_Devices[0], (ushort)m_Axises[axisNo], position * 1.0);
        }
        /// <summary>
        ///     设置指令位置计数器计数值
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="position"></param>
        public void SetFeedbackPosition(int axisNo, double position)
        {
            if (!_isInitialized) return;

            //var ret = Motion.mAcm_AxSetActualPosition(m_Axises[axisNo], position);
        }

        //网络中断 返回0正常
        public ushort NetworkError()
        {
            if (!_isInitialized) return 1;

            ushort errcode = 0;
            LTDMC.nmc_get_errcode(m_Devices[0], 2, ref errcode);
            return errcode;
        }

        //网络中断 返回节点
        public string NetworkErrorNode()
        {
            if (!_isInitialized) return null;

            ushort ErrorAxis = 0;
            ushort ErrorType = 0;
            ushort SlaveAddr = 0;
            uint ErrorFieldbusCode = 0;
            LTDMC.nmc_get_current_fieldbus_state_info(m_Devices[0], 2, ref ErrorAxis, ref ErrorType, ref SlaveAddr, ref ErrorFieldbusCode);
            return " 错误类型:" + ErrorType.ToString() + " 错误节点:" + SlaveAddr.ToString();
        }

        //冷复位
        public void SoftReset()
        {
            if (!_isInitialized) return;

            ushort errcode = 0;
            LTDMC.nmc_get_errcode(m_Devices[0], 2, ref errcode);
            if (0 != errcode)
            {
                LTDMC.dmc_soft_reset(m_Devices[0]);
                for (int i = 0; i < 15; i++)//总线卡软件复位耗时15s左右
                {
                    Application.DoEvents();
                    Thread.Sleep(1000);
                }
                for (ushort i = 0; i < deviceCount; i++)
                {
                    uint AxisTotalNumer = 0;
                    LTDMC.nmc_get_total_axes(i, ref AxisTotalNumer);
                    if (0 < AxisTotalNumer)
                    {
                        for (uint j = 0; j < AxisTotalNumer; j++)
                        {
                            LTDMC.nmc_set_offset_pos(m_Devices[i], (ushort)j, 0);      //设置编码器映射
                            LTDMC.dmc_set_equiv(m_Devices[i], (ushort)j, 1);
                        }
                    }
                }
            }
        }

        //热复位
        public void CoolReset()
        {
            if (!_isInitialized) return;

            ushort errcode = 0;
            LTDMC.nmc_get_errcode(m_Devices[0], 2, ref errcode);
            if (0 != errcode)
            {
                LTDMC.dmc_cool_reset(m_Devices[0]);
                for (int i = 0; i < 15; i++)//总线卡软件复位耗时15s左右
                {
                    Application.DoEvents();
                    Thread.Sleep(1000);
                }
                for (ushort i = 0; i < deviceCount; i++)
                {
                    uint AxisTotalNumer = 0;
                    LTDMC.nmc_get_total_axes(i, ref AxisTotalNumer);
                    if (0 < AxisTotalNumer)
                    {
                        for (uint j = 0; j < AxisTotalNumer; j++)
                        {
                            LTDMC.nmc_set_offset_pos(m_Devices[i], (ushort)j, 0);      //设置编码器映射
                            LTDMC.dmc_set_equiv(m_Devices[i], (ushort)j, 1);
                        }
                    }
                }
            }
        }

        //清除总线报警
        public void ClearError()
        {
            if (!_isInitialized) return;

            ushort errcode = 0;
            LTDMC.nmc_get_errcode(m_Devices[0], 2, ref errcode);
            if (0 != errcode)
            {
                LTDMC.nmc_clear_errcode(m_Devices[0], 2);
            }
        }

        //清除轴报警
        public void ClearAxisError(int axisNo)
        {
            if (!_isInitialized) return;

            ushort Errcode = 0;
            LTDMC.nmc_get_axis_errcode(m_Devices[0], (ushort)m_Axises[axisNo], ref Errcode);
            if (0 != Errcode)
            {
                LTDMC.nmc_clear_axis_errcode(m_Devices[0], (ushort)m_Axises[axisNo]);
            }
        }

        /// <summary>
        /// 返回轴的运动信号的状态
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public double AxisStatus(int axisNo)
        {
            if (!_isInitialized) return 1;

            double ret = 0;
            ret = LTDMC.dmc_axis_io_status(m_Devices[0], (ushort)m_Axises[axisNo]);
            return ret;
        }
        /// <summary>
        ///     轴上电
        /// </summary>
        /// <param name="noId"></param>
        public void ServoOn(int axisNo)
        {
            if (!_isInitialized) return;

            if (11 == axisNo)
            {
                short ret = LTDMC.dmc_set_sevon_enable(m_Devices[0], (ushort)m_Axises[axisNo], 1);
            }
            else
            {
                short ret = LTDMC.nmc_set_axis_enable(m_Devices[0], (ushort)m_Axises[axisNo]);
            }
        }
        /// <summary>
        ///     轴掉电
        /// </summary>
        /// <param name="noId"></param>
        public void ServoOff(int axisNo)
        {
            if (!_isInitialized) return;

            if (11 == axisNo || 12 == axisNo || 13 == axisNo || 14 == axisNo || 15 == axisNo)
            {
                short ret = LTDMC.dmc_set_sevon_enable(m_Devices[0], (ushort)m_Axises[axisNo], 0);
            }
            else
            {
                short ret = LTDMC.nmc_set_axis_disable(m_Devices[0], (ushort)m_Axises[axisNo]);
            }
        }

        public void ServoOn()
        {
            if (!_isInitialized) return;

            m_Axises.ForEach(axisNo =>
            {
                var result = LTDMC.nmc_set_axis_enable(m_Devices[0], (ushort)m_Axises[(ushort)axisNo]);
                var innerMsg = (result).ToString();
                if (innerMsg != "No Error")
                    MessageBox.Show(string.Format("伺服打开功能错误:{0}", innerMsg));
            });
        }

        public void ServoOff()
        {
            if (!_isInitialized) return;

            m_Axises.ForEach(axisNo =>
            {
                var result = LTDMC.nmc_set_axis_disable(m_Devices[0], (ushort)m_Axises[(ushort)axisNo]);
                var innerMsg = (result).ToString();
                if (innerMsg != "No Error")
                    MessageBox.Show(string.Format("伺服关闭功能错误:{0}", innerMsg));
            });
        }

        #region Error Code

        #endregion

        /// <summary>
        ///     单轴相对运动
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="pulseNum"></param>
        /// <param name="velocityCurveParams"></param>
        /// <returns></returns>
        public void MoveRelPulse(int axisNo, double position, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            //设置速度
            SetAxisVelocity(axisNo, velocityCurveParams);
            LTDMC.dmc_pmove_unit(m_Devices[0], (ushort)m_Axises[axisNo], position, 0);
        }

        /// <summary>
        ///     单轴绝对运动
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="position"></param>
        /// <param name="velocityCurveParams"></param>
        public void MoveAbsPulse(int axisNo, double position, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            //设置速度
            SetAxisVelocity(axisNo, velocityCurveParams);
            short ret = LTDMC.dmc_pmove_unit(m_Devices[0], (ushort)m_Axises[axisNo], (int)position, 1);
        }

        /// <summary>
        ///  设置轴速度
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="velocityCurveParams"></param>
        public void SetAxisVelocity(int axisNo, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            LTDMC.dmc_set_profile_unit(m_Devices[0], (ushort)m_Axises[axisNo], velocityCurveParams.Strvel * 1.0,
                velocityCurveParams.Maxvel * 1.0, velocityCurveParams.Tacc * 1.0, velocityCurveParams.Tdec * 1.0, 100);//设置速度参数

            LTDMC.dmc_set_s_profile(m_Devices[0], (ushort)m_Axises[axisNo], 0, velocityCurveParams.dS_para * 1.0);//设置S段速度参数

            //LTDMC.dmc_set_dec_stop_time(m_Devices[0], (ushort)m_Axises[axisNo], velocityCurveParams.dTdec * 1.0); //设置减速停止时间
        }

        /// <summary>
        ///     单轴绝对运动软着陆
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="position"></param>
        /// <param name="velocityCurveParams"></param>
        public void MoveAbsPulseExtern(int axisNo, double position1, double position2, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            short ret = LTDMC.dmc_t_pmove_extern(m_Devices[0], (ushort)m_Axises[axisNo], position1, position2, velocityCurveParams.Strvel * 1.0,
                velocityCurveParams.Maxvel * 1.0, velocityCurveParams.Stopvel * 1.0, velocityCurveParams.Tacc * 1.0, velocityCurveParams.Tdec * 1.0, 1);
        }

        /// <summary>
        ///  运行中改变轴速度
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="velocityCurveParams"></param>
        public void AlterAxisVelocity(int axisNo, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            LTDMC.dmc_change_speed_unit(m_Devices[0], (ushort)m_Axises[axisNo], velocityCurveParams.Maxvel * 1.0, velocityCurveParams.Tacc * 1.0);
        }

        public uint SetCmpTable(int axisNo, double[] TableArray, int ArrayCount)
        {
            if (!_isInitialized) return 1;

            //return Motion.mAcm_AxSetCmpTable(m_Axises[axisNo], TableArray, ArrayCount);
            return 0;
        }
        /// <summary>
        ///     连续运动
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="moveDirection"></param>
        /// <param name="velocityCurveParams"></param>
        /// <returns></returns>
        public void ContinuousMove(int axisNo, MoveDirection moveDirection, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            //设置速度
            SetAxisVelocity(axisNo, velocityCurveParams);
            ushort dir = 1;
            if (moveDirection == MoveDirection.Postive) { dir = 1; } else { dir = 0; }
            LTDMC.dmc_vmove(m_Devices[0], (ushort)m_Axises[axisNo], dir);
        }
        /// <summary>
        ///     立即停止
        /// </summary>
        /// <param name="axisNo"></param>
        public uint ImmediateStop(int axisNo)
        {
            if (!_isInitialized) return 1;

            short ret = LTDMC.dmc_stop(m_Devices[0], (ushort)m_Axises[axisNo], 1);
            return (uint)ret;
        }

        /// <summary>
        ///     减速停止指定机构轴脉冲输出
        /// </summary>
        /// <param name="axisNo"></param>
        public uint DecelStop(int axisNo)
        {
            if (!_isInitialized) return 1;

            short ret = LTDMC.dmc_stop(m_Devices[0], (ushort)m_Axises[axisNo], 0);
            return (uint)ret;
        }

        /// <summary>
        ///     是否停止移动
        /// </summary>
        /// <returns></returns>
        public bool IsDown(int axisNo, bool hasExtEncode = false)
        {
            if (!_isInitialized) return false;

            //if (LTDMC.dmc_check_done(m_Devices[0], (ushort)m_Axises[axisNo]) == 1)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            ushort status = 0, errcode = 0;
            var ret = LTDMC.dmc_get_axis_run_mode(m_Devices[0], (ushort)m_Axises[axisNo], ref status);
            var ret1 = IsAlm((ushort)m_Axises[axisNo]);
            var ret2 = LTDMC.nmc_get_axis_errcode(m_Devices[0], (ushort)m_Axises[axisNo], ref errcode);
            if (status != 0 || ret1 || errcode != 0) return false;
            else return true;
        }

        /// <summary>
        ///     检测指定轴的运动状态
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="hasExtEncode">是否有编码器接入(步进电机无外部编码器)</param>
        /// <remarks>判断INP鑫海</remarks>
        public int CheckDone(int axisNo, double timeoutLimit, bool hasExtEncode = false)
        {
            if (!_isInitialized) return 1;

            ushort status = 0;
            var strtime = new Stopwatch();
            strtime.Start();

            do
            {
                //判断是否正常停止
                if (LTDMC.dmc_check_done(m_Devices[0], (ushort)m_Axises[axisNo]) == 1)
                {
                    return 0;
                }

                if (hasExtEncode)
                {
                    ushort axisatatemachine = 0;
                    LTDMC.nmc_get_axis_state_machine(m_Devices[0], (ushort)m_Axises[axisNo], ref axisatatemachine);
                    if (axisatatemachine == 6 || axisatatemachine == 7)
                    {
                        return -2;
                    }
                }
                //检查是否超时
                strtime.Stop();
                if (strtime.ElapsedMilliseconds / 1000.0 > timeoutLimit)
                {
                    LTDMC.dmc_stop(m_Devices[0], (ushort)m_Axises[axisNo], 1);
                    return -3;
                }
                strtime.Start();
                //延时
                Thread.Sleep(20);
            } while (true);
        }

        /// <summary>
        /// 两轴做插补相对移动
        /// </summary>
        /// <param name="axisNo">轴ID</param>
        /// <param name="position1">坐标1</param>
        /// <param name="position2">坐标2</param>
        /// <param name="velocityCurveParams">速度参数</param>
        public void MoveLine2Relative(int axisNo, double position1, double position2, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            var pos = new double[2];
            uint pArrayElements = 2;
            pos[0] = position1;
            pos[1] = position2;
            //设置速度
            SetAxisVelocity(axisNo, velocityCurveParams);
            //启动运动
            LTDMC.dmc_set_vector_profile_unit(m_Devices[0], (ushort)m_Axises[axisNo], velocityCurveParams.Strvel * 1.0, velocityCurveParams.Maxvel * 1.0, velocityCurveParams.Tacc * 1.0, velocityCurveParams.Tdec * 1.0, 1);
            LTDMC.dmc_line_unit(m_Devices[0], 1, 2, new ushort[] { (ushort)axisNo, (ushort)(axisNo + 1) }, new double[] { position1, position2 }, 0); //执行两轴直线插补运动
        }
        /// <summary>
        ///     两轴直线插补绝对移动
        /// </summary>
        /// <param name="axisNo">轴ID</param>
        /// <param name="position1">坐标1</param>
        /// <param name="position2">坐标2</param>
        /// <param name="velocityCurveParams">速度参数</param>
        public void MoveLine2Absolute(int axisNo, double position1, double position2, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            var pos = new double[2];
            uint pArrayElements = 2;
            pos[0] = position1;
            pos[1] = position2;
            //设置速度
            SetAxisVelocity(axisNo, velocityCurveParams);
            //启动运动
            //Motion.mAcm_GpMoveDirectAbs(m_Axises[axisNo], pos, ref pArrayElements);
        }
        /// <summary>
        /// 两轴圆弧插补相对移动（方向）
        /// </summary>
        /// <param name="axisNo">轴ID</param>
        /// <param name="CX">圆心坐标X</param>
        /// <param name="CY">圆心坐标Y</param>
        /// <param name="EX">终点坐标X</param>
        /// <param name="EY">终点坐标Y</param>
        /// <param name="Direction">0:DIR_CW,1:DIR_CCW</param>
        /// <param name="velocityCurveParams">速度参数</param>
        public void MoveArc2Relative(int axisNo, double CX, double CY, double EX, double EY, short Direction, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            var Cpos = new double[2];
            var Epos = new double[2];
            uint pArrayElements = 2;
            Cpos[0] = CX;
            Cpos[1] = CY;
            Epos[0] = EX;
            Epos[1] = EY;
            //设置速度
            SetAxisVelocity(axisNo, velocityCurveParams);
            //启动运动

        }

        /// <summary>
        /// 两轴圆弧插补绝对移动（方向）
        /// </summary>
        /// <param name="axisNo">轴ID</param>
        /// <param name="CX">圆心坐标X</param>
        /// <param name="CY">圆心坐标Y</param>
        /// <param name="EX">终点坐标X</param>
        /// <param name="EY">终点坐标Y</param>
        /// <param name="Direction">0:DIR_CW,1:DIR_CCW</param>
        /// <param name="velocityCurveParams">速度参数</param>
        public void MoveArc2Absolute(int axisNo, double CX, double CY, double EX, double EY, short Direction, VelocityCurve velocityCurveParams)
        {
            if (!_isInitialized) return;

            var Cpos = new double[2];
            var Epos = new double[2];
            uint pArrayElements = 2;
            Cpos[0] = CX;
            Cpos[1] = CY;
            Epos[0] = EX;
            Epos[1] = EY;
            //设置速度
            SetAxisVelocity(axisNo, velocityCurveParams);
            //启动运动
            //Motion.mAcm_GpMoveCircularAbs(m_Axises[axisNo], Cpos, Epos, ref pArrayElements, Direction);
        }
        /// <summary>
        ///     回零
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="homeMode">回原点方式</param>
        /// <param name="DirMode">0:DIR_CW,1:DIR_CCW</param>
        public void BackHome(int axisNo, uint homeMode, uint DirMode, VelocityCurve HomeVelocityCurve)
        {
            if (!_isInitialized) return;

            if (11 == axisNo || 12 == axisNo || 13 == axisNo || 14 == axisNo) //步进轴
            {
                LTDMC.nmc_set_home_profile(m_Devices[0], (ushort)m_Axises[axisNo], 19, 3500.0, HomeVelocityCurve.Maxvel * 1.0, HomeVelocityCurve.Tacc * 1.0, HomeVelocityCurve.Tdec * 1.0, 0);
                LTDMC.nmc_home_move(m_Devices[0], (ushort)m_Axises[axisNo]);
                CheckHomeDone(axisNo, 200);
                LTDMC.nmc_set_home_profile(m_Devices[0], (ushort)m_Axises[axisNo], 19, HomeVelocityCurve.Strvel * 1.0, HomeVelocityCurve.Maxvel * 1.0, HomeVelocityCurve.Tacc * 1.0, HomeVelocityCurve.Tdec * 1.0, 0);
                LTDMC.nmc_home_move(m_Devices[0], (ushort)m_Axises[axisNo]);
            }
            else if (15 == axisNo)
            {
                LTDMC.nmc_set_home_profile(m_Devices[0], (ushort)m_Axises[axisNo], 21, HomeVelocityCurve.Strvel * 1.0, HomeVelocityCurve.Maxvel * 1.0, HomeVelocityCurve.Tacc * 1.0, HomeVelocityCurve.Tdec * 1.0, 0);
                LTDMC.nmc_home_move(m_Devices[0], (ushort)m_Axises[axisNo]);
            }
            else
            {
                SetAxisVelocity(axisNo, HomeVelocityCurve);      //设置速度
                LTDMC.dmc_pmove_unit(m_Devices[0], (ushort)m_Axises[axisNo], 0, 1);//移到编码器设置的零点位置（绝对位置）
            }
        }
        public bool IsHoming(int axisNo)
        {
            if (!_isInitialized) return false;

            if (11 == axisNo || 12 == axisNo || 13 == axisNo || 14 == axisNo || 15 == axisNo) //步进轴
            {
                ushort axisstatemachine = 0;
                LTDMC.nmc_get_axis_state_machine(m_Devices[0], (ushort)m_Axises[axisNo], ref axisstatemachine);
                if (axisstatemachine == 5)
                {
                    return true;
                }
                return false;
            }
            else
            {
                double dunitPos = 0;
                LTDMC.dmc_get_position_unit(m_Devices[0], (ushort)m_Axises[axisNo], ref dunitPos); //读取指定轴指令位置值
                if (0 == dunitPos)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary >
        ///     检查回零是否完成
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public int CheckHomeDone(int axisNo, double timeoutLimit)
        {
            if (!_isInitialized) return 1;

            var strtime = new Stopwatch();
            strtime.Start();
            Thread.Sleep(100);
            do
            {
                //判断是否正常停止
                if (LTDMC.dmc_check_done(m_Devices[0], (ushort)m_Axises[axisNo]) == 1)
                {
                    Thread.Sleep(20);
                    return 0;
                }
                //检查是否超时
                strtime.Stop();
                if (strtime.ElapsedMilliseconds / 1000.0 > timeoutLimit)
                {
                    LTDMC.dmc_stop(m_Devices[0], (ushort)m_Axises[axisNo], 0); //减速停止
                    return -1;
                }
                strtime.Start();
                //延时
                Thread.Sleep(20);
            } while (true);

            return -1;
        }
        private void ShowMessages(string DetailMessage, uint errorCode)
        {
            if (!_isInitialized) return;

            string ErrorMessage = errorCode.ToString();
            MessageBox.Show(DetailMessage + "\r\nError Message:" + ErrorMessage, "Motion DAQ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #region Implementation of IDisposable

        /// <summary>
        ///     线性差补方式运动。
        /// </summary>
        /// <param name="axisNo1"></param>
        /// <param name="axisNo2"></param>
        /// <param name="pulseNum1"></param>
        /// <param name="pulseNum2"></param>
        /// <param name="velocityCurve"></param>
        public void MoveLine(int axisNo1, int axisNo2, int pulseNum1, int pulseNum2, VelocityCurve velocityCurve)
        {
            if (!_isInitialized) return;

            throw new NotImplementedException();
        }

        ~ApsController()
        {
            Dispose(false);
        }

        /// <summary>
        ///     Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
            }
            try
            {
                //APS168.APS_close();
            }
            catch (Exception)
            {
                //ignorl
            }
            _isInitialized = false;
            _disposed = true;
        }

        #endregion

        #region Implementation of ISwitchController

        /// <summary>
        /// 读取CANIO的某个输出端口
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="Node"></param>
        /// <param name="BitNo"></param>
        /// <returns></returns>
        public bool ReadCanoutIO(ushort CardNo, ushort Node, ushort BitNo)
        {
            if (!_isInitialized) return false;

            ushort var = 0;
            LTDMC.nmc_read_outbit(CardNo, Node, BitNo, ref var);
            return var == 1 ? true : false;
        }
        /// <summary>
        /// 读取CANIO的某个输入端口
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="Node"></param>
        /// <param name="BitNo"></param>
        /// <returns></returns>
        public bool ReadCanintIO(ushort CardNo, ushort Node, ushort BitNo)
        {
            if (!_isInitialized) return false;

            ushort var = 0;
            LTDMC.nmc_read_inbit(CardNo, Node, BitNo, ref var);
            return var == 1 ? true : false;
        }

        /// <summary>
        /// 设置CANIO的某个输出端口
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="Node"></param>
        /// <param name="BitNo"></param>
        /// <param name="on_off"></param>
        /// <returns></returns>
        public bool WriteCanoutIO(ushort CardNo, ushort Node, ushort BitNo, bool on_off)
        {
            if (!_isInitialized) return false;

            ushort var = 0;
            if (on_off) { var = 1; } else { var = 0; }
            LTDMC.nmc_write_outbit(CardNo, Node, BitNo, var);
            return false;
        }

        public bool Read(IoPoint ioPoint)
        {
            if (!_isInitialized) return false;

            short value = 0;
            try
            {               
                if ((ioPoint.IoMode & IoModes.Responser) != 0)
                {
                    value = LTDMC.dmc_read_outbit((ushort)ioPoint.BoardNo, (ushort)ioPoint.PortNo);
                }
                else if ((ioPoint.IoMode & IoModes.Senser) != 0)
                {
                    value = LTDMC.dmc_read_inbit((ushort)ioPoint.BoardNo, (ushort)ioPoint.PortNo);
                }
            }
            catch(SystemException)
            {
            }
            return value == 0 ? true : false;
        }

        public void Write(IoPoint ioPoint, bool value)
        {
            if (!_isInitialized) return;

            var ret = LTDMC.dmc_write_outbit((ushort)ioPoint.BoardNo, (ushort)ioPoint.PortNo, (ushort)(value ? 0 : 1));
        }

        #endregion

        /// <summary>
        /// 设置编码器原点
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public bool SetHomeORG(int axisNo)
        {
            if (!_isInitialized) return false;

            LTDMC.nmc_set_home_profile(m_Devices[0], (ushort)m_Axises[axisNo], 35, 0, 20000, 0.15, 0.2, 0);
            LTDMC.nmc_home_move(m_Devices[0], (ushort)m_Axises[axisNo]);
            return true;
        }

        /// <summary>
        /// 设置软限位
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="nlimit">负限位位置</param>
        /// <param name="plimit">正限位位置</param>
        /// <returns></returns>
        public bool SetSoftLimit(int axisNo, int nlimit, int plimit)
        {
            if (!_isInitialized) return false;

            short var = 0;
            var = LTDMC.dmc_set_softlimit(m_Devices[0], (ushort)m_Axises[axisNo], 1, 1, 1, nlimit, plimit);
            return var == 0 ? true : false;
        }

        /// <summary>
        /// 读取软限位设置
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="nlimit">返回负限位脉冲数</param>
        /// <param name="plimit">返回正限位脉冲数</param>
        /// <returns></returns>
        public bool GetSoftLimit(int axisNo, ref int nlimit, ref int plimit)
        {
            if (!_isInitialized) return false;

            ushort enable = 0;
            ushort sourcesel = 0;
            ushort slaction = 0;
            var var = LTDMC.dmc_get_softlimit(m_Devices[0], (ushort)m_Axises[axisNo], ref enable, ref sourcesel, ref slaction, ref nlimit, ref plimit);
            return var == 0 ? true : false;
        }

        /// <summary>
        /// 读取指定轴的运动模式
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public ushort GetRunMode(int axisNo)
        {
            if (!_isInitialized) return 1;

            ushort runmode = 0;
            short ret = LTDMC.dmc_get_axis_run_mode(m_Devices[0], (ushort)m_Axises[axisNo], ref runmode);
            return runmode;
        }


        #region 扭力控制(RTEX总线）

        /// <summary>
        /// 读取伺服驱动器参数
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="index">伺服参数目录索引</param>
        /// <param name="subindex">伺服参数目录索引下编号</param>
        /// <returns></returns>
        public uint ReadServoParameter(int axisNo, ushort index, ushort subindex)
        {
            if (!_isInitialized) return 1;

            uint paradata = 0;
            var var = LTDMC.nmc_read_parameter(m_Devices[0], (ushort)m_Axises[axisNo], index, subindex, ref paradata);
            return paradata;
        }

        /// <summary>
        /// 读取伺服驱动器参数
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="index">伺服参数目录索引</param>
        /// <param name="subindex">伺服参数目录索引下编号</param>
        /// <param name="paradata">伺服参数写入值</param>
        /// <returns></returns>
        public bool WriteServoParameter(int axisNo, ushort index, ushort subindex, uint paradata)
        {
            if (!_isInitialized) return false;

            short var = 0;
            var = LTDMC.nmc_write_parameter(m_Devices[0], (ushort)m_Axises[axisNo], index, subindex, paradata);
            return var == 0 ? true : false;
        }

        /// <summary>
        /// 伺服参数写 EEPROM 操作
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public bool WriteSlaveEeprom(int axisNo)
        {
            if (!_isInitialized) return false;

            short var = 0;
            var = LTDMC.nmc_write_slave_eeprom(m_Devices[0], (ushort)m_Axises[axisNo]);
            return var == 0 ? true : false;
        }

        /// <summary>
        /// 获取当前轴的转矩值
        /// </summary>
        /// <param name="axisNo"></param>
        /// <returns></returns>
        public int GetTorque(int axisNo)
        {
            if (!_isInitialized) return 1;

            int torque = 0;
            //var var = LTDMC.nmc_get_torque(m_Devices[0], (ushort)m_Axises[axisNo], ref torque);
            return torque;
        }

        /// <summary>
        /// 启动转矩模式下的运动
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="torque">扭力</param>
        /// <param name="PosLimitValid">位置限制开关</param>
        /// <param name="PosLimitValue">限制值</param>
        /// <param name="PosMode">位置模式</param>
        /// <returns></returns>
        public bool TorqueMove(int axisNo, int torque, ushort PosLimitValid, double PosLimitValue, ushort PosMode)
        {
            if (!_isInitialized) return false;

            short var = 0;
            //          var = LTDMC.nmc_torque_move(m_Devices[0], (ushort)m_Axises[axisNo], torque, PosLimitValid, PosLimitValue, PosMode);
            return var == 0 ? true : false;
        }

        /// <summary>
        /// 转矩控制过程中在线调整转矩值
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="torque">扭力</param>
        /// <returns></returns>
        public bool ChangeTorque(int axisNo, int torque)
        {
            if (!_isInitialized) return false;

            short var = 0;
            //var = LTDMC.nmc_change_torque(m_Devices[0], (ushort)m_Axises[axisNo], torque); 
            return var == 0 ? true : false;
        }

        #endregion

        #region 扭力控制(EtherCAT总线）

        /// <summary>
        /// 读取从站对象字典参数值
        /// </summary>
        /// <param name="NodeNum">从站EtherCAT地址</param>
        /// <param name="Index">对象字典索引，十进制</param>
        /// <param name="SubIndex">对象字典子索引，十进制</param>
        /// <param name="ValLength">对象字典索引长度(单位：bit)</param>
        /// <param name="Value">对象字典索引参数值，十进制</param>
        /// <returns></returns>
        public int GetNodeOd(ushort NodeNum, ushort Index, ushort SubIndex, ushort ValLength)
        {
            if (!_isInitialized) return 1;

            int Value = 0;
            var var = LTDMC.nmc_get_node_od(m_Devices[0], 2, NodeNum, Index, SubIndex, ValLength, ref Value);
            return Value;
        }

        /// <summary>
        /// 设置从站对象字典参数值
        /// </summary>
        /// <param name="NodeNum">从站EtherCAT地址</param>
        /// <param name="Index">对象字典索引，十进制</param>
        /// <param name="SubIndex">对象字典子索引，十进制</param>
        /// <param name="ValLength">对象字典索引长度(单位：bit)</param>
        /// <param name="Value">对象字典索引参数值，十进制</param>
        /// <returns></returns>
        public bool SetNodeOd(ushort NodeNum, ushort Index, ushort SubIndex, ushort ValLength, int Value)
        {
            if (!_isInitialized) return false;

            short var = 0;
            var = LTDMC.nmc_set_node_od(m_Devices[0], 2, NodeNum, Index, SubIndex, ValLength, Value);
            return var == 0 ? true : false;
        }

        /// <summary>
        /// 转矩控制过程中在线调整转矩值
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="torque">扭力</param>
        /// <returns></returns>
        public int GetEtherCATTorque(int axisNo)
        {
            if (!_isInitialized) return 1;

            int torque = 0;
            var var = LTDMC.nmc_get_torque(m_Devices[0], (ushort)m_Axises[axisNo], ref torque);
            return torque;
        }

        /// <summary>
        /// 启动转矩模式下的运动
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="torque">扭力</param>
        /// <param name="PosLimitValid">位置限制开关</param>
        /// <param name="PosLimitValue">限制值</param>
        /// <param name="PosMode">位置模式</param>
        /// <returns></returns>
        public bool EtherCATTorqueMove(int axisNo, int torque, ushort PosLimitValid, double PosLimitValue, ushort PosMode)
        {
            if (!_isInitialized) return false;

            short var = 0;
            var = LTDMC.nmc_torque_move(m_Devices[0], (ushort)m_Axises[axisNo], torque, PosLimitValid, PosLimitValue, PosMode);
            return var == 0 ? true : false;
        }

        /// <summary>
        /// 转矩控制过程中在线调整转矩值
        /// </summary>
        /// <param name="axisNo"></param>
        /// <param name="torque">扭力</param>
        /// <returns></returns>
        public bool EtherCATChangeTorque(int axisNo, int torque)
        {
            if (!_isInitialized) return false;

            short var = 0;
            var = LTDMC.nmc_change_torque(m_Devices[0], (ushort)m_Axises[axisNo], torque);
            return var == 0 ? true : false;
        }

        #endregion

    }
}