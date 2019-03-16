using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Device
{
    public partial class frmSimensPLC : Form
    {
        #region 变量

        SimensPLC.SimensPLC _device;
        string saveParam;

        #endregion
        #region 构造函数
        public frmSimensPLC()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        /// <summary>
        /// 窗体构造函数
        /// </summary>
        /// <param name="devicename">设备标识</param>
        public frmSimensPLC(SimensPLC.SimensPLC device)
            : this()
        {
            _device = device;
            this.Text = _device.Name;
            saveParam = _device.ConnectionParam;
            LoadParam();
        }
        #endregion
        private void frmSimensPLC_Load(object sender, EventArgs e)
        {
            button_Connect.Enabled = _device.IsConnect ? false : true;
            button_Close.Enabled = _device.IsConnect ? true : false;
            lblConnectStatus.Text = _device.IsConnect ? "已连接" : "已断开";
            lblConnectStatus.ForeColor = _device.IsConnect ? Color.DarkGreen : Color.DarkRed;
        }

        /// <summary>
        /// 加载通讯参数
        /// </summary>
        public void LoadParam()
        {
            string[] str = saveParam.Split(',');
            txtIPAddr.Text = str[0];
            txtPortNumber.Text = str[1];
            txtRack.Text = str[2];
            txtSlot.Text = str[3];
        }

        /// <summary>
        /// 保存通讯参数
        /// </summary>
        void SaveParam()
        {
            if (txtIPAddr.Text == null) return;
            if (txtPortNumber.Text == null) return;
            if (txtRack.Text == null) return;
            if (txtSlot.Text == null) return;
            _device.ConnectionParam = txtIPAddr.Text.Trim() + ","
                                    + txtPortNumber.Text.Trim() + ","
                                    + txtRack.Text.Trim() + ","
                                    + txtSlot.Text.Trim(); 
        }

        #region 控件事件
        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (_device.IsConnect)
                {
                    lblConnectStatus.Text = "已连接";
                    lblConnectStatus.ForeColor = Color.DarkGreen;
                    button_Connect.Enabled = false;
                    button_Close.Enabled = true;
                    return;
                }
                _device.SetConnectionParam(_device.ConnectionParam);
                _device.Open();
            }
            catch (Exception ex)
            {
                _device.Close();
                lblConnectStatus.Text = "已断开";
                lblConnectStatus.ForeColor = Color.DarkRed;
                button_Connect.Enabled = true;
                button_Close.Enabled = false;
            }
            if (_device.IsConnect)
            {
                lblConnectStatus.Text = "已连接";
                lblConnectStatus.ForeColor = Color.DarkGreen;
                button_Connect.Enabled = false;
                button_Close.Enabled = true;
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            try
            {
                _device.Close();
                lblConnectStatus.Text = "已断开";
                lblConnectStatus.ForeColor = Color.DarkRed;
                button_Connect.Enabled = true;
                button_Close.Enabled = false;
            }
            catch (Exception ex)
            {
                //ShowMessage(string.Format("设备关闭失败。{0}", ex.ToString()));
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            SaveParam();
        }
        #endregion


    }
}
