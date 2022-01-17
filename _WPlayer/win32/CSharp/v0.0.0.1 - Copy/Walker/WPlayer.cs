using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Walker {
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer {
        [return: MarshalAs(UnmanagedType.I4)]
        void SayHello(string a);
        void ShowPlayer(string fpath, bool play);
    }
    public class WPlayer : IWPlayer {

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref IWPlayer x) {
            x = new WPlayer();
            return true;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public void SayHello(string a) => MessageBox.Show("CSharp say hello to " + a, "CSharp MessageBox:");
        /// <summary>
        /// Load a SWF File in to WPlayer
        /// </summary>
        /// <param name="fpath">SWF file path</param>
        /// <param name="play">Play on start</param>
        public void ShowPlayer(string fpath = "", bool play = false) {
            WPlayerForm wl = new WPlayerForm();
            wl.LoadFile(fpath, play);
            wl.Show();
        }
    }
}
