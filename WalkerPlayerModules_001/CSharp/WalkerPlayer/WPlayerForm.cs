using AxShockwaveFlashObjects;
using System.Drawing;
using System.Windows.Forms;
using WalkerPlayer.bridge;
using WalkerPlayer.player;
using WalkerPlayer.utils;

namespace WalkerPlayer {
    public partial class WPlayerForm : Form {

        //public static bool IsClosed;
        private bool _isMediaLoaded;

        public bool IsMediaLoaded { get => _isMediaLoaded; set => _isMediaLoaded = value; }

        public WPlayerForm() {
            InitializeComponent();
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //Application.SetCompatibleTextRenderingDefault(false);
        }

        internal void SetFullScreen(bool state) {
            if (state) {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                //if (IsMediaLoaded) FlControll.Size = new Size();
            } else {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FlashBridge.FlashOptions.Resizable ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
                if (IsMediaLoaded) this.ClientSize = new Size(WPWindow.swfStartSize.Width, WPWindow.swfStartSize.Height);
                CenterToScreen(); // TODO  test if wee use 3d window preview in rect
            }
        }

        /// <summary>
        /// All Flash Interfaces (AudioPlayer, VideoPlayer, LessonPlayer, Projector3DPlayer, etc..) will be loaded only in FLWindow2D component
        /// If is 2D will be in mode Window and if is 3D will be in mode Direct
        /// </summary>
        internal void LoadFile(OWPlayer options) {

            WPGlobal.Log("CSharp", "WPlayerForm > LoadFile >\n\tMediaType:{0}\n\tAutoPlay:{1}", options.MediaType, options.AutoPlay);
            //options.FixMissing();
            FlashBridge.FlashOptions = options;
            FlControll.AllowScriptAccess = "Always";
            FlControll.Quality2 = "High";
            Text = options.Name;
            WPWindow.SetupPlayer(this, FlControll, options);
        }

        internal void CloseWindow() {
            // Remove controll before form close (else error okurek)
            Controls.Remove(FlControll);
            FlControll = null;
            Close();
        }


        internal void ShowPanel(bool state) {
            if (state) this.Show(); else this.Hide();
        }

        private void OnFlashWalkerCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
            FlashBridge.OnFlashWalkerCall((AxShockwaveFlash)sender, e);
        }

        // Disable the context menu on a flash control added to form (by JayJayson)
        private void OnFormLoad(object sender, System.EventArgs e) {
            // Assign the handle of your flash control to the ControlWatcher class.  
            new ControlWatcher(FlControll.Handle);
        }

        private void OnFormResize(object sender, System.EventArgs e) {

            //if (!FlashBridge.FlashOptions.FitToScreen) return;
            //FitPlayerToProportionallyToWindow();
        }


        // X Replacement Removed
        /// <summary>
        /// Replace "(X) Close" button function with "Hide"
        /// </summary>
        //private bool _allowClose = false;
        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            WPGlobal.DisposeConsole();
            // X Replacement Removed
            //if (!_allowClose && e.CloseReason == CloseReason.UserClosing) {
            //    e.Cancel = true;
            //    Hide();
            //}
        }

        // To enable Form Keyboard Events set KeyPreview = true;
        private void OnFormKeyDown(object sender, KeyEventArgs e) {
            // X Replacement Removed
            //if (e.Alt && e.KeyCode == Keys.F4) {

            //    _allowClose = true;
            //} else 

            if (e.KeyCode == Keys.Escape && FlashBridge.FlashOptions.EscapeEnabled) {

                SetFullScreen(false);
                WPGlobal.Log("CSharp", "WPlayerForm > OnFormKeyDown > Exit FullScreen.");
                // prevent child controls from handling this event as well
                e.SuppressKeyPress = true;

            } else if (e.Control && e.Shift && e.KeyCode == Keys.E) {

                WPGlobal.ShowConsole(true);
            }
        }

        internal void CenterWindowToScreen() {
            CenterToScreen();
        }
    }
}
