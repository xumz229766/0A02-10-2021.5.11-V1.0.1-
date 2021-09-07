using System;
using System.Windows.Forms;
using System.Enginee;

namespace desay
{
    public partial class TricolorLampSet : UserControl
    {

        public TricolorLampSet()
        {
            InitializeComponent();
        }

        private void TricolorLampSet_Load(object sender, EventArgs e)
        {
            switch (Config.Instance.RunSturs.isGreen)
            {
                case light.常亮:
                    btnRunStursGreen.Image = Properties.Resources.LedGreen;
                    break;
                case light.闪烁:
                    btnRunStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnRunStursGreen.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.RunSturs.isYellow)
            {
                case light.常亮:
                    btnRunStursYellow.Image = Properties.Resources.LedYellow;
                    break;
                case light.闪烁:
                    btnRunStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnRunStursYellow.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.RunSturs.isRed)
            {
                case light.常亮:
                    btnRunStursRed.Image = Properties.Resources.LedRed;
                    break;
                case light.闪烁:
                    btnRunStursRed.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnRunStursRed.Image = Properties.Resources.LedNone;
                    break;
            }
            ckbbtnRunSturs.Text = Config.Instance.RunSturs.Buzzer.ToString();
            switch (Config.Instance.ErrSturs.isGreen)
            {
                case light.常亮:
                    btnErrStursGreen.Image = Properties.Resources.LedGreen;
                    break;
                case light.闪烁:
                    btnErrStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnErrStursGreen.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.ErrSturs.isYellow)
            {
                case light.常亮:
                    btnErrStursYellow.Image = Properties.Resources.LedYellow;
                    break;
                case light.闪烁:
                    btnErrStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnErrStursYellow.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.ErrSturs.isRed)
            {
                case light.常亮:
                    btnErrStursRed.Image = Properties.Resources.LedRed;
                    break;
                case light.闪烁:
                    btnErrStursRed.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnErrStursRed.Image = Properties.Resources.LedNone;
                    break;
            }
            ckbErrSturs.Text = Config.Instance.ErrSturs.Buzzer.ToString();
            switch (Config.Instance.SuspendSturs.isGreen)
            {
                case light.常亮:
                    btnPuseStursGreen.Image = Properties.Resources.LedGreen;
                    break;
                case light.闪烁:
                    btnPuseStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnPuseStursGreen.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.SuspendSturs.isYellow)
            {
                case light.常亮:
                    btnPuseStursYellow.Image = Properties.Resources.LedYellow;
                    break;
                case light.闪烁:
                    btnPuseStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnPuseStursYellow.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.SuspendSturs.isRed)
            {
                case light.常亮:
                    btnPuseStursRed.Image = Properties.Resources.LedRed;
                    break;
                case light.闪烁:
                    btnPuseStursRed.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnPuseStursRed.Image = Properties.Resources.LedNone;
                    break;
            }
            ckbPuseSturs.Text = Config.Instance.SuspendSturs.Buzzer.ToString();
            switch (Config.Instance.ResetSturs.isGreen)
            {
                case light.常亮:
                    btnResetStursGreen.Image = Properties.Resources.LedGreen;
                    break;
                case light.闪烁:
                    btnResetStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnResetStursGreen.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.ResetSturs.isYellow)
            {
                case light.常亮:
                    btnResetStursYellow.Image = Properties.Resources.LedYellow;
                    break;
                case light.闪烁:
                    btnResetStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnResetStursYellow.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.ResetSturs.isRed)
            {
                case light.常亮:
                    btnResetStursRed.Image = Properties.Resources.LedRed;
                    break;
                case light.闪烁:
                    btnResetStursRed.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnResetStursRed.Image = Properties.Resources.LedNone;
                    break;
            }
            ckbResetSturs.Text = Config.Instance.ResetSturs.Buzzer.ToString();
            switch (Config.Instance.StopSturs.isGreen)
            {
                case light.常亮:
                    btnStopStursGreen.Image = Properties.Resources.LedGreen;
                    break;
                case light.闪烁:
                    btnStopStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnStopStursGreen.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.StopSturs.isYellow)
            {
                case light.常亮:
                    btnStopStursYellow.Image = Properties.Resources.LedYellow;
                    break;
                case light.闪烁:
                    btnStopStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnStopStursYellow.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.StopSturs.isRed)
            {
                case light.常亮:
                    btnStopStursRed.Image = Properties.Resources.LedRed;
                    break;
                case light.闪烁:
                    btnStopStursRed.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnStopStursRed.Image = Properties.Resources.LedNone;
                    break;
            }
            ckbStopSturs.Text = Config.Instance.StopSturs.Buzzer.ToString();
            switch (Config.Instance.WarningSturs.isGreen)
            {
                case light.常亮:
                    btnWarningStursGreen.Image = Properties.Resources.LedGreen;
                    break;
                case light.闪烁:
                    btnWarningStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnWarningStursGreen.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.WarningSturs.isYellow)
            {
                case light.常亮:
                    btnWarningStursYellow.Image = Properties.Resources.LedYellow;
                    break;
                case light.闪烁:
                    btnWarningStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnWarningStursYellow.Image = Properties.Resources.LedNone;
                    break;
            }
            switch (Config.Instance.WarningSturs.isRed)
            {
                case light.常亮:
                    btnWarningStursRed.Image = Properties.Resources.LedRed;
                    break;
                case light.闪烁:
                    btnWarningStursRed.Image = Properties.Resources.IO;
                    break;
                case light.常灭:
                    btnWarningStursRed.Image = Properties.Resources.LedNone;
                    break;
            }
            ckbWarningSturs.Text = Config.Instance.WarningSturs.Buzzer.ToString();

        }

