using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Tray;
namespace desay
{
    public partial class frmRunSetting : Form
    {
        public frmRunSetting()
        {
            InitializeComponent();
        }

        private void frmRunSetting_Load(object sender, EventArgs e)
        {
            //chkInhaleSensorSheild.Checked = Config.Instance.inhaleSensorSheild;
            //chkTraySensorSheild.Checked = Config.Instance.traySensorSheild;
            ////chkRepositorySensorSheild.Checked = Config.Instance.repositorySensorSheild;
            //chkIncomingHaveProductSheild.Checked = Config.Instance.incomingHaveProductSheild;
            chxIncomingSensorSheild.Checked = Marking.incomingHaveProductSheild;
            chxFrameSensorSheild.Checked = Marking.repositorySensorSheild;
            chxPlateSensorSheild.Checked = Marking.traySensorSheild;
            chxUpCameraSheild.Checked = Marking.UpCameraSheild;
            chxDownCameraSheild.Checked = Marking.DownCameraSheild;
            chxInhaleSignalSheild.Checked = Marking.inhaleSensorSheild;
            chkZGetBuffer.Checked = Position.Instance.IsZGetBuffer;
            chkZPutBuffer.Checked = Position.Instance.IsZPutBuffer;
            chxHaveInPlate.Checked = Position.Instance.HaveInPlate;
            if (Position.Instance.PlateID != "")
            {
                ndnCurrentTrayPosition.Maximum = TrayFactory.GetTrayFactory(Position.Instance.PlateID).EndPos;
                if (Position.Instance.TrayIndex >= TrayFactory.GetTrayFactory(Position.Instance.PlateID).EndPos)
                {
                    ndnCurrentTrayPosition.Value = TrayFactory.GetTrayFactory(Position.Instance.PlateID).EndPos;
                }
                else
                {
                    ndnCurrentTrayPosition.Value = Position.Instance.TrayIndex + 1;
                }
            }

            ndnMLayerCurrentIndex.Maximum = 5;
            ndnMLayerCurrentIndex.Value = Position.Instance.MLayerIndex+1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Marking.incomingHaveProductSheild=chxIncomingSensorSheild.Checked;
            Marking.repositorySensorSheild=chxFrameSensorSheild.Checked;
            Marking.traySensorSheild=chxPlateSensorSheild.Checked;
            Marking.UpCameraSheild=chxUpCameraSheild.Checked;
            Marking.DownCameraSheild=chxDownCameraSheild.Checked;
            Marking.inhaleSensorSheild=chxInhaleSignalSheild.Checked;
            Position.Instance.IsZGetBuffer = chkZGetBuffer.Checked;
            Position.Instance.IsZPutBuffer = chkZPutBuffer.Checked;
            Position.Instance.HaveInPlate = chxHaveInPlate.Checked;
            var trayIndex = (int)ndnCurrentTrayPosition.Value - 1;
            var layerIndex= (int)ndnMLayerCurrentIndex.Value-1;
            if (Position.Instance.PlateID != "")
            {                
                if (trayIndex>=0&&trayIndex< TrayFactory.GetTrayFactory(Position.Instance.PlateID).EndPos)
                {
                    Position.Instance.TrayIndex = trayIndex;
                }
            }
            if (layerIndex >= 0 && layerIndex < 5)
            {
                Position.Instance.MLayerIndex = layerIndex;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ndnCurrentTrayPosition_Validating(object sender, CancelEventArgs e)
        {
            if (ndnCurrentTrayPosition.Value > ndnCurrentTrayPosition.Maximum) e.Cancel = true;
        }

        private void ndnMLayerCurrentIndex_Validating(object sender, CancelEventArgs e)
        {
            if (ndnMLayerCurrentIndex.Value > ndnMLayerCurrentIndex.Maximum) e.Cancel = true;
        }
    }
}
