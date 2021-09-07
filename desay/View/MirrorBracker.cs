using System;
using System.Enginee;
using System.Interfaces;
using System.ToolKit;
using System.ToolKit.Helper;
using System.Tray;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace desay
{
    public partial class MirrorBracker : UserControl
    {
        public MirrorBracker(Platform Platform)
        {
            InitializeComponent();
            m_Platform = Platform;
        }

        Platform m_Platform;

        string[] ID = new string[] { "8Hole", "12Hole", "16Hole", "20Hole", "24Hole", "32Hole" };

        private void MirrorBracker_Load(object sender, EventArgs e)
        {
            FragmentationMode.Items.Clear();
            FragmentationMode.Items.Add("冲压碎料");
            FragmentationMode.Items.Add("电机碎料");
            FragmentationMode.Items.Add("屏蔽碎料");          
            init();
            FragmentationModeSelect(FragmentationMode.SelectedIndex);
        }

        public void init()
        {
            numHoleNumber.Text = Position.Instance.HoleNumber.ToString();
            CkbSignalReverseSplice.Checked = Config.Instance.SignalReverseSplice;
            ckbThermoprintOpen1.Checked = Position.Instance.Caxis[0].HotCut;
            ckbThermoprintOpen2.Checked = Position.Instance.Caxis[1].HotCut;
            ckbThermoprintOpen3.Checked = Position.Instance.Caxis[2].HotCut;
            ckbThermoprintOpen4.Checked = Position.Instance.Caxis[3].HotCut;
            cbOverturnOpen1.Checked = Position.Instance.OverturnOpen[0];
            cbOverturnOpen2.Checked = Position.Instance.OverturnOpen[1];
            cbOverturnOpen3.Checked = Position.Instance.OverturnOpen[2];
            cbOverturnOpen4.Checked = Position.Instance.OverturnOpen[3];
            SpliceDelay.Value = (decimal)Delay.Instance.SpliceDelay / 1000;
            wasteWaitTime.Value = (decimal)Delay.Instance.WasteWaitTime / 1000;
            wasteNumber.Value = (decimal)Delay.Instance.WasteNumber;
            gripperCylinderTime.Value = (decimal)Delay.Instance.GripperCylinderTime / 1000;
            shearTime.Value = (decimal)Delay.Instance.ShearTime / 1000;
            numCaxisFrontDelay.Value = (decimal)Delay.Instance.CaxisFrontDelay / 1000;
            numCaxisRotateDelay.Value = (decimal)Delay.Instance.CaxisRotateDelay / 1000;
            EquiprmentWaitTime.Value = (decimal)Delay.Instance.equiprmentWaitTime / 1000;
            numSpliceDelay.Value = (decimal)Config.Instance.SignalSpliceDelay / 1000;
            numDestaticizing.Value = (decimal)Config.Instance.DestaticizingTime / 1000;
            JourneyControl1.Value = (decimal)Position.Instance.Caxis[0].JourneyControl / 1000;
            JourneyControl2.Value = (decimal)Position.Instance.Caxis[1].JourneyControl / 1000;
            JourneyControl3.Value = (decimal)Position.Instance.Caxis[2].JourneyControl / 1000;
            JourneyControl4.Value = (decimal)Position.Instance.Caxis[3].JourneyControl / 1000;
            ControlOpen1.Checked = Position.Instance.Caxis[0].ControlOpen;
            ControlOpen2.Checked = Position.Instance.Caxis[1].ControlOpen;
            ControlOpen3.Checked = Position.Instance.Caxis[2].ControlOpen;
            ControlOpen4.Checked = Position.Instance.Caxis[3].ControlOpen;
            numThermoprintCount1.Value = Position.Instance.Caxis[0].HotCutCount;
            numThermoprintCount2.Value = Position.Instance.Caxis[1].HotCutCount;
            numThermoprintCount3.Value = Position.Instance.Caxis[2].HotCutCount;
            numThermoprintCount4.Value = Position.Instance.Caxis[3].HotCutCount;
            numThermoprintTimer1.Value = (decimal)Position.Instance.Caxis[0].HotCutTime / 1000;
            numThermoprintTimer2.Value = (decimal)Position.Instance.Caxis[1].HotCutTime / 1000;
            numThermoprintTimer3.Value = (decimal)Position.Instance.Caxis[2].HotCutTime / 1000;
            numThermoprintTimer4.Value = (decimal)Position.Instance.Caxis[3].HotCutTime / 1000;
            FragmentationMode.SelectedIndex = Position.Instance.FragmentationMode;
            MotorStart.Checked = Position.Instance.CheckMotorStart;
            CAxisOrgRotate.Checked = Position.Instance.CAxisOrgRotate;
            checkOverload.Checked = Position.Instance.CheckOverload;
            cbSpecialTrayStart.Checked = Config.Instance.SpecialTrayStart;

            cbxYoungTraySelect.Items.Clear();
            cbxBigTraySelect.Items.Clear();
            cbSpecialTraySelect.Items.Clear();
            bool isHave = false;
            cbSpecialTraySelect.Items.Add("SpecialTray");
            foreach (var key in TrayFactory.GetTrayDict.Keys)
            {
                isHave = false;
                foreach (var id in ID)
                {
                    if (key == id)
                    {
                        isHave = true;
                    }
                }
                if (!isHave) { cbxYoungTraySelect.Items.Add(key); }               
            }
            cbSpecialTraySelect.Text = Config.Instance.SpecialPlateID;
            string x = Position.Instance.HoleNumber.ToString() + "Hole";
            cbxBigTraySelect.Items.Add(x);
            cbxBigTraySelect.Text = x;
            cbxYoungTraySelect.Text = Config.Instance.YoungPlateID;
            if (cbSpecialTraySelect.Text != "") { lblSpecialTray.Text = TrayFactory.GetTrayFactory(cbSpecialTraySelect.Text).IsCalibration ? "已标定" : "未标定"; }
            if (cbxYoungTraySelect.Text != "") { lblYoungTray.Text = TrayFactory.GetTrayFactory(cbxYoungTraySelect.Text).IsCalibration ? "已标定" : "未标定"; }
            if (cbxBigTraySelect.Text != "") { lblBigTray.Text = TrayFactory.GetTrayFactory(cbxBigTraySelect.Text).IsCalibration ? "已标定" : "未标定"; }
        }

        private void CbxYoungTraySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Instance.YoungPlateID = cbxYoungTraySelect.Text;
            if (cbxYoungTraySelect.Text != "") { lblYoungTray.Text = TrayFactory.GetTrayFactory(cbxYoungTraySelect.Text).IsCalibration ? "已标定" : "未标定"; }
        }

        private void CbxBigTraySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Instance.BigPlateID = cbxBigTraySelect.Text;
                if (cbxBigTraySelect.Text != "")
                {
                    lblBigTray.Text = TrayFactory.GetTrayFactory(cbxBigTraySelect.Text).IsCalibration ? "已标定" : "未标定";
                }
            }
            catch
            {
                MessageBox.Show("未建立此类型大托盘，请建立此托盘");
            }
        }

        private void CbxSpecialTraySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Config.Instance.SpecialPlateID = cbSpecialTraySelect.Text;
                if (cbSpecialTraySelect.Text != "")
                {
                    lblSpecialTray.Text = TrayFactory.GetTrayFactory(cbSpecialTraySelect.Text).IsCalibration ? "已标定" : "未标定";
                }
            }
            catch
            {
                MessageBox.Show("未建立此类型特殊托盘，请建立此托盘");
            }
        }

        frmTrayCalib trayCalib;

        private void btnYoungTrayCalib_Click(object sender, EventArgs e)
        {
            if (null == cbxYoungTraySelect.SelectedItem)
            {
                MessageBox.Show("小托盘型号为空，请选择托盘型号再进行标定操作！");
                return;
            }
            trayCalib = new frmTrayCalib(cbxYoungTraySelect.SelectedItem.ToString(), m_Platform.Xaxis, m_Platform.Yaxis, m_Platform.Zaxis, () => { return m_Platform.stationInitialize.InitializeDone; });
            trayCalib.Text = "小托盘标定";
            trayCalib.ShowDialog();
        }

        private void btnBigTrayCalib_Click(object sender, EventArgs e)
        {
            if (null == cbxBigTraySelect.SelectedItem)
            {
                MessageBox.Show("大托盘型号为空，请选择托盘型号再进行标定操作！");
                return;
            }
            trayCalib = new frmTrayCalib(cbxBigTraySelect.SelectedItem.ToString(), m_Platform.Xaxis, m_Platform.Yaxis, m_Platform.Zaxis, () => { return m_Platform.stationInitialize.InitializeDone; });
            trayCalib.Text = "大托盘标定";
            trayCalib.ShowDialog();
        }

        private void btnSpecialTrayCalib_Click(object sender, EventArgs e)
        {
            if (null == cbSpecialTraySelect.SelectedItem)
            {
                MessageBox.Show("特殊托盘型号为空，请选择托盘型号再进行标定操作！");
                return;
            }
            trayCalib = new frmTrayCalib(cbSpecialTraySelect.SelectedItem.ToString(), m_Platform.Xaxis, m_Platform.Yaxis, m_Platform.Zaxis, () => { return m_Platform.stationInitialize.InitializeDone; });
            trayCalib.Text = "特殊托盘标定";
            trayCalib.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {           
            Position.Instance.HoleNumber = Convert.ToInt32(numHoleNumber.Text);
            Config.Instance.SignalReverseSplice = CkbSignalReverseSplice.Checked;
            Position.Instance.Caxis[0].HotCut = ckbThermoprintOpen1.Checked;
            Position.Instance.Caxis[1].HotCut = ckbThermoprintOpen2.Checked;
            Position.Instance.Caxis[2].HotCut = ckbThermoprintOpen3.Checked;
            Position.Instance.Caxis[3].HotCut = ckbThermoprintOpen4.Checked;
            Position.Instance.OverturnOpen[0] = cbOverturnOpen1.Checked;
            Position.Instance.OverturnOpen[1] = cbOverturnOpen2.Checked;
            Position.Instance.OverturnOpen[2] = cbOverturnOpen3.Checked;
            Position.Instance.OverturnOpen[3] = cbOverturnOpen4.Checked;
            Delay.Instance.SpliceDelay = Convert.ToInt32(Convert.ToDouble(SpliceDelay.Value) * 1000);
            Delay.Instance.WasteWaitTime = Convert.ToInt32(Convert.ToDouble(wasteWaitTime.Value) * 1000);
            Delay.Instance.WasteNumber = Convert.ToInt32(Convert.ToDouble(wasteNumber.Value));
            Delay.Instance.GripperCylinderTime = Convert.ToInt32(Convert.ToDouble(gripperCylinderTime.Value) * 1000);
            Delay.Instance.ShearTime = Convert.ToInt32(Convert.ToDouble(shearTime.Value) * 1000);           
            Delay.Instance.CaxisFrontDelay = Convert.ToInt32(Convert.ToDouble(numCaxisFrontDelay.Value) * 1000);
            Delay.Instance.CaxisRotateDelay = Convert.ToInt32(Convert.ToDouble(numCaxisRotateDelay.Value) * 1000);
            Delay.Instance.equiprmentWaitTime = Convert.ToInt32(Convert.ToDouble(EquiprmentWaitTime.Value) * 1000);
            Config.Instance.SignalSpliceDelay = Convert.ToInt32(Convert.ToDouble(numSpliceDelay.Value) * 1000);           
            Config.Instance.DestaticizingTime = Convert.ToInt32(Convert.ToDouble(numDestaticizing.Value) * 1000);
            Position.Instance.Caxis[0].JourneyControl = Convert.ToInt32(Convert.ToDouble(JourneyControl1.Value) * 1000);
            Position.Instance.Caxis[1].JourneyControl = Convert.ToInt32(Convert.ToDouble(JourneyControl2.Value) * 1000);
            Position.Instance.Caxis[2].JourneyControl = Convert.ToInt32(Convert.ToDouble(JourneyControl3.Value) * 1000);
            Position.Instance.Caxis[3].JourneyControl = Convert.ToInt32(Convert.ToDouble(JourneyControl4.Value) * 1000);
            Position.Instance.Caxis[0].ControlOpen = ControlOpen1.Checked;
            Position.Instance.Caxis[1].ControlOpen = ControlOpen2.Checked;
            Position.Instance.Caxis[2].ControlOpen = ControlOpen3.Checked;
            Position.Instance.Caxis[3].ControlOpen = ControlOpen4.Checked;
            Position.Instance.Caxis[0].HotCutCount = Convert.ToInt32(numThermoprintCount1.Value);
            Position.Instance.Caxis[1].HotCutCount = Convert.ToInt32(numThermoprintCount2.Value);
            Position.Instance.Caxis[2].HotCutCount = Convert.ToInt32(numThermoprintCount3.Value);
            Position.Instance.Caxis[3].HotCutCount = Convert.ToInt32(numThermoprintCount4.Value);
            Position.Instance.Caxis[0].HotCutTime = Convert.ToInt32(Convert.ToDouble(numThermoprintTimer1.Value) * 1000);
            Position.Instance.Caxis[1].HotCutTime = Convert.ToInt32(Convert.ToDouble(numThermoprintTimer2.Value) * 1000);
            Position.Instance.Caxis[2].HotCutTime = Convert.ToInt32(Convert.ToDouble(numThermoprintTimer3.Value) * 1000);
            Position.Instance.Caxis[3].HotCutTime = Convert.ToInt32(Convert.ToDouble(numThermoprintTimer4.Value) * 1000);
            Position.Instance.FragmentationMode = FragmentationMode.SelectedIndex;
            Position.Instance.CheckMotorStart = MotorStart.Checked;
            Position.Instance.CAxisOrgRotate = CAxisOrgRotate.Checked;
            Position.Instance.CheckOverload = checkOverload.Checked;
            Config.Instance.SpecialTrayStart = cbSpecialTrayStart.Checked;
            Config.Instance.SpecialPlateID = cbSpecialTraySelect.Text;

            if (!Global.TrayDataRefresh)
            {
                init();
                Global.TrayDataRefresh = true;
            }

            Marking.ModifyParameterMarker = true;
        }

        private bool ServoAxisIsReady(ApsAxis axis)
        {
            return !axis.IsServon || axis.IsAlarmed || axis.IsEmg || axis.IsMEL || axis.IsPEL;
        }

        private void butGoto_Click(object sender, EventArgs e)
        {
            if(!tipsCancel.Checked)
            {
                if (DialogResult.No == MessageBox.Show("请先设置摆产品第一个位置!", "提示", MessageBoxButtons.YesNo)) return;
            }
            
            if (Convert.ToInt32(bigTaryID.Value) > Global.BigTray.EndPos)
            {
                MessageBox.Show("大盘超出设定坐标!");
                return;
            }
            if (Convert.ToInt32(youngTrayID.Value) > Global.SmallTray.EndPos)
            {
                MessageBox.Show("小盘超出设定坐标!");
                return;
            }
            Point3D<double> pos1 = Global.BigTray.GetPosition(Position.Instance.PuchProductPosition, Convert.ToInt32(bigTaryID.Value));
            Point3D<double> pos = Global.SmallTray.GetPosition(pos1, Convert.ToInt32(youngTrayID.Value));

            Global.IsLocating = true;
            Task.Factory.StartNew(() =>
            {
                try
                {
                    m_Platform.Zaxis.IsServon = true;
                    m_Platform.Xaxis.IsServon = true;
                    m_Platform.Yaxis.IsServon = true;                    
                    //判断Z轴是否在零点
                    if (!m_Platform.Zaxis.IsInPosition(0))
                        m_Platform.Zaxis.MoveTo(0, new VelocityCurve(0, (double)m_Platform.Zaxis.Speed, 0));
                    while (true)
                    {
                        if (!Global.IsLocating) return;
                        Thread.Sleep(10);
                        if (m_Platform.Zaxis.IsInPosition(0)) break;
                        if (ServoAxisIsReady(m_Platform.Zaxis))
                        {
                            m_Platform.Zaxis.Stop();
                            Global.IsLocating = false;
                            return;
                        }
                    }
                    //将X、Y移动到指定位置
                    if (!m_Platform.Xaxis.IsInPosition(pos.X))
                        m_Platform.Xaxis.MoveTo(pos.X, new VelocityCurve(0, (double)m_Platform.Xaxis.Speed, 0));
                    if (!m_Platform.Yaxis.IsInPosition(pos.Y))
                        m_Platform.Yaxis.MoveTo(pos.Y, new VelocityCurve(0, (double)m_Platform.Yaxis.Speed, 0));
                    while (true)
                    {
                        if (!Global.IsLocating) return;
                        Thread.Sleep(10);
                        if (m_Platform.Xaxis.IsInPosition(pos.X) && m_Platform.Yaxis.IsInPosition(pos.Y)) break;
                        if (ServoAxisIsReady(m_Platform.Xaxis) || ServoAxisIsReady(m_Platform.Yaxis))
                        {
                            m_Platform.Xaxis.Stop();
                            m_Platform.Yaxis.Stop();
                            Global.IsLocating = false;
                            return;
                        }
                    }
                    //将Z轴移动到指定位置
                    m_Platform.Zaxis.MoveTo(pos.Z, new VelocityCurve(0, (double)m_Platform.Zaxis.Speed, 0));
                    while (true)
                    {
                        if (!Global.IsLocating) return;
                        Thread.Sleep(10);
                        if (m_Platform.Zaxis.IsInPosition(pos.Z)) break;
                        if (ServoAxisIsReady(m_Platform.Zaxis))
                        {
                            m_Platform.Zaxis.Stop();
                            Global.IsLocating = false;
                            return;
                        }
                    }
                    Global.IsLocating = false;
                    return;
                }
                catch (Exception ex)
                {
                    Global.IsLocating = false;
                    return;
                }
            }, TaskCreationOptions.AttachedToParent | TaskCreationOptions.LongRunning);

            return;
        }

        private void FragmentationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            FragmentationModeSelect(FragmentationMode.SelectedIndex);
        }

        //碎料模式选择
        private void FragmentationModeSelect(int nFragmentationMode)
        {
            switch (nFragmentationMode)
            {
                case 0:
                    labelWasteWaitTime.Visible = true;
                    wasteWaitTime.Visible = true;
                    labelWasteNumber.Visible = true;
                    wasteNumber.Visible = true;
                    labelMotorStart.Visible = false;
                    MotorStart.Visible = false;
                    labOverload.Visible = false;
                    checkOverload.Visible = false;
                    break;
                case 1:
                    labelWasteWaitTime.Visible = false;
                    wasteWaitTime.Visible = false;
                    labelWasteNumber.Visible = false;
                    wasteNumber.Visible = false;
                    labelMotorStart.Visible = true;
                    MotorStart.Visible = true;
                    labOverload.Visible = true;
                    checkOverload.Visible = true;
                    break;
                default:
                    labelWasteWaitTime.Visible = false;
                    wasteWaitTime.Visible = false;
                    labelWasteNumber.Visible = false;
                    wasteNumber.Visible = false;
                    labelMotorStart.Visible = false;
                    MotorStart.Visible = false;
                    labOverload.Visible = false;
                    checkOverload.Visible = false;
                    IoPoints.T2DO10.Value = false;
                    break;
            }
        }

        //碎料电机开关
        private void MotorStart_CheckedChanged(object sender, EventArgs e)
        {
            if (MotorStart.Checked)
            {
                IoPoints.T2DO10.Value = true;
            }
            else
            {
                IoPoints.T2DO10.Value = false;
            }
        }
    }
}
