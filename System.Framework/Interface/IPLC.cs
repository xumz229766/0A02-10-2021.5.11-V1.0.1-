using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Framework
{
    public interface IPLC<PLCDeviceType,T> :IAutomatic,IDisposable
    {
        string ConnectionParam { get; set; }
        int Open();
        int Close();
        void SetConnectionParam(string param);
        int SetBitDevice(string iDeviceName, int iSize, byte[] onOffBits);
        int SetBitDevice(PLCDeviceType iType, int iAddress, int iSize, byte[] onOffBits);
        int GetBitDevice(string iDeviceName, int iSize, byte[] outOnOffBits);
        int GetBitDevice(PLCDeviceType iType, int iAddress, int iSize, byte[] outOnOffBits);
        int WriteDeviceBlock(string iDeviceName, int iSize, ref T[] iData);
        int WriteDeviceBlock(PLCDeviceType iType, int iAddress, int iSize, ref T[] iData);
        int ReadDeviceBlock(string iDeviceName, int iSize,out T[] oData);
        int ReadDeviceBlock(PLCDeviceType iType, int iAddress, int iSize,out T[] oData);
        int SetDevice(string iDeviceName, T iData);
        int SetDevice(PLCDeviceType iType, int iAddress, T iData);
        int GetDevice(string iDeviceName, out T oData);
        int GetDevice(PLCDeviceType iType, int iAddress, out T oData);
    }
}
