using System;
using System.Enginee;
using System.Interfaces;
using System.Threading;
using System.ToolKit.Helper;
using System.ToolKit;
using System.Windows.Forms;

namespace desay
{
    public partial class Jurisdiction : UserControl
    {
      
        public Jurisdiction()
        {
            InitializeComponent();          
        }

        private void Jurisdiction_Load(object sender, EventArgs e)
        {
            ckbWorkMode.Items.Add(UserLevel.操作员.ToString());
            ckbWorkMode.Items.Add(UserLevel.工程师.ToString());
            ckbWorkMode.Items.Add(UserLevel.设计者.ToString());
            ckbWorkMode.Text = Config.Instance.userLevels[0].ToString();
            ckbCylinderDelay.Items.Add(UserLevel.操作员.ToString());
            ckbCylinderDelay.Items.Add(UserLevel.工程师.ToString());
            ckbCylinderDelay.Items.Add(UserLevel.设计者.ToString());
            ckbCylinderDelay.Text = Config.Instance.userLevels[1].ToString();
            ckbExit.Items.Add(UserLevel.操作员.ToString());
            ckbExit.Items.Add(UserLevel.工程师.ToString());
            ckbExit.Items.Add(UserLevel.设计者.ToString());
            ckbExit.Text = Config.Instance.userLevels[2].ToString();
            ckbIoView.Items.Add(UserLevel.操作员.ToString());
            ckbIoView.Items.Add(UserLevel.工程师.ToString());
            ckbIoView.Items.Add(UserLevel.设计者.ToString());
            ckbIoView.Text = Config.Instance.userLevels[3].ToString();
            ckbMaintain.Items.Add(UserLevel.操作员.ToString());
            ckbMaintain.Items.Add(UserLevel.工程师.ToString());
            ckbMaintain.Items.Add(UserLevel.设计者.ToString());
            ckbMaintain.Text = Config.Instance.userLevels[4].ToString();
            ckbOffice.Items.Add(UserLevel.操作员.ToString());
            ckbOffice.Items.Add(UserLevel.工程师.ToString());
            ckbOffice.Items.Add(UserLevel.设计者.ToString());
            ckbOffice.Text = Config.Instance.userLevels[5].ToString();
            ckbSpeed.Items.Add(UserLevel.操作员.ToString());
            ckbSpeed.Items.Add(UserLevel.工程师.ToString());
            ckbSpeed.Items.Add(UserLevel.设计者.ToString());
            ckbSpeed.Text = Config.Instance.userLevels[6].ToString();
            ckbTeach.Items.Add(UserLevel.操作员.ToString());
            ckbTeach.Items.Add(UserLevel.工程师.ToString());
            ckbTeach.Items.Add(UserLevel.设计者.ToString());
            ckbTeach.Text = Config.Instance.userLevels[7].ToString();
            ckbTraySelect.Items.Add(UserLevel.操作员.ToString());
            ckbTraySelect.Items.Add(UserLevel.工程师.ToString());
            ckbTraySelect.Items.Add(UserLevel.设计者.ToString());
            ckbTraySelect.Text = Config.Instance.userLevels[8].ToString();
            ckbTricolorLamp.Items.Add(UserLevel.操作员.ToString());
            ckbTricolorLamp.Items.Add(UserLevel.工程师.ToString());
            ckbTricolorLamp.Items.Add(UserLevel.设计者.ToString());
            ckbTricolorLamp.Text = Config.Instance.userLevels[9].ToString();
            AccDec.Items.Add(UserLevel.设备厂商.ToString());
            AccDec.Text = Config.Instance.userLevels[10].ToString();           
            Manufacturer.Items.Add(UserLevel.设备厂商.ToString());
            Manufacturer.Text = Config.Instance.userLevels[11].ToString();          
        }

        private void button1Save_Click(object sender, EventArgs e)
        {
            switch (ckbWorkMode.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[0] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[0] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[0] = UserLevel.设计者;
                    break;
            }
            switch (ckbCylinderDelay.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[1] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[1] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[1] = UserLevel.设计者;
                    break;
            }
            switch (ckbExit.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[2] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[2] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[2] = UserLevel.设计者;
                    break;
            }
            switch (ckbIoView.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[3] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[3] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[3] = UserLevel.设计者;
                    break;
            }
            switch (ckbMaintain.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[4] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[4] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[4] = UserLevel.设计者;
                    break;
            }
            switch (ckbOffice.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[5] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[5] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[5] = UserLevel.设计者;
                    break;
            }
            switch (ckbSpeed.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[6] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[6] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[6] = UserLevel.设计者;
                    break;
            }
            switch (ckbTeach.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[7] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[7] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[7] = UserLevel.设计者;
                    break;
            }
            switch (ckbTraySelect.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[8] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[8] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[8] = UserLevel.设计者;
                    break;
            }
            switch (ckbTricolorLamp.Text)
            {
                case "操作员":
                    Config.Instance.userLevels[9] = UserLevel.操作员;
                    break;
                case "工程师":
                    Config.Instance.userLevels[9] = UserLevel.工程师;
                    break;
                case "设计者":
                    Config.Instance.userLevels[9] = UserLevel.设计者;
                    break;
            }
            if(AccDec.Text == "设备厂商")
            {
                Config.Instance.userLevels[10] = UserLevel.设备厂商;
            }
            if (Manufacturer.Text == "设备厂商")
            {
                Config.Instance.userLevels[11] = UserLevel.设备厂商;
            }
            Marking.ModifyParameterMarker = true;
        }
    }
}
