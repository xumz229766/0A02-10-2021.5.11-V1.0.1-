using System;
using System.Threading;
using System.Windows.Forms;

using System.Enginee;
using System.Interfaces;
using System.ToolKit;
namespace desay
{
    public partial class Position3DEditView<T> : UserControl, IRefreshing
    {
        private AxisOperate[] m_AxisOperate;
        private ApsAxis[] m_axis;
        private readonly Action m_SaveValue, m_Location;
        private CylinderOperate[] CylinderOperate;       
        public Position3DEditView()
        {
            InitializeComponent();
        }
        public Position3DEditView(ApsAxis[] axis, CylinderOperate[] mCylinderOperate, Action SaveValue, Action Location) : this()
        {
            m_axis = axis;
            m_SaveValue = SaveValue;
            m_Location = Location;
            lblName1.Text = m_axis[0].Name;
            lblName2.Text = m_axis[1].Name;
            lblName3.Text = m_axis[2].Name;
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
        public Position3DEditView(ApsAxis[] axis, Action SaveValue, Action Location) : this()
        {
            m_axis = axis;
            m_SaveValue = SaveValue;
            m_Location = Location;
            lblName1.Text = m_axis[0].Name;
            lblName2.Text = m_axis[1].Name;
            lblName3.Text = m_axis[2].Name;          
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
        public T[] Point { get; set; }
        private void uc3DPointView_Load(object sender, EventArgs e)
        {
            if (CylinderOperate != null)
            { foreach (var Cylinder in CylinderOperate) { flowLayoutPanel1.Controls.Add(Cylinder); } }
        }

        private void cbManualInput_CheckedChanged(object sender, EventArgs e)
        {
            if (cbManualInput.Checked)
            {
                tbPointX.Enabled = true;
                tbPointY.Enabled = true;
                tbPointZ.Enabled = true;
            }
            else
            {
                tbPointX.Enabled = false;
                tbPointY.Enabled = false;
                tbPointZ.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否获取当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            if (cbManualInput.Checked)
            {
                Point[0] = (T)Convert.ChangeType(tbPointX.Text, typeof(T));
                Point[1] = (T)Convert.ChangeType(tbPointY.Text, typeof(T));
                Point[2] = (T)Convert.ChangeType(tbPointZ.Text, typeof(T));
            }
            else
            {
                Point[0] = (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T));
                Point[1] = (T)Convert.ChangeType(m_axis[1].CurrentPos, typeof(T));
                Point[2] = (T)Convert.ChangeType(m_axis[2].CurrentPos, typeof(T));
            }
            m_SaveValue?.Invoke();
        }

        private void btnGoto_Click(object sender, EventArgs e)
        {
            m_Location?.Invoke();
        }

        public void Refreshing()
        {
            foreach (var axis in m_AxisOperate) axis.Refreshing();
            if(!cbManualInput.Checked)
            {
                tbPointX.Text = ((double)Convert.ChangeType(Point[0], typeof(double))).ToString("0.000");
                tbPointY.Text = ((double)Convert.ChangeType(Point[1], typeof(double))).ToString("0.000");
                tbPointZ.Text = ((double)Convert.ChangeType(Point[2], typeof(double))).ToString("0.000");
            }
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
