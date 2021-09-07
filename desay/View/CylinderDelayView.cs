using System;
using System.Enginee;
using System.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.ToolKit;
using System.Windows.Forms;
using System.ToolKit.Helper;

namespace desay
{
  
    public partial class CylinderDelayView : UserControl
    {
        private Splice m_Splice;
        private Buffer m_Buffer;
        private Feeder m_Feeder;
        private Move m_Move;
        private LeftC m_LeftC;
        private LeftCut1 m_LeftCut1;
        private LeftCut2 m_LeftCut2;
        private RightCut1 m_RightCut1;
        private RightCut2 m_RightCut2;
        private Platform m_Platform;
        private Storing m_Storing;

   //     private VacuoParameter Left1InhaleCylinderParameter, Left2InhaleCylinderParameter, Left3InhaleCylinderParameter, Left4InhaleCylinderParameter;

        private CylinderParameter NoRodFeedCylinderParameter, FeederCylinderParameter, MoveLeftCylinderParameter, MoveDownCylinderParameter,
             MoveGripperCylinderParameter, CutwasteCylinder1Parameter, CutwasteCylinder2Parameter, CutwasteCylinder3Parameter, LeftCut1FrontCylinderParameter, LeftCut1DownCylinderParameter
             , LeftCut1GripperCylinderParameter, LeftCut2FrontCylinderParameter, LeftCut2DownCylinderParameter
             , LeftCut2GripperCylinderParameter, LeftCut3FrontCylinderParameter, LeftCut3DownCylinderParameter
             , LeftCut3GripperCylinderParameter, LeftCut4FrontCylinderParameter, LeftCut4DownCylinderParameter
             , LeftCut4GripperCylinderParameter, InhaleLeft1CylinderParameter, /*InhaleLeft2CylinderParameter,*/ GetTrayCylinderParameter
             , LockCylindernParameter, SafeDoorCylinderParameter, /*CAxisPush1CylinderParameter,*/ bufDownCyliderParameter, bufLeftCyliderParameter, bufGripperCyliderParameter;

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Delay.Instance.bufDownCyliderDelay = bufDownCyliderParameter.Save;
            Delay.Instance.bufLeftCyliderDelay = bufLeftCyliderParameter.Save;
            Delay.Instance.bufGripperCyliderDelay = bufGripperCyliderParameter.Save;
            m_Buffer.DownCylinder.Delay = Delay.Instance.bufDownCyliderDelay;
            m_Buffer.LeftCylinder.Delay = Delay.Instance.bufLeftCyliderDelay;
            m_Buffer.GripperCylinder.Delay = Delay.Instance.bufGripperCyliderDelay;

            Delay.Instance.FeederCylinderDelay = FeederCylinderParameter.Save;
            m_Feeder.FeederCylinder.Delay = Delay.Instance.FeederCylinderDelay;

            Delay.Instance.LeftCut1FrontCylinderDelay = LeftCut1FrontCylinderParameter.Save;
            Delay.Instance.LeftCut1OverturnCylinderDelay = LeftCut1DownCylinderParameter.Save;
            Delay.Instance.LeftCut1GripperCylinderDelay = LeftCut1GripperCylinderParameter.Save;
            Delay.Instance.LeftCut2FrontCylinderDelay = LeftCut2FrontCylinderParameter.Save;
            Delay.Instance.LeftCut2OverturnCylinderDelay = LeftCut2DownCylinderParameter.Save;
            Delay.Instance.LeftCut2GripperCylinderDelay = LeftCut2GripperCylinderParameter.Save;
            Delay.Instance.LeftCut3FrontCylinderDelay = LeftCut3FrontCylinderParameter.Save;
            Delay.Instance.LeftCut3OverturnCylinderDelay = LeftCut3DownCylinderParameter.Save;
            Delay.Instance.LeftCut3GripperCylinderDelay = LeftCut3GripperCylinderParameter.Save;
            Delay.Instance.LeftCut4FrontCylinderDelay = LeftCut4FrontCylinderParameter.Save;
            Delay.Instance.LeftCut4OverturnCylinderDelay = LeftCut4DownCylinderParameter.Save;
            Delay.Instance.LeftCut4GripperCylinderDelay = LeftCut4GripperCylinderParameter.Save;
            m_LeftCut1.FrontCylinder.Delay = Delay.Instance.LeftCut1FrontCylinderDelay;
            m_LeftCut1.OverturnCylinder.Delay = Delay.Instance.LeftCut1OverturnCylinderDelay;
            m_LeftCut1.GripperCylinder.Delay = Delay.Instance.LeftCut1GripperCylinderDelay;
            m_LeftCut2.FrontCylinder.Delay = Delay.Instance.LeftCut2FrontCylinderDelay;
            m_LeftCut2.OverturnCylinder.Delay = Delay.Instance.LeftCut2OverturnCylinderDelay;
            m_LeftCut2.GripperCylinder.Delay = Delay.Instance.LeftCut2GripperCylinderDelay;
            m_RightCut1.FrontCylinder.Delay = Delay.Instance.LeftCut3FrontCylinderDelay;
            m_RightCut1.OverturnCylinder.Delay = Delay.Instance.LeftCut3OverturnCylinderDelay;
            m_RightCut1.GripperCylinder.Delay = Delay.Instance.LeftCut3GripperCylinderDelay;
            m_RightCut2.FrontCylinder.Delay = Delay.Instance.LeftCut4FrontCylinderDelay;
            m_RightCut2.OverturnCylinder.Delay = Delay.Instance.LeftCut4OverturnCylinderDelay;
            m_RightCut2.GripperCylinder.Delay = Delay.Instance.LeftCut4GripperCylinderDelay;

