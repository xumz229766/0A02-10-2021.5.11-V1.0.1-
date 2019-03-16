using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Motion.Enginee;
using System.Threading;

namespace desay
{
    public partial class frmTeach : Form
    {
        PositionName name = 0;
        private Splice m_Splice;
        private Buffer m_Buffer;
        private Feeder m_Feeder;
        private Move m_Move;
        private LeftC m_LeftC;
        private MiddleC m_MiddleC;
        private RightC m_RightC;
        private LeftCut1 m_LeftCut1;
        private LeftCut2 m_LeftCut2;
        private RightCut1 m_RightCut1;
        private RightCut2 m_RightCut2;
        private Platform m_Platform;
        private Storing m_Storing;

        #region 控件

        Panel m_PanelJogType,m_panelOperate;
        MoveSelectHorizontal moveselect;
        MLayerView<double> mLayerView;

        PositionDefaultView defaultView;

        Position1DView<double> YWaitPositionView;
        Position1DView<double> ZWaitPositionView;
        Position1DView<double> YGetPlatePositionView;

        //Position2DView<double> UpCameraPositionView;
        //Position2DView<double> UpCameraBasePosView;
        Position2DView<double> InhalePositionView;
        //Position2DView<double> DownCameraPositionView;
        Position2DView<double> NGproductPositionView;

        Position3DView<double> PlateBasePositionView;

        #endregion

        public frmTeach()
        {
            InitializeComponent();
        }

        public frmTeach(Splice Splice, Buffer Buffer, Feeder Feeder, Move Move, LeftC LeftC, MiddleC MiddleC, RightC RightC,
           LeftCut1 LeftCut1, LeftCut2 LeftCut2, RightCut1 RightCut1, RightCut2 RightCut2, Platform Platform, Storing Storing) : this()
        {
            m_Splice = Splice;
            m_Buffer = Buffer;
            m_Feeder = Feeder;
            m_Move = Move;
            m_LeftC = LeftC;
            m_MiddleC = MiddleC;
            m_RightC = RightC;
            m_LeftCut1 = LeftCut1;
            m_LeftCut2 = LeftCut2;
            m_RightCut1 = RightCut1;
            m_RightCut2 = RightCut2;
            m_Platform = Platform;
            m_Storing = Storing;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "O_Ring组装设备") return;

            foreach (TreeNode node in treeView1.Nodes[0].Nodes)
            {
                if (node.Text == e.Node.Text)
                {
                    node.ForeColor = Color.White;
                    node.BackColor = Color.DodgerBlue;
                }
                else
                {
                    node.ForeColor = Color.Black;
                    node.BackColor = Color.Transparent;
                }
            }

            var nodetext = (PositionName)Enum.Parse(typeof(PositionName), e.Node.Text);
            panelVeiw.Controls.Clear();
            m_panelOperate.Controls.Clear();

            m_PanelJogType.Controls.Add(moveselect);
            panelVeiw.Controls.Add(m_PanelJogType, 0, 0);

            switch (nodetext)
            {
                case PositionName.吸料位置:
                    m_panelOperate.Controls.Add(InhalePositionView); 
                    panelVeiw.Controls.Add(m_panelOperate, 0, 1);
                    break;
                case PositionName.NG料排放位置:
                    m_panelOperate.Controls.Add(NGproductPositionView);
                    panelVeiw.Controls.Add(m_panelOperate, 0, 1);
                    break;
                case PositionName.Y轴取盘位置:
                    m_panelOperate.Controls.Add(YGetPlatePositionView);
                    panelVeiw.Controls.Add(m_panelOperate, 0, 1);
                    break;
                case PositionName.Y轴等待位置:
                    m_panelOperate.Controls.Add(YWaitPositionView);
                    panelVeiw.Controls.Add(m_panelOperate, 0, 1);
                    break;
                case PositionName.Z轴等待位置:
                    m_panelOperate.Controls.Add(ZWaitPositionView);
                    panelVeiw.Controls.Add(m_panelOperate, 0, 1);
                    break;
                case PositionName.托盘基准位置:
                    m_panelOperate.Controls.Add(PlateBasePositionView);
                    panelVeiw.Controls.Add(m_panelOperate, 0, 1);
                    break;
                case PositionName.料仓位置:
                    m_panelOperate.Controls.Add(mLayerView);
                    m_panelOperate.Dock = DockStyle.Fill;
                    panelVeiw.Controls.Add(m_panelOperate, 0, 1);
                    break;
                default:
                    panelVeiw.Controls.Add(defaultView);
                    break;
            }
            name = nodetext;
        }

