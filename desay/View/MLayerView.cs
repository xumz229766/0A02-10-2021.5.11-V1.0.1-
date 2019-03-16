using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Motion.Interfaces;
using Motion.Enginee;

namespace desay
{
    public partial class MLayerView<T> : UserControl, IRefreshing
    {
        private AxisOperate m_AxisOperate;
        private ApsAxis m_axis;
        private double startMLayerActionPosition, endMLayerActionPosition;
        //private double average, pos;
        public MLayerView()
        {
            InitializeComponent();
        }

        public MLayerView(ApsAxis maxis) : this()
        {
            m_axis = maxis;

            m_AxisOperate = new AxisOperate(m_axis);
            tableLayoutPanel1.Controls.Add(m_AxisOperate, 1, 0);

        }

        public AxisMoveMode MoveMode
        {
            set
            {
                m_AxisOperate.MoveMode = value;
            }
        }

        private void MLayerView_Load(object sender, EventArgs e)
        {

            //txtMLayerCount.Text = Position.Instance.MLayerCount.ToString();

            ndnMIndex.Minimum = 0;
            ndnMIndex.Maximum = 5;
            ndnMlayerDistance.Value = (decimal)Position.Instance.MLayerDistance;
        }

        public void Refreshing()
        {
            lblMLayerStartPosition.Text = Position.Instance.MStartPosition.ToString("0000.000");
            lblMLayerEndPosition.Text = Position.Instance.MEndPosition.ToString("0000.000");           
            lblMLayerTakePosition.Text = Position.Instance.MTakePosition.ToString("0000.000");
            m_AxisOperate.Refreshing();
        }

        private void btnMLayerStartPosition_Click(object sender, EventArgs e)
        {
            if (m_axis.IsAlarmed || m_axis.IsEmg || !m_axis.IsServon) return;            
            m_axis.MoveTo(Position.Instance.MStartPosition, new VelocityCurve(0, m_axis.Speed ?? 0, 0));
        }

        private void btnMLayerEndPosition_Click(object sender, EventArgs e)
        {
            if (m_axis.IsAlarmed || m_axis.IsEmg || !m_axis.IsServon) return;
            m_axis.MoveTo(Position.Instance.MEndPosition, new VelocityCurve(0, m_axis.Speed ?? 0, 0));
        }

        private void btnMLayerTakePosition_Click(object sender, EventArgs e)
        {
            if (m_axis.IsAlarmed || m_axis.IsEmg || !m_axis.IsServon) return;
            m_axis.MoveTo(Position.Instance.MTakePosition, new VelocityCurve(0, m_axis.Speed ?? 0, 0));
        }

        private void btnbtnMLayerStartPositionGet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Position.Instance.MStartPosition = m_axis.CurrentPos;
        }

        private void MLayerEndPositionGet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Position.Instance.MEndPosition = m_axis.CurrentPos;
        }
        private void btnMLayerTakePositionGet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否保存当前位置数据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No) return;
            Position.Instance.MTakePosition = m_axis.CurrentPos;
        }
        private void ndnMlayerDistance_ValueChanged(object sender, EventArgs e)
        {
            Position.Instance.MLayerDistance = (double)ndnMlayerDistance.Value;
        }

        private void btnMLayerCurrentIndex_Click(object sender, EventArgs e)
        {
            if (m_axis.IsAlarmed || m_axis.IsEmg || !m_axis.IsServon) return;
            var MLpos = Position.Instance.MStartPosition + Position.Instance.MDistance * ((int)ndnMIndex.Value - 1);
            var MMpos = MLpos + Position.Instance.MLayerDistance;
            m_axis.MoveTo(MLpos, new VelocityCurve(0, m_axis.Speed ?? 0, 0));
        }

        private void btnMLayerActionDistance_Click(object sender, EventArgs e)
        {
            if (m_axis.IsAlarmed || m_axis.IsEmg || !m_axis.IsServon) return;
            var MLpos = Position.Instance.MStartPosition + Position.Instance.MDistance * ((int)ndnMIndex.Value-1);
            var MMpos = MLpos + Position.Instance.MLayerDistance;
            m_axis.MoveTo(MMpos, new VelocityCurve(0, m_axis.Speed ?? 0, 0));
        }
    }
}
