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
using System.Tray;

namespace desay
{
    public partial class frmWorkParam : Form
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

        private storingMode m_StoringMode;
        private XYZmode m_XYZmode;
        private CutMode m_CutMode;
        private MirrorBracker m_MirrorBracker;
        private TarySetView m_TarySetView;
        private SpotCheckSet m_SpotCheckSet;
        private TestTray m_TestTray;

        #region 控件



        #endregion

        public frmWorkParam()
        {
            InitializeComponent();
        }

        public frmWorkParam(Splice Splice, Buffer Buffer, Feeder Feeder, Move Move, LeftC LeftC,
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
            button9.Visible = Config.Instance.UserL[8];
            button11.Visible = Config.Instance.UserL[11];

            m_StoringMode = new storingMode();
            m_XYZmode = new XYZmode(IoPoints.ApsController);
            m_CutMode = new CutMode();
            m_MirrorBracker = new MirrorBracker(m_Platform);
            m_TarySetView = new TarySetView();
            m_SpotCheckSet = new SpotCheckSet(IoPoints.ApsController);
            m_TestTray = new TestTray();

            timer1.Enabled = true;
        }
          
        private void BtnStoring_Click(object sender, EventArgs e)
        {
            LogHelper.Info("仓储设定操作");
            btnStoring.BackColor = Color.Green;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Gray;
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Gray;
            panel1.Controls.Clear();
            panel1.Controls.Add(m_StoringMode);
            m_StoringMode.init();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            LogHelper.Info("XYZ设定操作");
            btnStoring.BackColor = Color.Gray;
            button6.BackColor = Color.Green;
            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Gray;
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Gray;
            panel1.Controls.Clear();
            panel1.Controls.Add(m_XYZmode);
            m_XYZmode.init();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            LogHelper.Info("剪切模组设定操作");
            btnStoring.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Green;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Gray;
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Gray;
            panel1.Controls.Clear();
            panel1.Controls.Add(m_CutMode);
            m_CutMode.init();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            LogHelper.Info("镜架模组设定操作");
            btnStoring.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Green;
            button9.BackColor = Color.Gray;
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Gray;
            panel1.Controls.Clear();
            panel1.Controls.Add(m_MirrorBracker);
            m_MirrorBracker.init();
        }

        private void CloseProForm()
        {
            foreach (Control item in this.panel1.Controls)
            {
                if (item is Form)
                {
                    Form objControl = (Form)item;
                    objControl.Close();
                }
            }
        }

        private void OpenForm(Form ojbFrm)
        {
            ojbFrm.TopLevel = false;
            ojbFrm.FormBorderStyle = FormBorderStyle.None;
            ojbFrm.Parent = this.panel1;
            ojbFrm.Dock = DockStyle.Fill;
            ojbFrm.Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            LogHelper.Info("托盘设定操作");
            btnStoring.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Green;
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Gray; 
            panel1.Controls.Clear();
            CloseProForm();
            OpenForm(m_TestTray);
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            LogHelper.Info("剪片摆放设定操作");
            btnStoring.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Gray;
            button10.BackColor = Color.Green;
            button11.BackColor = Color.Gray;
            panel1.Controls.Clear();
            panel1.Controls.Add(m_TarySetView);
            m_TarySetView.init();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            LogHelper.Info("抽检设定操作");
            btnStoring.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Gray;
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Green;
            panel1.Controls.Clear();
            panel1.Controls.Add(m_SpotCheckSet);
            m_SpotCheckSet.init();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!Global.TrayDataRefresh)
            {
                Global.TrayDataRefresh = true;
            }

            LogHelper.Info("刷新显示操作");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            button9.Visible = Config.Instance.UserL[8];
            button11.Visible = Config.Instance.UserL[11];
            timer1.Enabled = true;
        }
    }
}
