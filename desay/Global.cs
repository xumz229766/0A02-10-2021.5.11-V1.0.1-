using System.ToolKit;
using System;
using System.IO;                    //csv 文档使用
using System.Data;                  //使用DataTable类
using System.Tray;
using System.Collections.Generic;
using Motion.Enginee;
namespace desay
{
    public class Global
    {
       
        public const double PI = 3.14159265;
        public const string MACHINNAME = "O_Ring组装设备";
        public static List<Alarm> Alarms = new List<Alarm>();
        public static double BaseHeight;
        public static bool CleanProductDone;
        public static double CycleTime;
        public static bool isErrorExit;
        private static string ProductDataFile
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\" + Config.Instance.CurrentProductType + ".ini");
            }
        }
        public static Tray LensTray = null;
        public static Tray ConeTray = null;

        #region "保存数据xls"
        static string ResportPath= Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resport\\");
        public static string Savexls(string DateAndTime, string Plate, string CellNo, string X, string Y, string R, string Result, string TrayType)
        {
            try
            {
                CreateDir(ResportPath);
                if (File.Exists(ResportPath + DateTime.Now.ToString("yyyy_MM_dd") + ".xls") == false)
                {
                    StreamWriter Save_File = File.CreateText(ResportPath + DateTime.Now.ToString("yyyy_MM_dd") + ".xls");
                    Save_File.Write("DateAndTime" + "\t" + "Plate" + "\t" + "CellNo" + "\t" + "X" + "\t" + "Y" +
                        "\t" + "R" + "\t" + "Result" + "\t" + "TrayType"+"\t\r\n", true);
                    Save_File.Flush();
                    Save_File.Close();
                }
                StreamWriter Save_file = File.AppendText(ResportPath + DateTime.Now.ToString("yyyy_MM_dd") + ".xls");
                Save_file.Write(DateAndTime + "\t" + Plate + "\t" + CellNo + "\t" + X + "\t" + Y + "\t" + R + "\t" + Result + "\t" + TrayType+ "\t\r\n", true);
                Save_file.Flush();
                Save_file.Close();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private static bool CreateDir(string path)
        {
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);
            return true;
        }
        #endregion

    }

    public struct Hole
    {
        /// <summary>
        /// 穴号
        /// </summary>
        public int holeNumber;
        /// <summary>
        /// 角度
        /// </summary>
        public double  angle;
        
       
    }
    public struct Caxis
    {
     
        /// <summary>
        /// 穴数据
        /// </summary>
        public Hole[] holes;
        /// <summary>
        /// 待料角度
        /// </summary>
        public double Startangle;
        /// <summary>
        /// 轴号
        /// </summary>
        public double axisName;
       

    }
}
