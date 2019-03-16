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
namespace desay
{
    public partial class frmManualOperate : Form
    {
        StationName name = 0;
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

        Panel m_PanelJogType,m_PanelModelOperate;
        FlowLayoutPanel m_panelAxis, m_panelCylinder;
        MoveSelectHorizontal moveselect;
        PositionDefaultView PositionView;
        AxisOperate m_Xaxis,m_Yaxis, m_Zaxis, m_Maxis, m_Caxis;
        CylinderOperate m_InhaleOperate;

        ModelOperate m_ModelOperate;

        #endregion

        public frmManualOperate()
        {
            InitializeComponent();
        }

        public frmManualOperate(Splice Splice, Buffer Buffer, Feeder Feeder, Move Move, LeftC LeftC, MiddleC MiddleC, RightC RightC,
           LeftCut1 LeftCut1, LeftCut2 LeftCut2, RightCut1 RightCut1, RightCut2 RightCut2, Platform Platform, Storing Storing) :this()
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
            var nodetext = (StationName)Enum.Parse(typeof(StationName), e.Node.Text);
            panelVeiw.Controls.Clear();
            m_panelAxis.Controls.Clear();
            panelOperator.Controls.Clear();
            switch(nodetext)
            {
                case StationName.O_Ring组装设备:
                    panelVeiw.Controls.Add(PositionView, 0, 0);
                    break;
                case StationName.装配工位:
                    m_PanelJogType.Controls.Add(moveselect);
                    panelVeiw.Controls.Add(m_PanelJogType, 0, 0);
                    m_panelAxis.Controls.Add(m_Xaxis);
                    m_panelAxis.Controls.Add(m_Yaxis);
                    m_panelAxis.Controls.Add(m_Zaxis);
                    m_panelAxis.Controls.Add(m_Maxis);
                    panelVeiw.Controls.Add(m_panelAxis, 1, 0);
                    m_panelCylinder.Controls.Add(m_InhaleOperate);
                    panelVeiw.Controls.Add(m_panelCylinder, 2, 0);
                    m_PanelModelOperate.Controls.Add(m_ModelOperate);
                    panelOperator.Controls.Add(m_PanelModelOperate);
        
                    break;
                case StationName.送料工位:
                    m_PanelJogType.Controls.Add(moveselect);
                    panelVeiw.Controls.Add(m_PanelJogType, 0, 0);
                    m_panelAxis.Controls.Add(m_Caxis);
                    panelVeiw.Controls.Add(m_panelAxis, 1, 0);
                    m_PanelModelOperate.Controls.Add(m_ModelOperate);
                    panelOperator.Controls.Add(m_PanelModelOperate);
                    break;
                default:
                    break;
            }
            name = nodetext;
        }

        private void frmTeach_Load(object sender, EventArgs e)
        {
            PositionView = new PositionDefaultView();

            m_ModelOperate = new ModelOperate();
            m_ModelOperate.Dock = DockStyle.Fill;

            moveselect = new MoveSelectHorizontal();
            moveselect.Dock = DockStyle.Fill;

            m_PanelJogType = new Panel();
            m_PanelJogType.Size = new Size(133, 60);
            m_PanelJogType.Dock = DockStyle.Top;

            m_panelAxis = new FlowLayoutPanel();
            m_panelAxis.Dock = DockStyle.Fill;
            m_Xaxis = new AxisOperate(m_Plateform.Xaxis);
            m_Yaxis = new AxisOperate(m_Plateform.Yaxis);
            m_Zaxis = new AxisOperate(m_Plateform.Zaxis);
            m_Maxis = new AxisOperate(m_Plateform.Maxis);
            m_Caxis = new AxisOperate(m_Incoming.Caxis);

            m_panelCylinder = new FlowLayoutPanel();
            m_panelCylinder.Dock = DockStyle.Fill;
            m_InhaleOperate = new CylinderOperate(() => m_Plateform.InhaleCylinder.ManualExecute()) { CylinderName = m_Plateform.InhaleCylinder.Name };

            m_PanelModelOperate = new Panel();
            m_PanelModelOperate.Size = new Size(133, 60);
            m_PanelModelOperate.Dock = DockStyle.Bottom;

            treeView1.Nodes.Add(StationName.O_Ring组装设备.ToString());
            treeView1.Nodes[0].Nodes.Add(StationName.装配工位.ToString());
            treeView1.Nodes[0].Nodes.Add(StationName.送料工位.ToString());
            treeView1.ExpandAll();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            switch (name)
            {
                case StationName.装配工位:
                    m_Xaxis.MoveMode = moveselect.MoveMode;
                    m_Xaxis.Refreshing();
                    m_Yaxis.MoveMode = moveselect.MoveMode;
                    m_Yaxis.Refreshing();
                    m_Zaxis.MoveMode = moveselect.MoveMode;
                    m_Zaxis.Refreshing();
                    m_Maxis.MoveMode = moveselect.MoveMode;
                    m_Maxis.Refreshing();
                    m_InhaleOperate.InOrigin = m_Plateform.InhaleCylinder.OutOriginStatus;
                    m_InhaleOperate.InMove = m_Plateform.InhaleCylinder.OutMoveStatus;
                    m_InhaleOperate.OutMove = m_Plateform.InhaleCylinder.IsOutMove;
                    m_ModelOperate.StationIni = m_Plateform.stationInitialize;
                    m_ModelOperate.StationOpe = m_Plateform.stationOperate;
                    m_ModelOperate.Refreshing();
                    break;
                case StationName.送料工位:
                    m_Caxis.MoveMode = moveselect.MoveMode;
                    m_Caxis.Refreshing();
                    m_ModelOperate.StationIni = m_Incoming.stationInitialize;
                    m_ModelOperate.StationOpe = m_Incoming.stationOperate;
                    m_ModelOperate.Refreshing();
                    break;
                default:
                    break;
            }
            timer1.Enabled = true;
        }

        public enum StationName
        {
            O_Ring组装设备,
            装配工位,
            送料工位
        }
    }
}
