using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WalkerPlayer {
    // Interface
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer {
        void Log(string tabName, string msg);
        void SayHello(string msg);
        void ShowPanel(bool state);
    }
    class WPlayer : IWPlayer {

        public static SwfForm swfForm;

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref IWPlayer x) {

            x = new WPlayer(); // create self instance
            swfForm = new SwfForm();
            return true;
        }

        public void Log(string tabName, string msg) => swfForm?.Log(tabName, msg);

        public void SayHello(string msg) {
            MessageBox.Show("CSharp receive you message:" + msg, "CSharp Interface:");
        }

        public void ShowPanel(bool state) => swfForm?.ShowPanel(state);
    }
}
