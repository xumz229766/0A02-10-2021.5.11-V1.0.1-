
using Motion.Interfaces;
using Motion.LSAps;
namespace desay
{
    /// <summary>
    ///     设备 IO 项
    /// </summary>
    public class IoPoints
    {
        private const string ApsControllerName = "雷塞控制卡";  
        internal static readonly ushort DMC3C00 = 0;
        internal static readonly ushort DMC3400 = 1;
        internal static readonly byte PCI7432_0 = 0;
        public static ApsController ApsController = new ApsController() { Name = ApsControllerName };

        #region DMC3C00 IO list

        /// <summary>
        ///   接料原点信号
        /// </summary>
        public static IoPoint T0DI0 = new IoPoint(ApsController, DMC3C00, 0, IoModes.Senser)
        {
            Name = "T0DI0",
            Description = "接料原点信号"
        };

        /// <summary>
        ///   接料动点信号
        /// </summary>
        public static IoPoint T0DI1 = new IoPoint(ApsController, DMC3C00, 1, IoModes.Senser)
        {
            Name = "T0DI0",
            Description = "接料动点信号"
        };

        /// <summary>
        ///   1#来料光电感应
        /// </summary>
        public static IoPoint T0DI2 = new IoPoint(ApsController, DMC3C00, 2, IoModes.Senser)
        {
            Name = "T0DI2",
            Description = "1#来料光电感应"
        };

        /// <summary>
        ///   气压检测信号
        /// </summary>
        public static IoPoint T0DI3 = new IoPoint(ApsController, DMC3C00, 3, IoModes.Senser)
        {
            Name = "T0DI3",
            Description = "气压检测信号"
        };

        /// <summary>
        ///   仓储自动门按钮
        /// </summary>
        public static IoPoint T0DI4 = new IoPoint(ApsController, DMC3C00, 4, IoModes.Senser)
        {
            Name = "T0DI4",
            Description = "仓储自动门按钮"
        };

        /// <summary>
        ///   切废料气缸原点
        /// </summary>
        public static IoPoint T0DI5 = new IoPoint(ApsController, DMC3C00, 5, IoModes.Senser)
        {
            Name = "T0DI5",
            Description = "切废料气缸原点"
        };

