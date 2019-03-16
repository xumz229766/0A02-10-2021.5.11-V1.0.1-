using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Motion.LSAps;
using Motion.Enginee;
using Motion.Interfaces;
using log4net;
using System.Threading;
using System.ToolKit;
using System.ToolKit.Helper;
using System.Collections.Generic;
using System.Tray;
using System.IO;
using System.IO.Ports;
using System.Device;
using System.Framework;
using System.Threading.Tasks;

namespace desay
{
    public partial class frmMain : Form
    {
        #region 字段
        //发送者    
        private AlarmType SpliceIsAlarm, BufferIsAlarm, FeederIsAlarm, MoveIsAlarm, LeftCIsAlarm, MiddleCIsAlarm
            , RightCIsAlarm, LeftCut1IsAlarm, LeftCut2IsAlarm, RightCut1IsAlarm, RightCut2IsAlarm,
            PlateformIsAlarm, StoringIsAlarm, MachineIsAlarm;
        private External m_External = new External();
        private MachineOperate MachineOperation;
        private Splice m_Splice;
        private Buffer m_Buffer;
        private Feeder m_Feeder;
        private Move m_Move;
        private LeftC m_LeftC;
        private MiddleC m_MiddleC;
        private RightC m_RightC;
        private LeftCut1 m_LeftCut1;
        private LeftCut2 m_LeftCut2;
        private RightCut1 m_RightCut1;
        private RightCut2 m_RightCut2;
        private Platform m_Platform;
        private Storing m_Storing;
        private bool isExit;
        GTA2 TempGTA2;

        private ManualResetEventSlim closeSafe = new ManualResetEventSlim();
        private LightButton StartButton, StopButton, PauseButton, ResetButton;
        private EventButton EstopButton;
        private LayerLight layerLight;
        private bool ManualAutoMode;
        Thread threadMachineRun = null;
        Thread threadAlarmCheck = null;
        Thread threadStatusCheck = null;
        static ILog log = LogManager.GetLogger(typeof(frmMain));

        public bool uploadEnable = false;
        event Action<string> LoadingMessage;
        event Action<UserLevel> UserLevelChangeEvent;
        uTrayPanel ConeTrayDisplay = null;//托盘显示
        bool TisConnect;
        string LeftPV1, LeftPV2, LeftPV3, LeftPV4;
        string RightPV1, RightPV2, RightPV3, RightPV4;


        #endregion

        #region 托盘显示
        //初始化托盘参数
        private void InitTray()
        {
            Global.LensTray = TrayFactory.GetTrayFactory("大盘");
            Global.ConeTray = TrayFactory.GetTrayFactory("小盘");
            palTary.Controls.Clear();
            palTary.ColumnCount = Global.LensTray.Column;
            for (int i = 0; i < Global.LensTray.Column; i++)
            {
                palTary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }
            palTary.RowCount = Global.LensTray.Row;
            for (int i = 0; i < Global.LensTray.Row; i++)
            {
                palTary.ColumnStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }
            uTrayPanel[] ConeTrayDisplay = new uTrayPanel[Global.LensTray.Column * Global.LensTray.Row];//托盘显示
            if (Global.ConeTray != null)
            {
                for (int i = 0; i < Global.LensTray.Column * Global.LensTray.Row; i++)
                {
                    ConeTrayDisplay[i] = new uTrayPanel();
                    ConeTrayDisplay[i].AutoSize = true;
                    ConeTrayDisplay[i].SetTrayObj(Global.ConeTray, Color.Gray);
                    ConeTrayDisplay[i].Dock = DockStyle.Fill;
                    Global.ConeTray.updateColor += ConeTrayDisplay[i].UpdateColor;
                }
                palTary.Controls.AddRange(ConeTrayDisplay);
            }
        }
        #endregion

        #region 构造函数

        public frmMain()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        #endregion

        #region 用户权限