            Delay.Instance.NoRodFeedCylinderDelay = NoRodFeedCylinderParameter.Save;
            Delay.Instance.FeederCylinderDelay = FeederCylinderParameter.Save;
            m_Splice.NoRodFeedCylinder.Delay = Delay.Instance.NoRodFeedCylinderDelay;

            Delay.Instance.MoveDownCylinderDelay = MoveDownCylinderParameter.Save;
            Delay.Instance.MoveLeftCylinderDelay = MoveLeftCylinderParameter.Save;
            Delay.Instance.MoveGripperCylinderDelay = MoveGripperCylinderParameter.Save;
            if (0 == Position.Instance.FragmentationMode)
            {
                Delay.Instance.CutwasteCylinder1Delay = CutwasteCylinder1Parameter.Save;
                Delay.Instance.CutwasteCylinder2Delay = CutwasteCylinder2Parameter.Save;
                Delay.Instance.CutwasteCylinder3Delay = CutwasteCylinder3Parameter.Save;
            }
            m_Move.DownCylinder.Delay = Delay.Instance.MoveDownCylinderDelay;
            m_Move.LeftCylinder.Delay = Delay.Instance.MoveLeftCylinderDelay;
            m_Move.GripperCylinder.Delay = Delay.Instance.MoveGripperCylinderDelay;
            if (0 == Position.Instance.FragmentationMode)
            {
                m_Move.CutwasteCylinder1.Delay = Delay.Instance.CutwasteCylinder1Delay;
                m_Move.CutwasteCylinder2.Delay = Delay.Instance.CutwasteCylinder2Delay;
                m_Move.CutwasteCylinder3.Delay = Delay.Instance.CutwasteCylinder3Delay;
            }

            Delay.Instance.InhaleLeft1CylinderDelay = InhaleLeft1CylinderParameter.Save;
            //Delay.Instance.InhaleLeft2CylinderDelay = InhaleLeft2CylinderParameter.Save;
            //Delay.Instance.Left1InhaleCylinderDelay = Left1InhaleCylinderParameter.Save;
            //Delay.Instance.Left2InhaleCylinderDelay = Left2InhaleCylinderParameter.Save;
            //Delay.Instance.Left3InhaleCylinderDelay = Left3InhaleCylinderParameter.Save;
            //Delay.Instance.Left4InhaleCylinderDelay = Left4InhaleCylinderParameter.Save;
            Delay.Instance.GetTrayCylinderDelay = GetTrayCylinderParameter.Save;
            Delay.Instance.LockCylinderDelay = LockCylindernParameter.Save;
            m_Platform.GetTrayCylinder.Delay = Delay.Instance.GetTrayCylinderDelay;
            m_Platform.LockCylinder.Delay = Delay.Instance.LockCylinderDelay;

            Delay.Instance.SafeDoorCylinderDelay = SafeDoorCylinderParameter.Save;
            m_Storing.SafeDoolCylinder.Delay = Delay.Instance.SafeDoorCylinderDelay;
            //Delay.Instance.CAxisPush1CylinderDelay = CAxisPush1CylinderParameter.Save;
            //m_LeftC.BoostCylinder.Delay = Delay.Instance.CAxisPush1CylinderDelay;

