using System;
using System.Windows.Forms;
using System.ToolKit;
using System.ToolKit.Helper;
using System.AdvantechAps;

namespace desay
{
    public partial class XYZmode : UserControl
    {
        public ApsController ApsController;

        public XYZmode(ApsController ApsController)
        {
            InitializeComponent();
            this.ApsController = ApsController;
        }

        public void init()
        {        
            NumInspire1DelaySetValue.Value = (decimal)Delay.Instance.InspireDelay[0] / 1000;         
            NumInspire1ErrDelay.Value = (decimal)Delay.Instance.InspireErrDelay[0] / 1000;         
            NumInspire1StopDelay.Value = (decimal)Delay.Instance.InspireStopDelay[0] / 1000;         
            NumSopro1DelaySetValue.Value = (decimal)Delay.Instance.SoproDelay[0] / 1000;
            nudZSoproDelay.Value = (decimal)Delay.Instance.ZSoproDelay[0] / 1000;
            NumZaxisDoneDelay.Value = (decimal)Delay.Instance.ZaxisDoneDelay / 1000;
            outoCloseDoorTime.Value = (decimal)Delay.Instance.outoCloseDoorTime / 1000;
            outoCloseDoorOpen.Checked = Delay.Instance.outoCloseDoorOpen;          
            NumZaxisUpDecTime.Value = (decimal)Position.Instance.ZxiasUp;
            NumTrayPositon.Value = (decimal)Position.Instance.numTrayPositon;
            numZInformHeight.Value = (decimal)Position.Instance.ZInformHeight;
            numYAvoidDistance.Value = (decimal)Position.Instance.YAvoidDistance;
        }

        private void XYZmode_Load(object sender, EventArgs e)
        {
            init();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {          
            Delay.Instance.InspireDelay[0] = Convert.ToInt32(Convert.ToDouble(NumInspire1DelaySetValue.Value) * 1000);         
            Delay.Instance.InspireErrDelay[0] = Convert.ToInt32(Convert.ToDouble(NumInspire1ErrDelay.Value) * 1000);          
            Delay.Instance.InspireStopDelay[0] = Convert.ToInt32(Convert.ToDouble(NumInspire1StopDelay.Value) * 1000);       
            Delay.Instance.SoproDelay[0] = Convert.ToInt32(Convert.ToDouble(NumSopro1DelaySetValue.Value) * 1000);
            Delay.Instance.ZSoproDelay[0] = Convert.ToInt32(Convert.ToDouble(nudZSoproDelay.Value) * 1000);
            Delay.Instance.ZaxisDoneDelay = Convert.ToInt32(Convert.ToDouble(NumZaxisDoneDelay.Value) * 1000);
            Delay.Instance.outoCloseDoorTime = Convert.ToInt32(Convert.ToDouble(outoCloseDoorTime.Value) * 1000);
            Delay.Instance.outoCloseDoorOpen = outoCloseDoorOpen.Checked;
            Position.Instance.ZxiasUp = Convert.ToDouble(NumZaxisUpDecTime.Value);
            Position.Instance.numTrayPositon = Convert.ToInt32(NumTrayPositon.Value);
            Position.Instance.ZInformHeight = Convert.ToDouble(numZInformHeight.Value);
            Position.Instance.YAvoidDistance = Convert.ToDouble(numYAvoidDistance.Value);
            Marking.ModifyParameterMarker = true;
        }
    }
}
