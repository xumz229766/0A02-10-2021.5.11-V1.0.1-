using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace desay
{
    public enum SpliceAlarm:int
    {
        无消息,
        初始化故障,
        无杆气缸回原点超时,
        无杆气缸上升时感应超时,
        无杆气缸下降时感应超时
    }
    public enum BufferAlarm : int
    {
        无消息,
        初始化故障

    }
    public enum FeederAlarm : int
    {
        无消息,
        初始化故障

    }
    public enum MoveAlarm : int
    {
        无消息,
        初始化故障

    }
    public enum LeftCAlarm : int
    {
        无消息,
        初始化故障

    }
    public enum LeftCutAlarm : int
    {
        无消息,
        初始化故障
    }
    public enum RightCAlarm : int
    {
        无消息,
        初始化故障
    }
    public enum RightCutAlarm : int
    {
        无消息,
        初始化故障
    }
    public enum PlateformAlarm : int
    {
        无消息,
        初始化故障,
        台面上已有承盘设置报错,
        坐标计算失败Tray盘设置出错,
        卡紧气缸或取放盘气缸没有复位
    }
    public enum StoreAlarm : int
    {
        无消息,
        初始化故障,
        设备气压低故障
    }
}
