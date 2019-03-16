using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSMQ;



namespace desay
{
   public class claMQ
    {
        private MQ msgSender ;
        //接收者
        private MQ msgRecv;
        //接收任务线程
        private Task photoMessage = null;
        public bool IsComplete { get; set; }
        public string RecvMessage { get; set; }

        public claMQ()
        {
            msgSender = new MQ("sender");
            msgRecv = new MQ("reciver");
            photoMessage = new Task(ReciveMsg);
            photoMessage.Start();
        }
        /// <summary>
       /// 数据接收
        /// </summary>
        public void ReciveMsg()
        {
            while (true)
            {
                //这里会自动阻塞等待
                string str= msgRecv.Receive();
                RecvMessage = str;
                IsComplete = true;
            }
        }
        /// <summary>
        /// 数据发送
        /// </summary>
        public void SendMsg(string str)
        {
            RecvMessage = "";
            IsComplete = false;
            msgSender.Send(str);
        }
    }
   

}
