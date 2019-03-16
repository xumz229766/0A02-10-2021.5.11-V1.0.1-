using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Framework
{
    public interface IPLCModel : IDevice
    {
        int ReadDeviceBlock(string szDevice, int dwSize, out int lpdwData);
        Int16[] ReadInt16Array(string str, int n);
        Int32[] ReadInt32Array(string str, int n);
        int WriteDeviceBlock(string szDevice, int dwSize, ref int lpdwData);
        void WriteInt16Array(string str, Int16[] values);
        void WriteInt32Array(string str, Int32[] values);

        //int SetBitDevice(string iDeviceName, int iSize, byte[] onOffBits);
        //int SetBitDevice(PlcDeviceType iType, int iAddress, int iSize, byte[] onOffBits);
        //int GetBitDevice(string iDeviceName, int iSize, byte[] outOnOffBits);
        //int GetBitDevice(PlcDeviceType iType, int iAddress, int iSize, byte[] outOnOffBits);
        //int WriteDeviceBlock(string iDeviceName, int iSize, int[] iData);
        //int WriteDeviceBlock(PlcDeviceType iType, int iAddress, int iSize, int[] iData);
        //int ReadDeviceBlock(string iDeviceName, int iSize, int[] oData);
        //int ReadDeviceBlock(PlcDeviceType iType, int iAddress, int iSize, int[] oData);
        //int SetDevice(string iDeviceName, int iData);
        //int SetDevice(PlcDeviceType iType, int iAddress, int iData);
        //int GetDevice(string iDeviceName, out int oData);
        //int GetDevice(PlcDeviceType iType, int iAddress, out int oData);
    }
}
