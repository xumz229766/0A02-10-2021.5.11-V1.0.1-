using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ToolKit;
namespace System.Tray
{
    public partial class uTrayPanel : UserControl
    {
        bool bFlag = false;//添加屏蔽标志
        bool bRemoveFlag = false;//移除屏蔽标志
        bool bShowModel = true;//显示模式
        Color backColor = Color.Black;//背景色
        private SynchronizationContext context = null;
        int Row = 3;
        int Col = 3;
        Tray t = null;
        public void SetTrayObj(Tray tray,Color initColor)
        {
            t = tray;
            Row = t.Row;
            Col = t.Column;
            SetLayout(initColor);
        }
        public bool BRemoveFlag
        {
            get { return bRemoveFlag; }
            set { bRemoveFlag = value;
               
            }
        }

        public bool BFlag
        {
            get { return bFlag; }
            set { bFlag = value; }
        }
        public bool BShowModel
        {
            get { return bShowModel; }
            set { bShowModel = value; }
        }
        public uTrayPanel()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
        }

        /// <summary>  
        /// 动态布局  
        /// </summary>  
        /// <param name="layoutPanel">布局面板</param>  
        /// <param name="Row">行</param>  
        /// <param name="Col">列</param>  
        private void DynamicLayout(TableLayoutPanel layoutPanel,Color bColor)
        {
            layoutPanel.Controls.Clear();
            layoutPanel.RowStyles.Clear();
            layoutPanel.ColumnStyles.Clear();
            layoutPanel.RowCount = Row+1;    //设置分成几行  
            float pRow = Convert.ToSingle((100 / Row).ToString("0.00"));
            float pColumn = Convert.ToSingle((100 / Col).ToString("0.00"));
            for (int i = 0; i < Row + 1; i++)
            {
                if (i == Row)
                {
                    layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 0));
                }
                else
                    layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            }
            layoutPanel.ColumnCount = Col + 1;    //设置分成几列  
            for (int i = 0; i < Col + 1; i++)
            {
                if (i == Col)
                {
                    layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0));
                }
                else
                {
                    layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                }
            }
            for (int i = 0; i < Row; i++)
            {

                for (int j = 0; j < Col; j++)
                {
                    Button btn = new Button();
                    btn.Anchor = AnchorStyles.None;
                    btn.Margin = new Padding(0, 0, 0, 0);
                    btn.Dock = DockStyle.Fill;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatStyle = FlatStyle.Flat;

                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Name = i.ToString()+"_"+j.ToString();
                    Index pos = new Index(i, j);                   
                    int num = t.FindPos(pos);
                    if(num > -1)
                     t.dic_Index[num].SetColor(bColor);//初始化颜色
                    //如果是显示模式
                    if (bShowModel)
                    {                      
                        //屏蔽的点不显示名称
                        if (num < 0)
                        {
                            btn.Text = "";
                            SetBtnColor(btn, backColor);
                        }
                        else
                        {
                            //不屏蔽的点显示顺序号
                            btn.Text = num.ToString();
                            SetBtnColor(btn, bColor);
                        }

                    }
                    else
                    {
                        if (num < 0)
                        {
                            SetBtnColor(btn, backColor);
                        }
                        else {

                            SetBtnColor(btn,bColor);
                        }
                        btn.Text = i.ToString() + "," + j.ToString();
                       
                    }
                   
                    btn.Click += new EventHandler(this.label_Click);
                    layoutPanel.Controls.Add(btn,j,i);
                }
               
            }
        }
        private void SetBtnColor(Button btn,Color color)
        {
            if (color == Color.Yellow)
            {
                btn.BackgroundImage = Properties.Resources.ball_yellow_b;

            }
            else if (color == Color.Green)
            {
                btn.BackgroundImage = Properties.Resources.ball_green_b;

            }
            else if (color == Color.Blue)
            {
                btn.BackgroundImage = Properties.Resources.ball_blue_b;
            }
            else if (color == Color.Red)
            {
                btn.BackgroundImage = Properties.Resources.ball_red_b;
            }
            else if (color == Color.Gray)
            {
                btn.BackgroundImage = Properties.Resources.ball_gray_b;
            }
            else
            {
                btn.BackgroundImage = null;
                btn.BackColor = color;
            }
        }
        public void SetLayout(Color bColor)
        {
            t.SortTray(t.StartPose,t.Direction,t.ChangeLineType);
            DynamicLayout(tableLayoutPanel1, bColor);
        }
       
        private void label_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var str = btn.Name.Split('_');
            var locate = new Coordinate();
            locate.Row = int.Parse(str[0]);
            locate.Column = int.Parse(str[1]);
            Locate = locate;
            if (bFlag && !bShowModel)
            {
                SetBtnColor(btn, backColor);
                t.AddEmptyPos(btn.Name);
            }
            if (bRemoveFlag && !bShowModel)
            {
                SetBtnColor(btn, Color.Blue);
                t.RemoveEmptyPos(btn.Name);
            }
        }
        public void CreateUnRegular1()
        {
            if (bShowModel)
                return;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++) {

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            var btn = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                            SetBtnColor(btn, backColor);
                            t.AddEmptyPos(btn.Name);
                        }
                        else {
                            var btn = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                            SetBtnColor(btn, Color.Blue);
                            t.RemoveEmptyPos(btn.Name);
                        }
                    }
                    else {
                        if (j % 2 == 1)
                        {
                            var btn = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                            SetBtnColor(btn, backColor);
                            t.AddEmptyPos(btn.Name);
                        }
                        else
                        {
                            var btn = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                            SetBtnColor(btn, Color.Blue);
                            t.RemoveEmptyPos(btn.Name);
                        }
                    }
                
                }
            }
        }
        public void CreateUnRegular2()
        {
            if (bShowModel)
                return;

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 1)
                        {
                            var btn = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                            SetBtnColor(btn, backColor);
                            t.AddEmptyPos(btn.Name);
                        }
                        else
                        {
                            var btn = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                            SetBtnColor(btn, Color.Blue);
                            t.RemoveEmptyPos(btn.Name);
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            var btn = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                            SetBtnColor(btn, backColor);
                            t.AddEmptyPos(btn.Name);
                        }
                        else
                        {
                            var btn = (Button)tableLayoutPanel1.GetControlFromPosition(j, i);
                            SetBtnColor(btn, Color.Blue);
                            t.RemoveEmptyPos(btn.Name);
                        }
                    }

                }
            }
        }
        public Coordinate Locate { get;private set; }
        public void UpdateColor()
        {
            context.Post(updateUI, null);
            
        }
        private void updateUI(object obj)
        {
            foreach (KeyValuePair<int, Index> pair in t.dic_Index)
            {
                int col = pair.Value.Col;
                int row = pair.Value.Row;
                var btn = (Button)tableLayoutPanel1.GetControlFromPosition(col, row);
                SetBtnColor(btn, pair.Value.color);
            }
        }             
    }
    public struct Coordinate
    {
        public int Row;
        public int Column;
    }
}
