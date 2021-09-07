using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.ToolKit;
using System.Collections.Generic;
using System.Enginee;
namespace desay
{
    [Serializable]
    public class Config
    {
        public static Config Instance = new Config();

        //用户相关信息
        public string userName, AdminPassword = MD5.TextToMd5("321"), OperatePassword = MD5.TextToMd5("123"), EngineerPassword = MD5.TextToMd5("123456"),
            ManufacturerPassword = MD5.TextToMd5("ds");
        public UserLevel userLevel = UserLevel.None;

     

        /// <summary>
        ///     当前产品型号
        /// </summary>
        public string CurrentProductType = "DS";

        /// <summary>
        ///     所有产品型号
        /// </summary>
        public List<string> ProductType = new List<string>();
        /// <summary>
        /// 通信端口ModeBusRTU(温度控制)
        /// </summary>
        public string AnalogConnetPortName = "COM4";
        /// <summary>
        /// 通信端口ModeBusRTU
        /// </summary>
        public string AnalogConnetPortName1 = "COM6";
        /// <summary>
        /// 模拟量地址通道
        /// </summary>
        public string[] AnalogAddress = new string[4] { "0", "1", "2", "3" };

        ///// <summary>
        ///// 温控器值
        ///// </summary>
        //public short[] TemperatureValue1 = new short[4] { 0, 0, 0, 0 };
        /// <summary>
        /// 温控器地址通道(写)
        /// </summary>
        public string[] WriteTemperatureValue = new string[4] { "0C", "0D", "0E", "0F" };
        /// <summary>
        /// 温控器地址通道(读)
        /// </summary>
        public string[] TemperatureAddress1 = new string[4] { "00", "01", "02", "03" };     
      
        /// <summary>
        /// 剪切扭力值
        /// </summary>
        public int[] PressCut = new int[4] { 1, 1, 1, 1 };
        /// <summary>
        /// 温度设定
        /// </summary>
        public int[] TemperatureValue = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// 温度报警上下限
        /// </summary>
        public int[] TemperatureAlarmLimit = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// 温度报警上下限
        /// </summary>
        public bool[] TemperatureAlarmState = new bool[4] {false,false,false,false};
        /// <summary>
        /// 温度修正
        /// </summary>
        public int[] TemperatureViewOffset = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>
        ///     OK产品总数
        /// </summary>
        public int ProductOkTotal;
    
        /// <summary>
        ///     NG产品总数
        /// </summary>
        public int ProductNgTotal;
        /// <summary>
        /// C轴旋转次数
        /// </summary>
        public int[] CaxisCountSet = new int[4];
        /// <summary>
        /// C轴旋转次数
        /// </summary>
        public int[] CaxisCount = new int[3];


        /// <summary>
        /// C轴剪料总计数
        /// </summary>
        public int[] CutaxisCountTotal = new int[4];
        /// <summary>
        /// 无料勾盘次数设定
        /// </summary>
        public int NoProductGTrayCount;



        /// <summary>
        /// 是否换盘报警
        /// </summary>
        public bool ChangeTrayArl;

        #region  联机信号
        /// <summary>
        /// 联机信号
        /// </summary>
        public bool OnlineStu;
        /// <summary>
        /// 联机信号反转
        /// </summary>
        public bool SignalReverseSplice;
        /// <summary>
        /// 联机信号延时
        /// </summary>
        public int SignalSpliceDelay;
        #endregion

        #region 除静电时间
        /// <summary>
        ///  除静电时间
        /// </summary>
        public int DestaticizingTime;
        #endregion

        /// <summary>
        /// 吸笔报警取消
        /// </summary>
        public bool InspireErrEsc;

        /// <summary>
        /// 进料光纤连续未取到料
        /// </summary>
        public int FeederFailCount;

        /// <summary>
        /// 左大托盘
        /// </summary>
        public int[] LeftTarySet = new int[] { };
        /// <summary>
        /// 右大托盘
        /// </summary>
        public int[] RightTarySet = new int[] { };
        /// <summary>
        /// 左大托盘
        /// </summary>
        public int[] LeftTarySet1 = new int[] { };
        /// <summary>
        /// 右大托盘
        /// </summary>
        public int[] RightTarySet1 = new int[] { };

        /// <summary>
        /// 小托盘ID
        /// </summary>
        public string YoungPlateID = "Hole";
        /// <summary>
        /// 大托盘ID
        /// </summary>
        public string BigPlateID = "BigTray";
        /// <summary>
        /// 特殊托盘ID
        /// </summary>
        public string SpecialPlateID = "SpecialTray";
        /// <summary>
        /// 小盘运行位置记录
        /// </summary>
        public int YoungPlatePos;
        /// <summary>
        /// 大盘运行位置记录
        /// </summary>
        public int BigPlatePos;
        /// <summary>
        /// 特殊盘运行位置记录
        /// </summary>
        public int SpecialPlatePos;
        /// <summary>
        /// 抽检执行状态(控制界面按键状态)
        /// </summary>
        public bool SelectCheckRunState;

        /// <summary>
        /// 特殊盘开启
        /// </summary>
        public bool SpecialTrayStart;

        #region 主界面参数
        /// <summary>
        /// C轴剪料次数
        /// </summary>
        public int[] CutaxisCount = new int[4];
        /// <summary>
        /// 托盘完成数量
        /// </summary>
        public int TrayFinishcount;
        /// <summary>
        /// 镜片完成数量
        /// </summary>
        public int Finishcount;
        /// <summary>
        /// 穴完成数量
        /// </summary>
        public int HoleFinishCount;
        #endregion

        #region 三色灯显示模式
        /// <summary>
        /// 运行时三色灯的状态
        /// </summary>
        public TricolorLamp RunSturs;
        /// <summary>
        /// 暂停时三色灯的状态
        /// </summary>
        public TricolorLamp SuspendSturs;
        /// <summary>
        /// 停止时三色灯的状态
        /// </summary>
        public TricolorLamp StopSturs;
        /// <summary>
        /// 故障时三色灯的状态
        /// </summary>
        public TricolorLamp ErrSturs;
        /// <summary>
        /// 复位时三色灯的状态
        /// </summary>
        public TricolorLamp ResetSturs;
        /// <summary>
        /// 有警示时三色灯的状态
        /// </summary>
        public TricolorLamp WarningSturs;
        #endregion

        #region 用户权限设定
        public UserLevel[] userLevels = new UserLevel[12];

        public bool[] UserL = new bool[13];
        #endregion

        /// <summary>
        /// 产品总数
        /// </summary>
        public int ProductTotal
        {
            get
            {
                return ProductOkTotal + ProductNgTotal;
            }
        }
        /// <summary>
        /// 开机时间
        /// </summary>
        public TimeSpan UpDateTime;

        /// <summary>
        /// 运行时间
        /// </summary>
        public TimeSpan RunDateTime;
    }
}
