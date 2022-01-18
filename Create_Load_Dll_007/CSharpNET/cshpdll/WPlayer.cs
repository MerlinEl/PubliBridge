using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
//https://docs.microsoft.com/en-us/dotnet/
//https://stackoverflow.com/questions/53529623/passing-string-from-delphi-to-c-sharp-returns-null-however-it-works-fine-when-i
namespace cshpdll {
    // Options
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct OWPlayer {
        public int Type;
        public string Name;
        [MarshalAs(UnmanagedType.LPWStr)] public string FilePath;
        public bool Hidden;  // input > 1 = True, 0 = False  
        public bool AutoPlay;
        public bool FullScreen;
        public bool FitToScreen;
        public bool CenterToScreen;
    }
    // Interface
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer {
        [return: MarshalAs(UnmanagedType.I4)]
        void SayHello(string a);
        void Display(bool state);
        //void LoadFile(string fpath, Dictionary<string, string> options);
        void LoadFile(OWPlayer options);
        void UnloadAll();
        void FullScreen(bool state);
    }
    // Class
    public class WPlayer : IWPlayer {
        
        // Loader Form instance
        private static WPlayerForm wLoader = new WPlayerForm(); // create window swf projector

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
        /// <param name="options">Player Optional Args</param>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        public void LoadFile(OWPlayer options) => wLoader.LoadFile(options);

        public void UnloadAll() => wLoader.RemoveAll();

        public void Display(bool state) => wLoader.Display(state);

        public void FullScreen(bool state) => wLoader.FullScreenMode = state;
    }
}