        /// <summary>
        ///   切废料气缸动点
        /// </summary>
        public static IoPoint T0DI6 = new IoPoint(ApsController, DMC3C00, 6, IoModes.Senser)
        {
            Name = "T0DI6",
            Description = "切废料气缸动点"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T0DI7 = new IoPoint(ApsController, DMC3C00, 7, IoModes.Senser)
        {
            Name = "T0DI7",
            Description = "备用"
        };
        /// <summary>
        ///   移料左右原点信号（1#）
        /// </summary>
        public static IoPoint T0DI8 = new IoPoint(ApsController, DMC3C00, 8, IoModes.Senser)
        {
            Name = "T0DI8",
            Description = "移料左右原点信号（1#）"
        };
        /// <summary>
        ///   移料左右动点信号（1#）
        /// </summary>
        public static IoPoint T0DI9 = new IoPoint(ApsController, DMC3C00, 9, IoModes.Senser)
        {
            Name = "T0DI9",
            Description = "移料左右动点信号（1#）"
        };
        /// <summary>
        ///   进料原点信号
        /// </summary>
        public static IoPoint T0DI10 = new IoPoint(ApsController, DMC3C00, 10, IoModes.Senser)
        {
            Name = "T0DI10",
            Description = "进料原点信号"
        };
        /// <summary>
        ///   进料动点信号
        /// </summary>
        public static IoPoint T0DI11 = new IoPoint(ApsController, DMC3C00, 11, IoModes.Senser)
        {
            Name = "T0DI11",
            Description = "进料动点信号"
        };
        /// <summary>
        ///   移料左右原点信号（2#）
        /// </summary>
        public static IoPoint T0DI12 = new IoPoint(ApsController, DMC3C00, 12, IoModes.Senser)
        {
            Name = "T0DI12",
            Description = "移料左右原点信号（2#）"
        };

        /// <summary>
        ///   移料左右动点信号（2#）
        /// </summary>
        public static IoPoint T0DI13 = new IoPoint(ApsController, DMC3C00, 13, IoModes.Senser)
        {
            Name = "T0DI13",
            Description = "移料左右动点信号（2#）"
        };
        /// <summary>
        ///   移料上下原点信号
        /// </summary>
        public static IoPoint T0DI14 = new IoPoint(ApsController, DMC3C00, 14, IoModes.Senser)
        {
            Name = "T0DI14",
            Description = "移料上下原点信号"
        };
        /// <summary>
        ///   移料上下动点信号
        /// </summary>
        public static IoPoint T0DI15 = new IoPoint(ApsController, DMC3C00, 15, IoModes.Senser)
        {
            Name = "T0DI15",
            Description = "移料上下动点信号"
        };

        /// <summary>
        /// 接料原点动作
        /// </summary>
        public static IoPoint T0DO0 = new IoPoint(ApsController, DMC3C00, 0, IoModes.Signal)
        {
            Name = "T0DO0",
            Description = "接料原点动作"
        };

        /// <summary>
        ///   接料动点动作
        /// </summary>
        public static IoPoint T0DO1 = new IoPoint(ApsController, DMC3C00, 1, IoModes.Signal)
        {
            Name = "T0DO1",
            Description = "接料动点动作"
        };

        /// <summary>
        ///   切废料气缸1#
        /// </summary>
        public static IoPoint T0DO2 = new IoPoint(ApsController, DMC3C00, 2, IoModes.Signal)
        {
            Name = "T0DO2",
            Description = "切废料气缸1#"
        };

        /// <summary>
        ///   切废料气缸2#（备用）
        /// </summary>
        public static IoPoint T0DO3 = new IoPoint(ApsController, DMC3C00, 3, IoModes.Signal)
        {
            Name = "T0DO3",
            Description = "切废料气缸2#（备用）"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T0DO4 = new IoPoint(ApsController, DMC3C00, 4, IoModes.Signal)
        {
            Name = "T0DO4",
            Description = "备用"
        };

        /// <summary>
        ///  进料
        /// </summary>
        public static IoPoint T0DO5 = new IoPoint(ApsController, DMC3C00, 5, IoModes.Signal)
        {
            Name = "T0DO5",
            Description = "进料"
        };

        /// <summary>
        ///  移料左右
        /// </summary>
        public static IoPoint T0DO6 = new IoPoint(ApsController, DMC3C00, 6, IoModes.Signal)
        {
            Name = "T0DO6",
            Description = "移料左右"
        };

        /// <summary>
        ///   移料上下
        /// </summary>
        public static IoPoint T0DO7 = new IoPoint(ApsController, DMC3C00, 7, IoModes.Signal)
        {
            Name = "T0DO7",
            Description = "移料上下"
        };

        /// <summary>
        ///  移料夹子
        /// </summary>
        public static IoPoint T0DO8 = new IoPoint(ApsController, DMC3C00, 8, IoModes.Signal)
        {
            Name = "T0DO8",
            Description = "移料夹子"
        };

        /// <summary>
        ///  1#剪刀夹料上下
        /// </summary>
        public static IoPoint T0DO9 = new IoPoint(ApsController, DMC3C00, 9, IoModes.Signal)
        {
            Name = "T0DO9",
            Description = "1#剪刀夹料上下"
        };

        /// <summary>
        ///  2#剪刀夹料上下
        /// </summary>
        public static IoPoint T0DO10 = new IoPoint(ApsController, DMC3C00, 10, IoModes.Signal)
        {
            Name = "T0DO10",
            Description = "2#剪刀夹料上下"
        };

        /// <summary>
        ///  3#剪刀夹料上下
        /// </summary>
        public static IoPoint T0DO11 = new IoPoint(ApsController, DMC3C00, 11, IoModes.Signal)
        {
            Name = "T0DO11",
            Description = "3#剪刀夹料上下"
        };

        /// <summary>
        ///   4#剪刀夹料上下
        /// </summary>
        public static IoPoint T0DO12 = new IoPoint(ApsController, DMC3C00, 12, IoModes.Signal)
        {
            Name = "T0DO12",
            Description = "4#剪刀夹料上下"
        };

        /// <summary>
        ///  1#C轴推进
        /// </summary>
        public static IoPoint T0DO13 = new IoPoint(ApsController, DMC3C00, 13, IoModes.Signal)
        {
            Name = "T0DO13",
            Description = "1#C轴推进"
        };

        /// <summary>
        ///  2#C轴推进
        /// </summary>
        public static IoPoint T0DO14 = new IoPoint(ApsController, DMC3C00, 14, IoModes.Signal)
        {
            Name = "T0DO14",
            Description = "2#C轴推进"
        };

        /// <summary>
        ///   3#C轴推进
        /// </summary>
        public static IoPoint T0DO15 = new IoPoint(ApsController, DMC3C00, 15, IoModes.Signal)
        {
            Name = "T0DO15",
            Description = "3#C轴推进"
        };

        #endregion

        #region DMC3400 IO list

        /// <summary>
        ///   1#剪切夹料上下原点
        /// </summary>
        public static IoPoint T1DI0 = new IoPoint(ApsController, DMC3400, 0, IoModes.Senser)
        {
            Name = "T1DI0",
            Description = "1#剪切夹料上下原点"
        };

        /// <summary>
        ///   1#剪切夹料上下动点
        /// </summary>
        public static IoPoint T1DI1 = new IoPoint(ApsController, DMC3400, 1, IoModes.Senser)
        {
            Name = "T1DI1",
            Description = "1#剪切夹料上下动点"
        };

        /// <summary>
        ///   2#剪切夹料上下原点
        /// </summary>
        public static IoPoint T1DI2 = new IoPoint(ApsController, DMC3400, 2, IoModes.Senser)
        {
            Name = "T1DI2",
            Description = "2#剪切夹料上下原点"
        };

        /// <summary>
        ///   2#剪切夹料上下动点
        /// </summary>
        public static IoPoint T1DI3 = new IoPoint(ApsController, DMC3400, 3, IoModes.Senser)
        {
            Name = "T1DI3",
            Description = "2#剪切夹料上下动点"
        };

        /// <summary>
        ///   3#剪切夹料上下原点
        /// </summary>
        public static IoPoint T1DI4 = new IoPoint(ApsController, DMC3400, 4, IoModes.Senser)
        {
            Name = "T1DI4",
            Description = "3#剪切夹料上下原点"
        };

        /// <summary>
        ///   3#剪切夹料上下动点
        /// </summary>
        public static IoPoint T1DI5 = new IoPoint(ApsController, DMC3400, 5, IoModes.Senser)
        {
            Name = "T1DI5",
            Description = "3#剪切夹料上下动点"
        };

        /// <summary>
        ///   4#剪切夹料上下原点
        /// </summary>
        public static IoPoint T1DI6 = new IoPoint(ApsController, DMC3400, 6, IoModes.Senser)
        {
            Name = "T1DI6",
            Description = "4#剪切夹料上下原点"
        };

        /// <summary>
        ///   4#剪切夹料上下动点
        /// </summary>
        public static IoPoint T1DI7 = new IoPoint(ApsController, DMC3400, 7, IoModes.Senser)
        {
            Name = "T1DI7",
            Description = "4#剪切夹料上下动点"
        };
        /// <summary>
        ///   C轴推进1#原点信号
        /// </summary>
        public static IoPoint T1DI8 = new IoPoint(ApsController, DMC3400, 8, IoModes.Senser)
        {
            Name = "T1DI8",
            Description = "C轴推进1#原点信号"
        };
        /// <summary>
        ///   C轴推进1#动点信号
        /// </summary>
        public static IoPoint T1DI9 = new IoPoint(ApsController, DMC3400, 9, IoModes.Senser)
        {
            Name = "T1DI9",
            Description = "C轴推进1#动点信号"
        };
        /// <summary>
        ///   C轴推进2#原点信号
        /// </summary>
        public static IoPoint T1DI10 = new IoPoint(ApsController, DMC3400, 10, IoModes.Senser)
        {
            Name = "T1DI10",
            Description = "C轴推进2#原点信号"
        };
        /// <summary>
        ///   C轴推进2#动点信号
        /// </summary>
        public static IoPoint T1DI11 = new IoPoint(ApsController, DMC3400, 11, IoModes.Senser)
        {
            Name = "T1DI11",
            Description = "C轴推进2#动点信号"
        };
        /// <summary>
        ///   C轴推进3#原点信号
        /// </summary>
        public static IoPoint T1DI12 = new IoPoint(ApsController, DMC3400, 12, IoModes.Senser)
        {
            Name = "T1DI12",
            Description = "C轴推进3#原点信号"
        };

        /// <summary>
        ///   C轴推进3#动点信号
        /// </summary>
        public static IoPoint T1DI13 = new IoPoint(ApsController, DMC3400, 13, IoModes.Senser)
        {
            Name = "T1DI13",
            Description = "C轴推进3#动点信号"
        };
        /// <summary>
        ///   移料夹子有料感应
        /// </summary>
        public static IoPoint T1DI14 = new IoPoint(ApsController, DMC3400, 14, IoModes.Senser)
        {
            Name = "T1DI14",
            Description = "移料夹子有料感应"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T1DI15 = new IoPoint(ApsController, DMC3400, 15, IoModes.Senser)
        {
            Name = "T1DI15",
            Description = "备用"
        };

        /// <summary>
        /// 1#剪切夹料前后
        /// </summary>
        public static IoPoint T1DO0 = new IoPoint(ApsController, DMC3400, 0, IoModes.Signal)
        {
            Name = "T1DO0",
            Description = "1#剪切夹料前后"
        };

        /// <summary>
        ///   2#剪切夹料前后
        /// </summary>
        public static IoPoint T1DO1 = new IoPoint(ApsController, DMC3400, 1, IoModes.Signal)
        {
            Name = "T1DO1",
            Description = "2#剪切夹料前后"
        };

        /// <summary>
        ///   3#剪切夹料前后
        /// </summary>
        public static IoPoint T1DO2 = new IoPoint(ApsController, DMC3400, 2, IoModes.Signal)
        {
            Name = "T1DO2",
            Description = "3#剪切夹料前后"
        };

        /// <summary>
        ///   4#剪切夹料前后
        /// </summary>
        public static IoPoint T1DO3 = new IoPoint(ApsController, DMC3400, 3, IoModes.Signal)
        {
            Name = "T1DO3",
            Description = "4#剪切夹料前后"
        };

        /// <summary>
        ///   1#剪切夹料夹爪
        /// </summary>
        public static IoPoint T1DO4 = new IoPoint(ApsController, DMC3400, 4, IoModes.Signal)
        {
            Name = "T1DO4",
            Description = "1#剪切夹料夹爪"
        };

        /// <summary>
        ///  2#剪切夹料夹爪
        /// </summary>
        public static IoPoint T1DO5 = new IoPoint(ApsController, DMC3400, 5, IoModes.Signal)
        {
            Name = "T1D05",
            Description = "2#剪切夹料夹爪"
        };

        /// <summary>
        ///  3#剪切夹料夹爪
        /// </summary>
        public static IoPoint T1DO6 = new IoPoint(ApsController, DMC3400, 6, IoModes.Signal)
        {
            Name = "T1DO6",
            Description = "3#剪切夹料夹爪"
        };

        /// <summary>
        ///   4#剪切夹料夹爪
        /// </summary>
        public static IoPoint T1DO7 = new IoPoint(ApsController, DMC3400, 7, IoModes.Signal)
        {
            Name = "T1DO7",
            Description = "4#剪切夹料夹爪"
        };

        /// <summary>
        ///  1#吸笔吸真空
        /// </summary>
        public static IoPoint T1DO8 = new IoPoint(ApsController, DMC3400, 8, IoModes.Signal)
        {
            Name = "T1DO8",
            Description = "1#吸笔吸真空"
        };

        /// <summary>
        ///  1#吸笔破真空
        /// </summary>
        public static IoPoint T1DO9 = new IoPoint(ApsController, DMC3400, 9, IoModes.Signal)
        {
            Name = "T1DO9",
            Description = "1#吸笔破真空"
        };

        /// <summary>
        ///  2#吸笔吸真空
        /// </summary>
        public static IoPoint T1DO10 = new IoPoint(ApsController, DMC3400, 10, IoModes.Signal)
        {
            Name = "T1DO10",
            Description = "2#吸笔吸真空"
        };

        /// <summary>
        ///  2#吸笔破真空
        /// </summary>
        public static IoPoint T1DO11 = new IoPoint(ApsController, DMC3400, 11, IoModes.Signal)
        {
            Name = "T1DO11",
            Description = "2#吸笔破真空"
        };

        /// <summary>
        ///   3#吸笔吸真空
        /// </summary>
        public static IoPoint T1DO12 = new IoPoint(ApsController, DMC3400, 12, IoModes.Signal)
        {
            Name = "T1DO12",
            Description = "3#吸笔吸真空"
        };

        /// <summary>
        ///  3#吸笔破真空
        /// </summary>
        public static IoPoint T1DO13 = new IoPoint(ApsController, DMC3400, 13, IoModes.Signal)
        {
            Name = "T1DO13",
            Description = "3#吸笔破真空"
        };

        /// <summary>
        ///  4#吸笔吸真空
        /// </summary>
        public static IoPoint T1DO14 = new IoPoint(ApsController, DMC3400, 14, IoModes.Signal)
        {
            Name = "T1DO14",
            Description = "4#吸笔吸真空用"
        };

        /// <summary>
        ///   4#吸笔破真空
        /// </summary>
        public static IoPoint T1DO15 = new IoPoint(ApsController, DMC3400, 15, IoModes.Signal)
        {
            Name = "T1DO15",
            Description = "4#吸笔破真空"
        };

        #endregion

        #region EM32DX-C1) IO list

        /// <summary>
        ///   1#剪切夹料前后原点信号
        /// </summary>
        public static IoPoint T2DI0 = new IoPoint(ApsController, DMC3400, 0, IoModes.Senser,1)
        {
            Name = "T2DI0",
            Description = "1#剪切夹料前后原点信号"
        };

        /// <summary>
        ///   1#剪切夹料前后动点
        /// </summary>
        public static IoPoint T2DI1 = new IoPoint(ApsController, DMC3400, 1, IoModes.Senser,1)
        {
            Name = "T2DI1",
            Description = "1#剪切夹料前后动点"
        };

        /// <summary>
        ///   2#剪切夹料前后原点
        /// </summary>
        public static IoPoint T2DI2 = new IoPoint(ApsController, DMC3400, 2, IoModes.Senser,1)
        {
            Name = "T2DI2",
            Description = "2#剪切夹料前后原点"
        };

        /// <summary>
        ///   2#剪切夹料前后动点
        /// </summary>
        public static IoPoint T2DI3 = new IoPoint(ApsController, DMC3400, 3, IoModes.Senser,1)
        {
            Name = "T2DI3",
            Description = "2#剪切夹料前后动点"
        };

        /// <summary>
        ///   3#剪切夹料前后原点
        /// </summary>
        public static IoPoint T2DI4 = new IoPoint(ApsController, DMC3400, 4, IoModes.Senser,1)
        {
            Name = "T2DI4",
            Description = "3#剪切夹料前后原点"
        };

        /// <summary>
        ///   3#剪切夹料前后动点
        /// </summary>
        public static IoPoint T2DI5 = new IoPoint(ApsController, DMC3400, 5, IoModes.Senser,1)
        {
            Name = "T2DI5",
            Description = "3#剪切夹料前后动点"
        };

        /// <summary>
        ///   4#剪切夹料前后原点
        /// </summary>
        public static IoPoint T2DI6 = new IoPoint(ApsController, DMC3400, 6, IoModes.Senser,1)
        {
            Name = "T2DI6",
            Description = "4#剪切夹料前后原点"
        };

        /// <summary>
        ///   4#剪切夹料前后动点
        /// </summary>
        public static IoPoint T2DI7 = new IoPoint(ApsController, DMC3400, 7, IoModes.Senser,1)
        {
            Name = "T2DI7",
            Description = "4#剪切夹料前后动点"
        };
        /// <summary>
        ///   1#吸笔移动原点信号
        /// </summary>
        public static IoPoint T2DI8 = new IoPoint(ApsController, DMC3400, 8, IoModes.Senser,1)
        {
            Name = "T2DI8",
            Description = "1#吸笔移动原点信号"
        };
        /// <summary>
        ///   1#吸笔移动动点信号
        /// </summary>
        public static IoPoint T2DI9 = new IoPoint(ApsController, DMC3400, 9, IoModes.Senser,1)
        {
            Name = "T2DI9",
            Description = "1#吸笔移动动点信号"
        };
        /// <summary>
        ///   2#吸笔移动原点信号
        /// </summary>
        public static IoPoint T2DI10 = new IoPoint(ApsController, DMC3400, 10, IoModes.Senser,1)
        {
            Name = "T2DI10",
            Description = "2#吸笔移动原点信号"
        };
        /// <summary>
        ///   2#吸笔移动动点信号
        /// </summary>
        public static IoPoint T2DI11 = new IoPoint(ApsController, DMC3400, 11, IoModes.Senser,1)
        {
            Name = "T2DI11",
            Description = "2#吸笔移动动点信号"
        };
        /// <summary>
        ///  3#吸笔移动原点信号
        /// </summary>
        public static IoPoint T2DI12 = new IoPoint(ApsController, DMC3400, 12, IoModes.Senser,1)
        {
            Name = "T2DI12",
            Description = "3#吸笔移动原点信号"
        };

        /// <summary>
        ///   3#吸笔移动动点信号
        /// </summary>
        public static IoPoint T2DI13 = new IoPoint(ApsController, DMC3400, 13, IoModes.Senser,1)
        {
            Name = "T2DI13",
            Description = "3#吸笔移动动点信号"
        };
        /// <summary>
        ///  4#吸笔移动原点信号
        /// </summary>
        public static IoPoint T2DI14 = new IoPoint(ApsController, DMC3400, 14, IoModes.Senser,1)
        {
            Name = "T2DI14",
            Description = "4#吸笔移动原点信号"
        };
        /// <summary>
        ///   4#吸笔移动动点信号
        /// </summary>
        public static IoPoint T2DI15 = new IoPoint(ApsController, DMC3400, 15, IoModes.Senser,1)
        {
            Name = "T2DI15",
            Description = "4#吸笔移动动点信号"
        };

        /// <summary>
        /// 拉料气缸上下
        /// </summary>
        public static IoPoint T2DO0 = new IoPoint(ApsController, DMC3400, 0, IoModes.Signal,1)
        {
            Name = "T2DO0",
            Description = "拉料气缸上下"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T2DO1 = new IoPoint(ApsController, DMC3400, 1, IoModes.Signal,1)
        {
            Name = "T2DO1",
            Description = "备用"
        };

        /// <summary>
        ///   摆盘卡紧
        /// </summary>
        public static IoPoint T2DO2 = new IoPoint(ApsController, DMC3400, 2, IoModes.Signal,1)
        {
            Name = "T2DO2",
            Description = "摆盘卡紧"
        };

        /// <summary>
        ///   安全门原点动作
        /// </summary>
        public static IoPoint T2DO3 = new IoPoint(ApsController, DMC3400, 3, IoModes.Signal,1)
        {
            Name = "T2DO3",
            Description = "安全门原点动作"
        };

        /// <summary>
        ///   安全门动点动作
        /// </summary>
        public static IoPoint T2DO4 = new IoPoint(ApsController, DMC3400, 4, IoModes.Signal,1)
        {
            Name = "T2DO4",
            Description = "安全门动点动作"
        };

        /// <summary>
        ///  1#4#吸笔移动
        /// </summary>
        public static IoPoint T2DO5 = new IoPoint(ApsController, DMC3400, 5, IoModes.Signal,1)
        {
            Name = "T2D05",
            Description = "1#4#吸笔移动"
        };

        /// <summary>
        ///  2#3#吸笔移动
        /// </summary>
        public static IoPoint T2DO6 = new IoPoint(ApsController, DMC3400, 6, IoModes.Signal,1)
        {
            Name = "T2DO6",
            Description = "2#3#吸笔移动"
        };

        /// <summary>
        ///   进料升降气缸（新增）
        /// </summary>
        public static IoPoint T2DO7 = new IoPoint(ApsController, DMC3400, 7, IoModes.Signal,1)
        {
            Name = "T2DO7",
            Description = "进料升降气缸（新增）"
        };

        /// <summary>
        ///  接料夹爪气缸（新增）
        /// </summary>
        public static IoPoint T2DO8 = new IoPoint(ApsController, DMC3400, 8, IoModes.Signal,1)
        {
            Name = "T2DO8",
            Description = "接料夹爪气缸（新增）"
        };

        /// <summary>
        ///  接料升降气缸（新增）
        /// </summary>
        public static IoPoint T2DO9 = new IoPoint(ApsController, DMC3400, 9, IoModes.Signal,1)
        {
            Name = "T2DO9",
            Description = "接料升降气缸（新增）"
        };

        /// <summary>
        ///  接料翻转气缸（新增）
        /// </summary>
        public static IoPoint T2DO10 = new IoPoint(ApsController, DMC3400, 10, IoModes.Signal,1)
        {
            Name = "T2DO10",
            Description = "接料翻转气缸（新增）"
        };

        /// <summary>
        ///  b备用
        /// </summary>
        public static IoPoint T2DO11 = new IoPoint(ApsController, DMC3400, 11, IoModes.Signal,1)
        {
            Name = "T2DO11",
            Description = "b备用"
        };

        /// <summary>
        ///   红灯
        /// </summary>
        public static IoPoint T2DO12 = new IoPoint(ApsController, DMC3400, 12, IoModes.Signal,1)
        {
            Name = "T2DO12",
            Description = "红灯"
        };

        /// <summary>
        ///  黄灯
        /// </summary>
        public static IoPoint T2DO13 = new IoPoint(ApsController, DMC3400, 13, IoModes.Signal,1)
        {
            Name = "T2DO13",
            Description = "黄灯"
        };

        /// <summary>
        ///  绿灯
        /// </summary>
        public static IoPoint T2DO14 = new IoPoint(ApsController, DMC3400, 14, IoModes.Signal,1)
        {
            Name = "T2DO14",
            Description = "绿灯"
        };

        /// <summary>
        ///   蜂鸣器
        /// </summary>
        public static IoPoint T2DO15 = new IoPoint(ApsController, DMC3400, 15, IoModes.Signal,1)
        {
            Name = "T2DO15",
            Description = "蜂鸣器"
        };

        #endregion

        #region EM96DX-C1(1) list

        /// <summary>
        ///   M左卡盘检测信号
        /// </summary>
        public static IoPoint T3DI0 = new IoPoint(ApsController, DMC3400, 0, IoModes.Senser,2)
        {
            Name = "T3DI0",
            Description = "M左卡盘检测信号"
        };

        /// <summary>
        ///   M右卡盘检测信号
        /// </summary>
        public static IoPoint T3DI1 = new IoPoint(ApsController, DMC3400, 1, IoModes.Senser,2)
        {
            Name = "T3DI1",
            Description = "M右卡盘检测信号"
        };

        /// <summary>
        ///   接料夹爪气缸原点（新增）
        /// </summary>
        public static IoPoint T3DI2 = new IoPoint(ApsController, DMC3400, 2, IoModes.Senser,2)
        {
            Name = "T3DI2",
            Description = "接料夹爪气缸原点（新增）"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DI3 = new IoPoint(ApsController, DMC3400, 3, IoModes.Senser,2)
        {
            Name = "T3DI3",
            Description = "备用"
        };

        /// <summary>
        ///   接料升降气缸原点（新增）
        /// </summary>
        public static IoPoint T3DI4 = new IoPoint(ApsController, DMC3400, 4, IoModes.Senser,2)
        {
            Name = "T3DI4",
            Description = "接料升降气缸原点（新增）"
        };

        /// <summary>
        ///   接料升降气缸动点（新增）
        /// </summary>
        public static IoPoint T3DI5 = new IoPoint(ApsController, DMC3400, 5, IoModes.Senser,2)
        {
            Name = "T3DI5",
            Description = "接料升降气缸动点（新增）"
        };

        /// <summary>
        ///   接料翻转气缸原点（新增）
        /// </summary>
        public static IoPoint T3DI6 = new IoPoint(ApsController, DMC3400, 6, IoModes.Senser,2)
        {
            Name = "T3DI6",
            Description = "接料翻转气缸原点（新增）"
        };

        /// <summary>
        ///   接料翻转气缸动点（新增）
        /// </summary>
        public static IoPoint T3DI7 = new IoPoint(ApsController, DMC3400, 7, IoModes.Senser,2)
        {
            Name = "T3DI7",
            Description = "接料翻转气缸动点（新增）"
        };
        /// <summary>
        ///  接料安全感应器（新增）
        /// </summary>
        public static IoPoint T3DI8 = new IoPoint(ApsController, DMC3400, 8, IoModes.Senser,2)
        {
            Name = "T3DI8",
            Description = "接料安全感应器（新增）"
        };
        /// <summary>
        ///   进料升降气缸原点（新增）
        /// </summary>
        public static IoPoint T3DI9 = new IoPoint(ApsController, DMC3400, 9, IoModes.Senser,2)
        {
            Name = "T3DI9",
            Description = "进料升降气缸原点（新增）"
        };
        /// <summary>
        ///   进料升降气缸动点（新增）
        /// </summary>
        public static IoPoint T3DI10 = new IoPoint(ApsController, DMC3400, 10, IoModes.Senser,2)
        {
            Name = "T3DI10",
            Description = "进料升降气缸动点（新增）"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DI11 = new IoPoint(ApsController, DMC3400, 11, IoModes.Senser,2)
        {
            Name = "T3DI11",
            Description = "备用"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DI12 = new IoPoint(ApsController, DMC3400, 12, IoModes.Senser,2)
        {
            Name = "T3DI12",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DI13 = new IoPoint(ApsController, DMC3400, 13, IoModes.Senser,2)
        {
            Name = "T3DI13",
            Description = "备用"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DI14 = new IoPoint(ApsController, DMC3400, 14, IoModes.Senser,2)
        {
            Name = "T3DI14",
            Description = "备用"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DI15 = new IoPoint(ApsController, DMC3400, 15, IoModes.Senser,2)
        {
            Name = "T3DI15",
            Description = "备用"
        };

        /// <summary>
        /// 备用
        /// </summary>
        public static IoPoint T3DO0 = new IoPoint(ApsController, DMC3400, 0, IoModes.Signal,2)
        {
            Name = "T3DO0",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DO1 = new IoPoint(ApsController, DMC3400, 1, IoModes.Signal,2)
        {
            Name = "T3DO1",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DO2 = new IoPoint(ApsController, DMC3400, 2, IoModes.Signal,2)
        {
            Name = "T3DO2",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DO3 = new IoPoint(ApsController, DMC3400, 3, IoModes.Signal,2)
        {
            Name = "T3DO3",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DO4 = new IoPoint(ApsController, DMC3400, 4, IoModes.Signal,2)
        {
            Name = "T3DO4",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T3DO5 = new IoPoint(ApsController, DMC3400, 5, IoModes.Signal,2)
        {
            Name = "T3D05",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T3DO6 = new IoPoint(ApsController, DMC3400, 6, IoModes.Signal,2)
        {
            Name = "T3DO6",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DO7 = new IoPoint(ApsController, DMC3400, 7, IoModes.Signal,2)
        {
            Name = "T3DO7",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T3DO8 = new IoPoint(ApsController, DMC3400, 8, IoModes.Signal,2)
        {
            Name = "T3DO8",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T3DO9 = new IoPoint(ApsController, DMC3400, 9, IoModes.Signal,2)
        {
            Name = "T3DO9",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T3DO10 = new IoPoint(ApsController, DMC3400, 10, IoModes.Signal,2)
        {
            Name = "T3DO10",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T3DO11 = new IoPoint(ApsController, DMC3400, 11, IoModes.Signal,2)
        {
            Name = "T3DO11",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DO12 = new IoPoint(ApsController, DMC3400, 12, IoModes.Signal,2)
        {
            Name = "T3DO12",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T3DO13 = new IoPoint(ApsController, DMC3400, 13, IoModes.Signal,2)
        {
            Name = "T3DO13",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T3DO14 = new IoPoint(ApsController, DMC3400, 14, IoModes.Signal,2)
        {
            Name = "T3DO14",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T3DO15 = new IoPoint(ApsController, DMC3400, 15, IoModes.Signal,2)
        {
            Name = "T3DO15",
            Description = "备用"
        };

        #endregion

        #region  EM96DX-C1(2) list

        /// <summary>
        ///   左取放盘上下原点信号
        /// </summary>
        public static IoPoint T4DI0 = new IoPoint(ApsController, DMC3400, 16, IoModes.Senser,2)
        {
            Name = "T4DI0",
            Description = "左取放盘上下原点信号"
        };

        /// <summary>
        ///   左取放盘上下动点信号
        /// </summary>
        public static IoPoint T4DI1 = new IoPoint(ApsController, DMC3400, 17, IoModes.Senser,2)
        {
            Name = "T4DI1",
            Description = "左取放盘上下动点信号"
        };

        /// <summary>
        ///   右取放盘上下原点信号
        /// </summary>
        public static IoPoint T4DI2 = new IoPoint(ApsController, DMC3400, 18, IoModes.Senser,2)
        {
            Name = "T4DI2",
            Description = "右取放盘上下原点信号"
        };

        /// <summary>
        ///   右取放盘上下动点信号
        /// </summary>
        public static IoPoint T4DI3 = new IoPoint(ApsController, DMC3400, 19, IoModes.Senser,2)
        {
            Name = "T4DI3",
            Description = "右取放盘上下动点信号"
        };

        /// <summary>
        ///   摆盘卡紧原点信号
        /// </summary>
        public static IoPoint T4DI4 = new IoPoint(ApsController, DMC3400, 20, IoModes.Senser,2)
        {
            Name = "T4DI4",
            Description = "摆盘卡紧原点信号"
        };

        /// <summary>
        ///   摆盘卡紧动点信号
        /// </summary>
        public static IoPoint T4DI5 = new IoPoint(ApsController, DMC3400, 21, IoModes.Senser,2)
        {
            Name = "T4DI5",
            Description = "摆盘卡紧动点信号"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DI6 = new IoPoint(ApsController, DMC3400, 22, IoModes.Senser,2)
        {
            Name = "T4DI6",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DI7 = new IoPoint(ApsController, DMC3400, 23, IoModes.Senser,2)
        {
            Name = "T4DI7",
            Description = "备用"
        };
        /// <summary>
        ///   摆盘前感应1#
        /// </summary>
        public static IoPoint T4DI8 = new IoPoint(ApsController, DMC3400, 24, IoModes.Senser,2)
        {
            Name = "T4DI8",
            Description = "摆盘前感应1#"
        };
        /// <summary>
        ///   摆盘前感应2#
        /// </summary>
        public static IoPoint T4DI9 = new IoPoint(ApsController, DMC3400, 25, IoModes.Senser,2)
        {
            Name = "T4DI9",
            Description = "摆盘前感应2#"
        };
        /// <summary>
        ///   摆盘后感应1#
        /// </summary>
        public static IoPoint T4DI10 = new IoPoint(ApsController, DMC3400, 26, IoModes.Senser,2)
        {
            Name = "T4DI10",
            Description = "摆盘后感应1#"
        };
        /// <summary>
        ///   摆盘后感应2#
        /// </summary>
        public static IoPoint T4DI11 = new IoPoint(ApsController, DMC3400, 27, IoModes.Senser,2)
        {
            Name = "T4DI11",
            Description = "摆盘后感应2#"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DI12 = new IoPoint(ApsController, DMC3400, 28, IoModes.Senser,2)
        {
            Name = "T4DI12",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DI13 = new IoPoint(ApsController, DMC3400, 29, IoModes.Senser,2)
        {
            Name = "T4DI13",
            Description = "备用"
        };
        /// <summary>
        ///   仓储自动门原点信号
        /// </summary>
        public static IoPoint T4DI14 = new IoPoint(ApsController, DMC3400, 30, IoModes.Senser,2)
        {
            Name = "T4DI14",
            Description = "仓储自动门原点信号"
        };
        /// <summary>
        ///   仓储自动门动点信号
        /// </summary>
        public static IoPoint T4DI15 = new IoPoint(ApsController, DMC3400, 31, IoModes.Senser,2)
        {
            Name = "T4DI15",
            Description = "仓储自动门动点信号"
        };

        /// <summary>
        /// 备用
        /// </summary>
        public static IoPoint T4DO0 = new IoPoint(ApsController, DMC3400, 16, IoModes.Signal,2)
        {
            Name = "T4DO0",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DO1 = new IoPoint(ApsController, DMC3400, 17, IoModes.Signal,2)
        {
            Name = "T4DO1",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DO2 = new IoPoint(ApsController, DMC3400, 18, IoModes.Signal,2)
        {
            Name = "T4DO2",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DO3 = new IoPoint(ApsController, DMC3400, 19, IoModes.Signal,2)
        {
            Name = "T4DO3",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DO4 = new IoPoint(ApsController, DMC3400, 20, IoModes.Signal,2)
        {
            Name = "T4DO4",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T4D05 = new IoPoint(ApsController, DMC3400, 21, IoModes.Signal,2)
        {
            Name = "T4D05",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T4DO6 = new IoPoint(ApsController, DMC3400, 22, IoModes.Signal,2)
        {
            Name = "T4DO6",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DO7 = new IoPoint(ApsController, DMC3400, 23, IoModes.Signal,2)
        {
            Name = "T4DO7",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T4DO8 = new IoPoint(ApsController, DMC3400, 24, IoModes.Signal,2)
        {
            Name = "T4DO8",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T4DO9 = new IoPoint(ApsController, DMC3400, 25, IoModes.Signal,2)
        {
            Name = "T4DO9",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T4DO10 = new IoPoint(ApsController, DMC3400, 26, IoModes.Signal,2)
        {
            Name = "T4DO10",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T4DO11 = new IoPoint(ApsController, DMC3400, 27, IoModes.Signal,2)
        {
            Name = "T4DO11",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DO12 = new IoPoint(ApsController, DMC3400, 28, IoModes.Signal,2)
        {
            Name = "T4DO12",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T4DO13 = new IoPoint(ApsController, DMC3400, 29, IoModes.Signal,2)
        {
            Name = "T4DO13",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T4DO14 = new IoPoint(ApsController, DMC3400, 30, IoModes.Signal,2)
        {
            Name = "T4DO14",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T4DO15 = new IoPoint(ApsController, DMC3400, 31, IoModes.Signal,2)
        {
            Name = "T4DO15",
            Description = "备用"
        };

        #endregion

        #region  EM96DX-C1(3) list

        /// <summary>
        ///   启动按钮
        /// </summary>
        public static IoPoint T5DI0 = new IoPoint(ApsController, DMC3400, 32, IoModes.Senser,2)
        {
            Name = "T5DI0",
            Description = "启动按钮"
        };

        /// <summary>
        ///   停止按钮
        /// </summary>
        public static IoPoint T5DI1 = new IoPoint(ApsController, DMC3400, 33, IoModes.Senser,2)
        {
            Name = "T5DI1",
            Description = "停止按钮"
        };

        /// <summary>
        ///   急停按钮
        /// </summary>
        public static IoPoint T5DI2 = new IoPoint(ApsController, DMC3400, 34, IoModes.Senser,2)
        {
            Name = "T5DI2",
            Description = "急停按钮"
        };

        /// <summary>
        ///   复位按钮
        /// </summary>
        public static IoPoint T5DI3 = new IoPoint(ApsController, DMC3400, 35, IoModes.Senser,2)
        {
            Name = "T5DI3",
            Description = "复位按钮"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI4 = new IoPoint(ApsController, DMC3400, 36, IoModes.Senser,2)
        {
            Name = "T5DI4",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI5 = new IoPoint(ApsController, DMC3400, 37, IoModes.Senser,2)
        {
            Name = "T5DI5",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI6 = new IoPoint(ApsController, DMC3400, 38, IoModes.Senser,2)
        {
            Name = "T5DI6",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI7 = new IoPoint(ApsController, DMC3400, 39, IoModes.Senser,2)
        {
            Name = "T5DI7",
            Description = "备用"
        };
        /// <summary>
        ///   左门禁信号
        /// </summary>
        public static IoPoint T5DI8 = new IoPoint(ApsController, DMC3400, 40, IoModes.Senser,2)
        {
            Name = "T5DI8",
            Description = "左门禁信号"
        };
        /// <summary>
        ///   右门禁信号
        /// </summary>
        public static IoPoint T5DI9 = new IoPoint(ApsController, DMC3400, 41, IoModes.Senser,2)
        {
            Name = "T5DI9",
            Description = "右门禁信号"
        };
        /// <summary>
        ///   安全光幕
        /// </summary>
        public static IoPoint T5DI10 = new IoPoint(ApsController, DMC3400, 42, IoModes.Senser,2)
        {
            Name = "T5DI10",
            Description = "安全光幕"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI11 = new IoPoint(ApsController, DMC3400, 43, IoModes.Senser,2)
        {
            Name = "T5DI11",
            Description = "备用"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI12 = new IoPoint(ApsController, DMC3400, 44, IoModes.Senser,2)
        {
            Name = "T5DI12",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI13 = new IoPoint(ApsController, DMC3400, 45, IoModes.Senser,2)
        {
            Name = "T5DI13",
            Description = "备用"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI14 = new IoPoint(ApsController, DMC3400, 46, IoModes.Senser,2)
        {
            Name = "T5DI14",
            Description = "备用"
        };
        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DI15 = new IoPoint(ApsController, DMC3400, 47, IoModes.Senser,2)
        {
            Name = "T5DI15",
            Description = "备用"
        };

        /// <summary>
        /// 备用
        /// </summary>
        public static IoPoint T5DO0 = new IoPoint(ApsController, DMC3400, 32, IoModes.Signal,2)
        {
            Name = "T5DO0",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DO1 = new IoPoint(ApsController, DMC3400, 33, IoModes.Signal,2)
        {
            Name = "T5DO1",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DO2 = new IoPoint(ApsController, DMC3400, 34, IoModes.Signal,2)
        {
            Name = "T5DO2",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DO3 = new IoPoint(ApsController, DMC3400, 35, IoModes.Signal,2)
        {
            Name = "T5DO3",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DO4 = new IoPoint(ApsController, DMC3400, 36, IoModes.Signal,2)
        {
            Name = "T5DO4",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T5D05 = new IoPoint(ApsController, DMC3400, 37, IoModes.Signal,2)
        {
            Name = "T5D05",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T5DO6 = new IoPoint(ApsController, DMC3400, 38, IoModes.Signal,2)
        {
            Name = "T5DO6",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DO7 = new IoPoint(ApsController, DMC3400, 39, IoModes.Signal,2)
        {
            Name = "T5DO7",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T5DO8 = new IoPoint(ApsController, DMC3400, 40, IoModes.Signal,2)
        {
            Name = "T5DO8",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T5DO9 = new IoPoint(ApsController, DMC3400, 41, IoModes.Signal,2)
        {
            Name = "T5DO9",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T5DO10 = new IoPoint(ApsController, DMC3400, 42, IoModes.Signal,2)
        {
            Name = "T5DO10",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T5DO11 = new IoPoint(ApsController, DMC3400, 43, IoModes.Signal,2)
        {
            Name = "T5DO11",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DO12 = new IoPoint(ApsController, DMC3400, 44, IoModes.Signal,2)
        {
            Name = "T5DO12",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T5DO13 = new IoPoint(ApsController, DMC3400, 45, IoModes.Signal,2)
        {
            Name = "T5DO13",
            Description = "备用"
        };

        /// <summary>
        ///  备用
        /// </summary>
        public static IoPoint T5DO14 = new IoPoint(ApsController, DMC3400, 46, IoModes.Signal,2)
        {
            Name = "T5DO14",
            Description = "备用"
        };

        /// <summary>
        ///   备用
        /// </summary>
        public static IoPoint T5DO15 = new IoPoint(ApsController, DMC3400, 47, IoModes.Signal,2)
        {
            Name = "T5DO15",
            Description = "备用"
        };

        #endregion
    }
}