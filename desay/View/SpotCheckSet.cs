using System;
using System.Enginee;
using System.Interfaces;
using System.ToolKit;
using System.ToolKit.Helper;
using System.Tray;
using System.Windows.Forms;
using System.AdvantechAps;

namespace desay
{
    public partial class SpotCheckSet : UserControl
    {

        public ApsController ApsController;

        public ServoAxis AllAxis { get; set; }

        public SpotCheckSet(ApsController ApsController)
        {
            InitializeComponent();
            this.ApsController = ApsController;
        }

        private void SpotCheckSet_Load(object sender, EventArgs e)
        {
            init();
            timer1.Enabled = true;
        }

        public void init()
        {
            AxisID.Items.Clear();
            AxisID.Items.Add("Y轴");
            AxisID.Items.Add("X轴");
            AxisID.Items.Add("Z轴");
            AxisID.Items.Add("C1轴");
            AxisID.Items.Add("C2轴");
            AxisID.Items.Add("C3轴");
            AxisID.Items.Add("C4轴");
            AxisID.Items.Add("P1轴");
            AxisID.Items.Add("P2轴");
            AxisID.Items.Add("P3轴");
            AxisID.Items.Add("P4轴");
            AxisID.Items.Add("Z1轴");
            AxisID.Items.Add("Z2轴");
            AxisID.Items.Add("Z3轴");
            AxisID.Items.Add("Z4轴");
            AxisID.Items.Add("M轴仓储");
            AxisID.SelectedIndex = 0;

            SoftNlimit.Text = AxisParameter.Instance.SoftNlimit[AxisID.SelectedIndex].ToString();
            SoftPlimit.Text = AxisParameter.Instance.SoftPlimit[AxisID.SelectedIndex].ToString();

            InitServoParam();
        }

