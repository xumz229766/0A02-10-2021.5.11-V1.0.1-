using System.ToolKit;
using System;
using System.IO;                    //csv 文档使用
using System.Data;                  //使用DataTable类
using System.Tray;
using System.Collections.Generic;
using System.Enginee;
namespace desay
{
    public class Global
    {
        /// <summary>
        /// 机台名称
        /// </summary>
        public const string MACHINNAME = "0A02剪切机";
        /// <summary>
        /// 报警总集合
        /// </summary>
        public static List<Alarm> Alarms = new List<Alarm>();
        /// <summary>
        /// 清料完成状态
        /// </summary>
        public static bool CleanProductDone;
        /// <summary>
        /// 单科产品循环时间
        /// </summary>
        public static double CycleTime;
        /// <summary>
        /// 一盘完成循环时间
        /// </summary>
        public static double EndCycleTime;
        /// <summary>
        /// 是否错误退出
        /// </summary>
        public static bool isErrorExit;
        /// <summary>
        /// 运动轴锁
        /// </summary>
        public static bool IsLocating = false;

        /// <summary>
        /// 大盘
        /// </summary>
        public static Tray BigTray = null;
        /// <summary>
        /// 小盘关系
        /// </summary>
        public static Tray SmallTray = null;
        /// <summary>
        /// 特殊盘关系
        /// </summary>
        public static Tray SpecialTray = null;

        /// <summary>
        /// 点检模式
        /// </summary>
        public static bool CheckModel;
        /// <summary>
        /// 抽检记录小盘放料位
        /// </summary>
        public static int SelectCheckSmallPos;
        /// <summary>
        /// 抽检记录大盘放料位
        /// </summary>
        public static int SelectCheckBigPos;
        /// <summary>
        /// 结束入料
        /// </summary>
        public static bool Endload;
        /// <summary>
        /// 废料模式
        /// </summary>
        public static bool WasteMode;
        /// <summary>
        /// 循环停止
        /// </summary>
        public static bool CyclicStop;
        /// <summary>
        /// 排盘未有盘
        /// </summary>
        public static bool HaveTray;
        /// <summary>
        /// 当前卡盘位置
        /// </summary>
        public static int mViewOperation;
        /// <summary>
        /// 抽检卡盘位置
        /// </summary>
        public static bool mSelectCheckOperation;

        public static uTrayPanel[] LeftConeTrayDisplay;//托盘显示        

     
        /// <summary>
        /// 故障词典
        /// </summary>
        public static Dictionary<string, Fault> FaultDictionary = new Dictionary<string, Fault>();
        /// <summary>
        /// 所有故障记录
        /// </summary>
        public static List<Fault1> AlarmsFault = new List<Fault1>();

        /// <summary>
        /// 回初始状态
        /// </summary>
        public static bool GoOriBool;

        /// <summary>
        /// 温度更新
        /// </summary>
        public static bool WritePulse;
        /// <summary>
        /// 托盘显示刷新
        /// </summary>
        public static bool TrayDataRefresh = false;


        #region "保存数据xls"
        static string ResportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resport\\");
        public static string Savexls(string DateAndTime, string Plate, string CellNo, string X, string Y, string R, string Result, string TrayType)
        {
            try
            {
                CreateDir(ResportPath);
                if (File.Exists(ResportPath + DateTime.Now.ToString("yyyy_MM_dd") + ".xls") == false)
                {
                    StreamWriter Save_File = File.CreateText(ResportPath + DateTime.Now.ToString("yyyy_MM_dd") + ".xls");
                    Save_File.Write("DateAndTime" + "\t" + "Plate" + "\t" + "CellNo" + "\t" + "X" + "\t" + "Y" +
                        "\t" + "R" + "\t" + "Result" + "\t" + "TrayType" + "\t\r\n", true);
                    Save_File.Flush();
                    Save_File.Close();
                }
                StreamWriter Save_file = File.AppendText(ResportPath + DateTime.Now.ToString("yyyy_MM_dd") + ".xls");
                Save_file.Write(DateAndTime + "\t" + Plate + "\t" + CellNo + "\t" + X + "\t" + Y + "\t" + R + "\t" + Result + "\t" + TrayType + "\t\r\n", true);
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

     

}
