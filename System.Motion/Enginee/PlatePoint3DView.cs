using System.Windows.Forms;
using System.ToolKit;

namespace System.Enginee
{
    public partial class PlatePoint3DView : UserControl
    {
        public PlatePoint3DView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 索引编号
        /// </summary>
        public int Index
        {
            get
            {
                return (int)ndnIndex.Value;
            }
            set
            {
                ndnIndex.Value = value;
            }
        }
        public Point3D<double> Point
        {
            set
            {
                lblGetProductX.Text = value.X.ToString("0.000");
                lblGetProductY.Text = value.Y.ToString("0.000");
                lblGetProductZ.Text = value.Z.ToString("0.000");
            }
        }
    }
}