        private void BtnRunStursGreen_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.RunSturs.isGreen)
            {
                case light.常亮:
                    Config.Instance.RunSturs.isGreen = light.闪烁;
                    btnRunStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.RunSturs.isGreen = light.常灭;
                    btnRunStursGreen.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.RunSturs.isGreen = light.常亮;
                    btnRunStursGreen.Image = Properties.Resources.LedGreen;
                    break;
            }

        }

        private void BtnRunStursYellow_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.RunSturs.isYellow)
            {
                case light.常亮:
                    Config.Instance.RunSturs.isYellow = light.闪烁;
                    btnRunStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.RunSturs.isYellow = light.常灭;
                    btnRunStursYellow.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.RunSturs.isYellow = light.常亮;
                    btnRunStursYellow.Image = Properties.Resources.LedYellow;
                    break;
            }

        }

        private void BtnRunStursRed_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.RunSturs.isRed)
            {
                case light.常亮:
                    Config.Instance.RunSturs.isRed = light.闪烁;
                    btnRunStursRed.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.RunSturs.isRed = light.常灭;
                    btnRunStursRed.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.RunSturs.isRed = light.常亮;
                    btnRunStursRed.Image = Properties.Resources.LedRed;
                    break;
            }

        }

        private void CkbbtnRunSturs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ckbbtnRunSturs.Text)
            {
                case "静音":
                    Config.Instance.RunSturs.Buzzer = Buzzer.静音;
                    break;
                case "长音":
                    Config.Instance.RunSturs.Buzzer = Buzzer.长音;
                    break;
                case "间隔音":
                    Config.Instance.RunSturs.Buzzer = Buzzer.间隔音;
                    break;
            }
        }

        private void BtnErrStursGreen_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.ErrSturs.isGreen)
            {
                case light.常亮:
                    Config.Instance.ErrSturs.isGreen = light.闪烁;
                    btnErrStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.ErrSturs.isGreen = light.常灭;
                    btnErrStursGreen.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.ErrSturs.isGreen = light.常亮;
                    btnErrStursGreen.Image = Properties.Resources.LedGreen;
                    break;
            }

        }

        private void BtnErrStursYellow_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.ErrSturs.isYellow)
            {
                case light.常亮:
                    Config.Instance.ErrSturs.isYellow = light.闪烁;
                    btnErrStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.ErrSturs.isYellow = light.常灭;
                    btnErrStursYellow.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.ErrSturs.isYellow = light.常亮;
                    btnErrStursYellow.Image = Properties.Resources.LedYellow;
                    break;
            }

        }

        private void BtnErrStursRed_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.ErrSturs.isRed)
            {
                case light.常亮:
                    Config.Instance.ErrSturs.isRed = light.闪烁;
                    btnErrStursRed.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.ErrSturs.isRed = light.常灭;
                    btnErrStursRed.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.ErrSturs.isRed = light.常亮;
                    btnErrStursRed.Image = Properties.Resources.LedRed;
                    break;
            }

        }

        private void CkbErrSturs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ckbErrSturs.Text)
            {
                case "静音":
                    Config.Instance.ErrSturs.Buzzer = Buzzer.静音;
                    break;
                case "长音":
                    Config.Instance.ErrSturs.Buzzer = Buzzer.长音;
                    break;
                case "间隔音":
                    Config.Instance.ErrSturs.Buzzer = Buzzer.间隔音;
                    break;
            }
        }

        private void BtnPuseStursGreen_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.SuspendSturs.isGreen)
            {
                case light.常亮:
                    Config.Instance.SuspendSturs.isGreen = light.闪烁;
                    btnPuseStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.SuspendSturs.isGreen = light.常灭;
                    btnPuseStursGreen.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.SuspendSturs.isGreen = light.常亮;
                    btnPuseStursGreen.Image = Properties.Resources.LedGreen;
                    break;
            }

        }

        private void BtnPuseStursYellow_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.SuspendSturs.isYellow)
            {
                case light.常亮:
                    Config.Instance.SuspendSturs.isYellow = light.闪烁;
                    btnPuseStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.SuspendSturs.isYellow = light.常灭;
                    btnPuseStursYellow.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.SuspendSturs.isYellow = light.常亮;
                    btnPuseStursYellow.Image = Properties.Resources.LedYellow;
                    break;
            }

        }

        private void BtnPuseStursRed_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.SuspendSturs.isRed)
            {
                case light.常亮:
                    Config.Instance.SuspendSturs.isRed = light.闪烁;
                    btnPuseStursRed.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.SuspendSturs.isRed = light.常灭;
                    btnPuseStursRed.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.SuspendSturs.isRed = light.常亮;
                    btnPuseStursRed.Image = Properties.Resources.LedRed;
                    break;
            }

        }

        private void CkbPuseSturs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ckbPuseSturs.Text)
            {
                case "静音":
                    Config.Instance.SuspendSturs.Buzzer = Buzzer.静音;
                    break;
                case "长音":
                    Config.Instance.SuspendSturs.Buzzer = Buzzer.长音;
                    break;
                case "间隔音":
                    Config.Instance.SuspendSturs.Buzzer = Buzzer.间隔音;
                    break;
            }
        }

        private void BtnStopStursGreen_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.StopSturs.isGreen)
            {
                case light.常亮:
                    Config.Instance.StopSturs.isGreen = light.闪烁;
                    btnStopStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.StopSturs.isGreen = light.常灭;
                    btnStopStursGreen.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.StopSturs.isGreen = light.常亮;
                    btnStopStursGreen.Image = Properties.Resources.LedGreen;
                    break;
            }

        }

        private void BtnStopStursYellow_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.StopSturs.isYellow)
            {
                case light.常亮:
                    Config.Instance.StopSturs.isYellow = light.闪烁;
                    btnStopStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.StopSturs.isYellow = light.常灭;
                    btnStopStursYellow.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.StopSturs.isYellow = light.常亮;
                    btnStopStursYellow.Image = Properties.Resources.LedYellow;
                    break;
            }

        }

        private void BtnStopStursRed_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.StopSturs.isRed)
            {
                case light.常亮:
                    Config.Instance.StopSturs.isRed = light.闪烁;
                    btnStopStursRed.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.StopSturs.isRed = light.常灭;
                    btnStopStursRed.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.StopSturs.isRed = light.常亮;
                    btnStopStursRed.Image = Properties.Resources.LedRed;
                    break;
            }
        }

        private void CkbStopSturs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ckbStopSturs.Text)
            {
                case "静音":
                    Config.Instance.StopSturs.Buzzer = Buzzer.静音;
                    break;
                case "长音":
                    Config.Instance.StopSturs.Buzzer = Buzzer.长音;
                    break;
                case "间隔音":
                    Config.Instance.StopSturs.Buzzer = Buzzer.间隔音;
                    break;
            }
        }

        private void BtnWarningStursGreen_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.WarningSturs.isGreen)
            {
                case light.常亮:
                    Config.Instance.WarningSturs.isGreen = light.闪烁;
                    btnWarningStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.WarningSturs.isGreen = light.常灭;
                    btnWarningStursGreen.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.WarningSturs.isGreen = light.常亮;
                    btnWarningStursGreen.Image = Properties.Resources.LedGreen;
                    break;
            }

        }

        private void BtnWarningStursYellow_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.WarningSturs.isYellow)
            {
                case light.常亮:
                    Config.Instance.WarningSturs.isYellow = light.闪烁;
                    btnWarningStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.WarningSturs.isYellow = light.常灭;
                    btnWarningStursYellow.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.WarningSturs.isYellow = light.常亮;
                    btnWarningStursYellow.Image = Properties.Resources.LedYellow;
                    break;
            }

        }

        private void BtnWarningStursRed_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.WarningSturs.isRed)
            {
                case light.常亮:
                    Config.Instance.WarningSturs.isRed = light.闪烁;
                    btnWarningStursRed.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.WarningSturs.isRed = light.常灭;
                    btnWarningStursRed.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.WarningSturs.isRed = light.常亮;
                    btnWarningStursRed.Image = Properties.Resources.LedRed;
                    break;
            }

        }

        private void CkbWarningSturs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ckbWarningSturs.Text)
            {
                case "静音":
                    Config.Instance.WarningSturs.Buzzer = Buzzer.静音;
                    break;
                case "长音":
                    Config.Instance.WarningSturs.Buzzer = Buzzer.长音;
                    break;
                case "间隔音":
                    Config.Instance.WarningSturs.Buzzer = Buzzer.间隔音;
                    break;
            }
        }

        private void BtnResetStursGreen_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.ResetSturs.isGreen)
            {
                case light.常亮:
                    Config.Instance.ResetSturs.isGreen = light.闪烁;
                    btnResetStursGreen.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.ResetSturs.isGreen = light.常灭;
                    btnResetStursGreen.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.ResetSturs.isGreen = light.常亮;
                    btnResetStursGreen.Image = Properties.Resources.LedGreen;
                    break;
            }

        }

        private void BtnResetStursYellow_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.ResetSturs.isYellow)
            {
                case light.常亮:
                    Config.Instance.ResetSturs.isYellow = light.闪烁;
                    btnResetStursYellow.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.ResetSturs.isYellow = light.常灭;
                    btnResetStursYellow.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.ResetSturs.isYellow = light.常亮;
                    btnResetStursYellow.Image = Properties.Resources.LedYellow;
                    break;
            }

        }

        private void BtnResetStursRed_Click(object sender, EventArgs e)
        {
            switch (Config.Instance.ResetSturs.isRed)
            {
                case light.常亮:
                    Config.Instance.ResetSturs.isRed = light.闪烁;
                    btnResetStursRed.Image = Properties.Resources.IO;
                    break;
                case light.闪烁:
                    Config.Instance.ResetSturs.isRed = light.常灭;
                    btnResetStursRed.Image = Properties.Resources.LedNone;
                    break;
                case light.常灭:
                    Config.Instance.ResetSturs.isRed = light.常亮;
                    btnResetStursRed.Image = Properties.Resources.LedRed;
                    break;
            }
        }

        private void CkbResetSturs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ckbResetSturs.Text)
            {
                case "静音":
                    Config.Instance.ResetSturs.Buzzer = Buzzer.静音;
                    break;
                case "长音":
                    Config.Instance.ResetSturs.Buzzer = Buzzer.长音;
                    break;
                case "间隔音":
                    Config.Instance.ResetSturs.Buzzer = Buzzer.间隔音;
                    break;
            }
        }
    }
}
