using System;
using System.Threading;
using System.Windows.Forms;
using System.Enginee;
using System.Interfaces;
using System.ToolKit;
namespace desay
{
    public partial class PushSet<T> : UserControl, IRefreshing
    {
        private AxisOperate[] m_AxisOperate;
        private ApsAxis[] m_axis;
        private CylinderOperate[] CylinderOperate;
      
        private readonly Action m_SaveValue, m_Location;
        public PushSet()
        {
            InitializeComponent();
        }
        public PushSet(ApsAxis[] axis, CylinderOperate[] mCylinderOperate, Action SaveValue, Action Location) : this()
        {
            m_axis = axis;
            m_SaveValue = SaveValue;
            m_Location = Location;
            CylinderOperate = mCylinderOperate;
            m_AxisOperate = new AxisOperate[4]
            {
                new AxisOperate(m_axis[0]),
                new AxisOperate(m_axis[1]),
                new AxisOperate(m_axis[2]),
                new AxisOperate(m_axis[3])
            };

            foreach (var tempaxis in m_AxisOperate)
                flpView.Controls.Add(tempaxis);
        }
        public PushSet(ApsAxis[] axis, Action SaveValue, Action Location) : this()
        {
            m_axis = axis;
            m_SaveValue = SaveValue;
            m_Location = Location;
            m_AxisOperate = new AxisOperate[4]
            {
                new AxisOperate(m_axis[0]),
                new AxisOperate(m_axis[1]),
                new AxisOperate(m_axis[2]),
                new AxisOperate(m_axis[3])              
            };

            foreach (var tempaxis in m_AxisOperate)
                flpView.Controls.Add(tempaxis);
        }

        public PushSet(ApsAxis[] axis, Action SaveValue) : this()
        {
            m_axis = axis;
            m_SaveValue = SaveValue;
            m_AxisOperate = new AxisOperate[4]
            {
                new AxisOperate(m_axis[0]),
                new AxisOperate(m_axis[1]),
                new AxisOperate(m_axis[2]),
                new AxisOperate(m_axis[3])
            };

            foreach (var tempaxis in m_AxisOperate)
                flpView.Controls.Add(tempaxis);

            RefreshPAxisCompensationValue();
        }

        public AxisMoveMode MoveMode
        {
            set
            {
                m_AxisOperate[0].MoveMode = value;
                m_AxisOperate[1].MoveMode = value;
                m_AxisOperate[2].MoveMode = value;
                m_AxisOperate[3].MoveMode = value;
            }
        }
        public T[] Point { get; set; }
        private void PushSet_Load(object sender, EventArgs e)
        {
            if (CylinderOperate != null)
            { foreach (var Cylinder in CylinderOperate) { flowLayoutPanel1.Controls.Add(Cylinder); } }
        }

        private void btnP1GotoOrigin_Click(object sender, EventArgs e)
        {
            m_axis[3].MoveTo(Convert.ToDouble(lblP1OriginPos.Text), new VelocityCurve() { Maxvel = m_axis[3].Speed ?? 0 });
        }

        private void btnP1OriginSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(m_axis[3].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)),
                (T)Convert.ChangeType(Point[4], typeof(T)),
                (T)Convert.ChangeType(Point[5], typeof(T)),
                (T)Convert.ChangeType(Point[6], typeof(T)),
                (T)Convert.ChangeType(Point[7], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("推荐轴1#原点保存操作");
        }

        private void btnP1GotoMove_Click(object sender, EventArgs e)
        {          
            double CPos = 0;
            bool AllSheild = true;
            if (m_axis[7].IsInPosition(Position.Instance.Caxis[0].Startangle))
            {
                m_axis[3].MoveTo(Convert.ToDouble(lblP1MovePos.Text) + Position.Instance.P1HolesOffset[0], new VelocityCurve() { Maxvel = m_axis[3].Speed ?? 0 });
                AllSheild = false;
            }
            else
            {
                for (var i = 0; i < Position.Instance.HoleNumber / 4; i++)
                {
                    CPos = Position.Instance.C1holes[i] + Position.Instance.C1HolesOffset[i];
                    if (m_axis[7].IsInPosition(CPos))
                    {
                        m_axis[3].MoveTo(Convert.ToDouble(lblP1MovePos.Text) + Position.Instance.P1HolesOffset[i], new VelocityCurve() { Maxvel = m_axis[3].Speed ?? 0 });
                        AllSheild = false;
                        break;
                    }
                }
            }
            if (AllSheild)
            {
                m_axis[3].MoveTo(Convert.ToDouble(lblP1MovePos.Text) + Position.Instance.P1HolesOffset[0], new VelocityCurve() { Maxvel = m_axis[3].Speed ?? 0 });
            }
        }

