using System;
using System.Windows.Forms;
using System.ToolKit;
namespace desay
{
    public partial class PasswordChang : UserControl
    {

        public PasswordChang()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            new frmPasswordChange(UserLevel.操作员).ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            new frmPasswordChange(UserLevel.工程师).ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            new frmPasswordChange(UserLevel.设计者).ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            new frmPasswordChange(UserLevel.设备厂商).ShowDialog();
        }
    }
}
