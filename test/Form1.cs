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
using System.ToolKit;
using System.ToolKit.Helper;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Tray LensTray, ConeTray;

        private void InitTray()
        {
            LensTray = TrayFactory.GetTrayFactory("1");
            ConeTray = TrayFactory.GetTrayFactory("P0606");
            palTary.Controls.Clear();
            palTary.ColumnCount = LensTray.Column;
            for (int i = 0; i < LensTray.Column; i++)
            {
                palTary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }
            palTary.RowCount = LensTray.Row;
            for (int i = 0; i < LensTray.Row; i++)
            {
                palTary.ColumnStyles.Add(new RowStyle(SizeType.Percent, 25F));
            }
            uTrayPanel[] ConeTrayDisplay = new uTrayPanel[LensTray.Column * LensTray.Row];//托盘显示
            if (ConeTray != null)
            {
                for (int i = 0; i < LensTray.Column * LensTray.Row; i++)
                {
                    ConeTrayDisplay[i] = new uTrayPanel();
                    ConeTrayDisplay[i].AutoSize = true;
                    ConeTrayDisplay[i].SetTrayObj(ConeTray, Color.Gray);
                    ConeTrayDisplay[i].Dock = DockStyle.Fill;
                    ConeTray.updateColor += ConeTrayDisplay[i].UpdateColor;                   
                }
                palTary.Controls.AddRange(ConeTrayDisplay);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            TrayFactory.LoadTrayFactory(AppConfig.ConfigTrayName);
            InitTray();


        }
    }
}
