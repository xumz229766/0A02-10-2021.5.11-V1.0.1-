using System.Diagnostics;
using System.Device;
using System.Collections.Generic;
using System.ToolKit;

namespace desay
{
    public class Marking
    {
        public static int LeftCcellNum = 1;
        public static int MiddleCcellNum = 1;
        public static int RightCcellNum = 1;
        public static int PlateIndex = 1;
        public static int TrayIndex = 1;
        public static int LayerNum = 1;

        public static int LeftCut1Num;
        public static int LeftCut2Num;
        public static int RightCut1Num;
        public static int RightCut2Num;
        public static bool LeftCut1Done;
        public static bool LeftCut2Done;
        public static bool RightCut1Done;
        public static bool RightCut2Done;


        #region 工作信号
        /// <summary>
        /// 接料完成信号
        /// </summary>
        public static bool NoRodFinish;
        /// <summary>
        /// 缓冲完成信号
        /// </summary>
        public static bool BufferFinish;
        /// <summary>
        /// 进料获得来料
        /// </summary>
        public static bool FeederFinish;
        public static bool FeederReady;
        public static bool FeederHaveProduct;
        /// <summary>
        /// 左移料完成信号
        /// </summary>
        public static bool LeftMoveFinish;
        /// <summary>
        /// 中移料完成信号
        /// </summary>
        public static bool MiddleMoveFinish;
        /// <summary>
        /// 右移料完成信号
        /// </summary>
        public static bool RightMoveFinish;
        public static bool LeftCAxisHaveProduct;
        public static bool MiddleCAxisHaveProduct;
        public static bool RightCAxisHaveProduct;
        /// <summary>
        /// 左1#C轴送料完成信号
        /// </summary>
        public static bool LeftCAxis1Finish;
        /// <summary>
        /// 左2#C轴送料完成信号
        /// </summary>
        public static bool LeftCAxis2Finish;
        /// <summary>
        /// 右1#C轴送料完成信号
        /// </summary>
        public static bool RightCAxis1Finish;
        /// <summary>
        /// 右2#C轴送料完成信号
        /// </summary>
        public static bool RightCAxis2Finish;

        /// <summary>
        /// 左1#剪切轴切料完成
        /// </summary>
        public static bool LeftCut1Finish;
        public static bool LeftCut1HaveProduct;
        /// <summary>
        /// 左2#剪切轴切料完成
        /// </summary>
        public static bool LeftCut2Finish;
        public static bool LeftCut2HaveProduct;
        /// <summary>
        /// 右1#剪切轴切料完成
        /// </summary>
        public static bool RightCut1Finish;
        public static bool RightCut1HaveProduct;
        /// <summary>
        /// 右2#剪切轴切料完成
        /// </summary>
        public static bool RightCut2Finish;
        public static bool RightCut2HaveProduct;
        /// <summary>
        /// 左1#吸笔吸气标记
        /// </summary>
        public static bool XYZLeftInhale1Sign;
        /// <summary>
        /// 左2#吸笔吸气标记
        /// </summary>
        public static bool XYZLeftInhale2Sign;
        /// <summary>
        /// 右1#吸笔吸气标记
        /// </summary>
        public static bool XYZRightInhale1Sign;
        /// <summary>
        /// 右2#吸笔吸气标记
        /// </summary>
        public static bool XYZRightInhale2Sign;
        public static bool ForceInPlate;
        /// <summary>
        /// 仓储移位完成
        /// </summary>
        public static bool StoreFinish;
        public static bool PlateLittle;
        /// <summary>
        /// 取托盘完成
        /// </summary>
        public static bool GetPlateFinish;
        public static bool HavePlateInPlateform;

        #endregion

        #region 防呆信号
        /// <summary>
        /// Y轴移动到安全去以内,在安全区内为false;
        /// </summary>
        public static bool YMoveToNoInSafePostioin;
        /// <summary>
        /// M轴正在移动,不移动为true
        /// </summary>
        public static bool MIsNoMoving;
        #endregion

        #region 模组屏蔽信号
        public static bool SpliceSheild;
        public static bool BufferSheild;
        public static bool FeederSheild;
        public static bool MoveSheild;
        public static bool LeftCSheild;
        public static bool LeftCutSheild;
        public static bool RightCSheild;
        public static bool RightCutSheild;
        public static bool XYZPlateformSheild;
        public static bool StoreSheild;
        #endregion
        #region 屏蔽
        /// <summary>
        ///     料盘感应屏蔽
        /// </summary>
        public static bool traySensorSheild;
        /// <summary>
        ///     料仓感应屏蔽
        /// </summary>
        public static bool repositorySensorSheild;
        /// <summary>
        ///     真空吸屏蔽
        /// </summary>
        public static bool inhaleSensorSheild;
        /// <summary>
        ///     清料信号
        /// </summary>
        public static bool CleanMachineProduct;
     
        #endregion

        public static Stopwatch Singlewatch = new Stopwatch();
        public static Stopwatch Totalwatch = new Stopwatch();
        /// <summary>
        /// C1轴计时器
        /// </summary>
        public static Stopwatch watchCT1 = new Stopwatch();
        /// <summary>
        /// C1轴周期时间
        /// </summary>
        public static double watchCT1Value;
        /// <summary>
        /// C2轴计时器
        /// </summary>
        public static Stopwatch watchCT2 = new Stopwatch();
        /// <summary>
        /// C2轴周期时间
        /// </summary>
        public static double watchCT2Value;
        /// <summary>
        /// C3轴计时器
        /// </summary>
        public static Stopwatch watchCT3 = new Stopwatch();
        /// <summary>
        /// C3轴周期时间
        /// </summary>
        public static double watchCT3Value;
        /// <summary>
        /// C4轴计时器
        /// </summary>
        public static Stopwatch watchCT4 = new Stopwatch();
        /// <summary>
        /// C4轴周期时间
        /// </summary>
        public static double watchCT4Value;
        public static double SingleValue, TotalValue1, TotalValue2, TotalValue3, TotalValue4, TotalValue5;

    }
}
