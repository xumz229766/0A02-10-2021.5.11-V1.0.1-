using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace System.ToolKit
{
    public class AppConfig
    {
        public static string ConfigFileName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\Config.xml");
            }
        }
        public static string ConfigCardName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\param.xml");
            }
        }
        public static string ConfigTrayName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\Tray.ini");
            }
        }
        public static string ConfigTrayName1
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\Tray.xml");
            }
        }
        public static string ConfigDelayName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\Delay.xml");
            }
        }
        public static string ConfigAxisName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\AxisParam.xml");
            }
        }
        public static string ConfigPositionName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config\\Position.xml");
            }
        }
        public static string LogFileName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            }
        }
        public static string ProductDataFileName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProductData.ini");
            }
        }
        /// <summary>
        /// 生产信息文件路径
        /// </summary>
        public static string ProdutionInfoFileName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProdutionInfo.ini");
            }
        }
        /// <summary>
        /// MES配置参数文件路径
        /// </summary>
        public static string MESConfigFileName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MESConfig.ini");
            }
        }
        /// <summary>
        /// 本地数据库文件夹路径
        /// </summary>
        public static string dataBaseDirectoryPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DataBase");
            }
        }
        /// <summary>
        /// 本地数据库文件路径
        /// </summary>
        public static string dataBaseFileName
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("{0}.db3", DateTime.Now.ToString("yyyyMMdd")));
            }
        }
    }
}
