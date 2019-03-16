using System;
using System.Threading;
using System.Windows.Forms;
using Motion.Enginee;
using System.ToolKit;
using System.ToolKit.Helper;
using System.Tray;
namespace desay
{
    public partial class frmParameter : Form
    {
        //private VacuoParameter InhaleParameter;
        private AxisSpeed XaxisSpeedView;
        private AxisSpeed YaxisSpeedView;
        private AxisSpeed ZaxisSpeedView;
        private AxisSpeed MaxisSpeedView;
        private AxisSpeed CaxisSpeedView;

        private Splice m_Splice;
        private Buffer m_Buffer;
        private Feeder m_Feeder;
        private Move m_Move;
        private LeftC m_LeftC;
        private MiddleC m_MiddleC;
        private RightC m_RightC;
        private LeftCut1 m_LeftCut1;
        private LeftCut2 m_LeftCut2;
        private RightCut1 m_RightCut1;
        private RightCut2 m_RightCut2;
        private Platform m_Platform;
        private Storing m_Storing;
        public frmParameter()
        {
            InitializeComponent();
        }
        public frmParameter(Splice Splice, Buffer Buffer, Feeder Feeder, Move Move, LeftC LeftC, MiddleC MiddleC, RightC RightC,
           LeftCut1 LeftCut1, LeftCut2 LeftCut2, RightCut1 RightCut1, RightCut2 RightCut2, Platform Platform, Storing Storing) :this()
        {
            m_Splice = Splice;
            m_Buffer = Buffer;
            m_Feeder = Feeder;
            m_Move = Move;
            m_LeftC = LeftC;
            m_MiddleC = MiddleC;
            m_RightC = RightC;
            m_LeftCut1 = LeftCut1;
            m_LeftCut2 = LeftCut2;
            m_RightCut1 = RightCut1;
            m_RightCut2 = RightCut2;
            m_Platform = Platform;
            m_Storing = Storing;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < Config.Instance.ProductType.Count; i++)
            {
                if (txtProductType.Text.Trim() == Config.Instance.ProductType[i])
                {
                    MessageBox.Show("有相同型号，不能新增！");
                    return;
                }
            }
            Config.Instance.ProductType.Add(txtProductType.Text.Trim());
            Config.Instance.CurrentProductType = txtProductType.Text.Trim();
            lbxProductType.Items.Clear();
            for (var i = 0; i < Config.Instance.ProductType.Count; i++)
                lbxProductType.Items.Add(Config.Instance.ProductType[i]);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < Config.Instance.ProductType.Count; i++)
            {
                if (txtProductType.Text.Trim() == Config.Instance.CurrentProductType)
                {
                    MessageBox.Show("该型号正在使用，不能删除！");
                    return;
                }
                else
                {
                    if (txtProductType.Text.Trim() == Config.Instance.ProductType[i])
                    {
                        Config.Instance.ProductType.Remove(txtProductType.Text.Trim());
                        lbxProductType.Items.Clear();
                        for (var j = 0; j < Config.Instance.ProductType.Count; j++)
                            lbxProductType.Items.Add(Config.Instance.ProductType[j]);
                        return;
                    }
                }
            }
        }

        private void btnSelectProductType_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否保存前一型号的数据？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) SerializerManager<Position>.Instance.Save(AppConfig.ConfigFileName, Position.Instance);
            Thread.Sleep(20);
            Config.Instance.CurrentProductType = lbxProductType.Text;
            Thread.Sleep(20);
            Position.Instance= SerializerManager<Position>.Instance.Load(AppConfig.ConfigPositionName);
        }

        private void frmParameter_Load(object sender, EventArgs e)
        {
            lbxProductType.Items.Clear();
            for (var i = 0; i < Config.Instance.ProductType.Count; i++)
                lbxProductType.Items.Add(Config.Instance.ProductType[i]);
            lblCurrentProductType.Text = Config.Instance.CurrentProductType;

            ndnInhaleTime.Value=(decimal)((double)Delay.Instance.InhaleTime/1000.0);
            ndnNgBrokenTime.Value=(decimal)((double)Delay.Instance.NgBrokenTime / 1000.0);
            ndnPlateBrokenTime.Value=(decimal)((double)Delay.Instance.PlateBrokenTime / 1000.0);
            ndnPlateInPosBroken.Value = (decimal) ((double) Delay.Instance.PlateInPosBrokenTime/1000.0);
            //InhaleParameter = new VacuoParameter(Delay.Instance.InhaleDelay) { Name = "吸笔真空阀" };
            //flpVacuoParam.Controls.Add(InhaleParameter);

            XaxisSpeedView = new AxisSpeed(AxisParameter.Instance.XvelocityMax)
            {
                Name = "X轴运行",
                SpeedRate = AxisParameter.Instance.XvelocityRate
            };
            YaxisSpeedView = new AxisSpeed(AxisParameter.Instance.YvelocityMax)
            {
                Name = "Y轴运行",
                SpeedRate = AxisParameter.Instance.YvelocityRate
            };
            ZaxisSpeedView = new AxisSpeed(AxisParameter.Instance.ZvelocityMax)
            {
                Name = "Z轴运行",
                SpeedRate = AxisParameter.Instance.ZvelocityRate
            };
            MaxisSpeedView = new AxisSpeed(AxisParameter.Instance.MvelocityMax)
            {
                Name = "M轴运行",
                SpeedRate = AxisParameter.Instance.MvelocityRate
            };
            CaxisSpeedView = new AxisSpeed(AxisParameter.Instance.CvelocityMax)
            {
                Name = "C轴运行",
                SpeedRate = AxisParameter.Instance.CvelocityRate
            };
            flpAxisSpeed.Controls.Add(XaxisSpeedView);
            flpAxisSpeed.Controls.Add(YaxisSpeedView);
            flpAxisSpeed.Controls.Add(ZaxisSpeedView);
            flpAxisSpeed.Controls.Add(MaxisSpeedView);
            flpAxisSpeed.Controls.Add(CaxisSpeedView);

            var Keys = TrayFactory.GetTrayDict.Keys;
            var count = Keys.Count;
            foreach (var key in Keys)
            {
                cbxAssemblyPlateID.Items.Add(key);
            }
            cbxAssemblyPlateID.Text = Position.Instance.PlateID;
            //textBox1.Text = Delay.Instance.MissingAlarmTime.ToString();

            ndnCaxisOffsetDistance.Value = (decimal)Position.Instance.CaxisOffsetDistance;
            ndnUpCameraPlimit.Value = (decimal)Position.Instance.UpCameraPLimit;
            ndnUpCameraNlimit.Value = (decimal) Position.Instance.UpCameraNLimit;
            ndnUpCamerauplimit.Value = (decimal)Position.Instance.UpCameraupLimit;
            chxZPutIsBuffeer.Checked = Position.Instance.IsZPutBuffer;
            ndnZPutBuffeerSpeed.Value = (decimal)Position.Instance.ZPutBufferSpeed;
            ndnZPutBuffeerDistance.Value = (decimal)Position.Instance.ZPutBufferDistance;
            chxZGetIsBuffeer.Checked = Position.Instance.IsZGetBuffer;
            ndnZGetBuffeerSpeed.Value = (decimal)Position.Instance.ZGetBufferSpeed;
            ndnZGetBuffeerDistance.Value = (decimal)Position.Instance.ZGetBufferDistance;
            ndnZUptBuffeerSpeed.Value = (decimal)Position.Instance.ZUpBufferSpeed;
            ndnZUpBuffeerDistance.Value = (decimal)Position.Instance.ZUpBufferDistance;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否需要保存参数设置的数据", "保存", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            //Delay.Instance.InhaleDelay = InhaleParameter.Save;
            //Delay.Instance.MissingAlarmTime = Convert.ToDouble(textBox1.Text);
            Delay.Instance.InhaleTime = (int)((double)ndnInhaleTime.Value * 1000.0);
            Delay.Instance.NgBrokenTime = (int)((double)ndnNgBrokenTime.Value * 1000.0);
            Delay.Instance.PlateBrokenTime = (int)((double)ndnPlateBrokenTime.Value * 1000.0);
            Delay.Instance.PlateInPosBrokenTime = (int) ((double) ndnPlateInPosBroken.Value*1000.0);
            Position.Instance.PlateID = cbxAssemblyPlateID.Text;
            Position.Instance.CaxisOffsetDistance = (double)ndnCaxisOffsetDistance.Value;
            Position.Instance.UpCameraPLimit = (double)ndnUpCameraPlimit.Value;
            Position.Instance.UpCameraNLimit = (double) ndnUpCameraNlimit.Value;
            Position.Instance.UpCameraupLimit = (double)ndnUpCamerauplimit.Value;
          
            Position.Instance.IsZPutBuffer = chxZPutIsBuffeer.Checked;
            Position.Instance.ZPutBufferSpeed = (double)ndnZPutBuffeerSpeed.Value;
            Position.Instance.ZPutBufferDistance = (double)ndnZPutBuffeerDistance.Value;
            Position.Instance.IsZGetBuffer = chxZGetIsBuffeer.Checked;
            Position.Instance.ZGetBufferSpeed = (double)ndnZGetBuffeerSpeed.Value;
            Position.Instance.ZGetBufferDistance = (double)ndnZGetBuffeerDistance.Value;
            Position.Instance.ZUpBufferSpeed = (double)ndnZUptBuffeerSpeed.Value;
            Position.Instance.ZUpBufferDistance = (double)ndnZUpBuffeerDistance.Value;
           
            AxisParameter.Instance.XvelocityRate = XaxisSpeedView.SpeedRate;
            AxisParameter.Instance.YvelocityRate = YaxisSpeedView.SpeedRate;
            AxisParameter.Instance.ZvelocityRate = ZaxisSpeedView.SpeedRate;
            AxisParameter.Instance.MvelocityRate = MaxisSpeedView.SpeedRate;
            AxisParameter.Instance.CvelocityRate = CaxisSpeedView.SpeedRate;
        }

        private void btnAssemblyCalib_Click(object sender, EventArgs e)
        {
            try
            {
                new frmTrayCalib(cbxAssemblyPlateID.Text, m_plateform.Xaxis,m_plateform.Yaxis, m_plateform.Zaxis, 
                    () => { return !m_plateform.stationOperate.Running&!m_plateform.stationInitialize.Running; }).ShowDialog();
            }
            catch (Exception ex) { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var Keys = TrayFactory.GetTrayDict.Keys;
            var count = Keys.Count;
            cbxAssemblyPlateID.Items.Clear();
            foreach (var key in Keys)
            {
                cbxAssemblyPlateID.Items.Add(key);
            }
            cbxAssemblyPlateID.Text = Position.Instance.PlateID;
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}
