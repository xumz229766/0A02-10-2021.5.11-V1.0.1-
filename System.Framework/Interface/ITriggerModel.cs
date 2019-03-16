using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Framework
{
    public delegate void DataReceiveCompleteEventHandler(object sender, string result);

    public struct TriggerArgs
    {
        public object sender;
        public byte tryTimes;
        public string message;
    }

    public interface ITriggerModel : IDevice
    {
        event DataReceiveCompleteEventHandler DeviceDataReceiveCompelete;

        IAsyncResult BeginTrigger(TriggerArgs args);
        string Execute(string cmd);
        void Trigger(TriggerArgs args);
        string StopTrigger();
    }

    public interface ISerialPortTriggerModel : ISerialPort, ITriggerModel { }
    public interface INetworkTriggerModel : INetWork, ITriggerModel { }

}
