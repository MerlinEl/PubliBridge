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
        public int _Type;           // Type is a reserved word in Delphi  
        public string Name;
        public string MediaType;    // AUDIO, VIDEO, IMAGES, LESSON, STAGE3D
        public string WindowSize;   // Window position size AUTO or 800,600
        public string WindowPos;    // Window position CENTER or 120,120
        [MarshalAs(UnmanagedType.LPWStr)] public string FilePath;// swf file path
        [MarshalAs(UnmanagedType.LPWStr)] public string RootDir; // directory with xml setting
        public bool HiddenPlayer;   // input > 1 = True, 0 = False  
        public bool HiddenConsole;
        public bool AutoPlay;
        public bool Resizable;
        public bool FitToScreen;
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
        public OWPlayer GetDefault() {

            Name = "FLOptions";
            MediaType = "Lesson";
            WindowSize = "AUTO"; // or 800,600
            WindowPos = "CENTER"; // or 100,100  
            FilePath = "";
            RootDir = "";
            HiddenPlayer = false;
            HiddenConsole = false;
            AutoPlay = true;
            Resizable = false;
            FitToScreen = true;
            EscapeEnabled = true;
            SkipLogo = false;
            return this;
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

        //public static bool GetDefaultOptions2(ref OWPlayer x) {
        //    x = new OWPlayer().GetDefault();
        //    return true;
        //}

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

/*
      internal void FixMissing() {
            OWPlayer defautOptions = GetDefault();
            if (String.IsNullOrEmpty(Name)) Name = defautOptions.Name;
            if (String.IsNullOrEmpty(MediaType)) MediaType = defautOptions.MediaType;
            if (String.IsNullOrEmpty(WindowSize)) WindowSize = defautOptions.WindowSize;
            if (String.IsNullOrEmpty(WindowPos)) WindowPos = defautOptions.WindowPos;
            if (String.IsNullOrEmpty(FilePath)) FilePath = defautOptions.FilePath;
            if (String.IsNullOrEmpty(RootDir)) RootDir = defautOptions.RootDir;
        }
 * 
        public (string, int, bool) GetValueByName(string fieldName){
            
            (string, int, bool) result;
            result.Item1 = "";
            result.Item2 = 0;
            result.Item3 = false;

            foreach (var field in typeof(OWPlayer).GetFields(BindingFlags.Public | BindingFlags.Instance)) {
                if (field.Name == fieldName) {

                    var val = field.GetValue(this);
                    Type t = val.GetType();
                    if (t.Equals(typeof(string))) {
                       
                        result.Item1 = (string)val;

                    } else if (t.Equals(typeof(int))) {

                        result.Item2 = (int)val;

                    } else if (t.Equals(typeof(bool))) {

                        result.Item3 = (bool)val;
                    }
                }
            }
            return result;
        }

        internal void SetMissingToDefault() {
            foreach (var field in typeof(OWPlayer).GetFields(BindingFlags.Public | BindingFlags.Instance)) {

                if (field.GetValue(this) == null) {
                    
                    field.SetValue(this, GetValueByName(field.Name));
                }
            }
        }
 */