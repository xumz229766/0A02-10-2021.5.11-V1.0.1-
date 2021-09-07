using System.Enginee;
using System.Interfaces;
using System.ToolKit;
using System.Windows.Forms;
using System;
using System.Threading;

namespace desay
{
    public partial class CutControlView<T> : UserControl
    {
        private AxisOperate[] m_AxisOperate;
        private ApsAxis[] m_axis;
        private readonly Action m_SaveValue, m_Location, m_CRotate;
        private CylinderOperate[] CylinderOperate;
        public CutControlView()
        {
            InitializeComponent();
        }

        private void CutControlView_Load(object sender, EventArgs e)
        {
            if (CylinderOperate != null)
            { foreach (var Cylinder in CylinderOperate) { flowLayoutPanel2.Controls.Add(Cylinder); } }
            timer1.Enabled = true;
        }
        public T[] Point { get; set; }
        public CutControlView(ApsAxis[] axis, CylinderOperate[] mCylinderOperate, Action SaveValue, Action Location, Action CRotate) : this()
        {
            m_axis = axis;
            m_SaveValue = SaveValue;
            m_Location = Location;
            m_CRotate = CRotate;
            CylinderOperate = mCylinderOperate;
            m_AxisOperate = new AxisOperate[2]
            {
                new AxisOperate(m_axis[0]),
                new AxisOperate(m_axis[1])
            };
            foreach (var tempaxis in m_AxisOperate)
                flpView.Controls.Add(tempaxis);
            LogHelper.Info("剪切保存操作");
        }
        public AxisMoveMode MoveMode
        {
            set
            {
                m_AxisOperate[0].MoveMode = value;
                m_AxisOperate[1].MoveMode = value;
            }
        }

        private void btnTestCut_Click(object sender, EventArgs e)
        {
            m_Location?.Invoke();
            LogHelper.Info("剪切测试操作");
        }

        private void BtnSaveOpenCut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("剪切保存操作");
        }

        private void BtnGotoOpenCut_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lblPointX.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });
        }

        private void BtnGotoBufCut_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lblPointY.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });
        }

        private void BtnGotoCloseCut_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lblPointZ.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });
        }

        private void BtnSaveBufCut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("剪切保存操作");
        }

        private void BtnSaveCloseCut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void BtnCRotate_Click(object sender, EventArgs e)
        {
            m_CRotate?.Invoke();
            LogHelper.Info("C轴旋转");
        }

        private void btnPMove_Click(object sender, EventArgs e)
        {
            LogHelper.Info("P轴前后");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnTestCut.BackColor = AxisParameter.Instance.BtnTestState ? System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor.Control) : System.Drawing.Color.Green;
            btnTestCut.UseVisualStyleBackColor = AxisParameter.Instance.BtnTestState ? true : false;
            timer1.Enabled = true;
        }

        public void Refreshing()
        {
            foreach (var axis in m_AxisOperate) axis.Refreshing();
            lblPointX.Text = ((double)Convert.ChangeType(Point[0], typeof(double))).ToString("0.000");
            lblPointY.Text = ((double)Convert.ChangeType(Point[1], typeof(double))).ToString("0.000");
            lblPointZ.Text = ((double)Convert.ChangeType(Point[2], typeof(double))).ToString("0.000");
            if (CylinderOperate != null)
            {
                foreach (var Cylinder in CylinderOperate)
                {
                    Cylinder.Refreshing();
                }
            }
        }
    }
}
