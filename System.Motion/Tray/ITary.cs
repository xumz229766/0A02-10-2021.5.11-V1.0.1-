using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ToolKit;
using System.Drawing;

namespace System.Tray
{
    interface ITary
    {
        string Type { get; set; }

        string Name { get; set; }

        int Row { get; set; }//托盘行数

        EStartPos StartPose { get; set; }
        EIndexDirect Direction { get; set; }
        int Column { get; set; }//托盘列数

        string Empty { get; }

        int CurrentPos { get; set; }
        int StartPos { get; set; }
        int EndPos { get; set; }

        void InitTray(string start, string direct, string lineType, string strEmpty);

        void SortTray(EStartPos start, EIndexDirect direct, EChangeLine lineType);

        int FindPos(Index _pos);

        void AddEmptyPos(string r_c);

        void RemoveEmptyPos(string r_c);

        bool IsExistEmpty(Index _pos);

        //string GetStringEmpty();
        void SetNumColor(int num, Color bColor);
      


    }

    public enum EStartPos
    {
        左上角,
        左下角,
        右上角,
        右下角
    }
    public enum EIndexDirect
    {
        行,
        列
    }
    public enum EChangeLine
    {
        Z,
        S
    }
}
