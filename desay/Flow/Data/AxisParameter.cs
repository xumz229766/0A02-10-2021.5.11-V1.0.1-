using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.AdvantechAps;
using System.Interfaces;

namespace desay
{

    /// <summary>
    /// 各轴参数
    /// </summary>
    [Serializable]
    public class AxisParameter
    {
        [NonSerialized]
        public static AxisParameter Instance = new AxisParameter();

        /// <summary>
        /// Y,X,Z,C1,C2,C3,C4,Push1,Push2,Push3,Push4,Cut1,Cut2,Cut3,Cut4,M
        /// </summary>
        public HomeSpeed[] HomeSpeed = new HomeSpeed[16];
        /// <summary>
        /// Y,X,Z,C1,C2,C3,C4,Push1,Push2,Push3,Push4,Cut1,Cut2,Cut3,Cut4,M
        /// </summary>
        public HomeSpeed[] RunSpeed = new HomeSpeed[16];

        #region 最大速度
        /// <summary>
        /// 勾盘慢速
        /// </summary>
        public double SlowvelocityMax = 10.00;

        /// <summary>
        /// 剪切慢速
        /// </summary>
        public double SlowCutvelocityMax = 100.00;

        /// <summary>
        /// 摆盘慢速
        /// </summary>
        public double SlowZvelocityMax = 100.00;
        #endregion

        #region 速度比率
        public double YvelocityRate = 20;
        public double XvelocityRate = 20;
        public double ZvelocityRate = 20;
        public double C1velocityRate = 20;
        public double C2velocityRate = 20;
        public double C3velocityRate = 20;
        public double C4velocityRate = 20;
        public double Cut1velocityRate = 20;
        public double Cut2velocityRate = 20;
        public double Cut3velocityRate = 20;
        public double Cut4velocityRate = 20;
        public double Push1velocityRate = 20;
        public double Push2velocityRate = 20;
        public double Push3velocityRate = 20;
        public double Push4velocityRate = 20;
        public double MvelocityRate = 20;

        /// <summary>
        /// 勾盘慢速
        /// </summary>
        public double SlowvelocityRate = 20;
        /// <summary>
        /// 勾盘慢速
        /// </summary>
        public double SlowveExitlocityRate = 20;
        /// <summary>
        /// 剪切慢速
        /// </summary>
        public double SlowCutvelocityRate1 = 20;
        /// <summary>
        /// 剪切慢速
        /// </summary>
        public double SlowCutvelocityRate2 = 20;
        /// <summary>
        /// 剪切慢速
        /// </summary>
        public double SlowCutvelocityRate3 = 20;
        /// <summary>
        /// 剪切慢速
        /// </summary>
        public double SlowCutvelocityRate4 = 20;
        /// <summary>
        /// 摆盘慢速
        /// </summary>
        public double SlowZvelocityRate = 20;
        #endregion