        private void frmTeach_Load(object sender, EventArgs e)
        {
            defaultView = new PositionDefaultView();

            mLayerView = new MLayerView<double>(m_Plateform.Maxis)
            {
                Dock = DockStyle.Fill
            };

            InhalePositionView = new Position2DView<double>(new ApsAxis[] { m_Plateform.Xaxis, m_Plateform.Zaxis }, () =>
            {
                Config.Instance.InhalePosition.X = InhalePositionView.Point[0];
                Config.Instance.InhalePosition.Z = InhalePositionView.Point[1];
            }, () => 
            {
                int step = 0;
                while (true)
                {
                    if (ServoAxisIsReady(m_Plateform.Xaxis) || ServoAxisIsReady(m_Plateform.Zaxis)) return;
                    if (step == 0)
                    {
                        m_Plateform.Zaxis.MoveTo(Config.Instance.ZWaitPosition, AxisParameter.Instance.ZVelocityCurve);
                        step = 10;
                    }
                    if (step == 10)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Config.Instance.ZWaitPosition))
                        {
                            m_Plateform.Xaxis.MoveTo(Config.Instance.InhalePosition.X, AxisParameter.Instance.XVelocityCurve);
                            step = 20;
                        }
                    }
                    if (step == 20)
                    {
                        if (m_Plateform.Xaxis.IsInPosition(Config.Instance.InhalePosition.X))
                        {
                            m_Plateform.Zaxis.MoveTo(Config.Instance.InhalePosition.Z, AxisParameter.Instance.ZVelocityCurve);
                            step = 30;
                        }
                    }
                    if (step == 30)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Config.Instance.InhalePosition.Z))
                        {
                            break;
                        }
                    }
                    Thread.Sleep(50);
                }
            })
            {
                Point = new double[] { Config.Instance.InhalePosition.X, Config.Instance.InhalePosition.Z },
                Dock = DockStyle.Fill
            };
            NGproductPositionView = new Position2DView<double>(new ApsAxis[] { m_Plateform.Xaxis, m_Plateform.Zaxis }, () =>
            {
                Config.Instance.NGproductPosition.X = NGproductPositionView.Point[0];
                Config.Instance.NGproductPosition.Z = NGproductPositionView.Point[1];
            }, () =>
            {
                int step = 0;
                while (true)
                {
                    if (ServoAxisIsReady(m_Plateform.Xaxis) || ServoAxisIsReady(m_Plateform.Zaxis)) return;
                    if (step == 0)
                    {
                        m_Plateform.Zaxis.MoveTo(Config.Instance.ZWaitPosition, AxisParameter.Instance.ZVelocityCurve);
                        step = 10;
                    }
                    if (step == 10)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Config.Instance.ZWaitPosition))
                        {
                            m_Plateform.Xaxis.MoveTo(Config.Instance.NGproductPosition.X, AxisParameter.Instance.XVelocityCurve);
                            step = 20;
                        }
                    }
                    if (step == 20)
                    {
                        if (m_Plateform.Xaxis.IsInPosition(Config.Instance.NGproductPosition.X))
                        {
                            m_Plateform.Zaxis.MoveTo(Config.Instance.NGproductPosition.Z, AxisParameter.Instance.ZVelocityCurve);
                            step = 30;
                        }
                    }
                    if (step == 30)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Config.Instance.NGproductPosition.Z))
                        {
                            break;
                        }
                    }
                    Thread.Sleep(50);
                }
            })
            {
                Point = new double[] { Config.Instance.NGproductPosition.X, Config.Instance.NGproductPosition.Z },
                Dock = DockStyle.Fill
            };

            PlateBasePositionView = new Position3DView<double>(new ApsAxis[] { m_Plateform.Xaxis, m_Plateform.Yaxis, m_Plateform.Zaxis }, () =>
            {
                Position.Instance.PlateBasePosition.X = PlateBasePositionView.Point[0];
                Position.Instance.PlateBasePosition.Y = PlateBasePositionView.Point[1];
                Position.Instance.PlateBasePosition.Z = PlateBasePositionView.Point[2];
            }, () =>
            {
                int step = 0;
                while (true)
                {
                    if (ServoAxisIsReady(m_Plateform.Xaxis) || ServoAxisIsReady(m_Plateform.Yaxis) || ServoAxisIsReady(m_Plateform.Zaxis)) return;
                    if (step == 0)
                    {
                        m_Plateform.Zaxis.MoveTo(Config.Instance.ZWaitPosition, AxisParameter.Instance.ZVelocityCurve);
                        step = 10;
                    }
                    if (step == 10)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Config.Instance.ZWaitPosition))
                        {
                            m_Plateform.Xaxis.MoveTo(Position.Instance.PlateBasePosition.X, AxisParameter.Instance.XVelocityCurve);
                            m_Plateform.Yaxis.MoveTo(Position.Instance.PlateBasePosition.Y, AxisParameter.Instance.YVelocityCurve);
                            step = 20;
                        }
                    }
                    if (step == 20)
                    {
                        if (m_Plateform.Xaxis.IsInPosition(Position.Instance.PlateBasePosition.X)
                        && m_Plateform.Yaxis.IsInPosition(Position.Instance.PlateBasePosition.Y))
                        {
                            m_Plateform.Zaxis.MoveTo(Position.Instance.PlateBasePosition.Z, AxisParameter.Instance.ZVelocityCurve);
                            step = 30;
                        }
                    }
                    if (step == 30)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Position.Instance.PlateBasePosition.Z))
                        {
                            break;
                        }
                    }
                    Thread.Sleep(50);
                }
            })
            {
                Point = new double[] { Position.Instance.PlateBasePosition.X, Position.Instance.PlateBasePosition.Y, Position.Instance.PlateBasePosition.Z },
                Dock = DockStyle.Fill
            };

            YWaitPositionView = new Position1DView<double>(new ApsAxis[] { m_Plateform.Yaxis }, () =>
            {
                Position.Instance.YWaitPosition = YWaitPositionView.Point[0];
            }, () =>
            {
                int step = 0;
                while (true)
                {
                    if (ServoAxisIsReady(m_Plateform.Yaxis) || ServoAxisIsReady(m_Plateform.Zaxis)) return;
                    if (step == 0)
                    {
                        m_Plateform.Zaxis.MoveTo(Config.Instance.ZWaitPosition, AxisParameter.Instance.ZVelocityCurve);
                        step = 10;
                    }
                    if (step == 10)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Config.Instance.ZWaitPosition))
                        {
                            m_Plateform.Yaxis.MoveTo(Position.Instance.YWaitPosition, AxisParameter.Instance.YVelocityCurve);
                            step = 20;
                        }
                    }
                    if (step == 20)
                    {
                        if (m_Plateform.Yaxis.IsInPosition(Position.Instance.YWaitPosition))
                        {
                            break;
                        }
                    }
                    Thread.Sleep(50);
                }
            })
            {
                Point = new double[] { Position.Instance.YWaitPosition },
                Dock = DockStyle.Fill
            };


            ZWaitPositionView = new Position1DView<double>(new ApsAxis[] { m_Plateform.Zaxis }, () =>
            {
                Config.Instance.ZWaitPosition = ZWaitPositionView.Point[0];
            }, () =>
            {
                int step = 0;
                while (true)
                {
                    if (ServoAxisIsReady(m_Plateform.Zaxis)) return;
                    if (step == 0)
                    {
                        m_Plateform.Zaxis.MoveTo(Config.Instance.ZWaitPosition, AxisParameter.Instance.ZVelocityCurve);
                        step = 10;
                    }
                    if (step == 10)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Config.Instance.ZWaitPosition))
                        {
                            break;
                        }
                    }
                }
                Thread.Sleep(50);
            })
            {
                Point = new double[] { Config.Instance.ZWaitPosition },
                Dock = DockStyle.Fill
            };

            YGetPlatePositionView = new Position1DView<double>(new ApsAxis[] { m_Plateform.Yaxis }, () =>
            {
                Position.Instance.YGetTrayPosition = YGetPlatePositionView.Point[0];
            }, () =>
            {
                int step = 0;
                while (true)
                {
                    if (ServoAxisIsReady(m_Plateform.Yaxis)) return;
                    if (step == 0)
                    {
                        m_Plateform.Zaxis.MoveTo(Config.Instance.ZWaitPosition, AxisParameter.Instance.ZVelocityCurve);
                        step = 10;
                    }
                    if (step == 10)
                    {
                        if (m_Plateform.Zaxis.IsInPosition(Config.Instance.ZWaitPosition))
                        {
                            m_Plateform.Yaxis.MoveTo(Position.Instance.YGetTrayPosition, AxisParameter.Instance.YVelocityCurve);
                            step = 20;
                        }
                    }
                    if (step == 20)
                    {
                        if (m_Plateform.Yaxis.IsInPosition(Position.Instance.YGetTrayPosition))
                        {
                            break;
                        }
                    }
                    Thread.Sleep(50);
                }
            })
            {
                Point = new double[] { Position.Instance.YGetTrayPosition },
                Dock = DockStyle.Fill
            };

            moveselect = new MoveSelectHorizontal();
            moveselect.Dock = DockStyle.Fill;

            m_PanelJogType = new Panel();
            m_PanelJogType.Size = new Size(133, 60);
            m_PanelJogType.Dock = DockStyle.Top;
            m_PanelJogType.Controls.Add(moveselect);

            m_panelOperate = new Panel();
            m_panelOperate.Dock = DockStyle.Fill;

            treeView1.Nodes.Add(Global.MACHINNAME);
            foreach(string str in Enum.GetNames(typeof(PositionName)))
            {
                treeView1.Nodes[0].Nodes.Add(str);
            }

            treeView1.ExpandAll();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            switch (name)
            {
                case PositionName.吸料位置:
                    InhalePositionView.MoveMode = moveselect.MoveMode;
                    InhalePositionView.Refreshing();
                    break;
                case PositionName.NG料排放位置:
                    NGproductPositionView.MoveMode = moveselect.MoveMode;
                    NGproductPositionView.Refreshing();
                    break;
                case PositionName.Y轴取盘位置:
                    YGetPlatePositionView.MoveMode = moveselect.MoveMode;
                    YGetPlatePositionView.Refreshing();
                    break;
                case PositionName.Y轴等待位置:
                    YWaitPositionView.MoveMode = moveselect.MoveMode;
                    YWaitPositionView.Refreshing();
                    break;
                case PositionName.Z轴等待位置:
                    ZWaitPositionView.MoveMode = moveselect.MoveMode;
                    ZWaitPositionView.Refreshing();
                    break;
                case PositionName.托盘基准位置:
                    PlateBasePositionView.MoveMode = moveselect.MoveMode;
                    PlateBasePositionView.Refreshing();
                    break;
                case PositionName.料仓位置:
                    mLayerView.MoveMode = moveselect.MoveMode;
                    mLayerView.Refreshing();
                    break;
                default:
                    break;
            }
            timer1.Enabled = true;
        }

        private bool ServoAxisIsReady(ServoAxis axis)
        {
            return !axis.IsServon || axis.IsAlarmed || axis.IsEmg || axis.IsMEL || axis.IsPEL;
        }

        public enum PositionName
        {
            吸料位置,
            NG料排放位置,
            Y轴取盘位置,
            Y轴等待位置,
            Z轴等待位置,
            托盘基准位置,
            料仓位置
        }
    }
}
