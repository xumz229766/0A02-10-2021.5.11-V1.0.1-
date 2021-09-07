using System;
using System.Drawing;
using System.Windows.Forms;
using System.ToolKit.Helper;
using System.ToolKit;

namespace desay
{
    public partial class TarySetView : UserControl
    {
        public TarySetView()
        {
            InitializeComponent();
        }

        public void init()
        {
            tpl4.Controls.Clear();
            tpl3.Controls.Clear();
            tpl2.Controls.Clear();
            tpl1.Controls.Clear();
            tpl4.RowStyles.Clear();
            tpl4.ColumnStyles.Clear();
            tpl3.RowStyles.Clear();
            tpl3.ColumnStyles.Clear();
            tpl2.RowStyles.Clear();
            tpl2.ColumnStyles.Clear();
            tpl1.RowStyles.Clear();
            tpl1.ColumnStyles.Clear();
            tpl4.ColumnCount = Global.BigTray.Column;
            tpl3.ColumnCount = Global.BigTray.Column;
            tpl2.ColumnCount = Global.BigTray.Column;
            tpl1.ColumnCount = Global.BigTray.Column;
            for (int i = 0; i < Global.BigTray.Column; i++)
            {
                tpl4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tpl3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tpl2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                tpl1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }           
            tpl4.RowCount = Global.BigTray.Row;
            tpl3.RowCount = Global.BigTray.Row;
            tpl2.RowCount = Global.BigTray.Row;
            tpl1.RowCount = Global.BigTray.Row;
            for (int i = 0; i < Global.BigTray.Row; i++)
            {
                tpl4.ColumnStyles.Add(new RowStyle(SizeType.Percent, 25F));
                tpl3.ColumnStyles.Add(new RowStyle(SizeType.Percent, 25F));
                tpl2.ColumnStyles.Add(new RowStyle(SizeType.Percent, 25F));
                tpl1.ColumnStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }         
            int value = (Global.BigTray.Column * Global.BigTray.Row) - 1;
            for (int i = 0; i < Global.BigTray.Column; i++)
            {
                for (int j = 0; j < Global.BigTray.Row; j++)
                {
                    NumericUpDown btn = new NumericUpDown();
                    btn.Dock = DockStyle.Fill;
                    //btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Name = "LeftOne," + value.ToString();
                    btn.Maximum = Global.BigTray.Column * Global.BigTray.Row * 4;
                    btn.Minimum = 1;
                    NumericUpDown btn1 = new NumericUpDown();
                    btn1.Anchor = AnchorStyles.None;
                    btn1.Dock = DockStyle.Fill;
                    //btn1.BackgroundImageLayout = ImageLayout.Stretch;
                    btn1.Name = "LeftTwo," + value.ToString();
                    //btn.Size = new Size(tpl2.Size.Width / Global.LensTray.Column, 20);
                    btn1.Maximum = Global.BigTray.Column * Global.BigTray.Row * 4;
                    btn1.Minimum = 1;
                    NumericUpDown btn2 = new NumericUpDown();
                    btn2.Anchor = AnchorStyles.None;
                    btn2.Dock = DockStyle.Fill;
                    //btn2.BackgroundImageLayout = ImageLayout.Stretch;
                    btn2.Name = "RightOne," + value.ToString();
                    //btn2.Size = new Size(tpl3.Size.Width / Global.LensTray.Column, 20);
                    btn2.Maximum = Global.BigTray.Column * Global.BigTray.Row * 4;
                    btn2.Minimum = 1;
                    NumericUpDown btn3 = new NumericUpDown();
                    btn3.Anchor = AnchorStyles.None;
                    btn3.Dock = DockStyle.Fill;
                    //btn3.BackgroundImageLayout = ImageLayout.Stretch;
                    btn3.Name = "RightTwo," + value.ToString();
                    //btn3.Size = new Size(tpl4.Size.Width / Global.LensTray.Column, 20);
                    btn3.Maximum = Global.BigTray.Column * Global.BigTray.Row * 4;
                    btn3.Minimum = 1;
                    try
                    {
                        btn.Value = (decimal)Config.Instance.LeftTarySet[value];
                    }
                    catch{ btn.Value = 1;}
                    try
                    {
                        btn1.Value = (decimal)Config.Instance.LeftTarySet1[value];
                    }
                    catch { btn1.Value = 1; }
                    try
                    {
                        btn2.Value = (decimal)Config.Instance.RightTarySet[value];
                    }
                    catch { btn2.Value = 1; }
                    try
                    {
                        btn3.Value = (decimal)Config.Instance.RightTarySet1[value];
                    }
                    catch { btn3.Value = 1; }
                    value--;
                    btn.ValueChanged += new System.EventHandler(this.label_Click);
                    btn1.ValueChanged += new System.EventHandler(this.label_Click);
                    btn2.ValueChanged += new System.EventHandler(this.label_Click);
                    btn3.ValueChanged += new System.EventHandler(this.label_Click);
                    if(0 == Global.BigTray.Direction)
                    {
                        tpl1.Controls.Add(btn, j, i);
                        tpl2.Controls.Add(btn1, j, i);
                        tpl3.Controls.Add(btn2, j, i);
                        tpl4.Controls.Add(btn3, j, i);
                    }
                    else
                    {
                        tpl1.Controls.Add(btn, i, j);
                        tpl2.Controls.Add(btn1, i, j);
                        tpl3.Controls.Add(btn2, i, j);
                        tpl4.Controls.Add(btn3, i, j);
                    }
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            NumericUpDown btn = (NumericUpDown)sender;
            try
            {
                int tmp = Convert.ToInt32(btn.Value);
                var x = Array.IndexOf(Config.Instance.LeftTarySet, tmp);
                if (btn.Name.Contains("LeftOne"))
                {
                    var i = btn.Name.Split(',');
                    int i1 = Convert.ToInt32(i[1]);
                    Config.Instance.LeftTarySet[i1] = tmp;
                }
                if (btn.Name.Contains("LeftTwo"))
                {
                    var i = btn.Name.Split(',');
                    int i1 = Convert.ToInt32(i[1]);
                    Config.Instance.LeftTarySet1[i1] = tmp;
                }
                if (btn.Name.Contains("RightOne"))
                {
                    var i = btn.Name.Split(',');
                    int i1 = Convert.ToInt32(i[1]);                   
                    Config.Instance.RightTarySet[i1] = tmp;
                }
                if (btn.Name.Contains("RightTwo"))
                {
                    var i = btn.Name.Split(',');
                    int i1 = Convert.ToInt32(i[1]);
                    Config.Instance.RightTarySet1[i1] = tmp;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请正确输入数字");
                return;
            }
        }
        private void TarySetView_Load(object sender, EventArgs e)
        {
            init();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Global.TrayDataRefresh)
            {
                Global.TrayDataRefresh = true;
            }
        }
    }
}
