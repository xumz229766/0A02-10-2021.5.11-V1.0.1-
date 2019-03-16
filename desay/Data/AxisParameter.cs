using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Motion.LSAps;
using Motion.Interfaces;
using System.ToolKit;
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

        //最大速度
        public double XvelocityMax = 400.000;
        public double YvelocityMax = 400.000;
        public double ZvelocityMax = 400.000;
        public double MvelocityMax = 200.000;
        public double C1velocityMax = 200.00;
        public double C2velocityMax = 200.00;
        public double C3velocityMax = 200.00;
        public double C4velocityMax = 200.00;
        public double Cut1velocityMax = 200.00;
        public double Cut2velocityMax = 200.00;
        public double Cut3velocityMax = 200.00;
        public double Cut4velocityMax = 200.00;
        public double LoadvelocityMax = 200.00;        


        //速度比率
        public double XvelocityRate = 20;
        public double YvelocityRate = 20;
        public double ZvelocityRate = 20;
        public double MvelocityRate = 20;
        public double C1velocityRate = 20;
        public double C2velocityRate = 20;
        public double C3velocityRate = 20;
        public double C4velocityRate = 20;
        public double Cut1velocityRate = 20;
        public double Cut2velocityRate = 20;
        public double Cut3velocityRate = 20;
        public double Cut4velocityRate = 20;
        public double LoadvelocityRate = 20;

        //速度参数
        public VelocityCurve XVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (XvelocityMax * XvelocityRate) / 100, 0);
            }
        }

        public VelocityCurve YVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (YvelocityMax * YvelocityRate) / 100, 0);
            }
        }

        public VelocityCurve ZVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (ZvelocityMax * ZvelocityRate) / 100, 0);
            }
        }

        public VelocityCurve ZSlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (ZvelocityMax * ZvelocityRate) / 100, 0);
            }
        }

        public VelocityCurve MVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (MvelocityMax * MvelocityRate) / 100, 0);
            }
        }

        public VelocityCurve MSlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (MvelocityMax * MvelocityRate) / 500, 0);
            }
        }

        public VelocityCurve C1VelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (C1velocityMax * C1velocityRate) / 100, 0);
            }
        }

        public VelocityCurve C2VlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (C2velocityMax * C2velocityRate) / 100, 0);
            }
        }
        public VelocityCurve C3VlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (C3velocityMax * C3velocityRate) / 100, 0);
            }
        }
        public VelocityCurve C4VlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (C4velocityMax * C4velocityRate) / 100, 0);
            }
        }
        public VelocityCurve Cut1VlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (Cut1velocityMax * Cut1velocityRate) / 100, 0);
            }
        }
        public VelocityCurve Cut2VlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (Cut2velocityMax * Cut2velocityRate) / 100, 0);
            }
        }
        public VelocityCurve Cut3VlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (Cut3velocityMax * Cut3velocityRate) / 100, 0);
            }
        }
        public VelocityCurve Cut4VlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (Cut4velocityMax * Cut4velocityRate) / 100, 0);
            }
        }
        public VelocityCurve LoadVlowVelocityCurve
        {
            get
            {
                return new VelocityCurve(0, (LoadvelocityMax * LoadvelocityRate) / 100, 0);
            }
        }
        //传动参数
        public TransmissionParams XTransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };

        public TransmissionParams YTransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };

        public TransmissionParams ZTransParams { get; set; } = new TransmissionParams() { Lead = 6, SubDivisionNum = 10000 };

        public TransmissionParams MTransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };

        public TransmissionParams C1TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams C2TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams C3TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams C4TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams Cut1TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams Cut2TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams Cut3TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams Cut4TransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };
        public TransmissionParams LoadTransParams { get; set; } = new TransmissionParams() { Lead = 10, SubDivisionNum = 10000 };

    }
}
