using RGiesecke.DllExport;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WalkerPlayer.utils;
//https://docs.microsoft.com/en-us/dotnet/
//https://stackoverflow.com/questions/53529623/passing-string-from-delphi-to-c-sharp-returns-null-however-it-works-fine-when-i
namespace WalkerPlayer {
    // Options
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct OWPlayer {
        public int Type;
        public string Name;
        [MarshalAs(UnmanagedType.LPWStr)] public string FilePath;// swf file path
        [MarshalAs(UnmanagedType.LPWStr)] public string RootDir; // directory with xml setting
        public bool Hidden;  // input > 1 = True, 0 = False  
        public bool AutoPlay;
        public bool FullScreen;
        public bool FitToScreen;
        public bool CenterToScreen;
        public bool EscapeEnabled;
        internal void Print(string header, OWPlayer options) {
            string msg = header;
            foreach (var field in typeof(OWPlayer).GetFields(BindingFlags.Public | BindingFlags.Instance)) {
                msg += String.Format("\n\t{0} = {1}", field.Name, field.GetValue(options));
            }
            WPGlobal.Log("Delphi", msg);
        }
    }
    // Interface
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer {
        [return: MarshalAs(UnmanagedType.I4)]
        void SayHello(string a);
        void ShowPanel(bool state);
        //void LoadFile(string fpath, Dictionary<string, string> options);
        void LoadFile(OWPlayer options);
        void UnloadAll();
        void FullScreen(bool state);
    }
    // Class
    public class WPlayer : IWPlayer {
        // Loader Form instance
        private WPlayerForm wLoader;

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
        public void LoadFile(OWPlayer options) {

            if (wLoader == null || wLoader.IsDisposed) {

                wLoader = new WPlayerForm(); // create media projector window
                WPGlobal.CreateConsole(wLoader); // create hidden console
                WPGlobal.Log("Welcome To Walker Player Console!"); // type in main console tab
                WPGlobal.Log("CSharp", "WPlayer > LoadFile >\n\tInstance WPlayerForm Created."); // type in CSharp console tab
                WPGlobal.ConsoleHiddenMode(false);
            }
            wLoader.LoadFile(options);
        }
        public void UnloadAll() => wLoader?.RemoveAll(); // TODO Remove this
        public void ShowPanel(bool state) => wLoader?.ShowPanel(state);
        public void FullScreen(bool state) => wLoader?.SetFullScreen(state);
    }
}