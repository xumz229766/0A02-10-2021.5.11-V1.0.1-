﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Framework;

namespace System.Device
{
    public class HIOKI3561 : SerialPort, ISerialPortTriggerModel
    {
        /* 
         * :TRIG:SOUR EXT/IMM<CR>
         * :INIT:CONT ON/OFF<CR>
         */

        #region 变量

        string receiveString = "";

        #endregion

        #region 构造函数

        public HIOKI3561() : base() { }

        /// <summary>
        /// 使用指定的端口名称、波特率、奇偶校验位、数据位和停止位初始化 System.IO.Ports.SerialPort 类的新实例。
        /// </summary>
        /// <param name="portName">要使用的端口（例如 COM1）。</param>
        /// <param name="baudRate">波特率。</param>
        /// <param name="parity"> System.IO.Ports.SerialPort.Parity 值之一。</param>
        /// <param name="dataBits">数据位值。</param>
        /// <param name="stopBits">System.IO.Ports.SerialPort.StopBits 值之一。</param>
        public HIOKI3561(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits) : base(portName, baudRate, parity, dataBits, stopBits) { }

        #endregion

        #region 方法

        #endregion

        #region 接口

        public event DataReceiveCompleteEventHandler DeviceDataReceiveCompelete;

        public string Name { get; set; }
        public string ConnectionParam { get; set; }

        public void SetConnectionParam(string str)
        {
            ConnectionParam = str;
            string[] param = ConnectionParam.Split(',');
            PortName = param[0];
            BaudRate = int.Parse(param[1]);
            Parity = (Parity)Enum.Parse(typeof(Parity), param[2]);
            DataBits = int.Parse(param[3]);
            StopBits = (StopBits)Enum.Parse(typeof(StopBits), param[4]);
            ReadTimeout = int.Parse(param[5]);
            WriteTimeout = int.Parse(param[6]);
        }

        public void DeviceOpen()
        {
            if (IsOpen)
                throw new Exception("设备已经连接\n");

            Open();
        }

        public void DeviceClose()
        {
            if (IsOpen)
            {
                Application.DoEvents();
                Close();
            }
        }

        delegate void TriggerDelegate(TriggerArgs args);
        TriggerDelegate triggerMethod;
        public IAsyncResult TriggerResult;
        public IAsyncResult BeginTrigger(TriggerArgs args)
        {
            if (triggerMethod == null)
                triggerMethod = new TriggerDelegate(Trigger);

            if (TriggerResult != null && !TriggerResult.IsCompleted)
                return TriggerResult;

            TriggerResult = triggerMethod.BeginInvoke(args, null, null);

            return TriggerResult;
        }

        double vol, res;
        [ExecuteInfo("TRG", "测试设备开始测试", "TRG")]
        public void Trigger(TriggerArgs args)
        {
            for (int i = 0; i < args.tryTimes; i++)
            {
                try
                {
                    vol = res = 0;
                    receiveString = "";
                    DiscardInBuffer();
                    WriteLine(@"*TRG;:FETC?");
                    receiveString = ReadLine();
                    string[] results = receiveString.Split(',');
                    results[0] = results[0].Trim();
                    results[1] = results[1].Trim();

                    if (results[1] == "10.0000E+9")
                        throw new Exception("电压测量失败");

                    if (results[0] == "1000.00E+7")
                        throw new Exception("内阻测量失败");

                    vol = Convert.ToDouble(results[1]);
                    res = Convert.ToDouble(results[0]) * 1000;
                    receiveString = vol.ToString("0.0000") + "," + res.ToString("F");
                    break;
                }
                catch (Exception ex)
                {
                    receiveString = UniversalFlags.errorStr + ex.Message;
                }
            }
            if (args.sender.GetType() != typeof(HIOKI3561))
            {
                if (DeviceDataReceiveCompelete != null)
                    DeviceDataReceiveCompelete(this, receiveString);
            }
        }


        public string StopTrigger()
        {
            return UniversalFlags.successStr;
        }

        public string Execute(string cmd)
        {
            string result = "";
            cmd = cmd.ToUpper().Trim();
            if ("HEL" == cmd.Substring(0, 3))
            {
                Attribute[] attribs = typeof(HIOKI3561).GetMethods().Select(s =>
                    Attribute.GetCustomAttribute(s, typeof(ExecuteInfo))
                    ).Where(s => s != null).ToArray();

                result = "该设备支持以下指令：" + Environment.NewLine;
                foreach (Attribute attrib in attribs)
                {
                    ExecuteInfo exe = (ExecuteInfo)attrib;
                    result += Environment.NewLine + exe.Command + " - " + exe.Describe + Environment.NewLine
                        + "示例：" + exe.Example + Environment.NewLine;
                }
            }
            else if ("TRG" == cmd.Substring(0, 3))
            {
                Trigger(new TriggerArgs()
                {
                    sender = this,
                    tryTimes = 1
                });
                result = receiveString;
            }
            else
            {
                result = "不支持指令" + cmd;
            }
            return result;
        }

        #endregion
    }
}
