using System;
using System.Collections.Generic;
using System.IO;
using Motion.Enginee;
using System.ToolKit;
using System.Tray;
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
        public Caxis[] Caxis;

        /// <summary>
        /// 穴数
        /// </summary>
        public int HoleNumber;


        #endregion



        #region 料仓
        /// <summary>
        /// Y轴取盘位置
        /// </summary>
        public double YGetTrayPosition;
        /// <summary>
        /// Y轴等待位置
        /// </summary>
        public double YWaitPosition;
        /// <summary>
        /// 料仓起始位置
        /// </summary>
        public double MStartPosition;

        /// <summary>
        /// 料仓终点位置
        /// </summary>
        public double MEndPosition;

        public double MDistance
        {
            get { return (MEndPosition - MStartPosition) / 4; }
        }
        public double MTakePosition;
        /// <summary>
        /// 料仓动作距离
        /// </summary>
        public double MLayerDistance;
        /// <summary>
        /// 料仓当前位置索引
        /// </summary>
        public int MLayerIndex;

        #endregion
    }
}
