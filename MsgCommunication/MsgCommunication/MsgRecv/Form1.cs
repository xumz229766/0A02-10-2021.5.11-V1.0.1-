using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using MSMQ;


namespace MsgRecv
{
    public partial class Form1 : Form
    {
        //发送者
        private MQ msgSender = new MQ("myMQForComunicationSender");
        //接收者
        private MQ msgRecv = new MQ("myMQForComunicationRecv");
        //接收任务线程
        private Task t = null;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            t = new Task(ReciveMsg);
            t.Start();
        }
        /// <summary>
        /// 接收任务线程
        /// </summary>
        public void ReciveMsg()
        {
            while (true)
            {
                //这里会自动阻塞等待
                string txt = msgRecv.Receive(); 
                OutputInfo(txtRecvInfo, txt, false);
            }
        }

        public static void OutputInfo(TextBox txtInfo, string info, bool clear = false)
        {
            if (string.IsNullOrEmpty(info)) return;

            if (txtInfo.InvokeRequired)
            {
                Action<TextBox, string, bool> d = OutputInfo;
                txtInfo.BeginInvoke(d, new object[] { txtInfo, info, clear });
            }
            else
            {
                if (txtInfo.MaxLength < 32767 && !txtInfo.Visible) return;
                if (clear)
                {
                    txtInfo.Text = "";
                }
                txtInfo.AppendText(info);
                txtInfo.AppendText("\r\n");
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            msgSender.Send(txtSendInfo.Text);
        }
    }
}
