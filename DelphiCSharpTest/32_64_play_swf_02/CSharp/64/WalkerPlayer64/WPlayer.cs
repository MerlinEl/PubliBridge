using RGiesecke.DllExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WalkerPlayer64;

namespace WalkerPlayer {
    // Interface
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer {
        void Log(string tabName, string msg);
        void SayHello(string msg);
        void ShowPanel(bool state);
    }
    class WPlayer : IWPlayer {

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref IWPlayer x) {

            x = new WPlayer(); // create self instance
            return true;
        }

        public void Log(string tabName, string msg) {
            throw new NotImplementedException();
        }

        public void SayHello(string msg) {
            throw new NotImplementedException();
        }

        public void ShowPanel(bool state) => new Form1().ShowPanel(state);
    }
}
