using System;
using System.Windows.Forms;
using System.ToolKit;

namespace desay
{
    public partial class offcesValue : UserControl
    {

        public offcesValue(int i)
        {
            InitializeComponent();
            X = i;
        }
        private int X;
        private void OffcesValue_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = (decimal)Position.Instance.trayOffces[X].X * 1000;
            numericUpDown2.Value = (decimal)Position.Instance.trayOffces[X].Y * 1000;
            numericUpDown3.Value = (decimal)Position.Instance.trayOffces[X].Z * 1000;
            label1.Text = X.ToString() + "#位置";
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Position.Instance.trayOffces[X].X = Convert.ToDouble(numericUpDown1.Value / 1000);
            LogHelper.Info("偏移X更新");
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Position.Instance.trayOffces[X].Y = Convert.ToDouble(numericUpDown2.Value / 1000);
            LogHelper.Info("偏移Y更新");
        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Position.Instance.trayOffces[X].Z = Convert.ToDouble(numericUpDown3.Value / 1000);
            LogHelper.Info("偏移Z更新");
        }
    }
}
