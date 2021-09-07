using System;
using System.Enginee;
using System.Interfaces;
using System.Threading;
using System.ToolKit.Helper;
using System.ToolKit;
using System.Windows.Forms;

namespace desay
{
    public partial class storingMode : UserControl
    {
       
        public storingMode()
        {         
            InitializeComponent();          
        }

       
        private void StoringMode_Load(object sender, EventArgs e)
        {
            init();
        }

        public void init()
        {
            numUpfristCount.Value = (decimal)Position.Instance.MLayerFillCount[0];
            numUpSecondCount.Value = (decimal)Position.Instance.MLayerFillCount[1];
            numUpthirdlyCount.Value = (decimal)Position.Instance.MLayerFillCount[2];
            numUpFourCount.Value = (decimal)Position.Instance.MLayerFillCount[3];
            numUpFifthCount.Value = (decimal)Position.Instance.MLayerFillCount[4];
            numUpSixCount.Value = (decimal)Position.Instance.MLayerFillCount[5];
            numUpSeventhCount.Value = (decimal)Position.Instance.MLayerFillCount[6];
            numericUpDown1.Value = Config.Instance.NoProductGTrayCount;
            checkBox1.Checked = Config.Instance.ChangeTrayArl;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Config.Instance.NoProductGTrayCount = Convert.ToInt32(numericUpDown1.Value);
            Config.Instance.ChangeTrayArl = checkBox1.Checked;
            Position.Instance.MLayerFillCount[0] = Convert.ToInt32(numUpfristCount.Value);
            Position.Instance.MLayerFillCount[1] = Convert.ToInt32(numUpSecondCount.Value);
            Position.Instance.MLayerFillCount[2] = Convert.ToInt32(numUpthirdlyCount.Value);
            Position.Instance.MLayerFillCount[3] = Convert.ToInt32(numUpFourCount.Value);
            Position.Instance.MLayerFillCount[4] = Convert.ToInt32(numUpFifthCount.Value);
            Position.Instance.MLayerFillCount[5] = Convert.ToInt32(numUpSixCount.Value);
            Position.Instance.MLayerFillCount[6] = Convert.ToInt32(numUpSeventhCount.Value);
            Marking.ModifyParameterMarker = true;
        }
    }
}
