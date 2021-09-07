using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desay
{
    public partial class frmSpeed : Form
    {
        public frmSpeed()
        {
            InitializeComponent();
        }

        private void Speed_Load(object sender, EventArgs e)
        {
            InitdgvPlatePositionRows();
        }
        String[] CaxisName = new String[] { "Y轴", "X轴", "Z轴", "C1轴", "C2轴", "C3轴", "C4轴", "P1轴", "P2轴", "P3轴", "P4轴", "Z1轴", "Z2轴", "Z3轴", "Z4轴", "M轴", };
        /// <summary>
        /// 刷新整体C轴设置
        /// </summary>
        private void InitdgvPlatePositionRows()
        {
            dgvSpeed.Rows.Clear();
            for (var i = 0; i < AxisParameter.Instance.HomeSpeed.Length; i++)
            {
                dgvSpeed.Rows.Add(new object[] {
                     CaxisName[i],
                    AxisParameter.Instance.HomeSpeed[i].startSpeed.ToString(),
                    AxisParameter.Instance.HomeSpeed[i].add.ToString(),
                    AxisParameter.Instance.HomeSpeed[i].dec.ToString(),
                    AxisParameter.Instance.HomeSpeed[i].MaxSpeed.ToString(),
                    AxisParameter.Instance.RunSpeed[i].startSpeed.ToString(),
                    AxisParameter.Instance.RunSpeed[i].add.ToString(),
                    AxisParameter.Instance.RunSpeed[i].dec.ToString(),
                    AxisParameter.Instance.RunSpeed[i].MaxSpeed.ToString(),
                    "Save"
                });
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            switch (e.ColumnIndex)
            {
                case 9:
                    if (MessageBox.Show(string.Format("是否保存{0}的数据", dgvSpeed.Rows[e.RowIndex].Cells[0].Value),
                        "保存", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        break;
                    }
                    if (dgvSpeed.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Save")
                    {
                        AxisParameter.Instance.HomeSpeed[e.RowIndex].startSpeed= Convert.ToInt32(dgvSpeed.Rows[e.RowIndex].Cells[1].Value);
                        AxisParameter.Instance.HomeSpeed[e.RowIndex].add = Convert.ToInt32(dgvSpeed.Rows[e.RowIndex].Cells[2].Value);
                        AxisParameter.Instance.HomeSpeed[e.RowIndex].dec = Convert.ToInt32(dgvSpeed.Rows[e.RowIndex].Cells[3].Value);
                        AxisParameter.Instance.HomeSpeed[e.RowIndex].MaxSpeed = Convert.ToInt32(dgvSpeed.Rows[e.RowIndex].Cells[4].Value);
                        AxisParameter.Instance.RunSpeed[e.RowIndex].startSpeed = Convert.ToInt32(dgvSpeed.Rows[e.RowIndex].Cells[5].Value);
                        AxisParameter.Instance.RunSpeed[e.RowIndex].add = Convert.ToInt32(dgvSpeed.Rows[e.RowIndex].Cells[6].Value);
                        AxisParameter.Instance.RunSpeed[e.RowIndex].dec = Convert.ToInt32(dgvSpeed.Rows[e.RowIndex].Cells[7].Value);
                        AxisParameter.Instance.RunSpeed[e.RowIndex].MaxSpeed = Convert.ToInt32(dgvSpeed.Rows[e.RowIndex].Cells[8].Value);
                       
                        InitdgvPlatePositionRows();
                    }
                    break;
                default: break;
            }
        }
    }
}