        private void btnP1MoveSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(m_axis[3].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)),
                (T)Convert.ChangeType(Point[4], typeof(T)),
                (T)Convert.ChangeType(Point[5], typeof(T)),
                (T)Convert.ChangeType(Point[6], typeof(T)),
                (T)Convert.ChangeType(Point[7], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("推荐轴1#动点保存操作");
        }

        private void btnP2GotoOrigin_Click(object sender, EventArgs e)
        {
            m_axis[2].MoveTo(Convert.ToDouble(lblP2OriginPos.Text), new VelocityCurve() { Maxvel = m_axis[2].Speed ?? 0 });
        }

        private void btnP2OriginSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(m_axis[2].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)),
                (T)Convert.ChangeType(Point[4], typeof(T)),
                (T)Convert.ChangeType(Point[5], typeof(T)),
                (T)Convert.ChangeType(Point[6], typeof(T)),
                (T)Convert.ChangeType(Point[7], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("推荐轴2#原点保存操作");
        }

        private void btnP2GotoMove_Click(object sender, EventArgs e)
        {
            double CPos = 0;
            bool AllSheild = true;
            if (m_axis[6].IsInPosition(Position.Instance.Caxis[1].Startangle))
            {
                m_axis[2].MoveTo(Convert.ToDouble(lblP2MovePos.Text) + Position.Instance.P2HolesOffset[0], new VelocityCurve() { Maxvel = m_axis[2].Speed ?? 0 });
                AllSheild = false;
            }
            else
            {
                for (var i = 0; i < Position.Instance.HoleNumber / 4; i++)
                {
                    CPos = Position.Instance.C2holes[i] + Position.Instance.C2HolesOffset[i];
                    if (m_axis[6].IsInPosition(CPos))
                    {
                        m_axis[2].MoveTo(Convert.ToDouble(lblP2MovePos.Text) + Position.Instance.P2HolesOffset[i], new VelocityCurve() { Maxvel = m_axis[2].Speed ?? 0 });
                        AllSheild = false;
                        break;
                    }
                }
            }
            if (AllSheild)
            {
                m_axis[2].MoveTo(Convert.ToDouble(lblP2MovePos.Text) + Position.Instance.P2HolesOffset[0], new VelocityCurve() { Maxvel = m_axis[2].Speed ?? 0 });
            }
        }

        private void btnP2MoveSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(m_axis[2].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[4], typeof(T)),
                (T)Convert.ChangeType(Point[5], typeof(T)),
                (T)Convert.ChangeType(Point[6], typeof(T)),
                (T)Convert.ChangeType(Point[7], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("推荐轴2#动点保存操作");
        }

        private void btnP3GotoOrigin_Click(object sender, EventArgs e)
        {
            m_axis[1].MoveTo(Convert.ToDouble(lblP3OriginPos.Text), new VelocityCurve() { Maxvel = m_axis[1].Speed ?? 0 });
        }

        private void btnP3OriginSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)),
                (T)Convert.ChangeType(m_axis[1].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[5], typeof(T)),
                (T)Convert.ChangeType(Point[6], typeof(T)),
                (T)Convert.ChangeType(Point[7], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("推荐轴3#原点保存操作");
        }

        private void btnP3GotoMove_Click(object sender, EventArgs e)
        {
            double CPos = 0;
            bool AllSheild = true;
            if (m_axis[5].IsInPosition(Position.Instance.Caxis[2].Startangle))
            {
                m_axis[1].MoveTo(Convert.ToDouble(lblP3MovePos.Text) + Position.Instance.P3HolesOffset[0], new VelocityCurve() { Maxvel = m_axis[1].Speed ?? 0 });
                AllSheild = false;
            }
            else
            {
                for (var i = 0; i < Position.Instance.HoleNumber / 4; i++)
                {
                    CPos = Position.Instance.C3holes[i] + Position.Instance.C3HolesOffset[i];
                    if (m_axis[5].IsInPosition(CPos))
                    {
                        m_axis[1].MoveTo(Convert.ToDouble(lblP3MovePos.Text) + Position.Instance.P3HolesOffset[i], new VelocityCurve() { Maxvel = m_axis[1].Speed ?? 0 });
                        AllSheild = false;
                        break;
                    }
                }
            }
            if (AllSheild)
            {
                m_axis[1].MoveTo(Convert.ToDouble(lblP3MovePos.Text) + Position.Instance.P3HolesOffset[0], new VelocityCurve() { Maxvel = m_axis[1].Speed ?? 0 });
            }
        }

        private void btnP3MoveSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)),
                (T)Convert.ChangeType(Point[4], typeof(T)),
                (T)Convert.ChangeType(m_axis[1].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[6], typeof(T)),
                (T)Convert.ChangeType(Point[7], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("推荐轴3#动点保存操作");
        }

        private void btnP4GotoOrigin_Click(object sender, EventArgs e)
        {
            m_axis[0].MoveTo(Convert.ToDouble(lblP4OriginPos.Text), new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });
        }


        private void btnP4OriginSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)),
                (T)Convert.ChangeType(Point[4], typeof(T)),
                (T)Convert.ChangeType(Point[5], typeof(T)),
                (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)),
                (T)Convert.ChangeType(Point[7], typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("推荐轴4#原点保存操作");
        }

        private void btnP4GotoMove_Click(object sender, EventArgs e)
        {
            double CPos = 0;
            bool AllSheild = true;
            if(m_axis[4].IsInPosition(Position.Instance.Caxis[3].Startangle))
            {
                m_axis[0].MoveTo(Convert.ToDouble(lblP4MovePos.Text) + Position.Instance.P4HolesOffset[0], new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });
                AllSheild = false;
            }
            else
            {
                for (var i = 0; i < Position.Instance.HoleNumber / 4; i++)
                {
                    CPos = Position.Instance.C4holes[i] + Position.Instance.C4HolesOffset[i];
                    if (m_axis[4].IsInPosition(CPos))
                    {
                        m_axis[0].MoveTo(Convert.ToDouble(lblP4MovePos.Text) + Position.Instance.P4HolesOffset[i], new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });
                        AllSheild = false;
                        break;
                    }
                }
            }
            if(AllSheild)
            {
                m_axis[0].MoveTo(Convert.ToDouble(lblP4MovePos.Text) + Position.Instance.P4HolesOffset[0], new VelocityCurve() { Maxvel = m_axis[0].Speed ?? 0 });
            }
        }

        private void btnP4MoveSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Point = new T[] { (T)Convert.ChangeType(Point[0], typeof(T)),
                (T)Convert.ChangeType(Point[1], typeof(T)),
                (T)Convert.ChangeType(Point[2], typeof(T)),
                (T)Convert.ChangeType(Point[3], typeof(T)),
                (T)Convert.ChangeType(Point[4], typeof(T)),
                (T)Convert.ChangeType(Point[5], typeof(T)),
                (T)Convert.ChangeType(Point[6], typeof(T)),
                (T)Convert.ChangeType(m_axis[0].CurrentPos, typeof(T)) };
            m_SaveValue?.Invoke();
            LogHelper.Info("推荐轴4#动点保存操作");
        }

        public void Refreshing()
        {
            foreach (var axis in m_AxisOperate) axis.Refreshing();
            lblP1OriginPos.Text = ((double)Convert.ChangeType(Point[0], typeof(double))).ToString("0.000");
            lblP1MovePos.Text = ((double)Convert.ChangeType(Point[1], typeof(double))).ToString("0.000");
            lblP2OriginPos.Text = ((double)Convert.ChangeType(Point[2], typeof(double))).ToString("0.000");
            lblP2MovePos.Text = ((double)Convert.ChangeType(Point[3], typeof(double))).ToString("0.000");
            lblP3OriginPos.Text = ((double)Convert.ChangeType(Point[4], typeof(double))).ToString("0.000");
            lblP3MovePos.Text = ((double)Convert.ChangeType(Point[5], typeof(double))).ToString("0.000");
            lblP4OriginPos.Text = ((double)Convert.ChangeType(Point[6], typeof(double))).ToString("0.000");
            lblP4MovePos.Text = ((double)Convert.ChangeType(Point[7], typeof(double))).ToString("0.000");
            if (CylinderOperate != null)
            {
                foreach (var Cylinder in CylinderOperate)
                {
                    Cylinder.Refreshing();
                }
            }
        }

        private void btnSavePAxisCV_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < Position.Instance.HoleNumber / 4; i++)
            {
                Position.Instance.P4HolesOffset[i] = Convert.ToDouble(dGVP4CompensationValue.Rows[i].Cells[1].Value);
                Position.Instance.P3HolesOffset[i] = Convert.ToDouble(dGVP3CompensationValue.Rows[i].Cells[1].Value);
                Position.Instance.P2HolesOffset[i] = Convert.ToDouble(dGVP2CompensationValue.Rows[i].Cells[1].Value);
                Position.Instance.P1HolesOffset[i] = Convert.ToDouble(dGVP1CompensationValue.Rows[i].Cells[1].Value);
            }
            Marking.ModifyParameterMarker = true;
        }

        private void btnRefreshPAxisCV_Click(object sender, EventArgs e)
        {
            RefreshPAxisCompensationValue();
        }

        /// <summary>
        /// 刷新P轴穴位补偿值
        /// </summary>
        private void RefreshPAxisCompensationValue()
        {
            dGVP4CompensationValue.Rows.Clear();
            dGVP3CompensationValue.Rows.Clear();
            dGVP2CompensationValue.Rows.Clear();
            dGVP1CompensationValue.Rows.Clear();     
            for (var i = 0; i < Position.Instance.HoleNumber / 4; i++)
            {
                dGVP4CompensationValue.Rows.Add(new object[] {
                     (i + 1).ToString()+"穴",
                    (Position.Instance.P4HolesOffset[i]).ToString()
                });
                dGVP3CompensationValue.Rows.Add(new object[] {
                     (i + 1).ToString()+"穴",
                    (Position.Instance.P3HolesOffset[i]).ToString()
                });
                dGVP2CompensationValue.Rows.Add(new object[] {
                     (i + 1).ToString()+"穴",
                    (Position.Instance.P2HolesOffset[i]).ToString()
                });
                dGVP1CompensationValue.Rows.Add(new object[] {
                     (i + 1).ToString()+"穴",
                    (Position.Instance.P1HolesOffset[i]).ToString()
                });
            }
        }
    }
}
