using System;
using Motion.Enginee;
namespace desay
{
    [Serializable]
    public class Delay
    {
        [NonSerialized]
        public static Delay Instance = new Delay();
        public int InhaleTime;
        public int NgBrokenTime;
        public int PlateBrokenTime;
        public int PlateInPosBrokenTime;
        public int InhaleAlarmTime=10000;
    }
}
