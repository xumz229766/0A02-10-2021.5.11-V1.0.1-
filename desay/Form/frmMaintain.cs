using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ToolKit;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Tray;
namespace desay
{
    public partial class frmMaintain : Form
    {
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

        private TricolorLampSet m_TricolorLampSet;
        private PasswordChang m_PasswordChang;
        private Jurisdiction m_Jurisdiction;
        private CylinderDelayView m_CylinderDelayView;

        public frmMaintain()
        {
            InitializeComponent();
        }
        public frmMaintain(Splice Splice, Buffer Buffer, Feeder Feeder, Move Move, LeftC LeftC,
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

        private void FrmMaintain_Load(object sender, EventArgs e)
        {
            button5.Visible = Config.Instance.UserL[1];
            button3.Visible = Config.Instance.UserL[12];

            m_TricolorLampSet = new TricolorLampSet();
            m_PasswordChang = new PasswordChang();
            m_Jurisdiction = new Jurisdiction();
            m_CylinderDelayView = new CylinderDelayView(m_Splice, m_Buffer, m_Feeder, m_Move, m_LeftC, m_LeftCut1, m_LeftCut2, m_RightCut1, m_RightCut2, m_Platform, m_Storing);
            m_CylinderDelayView.Dock = DockStyle.Fill;

            timer1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
            button2.BackColor = Color.Gray;
            button3.BackColor = Color.Gray;
            button5.BackColor = Color.Gray;           
            panel1.Controls.Clear();
            panel1.Controls.Add(m_TricolorLampSet);
            LogHelper.Info("三色灯操作");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Green;
            button3.BackColor = Color.Gray;
            button5.BackColor = Color.Gray;          
            panel1.Controls.Clear();
            panel1.Controls.Add(m_PasswordChang);
            LogHelper.Info("密码设定");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button3.BackColor = Color.Green;
            button5.BackColor = Color.Gray;          
            panel1.Controls.Clear();
            panel1.Controls.Add(m_Jurisdiction);
            LogHelper.Info("权限设定操作");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button3.BackColor = Color.Gray;
            button5.BackColor = Color.Green;
            panel1.Controls.Clear();
            panel1.Controls.Add(m_CylinderDelayView);
            LogHelper.Info("气缸延时操作设定");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button5.Visible = Config.Instance.UserL[1];
            button3.Visible = Config.Instance.UserL[12];
            timer1.Enabled = true;         
        }
    }
}