        //初始化各轴伺服参数
        public void InitServoParam()
        {
            ServoParam.Rows.Clear();
            ServoParam.Rows.Add("0.00", "16", "2100h", "01h", "电机旋转正方向定义", "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false);
            ServoParam.Rows.Add("0.02", "16", "2100h", "03h", "实时自调整模式", "1", false, "2", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false);
            ServoParam.Rows.Add("0.03", "16", "2100h", "04h", "刚性等级设置", "16", false, "14", false, "16", false, "18", false, "18", false, "18", false, "18", false, "18", false, "18", false, "18", false, "18", false);
            ServoParam.Rows.Add("0.04", "16", "2100h", "05h", "惯量比", "430", false, "280", false, "100", false, "100", false, "100", false, "100", false, "100", false, "100", false, "100", false, "100", false, "100", false);
            ServoParam.Rows.Add("0.16", "16", "2100h", "11h", "脉冲输出正方向定义", "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false);
            ServoParam.Rows.Add("1.00", "16", "2101h", "01h", "位置环增益1", "900", false, "630", false, "900", false, "1350", false, "1350", false, "1350", false, "1350", false, "1350", false, "1350", false, "1350", false, "1350", false);
            ServoParam.Rows.Add("1.01", "16", "2101h", "02h", "速度环增益", "500", false, "350", false, "500", false, "750", false, "750", false, "750", false, "750", false, "750", false, "750", false, "750", false, "750", false);
            ServoParam.Rows.Add("1.02", "16", "2101h", "03h", "速度环积分时间1", "1200", false, "1600", false, "1200", false, "900", false, "900", false, "900", false, "900", false, "900", false, "900", false, "900", false, "900", false);
            ServoParam.Rows.Add("1.04", "16", "2101h", "05h", "转矩指令滤波1", "45", false, "65", false, "45", false, "30", false, "30", false, "30", false, "30", false, "30", false, "30", false, "30", false, "30", false);
            ServoParam.Rows.Add("1.05", "16", "2101h", "06h", "位置环增益2", "1050", false, "730", false, "1050", false, "1570", false, "1570", false, "1570", false, "1570", false, "1570", false, "1570", false, "1570", false, "1570", false);
            ServoParam.Rows.Add("1.06", "16", "2101h", "07h", "速度环增益2", "500", false, "350", false, "500", false, "750", false, "750", false, "750", false, "750", false, "750", false, "750", false, "750", false, "750", false);
            ServoParam.Rows.Add("1.09", "16", "2101h", "0Ah", "转矩指令滤波2", "45", false, "65", false, "45", false, "30", false, "30", false, "30", false, "30", false, "30", false, "30", false, "30", false, "30", false);
            ServoParam.Rows.Add("2.01", "16", "2102h", "02h", "位置指令FIR滤波", "0", false, "10", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false);
            ServoParam.Rows.Add("2.10", "16", "2102h", "0Bh", "第3陷波器频率", "5000", false, "2574", false, "5000", false, "5000", false, "5000", false, "5000", false, "5000", false, "5000", false, "5000", false, "5000", false, "5000", false);
            ServoParam.Rows.Add("2.11", "16", "2102h", "0Ch", "第3陷波器宽度", "2", false, "1", false, "2", false, "2", false, "2", false, "2", false, "2", false, "2", false, "2", false, "2", false, "2", false);
            ServoParam.Rows.Add("2.12", "16", "2102h", "0Dh", "第3陷波器深度", "0", false, "1", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false);
            ServoParam.Rows.Add("4.16", "16", "2104h", "11h", "DI6端子逻辑选择", "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false);
            ServoParam.Rows.Add("4.17", "16", "2104h", "12h", "DI7端子逻辑选择", "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false, "0", false);
            ServoParam.Rows.Add("4.34", "16", "2104h", "23h", "DO4端子逻辑电平选择", "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false);
            ServoParam.Rows.Add("4.51", "16", "2104h", "34h", "零速时制动器动作后伺服OFF延迟时间", "10", false, "10", false, "100", false, "10", false, "10", false, "10", false, "10", false, "10", false, "10", false, "10", false, "10", false);
            ServoParam.Rows.Add("6.26", "16", "2106h", "1Bh", "伺服OFF停机方式", "2", false, "2", false, "1", false, "0", false, "0", false, "0", false, "0", false, "2", false, "2", false, "2", false, "2", false);
            ServoParam.Rows.Add("6.27", "16", "2106h", "1Ch", "第二类故障停机方式选择", "2", false, "2", false, "1", false, "2", false, "2", false, "2", false, "2", false, "0", false, "0", false, "0", false, "0", false);
            ServoParam.Rows.Add("6.29", "16", "2106h", "1Eh", "超程时的停止方式", "2", false, "2", false, "0", false, "2", false, "2", false, "2", false, "2", false, "0", false, "0", false, "0", false, "0", false);
            ServoParam.Rows.Add("6.47", "16", "2106h", "30h", "绝对值系统设定", "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false);
            ServoParam.Rows.Add("7.00", "16", "2107h", "01h", "面板显示选项", "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false, "1", false);
            ServoParam.Rows.Add("20.06", "16", "2114h", "07h", "系统初始化功能", "7", false, "7", false, "7", false, "7", false, "7", false, "7", false, "7", false, "7", false, "7", false, "7", false, "7", false);
            ServoParam.Rows.Add("", "32", "6092h", "01h", "进给常量：分子", "10000", false, "40000", false, "10000", false, "36000", false, "36000", false, "36000", false, "36000", false, "10000", false, "10000", false, "10000", false, "10000", false);
            ServoParam.Rows.Add("", "32", "1010h", "01h", "保存进给常量", "1702257011", false, "1702257011", false, "1702257011", false, "1702257011", false, "1702257011", false, "1702257011", false, "1702257011", false, "1702257011", false, "1702257011", false, "1702257011", false, "1702257011", false);
            ServoParam.Rows.Add("", "16", "2114h", "03h", "保存所有参数", "42330", false, "42330", false, "42330", false, "42330", false, "42330", false, "42330", false, "42330", false, "42330", false, "42330", false, "42330", false, "42330", false);

            StepParam.Rows.Clear();
            StepParam.Rows.Add("16", "2000h", "00h", "驱动器峰值电流 ", "2800", false, "2800", false, "2800", false, "2800", false, "6000", false);
            StepParam.Rows.Add("16", "2001h", "00h", "电机每转脉冲数", "4000", false, "4000", false, "4000", false, "4000", false, "30000", false);
            StepParam.Rows.Add("16", "2003h", "00h", "待机电流百分比", "50", false, "50", false, "50", false, "50", false, "50", false);
            StepParam.Rows.Add("32", "1010h", "01h", "保存所有参数", "1", false, "1", false, "1", false, "1", false, "1", false);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            CurrentPos.Text = ((double)ApsController.GetCurrentFeedbackPosition(AxisID.SelectedIndex) * PulseEquivalent(AxisID.SelectedIndex)).ToString(); //获取编码器位置          
            timer1.Enabled = true;
        }

        //设置原点(编码器原点)
        private void SetORG_Click(object sender, EventArgs e)
        {
            if (11 == AxisID.SelectedIndex)
            {
                MessageBox.Show("Z1轴有机械原点");
                return;
            }
            else if (12 == AxisID.SelectedIndex)
            {
                MessageBox.Show("Z2轴有机械原点");
                return;
            }
            else if (13 == AxisID.SelectedIndex)
            {
                MessageBox.Show("Z3轴有机械原点");
                return;
            }
            else if (14 == AxisID.SelectedIndex)
            {
                MessageBox.Show("Z4轴有机械原点");
                return;
            }
            if (15 == AxisID.SelectedIndex)
            {
                MessageBox.Show("M轴有机械原点");
                return;
            }
            ApsController.SetHomeORG(AxisID.SelectedIndex);
            SoftNlimit.Text = 0.ToString();
            SoftPlimit.Text = 0.ToString();
            LogHelper.Info("设置原点");
        }

        //获取负限位位置
        private void GetSoftNLimit_Click(object sender, EventArgs e)
        {
            SoftNlimit.Text = ((double)ApsController.GetCurrentFeedbackPosition(AxisID.SelectedIndex) * PulseEquivalent(AxisID.SelectedIndex)).ToString(); //获取编码器位置
            LogHelper.Info("获取负限位位置");
        }

        //获取正限位位置
        private void GetSoftPLimit_Click(object sender, EventArgs e)
        {
            SoftPlimit.Text = ((double)ApsController.GetCurrentFeedbackPosition(AxisID.SelectedIndex) * PulseEquivalent(AxisID.SelectedIndex)).ToString(); //获取编码器位置
            LogHelper.Info("获取正限位位置");
        }

        //设置软限位
        private void SetSoftLimit_Click(object sender, EventArgs e)
        {
            AxisParameter.Instance.SoftNlimit[AxisID.SelectedIndex] = Convert.ToDouble(SoftNlimit.Text);
            AxisParameter.Instance.SoftPlimit[AxisID.SelectedIndex] = Convert.ToDouble(SoftPlimit.Text);
            bool ret =  ApsController.SetSoftLimit(AxisID.SelectedIndex, (int)(AxisParameter.Instance.SoftNlimit[AxisID.SelectedIndex]/ PulseEquivalent(AxisID.SelectedIndex)),
                (int)(AxisParameter.Instance.SoftPlimit[AxisID.SelectedIndex] / PulseEquivalent(AxisID.SelectedIndex)));
            if (true == ret)
            {
                MessageBox.Show("设置软限位--OK");
            }
            else
            {
                MessageBox.Show("设置软限位--NG");
            }
            Marking.ModifyParameterMarker = true;
            LogHelper.Info("设置软限位");
        }

        
        private void InitServo_CheckedChanged(object sender, EventArgs e)
        {
            if (InitServo.Checked)
            {
                ServoParam.Rows.Clear();
                StepParam.Rows.Clear();
                InitServoParam();
                for (var n = 0; n < 29; n++)
                {
                    ServoParam.Rows[n].Cells[6].Value = true;
                    ServoParam.Rows[n].Cells[8].Value = true;
                    ServoParam.Rows[n].Cells[10].Value = true;
                    ServoParam.Rows[n].Cells[12].Value = true;
                    ServoParam.Rows[n].Cells[14].Value = true;
                    ServoParam.Rows[n].Cells[16].Value = true;
                    ServoParam.Rows[n].Cells[18].Value = true;
                    ServoParam.Rows[n].Cells[20].Value = true;
                    ServoParam.Rows[n].Cells[22].Value = true;
                    ServoParam.Rows[n].Cells[24].Value = true;
                    ServoParam.Rows[n].Cells[26].Value = true;
                }

                for (var h = 0; h < StepParam.RowCount; h++)
                {
                    StepParam.Rows[h].Cells[5].Value = true;
                    StepParam.Rows[h].Cells[7].Value = true;
                    StepParam.Rows[h].Cells[9].Value = true;
                    StepParam.Rows[h].Cells[11].Value = true;
                    StepParam.Rows[h].Cells[13].Value = true;
                }
            }
        }

        //全选中
        private void AllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AllCheck.Checked)
            {
                for (var n = 0; n < 29; n++)
                {
                    ServoParam.Rows[n].Cells[6].Value = true;
                    ServoParam.Rows[n].Cells[8].Value = true;
                    ServoParam.Rows[n].Cells[10].Value = true;
                    ServoParam.Rows[n].Cells[12].Value = true;
                    ServoParam.Rows[n].Cells[14].Value = true;
                    ServoParam.Rows[n].Cells[16].Value = true;
                    ServoParam.Rows[n].Cells[18].Value = true;
                    ServoParam.Rows[n].Cells[20].Value = true;
                    ServoParam.Rows[n].Cells[22].Value = true;
                    ServoParam.Rows[n].Cells[24].Value = true;
                    ServoParam.Rows[n].Cells[26].Value = true;
                }

                for (var h = 0; h < StepParam.RowCount; h++)
                {
                    StepParam.Rows[h].Cells[5].Value = true;
                    StepParam.Rows[h].Cells[7].Value = true;
                    StepParam.Rows[h].Cells[9].Value = true;
                    StepParam.Rows[h].Cells[11].Value = true;
                    StepParam.Rows[h].Cells[13].Value = true;
                }
            }
            else
            {
                for (var n = 0; n < 29; n++)
                {
                    ServoParam.Rows[n].Cells[6].Value = false;
                    ServoParam.Rows[n].Cells[8].Value = false;
                    ServoParam.Rows[n].Cells[10].Value = false;
                    ServoParam.Rows[n].Cells[12].Value = false;
                    ServoParam.Rows[n].Cells[14].Value = false;
                    ServoParam.Rows[n].Cells[16].Value = false;
                    ServoParam.Rows[n].Cells[18].Value = false;
                    ServoParam.Rows[n].Cells[20].Value = false;
                    ServoParam.Rows[n].Cells[22].Value = false;
                    ServoParam.Rows[n].Cells[24].Value = false;
                    ServoParam.Rows[n].Cells[26].Value = false;
                }
                for (var h = 0; h < StepParam.RowCount; h++)
                {
                    StepParam.Rows[h].Cells[5].Value = false;
                    StepParam.Rows[h].Cells[7].Value = false;
                    StepParam.Rows[h].Cells[9].Value = false;
                    StepParam.Rows[h].Cells[11].Value = false;
                    StepParam.Rows[h].Cells[13].Value = false;
                }
            }
        }

        //写入伺服
        private void WriteServo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("是否写入伺服参数！"), "确定", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            bool AllRet = true;
            bool Ret = true;
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[6].Value))
            {
                Ret = ApsController.SetNodeOd(1002, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[5].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[8].Value))
            {
                Ret = ApsController.SetNodeOd(1001, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[7].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[10].Value))
            {
                Ret = ApsController.SetNodeOd(1003, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[9].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[12].Value))
            {
                Ret = ApsController.SetNodeOd(1004, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[11].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[14].Value))
            {
                Ret = ApsController.SetNodeOd(1005, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[13].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[16].Value))
            {
                Ret = ApsController.SetNodeOd(1006, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[15].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[18].Value))
            {
                Ret = ApsController.SetNodeOd(1007, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[17].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[20].Value))
            {
                Ret = ApsController.SetNodeOd(1008, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[19].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[22].Value))
            {
                Ret = ApsController.SetNodeOd(1009, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[21].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[24].Value))
            {
                Ret = ApsController.SetNodeOd(1010, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[23].Value));
                AllRet = AllRet || Ret;
            }
            if (Convert.ToBoolean(ServoParam.Rows[28].Cells[26].Value))
            {
                Ret = ApsController.SetNodeOd(1011, UInt16.Parse(ServoParam.Rows[28].Cells[2].Value.ToString().Remove(ServoParam.Rows[28].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[28].Cells[3].Value.ToString().Remove(ServoParam.Rows[28].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[28].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[28].Cells[25].Value));
                AllRet = AllRet || Ret;
            }
            for (var n = 0; n < 28; n++)
            {
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[6].Value))
                {
                    Ret = ApsController.SetNodeOd(1002, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[5].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[8].Value))
                {
                    Ret = ApsController.SetNodeOd(1001, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[7].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[10].Value))
                {
                    Ret = ApsController.SetNodeOd(1003, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[9].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[12].Value))
                {
                    Ret = ApsController.SetNodeOd(1004, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[11].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[14].Value))
                {
                    Ret = ApsController.SetNodeOd(1005, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[13].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[16].Value))
                {
                    Ret = ApsController.SetNodeOd(1006, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[15].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[18].Value))
                {
                    Ret = ApsController.SetNodeOd(1007, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[17].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[20].Value))
                {
                    Ret = ApsController.SetNodeOd(1008, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[19].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[22].Value))
                {
                    Ret = ApsController.SetNodeOd(1009, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[21].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[24].Value))
                {
                    Ret = ApsController.SetNodeOd(1010, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[23].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(ServoParam.Rows[n].Cells[26].Value))
                {
                    Ret = ApsController.SetNodeOd(1011, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                        UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value), Convert.ToInt32(ServoParam.Rows[n].Cells[25].Value));
                    AllRet = AllRet || Ret;
                }
            }

            for (var h = 0; h < StepParam.RowCount; h++)
            {
                if (Convert.ToBoolean(StepParam.Rows[h].Cells[5].Value))
                {
                    Ret = ApsController.SetNodeOd(1012, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                         UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value), Convert.ToInt32(StepParam.Rows[h].Cells[4].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(StepParam.Rows[h].Cells[7].Value))
                {
                    Ret = ApsController.SetNodeOd(1013, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                         UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value), Convert.ToInt32(StepParam.Rows[h].Cells[6].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(StepParam.Rows[h].Cells[9].Value))
                {
                    Ret = ApsController.SetNodeOd(1014, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                         UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value), Convert.ToInt32(StepParam.Rows[h].Cells[8].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(StepParam.Rows[h].Cells[11].Value))
                {
                    Ret = ApsController.SetNodeOd(1015, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                         UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value), Convert.ToInt32(StepParam.Rows[h].Cells[10].Value));
                    AllRet = AllRet || Ret;
                }
                if (Convert.ToBoolean(StepParam.Rows[h].Cells[13].Value))
                {
                    Ret = ApsController.SetNodeOd(1016, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                         UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value), Convert.ToInt32(StepParam.Rows[h].Cells[12].Value));
                    AllRet = AllRet || Ret;
                }
            }
            if (AllRet)
            {
                MessageBox.Show("写入伺服--OK");
            }
            else
            {
                MessageBox.Show("写入伺服--NG!");
            }

            LogHelper.Info("写入伺服参数");
        }

        //读取伺服
        private void ReadServo_Click(object sender, EventArgs e)
        {
            for (var n = 0; n < 28; n++)
            {
                ServoParam.Rows[n].Cells[5].Value = ApsController.GetNodeOd(1002, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[7].Value = ApsController.GetNodeOd(1001, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[9].Value = ApsController.GetNodeOd(1003, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[11].Value = ApsController.GetNodeOd(1004, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[13].Value = ApsController.GetNodeOd(1005, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[15].Value = ApsController.GetNodeOd(1006, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[17].Value = ApsController.GetNodeOd(1007, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[19].Value = ApsController.GetNodeOd(1008, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[21].Value = ApsController.GetNodeOd(1009, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[23].Value = ApsController.GetNodeOd(1010, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
                ServoParam.Rows[n].Cells[25].Value = ApsController.GetNodeOd(1011, UInt16.Parse(ServoParam.Rows[n].Cells[2].Value.ToString().Remove(ServoParam.Rows[n].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(ServoParam.Rows[n].Cells[3].Value.ToString().Remove(ServoParam.Rows[n].Cells[3].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(ServoParam.Rows[n].Cells[1].Value));
            }

            for (var h = 0; h < StepParam.RowCount; h++)
            {
                StepParam.Rows[h].Cells[4].Value = ApsController.GetNodeOd(1012, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value));
                StepParam.Rows[h].Cells[6].Value = ApsController.GetNodeOd(1013, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value));
                StepParam.Rows[h].Cells[8].Value = ApsController.GetNodeOd(1014, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value));
                StepParam.Rows[h].Cells[10].Value = ApsController.GetNodeOd(1015, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value));
                StepParam.Rows[h].Cells[12].Value = ApsController.GetNodeOd(1016, UInt16.Parse(StepParam.Rows[h].Cells[1].Value.ToString().Remove(StepParam.Rows[h].Cells[1].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber),
                    UInt16.Parse(StepParam.Rows[h].Cells[2].Value.ToString().Remove(StepParam.Rows[h].Cells[2].Value.ToString().Length - 1), System.Globalization.NumberStyles.HexNumber), Convert.ToUInt16(StepParam.Rows[h].Cells[0].Value));
            }
            LogHelper.Info("读取伺服参数");
        }

        public double PulseEquivalent(int AxisID)
        {
            double Equivalent = 0;
            switch (AxisID)
            {
                case 0:
                    Equivalent = 40.0 / 40000;
                    break;
                case 1:
                    Equivalent = 10.0 / 10000;
                    break;
                case 2:
                    Equivalent = 10.0 / 10000;
                    break;
                case 3:
                    Equivalent = 360.0 / 36000;
                    break;
                case 4:
                    Equivalent = 360.0 / 36000;
                    break;
                case 5:
                    Equivalent = 360.0 / 36000;
                    break;
                case 6:
                    Equivalent = 360.0 / 36000;
                    break;
                case 7:
                    Equivalent = 10.0 / 10000;
                    break;
                case 8:
                    Equivalent = 10.0 / 10000;
                    break;
                case 9:
                    Equivalent = 10.0 / 10000;
                    break;
                case 10:
                    Equivalent = 10.0 / 10000;
                    break;
                case 11:
                    Equivalent = 40.0 / 4000;
                    break;
                case 12:
                    Equivalent = 40.0 / 4000;
                    break;
                case 13:
                    Equivalent = 40.0 / 4000;
                    break;
                case 14:
                    Equivalent = 40.0 / 4000;
                    break;
                case 15:
                    Equivalent = 3.0 / 30000;
                    break;
                default: break;
            }
            return Equivalent;
        }

        private void AxisID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SoftNlimit.Text = AxisParameter.Instance.SoftNlimit[AxisID.SelectedIndex].ToString();
            SoftPlimit.Text = AxisParameter.Instance.SoftPlimit[AxisID.SelectedIndex].ToString();
        }

        private void InputLimitValue_CheckedChanged(object sender, EventArgs e)
        {
            if(InputLimitValue.Checked)
            {
                SoftNlimit.ReadOnly = false;
                SoftPlimit.ReadOnly = false;
            }
            else
            {
                SoftNlimit.ReadOnly = true;
                SoftPlimit.ReadOnly = true;
            }
        }

        //热复位
        private void btnCoolReset_Click(object sender, EventArgs e)
        {
            IoPoints.ApsController.CoolReset();
            MessageBox.Show("热复位完成！");
        }

        //冷复位
        private void btnSoftReset_Click(object sender, EventArgs e)
        {
            IoPoints.ApsController.SoftReset();
            MessageBox.Show("冷复位完成！");
        }
    }
}
