
namespace desay
{
   
    /// <summary>
    /// C轴数据结构
    /// </summary>
    public struct Caxis
    {      
        /// <summary>
        /// 待料角度
        /// </summary>
        public double Startangle;
        /// <summary>
        /// 剪刀初始角度
        /// </summary>
        public double CutStartangle;
        /// <summary>
        /// C轴回拉距离
        /// </summary>
        public double CaxisBackangle;
        /// <summary>
        /// 轴号
        /// </summary>
        public string axisName;
        /// <summary>
        /// 屏蔽
        /// </summary>
        public bool IsSheild;
        /// <summary>
        /// 剪切烫刀时间
        /// </summary>
        public int HotCutTime;
        /// <summary>
        /// 剪切是否扭力      
        /// </summary>
        public bool PosTorsion;
        /// <summary>
        /// 剪切烫刀次数
        /// </summary>
        public int HotCutCount;
        /// <summary>
        /// 剪切是否烫修
        /// </summary>
        public bool HotCut;
        /// <summary>
        /// 控制烫修行程的时间
        /// </summary>
        public int JourneyControl;
        /// <summary>
        /// 控制烫修行程开启
        /// </summary>
        public bool ControlOpen;
    }

    public struct Pos<T>
    {
        /// <summary>
        /// 原位
        /// </summary>
        public T Origin;
        /// <summary>
        /// 动作位
        /// </summary>
        public T Move;

    }


    public struct Fault
    {
        /// <summary>
        /// 故障代码
        /// </summary>
        public int FaultCode;
        /// <summary>
        /// 故障信息
        /// </summary>
        public string FaultMessage;
        /// <summary>
        /// 故障次数
        /// </summary>
        public int FaultCount;
    }

    public struct Fault1
    {
        /// <summary>
        /// 故障时间
        /// </summary>
        public string FaultTime;
        /// <summary>
        /// 故障代码
        /// </summary>
        public int FaultCode;
        /// <summary>
        /// 故障信息
        /// </summary>
        public string FaultMessage;
        /// <summary>
        /// 故障次数
        /// </summary>
        public int FaultCount;
    }

    public struct sPort
    {
        public string PortName;       
      
    }

}