        #region 回零速度
        public VelocityCurve YHomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[0].startSpeed, HomeSpeed[0].MaxSpeed, HomeSpeed[0].add / 1000.0, HomeSpeed[0].dec / 1000.0);
            }
        }
        public VelocityCurve XHomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[1].startSpeed, HomeSpeed[1].MaxSpeed, HomeSpeed[1].add / 1000.0, HomeSpeed[1].dec / 1000.0);
            }
        }

        public VelocityCurve ZHomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[2].startSpeed, HomeSpeed[2].MaxSpeed, HomeSpeed[2].add / 1000.0, HomeSpeed[2].dec / 1000.0);
            }
        }

        public VelocityCurve C1HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[3].startSpeed, HomeSpeed[3].MaxSpeed, HomeSpeed[3].add / 1000.0, HomeSpeed[3].dec / 1000.0);
            }
        }

        public VelocityCurve C2HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[4].startSpeed, HomeSpeed[4].MaxSpeed, HomeSpeed[4].add / 1000.0, HomeSpeed[4].dec / 1000.0);
            }
        }
        public VelocityCurve C3HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[5].startSpeed, HomeSpeed[5].MaxSpeed, HomeSpeed[5].add / 1000.0, HomeSpeed[5].dec / 1000.0);
            }
        }
        public VelocityCurve C4HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[6].startSpeed, HomeSpeed[6].MaxSpeed, HomeSpeed[6].add / 1000.0, HomeSpeed[6].dec / 1000.0);
            }
        }
        public VelocityCurve Push1HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[7].startSpeed, HomeSpeed[7].MaxSpeed, HomeSpeed[7].add / 1000.0, HomeSpeed[7].dec / 1000.0);
            }
        }
        public VelocityCurve Push2HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[8].startSpeed, HomeSpeed[8].MaxSpeed, HomeSpeed[8].add / 1000.0, HomeSpeed[8].dec / 1000.0);
            }
        }
        public VelocityCurve Push3HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[9].startSpeed, HomeSpeed[9].MaxSpeed, HomeSpeed[9].add / 1000.0, HomeSpeed[9].dec / 1000.0);
            }
        }
        public VelocityCurve Push4HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[10].startSpeed, HomeSpeed[10].MaxSpeed, HomeSpeed[10].add / 1000.0, HomeSpeed[10].dec / 1000.0);
            }
        }
        public VelocityCurve Cut1HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[11].startSpeed, HomeSpeed[11].MaxSpeed, HomeSpeed[11].add / 1000.0, HomeSpeed[11].dec / 1000.0);
            }
        }
        public VelocityCurve Cut2HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[12].startSpeed, HomeSpeed[12].MaxSpeed, HomeSpeed[12].add / 1000.0, HomeSpeed[12].dec / 1000.0);
            }
        }
        public VelocityCurve Cut3HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[13].startSpeed, HomeSpeed[13].MaxSpeed, HomeSpeed[13].add / 1000.0, HomeSpeed[13].dec / 1000.0);
            }
        }
        public VelocityCurve Cut4HomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[14].startSpeed, HomeSpeed[14].MaxSpeed, HomeSpeed[14].add / 1000.0, HomeSpeed[14].dec / 1000.0);
            }
        }
        public VelocityCurve MHomeVelocityCurve
        {
            get
            {
                return new VelocityCurve(HomeSpeed[15].startSpeed, HomeSpeed[15].MaxSpeed, HomeSpeed[15].add / 1000.0, HomeSpeed[15].dec / 1000.0);
            }
        }
        #endregion

        # region 运行速度
        public VelocityCurve YVelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[0].startSpeed, (RunSpeed[0].MaxSpeed * YvelocityRate) / 100.0, RunSpeed[0].add / 1000.0,
                    RunSpeed[1].dec / 1000.0, 0.08, 0.08, 0.08, 0.08, CurveTypes.S);
            }
        }

        public VelocityCurve XVelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[1].startSpeed, (RunSpeed[1].MaxSpeed * XvelocityRate) / 100.0, RunSpeed[1].add / 1000.0, RunSpeed[1].dec / 1000.0);
            }
        }

        public VelocityCurve ZVelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[2].startSpeed, (RunSpeed[2].MaxSpeed * ZvelocityRate) / 100.0,
                    (SlowZvelocityMax * SlowZvelocityRate) / 100.0, RunSpeed[2].add / 1000.0, RunSpeed[2].dec / 1000.0);
            }
        }

        public VelocityCurve C1VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[3].startSpeed, (RunSpeed[3].MaxSpeed * C1velocityRate) / 100.0, RunSpeed[3].add / 1000.0, RunSpeed[3].dec / 1000.0);
            }
        }

        public VelocityCurve C2VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[4].startSpeed, (RunSpeed[4].MaxSpeed * C2velocityRate) / 100.0, RunSpeed[4].add / 1000.0, RunSpeed[4].dec / 1000.0);
            }
        }
        public VelocityCurve C3VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[5].startSpeed, (RunSpeed[5].MaxSpeed * C3velocityRate) / 100.0, RunSpeed[5].add / 1000.0, RunSpeed[5].dec / 1000.0);
            }
        }
        public VelocityCurve C4VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[6].startSpeed, (RunSpeed[6].MaxSpeed * C4velocityRate) / 100.0, RunSpeed[6].add / 1000.0, RunSpeed[6].dec / 1000.0);
            }
        }
        public VelocityCurve Push1VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[7].startSpeed, (RunSpeed[7].MaxSpeed * Push1velocityRate) / 100.0, RunSpeed[7].add / 1000.0, RunSpeed[7].dec / 1000.0);
            }
        }
        public VelocityCurve Push2VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[8].startSpeed, (RunSpeed[8].MaxSpeed * Push2velocityRate) / 100.0, RunSpeed[8].add / 1000.0, RunSpeed[8].dec / 1000.0);
            }
        }
        public VelocityCurve Push3VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[9].startSpeed, (RunSpeed[9].MaxSpeed * Push3velocityRate) / 100.0, RunSpeed[9].add / 1000.0, RunSpeed[9].dec / 1000.0);
            }
        }
        public VelocityCurve Push4VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[10].startSpeed, (RunSpeed[10].MaxSpeed * Push4velocityRate) / 100.0, RunSpeed[10].add / 1000.0, RunSpeed[10].dec / 1000.0);
            }
        }
        public VelocityCurve Cut1VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[11].startSpeed, (RunSpeed[11].MaxSpeed * Cut1velocityRate) / 100.0,
                    (SlowCutvelocityMax * SlowCutvelocityRate1) / 100, RunSpeed[11].add / 1000.0, RunSpeed[11].dec / 1000.0);
            }
        }
        public VelocityCurve Cut2VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[12].startSpeed, (RunSpeed[12].MaxSpeed * Cut2velocityRate) / 100.0,
                    (SlowCutvelocityMax * SlowCutvelocityRate2) / 100, RunSpeed[12].add / 1000.0, RunSpeed[12].dec / 1000.0);
            }
        }
        public VelocityCurve Cut3VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[13].startSpeed, (RunSpeed[13].MaxSpeed * Cut3velocityRate) / 100.0,
                    (SlowCutvelocityMax * SlowCutvelocityRate3) / 100, RunSpeed[13].add / 1000.0, RunSpeed[13].dec / 1000.0);
            }
        }
        public VelocityCurve Cut4VelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[14].startSpeed, (RunSpeed[14].MaxSpeed * Cut4velocityRate) / 100.0,
                    (SlowCutvelocityMax * SlowCutvelocityRate4) / 100, RunSpeed[14].add / 1000.0, RunSpeed[14].dec / 1000.0);
            }
        }
        public VelocityCurve MVelocityCurve
        {
            get
            {
                return new VelocityCurve(RunSpeed[15].startSpeed, (RunSpeed[15].MaxSpeed * MvelocityRate) / 100.0, RunSpeed[15].add / 1000.0, RunSpeed[15].dec / 1000.0);
            }
        }
        #endregion

        /// <summary>
        /// 勾盘慢速
        /// </summary>
        public VelocityCurve SlowvelocityCurve
        {
            get
            {
                return new VelocityCurve(1000, (SlowvelocityMax * SlowvelocityRate) / 100.0, 0.2);
            }
        }
        /// <summary>
        /// 退盘慢速
        /// </summary>
        public VelocityCurve SlowExitvelocityCurve
        {
            get
            {
                return new VelocityCurve(1000, (SlowvelocityMax * SlowveExitlocityRate) / 100.0, 0.2);
            }
        }

        #region 传动比
        public TransmissionParams YTransParams { get; set; } = new TransmissionParams() { Lead = 20, SubDivisionNum = 20000 };
        public TransmissionParams XTransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams ZTransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams C1TransParams { get; set; } = new TransmissionParams() { Lead = 360, SubDivisionNum = 36000 };
        public TransmissionParams C2TransParams { get; set; } = new TransmissionParams() { Lead = 360, SubDivisionNum = 36000 };
        public TransmissionParams C3TransParams { get; set; } = new TransmissionParams() { Lead = 360, SubDivisionNum = 36000 };
        public TransmissionParams C4TransParams { get; set; } = new TransmissionParams() { Lead = 360, SubDivisionNum = 36000 };
        public TransmissionParams Push1TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams Push2TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams Push3TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams Push4TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams Cut1TransParams { get; set; } = new TransmissionParams() { Lead = 40, SubDivisionNum = 4000 };
        public TransmissionParams Cut2TransParams { get; set; } = new TransmissionParams() { Lead = 40, SubDivisionNum = 4000 };
        public TransmissionParams Cut3TransParams { get; set; } = new TransmissionParams() { Lead = 40, SubDivisionNum = 4000 };
        public TransmissionParams Cut4TransParams { get; set; } = new TransmissionParams() { Lead = 40, SubDivisionNum = 4000 };
        public TransmissionParams MTransParams { get; set; } = new TransmissionParams() { Lead = 3, SubDivisionNum = 30000 };
        public TransmissionParams SlowTransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams SlowcutTransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        #endregion

        /// <summary>
        /// Y,X,Z,C1,C2,C3,C4,P1,P2,P3,P4,Cut1,Cut2,Cut3,Cut4,M
        /// </summary>
        public double[] SoftNlimit = new double[16];
        public double[] SoftPlimit = new double[16];

        /// <summary>
        /// 测试按键按下状态
        /// </summary>
        public bool BtnTestState = true;

    }

    public struct HomeSpeed
    {
        public int startSpeed;
        public double add;
        public double dec;
        public int MaxSpeed;
    }
}
