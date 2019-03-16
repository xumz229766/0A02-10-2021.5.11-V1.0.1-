using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Motion.Interfaces;
namespace desay
{
    public partial class frmIOmonitor : Form
    {
        private IoPoint[] Input;
        private IoPoint[] Output;
        public frmIOmonitor()
        {
            InitializeComponent();
        }
        private void frmIOmonitor_Load(object sender, EventArgs e)
        {
            Input = new IoPoint[]
            {
                IoPoints.T0DI0,IoPoints.T0DI1,IoPoints.T0DI2,IoPoints.T0DI3,
                IoPoints.T0DI4,IoPoints.T0DI5,IoPoints.T0DI6,IoPoints.T0DI7,
                IoPoints.T0DI8,IoPoints.T0DI9,IoPoints.T0DI10,IoPoints.T0DI11,
                IoPoints.T0DI12,IoPoints.T0DI13,IoPoints.T0DI14,IoPoints.T0DI15,
                IoPoints.T1DI0,IoPoints.T1DI1,IoPoints.T1DI2,IoPoints.T1DI3,
                IoPoints.T1DI4,IoPoints.T1DI5,IoPoints.T1DI6,IoPoints.T1DI7,
                IoPoints.T1DI8,IoPoints.T1DI9,IoPoints.T1DI10,IoPoints.T1DI11,
                IoPoints.T1DI12,IoPoints.T1DI13,IoPoints.T1DI14,IoPoints.T1DI15,
                IoPoints.T2DI0,IoPoints.T2DI1,IoPoints.T2DI2,IoPoints.T2DI3,
                IoPoints.T2DI4,IoPoints.T2DI5,IoPoints.T2DI6,IoPoints.T2DI7,
                IoPoints.T2DI8,IoPoints.T2DI9,IoPoints.T2DI10,IoPoints.T2DI11,
                IoPoints.T2DI12,IoPoints.T2DI13,IoPoints.T2DI14,IoPoints.T2DI15,
                IoPoints.T3DI0,IoPoints.T3DI1,IoPoints.T3DI2,IoPoints.T3DI3,
                IoPoints.T3DI4,IoPoints.T3DI5,IoPoints.T3DI6,IoPoints.T3DI7,
                IoPoints.T3DI8,IoPoints.T3DI9,IoPoints.T3DI10,IoPoints.T3DI11,
                IoPoints.T3DI12,IoPoints.T3DI13,IoPoints.T3DI14,IoPoints.T3DI15
            };
            Output = new IoPoint[]
            {
                IoPoints.T0DO0,IoPoints.T0DO1,IoPoints.T0DO2,IoPoints.T0DO3,
                IoPoints.T0DO4,IoPoints.T0DO5,IoPoints.T0DO6,IoPoints.T0DO7,
                IoPoints.T0DO8,IoPoints.T0DO9,IoPoints.T0DO10,IoPoints.T0DO11,
                IoPoints.T0DO12,IoPoints.T0DO13,IoPoints.T0DO14,IoPoints.T0DO15,
                IoPoints.T1DO0,IoPoints.T1DO1,IoPoints.T1DO2,IoPoints.T1DO3,
                IoPoints.T1DO4,IoPoints.T1DO5,IoPoints.T1DO6,IoPoints.T1DO7,
                IoPoints.T1DO8,IoPoints.T1DO9,IoPoints.T1DO10,IoPoints.T1DO11,
                IoPoints.T1DO12,IoPoints.T1DO13,IoPoints.T1DO14,IoPoints.T1DO15,
                IoPoints.T2DO0,IoPoints.T2DO1,IoPoints.T2DO2,IoPoints.T2DO3,
                IoPoints.T2DO4,IoPoints.T2DO5,IoPoints.T2DO6,IoPoints.T2DO7,
                IoPoints.T2DO8,IoPoints.T2DO9,IoPoints.T2DO10,IoPoints.T2DO11,
                IoPoints.T2DO12,IoPoints.T2DO13,IoPoints.T2DO14,IoPoints.T2DO15,
                IoPoints.T3DO0,IoPoints.T3DO1,IoPoints.T3DO2,IoPoints.T3DO3,
                IoPoints.T3DO4,IoPoints.T3DO5,IoPoints.T3DO6,IoPoints.T3DO7,
                IoPoints.T3DO8,IoPoints.T3DO9,IoPoints.T3DO10,IoPoints.T3DO11,
                IoPoints.T3DO12,IoPoints.T3DO13,IoPoints.T3DO14,IoPoints.T3DO15
              
            };
            InitdgvInputViewRows();
            InitdgvOutputViewRows();
            timer1.Enabled = true;
        }
        private void InitdgvInputViewRows()
        {
            this.dgvInputView.Rows.Clear();
            //in a real scenario, you may need to add different rows
            var i = 1;
            foreach (var di in Input)
            {
                dgvInputView.Rows.Add(new object[] {
                    i.ToString(),
                    di.Value?Properties.Resources.LedGreen:Properties.Resources.LedNone,
                    di.Name,
                    di.Description
                });
                i++;
            }
        }
        private void InitdgvOutputViewRows()
        {
            this.dgvOutputView.Rows.Clear();
            //in a real scenario, you may need to add different rows
            var i = 1;
            foreach (var DO in Output)
            {
                dgvOutputView.Rows.Add(new object[] {
                    i.ToString(),
                    DO.Value?Properties.Resources.LedGreen:Properties.Resources.LedNone,
                    DO.Name,
                    DO.Description
                });
                i++;
            }
        }
        private void refreshdgvInputViewRows()
        {
            //in a real scenario, you may need to add different rows
            var i = 1;
            foreach (var DI in Input)
            {
                dgvInputView.Rows[i-1].SetValues(new object[] {
                    i.ToString(),
                    DI.Value?Properties.Resources.LedGreen:Properties.Resources.LedNone,
                    DI.Name,
                    DI.Description
                });
                i++;
            }
        }
        private void refreshdgvOutputViewRows()
        {
            //in a real scenario, you may need to add different rows
            var i = 1;
            foreach (var DO in Output)
            {
                dgvOutputView.Rows[i - 1].SetValues(new object[] {
                    i.ToString(),
                    DO.Value?Properties.Resources.LedGreen:Properties.Resources.LedNone,
                    DO.Name,
                    DO.Description
                });
                i++;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            refreshdgvInputViewRows();
            refreshdgvOutputViewRows();
            timer1.Enabled = true;
        }
    }
}
