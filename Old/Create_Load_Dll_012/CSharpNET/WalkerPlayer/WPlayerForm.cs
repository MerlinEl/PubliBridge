using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WalkerPlayer.bridge;
using WalkerPlayer.utils;

namespace WalkerPlayer {
    public partial class WPlayerForm : Form {

        private Size swfStartSize = new Size(1024, 768);
        private bool _isMediaLoaded;
        public WPlayerForm() {
            InitializeComponent();

            // temp setup Move to elsewhere
            FLWindow3D.Visible = false;
            FLWindow3D.Location = new Point();
            FLWindow3D.Size = new Size(800, 800);
            FLWindow3D.BGColor = "0xec9900";
            FLWindow3D.AllowScriptAccess = "Always";
            FLWindow3D.Quality2 = "High";
            FLWindow2D.Playing = true;
        }

        public void LoadFile(OWPlayer options) {

            //var flWindow = options.ViewMode == "2D" ? FLWindow2D : FLWindow3D;

            WPGlobal.Log("CSharp", "WPlayerForm > LoadFile >\n\tfpath:{0}", options.FilePath);
            WPGlobal.Log("CSharp", "WPlayerForm > LoadFile >\n\tViewMode:{0}", options.ViewMode);
            FlashBridge.FlashOptions = options;
            if (!File.Exists(options.FilePath)) throw new FileNotFoundException("This file was not found.\n" + options.FilePath);
            //FLComponent.Menu = false;
            //FLComponent.Loop = false;
            //FLComponent.WMode = "Direct";
            FLWindow2D.AllowScriptAccess = "Always";
            FLWindow2D.Quality2 = "High";
            //FLComponent.FlashVars = "auto_play=true&channel=adventuretimed&start_volume=25";
            //FLComponent.ControlAdded += new EventHandler(OnControlAdded);
            //FLComponent.FSCommand += FlashMovieFSCommand;
            //FLComponent.FlashCall += FlashMovieFlashCall;
            //FLComponent.LoadMovie(0, swf_Path);
            FLWindow2D.Movie = options.FilePath;
            FLWindow2D.Playing = options.AutoPlay;
            if (options.FitToScreen) FitPlayerToMediaSize(options.FilePath);
            if (options.CenterToScreen) CenterToScreen();
            SetFullScreen(options.FullScreen);
            // FLComponent.AllowFullScreen = fullScreen ? "true" : "false";
            if (!options.HiddenPlayer) Show();
            _isMediaLoaded = true;
        }

        private void FitPlayerToMediaSize(string fpath) {
            Console.WriteLine("LoadFile > w:{0} h:{1}", FLWindow2D.Width, FLWindow2D.Height);
            try {
                SwfParser swfParser = new SwfParser();
                Rectangle rectangle = swfParser.GetDimensions(fpath);
                swfStartSize = new Size(rectangle.Width, rectangle.Height);
                FLWindow2D.Width = swfStartSize.Width;
                FLWindow2D.Height = swfStartSize.Height;
                FitPlayerToProportionallyToWindow();
            }
            catch (Exception ex) {
                Console.WriteLine("There is a problem with the swf file. " + ex.Message);
            }
            Console.WriteLine("\tw:{0} h:{1}", FLWindow2D.Width, FLWindow2D.Height);
        }

        internal void RemoveAll() {
            throw new NotImplementedException();
        }

        internal void ShowPanel(bool state) {
            if (state) this.Show(); else this.Hide();
        }
        internal void SetFullScreen(bool state) {
            if (state) {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            } else {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.ClientSize = new Size(swfStartSize.Width, swfStartSize.Height);
                if (_isMediaLoaded) CenterToScreen();
            }
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
        private void OnFormResize(object sender, EventArgs e) {

            if (!FlashBridge.FlashOptions.FitToScreen) return;
            FitPlayerToProportionallyToWindow();
        }

        private void FitPlayerToProportionallyToWindow() {
            // Obtain form's inner width and height
            var maxWidth = this.ClientSize.Width;
            var maxHeight = this.ClientSize.Height;
            // Fit component to Winfow Form
            var ratioX = (double)maxWidth / swfStartSize.Width;
            var ratioY = (double)maxHeight / swfStartSize.Height;
            var ratio = Math.Min(ratioX, ratioY);
            FLWindow2D.Width = (int)(swfStartSize.Width * ratio);
            FLWindow2D.Height = (int)(swfStartSize.Height * ratio);
            // Center component to Window Form
            FLWindow2D.Location = new Point(
                (maxWidth - FLWindow2D.Width) / 2,
                (maxHeight - FLWindow2D.Height) / 2
            );
        }

        // Disable the context menu on a flash control added to form (by JayJayson)
        private void OnFormLoad(object sender, EventArgs e) {
            // Assign the handle of your flash control to the ControlWatcher class.  
            new ControlWatcher(FLWindow2D.Handle);
        }

        private void OnFlashWalkerCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e) {
            FlashBridge.OnFlashWalkerCall(sender, e);
        }

        private void OnFlashProjectorCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e) {
            FlashBridge.OnFlashProjectorCall(sender, e);
        }
    }
}

//Screen.PrimaryScreen.Bounds.Width
//Screen.PrimaryScreen.Bounds.Height

//FlashBridge.SendCommand(new FlashArgsSend("CLOSE_WINDOW", "box_email"));