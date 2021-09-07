using System;
using System.Enginee;

namespace desay
{
    [Serializable]
    public class Delay
    {
        [NonSerialized]
        public static Delay Instance = new Delay();

        /// <summary>
        /// 接料无杆气缸
        /// </summary>
        public CylinderDelay NoRodFeedCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 进料气缸
        /// </summary>
        public CylinderDelay FeederCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 移料左右气缸
        /// </summary>
        public CylinderDelay MoveLeftCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 移料上下气缸
        /// </summary>
        public CylinderDelay MoveDownCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 移料夹子气缸
        /// </summary>
        public CylinderDelay MoveGripperCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// C轴推进气缸
        /// </summary>
        public CylinderDelay CAxisBoostCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 切废料气缸1
        /// </summary>
        public CylinderDelay CutwasteCylinder1Delay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 切废料气缸2
        /// </summary>
        public CylinderDelay CutwasteCylinder2Delay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 切废料气缸3
        /// </summary>
        public CylinderDelay CutwasteCylinder3Delay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// C轴推出1#气缸
        /// </summary>
        public CylinderDelay CAxisPush1CylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// C轴推出2#气缸
        /// </summary>
        public CylinderDelay CAxisPush2CylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// C轴推出3#气缸
        /// </summary>
        public CylinderDelay CAxisPush3CylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 1#剪切前后气缸
        /// </summary>
        public CylinderDelay LeftCut1FrontCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 1#剪切上下气缸
        /// </summary>
        public CylinderDelay LeftCut1OverturnCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 1#剪切夹子气缸
        /// </summary>
        public CylinderDelay LeftCut1GripperCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 2#剪切前后气缸
        /// </summary>
        public CylinderDelay LeftCut2FrontCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  2#剪切上下气缸
        /// </summary>
        public CylinderDelay LeftCut2OverturnCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  2#剪切夹子气缸
        /// </summary>
        public CylinderDelay LeftCut2GripperCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 3#剪切前后气缸
        /// </summary>
        public CylinderDelay LeftCut3FrontCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  3#剪切上下气缸
        /// </summary>
        public CylinderDelay LeftCut3OverturnCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  3#剪切夹子气缸
        /// </summary>
        public CylinderDelay LeftCut3GripperCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        /// 4#剪切前后气缸
        /// </summary>
        public CylinderDelay LeftCut4FrontCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  4#剪切上下气缸
        /// </summary>
        public CylinderDelay LeftCut4OverturnCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  4#剪切夹子气缸
        /// </summary>
        public CylinderDelay LeftCut4GripperCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  吸笔左右1#气缸
        /// </summary>
        public CylinderDelay InhaleLeft1CylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  吸笔左右2#气缸
        /// </summary>
        public CylinderDelay InhaleLeft2CylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  1#吸笔吸气
        /// </summary>
        public VacuoDelay Left1InhaleCylinderDelay { get; set; } = new VacuoDelay() { InhaleTime = 0, BrokenTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  2#吸笔吸气
        /// </summary>
        public VacuoDelay Left2InhaleCylinderDelay { get; set; } = new VacuoDelay() { InhaleTime = 0, BrokenTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  3#吸笔吸气
        /// </summary>
        public VacuoDelay Left3InhaleCylinderDelay { get; set; } = new VacuoDelay() { InhaleTime = 0, BrokenTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  4#吸笔吸气
        /// </summary>
        public VacuoDelay Left4InhaleCylinderDelay { get; set; } = new VacuoDelay() { InhaleTime = 0, BrokenTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  取放盘上下气缸
        /// </summary>
        public CylinderDelay GetTrayCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  卡紧气缸
        /// </summary>
        public CylinderDelay LockCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  安全门升降
        /// </summary>
        public CylinderDelay SafeDoorCylinderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };

        ///  缓冲升降气缸
        /// </summary>
        public CylinderDelay bufDownCyliderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  缓冲左右气缸
        /// </summary>
        public CylinderDelay bufLeftCyliderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  缓冲夹子气缸
        /// </summary>
        public CylinderDelay bufGripperCyliderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };
        /// <summary>
        ///  安全门气缸
        /// </summary>
        public CylinderDelay SafeDoorCyliderDelay { get; set; } = new CylinderDelay() { OriginTime = 0, MoveTime = 0, AlarmTime = 2000 };

        /// <summary>
        /// 剪切闭合延时
        /// </summary>
        public int[] CutDelay = new int[4];
        /// <summary>
        /// 吸嘴吸气延时
        /// </summary>
        public int[] InspireDelay = new int[4];
        /// <summary>
        /// 吸嘴报警时间
        /// </summary>
        public int[] InspireErrDelay = new int[4];
        /// <summary>
        /// 吸嘴吹气后停留时间
        /// </summary>
        public int[] InspireStopDelay = new int[4];
        /// <summary>
        /// 吸嘴吹气延时
        /// </summary>
        public int[] SoproDelay = new int[4];
        /// <summary>
        /// Z轴抬起破真空时间
        /// </summary>
        public int[] ZSoproDelay = new int[4];
        /// <summary>
        /// Z轴到位延时
        /// </summary>
        public int ZaxisDoneDelay;
        /// <summary>
        /// C轴前进延时
        /// </summary>
        public int CaxisFrontDelay;
        /// <summary>
        /// C轴旋转延时
        /// </summary>
        public int CaxisRotateDelay;
        /// <summary>
        /// 接料延时
        /// </summary>
        public int SpliceDelay;
        /// <summary>
        /// 废料等待延时
        /// </summary>
        public int WasteWaitTime;
        /// <summary>
        /// 切废料次数
        /// </summary>
        public int WasteNumber;
        /// <summary>
        /// 夹子往复夹延时
        /// </summary>
        public int GripperCylinderTime;
        /// <summary>
        /// 手动剪切延时
        /// </summary>
        public int ShearTime;
        /// <summary>
        /// 1#吸笔左右气缸动点屏蔽
        /// </summary>
        public bool noMoveShield = true;
        /// <summary>
        /// 设备待料时候
        /// </summary>
        public int equiprmentWaitTime;
        /// <summary>
        /// 自动关闭安全门时间
        /// </summary>
        public int outoCloseDoorTime;
        /// <summary>
        /// 自动关闭安全门开启
        /// </summary>
        public bool outoCloseDoorOpen;
    }
}
