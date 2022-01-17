using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//https://docs.microsoft.com/en-us/dotnet/
namespace cshpdll {

    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer {
        [return: MarshalAs(UnmanagedType.I4)]
        void SayHello(string a);
        void Display(bool state);
        void LoadFile(string fpath, bool autoPlay, bool fullScreen);
        void UnloadAll();
        void FullScreen(bool state);
    }
    public class WPlayer : IWPlayer {
        // Loader instance
        private readonly WPlayerForm wLoader = new WPlayerForm();

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref IWPlayer x) {

            //wPlayer = new WPlayerForm(); // create window swf projector;
            x = new WPlayer(); // create self instance
            return true;
        }

        [return: MarshalAs(UnmanagedType.I4)]
        public void SayHello(string a) => MessageBox.Show("CSharp say hello to " + a, "CSharp MessageBox:");
        /// <summary>
        /// Load a SWF File in to WPlayer
        /// </summary>
        /// <param name="fpath">SWF file path</param>
        /// <param name="autoPlay">Play on start</param>
        public void LoadFile(string fpath, bool autoPlay, bool fullScreen) => wLoader.LoadFile(fpath, autoPlay, fullScreen);
        //public void LoadFile(string fpath = "", bool autoPlay = false) => wLoader?.LoadFile(fpath, autoPlay);


        public void UnloadAll() => wLoader.RemoveAll();

        public void Display(bool state) => wLoader.Display(state);

        public void FullScreen(bool state) => wLoader.FullScreenMode = state;
    }
}