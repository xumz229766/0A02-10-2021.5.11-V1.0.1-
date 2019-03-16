using System;
using System.Drawing;
using System.Windows.Forms;
using Motion.LSAps;
using Motion.Interfaces;
using System.ToolKit;
using Motion.Enginee;
using System.Tray;
using System.Threading;
using System.Threading.Tasks;
namespace desay
{
    /// <summary>
    /// 托盘标定类
    /// </summary>
    public partial class frmTrayCalib : Form
    {
        Tray tray = null;//当前托盘对象
        bool IsWrite=false;
        private string PlateKey;
        ApsAxis m_Xaxis;
        ApsAxis m_Yaxis;
        ApsAxis m_Zaxis;
        private readonly Func<bool> _condition;

        #region 坐标显示
        private PlatePoint3DView BasePointView;
        private PlatePoint3DView RowPointView;
        private PlatePoint3DView ColumnPointView;
        #endregion

        public frmTrayCalib()
        {
            InitializeComponent();
        }
        public frmTrayCalib(string Key,ApsAxis Xaxis, ApsAxis Yaxis, ApsAxis Zaxis, Func<bool> Condition) :this()
        {
            PlateKey = Key;
            m_Xaxis = Xaxis;
            m_Yaxis = Yaxis;
            m_Zaxis = Zaxis;
            _condition = Condition;
        }
        public bool Xdir { get; set; }
        public bool Ydir { get; set; }
        public bool Zdir { get; set; }
        private void frmMotionCardSetting_Load(object sender, EventArgs e)
        {
            var Keys = TrayFactory.GetTrayDict.Keys;
            var count = Keys.Count;
            foreach (var key in Keys)
            {
                if (PlateKey == key)
                {
                    tray = TrayFactory.GetTrayFactory(PlateKey);
                    ndnRowXoffset.Value = (decimal)tray.RowXoffset;
                    ndnRowYoffset.Value = (decimal)tray.RowYoffset;
                    ndnColumnXoffset.Value = (decimal)tray.ColumnXoffset;
                    ndnColumnYoffset.Value = (decimal)tray.ColumnYoffset;
                    lblPlateID.Text = PlateKey;
                    lblTrayName.Text = tray.Name;
                };
            }
            if (tray == null)
            {
                MessageBox.Show("托盘不存在！");
                this.Close();
            }
            else
            {
                rbnContinueMoveSelect.Checked = true;
                rbnPos10um.Checked = true;
                BasePointView = new PlatePoint3DView()
                { Index = tray.BaseIndex, Point = tray.BasePosition };
                RowPointView = new PlatePoint3DView()
                { Index = tray.RowIndex, Point = tray.RowPosition };
                ColumnPointView = new PlatePoint3DView()
                { Index = tray.ColumnIndex, Point = tray.ColumnPosition };
                tbpUpPlate.Controls.Add(BasePointView, 1, 0);
                tbpUpPlate.Controls.Add(RowPointView, 1, 1);
                tbpUpPlate.Controls.Add(ColumnPointView, 1, 2);

                lblJogSpeed.Text = "点动速度:" + tbrJogSpeed.Value.ToString("0.00") + "mm/s";
                m_Xaxis.Speed = tbrJogSpeed.Value;
                m_Yaxis.Speed = tbrJogSpeed.Value;
                m_Zaxis.Speed = tbrJogSpeed.Value;

                timer1.Enabled = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            #region 轴状态
            lblCurrentPositionX.Text = m_Xaxis.CurrentPos.ToString("0.000");
            lblCurrentPositionY.Text = m_Yaxis.CurrentPos.ToString("0.000");
            lblCurrentPositionZ.Text = m_Zaxis.CurrentPos.ToString("0.000");
            lblCurrentSpeedX.Text = m_Xaxis.CurrentSpeed.ToString("0.000");
            lblCurrentSpeedY.Text = m_Yaxis.CurrentSpeed.ToString("0.000");
            lblCurrentSpeedZ.Text = m_Zaxis.CurrentSpeed.ToString("0.000");
            #endregion

            checkBox6.Text = "是否伺服ON";
            checkBox2.Text = "是否伺服ON";
            checkBox4.Text = "是否伺服ON";

            checkBox2.Checked = m_Xaxis.IsServon;
            checkBox4.Checked = m_Yaxis.IsServon;
            checkBox6.Checked = m_Zaxis.IsServon;

            if(!IsWrite)
            {
                ndnRowXoffset.Value = (decimal)tray.RowXoffset;
                ndnRowYoffset.Value = (decimal)tray.RowYoffset;
                ndnColumnXoffset.Value = (decimal)tray.ColumnXoffset;
                ndnColumnYoffset.Value = (decimal)tray.ColumnYoffset;

                lblIsCalibration.Text = tray.IsCalibration ? "已标定" : "未标定";
                lblIsCalibration.ForeColor = tray.IsCalibration ? Color.Green : Color.Red;
            }
        }

        #region 手动操作

        #region 三轴定距移动
        private void btnXdec_Click(object sender, EventArgs e)
        {
            if (!rbnLocationMoveSelect.Checked) return;
            if (!m_Xaxis.IsDone) return;
            var Value = 0.0;
            if (rbnPos10um.Checked) Value = 0.01;
            if (rbnPos100um.Checked) Value = 0.10;
            if (rbnPos1000um.Checked) Value = 1.00;
            if (rbnPosOtherum.Checked) Value = (double)ndnPosOther.Value;
            if (Xdir) Value *= -1.0;
            else Value *= 1.0;
            var velocityCurve = new VelocityCurve { Maxvel = m_Xaxis.Speed ?? 0 };
            m_Xaxis.MoveDelta(Value, velocityCurve);
        }
        private void btnXadd_Click(object sender, EventArgs e)
        {
            if (!rbnLocationMoveSelect.Checked) return;
            if (!m_Xaxis.IsDone) return;
            var Value = 0.0;
            if (rbnPos10um.Checked) Value = 0.01;
            if (rbnPos100um.Checked) Value = 0.10;
            if (rbnPos1000um.Checked) Value = 1.00;
            if (rbnPosOtherum.Checked) Value = (double)ndnPosOther.Value;
            if (Xdir) Value *= 1.0;
            else Value *= -1.0;
            var velocityCurve = new VelocityCurve { Maxvel = m_Xaxis.Speed ?? 0 };
            m_Xaxis.MoveDelta(Value, velocityCurve);
        }

        private void btnYdec_Click(object sender, EventArgs e)
        {
            if (!rbnLocationMoveSelect.Checked) return;
            if (!m_Yaxis.IsDone) return;
            var Value = 0.0;
            if (rbnPos10um.Checked) Value = 0.01;
            if (rbnPos100um.Checked) Value = 0.10;
            if (rbnPos1000um.Checked) Value = 1.00;
            if (rbnPosOtherum.Checked) Value = (double)ndnPosOther.Value;
            if (Ydir) Value *= 1.0;
            else Value *= -1.0;
            var velocityCurve = new VelocityCurve { Maxvel = m_Yaxis.Speed ?? 0 };
            m_Yaxis.MoveDelta(Value, velocityCurve);
        }

        private void btnYadd_Click(object sender, EventArgs e)
        {
            if (!rbnLocationMoveSelect.Checked) return;
            if (!m_Yaxis.IsDone) return;
            var Value = 0.0;
            if (rbnPos10um.Checked) Value = 0.01;
            if (rbnPos100um.Checked) Value = 0.10;
            if (rbnPos1000um.Checked) Value = 1.00;
            if (rbnPosOtherum.Checked) Value = (double)ndnPosOther.Value;
            if (Ydir) Value *= -1.0;
            else Value *= 1.0;
            var velocityCurve = new VelocityCurve { Maxvel = m_Yaxis.Speed ?? 0 };
            m_Yaxis.MoveDelta(Value, velocityCurve);
        }

        private void btnZadd_Click(object sender, EventArgs e)
        {
            if (!rbnLocationMoveSelect.Checked) return;
            if (!m_Zaxis.IsDone) return;
            var Value = 0.0;
            if (rbnPos10um.Checked) Value = 0.01;
            if (rbnPos100um.Checked) Value = 0.10;
            if (rbnPos1000um.Checked) Value = 1.00;
            if (rbnPosOtherum.Checked) Value = (double)ndnPosOther.Value;
            if (Zdir) Value *= -1.0;
            else Value *= 1.0;
            var velocityCurve = new VelocityCurve { Maxvel = m_Zaxis.Speed ?? 0 };
            m_Zaxis.MoveDelta(Value, velocityCurve);
        }

        private void btnZdec_Click(object sender, EventArgs e)
        {
            if (!rbnLocationMoveSelect.Checked) return;
            if (!m_Zaxis.IsDone) return;
            var Value = 0.0;
            if (rbnPos10um.Checked) Value = 0.01;
            if (rbnPos100um.Checked) Value = 0.10;
            if (rbnPos1000um.Checked) Value = 1.00;
            if (rbnPosOtherum.Checked) Value = (double)ndnPosOther.Value;
            if (Zdir) Value *= 1.0;
            else Value *= -1.0;
            var velocityCurve = new VelocityCurve { Maxvel = m_Zaxis.Speed ?? 0 };
            m_Zaxis.MoveDelta(Value, velocityCurve);
        }
        #endregion

        #region 三轴连续移动
        private void btnXdec_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rbnContinueMoveSelect.Checked) return;
            if (Xdir) m_Xaxis.Negative();
            else m_Xaxis.Postive();
        }

