using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WalkerPlayer.bridge;
using WalkerPlayer.utils;

namespace WalkerPlayer {
    public partial class WPlayerForm : Form {

        private Size swfStartSize = new Size(1024, 768);
        public AxWalkerPlayer.AxShockwaveFlash FLWindow2D;
        public AxWalkerPlayer.AxShockwaveFlash FLWindow3D;
        private bool _isMediaLoaded;

        public WPlayerForm() {
            InitializeComponent();
        }

        internal void SetFullScreen(bool state) {
            if (state) {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            } else {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                if (_isMediaLoaded) this.ClientSize = new Size(swfStartSize.Width, swfStartSize.Height);
                CenterToScreen(); // TODO  test if wee use 3d window preview in rect
            }
        }

        internal void LoadFile(OWPlayer options) {


            WPGlobal.Log("CSharp", "WPlayerForm > LoadFile >\n\tfpath:{0}", options.FilePath);
            WPGlobal.Log("CSharp", "WPlayerForm > LoadFile >\n\tViewMode:{0}", options.ViewMode);

            if (!File.Exists(options.FilePath)) throw new FileNotFoundException("This file was not found.\n" + options.FilePath);

            FlashBridge.FlashOptions = options;
            AxWalkerPlayer.AxShockwaveFlash flComponent = CreateFlControll(options);
            flComponent.LoadMovie(0, options.FilePath);
        }

        private AxWalkerPlayer.AxShockwaveFlash CreateFlControll(OWPlayer options) {

            if (FLWindow2D != null) RemoveFLControll();
            //switch (options.ViewMode) {

            //    case "2D":
            //        break;

            //    case "3D":
            //        break;
            //}

            FLWindow2D = new AxWalkerPlayer.AxShockwaveFlash();
            FLWindow2D.BeginInit();
            FLWindow2D.Location = new Point();
            FLWindow2D.Name = "axFlash";
            FLWindow2D.TabIndex = 0;

            // Get controll which is embeded in to resources WPlayer.resx
            //ComponentResourceManager resources = new ComponentResourceManager(typeof(WPlayerForm));
            //FLWindow2D.OcxState = ((AxHost.State)(resources.GetObject("FLWindow2D.OcxState")));
            FLWindow2D.FlashCall += new AxWalkerPlayer._IShockwaveFlashEvents_FlashCallEventHandler(OnFlashCall);

            FLWindow2D.Size = ClientSize;
            FLWindow2D.EndInit();
            this.Controls.Add(FLWindow2D);

            //axFlash.DeviceFont = false;
            //axFlash.FrameNum = -1;
            //axFlash.Loop = true;
            FLWindow2D.Playing = options.AutoPlay;
            //axFlash.Profile = true;
            //axFlash.SAlign = "LT";
            FLWindow2D.WMode = "Direct"; // Direct or Window
            FLWindow2D.AllowScriptAccess = "Always";
            FLWindow2D.AllowNetworking = "all";
            //axFlash.EmbedMovie = false;
            FLWindow2D.Quality2 = "High";
            FLWindow2D.BGColor = "0xec9900";

            return FLWindow2D;
        }
        private void OnFlashCall(object sender, AxWalkerPlayer._IShockwaveFlashEvents_FlashCallEvent e) {
            FlashBridge.OnFlashWalkerCall(FLWindow2D, e);
        }

        private void RemoveFLControll() {

            WPGlobal.Log("CSharp", "WPlayerForm > RemoveFLControll >\n\tfpath:{0}", FLWindow2D);
            this.Controls.Remove(FLWindow2D);
            FLWindow2D.Dispose();
        }

        internal void ShowPanel(bool state) {
            if (state) this.Show(); else this.Hide();
        }
    }
}
