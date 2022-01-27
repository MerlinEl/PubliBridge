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
        public string ViewMode;
        [MarshalAs(UnmanagedType.LPWStr)] public string FilePath;// swf file path
        [MarshalAs(UnmanagedType.LPWStr)] public string RootDir; // directory with xml setting
        public bool HiddenPlayer;  // input > 1 = True, 0 = False  
        public bool HiddenConsole;
        public bool AutoPlay;
        public bool FullScreen;
        public bool FitToScreen;
        public bool CenterToScreen;
        public bool EscapeEnabled;
        public bool SkipLogo;
        public new string ToString {
            get {
                string msg = "";
                foreach (var field in typeof(OWPlayer).GetFields(BindingFlags.Public | BindingFlags.Instance)) {
                    msg += String.Format("\n\t{0} = {1}", field.Name, field.GetValue(this));
                }
                return msg;
            }
        }
    }
    // Interface
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer {
        void Log(string tabName, string msg);
        void SayHello(string msg);
        void ShowPanel(bool state);
        //void LoadFile(string fpath, Dictionary<string, string> options);
        void LoadFile(OWPlayer options);
        void UnloadAll();
        void FullScreen(bool state);
        string OptionsToString(OWPlayer options);
    }
    // Class
    public class WPlayer : IWPlayer {

        // -------------------- //
        // Loader Form instance //
        // -------------------> //

        public static WPlayerForm wLoader;

        // <------------------- //

        // Constructor
        public WPlayer() {

            InitializeInterface();
        }

        private void InitializeInterface() {

            wLoader = new WPlayerForm(); // create media projector window
            WPGlobal.CreateConsole(wLoader); // create hidden console
            WPGlobal.Log("Welcome To Walker Player Console!"); // type in main console tab
            WPGlobal.Log("CSharp", "WPlayer > LoadFile >\n\tInstance WPlayerForm Created."); // type in CSharp console tab
        }

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref IWPlayer x) {

            x = new WPlayer(); // create self instance
            return true;
        }

        public void FullScreen(bool state) => wLoader?.SetFullScreen(state);

        /// <summary>
        /// Load a SWF File in to WPlayer
        /// </summary>
        /// <param name="options">Player Optional Args</param>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        public void LoadFile(OWPlayer options) {

            if (wLoader == null || wLoader.IsDisposed) InitializeInterface();
            ShowPanel(true);
            WPGlobal.ConsoleHiddenMode(options.HiddenConsole);
            wLoader.LoadFile(options);
        }

        public void Log(string tabName, string msg) {
            WPGlobal.Log(tabName, msg);
        }

        public void SayHello(string msg) => MessageBox.Show("CSharp say hello to " + msg, "CSharp MessageBox:");

        public void ShowPanel(bool state) => wLoader?.ShowPanel(state);

        public void UnloadAll() {  // TODO Remove this
            throw new NotImplementedException();
        }

        public string OptionsToString(OWPlayer options) {
            return options.ToString;
        }
    }
}