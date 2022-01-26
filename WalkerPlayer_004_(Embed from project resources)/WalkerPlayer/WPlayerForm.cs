using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WalkerPlayer.Properties;

namespace WalkerPlayer {
    public partial class WPlayerForm : Form {
        
        public static AxShockwaveFlash axFlash;
        public WPlayerForm() {
            InitializeComponent();
            InitializeFlash();
        }

        private void InitializeFlash() {

            axFlash = new AxShockwaveFlash();
            axFlash.BeginInit();
            axFlash.Location = new Point();
            axFlash.Name = "axFlash";
            axFlash.TabIndex = 0;
            axFlash.EndInit();
            this.Controls.Add(axFlash);
        }

        public void CreateFlashComponentAndLoadMedia(OWPlayer options) {
    
            this.Controls.Remove(axFlash);
            axFlash.Dispose();
            
            if (!File.Exists(options.FilePath)) return;

            axFlash = new AxShockwaveFlash();
            axFlash.BeginInit();
            axFlash.Location = new Point();
            axFlash.Name = "axFlash";
            axFlash.TabIndex = 0;

            // use this if controll is embeded in to resources WPlayer.resx
            //ComponentResourceManager resources = new ComponentResourceManager(typeof(WPlayerForm));
            //axFlash.OcxState = ((AxHost.State)(resources.GetObject("axFlash.OcxState")));

            // loading flash.ocx from Project Resources
            byte[] inputBytes = Resources.Flash32_14_0_0_176;
            Stream stream = new MemoryStream(inputBytes);
            axFlash.OcxState = new AxHost.State(stream, 1, false, null);

            axFlash.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(this.OnFlashWalkerCall);
            axFlash.Size = ClientSize;
            axFlash.EndInit();
            this.Controls.Add(axFlash);

            //axFlash.DeviceFont = false;
            //axFlash.FrameNum = -1;
            //axFlash.Loop = true;
            axFlash.Playing = options.AutoPlay;
            //axFlash.Profile = true;
            //axFlash.SAlign = "LT";
            axFlash.WMode = "Direct"; // Direct or Window
            axFlash.AllowScriptAccess = "Always";
            axFlash.AllowNetworking = "all";
            //axFlash.EmbedMovie = false;
            axFlash.Quality2 = "High";
            axFlash.BGColor = "0xec9900";
            axFlash.LoadMovie(0, options.FilePath);
        }

        private void OnFlashWalkerCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
            throw new NotImplementedException();
        }

        internal void SetFullScreen(bool state) {
            throw new NotImplementedException();
        }

        public void LoadFile(OWPlayer options) {

            Show();
            CreateFlashComponentAndLoadMedia(options);
        }

        public void LoadFile(string fpath) {

            OWPlayer options = new OWPlayer().SetDefault();
            options.FilePath = fpath;
            CreateFlashComponentAndLoadMedia(options);
            Show();
        }

        internal void ShowPanel(bool state) {
            Show();
        }
    }
}
