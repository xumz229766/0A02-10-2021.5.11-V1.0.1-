using System;
using System.Threading;
using System.Windows.Forms;
using System.Enginee;
using System.Interfaces;
using System.ToolKit;

namespace desay
{
    public partial class PackTrayOpenView<T> : UserControl, IRefreshing
    {
        private AxisOperate[] m_AxisOperate;
        private ApsAxis[] m_axis;
        private readonly Action m_SaveValue, m_Location;
        private CylinderOperate[] CylinderOperate;
        public PackTrayOpenView()
        {
            InitializeComponent();
        }

        private void CutControlView_Load(object sender, EventArgs e)
        {
            if (CylinderOperate != null)
            { foreach (var Cylinder in CylinderOperate) { flowLayoutPanel2.Controls.Add(Cylinder); } }
        }
        public T[] Point { get; set; }
        public PackTrayOpenView(ApsAxis[] axis, CylinderOperate[] mCylinderOperate, Action SaveValue, Action Location) : this()
        {
            m_axis = axis;
            m_SaveValue = SaveValue;
            m_Location = Location;
            CylinderOperate = mCylinderOperate;
            m_AxisOperate = new AxisOperate[3]
            {
                new AxisOperate(m_axis[0], m_axis[2]),
                new AxisOperate(m_axis[1], m_axis[2]),
                new AxisOperate(m_axis[2])
            };
            foreach (var tempaxis in m_AxisOperate)
                flpView.Controls.Add(tempaxis);
        }
        public AxisMoveMode MoveMode
        {
            set
            {
                m_AxisOperate[0].MoveMode = value;
                m_AxisOperate[1].MoveMode = value;
                m_AxisOperate[2].MoveMode = value;
            }
        }
    
        private void BtnGoto1GtaryStart_Click_1(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lbl1GtrayStart.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });

        }

        private void BtnSave1GtaryStart_Click_1(object sender, EventArgs e)
        {
            LogHelper.Info("勾盘起点位置1保存操作");
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                 (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void BtnGoto2GtaryStart_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lbl2GtrayStart.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });

        }

        private void BtnSave2GtaryStart_Click(object sender, EventArgs e)
        {
            LogHelper.Info("勾盘起点位置2保存操作");
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                 (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void BtnGoto1GtaryEnd_Click_1(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lbl1GtrayEnd.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });

        }

        private void BtnSave1GtaryEnd_Click_1(object sender, EventArgs e)
        {
            LogHelper.Info("勾盘终点位置1保存操作");
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                 (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void BtnGoto2GtaryEnd_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lbl2GtrayEnd.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });

        }

        private void BtnSave2GtaryEnd_Click(object sender, EventArgs e)
        {
            LogHelper.Info("勾盘终点位置2保存操作");
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                 (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void btnGtaryTest_Click(object sender, EventArgs e)
        {
            LogHelper.Info("勾盘测试");
            m_Location?.Invoke();
        }

        private void PackTrayOpenView_Load(object sender, EventArgs e)
        {
            if (CylinderOperate != null)
            { foreach (var Cylinder in CylinderOperate) { flowLayoutPanel2.Controls.Add(Cylinder); } }
            timer1.Enabled = true;
        }

        private void flpView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnGtaryTest.BackColor = AxisParameter.Instance.BtnTestState ? System.Drawing.Color.LightYellow : System.Drawing.Color.Green;
            timer1.Enabled = true;
        }

        public void Refreshing()
        {
            foreach (var axis in m_AxisOperate) axis.Refreshing();
            lbl1GtrayStart.Text = ((double)Convert.ChangeType(Point[0], typeof(double))).ToString("0.000");
            lbl1GtrayEnd.Text = ((double)Convert.ChangeType(Point[1], typeof(double))).ToString("0.000");
            lbl2GtrayStart.Text = ((double)Convert.ChangeType(Point[2], typeof(double))).ToString("0.000");
            lbl2GtrayEnd.Text = ((double)Convert.ChangeType(Point[3], typeof(double))).ToString("0.000");
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