        private void btnXdec_MouseUp(object sender, MouseEventArgs e)
        {
            if (rbnLocationMoveSelect.Checked) return;
            m_Xaxis.Stop();
        }

        private void btnXadd_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rbnContinueMoveSelect.Checked) return;
            if (Xdir) m_Xaxis.Postive();
            else m_Xaxis.Negative();
        }

        private void btnXadd_MouseUp(object sender, MouseEventArgs e)
        {
            if (rbnLocationMoveSelect.Checked) return;
            m_Xaxis.Stop();
        }

        private void btnYdec_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rbnContinueMoveSelect.Checked) return;
            if (Ydir) m_Yaxis.Postive();
            else m_Yaxis.Negative();
        }

        private void btnYdec_MouseUp(object sender, MouseEventArgs e)
        {
            if (rbnLocationMoveSelect.Checked) return;
            m_Yaxis.Stop();
        }

        private void btnYadd_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rbnContinueMoveSelect.Checked) return;
            if (Ydir) m_Yaxis.Negative();
            else m_Yaxis.Postive();
        }

        private void btnYadd_MouseUp(object sender, MouseEventArgs e)
        {
            if (rbnLocationMoveSelect.Checked) return;
            m_Yaxis.Stop();
        }
        private void btnZdec_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rbnContinueMoveSelect.Checked) return;
            if (Zdir) m_Zaxis.Negative();
            else m_Zaxis.Postive();
        }

        private void btnZdec_MouseUp(object sender, MouseEventArgs e)
        {
            if (rbnLocationMoveSelect.Checked) return;
            m_Zaxis.Stop();
        }

        private void btnZadd_MouseDown(object sender, MouseEventArgs e)
        {
            if (!rbnContinueMoveSelect.Checked) return;
            if (Zdir) m_Zaxis.Postive();
            else m_Zaxis.Negative();
        }

        private void btnZadd_MouseUp(object sender, MouseEventArgs e)
        {
            if (rbnLocationMoveSelect.Checked) return;
            m_Zaxis.Stop();
        }
        #endregion

        private void tbrJogSpeed_Scroll(object sender, EventArgs e)
        {
            lblJogSpeed.Text = "点动速度:" + tbrJogSpeed.Value.ToString("0.00") + "mm/s";
            m_Xaxis.Speed = (double)tbrJogSpeed.Value;
            m_Yaxis.Speed = (double)tbrJogSpeed.Value;
            m_Zaxis.Speed = (double)tbrJogSpeed.Value;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            m_Xaxis.IsServon = checkBox2.Checked;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            m_Yaxis.IsServon = checkBox4.Checked;
        }
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            m_Zaxis.IsServon = checkBox6.Checked;
        }
        #endregion


        private int MoveToPoint(Point3D<double> pos)
        {
            if (!_condition())return -1;
            //判断Z轴是否在零点
            if (!m_Zaxis.IsInPosition(0))
                m_Zaxis.MoveTo(0, new VelocityCurve(0, (double)m_Zaxis.Speed, 0));
            while (true)
            {
                Thread.Sleep(10);
                if (m_Zaxis.IsInPosition(0)) break;
                if (m_Zaxis.IsAlarmed || m_Zaxis.IsEmg || !m_Zaxis.IsServon
                    || m_Zaxis.IsPositiveLimit || m_Zaxis.IsNegativeLimit)
                {
                    m_Zaxis.Stop();
                    return -4;
                }
            }
            //将X、Y移动到指定位置
            if (!m_Xaxis.IsInPosition(pos.X)) m_Xaxis.MoveTo(pos.X, new VelocityCurve(0, (double)m_Xaxis.Speed, 0));
            if (!m_Yaxis.IsInPosition(pos.Y)) m_Yaxis.MoveTo(pos.Y, new VelocityCurve(0, (double)m_Yaxis.Speed, 0));
            while (true)
            {
                Thread.Sleep(10);
                if (m_Xaxis.IsInPosition(pos.X) && m_Yaxis.IsInPosition(pos.Y)) break;
                if (m_Xaxis.IsAlarmed || m_Xaxis.IsEmg || !m_Xaxis.IsServon
                    || m_Xaxis.IsPositiveLimit || m_Xaxis.IsNegativeLimit
                    || m_Yaxis.IsAlarmed || m_Yaxis.IsEmg || !m_Yaxis.IsServon
                    || m_Yaxis.IsPositiveLimit || m_Yaxis.IsNegativeLimit)
                {
                    m_Xaxis.Stop();
                    m_Yaxis.Stop();
                    return -4;
                }
            }
            //将Z轴移动到指定位置
            m_Zaxis.MoveTo(pos.Z, new VelocityCurve(0, (double)m_Zaxis.Speed, 0));
            while (true)
            {
                Thread.Sleep(10);
                if (m_Zaxis.IsInPosition(pos.Z)) break;
                if (m_Zaxis.IsAlarmed || m_Zaxis.IsEmg || !m_Zaxis.IsServon
                    || m_Zaxis.IsPositiveLimit || m_Zaxis.IsNegativeLimit)
                {
                    m_Zaxis.Stop();
                    return -4;
                }
            }
            return 0;
        }


        #region 保存及定位
        private void btnPlateBaseSave_Click(object sender, EventArgs e)
        {
            var pos = new Point3D<double>();
            pos.X = m_Xaxis.CurrentPos;
            pos.Y = m_Yaxis.CurrentPos;
            tray.BaseIndex = BasePointView.Index;
            pos.Z = m_Zaxis.CurrentPos;
            BasePointView.Point = pos;
            tray.BaseIndex = BasePointView.Index;
            tray.BasePosition = pos;
        }


        private void btnPlateRowSave_Click(object sender, EventArgs e)
        {
            var pos = new Point3D<double>();
            pos.X = m_Xaxis.CurrentPos;
            pos.Y = m_Yaxis.CurrentPos;
            tray.RowIndex = RowPointView.Index;
            pos.Z = m_Zaxis.CurrentPos;
            RowPointView.Point = pos;
            tray.RowIndex = RowPointView.Index;
            tray.RowPosition = pos;
        }

        private void btnPlateColSave_Click(object sender, EventArgs e)
        {
            var pos = new Point3D<double>();
            pos.X = m_Xaxis.CurrentPos;
            pos.Y = m_Yaxis.CurrentPos;
            tray.ColumnIndex = ColumnPointView.Index;
            pos.Z = m_Zaxis.CurrentPos;
            ColumnPointView.Point = pos;
            tray.ColumnIndex = ColumnPointView.Index;
            tray.ColumnPosition = pos;
        }

        private void btnPlateBaseGoto_Click(object sender, EventArgs e)
        {
            var ret = MoveToPoint(tray.BasePosition);
            switch (ret)
            {
                case -1:
                    MessageBox.Show("外部条件不成立！"); break;
                case -2:
                    MessageBox.Show("定位异常退出！"); break;
                case -4:
                    MessageBox.Show("XY定位失败！"); break;
                default:
                    break;
            }
        }

        private void btnPlateRowGoto_Click(object sender, EventArgs e)
        {
            var ret = MoveToPoint(tray.RowPosition);
            switch (ret)
            {
                case -1:
                    MessageBox.Show("外部条件不成立！"); break;
                case -2:
                    MessageBox.Show("定位异常退出！"); break;
                case -4:
                    MessageBox.Show("XY定位失败！"); break;
                default:
                    break;
            }
        }
        private void btnPlateColGoto_Click(object sender, EventArgs e)
        {
            var ret = MoveToPoint(tray.ColumnPosition);
            switch (ret)
            {
                case -1:
                    MessageBox.Show("外部条件不成立！"); break;
                case -2:
                    MessageBox.Show("定位异常退出！"); break;
                case -4:
                    MessageBox.Show("XY定位失败！"); break;
                default:
                    break;
            }
        }
        #endregion

        private void btnCalibCal_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否进行标定计算？", "标定计算", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel) return;
            if (tray == null)
            {
                MessageBox.Show("托盘信息为空！");
                return;
            }
            try
            {
                IsWrite = true;
                //var ret = TrayFactory.Calibration(PlateKey);
                //if (!ret) MessageBox.Show("托盘标定失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("托盘标定失败！" + ex.ToString());
            }
            IsWrite = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            tray.RowXoffset = (double)ndnRowXoffset.Value;
            tray.RowYoffset = (double)ndnRowYoffset.Value;
            tray.ColumnXoffset = (double)ndnColumnXoffset.Value;
            tray.ColumnYoffset = (double)ndnColumnYoffset.Value;
        }
    }
}
