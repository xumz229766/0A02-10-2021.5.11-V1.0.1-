using System;
using System.Windows.Forms;
using log4net;
using System.ToolKit;
using System.ToolKit.Helper;
using System.Threading;
using System.Tray;
namespace desay
{
    static class Program
    {

        static ILog log = LogManager.GetLogger(typeof(Program));

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isRunning;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "RunOneInstanceOnly", out isRunning);

            if (isRunning)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(UI_ThreadException);//处理UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);//处理非UI线程异常

                //加载配置文件
                Config.Instance = SerializerManager<Config>.Instance.Load(AppConfig.ConfigFileName);
                Delay.Instance = SerializerManager<Delay>.Instance.Load(AppConfig.ConfigDelayName);
                AxisParameter.Instance= SerializerManager<AxisParameter>.Instance.Load(AppConfig.ConfigAxisName);
                UTrayFactory.Instance= SerializerManager<UTrayFactory>.Instance.Load(AppConfig.ConfigTrayName);
                TrayFactory.LoadTrayFactory(AppConfig.ConfigTrayName);
                Thread.Sleep(200);
                Position.Instance = SerializerManager<Position>.Instance.Load(AppConfig.ConfigPositionName);
                Application.Run(new frmMain());
            }
            else
            {
                MessageBox.Show("程序已经启动！");
            }
        }
        /// <summary>
        /// 处理UI线程异常
        /// </summary>
        static void UI_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Global.isErrorExit = true;
            SerializerManager<Config>.Instance.Save(AppConfig.ConfigFileName,Config.Instance);
            //SerializerManager<Delay>.Instance.Save(AppConfig.ConfigDelayName, Delay.Instance);
            //SerializerManager<AxisParameter>.Instance.Save(AppConfig.ConfigAxisName, AxisParameter.Instance);
            Thread.Sleep(200);
            SerializerManager<Position>.Instance.Save(AppConfig.ConfigPositionName, Position.Instance);
            log.Fatal(e.Exception.Message);
            Application.Exit();
        }
        /// <summary>
        /// 处理非UI线程异常
        /// </summary>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Global.isErrorExit = true;
            SerializerManager<Config>.Instance.Save(AppConfig.ConfigFileName, Config.Instance);
            //SerializerManager<Delay>.Instance.Save(AppConfig.ConfigDelayName, Delay.Instance);
            //SerializerManager<AxisParameter>.Instance.Save(AppConfig.ConfigAxisName, AxisParameter.Instance);
            Thread.Sleep(200);
            SerializerManager<Position>.Instance.Save(AppConfig.ConfigPositionName, Position.Instance);
            log.Fatal(e.ExceptionObject.ToString());
            Application.Exit();
        }
    }
}
