using System;
using System.Enginee;
using System.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.ToolKit;
using System.Windows.Forms;
using System.ToolKit.Helper;
namespace desay
{
    public partial class CAxisPositionSet : UserControl, IRefreshing
    {
        private LeftC leftC;
        private AxisOperate[] m_AxisOperate;
        private ApsAxis[] m_axis;
        public CAxisPositionSet()
        {
            InitializeComponent();
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
        public CAxisPositionSet(LeftC mleft) : this()
        {
            leftC = mleft;
            m_axis = new ApsAxis[4] { leftC.C1Axis, leftC.C2Axis, leftC.C3Axis, leftC.C4Axis };
            m_AxisOperate = new AxisOperate[4]
            {
                new AxisOperate(m_axis[3]),
                new AxisOperate(m_axis[2]),
                new AxisOperate(m_axis[1]),
                new AxisOperate(m_axis[0])             
            };
            foreach (var tempaxis in m_AxisOperate)
            {
                flpView.Controls.Add(tempaxis);
            }
            InitdgvPlatePositionRows();
        }

        /// <summary>
        /// 刷新整体C轴设置
        /// </summary>
        public void InitdgvPlatePositionRows()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            Marking.ClearMemory();
            double Pos = 1440 / Position.Instance.HoleNumber;
            int pos1 = Position.Instance.HoleNumber / 4;
            for (var i = 0; i < pos1; i++)
            {
                Position.Instance.C1holes[i] = Pos * i + Position.Instance.Caxis[0].CutStartangle;
                Position.Instance.C2holes[i] = Pos * i + Position.Instance.Caxis[1].CutStartangle;
                Position.Instance.C3holes[i] = Pos * i + Position.Instance.Caxis[2].CutStartangle;
                Position.Instance.C4holes[i] = Pos * i + Position.Instance.Caxis[3].CutStartangle;
                dataGridView4.Rows.Add(new object[] {
                     (i + 1).ToString()+"穴",
                    (Position.Instance.C1holes[i]).ToString(),
                      Position.Instance.C1HolesOffset[i].ToString(),
                         Position.Instance.C1axisSheild[i],
                });
                dataGridView3.Rows.Add(new object[] {
                     (i + 1).ToString()+"穴",
                    (Position.Instance.C2holes[i]).ToString(),
                      Position.Instance.C2HolesOffset[i].ToString(),
                     Position.Instance.C2axisSheild[i],

                });
                dataGridView2.Rows.Add(new object[] {
                     (i + 1).ToString()+"穴",
                    (Position.Instance.C3holes[i]).ToString(),
                      Position.Instance.C3HolesOffset[i].ToString(),
                     Position.Instance.C3axisSheild[i],

                });
                dataGridView1.Rows.Add(new object[] {
                     (i + 1).ToString()+"穴",
                   (Position.Instance.C4holes[i]).ToString(),
                      Position.Instance.C4HolesOffset[i].ToString(),
                     Position.Instance.C4axisSheild[i],

                });
            }
            for (var i = 0; i < 4; i++)
            {
                dataGridView5.Rows.Add(new object[] {
                     "C"+(i + 1).ToString(),
                    Position.Instance.Caxis[i].Startangle.ToString(),
                    "Save",
                    Position.Instance.Caxis[i].CutStartangle.ToString(),
                     "Save",
                    Position.Instance.Caxis[i].IsSheild
                });
            }
        }


        public void Refreshing()
        {
            foreach (var axis in m_AxisOperate)
            {
                axis.Refreshing();
            }
        }

        private void CAxisPositionSet_Load(object sender, EventArgs e)
        {
            InitdgvPlatePositionRows();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int pos1 = Position.Instance.HoleNumber / 4;
            for (var i = 0; i < pos1; i++)
            {
                Position.Instance.C1holes[i] = Convert.ToDouble(dataGridView4.Rows[i].Cells[1].Value);
                Position.Instance.C1axisSheild[i] = Convert.ToBoolean(dataGridView4.Rows[i].Cells[3].Value);
                Position.Instance.C1HolesOffset[i] = Convert.ToDouble(dataGridView4.Rows[i].Cells[2].Value);

                Position.Instance.C2holes[i] = Convert.ToDouble(dataGridView3.Rows[i].Cells[1].Value);
                Position.Instance.C2axisSheild[i] = Convert.ToBoolean(dataGridView3.Rows[i].Cells[3].Value);
                Position.Instance.C2HolesOffset[i] = Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value);

                Position.Instance.C3holes[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);
                Position.Instance.C3axisSheild[i] = Convert.ToBoolean(dataGridView2.Rows[i].Cells[3].Value);
                Position.Instance.C3HolesOffset[i] = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);

                Position.Instance.C4holes[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                Position.Instance.C4axisSheild[i] = Convert.ToBoolean(dataGridView1.Rows[i].Cells[3].Value);
                Position.Instance.C4HolesOffset[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            for (var i = 0; i < 4; i++)
            {
                Position.Instance.Caxis[i].Startangle = Convert.ToDouble(dataGridView5.Rows[i].Cells[1].Value);
                Position.Instance.Caxis[i].CutStartangle = Convert.ToDouble(dataGridView5.Rows[i].Cells[3].Value);
                Position.Instance.Caxis[i].IsSheild = Convert.ToBoolean(dataGridView5.Rows[i].Cells[5].Value);
            }
            if (!Global.TrayDataRefresh)
            {
                Global.TrayDataRefresh = true;
            }

            Marking.ModifyParameterMarker = true;
        }

        private void DataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            switch (e.ColumnIndex)
            {
                case 2:
                    if (MessageBox.Show(string.Format("是否保存{0}的数据", dataGridView5.Rows[e.RowIndex].Cells[0].Value),
                        "保存", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        break;
                    }
                    if (dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Save")
                    {
                        Position.Instance.Caxis[e.RowIndex].Startangle = m_axis[e.RowIndex].CurrentPos;
                        InitdgvPlatePositionRows();
                    }
                    break;
                case 4:
                    if (MessageBox.Show(string.Format("是否保存{0}的数据", dataGridView5.Rows[e.RowIndex].Cells[0].Value),
                        "保存", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        break;
                    }
                    if (dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Save")
                    {
                        Position.Instance.Caxis[e.RowIndex].CutStartangle = m_axis[e.RowIndex].CurrentPos;
                        InitdgvPlatePositionRows();
                    }
                    break;

            }
        }
    }
}
