using System;
using System.ToolKit;
namespace desay
{
    [Serializable]
    public class Position
    {
        /// <summary>
        /// 单例模式
        /// </summary>
        [NonSerialized]
        public static Position Instance = new Position();

        #region 参数设置       

        /// <summary>
        /// 轴数据
        /// </summary>
        public Caxis[] Caxis = new Caxis[4];

        /// <summary>
        /// 穴数
        /// </summary>
        public int HoleNumber = 1;

        /// <summary>
        /// 穴数据
        /// </summary>
        public double[] C1holes = new double[32];
        /// <summary>
        /// 穴数据
        /// </summary>
        public double[] C2holes = new double[32];
        /// <summary>
        /// 穴数据
        /// </summary>
        public double[] C3holes = new double[32];
        /// <summary>
        /// 穴数据
        /// </summary>
        public double[] C4holes = new double[32];
        /// <summary>
        /// C1穴偏移数据
        /// </summary>
        public double[] C1HolesOffset = new double[32];
        /// <summary>
        /// C2穴偏移数据
        /// </summary>
        public double[] C2HolesOffset = new double[32];
        /// <summary>
        /// C3穴偏移数据
        /// </summary>
        public double[] C3HolesOffset = new double[32];
        /// <summary>
        /// C4穴偏移数据
        /// </summary>
        public double[] C4HolesOffset = new double[32];
        /// <summary>
        /// C轴是否屏蔽
        /// </summary>
        public bool[] C1axisSheild = new bool[32];
        /// <summary>
        /// C轴是否屏蔽
        /// </summary>
        public bool[] C2axisSheild = new bool[32];
        /// <summary>
        /// C轴是否屏蔽
        /// </summary>
        public bool[] C3axisSheild = new bool[32];
        /// <summary>
        /// C轴是否屏蔽
        /// </summary>
        public bool[] C4axisSheild = new bool[32];
        /// <summary>
        /// 勾盘原位
        /// </summary>
        public Point3D<double>[] PosGTrayOriPosition = new Point3D<double>[2];
        /// <summary>
        /// 勾盘动作位
        /// </summary>
        public Point3D<double>[] PosGTrayMovePosition = new Point3D<double>[2];
        /// <summary>
        /// 退盘原位
        /// </summary>
        public Point3D<double>[] PosExitTrayOriPosition = new Point3D<double>[2];
        /// <summary>
        /// 退盘原位
        /// </summary>
        public Point3D<double>[] PosExitTrayMovePosition = new Point3D<double>[2];
        /// <summary>
        /// 预剪切位置
        /// </summary>
        public Pos<double>[] PosCut = new Pos<double>[4];
        /// <summary>
        /// 剪切位置
        /// </summary>
        public double[] PosCutEnd = new double[4];
        /// <summary>
        /// <summary>
        /// 推进位置
        /// </summary>
        public Pos<double>[] PosPush = new Pos<double>[4];
        /// <summary>
        /// 开机废模设定数量
        /// </summary>
        public int ModelCountSet;
        /// <summary>
        /// 换盘废模设定数量
        /// </summary>
        public int ChangeTrayLayout;
        /// <summary>
        /// Z轴安全位置
        /// </summary>
        public Point3D<double> ZsafePosition;

        /// <summary>
        /// 抽检位置
        /// </summary>
        public Point3D<double> SelectCheckPosition;

        /// <summary>
        /// 取产品位置
        /// </summary>
        public Point3D<double> GetProductPosition;
        /// <summary>
        /// 取产品安全高度
        /// </summary>
        public double GetSafetyZ;
        /// <summary>
        /// 摆产品第一个位置
        /// </summary>
        public Point3D<double> PuchProductPosition;
        /// <summary>
        /// 摆产品安全高度
        /// </summary>
        public double PuchSafetyZ;
        /// <summary>
        /// C轴回拉角度
        /// </summary>
        public double[] cAxisPullBackPos = new double[4];
        /// <summary>
        /// C轴是否回拉
        /// </summary>
        public bool IscAxisPullBack;

        /// <summary>
        /// 排盘便宜值
        /// </summary>
        public Point3D<double>[] trayOffces = new Point3D<double>[32];

        /// <summary>
        /// 翻转开启
        /// </summary>
        public bool[] OverturnOpen = new bool[]{false, false, false, false};
        /// <summary>
        /// 抽检模数
        /// </summary>
        public int SelectCheckModulus;
        /// <summary>
        /// Z减速时间
        /// </summary>
        public double ZxiasUp;
        /// <summary>
        /// 托盘定位次数
        /// </summary>
        public double numTrayPositon;
        /// <summary>
        /// 碎料模式
        /// </summary>
        public int FragmentationMode;
        /// <summary>
        /// 电机碎料开关
        /// </summary>
        public bool CheckMotorStart;
        /// <summary>
        /// 电机过载屏蔽
        /// </summary>
        public bool CheckOverload;
        /// <summary>
        /// C轴原点旋转
        /// </summary>
        public bool CAxisOrgRotate;
        /// <summary>
        /// Z通知剪切高度
        /// </summary>
        public double ZInformHeight;
        /// <summary>
        /// Y摆盘避让距离
        /// </summary>
        public double YAvoidDistance;

        /// <summary>
        /// P1穴补偿值
        /// </summary>
        public double[] P1HolesOffset = new double[32];
        /// <summary>
        /// P2穴补偿值
        /// </summary>
        public double[] P2HolesOffset = new double[32];
        /// <summary>
        /// P3穴补偿值
        /// </summary>
        public double[] P3HolesOffset = new double[32];
        /// <summary>
        /// P4穴补偿值
        /// </summary>
        public double[] P4HolesOffset = new double[32];

        #endregion

        #region 料仓
        /// <summary>
        /// 料仓起始位置
        /// </summary>
        public double MStartPosition;

        /// <summary>
        /// 料仓格数
        /// </summary>
        public int MLayerCount = 1;

        /// <summary>
        /// 料仓格子间距
        /// </summary>
        public double MDistance;

        /// <summary>
        /// 料仓当前位置索引
        /// </summary>
        public int MLayerIndex = 0;

        /// <summary>
        /// 料仓待机位
        /// </summary>
        public double MStandbyPosition;

        /// <summary>
        /// 料仓待机位开启
        /// </summary>
        public bool MStandbyPositionOpen;

        public int[] MLayerFillCount = new int[8];

        #endregion
    }
}
