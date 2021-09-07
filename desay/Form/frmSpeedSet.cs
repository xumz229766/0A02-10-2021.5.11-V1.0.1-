using System;
using System.Diagnostics;
using System.Drawing;
using System.Enginee;
using System.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.ToolKit;
using System.ToolKit.Helper;
using System.Windows.Forms;

namespace desay
{
    public partial class frmSpeedSet : Form
    {
        private AxisSpeed XaxisSpeedView;
        private AxisSpeed YaxisSpeedView;
        private AxisSpeed ZaxisSpeedView;
        private AxisSpeed C1axisSpeedView;
        private AxisSpeed C2axisSpeedView;
        private AxisSpeed C3axisSpeedView;
        private AxisSpeed C4axisSpeedView;
        private AxisSpeed Push1axisSpeedView;
        private AxisSpeed Push2axisSpeedView;
        private AxisSpeed Push3axisSpeedView;
        private AxisSpeed Push4axisSpeedView;
        private AxisSpeed Cut1axisSpeedView;
        private AxisSpeed Cut2axisSpeedView;
        private AxisSpeed Cut3axisSpeedView;
        private AxisSpeed Cut4axisSpeedView;
        private AxisSpeed MaxisSpeedView;
        /// <summary>
        /// 勾盘慢速
        /// </summary>
        private AxisSpeed SlowaxisSpeedView, SlowExitaxisSpeedView;
        /// <summary>
        /// 剪切慢速
        /// </summary>
        private AxisSpeed SlowCut1axisSpeedView, SlowCut2axisSpeedView, SlowCut3axisSpeedView, SlowCut4axisSpeedView;
        /// <summary>
        /// 摆盘慢速
        /// </summary>
        private AxisSpeed SlowZaxisSpeedView;

        private Splice m_Splice;
        private Buffer m_Buffer;
        private Feeder m_Feeder;
        private Move m_Move;
        private LeftC m_LeftC;
        private LeftCut1 m_LeftCut1;
        private LeftCut2 m_LeftCut2;
        private RightCut1 m_RightCut1;
        private RightCut2 m_RightCut2;
        private Platform m_Platform;
        private Storing m_Storing;


        private void buttonAcc_Click(object sender, EventArgs e)
        {
            new frmSpeed().ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            buttonAcc.Visible = Config.Instance.UserL[10];
            timer1.Enabled = true;
        }

        public frmSpeedSet()
        {
            InitializeComponent();
        }

        public frmSpeedSet(Splice Splice, Buffer Buffer, Feeder Feeder, Move Move, LeftC LeftC,
           LeftCut1 LeftCut1, LeftCut2 LeftCut2, RightCut1 RightCut1, RightCut2 RightCut2, Platform Platform, Storing Storing) : this()
        {
            m_Splice = Splice;
            m_Buffer = Buffer;
            m_Feeder = Feeder;
            m_Move = Move;
            m_LeftC = LeftC;
            m_LeftCut1 = LeftCut1;
            m_LeftCut2 = LeftCut2;
            m_RightCut1 = RightCut1;
            m_RightCut2 = RightCut2;
            m_Platform = Platform;
            m_Storing = Storing;
        }


