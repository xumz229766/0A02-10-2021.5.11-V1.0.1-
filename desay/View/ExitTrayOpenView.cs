using System;
using System.Threading;
using System.Windows.Forms;
using System.Enginee;
using System.Interfaces;
using System.ToolKit;

namespace desay
{
    public partial class ExitTrayOpenView<T> : UserControl, IRefreshing
    {
        private AxisOperate[] m_AxisOperate;
        private ApsAxis[] m_axis;
        private readonly Action m_SaveValue, m_Location;
        private CylinderOperate[] CylinderOperate;
        public ExitTrayOpenView()
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
        public ExitTrayOpenView(ApsAxis[] axis, CylinderOperate[] mCylinderOperate, Action SaveValue, Action Location) : this()
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

        private void BtnGoto1ExittaryStart_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lbl1ExittrayStart.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });


        }

        private void BtnSave1ExittaryStart_Click(object sender, EventArgs e)
        {
            LogHelper.Info("退盘起点位置1保存操作");
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                 (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void BtnGoto2ExittaryStart_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lbl2ExittrayStart.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });

        }

        private void BtnSave2ExittaryStart_Click(object sender, EventArgs e)
        {
            LogHelper.Info("退盘起点位置2保存操作");
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                 (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void BtnGoto1ExittaryEnd_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lbl1ExittrayEnd.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });

        }

        private void BtnSave1ExittaryEnd_Click(object sender, EventArgs e)
        {
            LogHelper.Info("退盘终点位置1保存操作");
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                 (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void BtnGoto2ExittaryEnd_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lbl2ExittrayEnd.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });

        }

        private void BtnSave2ExittaryEnd_Click(object sender, EventArgs e)
        {
            LogHelper.Info("退盘终点位置2保存操作");
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                 (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)) };
            m_SaveValue?.Invoke();
        }

        private void btnExittaryTest_Click(object sender, EventArgs e)
        {
            LogHelper.Info("退盘操作");
            m_Location?.Invoke();
        }

        private void ExitTrayOpenView_Load(object sender, EventArgs e)
        {
            if (CylinderOperate != null)
            { foreach (var Cylinder in CylinderOperate) { flowLayoutPanel2.Controls.Add(Cylinder); } }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            btnExittaryTest.BackColor = AxisParameter.Instance.BtnTestState ? System.Drawing.Color.LightYellow : System.Drawing.Color.Green;
            timer1.Enabled = true;
        }

        public void Refreshing()
        {
            foreach (var axis in m_AxisOperate) axis.Refreshing();
            lbl1ExittrayStart.Text = ((double)Convert.ChangeType(Point[0], typeof(double))).ToString("0.000");
            lbl1ExittrayEnd.Text = ((double)Convert.ChangeType(Point[1], typeof(double))).ToString("0.000");
            lbl2ExittrayStart.Text = ((double)Convert.ChangeType(Point[2], typeof(double))).ToString("0.000");
            lbl2ExittrayEnd.Text = ((double)Convert.ChangeType(Point[3], typeof(double))).ToString("0.000");
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
