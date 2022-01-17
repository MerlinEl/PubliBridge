using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Walker {
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer {
        [return: MarshalAs(UnmanagedType.I4)]
        void SayHello(string a);
        void ShowPlayer();
        void HidePlayer();
        void LoadFile(string fpath, bool play);
        void UnloadAll();
    }
    public class WPlayer : IWPlayer {
       
        private readonly WPlayerForm wPlayer = new WPlayerForm(); // create window swf 

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref IWPlayer x) {

            x = new WPlayer(); // create self instance
            return true;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public void SayHello(string a) => MessageBox.Show("CSharp say hello to " + a, "CSharp MessageBox:");
        /// <summary>
        /// Load a SWF File in to WPlayer
        /// </summary>
        /// <param name="fpath">SWF file path</param>
        /// <param name="play">Play on start</param>
        public void LoadFile(string fpath = "", bool play = false) => wPlayer.LoadFile(fpath, play);

        public void ShowPlayer() => wPlayer.Show();

        public void HidePlayer() => wPlayer.Hide();

        public void UnloadAll() => wPlayer.RemoveSWFComponent();
    }
}
