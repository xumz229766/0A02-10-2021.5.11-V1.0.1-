using System;
using System.Enginee;
using System.Threading;
using System.ToolKit;
using System.ToolKit.Helper;
using System.Tray;
using System.Windows.Forms;


namespace desay
{
    public partial class frmOffces : Form
    {

        public frmOffces()
        {
            InitializeComponent();
        }
        offcesValue[] offcesValue;
        private void FrmOffces_Load(object sender, EventArgs e)
        {
            LogHelper.Info("偏移设定");
            flowLayoutPanel1.Controls.Clear();           
            offcesValue = new offcesValue[Position.Instance.HoleNumber / 4];         
            for (int i = 0; i < Position.Instance.HoleNumber / 4; i++)
            {
                offcesValue[i] = new offcesValue(i);
                flowLayoutPanel1.Controls.Add(offcesValue[i]);
            }

        }

        private void FrmOffces_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