        void UserLevelChange(UserLevel level)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<UserLevel>(UserLevelChange), level);
            }
            else
            {
                switch (level)
                {
                    case UserLevel.操作员:
                        btnManualOperate.Enabled = true;
                        btnTeach.Enabled = false;
                        btnParameter.Enabled = false;
                        btnConnectionSetting.Enabled = false;
                        btnTraySetting.Enabled = false;
                        break;
                    case UserLevel.工程师:
                        btnManualOperate.Enabled = true;
                        btnTeach.Enabled = true;
                        btnParameter.Enabled = true;
                        btnConnectionSetting.Enabled = true;
                        btnTraySetting.Enabled = true;
                        break;
                    default:
                        btnManualOperate.Enabled = false;
                        btnTeach.Enabled = false;
                        btnParameter.Enabled = false;
                        btnConnectionSetting.Enabled = false;
                        btnTraySetting.Enabled = false;
                        break;
                }
            }
        }
        public void OnUserLevelChange(UserLevel level)
        {
            UserLevelChangeEvent?.Invoke(level);
        }

        #endregion

        #region 窗体加载

        private void frmMain_Load(object sender, EventArgs e)
        {
            UserLevelChangeEvent += UserLevelChange;
            Config.Instance.userLevel = UserLevel.操作员;
            OnUserLevelChange(Config.Instance.userLevel);

            new Thread(new ThreadStart(() =>
            {
                frmStarting loading = new frmStarting(8);
                LoadingMessage += new Action<string>(loading.ShowMessage);
                loading.ShowDialog();
            })).Start();
            Thread.Sleep(500);

            #region  加载板卡

            LoadingMessage("加载板卡信息");
            try
            {
                if (!IoPoints.ApsController.LoadParamFromFile(AppConfig.ConfigCardName))
                { AppendText("配置文件失败"); }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                AppendText("板卡初始化失败！请检查硬件！");
                timer1.Enabled = false;
            }

            #endregion

            #region 轴信息

            LoadingMessage("加载轴控制资源");

            var Xaxis = new ServoAxis(IoPoints.ApsController)
            {
                NoId = 0,
                Transmission = AxisParameter.Instance.XTransParams,
                Name = "X轴"
            };
            var Yaxis = new ServoAxis(IoPoints.ApsController)
            {
                NoId = 1,
                Transmission = AxisParameter.Instance.YTransParams,
                Name = "Y轴"
            };
            var Zaxis = new ServoAxis(IoPoints.ApsController)
            {
                NoId = 2,
                Transmission = AxisParameter.Instance.ZTransParams,
                Name = "Z轴"
            };
            var Maxis = new StepAxis(IoPoints.ApsController)
            {
                NoId = 3,
                Transmission = AxisParameter.Instance.MTransParams,
                Name = "M轴"
            };
            var LeftCutAxis1 = new ServoAxis(IoPoints.ApsController)
            {
                NoId = 4,
                Transmission = AxisParameter.Instance.Cut1TransParams,
                Name = "剪切1#轴"
            };
            var LeftCutAxis2 = new ServoAxis(IoPoints.ApsController)
            {
                NoId = 5,
                Transmission = AxisParameter.Instance.Cut2TransParams,
                Name = "剪切2#轴"
            };

            var LeftCutAxis3 = new ServoAxis(IoPoints.ApsController)
            {
                NoId = 6,
                Transmission = AxisParameter.Instance.Cut3TransParams,
                Name = "剪切3#轴"
            };
            var LeftCutAxis4 = new ServoAxis(IoPoints.ApsController)
            {
                NoId = 7,
                Transmission = AxisParameter.Instance.Cut4TransParams,
                Name = "剪切4#轴"
            };
            var LeftC1Axis = new StepAxis(IoPoints.ApsController)
            {
                NoId = 8,
                Transmission = AxisParameter.Instance.C1TransParams,
                Name = "1#C轴"
            };
            var LeftC2Axis = new StepAxis(IoPoints.ApsController)
            {
                NoId = 9,
                Transmission = AxisParameter.Instance.C2TransParams,
                Name = "2#C轴"
            };
            var LeftC3Axis = new StepAxis(IoPoints.ApsController)
            {
                NoId = 10,
                Transmission = AxisParameter.Instance.C3TransParams,
                Name = "3#C轴"
            };
            var LeftC4Axis = new StepAxis(IoPoints.ApsController)
            {
                NoId = 11,
                Transmission = AxisParameter.Instance.C4TransParams,
                Name = "4#C轴"
            };
            var LoadAxis = new ServoAxis(IoPoints.ApsController)
            {
                NoId = 12,
                Transmission = AxisParameter.Instance.LoadTransParams,
                Name = "上料轴"
            };

            TempGTA2 = new GTA2();
            TempGTA2.Name = "温控器通讯";
            TConnect();
            #endregion

            #region 气缸信息

            LoadingMessage("加载气缸资源");

            var NoRodFeedCylinder = new DoubleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0, IoPoints.T0DO0)
            { Name = "接料无杆气缸" };
            var BufferFrontCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "缓冲前后气缸" };
            var BufferDownCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "缓冲上下气缸" };
            var BufferGripperCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "缓冲夹子气缸" };

            var FeederCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "进料气缸" };

            var MoveLeftCylinder = new SingleCylinder2(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "移料左右气缸" };
            var MoveDownCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "移料上下气缸" };
            var MoveGripperCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "移料夹子气缸" };
            var MoveWasteGripperCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "移料废料夹子气缸" };
            var AirCutFrontCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "气剪前后气缸" };
            var AirCutCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "气剪剪切气缸" };

            var CAxisPush1Cylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "C轴推出1#气缸" };
            var CAxisPush2Cylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "C轴推出2#气缸" };
            var CAxisPush3Cylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "C轴推出3#气缸" };

            var LeftCut1FrontCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "左1#剪切前后气缸" };
            var LeftCut1DownCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "左1#剪切上下气缸" };
            var LeftCut1GripperCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "左1#剪切夹子气缸" };

            var LeftCut2FrontCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "左2#剪切前后气缸" };
            var LeftCut2DownCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "左2#剪切上下气缸" };
            var LeftCut2GripperCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "左2#剪切夹子气缸" };

            var RightCut1FrontCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "右1#剪切前后气缸" };
            var RightCut1DownCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "右1#剪切上下气缸" };
            var RightCut1GripperCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "右1#剪切夹子气缸" };

            var RightCut2FrontCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "右2#剪切前后气缸" };
            var RightCut2DownCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "右2#剪切上下气缸" };
            var RightCut2GripperCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "右2#剪切夹子气缸" };

            var InhaleLeft1Cylinder = new SingleCylinder2(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "吸笔左右1#气缸" };
            var InhaleLeft2Cylinder = new SingleCylinder2(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "吸笔左右2#气缸" };
            var Left1InhaleCylinder = new VacuoBrokenCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "左1#吸笔吸气" };
            var Left2InhaleCylinder = new VacuoBrokenCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "左2#吸笔吸气" };
            var Right1InhaleCylinder = new VacuoBrokenCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "右1#吸笔吸气" };
            var Right2InhaleCylinder = new VacuoBrokenCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "右2#吸笔吸气" };

            var GetTrayCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "取放盘上下气缸" };
            var LockCylinder = new SingleCylinder(IoPoints.T0DI0, IoPoints.T0DI1, IoPoints.T0DO0)
            { Name = "卡紧气缸" };


            #endregion

            #region 工站模组操作

            LoadingMessage("加载模组操作资源");
            var spliceInitialize = new StationInitialize(
                () => { return ManualAutoMode; },
                () => { return SpliceIsAlarm.IsAlarm; });
            var spliceOperate = new StationOperate(
                 () => { return spliceInitialize.InitializeDone; },
                 () => { return SpliceIsAlarm.IsAlarm; });

            var bufferInitialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return BufferIsAlarm.IsAlarm; });
            var bufferOperate = new StationOperate(
                 () => { return bufferInitialize.InitializeDone; },
                 () => { return BufferIsAlarm.IsAlarm; });

            var feederInitialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return FeederIsAlarm.IsAlarm; });
            var feederOperate = new StationOperate(
                 () => { return feederInitialize.InitializeDone; },
                 () => { return FeederIsAlarm.IsAlarm; });

            var moveInitialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return MoveIsAlarm.IsAlarm; });
            var moveOperate = new StationOperate(
                 () => { return moveInitialize.InitializeDone; },
                 () => { return MoveIsAlarm.IsAlarm; });

            var leftcInitialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return LeftCIsAlarm.IsAlarm; });
            var leftcOperate = new StationOperate(
                 () => { return leftcInitialize.InitializeDone; },
                 () => { return LeftCIsAlarm.IsAlarm; });

            var middlecInitialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return MiddleCIsAlarm.IsAlarm; });
            var middlecOperate = new StationOperate(
                 () => { return middlecInitialize.InitializeDone; },
                 () => { return MiddleCIsAlarm.IsAlarm; });

            var rightcInitialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return RightCIsAlarm.IsAlarm; });
            var rightcOperate = new StationOperate(
                 () => { return rightcInitialize.InitializeDone; },
                 () => { return RightCIsAlarm.IsAlarm; });

            var leftcut1Initialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return LeftCut1IsAlarm.IsAlarm; });
            var leftcut1Operate = new StationOperate(
                 () => { return leftcut1Initialize.InitializeDone; },
                 () => { return LeftCut1IsAlarm.IsAlarm; });

            var leftcut2Initialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return LeftCut2IsAlarm.IsAlarm; });
            var leftcut2Operate = new StationOperate(
                 () => { return leftcut2Initialize.InitializeDone; },
                 () => { return LeftCut2IsAlarm.IsAlarm; });

            var rightcut1Initialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return RightCut1IsAlarm.IsAlarm; });
            var rightcut1Operate = new StationOperate(
                 () => { return rightcut1Initialize.InitializeDone; },
                 () => { return RightCut1IsAlarm.IsAlarm; });

            var rightcut2Initialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return RightCut2IsAlarm.IsAlarm; });
            var rightcut2Operate = new StationOperate(
                 () => { return rightcut2Initialize.InitializeDone; },
                 () => { return RightCut2IsAlarm.IsAlarm; });

            var platformInitialize = new StationInitialize(
                  () => { return ManualAutoMode; },
                  () => { return PlateformIsAlarm.IsAlarm; });
            var platformOperate = new StationOperate(
                  () => { return platformInitialize.InitializeDone; },
                  () => { return PlateformIsAlarm.IsAlarm; });

            var storingInitialize = new StationInitialize(
                 () => { return ManualAutoMode; },
                 () => { return StoringIsAlarm.IsAlarm; });
            var storingOperate = new StationOperate(
                 () => { return storingInitialize.InitializeDone; },
                 () => { return StoringIsAlarm.IsAlarm; });
            #endregion


           




            #region 模组信息加载、启动

            LoadingMessage("加载模组信息");
            m_Splice = new Splice(m_External, spliceInitialize, spliceOperate)
            {
                NoRodFeedCylinder = NoRodFeedCylinder
            };
            m_Splice.Run(Motion.Interfaces.RunningModes.Online);


            m_Buffer = new Buffer(m_External, bufferInitialize, bufferOperate)
            {
                FrontCylinder = BufferFrontCylinder,
                DownCylinder = BufferDownCylinder,
                GripperCylinder = BufferGripperCylinder
            };
            m_Buffer.Run(Motion.Interfaces.RunningModes.Online);

            m_Feeder = new Feeder(m_External, feederInitialize, feederOperate)
            {
                FeederCylinder = FeederCylinder,
            };
            m_Feeder.Run(Motion.Interfaces.RunningModes.Online);

            m_Move = new Move(m_External, moveInitialize, moveOperate)
            {
                LeftCylinder = MoveLeftCylinder,
                DownCylinder = MoveDownCylinder,
                GripperCylinder = MoveGripperCylinder,
                WasteGripperCylinder = MoveWasteGripperCylinder,
                AirCutFrontCylinder = AirCutFrontCylinder,
                AirCutCylinder = AirCutCylinder
            };
            m_Move.Run(Motion.Interfaces.RunningModes.Online);

            m_LeftC = new LeftC(m_External, leftcInitialize, leftcOperate)
            {
                CAxis = LeftC1Axis,
                PushCylinder = CAxisPush1Cylinder
            };
            m_LeftC.Run(Motion.Interfaces.RunningModes.Online);

            m_MiddleC = new MiddleC(m_External, middlecInitialize, middlecOperate)
            {
                LeftCAxis = LeftC2Axis,
                RightCAxis = LeftC3Axis,
                PushCylinder = CAxisPush2Cylinder
            };
            m_MiddleC.Run(Motion.Interfaces.RunningModes.Online);

            m_RightC = new RightC(m_External, rightcInitialize, rightcOperate)
            {
                CAxis = LeftC4Axis,
                PushCylinder = CAxisPush3Cylinder,
            };
            m_RightC.Run(Motion.Interfaces.RunningModes.Online);

            m_LeftCut1 = new LeftCut1(m_External, leftcut1Initialize, leftcut1Operate)
            {
                CutAxis = LeftCutAxis1,
                FrontCylinder = LeftCut1FrontCylinder,
                DownCylinder = LeftCut1DownCylinder,
                GripperCylinder = LeftCut1GripperCylinder
            };
            m_LeftCut1.Run(Motion.Interfaces.RunningModes.Online);

            m_LeftCut2 = new LeftCut2(m_External, leftcut2Initialize, leftcut2Operate)
            {
                CutAxis = LeftCutAxis2,
                FrontCylinder = LeftCut2FrontCylinder,
                DownCylinder = LeftCut2DownCylinder,
                GripperCylinder = LeftCut2GripperCylinder
            };
            m_LeftCut2.Run(Motion.Interfaces.RunningModes.Online);

            m_RightCut1 = new RightCut1(m_External, rightcut1Initialize, rightcut1Operate)
            {
                CutAxis = LeftCutAxis3,
                FrontCylinder = RightCut1FrontCylinder,
                DownCylinder = RightCut1DownCylinder,
                GripperCylinder = RightCut1GripperCylinder
            };
            m_RightCut1.Run(Motion.Interfaces.RunningModes.Online);

            m_RightCut2 = new RightCut2(m_External, rightcut2Initialize, rightcut2Operate)
            {
                CutAxis = LeftCutAxis4,
                FrontCylinder = RightCut2FrontCylinder,
                DownCylinder = RightCut2DownCylinder,
                GripperCylinder = RightCut2GripperCylinder
            };
            m_RightCut2.Run(Motion.Interfaces.RunningModes.Online);

            m_Platform = new Platform(m_External, platformInitialize, platformOperate)
            {
                Xaxis = Xaxis,
                Yaxis = Yaxis,
                Zaxis = Zaxis,
                Left1Cylinder = InhaleLeft1Cylinder,
                Left2Cylinder = InhaleLeft2Cylinder,
                Left1InhaleCylinder = Left1InhaleCylinder,
                Left2InhaleCylinder = Left2InhaleCylinder,
                Right1InhaleCylinder = Right1InhaleCylinder,
                Right2InhaleCylinder = Right2InhaleCylinder,
                GetTrayCylinder = GetTrayCylinder,
                LockCylinder = LockCylinder
            };
            m_Platform.Run(Motion.Interfaces.RunningModes.Online);

            m_Storing = new Storing(m_External, storingInitialize, storingOperate)
            {
                MAxis = Maxis
            };
            m_Storing.Run(Motion.Interfaces.RunningModes.Online);

            MachineOperation = new MachineOperate(() =>
            {
                return spliceInitialize.InitializeDone & bufferInitialize.InitializeDone & feederInitialize.InitializeDone
                & moveInitialize.InitializeDone & leftcInitialize.InitializeDone & middlecInitialize.InitializeDone & rightcInitialize.InitializeDone
                & leftcut1Initialize.InitializeDone & leftcut2Initialize.InitializeDone & rightcut1Initialize.InitializeDone & rightcut2Initialize.InitializeDone
                & platformInitialize.InitializeDone & storingInitialize.InitializeDone;
            }, () =>
            {
                return MachineIsAlarm.IsAlarm | SpliceIsAlarm.IsAlarm | BufferIsAlarm.IsAlarm | FeederIsAlarm.IsAlarm
                | MoveIsAlarm.IsAlarm | LeftCIsAlarm.IsAlarm | MiddleCIsAlarm.IsAlarm | RightCIsAlarm.IsAlarm | LeftCut1IsAlarm.IsAlarm
                | LeftCut2IsAlarm.IsAlarm | RightCut1IsAlarm.IsAlarm | RightCut2IsAlarm.IsAlarm | PlateformIsAlarm.IsAlarm | StoringIsAlarm.IsAlarm;
            });

            #endregion

            #region 加载信号灯资源

            StartButton = new LightButton(IoPoints.T5DI0, IoPoints.T3DO0);
            ResetButton = new LightButton(IoPoints.T5DI3, IoPoints.T3DO3);
            PauseButton = new LightButton(IoPoints.T5DI1, IoPoints.T3DO1);
            EstopButton = new EventButton(IoPoints.T5DI2);
            StopButton = new LightButton(IoPoints.T5DI1, IoPoints.T3DO1);

            layerLight = new LayerLight(IoPoints.T2DO14, IoPoints.T2DO13, IoPoints.T2DO12, IoPoints.T2DO15);

            StartButton.Pressed += btnStart_MouseDown;
            StartButton.Released += btnStart_MouseUp;
            PauseButton.Pressed += btnPause_MouseDown;
            PauseButton.Released += btnPause_MouseUp;
            ResetButton.Pressed += btnReset_MouseDown;
            ResetButton.Released += btnReset_MouseUp;

            MachineOperation.StartButton = StartButton;
            MachineOperation.StopButton = StopButton;
            MachineOperation.PauseButton = PauseButton;
            MachineOperation.ResetButton = ResetButton;
            MachineOperation.EstopButton = EstopButton;

            #endregion

            LoadingMessage("加载子窗体资源");
            AddSubForm();

            LoadingMessage("加载线程资源");
            SerialStart();
            InitTray();
        }

        #endregion
        private void TConnect()
        {
            try
            {
                TempGTA2.SetConnectionParam("COM3,9600,None,8,One,1500,1500");
                TempGTA2.DeviceDataReceiveCompelete += new DataReceiveCompleteEventHandler(DealWithReceiveData);
                TempGTA2.DeviceOpen();
                TisConnect = true;
            }
            catch (Exception ex)
            {
                TisConnect = false;
                AppendText(string.Format("上料处读码器连接失败：{0}", ex.Message));
            }
        }
        //温控器获取数据
        bool[] WriteSign = new bool[3];
        void DealWithReceiveData(object sender, string result)
        {
            if (sender.GetType() != typeof(frmMain))
            {
                try
                {
                    if (result.Contains(UniversalFlags.errorStr))
                        throw new Exception(result);
                    string[] results = result.Split(',');
                    if (results.Length != 9)
                    {
                        throw new Exception("结果解析后长度不为8");
                    }
                    if (results[1] == "16")
                    {
                        if (results[3] == "12") WriteSign[0] = true;
                        if (results[3] == "13") WriteSign[1] = true;
                        if (results[3] == "14") WriteSign[2] = true;
                        if (results[3] == "15")
                        {
                            if (WriteSign[0] && WriteSign[1] && WriteSign[2])
                            {
                                WriteSign[0] = false;
                                WriteSign[1] = false;
                                WriteSign[2] = false;
                                AppendText(string.Format("温控器{0}设置成功！", results[0]));
                            }
                            else AppendText(string.Format("温控器{0}设置失败！", results[0]));
                        }
                    }
                    else if (results[1] == "3")
                    {
                        if (results[0] == "1")
                        {
                            if (results[8] == "0")
                            {
                                var data = (byte.Parse(results[3]) << 8) | byte.Parse(results[4]);
                                LeftPV1 = (data / 10.0).ToString("0.0");
                            }
                            if (results[8] == "1")
                            {
                                var data = (byte.Parse(results[3]) << 8) | byte.Parse(results[4]);
                                LeftPV2 = (data / 10.0).ToString("0.0");
                            }
                            if (results[8] == "2")
                            {
                                var data = (byte.Parse(results[3]) << 8) | byte.Parse(results[4]);
                                LeftPV3 = (data / 10.0).ToString("0.0");
                            }
                            if (results[8] == "3")
                            {
                                var data = (byte.Parse(results[3]) << 8) | byte.Parse(results[4]);
                                LeftPV4 = (data / 10.0).ToString("0.0");
                            }
                        }
                        if (results[0] == "2")
                        {
                            if (results[8] == "0")
                            {
                                var data = (byte.Parse(results[3]) << 8) | byte.Parse(results[4]);
                                RightPV1 = (data / 10.0).ToString("0.0");
                            }
                            if (results[8] == "1")
                            {
                                var data = (byte.Parse(results[3]) << 8) | byte.Parse(results[4]);
                                RightPV2 = (data / 10.0).ToString("0.0");
                            }
                            if (results[8] == "2")
                            {
                                var data = (byte.Parse(results[3]) << 8) | byte.Parse(results[4]);
                                RightPV3 = (data / 10.0).ToString("0.0");
                            }
                            if (results[8] == "3")
                            {
                                var data = (byte.Parse(results[3]) << 8) | byte.Parse(results[4]);
                                RightPV4 = (data / 10.0).ToString("0.0");
                            }
                        }
                    }
                    else if (results[1] == "144") AppendText(string.Format("温控器{0}设置失败！", results[0]));
                    else if (results[1] == "131") AppendText(string.Format("温控器{0}读取失败！", results[0]));
                }
                catch (Exception ex)
                {
                    //AppendText("温控器通讯" + ex.Message);
                }
            }
        }

        #region 窗体关闭
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("是否保存配置文件再退出？", "退出", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                SerializerManager<Config>.Instance.Save(AppConfig.ConfigFileName, Config.Instance);
                SerializerManager<Delay>.Instance.Save(AppConfig.ConfigDelayName, Delay.Instance);
                SerializerManager<AxisParameter>.Instance.Save(AppConfig.ConfigAxisName, AxisParameter.Instance);
                TrayFactory.SaveTrayFactory(AppConfig.ConfigTrayName);
                SerializerManager<Position>.Instance.Save(AppConfig.ConfigPositionName, Position.Instance);
                if (!isExit)
                {
                    new Task(() =>
                    {
                        isExit = true;
                        closeSafe.Wait();
                        Invoke(new Action(Close));
                    }).Start();
                    e.Cancel = true;
                }
                log.Debug("配置文件已保存");
            }
            else if (result == DialogResult.No)
            {
                if (!isExit)
                {
                    new Task(() =>
                    {
                        isExit = true;
                        closeSafe.Wait();
                        Invoke(new Action(Close));
                    }).Start();
                    e.Cancel = true;
                }
                log.Debug("配置文件不保存");
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region 窗体切换

        private void btnMain_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tpgMain;
        }

        private void btnManualOperate_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tpgManualOperate;
        }
        private void btnConnectionSetting_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tpgphoto;
        }
        private void btnTeach_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tpgTeach;
        }

        private void btnParameter_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tpgParameter;
        }

        private void btnTraySetting_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tpgTraySetting;
        }

        private void btnIOMonitor_Click(object sender, EventArgs e)
        {
            tbcMain.SelectedTab = tabIOmonitor;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmLogin fm = new frmLogin();
            fm.ShowDialog();
            OnUserLevelChange(Config.Instance.userLevel);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddSubForm()
        {
            GenerateForm(new frmManualOperate(m_Splice,m_Buffer ,m_Feeder,m_Move,m_LeftC
                ,m_MiddleC,m_RightC,m_LeftCut1,m_LeftCut2,m_RightCut1,m_RightCut2,m_Platform,m_Storing), tpgManualOperate);
            GenerateForm(new frmTeach(m_Splice, m_Buffer, m_Feeder, m_Move, m_LeftC
                , m_MiddleC, m_RightC, m_LeftCut1, m_LeftCut2, m_RightCut1, m_RightCut2, m_Platform, m_Storing), tpgTeach);
            GenerateForm(new frmParameter(m_Splice, m_Buffer, m_Feeder, m_Move, m_LeftC
                , m_MiddleC, m_RightC, m_LeftCut1, m_LeftCut2, m_RightCut1, m_RightCut2, m_Platform, m_Storing), tpgParameter);
            GenerateForm(new TestTray(), tpgTraySetting);           
            GenerateForm(new frmIOmonitor(), tabIOmonitor);
        }

        /// <summary>
        /// 在选项卡中生成窗体
        /// </summary>
        private void GenerateForm(Form frm, TabPage sender)
        {
            //设置窗体没有边框 加入到选项卡中  
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Parent = sender;
            frm.ControlBox = false;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        #endregion

        #region 线程处理
        private void SerialStart()
        {
            try
            {
                threadMachineRun = new Thread(MachineRun);
                threadMachineRun.IsBackground = true;
                threadMachineRun.Start();
                new Task(() =>
                {
                    while (!isExit)
                    {
                        Thread.Sleep(10);
                        AlarmCheck();
                    }
                }
                ).Start();


                threadStatusCheck = new Thread(StatusCheck);
                threadStatusCheck.IsBackground = true;
                threadStatusCheck.Start();
                //if (threadStatusCheck.IsAlive) AppendText("状态检查线程运行中...");
            }
            catch (Exception ex)
            {
                AppendText("Server start Error: " + ex.Message);
            }
        }

        private void MachineRun()
        {
            while (true)
            {
                Thread.Sleep(50);
                m_External.AirSignal = !IoPoints.T0DI3.Value;
                m_External.ManualAutoMode = ManualAutoMode;

                MachineOperation.ManualAutoModel = ManualAutoMode;
                MachineOperation.CleanProductDone = Global.CleanProductDone;
                MachineOperation.Run();

                layerLight.Status = MachineOperation.Status;
                layerLight.Refreshing();
                #region
                m_Splice.stationOperate.ManualAutoMode = ManualAutoMode;
                m_Buffer.stationOperate.ManualAutoMode = ManualAutoMode;
                m_Feeder.stationOperate.ManualAutoMode = ManualAutoMode;
                m_Move.stationOperate.ManualAutoMode = ManualAutoMode;
                m_LeftC.stationOperate.ManualAutoMode = ManualAutoMode;
                m_MiddleC.stationOperate.ManualAutoMode = ManualAutoMode;
                m_RightC.stationOperate.ManualAutoMode = ManualAutoMode;
                m_LeftCut1.stationOperate.ManualAutoMode = ManualAutoMode;
                m_LeftCut2.stationOperate.ManualAutoMode = ManualAutoMode;
                m_RightCut1.stationOperate.ManualAutoMode = ManualAutoMode;
                m_RightCut2.stationOperate.ManualAutoMode = ManualAutoMode;
                m_Platform.stationOperate.ManualAutoMode = ManualAutoMode;
                m_Storing.stationOperate.ManualAutoMode = ManualAutoMode;

                m_Splice.stationOperate.AutoRun = MachineOperation.Running;
                m_Buffer.stationOperate.AutoRun = MachineOperation.Running;
                m_Feeder.stationOperate.AutoRun = MachineOperation.Running;
                m_Move.stationOperate.AutoRun = MachineOperation.Running;
                m_LeftC.stationOperate.AutoRun = MachineOperation.Running;
                m_MiddleC.stationOperate.AutoRun = MachineOperation.Running;
                m_RightC.stationOperate.AutoRun = MachineOperation.Running;
                m_LeftCut1.stationOperate.AutoRun = MachineOperation.Running;
                m_LeftCut2.stationOperate.AutoRun = MachineOperation.Running;
                m_RightCut1.stationOperate.AutoRun = MachineOperation.Running;
                m_RightCut2.stationOperate.AutoRun = MachineOperation.Running;
                m_Platform.stationOperate.AutoRun = MachineOperation.Running;
                m_Storing.stationOperate.AutoRun = MachineOperation.Running;


                m_Splice.stationInitialize.Run();
                m_Buffer.stationInitialize.Run();
                m_Move.stationInitialize.Run();
                m_LeftC.stationInitialize.Run();
                m_MiddleC.stationInitialize.Run();
                m_RightC.stationInitialize.Run();
                m_LeftCut1.stationInitialize.Run();
                m_LeftCut2.stationInitialize.Run();
                m_RightCut1.stationInitialize.Run();
                m_RightCut2.stationInitialize.Run();
                m_Platform.stationInitialize.Run();
                m_Storing.stationInitialize.Run();

                m_Splice.stationOperate.Run();
                m_Buffer.stationOperate.Run();
                m_Move.stationOperate.Run();
                m_LeftC.stationOperate.Run();
                m_MiddleC.stationOperate.Run();
                m_RightC.stationOperate.Run();
                m_LeftCut1.stationOperate.Run();
                m_LeftCut2.stationOperate.Run();
                m_RightCut1.stationOperate.Run();
                m_RightCut2.stationOperate.Run();
                m_Platform.stationOperate.Run();
                m_Storing.stationOperate.Run();
                #endregion
             
                if (!EstopButton.PressedIO.Value)
                {
                    m_LeftC.CAxis.Stop();
                    m_MiddleC.LeftCAxis.Stop();
                    m_MiddleC.RightCAxis.Stop();
                    m_RightC.CAxis.Stop();
                    m_LeftCut1.CutAxis.Stop();
                    m_LeftCut2.CutAxis.Stop();
                    m_RightCut1.CutAxis.Stop();
                    m_RightCut2.CutAxis.Stop();
                    m_Platform.Xaxis.Stop();
                    m_Platform.Yaxis.Stop();
                    m_Platform.Zaxis.Stop();
                    m_Storing.MAxis.Stop();

                    m_Splice.stationInitialize.InitializeDone = false;
                    m_Buffer.stationInitialize.InitializeDone = false;
                    m_Move.stationInitialize.InitializeDone = false;
                    m_LeftC.stationInitialize.InitializeDone = false;
                    m_MiddleC.stationInitialize.InitializeDone = false;
                    m_RightC.stationInitialize.InitializeDone = false;
                    m_LeftCut1.stationInitialize.InitializeDone = false;
                    m_LeftCut2.stationInitialize.InitializeDone = false;
                    m_RightCut1.stationInitialize.InitializeDone = false;
                    m_RightCut2.stationInitialize.InitializeDone = false;
                    m_Platform.stationInitialize.InitializeDone = false;
                    m_Storing.stationInitialize.InitializeDone = false;                   
                    MachineOperation.IniliazieDone = false;
                }

                #region 设备复位中
                if (MachineOperation.Resetting)
                {
                    switch (MachineOperation.Flow)
                    {
                        case 0:
                            MachineOperation.IniliazieDone = false;
                            m_External.InitializingDone = false;
                            m_Splice.stationInitialize.InitializeDone = false;
                            m_Buffer.stationInitialize.InitializeDone = false;
                            m_Move.stationInitialize.InitializeDone = false;
                            m_LeftC.stationInitialize.InitializeDone = false;
                            m_MiddleC.stationInitialize.InitializeDone = false;
                            m_RightC.stationInitialize.InitializeDone = false;
                            m_LeftCut1.stationInitialize.InitializeDone = false;
                            m_LeftCut2.stationInitialize.InitializeDone = false;
                            m_RightCut1.stationInitialize.InitializeDone = false;
                            m_RightCut2.stationInitialize.InitializeDone = false;
                            m_Platform.stationInitialize.InitializeDone = false;
                            m_Storing.stationInitialize.InitializeDone = false;
                            if (true) MachineOperation.Flow = 10;
                            break;
                        case 10:
                            m_Plateform.stationInitialize.Start = true;
                            m_Incoming.stationInitialize.Start = true;
                            if (m_Plateform.stationInitialize.Running && m_Incoming.stationInitialize.Running)
                            {
                                MachineOperation.Flow = 20;
                            }
                            break;
                        case 20:
                            if (m_Plateform.stationInitialize.Flow == -1 || m_Incoming.stationInitialize.Flow == -1)
                            {
                                MachineOperation.IniliazieDone = false;
                                MachineOperation.Flow = -1;
                            }
                            else
                            {
                                if (m_Plateform.stationInitialize.InitializeDone && m_Incoming.stationInitialize.InitializeDone)
                                {
                                    MachineOperation.IniliazieDone = true;
                                    MachineOperation.Flow = 30;
                                }
                            }
                            break;
                        default:
                            m_Plateform.stationInitialize.Start = false;
                            m_Incoming.stationInitialize.Start = false;
                            break;
                    }
                }

                #endregion

                #region 设备停止中

                if (MachineOperation.Stopping)
                {
                    m_Splice.stationInitialize.Estop = true;
                    m_Buffer.stationInitialize.Estop = true;
                    m_Move.stationInitialize.Estop = true;
                    m_LeftC.stationInitialize.Estop = true;
                    m_MiddleC.stationInitialize.Estop = true;
                    m_RightC.stationInitialize.Estop = true;
                    m_LeftCut1.stationInitialize.Estop = true;
                    m_LeftCut2.stationInitialize.Estop = true;
                    m_RightCut1.stationInitialize.Estop = true;
                    m_RightCut2.stationInitialize.Estop = true;
                    m_Platform.stationInitialize.Estop = true;
                    m_Storing.stationInitialize.Estop = true;                   
                    if (!m_Splice.stationInitialize.Running && !m_Buffer.stationInitialize.Running
                         && !m_Move.stationInitialize.Running && !m_LeftC.stationInitialize.Running
                          && !m_MiddleC.stationInitialize.Running && !m_RightC.stationInitialize.Running
                           && !m_LeftCut1.stationInitialize.Running && !m_LeftCut2.stationInitialize.Running
                            && !m_RightCut1.stationInitialize.Running && !m_RightCut2.stationInitialize.Running
                             && !m_Platform.stationInitialize.Running && !m_Storing.stationInitialize.Running)
                    {
                        MachineOperation.IniliazieDone = false;
                        MachineOperation.Stopping = false;
                        m_Splice.stationInitialize.Estop = false;
                        m_Buffer.stationInitialize.Estop = false;
                        m_Move.stationInitialize.Estop = false;
                        m_LeftC.stationInitialize.Estop = false;
                        m_MiddleC.stationInitialize.Estop = false;
                        m_RightC.stationInitialize.Estop = false;
                        m_LeftCut1.stationInitialize.Estop = false;
                        m_LeftCut2.stationInitialize.Estop = false;
                        m_RightCut1.stationInitialize.Estop = false;
                        m_RightCut2.stationInitialize.Estop = false;
                        m_Platform.stationInitialize.Estop = false;
                        m_Storing.stationInitialize.Estop = false;
                    }
                }

                #endregion
            }
        }



        private void StatusCheck()
        {
            var list = new List<ICylinderStatusJugger>();
            m_Splice.stationInitialize.Estop = false;
            m_Buffer.stationInitialize.Estop = false;
            m_Move.stationInitialize.Estop = false;
            m_LeftC.stationInitialize.Estop = false;
            m_MiddleC.stationInitialize.Estop = false;
            m_RightC.stationInitialize.Estop = false;
            m_LeftCut1.stationInitialize.Estop = false;
            m_LeftCut2.stationInitialize.Estop = false;
            m_RightCut1.stationInitialize.Estop = false;
            m_RightCut2.stationInitialize.Estop = false;
            m_Platform.stationInitialize.Estop = false;
            m_Storing.stationInitialize.Estop = false;
            list.AddRange(m_Splice.CylinderStatus);
            list.AddRange(m_Splice.CylinderStatus);
            while (true)
            {
                Thread.Sleep(100);
                foreach (var lst in list)
                    lst.StatusJugger();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnOneKeyRunSetting.BackColor = IsAllSetSheild ? Color.Yellow : Color.Transparent;
            lblLeftLens.Text = string.Format("镜筒投入数量 OK:{0} NG:{1} 总数:{2}",
                Config.Instance.ProductOkTotal, Config.Instance.ProductNgTotal, Config.Instance.ProductTotal);
            //lblORing.Text = string.Format("O-Ring统计 OK:{0} 上相机NG:{1} 下相机NG:{2} 吸取NG:{3} 总数:{4}",
              
            lblMachineStatus.Text = MachineOperation.Status.ToString();
            lblMachineStatus.ForeColor = MachineStatusColor(MachineOperation.Status);

           
            btnStopVoice.BackColor = layerLight.VoiceClosed ? Color.LightPink : Color.Transparent;

            layerLight.Status = MachineOperation.Status;
            layerLight.Refreshing();

            //btnStart.Enabled = !MachineOperation.Running;
            btnManualAuto.Enabled = !MachineOperation.Running;
            btnReset.Enabled = !MachineOperation.Running;

            if (ManualAutoMode)
            {
                btnManualOperate.Enabled = false;
                btnTeach.Enabled = false;
                btnTraySetting.Enabled = false;
                btnConnectionSetting.Enabled = false;
                btnParameter.Enabled = false;
            }
            else
            {
                if (Config.Instance.userLevel == UserLevel.操作员 || Config.Instance.userLevel == UserLevel.工程师)
                {
                    btnManualOperate.Enabled = true;
                    if (Config.Instance.userLevel == UserLevel.工程师)
                    {
                        btnTeach.Enabled = true;
                        btnTraySetting.Enabled = true;
                        btnConnectionSetting.Enabled = true;
                        btnParameter.Enabled = true;
                    }
                }
            }
            timer1.Enabled = true;
        }

        #endregion

        #region 消息显示

        /// <summary>
        /// 使用委托方式更新AppendText显示
        /// </summary>
        /// <param name="txt">消息</param>
        public void AppendText(string txt)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendText), txt);
            }
            else
            {
                listBox1.Items.Insert(0, string.Format("{0}-{1}" + Environment.NewLine, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), txt));
                log.Debug(txt);
            }
        }

        public AlarmType AlarmCheck()
        {
            var Alarm = new AlarmType();
            foreach (Alarm alarm in Global.Alarms)
            {
                var btemp = alarm.IsAlarm;
                if (alarm.AlarmLevel == AlarmLevels.Error)
                {
                    Alarm.IsAlarm |= btemp;
                    this.Invoke(new Action(() =>
                    {
                        Msg(string.Format("{0},{1}", alarm.AlarmLevel.ToString(), alarm.Name), btemp);
                    }));
                }
                else if (alarm.AlarmLevel == AlarmLevels.None)
                {
                    Alarm.IsPrompt |= btemp;
                    this.Invoke(new Action(() =>
                    {
                        Msg(string.Format("{0},{1}", alarm.AlarmLevel.ToString(), alarm.Name), btemp);
                    }));
                }
                else
                {
                    Alarm.IsWarning |= btemp;
                    this.Invoke(new Action(() =>
                    {
                        Msg(string.Format("{0},{1}", alarm.AlarmLevel.ToString(), alarm.Name), btemp);
                    }));
                }
            }
            return Alarm;
        }

        private void Msg(string str, bool value)
        {
            string tempstr = null;
            bool sign = false;
            try
            {
                var arrRight = new List<object>();
                foreach (var tmpist in listBox1.Items) arrRight.Add(tmpist);
                if (value)
                {
                    foreach (string tmplist in arrRight)
                    {
                        if (tmplist.IndexOf("-") > -1)
                        {
                            tempstr = tmplist.Substring(tmplist.IndexOf("-") + 1, tmplist.Length - tmplist.IndexOf("-") - 1);
                        }
                        if (tempstr == (str + "\r\n"))
                        {
                            sign = true;
                            break;
                        }
                    }
                    if (!sign)
                    {
                        listBox1.Items.Insert(0, (string.Format("{0}-{1}" + Environment.NewLine, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), str)));
                        log.Debug(str);
                    }
                }
                else
                {
                    foreach (string tmplist in arrRight)
                    {
                        if (tmplist.IndexOf("-") > -1)
                        {
                            tempstr = tmplist.Substring(tmplist.IndexOf("-") + 1, tmplist.Length - tmplist.IndexOf("-") - 1);
                            if (tempstr == (str + "\r\n")) listBox1.Items.Remove(tmplist);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private Color MachineStatusColor(MachineStatus status)
        {
            switch (status)
            {
                case MachineStatus.设备未准备好:
                    return Color.Orange;
                case MachineStatus.设备准备好:
                    return Color.Blue;
                case MachineStatus.设备运行中:
                    return Color.Green;
                case MachineStatus.设备停止中:
                    return Color.Red;
                case MachineStatus.设备暂停中:
                    return Color.Purple;
                case MachineStatus.设备复位中:
                    return Color.OrangeRed;
                case MachineStatus.设备报警中:
                    return Color.Red;
                case MachineStatus.设备急停已按下:
                    return Color.Red;
                default:
                    return Color.Red;
            }
        }
        #endregion

        #region 设备操作按钮

        private void btnStart_MouseDown(object sender, EventArgs e)
        {
            if (!ManualAutoMode)
            {
                AppendText("设备无法启动，必须在自动模式才能操作！");
                return;
            }
            MachineOperation.Start = true;
        }

        private void btnStart_MouseUp(object sender, EventArgs e)
        {
            MachineOperation.Start = false;
        }

        private void btnPause_MouseDown(object sender, EventArgs e)
        {
            MachineOperation.Pause = true;
        }

        private void btnPause_MouseUp(object sender, EventArgs e)
        {
            MachineOperation.Pause = false;
        }

        private void btnStop_MouseDown(object sender, EventArgs e)
        {
            MachineOperation.Stop = true;
        }

        private void btnStop_MouseUp(object sender, EventArgs e)
        {
            MachineOperation.Stop = false;
        }
        private void btnReset_MouseDown(object sender, EventArgs e)
        {
            if (ManualAutoMode)
            {
                if (!MachineIsAlarm.IsAlarm )
                    AppendText("设备手动状态时，才能复位。自动状态只能清除报警！");
                m_External.AlarmReset = true;
            }
            else
            {
                if (MachineOperation != null)
                {
                    MachineOperation.IniliazieDone = false;
                    MachineOperation.Flow = 0;
                    MachineOperation.Reset = true;
                }
            }
        }

        private void btnReset_MouseUp(object sender, EventArgs e)
        {
            MachineOperation.Reset = false;
            m_External.AlarmReset = false;
        }
        private void btnManualAuto_Click(object sender, EventArgs e)
        {
            if (ManualAutoMode && MachineOperation.Running) //自动模式不能直接切换为手动，需要先停止运行再切换模式
            {
                AppendText("设备运行中，不能切换至手动模式!");
                return;
            }
            ManualAutoMode = ManualAutoMode ? false : true;
            btnManualAuto.Text = ManualAutoMode ? "自动模式" : "手动模式";
            btnManualAuto.ForeColor = ManualAutoMode ? Color.Green : Color.Red;
            if (ManualAutoMode) tbcMain.SelectedTab = tpgMain;
        }

        private void lblPlateIndex_Click(object sender, EventArgs e)
        {
            if (MachineOperation.Running)
            {
                AppendText("设备停止或暂停时，才能操作！");
                return;
            }
            new frmRunSetting().ShowDialog();
        }

        bool IsAllSetSheild;

        private void btnOringClean_Click(object sender, EventArgs e)
        {
            if (MachineOperation.Running)
            {
                AppendText("设备停止或暂停时，才能操作！");
                return;
            }
            DialogResult result = MessageBox.Show("是否清除ORing计数？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Config.Instance.ORingOkTotal = 0;
                Config.Instance.ORingUpCameraNgTotal = 0;
                Config.Instance.ORingDownCameraNgTotal = 0;
                Config.Instance.ORingInhaleNgTotal = 0;
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.M:
                    if (ManualAutoMode && MachineOperation.Running) //自动模式不能直接切换为手动，需要先停止运行再切换模式
                    {
                        AppendText("设备运行中，不能切换至手动模式!");
                        return;
                    }
                    ManualAutoMode = ManualAutoMode ? false : true;
                    btnManualAuto.Text = ManualAutoMode ? "自动模式" : "手动模式";
                    btnManualAuto.ForeColor = ManualAutoMode ? Color.Green : Color.Red;
                    if (ManualAutoMode) tbcMain.SelectedTab = tpgMain;
                    break;
            }
        }

        private void btnOneKeyRunSetting_Click(object sender, EventArgs e)
        {
            IsAllSetSheild = IsAllSetSheild ? false : true;
            Marking.inhaleSensorSheild = IsAllSetSheild;
            Marking.traySensorSheild = IsAllSetSheild;
            Marking.repositorySensorSheild = IsAllSetSheild;
            
        }

        private void btnAlarmClean_MouseDown(object sender, MouseEventArgs e)
        {
            m_External.AlarmReset = true;
        }

        private void btnAlarmClean_MouseUp(object sender, MouseEventArgs e)
        {
            m_External.AlarmReset = false;
        }
        private void btnStopVoice_Click(object sender, EventArgs e)
        {
            layerLight.VoiceClosed = !layerLight.VoiceClosed;
        }

        private void btnLeftCountClean_Click(object sender, EventArgs e)
        {
            if (MachineOperation.Running)
            {
                AppendText("设备停止或暂停时，才能操作！");
                return;
            }
            DialogResult result = MessageBox.Show("是否清除产量计数？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Config.Instance.ProductNgTotal = 0;
                Config.Instance.ProductOkTotal = 0;
            }
        }
        #endregion

    }
    public enum MachineAlarm : int
    {
        无消息,
        初始化故障,
    }
}