        private void frmTeach_Load(object sender, EventArgs e)
        {
            buttonAcc.Visible = Config.Instance.UserL[10];

            #region 速度加载
            XaxisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[0].MaxSpeed)
            {
                Name = "X轴运行速度",
                SpeedRate = AxisParameter.Instance.XvelocityRate
            };
            YaxisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[1].MaxSpeed)
            {
                Name = "Y轴运行速度",
                SpeedRate = AxisParameter.Instance.YvelocityRate
            };
            ZaxisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[2].MaxSpeed)
            {
                Name = "Z轴运行速度",
                SpeedRate = AxisParameter.Instance.ZvelocityRate
            };
            C1axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[3].MaxSpeed)
            {
                Name = "C1轴运行速度",
                SpeedRate = AxisParameter.Instance.C1velocityRate
            };
            C2axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[4].MaxSpeed)
            {
                Name = "C2轴运行速度",
                SpeedRate = AxisParameter.Instance.C2velocityRate
            };
            C3axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[5].MaxSpeed)
            {
                Name = "C3轴运行速度",
                SpeedRate = AxisParameter.Instance.C3velocityRate
            };
            C4axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[6].MaxSpeed)
            {
                Name = "C4轴运行速度",
                SpeedRate = AxisParameter.Instance.C4velocityRate
            };
            Push1axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[7].MaxSpeed)
            {
                Name = "P1轴运行速度",
                SpeedRate = AxisParameter.Instance.C1velocityRate
            };
            Push2axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[8].MaxSpeed)
            {
                Name = "P2轴运行速度",
                SpeedRate = AxisParameter.Instance.C2velocityRate
            };
            Push3axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[9].MaxSpeed)
            {
                Name = "P3轴运行速度",
                SpeedRate = AxisParameter.Instance.C3velocityRate
            };
            Push4axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[10].MaxSpeed)
            {
                Name = "P4轴运行速度",
                SpeedRate = AxisParameter.Instance.C4velocityRate
            };
            Cut1axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[11].MaxSpeed)
            {
                Name = "Z1剪切轴运行速度",
                SpeedRate = AxisParameter.Instance.Cut1velocityRate
            };
            Cut2axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[12].MaxSpeed)
            {
                Name = "Z2剪切轴运行速度",
                SpeedRate = AxisParameter.Instance.Cut2velocityRate
            };
            Cut3axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[13].MaxSpeed)
            {
                Name = "Z3剪切轴运行速度",
                SpeedRate = AxisParameter.Instance.Cut3velocityRate
            };
            Cut4axisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[14].MaxSpeed)
            {
                Name = "Z4剪切轴运行速度",
                SpeedRate = AxisParameter.Instance.Cut4velocityRate
            };
            MaxisSpeedView = new AxisSpeed(AxisParameter.Instance.RunSpeed[15].MaxSpeed)
            {
                Name = "M轴运行速度",
                SpeedRate = AxisParameter.Instance.MvelocityRate
            };
            SlowaxisSpeedView = new AxisSpeed(AxisParameter.Instance.SlowvelocityMax)
            {
                Name = "勾盘慢速",
                SpeedRate = AxisParameter.Instance.SlowvelocityRate
            };
            SlowExitaxisSpeedView = new AxisSpeed(AxisParameter.Instance.SlowvelocityMax)
            {
                Name = "退盘慢速",
                SpeedRate = AxisParameter.Instance.SlowveExitlocityRate
            };
            SlowCut1axisSpeedView = new AxisSpeed(AxisParameter.Instance.SlowCutvelocityMax)
            {
                Name = "Z1剪切轴慢速",
                SpeedRate = AxisParameter.Instance.SlowCutvelocityRate1
            };
            SlowCut2axisSpeedView = new AxisSpeed(AxisParameter.Instance.SlowCutvelocityMax)
            {
                Name = "Z2剪切轴慢速",
                SpeedRate = AxisParameter.Instance.SlowCutvelocityRate2
            };
            SlowCut3axisSpeedView = new AxisSpeed(AxisParameter.Instance.SlowCutvelocityMax)
            {
                Name = "Z3剪切轴慢速",
                SpeedRate = AxisParameter.Instance.SlowCutvelocityRate3
            };
            SlowCut4axisSpeedView = new AxisSpeed(AxisParameter.Instance.SlowCutvelocityMax)
            {
                Name = "Z4剪切轴慢速",
                SpeedRate = AxisParameter.Instance.SlowCutvelocityRate4
            };
            SlowZaxisSpeedView = new AxisSpeed(AxisParameter.Instance.SlowZvelocityMax)
            {
                Name = "摆盘慢速",
                SpeedRate = AxisParameter.Instance.SlowZvelocityRate
            };
            flpAxisSpeed.Controls.Clear();
            flpAxisSpeed.Controls.Add(XaxisSpeedView);
            flpAxisSpeed.Controls.Add(YaxisSpeedView);
            flpAxisSpeed.Controls.Add(ZaxisSpeedView);          
            flpAxisSpeed.Controls.Add(C1axisSpeedView);
            flpAxisSpeed.Controls.Add(C2axisSpeedView);
            flpAxisSpeed.Controls.Add(C3axisSpeedView);
            flpAxisSpeed.Controls.Add(C4axisSpeedView);
            flpAxisSpeed.Controls.Add(Push1axisSpeedView);
            flpAxisSpeed.Controls.Add(Push2axisSpeedView);
            flpAxisSpeed.Controls.Add(Push3axisSpeedView);
            flpAxisSpeed.Controls.Add(Push4axisSpeedView);
            flpAxisSpeed.Controls.Add(Cut1axisSpeedView);
            flpAxisSpeed.Controls.Add(Cut2axisSpeedView);
            flpAxisSpeed.Controls.Add(Cut3axisSpeedView);
            flpAxisSpeed.Controls.Add(Cut4axisSpeedView);
            flpAxisSpeed.Controls.Add(MaxisSpeedView);
            flpAxisSpeed.Controls.Add(SlowaxisSpeedView);
            flpAxisSpeed.Controls.Add(SlowExitaxisSpeedView);
            flpAxisSpeed.Controls.Add(SlowCut1axisSpeedView);
            flpAxisSpeed.Controls.Add(SlowCut2axisSpeedView);
            flpAxisSpeed.Controls.Add(SlowCut3axisSpeedView);
            flpAxisSpeed.Controls.Add(SlowCut4axisSpeedView);
            flpAxisSpeed.Controls.Add(SlowZaxisSpeedView);
            #endregion

        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            LogHelper.Info("速度保存");
            AxisParameter.Instance.XvelocityRate = XaxisSpeedView.SpeedRate;
            AxisParameter.Instance.YvelocityRate = YaxisSpeedView.SpeedRate;
            AxisParameter.Instance.ZvelocityRate = ZaxisSpeedView.SpeedRate;          
            AxisParameter.Instance.C1velocityRate = C1axisSpeedView.SpeedRate;
            AxisParameter.Instance.C2velocityRate = C2axisSpeedView.SpeedRate;
            AxisParameter.Instance.C3velocityRate = C3axisSpeedView.SpeedRate;
            AxisParameter.Instance.C4velocityRate = C4axisSpeedView.SpeedRate;
            AxisParameter.Instance.Push1velocityRate = Push1axisSpeedView.SpeedRate;
            AxisParameter.Instance.Push2velocityRate = Push2axisSpeedView.SpeedRate;
            AxisParameter.Instance.Push3velocityRate = Push3axisSpeedView.SpeedRate;
            AxisParameter.Instance.Push4velocityRate = Push4axisSpeedView.SpeedRate;
            AxisParameter.Instance.Cut1velocityRate = Cut1axisSpeedView.SpeedRate;
            AxisParameter.Instance.Cut2velocityRate = Cut2axisSpeedView.SpeedRate;
            AxisParameter.Instance.Cut3velocityRate = Cut3axisSpeedView.SpeedRate;
            AxisParameter.Instance.Cut4velocityRate = Cut4axisSpeedView.SpeedRate;
            AxisParameter.Instance.MvelocityRate = MaxisSpeedView.SpeedRate;
            AxisParameter.Instance.SlowvelocityRate = SlowaxisSpeedView.SpeedRate;
            AxisParameter.Instance.SlowveExitlocityRate = SlowExitaxisSpeedView.SpeedRate;
            AxisParameter.Instance.SlowCutvelocityRate1 = SlowCut1axisSpeedView.SpeedRate;
            AxisParameter.Instance.SlowCutvelocityRate2 = SlowCut2axisSpeedView.SpeedRate;
            AxisParameter.Instance.SlowCutvelocityRate3 = SlowCut3axisSpeedView.SpeedRate;
            AxisParameter.Instance.SlowCutvelocityRate4 = SlowCut4axisSpeedView.SpeedRate;
            AxisParameter.Instance.SlowZvelocityRate = SlowZaxisSpeedView.SpeedRate;
          
            m_Platform.Xaxis.HomeSped = AxisParameter.Instance.XHomeVelocityCurve;
            m_Platform.Yaxis.HomeSped = AxisParameter.Instance.YHomeVelocityCurve;
            m_Platform.Zaxis.HomeSped = AxisParameter.Instance.ZHomeVelocityCurve;
            m_LeftC.C1Axis.HomeSped = AxisParameter.Instance.C1HomeVelocityCurve;
            m_LeftC.C2Axis.HomeSped = AxisParameter.Instance.C2HomeVelocityCurve;
            m_LeftC.C3Axis.HomeSped = AxisParameter.Instance.C3HomeVelocityCurve;
            m_LeftC.C4Axis.HomeSped = AxisParameter.Instance.C4HomeVelocityCurve;
            m_LeftC.Push1Axis.HomeSped = AxisParameter.Instance.Push1HomeVelocityCurve;
            m_LeftC.Push2Axis.HomeSped = AxisParameter.Instance.Push2HomeVelocityCurve;
            m_LeftC.Push3Axis.HomeSped = AxisParameter.Instance.Push3HomeVelocityCurve;
            m_LeftC.Push4Axis.HomeSped = AxisParameter.Instance.Push4HomeVelocityCurve;
            m_LeftCut1.CutAxis.HomeSped = AxisParameter.Instance.Cut1HomeVelocityCurve;
            m_LeftCut2.CutAxis.HomeSped = AxisParameter.Instance.Cut2HomeVelocityCurve;
            m_RightCut1.CutAxis.HomeSped = AxisParameter.Instance.Cut3HomeVelocityCurve;
            m_RightCut2.CutAxis.HomeSped = AxisParameter.Instance.Cut4HomeVelocityCurve;
            m_Storing.MAxis.HomeSped = AxisParameter.Instance.MHomeVelocityCurve;
        
            m_Platform.Xaxis.RunSped = AxisParameter.Instance.XVelocityCurve;
            m_Platform.Yaxis.RunSped = AxisParameter.Instance.YVelocityCurve;
            m_Platform.Zaxis.RunSped = AxisParameter.Instance.ZVelocityCurve;
            m_LeftC.C1Axis.RunSped = AxisParameter.Instance.C1VelocityCurve;
            m_LeftC.C2Axis.RunSped = AxisParameter.Instance.C2VelocityCurve;
            m_LeftC.C3Axis.RunSped = AxisParameter.Instance.C3VelocityCurve;
            m_LeftC.C4Axis.RunSped = AxisParameter.Instance.C4VelocityCurve;
            m_LeftC.Push1Axis.RunSped = AxisParameter.Instance.Push1VelocityCurve;
            m_LeftC.Push2Axis.RunSped = AxisParameter.Instance.Push2VelocityCurve;
            m_LeftC.Push3Axis.RunSped = AxisParameter.Instance.Push3VelocityCurve;
            m_LeftC.Push4Axis.RunSped = AxisParameter.Instance.Push4VelocityCurve;
            m_LeftCut1.CutAxis.RunSped = AxisParameter.Instance.Cut1VelocityCurve;
            m_LeftCut2.CutAxis.RunSped = AxisParameter.Instance.Cut2VelocityCurve;
            m_RightCut1.CutAxis.RunSped = AxisParameter.Instance.Cut3VelocityCurve;
            m_RightCut2.CutAxis.RunSped = AxisParameter.Instance.Cut4VelocityCurve;
            m_Storing.MAxis.RunSped = AxisParameter.Instance.MVelocityCurve;

            Marking.ModifyParameterMarker = true;
        }
    }
}
