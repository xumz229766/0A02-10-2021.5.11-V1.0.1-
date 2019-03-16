using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.ToolKit;
using System.Collections.Generic;
namespace desay
{
    [Serializable]
    public class Config
    {
        public static Config Instance = new Config();

        //用户相关信息
        public string userName, AdminPassword= MD5.TextToMd5("321"), OperatePassword= MD5.TextToMd5("123");
        public UserLevel userLevel = UserLevel.None;

        public string IP = "172.0.0.1";
        public int Port = 3306;

        /// <summary>
        ///     当前产品型号
        /// </summary>
        public string CurrentProductType="XV01";

        /// <summary>
        ///     所有产品型号
        /// </summary>
        public List<string> ProductType = new List<string>();

        /// <summary>
        ///     OK产品总数
        /// </summary>
        public int ProductOkTotal;

        /// <summary>
        ///     NG产品总数
        /// </summary>
        public int ProductNgTotal;

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

        public int ORingOkTotal;
        public int ORingUpCameraNgTotal;
        public int ORingDownCameraNgTotal;
        public int ORingInhaleNgTotal;
        public int ORingTotal
        {
            get { return ORingOkTotal + ORingUpCameraNgTotal + ORingDownCameraNgTotal+ ORingInhaleNgTotal; }
        }

        #region 位置

        /// <summary>
        /// 上相机拍照位置
        /// </summary>
        public Point3D<double> UpCameraPosition;

        /// <summary>
        /// 吸料位置
        /// </summary>
        public Point3D<double> InhalePosition;

        /// <summary>
        /// 下相机拍照位置
        /// </summary>
        public Point3D<double> DownCameraPosition;

        /// <summary>
        /// NG料排放位置
        /// </summary>
        public Point3D<double> NGproductPosition;

        /// <summary>
        /// Z轴等待位置
        /// </summary>
        public double ZWaitPosition;

        #endregion
        /// <summary>
        /// 上相机与吸笔的偏差值
        /// </summary>
        public Point<double> UpCameraInhaleOffset;
        /// <summary>
        /// 吸笔中心偏差
        /// </summary>
        public Point<double> InhaleCentreOffset;
        /// <summary>
        /// 上相机检测结果
        /// </summary>
        public CameraResult UpCameraReasult;

        /// <summary>
        /// 下相机检测结果
        /// </summary>
        public CameraResult DownCameraReasult;
    }
}
