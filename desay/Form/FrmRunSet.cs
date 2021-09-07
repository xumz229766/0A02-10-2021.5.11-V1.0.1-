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
    public partial class FrmRunSet : Form
    {
        public FrmRunSet()
        {
            InitializeComponent();
        }

        private void FrmRunSet_Load(object sender, EventArgs e)
        {
            ckbAutoDoorSheild.Checked = Marking.AutoDoorSheild;       
            ckbSpliceSensorSheild.Checked = Marking.SpliceSensorSheild;
            ckbtraySensorSheild.Checked = Marking.traySensorSheild;
            ckbMoveProductSensorSheild.Checked = Marking.MoveProductSensorSheild;
            doorSafeSensorSheild.Checked = Marking.DoorSafeSensorSheild;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Marking.AutoDoorSheild = ckbAutoDoorSheild.Checked;       
            Marking.SpliceSensorSheild = ckbSpliceSensorSheild.Checked;
            Marking.traySensorSheild = ckbtraySensorSheild.Checked;
            Marking.MoveProductSensorSheild = ckbMoveProductSensorSheild.Checked;
            Marking.DoorSafeSensorSheild = doorSafeSensorSheild.Checked;
            this.Close();
        }
    }
}