            Marking.ModifyParameterMarker = true;
        }


        public CylinderDelayView()
        {
            InitializeComponent();
        }
        public CylinderDelayView(Splice Splice, Buffer Buffer, Feeder Feeder, Move Move, LeftC LeftC,
         LeftCut1 LeftCut1, LeftCut2 LeftCut2, RightCut1 RightCut1, RightCut2 RightCut2, Platform Platform, Storing Storing) : this()
        {
            m_Splice = Splice;
            m_Buffer = Buffer;
            m_Feeder = Feeder;
            m_Move = Move;
            m_LeftC = LeftC;
            m_LeftCut1 = LeftCut1;
            m_LeftCut2 = LeftCut2;
            m_RightCut1 = RightCut1;
            m_RightCut2 = RightCut2;
            m_Platform = Platform;
            m_Storing = Storing;

        }
        private void CylinderDelayView_Load(object sender, EventArgs e)
        {

            #region 延时加载

            bufDownCyliderParameter = new CylinderParameter(Delay.Instance.bufDownCyliderDelay) { Name = "缓冲升降气缸" };
            bufLeftCyliderParameter = new CylinderParameter(Delay.Instance.bufLeftCyliderDelay) { Name = "缓冲左右气缸" };
            bufGripperCyliderParameter = new CylinderParameter(Delay.Instance.bufGripperCyliderDelay) { Name = "缓冲夹子气缸" };
            flpbufParam.Controls.Clear();
            flpbufParam.Controls.Add(bufDownCyliderParameter);
            flpbufParam.Controls.Add(bufLeftCyliderParameter);
            flpbufParam.Controls.Add(bufGripperCyliderParameter);

            LeftCut1FrontCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut1FrontCylinderDelay) { Name = "1#剪切前后气缸" };
            LeftCut1DownCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut1OverturnCylinderDelay) { Name = "1#剪切翻转气缸" };
            LeftCut1GripperCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut1GripperCylinderDelay) { Name = "1#剪切夹子气缸" };
            LeftCut2FrontCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut2FrontCylinderDelay) { Name = "2#剪切前后气缸" };
            LeftCut2DownCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut2OverturnCylinderDelay) { Name = "2#剪切翻转气缸" };
            LeftCut2GripperCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut2GripperCylinderDelay) { Name = "2#剪切夹子气缸" };
            LeftCut3FrontCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut3FrontCylinderDelay) { Name = "3#剪切前后气缸" };
            LeftCut3DownCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut3OverturnCylinderDelay) { Name = "3#剪切翻转气缸" };
            LeftCut3GripperCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut3GripperCylinderDelay) { Name = "3#剪切夹子气缸" };
            LeftCut4FrontCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut4FrontCylinderDelay) { Name = "4#剪切前后气缸" };
            LeftCut4DownCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut4OverturnCylinderDelay) { Name = "4#剪切翻转气缸" };
            LeftCut4GripperCylinderParameter = new CylinderParameter(Delay.Instance.LeftCut4GripperCylinderDelay) { Name = "4#剪切夹子气缸" };
            flpcutParam.Controls.Clear();
            flpcutParam.Controls.Add(LeftCut1FrontCylinderParameter);
            flpcutParam.Controls.Add(LeftCut1DownCylinderParameter);
            flpcutParam.Controls.Add(LeftCut1GripperCylinderParameter);
            flpcutParam.Controls.Add(LeftCut2FrontCylinderParameter);
            flpcutParam.Controls.Add(LeftCut2DownCylinderParameter);
            flpcutParam.Controls.Add(LeftCut2GripperCylinderParameter);
            flpcutParam.Controls.Add(LeftCut3FrontCylinderParameter);
            flpcutParam.Controls.Add(LeftCut3DownCylinderParameter);
            flpcutParam.Controls.Add(LeftCut3GripperCylinderParameter);
            flpcutParam.Controls.Add(LeftCut4FrontCylinderParameter);
            flpcutParam.Controls.Add(LeftCut4DownCylinderParameter);
            flpcutParam.Controls.Add(LeftCut4GripperCylinderParameter);

            NoRodFeedCylinderParameter = new CylinderParameter(Delay.Instance.NoRodFeedCylinderDelay) { Name = "接料无杆气缸" };
            FeederCylinderParameter = new CylinderParameter(Delay.Instance.FeederCylinderDelay) { Name = "进料气缸" };
            flpFeedParam.Controls.Clear();
            flpFeedParam.Controls.Add(NoRodFeedCylinderParameter);
            flpFeedParam.Controls.Add(FeederCylinderParameter);

            MoveLeftCylinderParameter = new CylinderParameter(Delay.Instance.MoveLeftCylinderDelay) { Name = "移料左右气缸" };
            MoveDownCylinderParameter = new CylinderParameter(Delay.Instance.MoveDownCylinderDelay) { Name = "移料上下气缸" };
            MoveGripperCylinderParameter = new CylinderParameter(Delay.Instance.MoveGripperCylinderDelay) { Name = "移料夹子气缸" };
            if (0 == Position.Instance.FragmentationMode)
            {
                CutwasteCylinder1Parameter = new CylinderParameter(Delay.Instance.CutwasteCylinder1Delay) { Name = "碎料气缸" };
                CutwasteCylinder2Parameter = new CylinderParameter(Delay.Instance.CutwasteCylinder2Delay) { Name = "排料气缸" };
                CutwasteCylinder3Parameter = new CylinderParameter(Delay.Instance.CutwasteCylinder3Delay) { Name = "碎料盖子气缸" };
            }
            flpmovParam.Controls.Clear();
            flpmovParam.Controls.Add(MoveLeftCylinderParameter);
            flpmovParam.Controls.Add(MoveDownCylinderParameter);
            flpmovParam.Controls.Add(MoveGripperCylinderParameter);
            if (0 == Position.Instance.FragmentationMode)
            {
                flpmovParam.Controls.Add(CutwasteCylinder1Parameter);
                flpmovParam.Controls.Add(CutwasteCylinder2Parameter);
                flpmovParam.Controls.Add(CutwasteCylinder3Parameter);
            }

            InhaleLeft1CylinderParameter = new CylinderParameter(Delay.Instance.InhaleLeft1CylinderDelay) { Name = "1#2#4#吸笔左右气缸" };
            //InhaleLeft2CylinderParameter = new CylinderParameter(Delay.Instance.InhaleLeft2CylinderDelay) { Name = "2#吸笔左右气缸" };
            //Left1InhaleCylinderParameter = new VacuoParameter(Delay.Instance.Left1InhaleCylinderDelay) { Name = "1#吸笔电磁阀" };
            //Left2InhaleCylinderParameter = new VacuoParameter(Delay.Instance.Left2InhaleCylinderDelay) { Name = "2#吸笔电磁阀" };
            //Left3InhaleCylinderParameter = new VacuoParameter(Delay.Instance.Left3InhaleCylinderDelay) { Name = "3#吸笔电磁阀" };
            //Left4InhaleCylinderParameter = new VacuoParameter(Delay.Instance.Left4InhaleCylinderDelay) { Name = "4#吸笔电磁阀" };
            GetTrayCylinderParameter = new CylinderParameter(Delay.Instance.GetTrayCylinderDelay) { Name = "取盘上下气缸" };
            LockCylindernParameter = new CylinderParameter(Delay.Instance.LockCylinderDelay) { Name = "卡紧料盘气缸" };
            flpstorParam.Controls.Clear();
            flpstorParam.Controls.Add(InhaleLeft1CylinderParameter);
            //flpstorParam.Controls.Add(InhaleLeft2CylinderParameter);
            //flpstorParam.Controls.Add(Left1InhaleCylinderParameter);
            //flpstorParam.Controls.Add(Left2InhaleCylinderParameter);
            //flpstorParam.Controls.Add(Left3InhaleCylinderParameter);
            //flpstorParam.Controls.Add(Left4InhaleCylinderParameter);
            flpstorParam.Controls.Add(GetTrayCylinderParameter);
            flpstorParam.Controls.Add(LockCylindernParameter);

            SafeDoorCylinderParameter = new CylinderParameter(Delay.Instance.SafeDoorCylinderDelay) { Name = "安全门电磁阀" };
            //CAxisPush1CylinderParameter = new CylinderParameter(Delay.Instance.CAxisPush1CylinderDelay) { Name = " C轴推进气缸" };
            flpotherParam.Controls.Clear();
            flpotherParam.Controls.Add(SafeDoorCylinderParameter);
            //flpotherParam.Controls.Add(CAxisPush1CylinderParameter);

            #endregion

        }
    }
}
