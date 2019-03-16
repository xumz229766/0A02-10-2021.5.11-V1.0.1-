using System;
using System.ToolKit;
using System.Tray;
namespace desay
{
    public class Plate
    {
        public Plate(Tray tray)
        {
            m_tray = tray;
        }
        public Tray m_tray { get; set; }

        /// <summary>
        /// 获取当前点数据位置
        /// </summary>
        /// <param name="point"></param>
        /// <param name="Trayindex"></param>
        /// <param name="Xdir"></param>
        /// <param name="Ydir"></param>
        /// <returns></returns>
        public Point3D<double> GetPosition(Point3D<double> point, int Trayindex, bool Xdir, bool Ydir)
        {
            var pos = new Point3D<double>();
            Index Traypos = m_tray.dic_Index[Trayindex];
            Index TrayBasePos = m_tray.dic_Index[1];
            if (point.X == 0 && point.Y == 0)
            {
                pos.X = 0;
                pos.Y = 0;
                pos.Z = 0;
                return pos;
            }
            var xdir = Xdir ? -1 : 1;
            var ydir = Ydir ? -1 : 1;
            pos.X = point.X + xdir * (Traypos.Row - TrayBasePos.Row) * m_tray.RowXoffset
                + xdir * (Traypos.Col - TrayBasePos.Col) * m_tray.ColumnXoffset;
            pos.Y = point.Y + ydir * (Traypos.Row - TrayBasePos.Row) * m_tray.RowYoffset
                + ydir * (Traypos.Col - TrayBasePos.Col) * m_tray.ColumnYoffset;
            pos.Z = point.Z;
            return pos;
        }
        /// <summary>
        /// 获取当前点数据位置
        /// </summary>
        /// <param name="point"></param>
        /// <param name="Trayindex"></param>
        /// <param name="Xdir"></param>
        /// <param name="Ydir"></param>
        /// <returns></returns>
        public Point<double> GetPosition(Point<double> point, int Trayindex, bool Xdir, bool Ydir)
        {
            var pos = new Point<double>();
            Index Traypos = m_tray.dic_Index[Trayindex];
            Index TrayBasePos = m_tray.dic_Index[1];
            if (point.X == 0 && point.Y == 0)
            {
                pos.X = 0;
                pos.Y = 0;
                return pos;
            }
            var xdir = Xdir ? -1 : 1;
            var ydir = Ydir ? -1 : 1;
            pos.X = point.X + xdir * (Traypos.Row - TrayBasePos.Row) * m_tray.RowXoffset
                + xdir * (Traypos.Col - TrayBasePos.Col) * m_tray.ColumnXoffset;
            pos.Y = point.Y + ydir * (Traypos.Row - TrayBasePos.Row) * m_tray.RowYoffset
                + ydir * (Traypos.Col - TrayBasePos.Col) * m_tray.ColumnYoffset;
            return pos;
        }
        ///// <summary>
        ///// 获取当前点数据位置
        ///// </summary>
        ///// <param name="Trayindex"></param>
        ///// <returns></returns>
        //public UpCameraCalib GetPosition(UpCameraCalib point, int Trayindex, bool Xdir, bool Ydir)
        //{
        //    var pos = new UpCameraCalib();
        //    Index Traypos = m_tray.dic_Index[Trayindex];
        //    Index TrayBasePos = m_tray.dic_Index[1];
        //    if (point.X == 0 && point.Y == 0)
        //    {
        //        pos.X = 0;
        //        pos.Y = 0;
        //        return pos;
        //    }
        //    var xdir = Xdir ? -1 : 1;
        //    var ydir = Ydir ? -1 : 1;
        //    pos.X = point.X + xdir * (Traypos.Row - TrayBasePos.Row) * m_tray.RowXoffset
        //        + xdir * (Traypos.Col - TrayBasePos.Col) * m_tray.ColumnXoffset;
        //    pos.Y = point.Y + ydir * (Traypos.Row - TrayBasePos.Row) * m_tray.RowYoffset
        //        + ydir * (Traypos.Col - TrayBasePos.Col) * m_tray.ColumnYoffset;
        //    return pos;
        //}
    }
}
