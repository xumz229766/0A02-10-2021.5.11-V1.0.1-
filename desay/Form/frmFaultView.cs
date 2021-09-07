using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Interfaces;
using System.Threading;
using System.ToolKit;
using System.ToolKit.Helper;
using System.Enginee;
namespace desay
{
    public partial class frmFaultView : Form
    {
        private AlarmType IsAlarm;
        private List<Alarm>[] Alarms;
        public frmFaultView()
        {
            InitializeComponent();
        }

        public frmFaultView(List<Alarm>[] Alarm) : this()
        {
            Alarms = Alarm;
        }
        private void frmIOmonitor_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            for (int i = 0; i < Alarms.Length; i++)
            {
                IsAlarm = AlarmCheck(Alarms[i]);
            }
            timer1.Enabled = true;
        }


        public AlarmType AlarmCheck(IList<Alarm> Alarms)
        {
            var Alarm = new AlarmType();
            Fault Fau;
            foreach (Alarm alarm in Alarms)
            {
                var btemp = alarm.IsAlarm;
                if (alarm.AlarmLevel == AlarmLevels.Error)
                {
                    Alarm.IsAlarm |= btemp;
                    this.Invoke(new Action(() =>
                    {
                        Fau = Global.FaultDictionary[alarm.Name];
                        Msg(string.Format("{0},{1},{2},{3}", alarm.AlarmLevel.ToString(), Fau.FaultCode, Fau.FaultCount, Fau.FaultMessage), btemp);
                    }));
                }
                else if (alarm.AlarmLevel == AlarmLevels.None)
                {
                    Alarm.IsPrompt |= btemp;
                    this.Invoke(new Action(() =>
                    {
                        Msg(string.Format("{0},{1}", alarm.AlarmLevel.ToString(), alarm.Name), btemp);
                    }));
                }
                else
                {
                    Alarm.IsWarning |= btemp;
                    this.Invoke(new Action(() =>
                    {
                        Msg(string.Format("{0},{1}", alarm.AlarmLevel.ToString(), alarm.Name), btemp);
                    }));
                }
            }
            return Alarm;
        }

        private void Msg(string str, bool value)
        {
            string tempstr = null;
            bool sign = false;
            try
            {
                var arrRight = new List<object>();
                foreach (var tmpist in listArm.Items)
                {
                    arrRight.Add(tmpist);
                }

                if (value)
                {
                    foreach (string tmplist in arrRight)
                    {
                        if (tmplist.IndexOf("-") > -1)
                        {
                            tempstr = tmplist.Substring(tmplist.IndexOf("-") + 1, tmplist.Length - tmplist.IndexOf("-") - 1);
                        }
                        if (tempstr == (str + "\r\n"))
                        {
                            sign = true;
                            break;
                        }
                    }
                    if (!sign)
                    {
                        listArm.Items.Insert(0, (string.Format("{0}-{1}" + Environment.NewLine, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), str)));
                        LogHelper.Error(str);
                    }
                }
                else
                {
                    foreach (string tmplist in arrRight)
                    {
                        if (tmplist.IndexOf("-") > -1)
                        {
                            tempstr = tmplist.Substring(tmplist.IndexOf("-") + 1, tmplist.Length - tmplist.IndexOf("-") - 1);
                            if (tempstr == (str + "\r\n"))
                            {
                                listArm.Items.Remove(tmplist);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Debug(ex.ToString() + "消息显示异常");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            listArm.Items.Clear();
            reshing();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            listArm.Items.Clear();
            timer1.Enabled = true;
        }

        private void reshing()
        {
            foreach (Fault1 AlarmFault in Global.AlarmsFault)
            {
                AppendText(AlarmFault.FaultTime.ToString() + "故障代码：" + AlarmFault.FaultCode.ToString() + "故障消息：" + AlarmFault.FaultMessage/* + "故障次数：" + kvp.Value.FaultCount.ToString()*/);
            }
        }

        /// <summary>
        /// 使用委托方式更新AppendText显示
        /// </summary>
        /// <param name="txt">消息</param>
        public void AppendText(string txt)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendText), txt);
            }
            else
            {
                listArm.Items.Insert(0, string.Format("{0}" + Environment.NewLine, txt));
                //LogHelper.Debug(txt);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Global.AlarmsFault.Clear();
            listArm.Items.Clear();
        }
    }
}
