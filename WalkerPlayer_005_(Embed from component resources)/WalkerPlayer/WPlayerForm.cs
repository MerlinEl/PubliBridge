using System;
using System.IO;
using System.Windows.Forms;

namespace WalkerPlayer {
    public partial class WPlayerForm : Form {
        
        public WPlayerForm() {
            InitializeComponent();
        }

        public void CreateFlashComponentAndLoadMedia(OWPlayer options) {
    
            //this.Controls.Remove(axShockwaveFlash1);
            //axShockwaveFlash1.Dispose();
            
            if (!File.Exists(options.FilePath)) return;

            //axShockwaveFlash1 = new AxShockwaveFlash();
            //axShockwaveFlash1.BeginInit();
            //axShockwaveFlash1.Location = new Point();
            //axShockwaveFlash1.Name = "axFlash";
            //axShockwaveFlash1.TabIndex = 0;

            // use this if controll is embeded in to resources WPlayer.resx
            //ComponentResourceManager resources = new ComponentResourceManager(typeof(WPlayerForm));
            //axShockwaveFlash1.OcxState = ((AxHost.State)(resources.GetObject("axFlash.OcxState")));
            //axShockwaveFlash1.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(this.OnFlashWalkerCall);

            axShockwaveFlash1.Size = ClientSize;
            //axShockwaveFlash1.EndInit();
            //this.Controls.Add(axShockwaveFlash1);

            //axFlash.DeviceFont = false;
            //axFlash.FrameNum = -1;
            //axFlash.Loop = true;
            axShockwaveFlash1.Playing = options.AutoPlay;
            //axFlash.Profile = true;
            //axFlash.SAlign = "LT";
            axShockwaveFlash1.WMode = "Direct"; // Direct or Window
            axShockwaveFlash1.AllowScriptAccess = "Always";
            axShockwaveFlash1.AllowNetworking = "all";
            //axFlash.EmbedMovie = false;
            axShockwaveFlash1.Quality2 = "High";
            axShockwaveFlash1.BGColor = "0xec9900";
            axShockwaveFlash1.LoadMovie(0, options.FilePath);
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

        private void OnWalkerPlayerCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e) {

        }
    }
}
