using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WalkerPlayer.bridge;
using WalkerPlayer.utils;
using WalkerPlayerConsole;

namespace WalkerPlayer {
    public partial class WPlayerForm : Form {

        private Size swfStartSize = new Size(1024, 768);
        private OWPlayer _options;
        private bool _isMediaLoaded;
        public WPlayerForm() {
            InitializeComponent();
        }

        public void LoadFile(OWPlayer options) {

            WPGlobal.Log("CSharp", "WPlayerForm > LoadFile >\n\tfpath:{0}", options.FilePath);
            _options = options;
            if (!File.Exists(options.FilePath)) throw new FileNotFoundException("This file was not found.\n" + options.FilePath);
            options.Print("LoadFile > info:", options);
            //FLComponent.Menu = false;
            //FLComponent.Loop = false;
            //FLComponent.WMode = "Direct";
            FLComponent.AllowScriptAccess = "Always";
            FLComponent.Quality2 = "High";
            //FLComponent.FlashVars = "auto_play=true&channel=adventuretimed&start_volume=25";
            //FLComponent.ControlAdded += new EventHandler(OnControlAdded);
            //FLComponent.FSCommand += FlashMovieFSCommand;
            //FLComponent.FlashCall += FlashMovieFlashCall;
            //FLComponent.LoadMovie(0, swf_Path);
            FLComponent.Movie = options.FilePath;
            FLComponent.Playing = options.AutoPlay;
            if (options.FitToScreen) FitPlayerToMediaSize(options.FilePath);
            if (options.CenterToScreen) CenterToScreen();
            SetFullScreen(options.FullScreen);
            // FLComponent.AllowFullScreen = fullScreen ? "true" : "false";
            if (!options.Hidden) Show();
            _isMediaLoaded = true;
        }

        private void FitPlayerToMediaSize(string fpath) {
            Console.WriteLine("LoadFile > w:{0} h:{1}", FLComponent.Width, FLComponent.Height);
            try {
                SwfParser swfParser = new SwfParser();
                Rectangle rectangle = swfParser.GetDimensions(fpath);
                swfStartSize = new Size(rectangle.Width, rectangle.Height);
                FLComponent.Width = swfStartSize.Width;
                FLComponent.Height = swfStartSize.Height;
                FitPlayerToProportionallyToWindow();
            }
            catch (Exception ex) {
                Console.WriteLine("There is a problem with the swf file. " + ex.Message);
            }
            Console.WriteLine("\tw:{0} h:{1}", FLComponent.Width, FLComponent.Height);
        }

        private void OnFlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e) {

            FlashArgsGet data = FlashBridge.GetCommand(e.request);
            WPGlobal.Log("Flash", "WPlayerForm > OnFlashCall >\n\t Data:{0}", data);
            switch (data.ProcessType) {
                case "FLASH_UI_READY":
                    // When flash loads send it RottDir ( directory with xml settings )
                    string dir = _options.RootDir;
                    FlashBridge.SendCommand(FLComponent, new FlashArgsSend("GET_APP_DIR", dir));
                    break;
                case "FLASH_LOG":
                    // Flash debug output displayed in CSharp console
                    string[] logArgs = FlashDataParser.GetLogDataFromStringArray(data.ParamsList);
                    WPGlobal.Log(logArgs[0], logArgs[1]);
                    break;
                case "READ_FILE":
                    // Read a file and send result back to Flash
                    string text = WPFso.ReadFile(data.ParamsList[0]);
                    FlashBridge.SendCommand(FLComponent, new FlashArgsSend("READ_FILE", text));
                    break;
                case "SAVE_FILE":
                   
                    break;
            }
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
            
            if (e.KeyCode == Keys.Escape && _options.EscapeEnabled) {

                SetFullScreen(false);
                WPGlobal.Log("CSharp", "WPlayerForm > OnFormKeyDown > Exit FullScreen.");
                // prevent child controls from handling this event as well
                e.SuppressKeyPress = true;

            } else if (e.Control && e.Shift && e.KeyCode == Keys.E) {

                WPGlobal.ShowConsole(true);
            }
        }
        private void OnFormResize(object sender, EventArgs e) {

            if (!_options.FitToScreen) return;
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
            FLComponent.Width = (int)(swfStartSize.Width * ratio);
            FLComponent.Height = (int)(swfStartSize.Height * ratio);
            // Center component to Window Form
            FLComponent.Location = new Point(
                (maxWidth - FLComponent.Width) / 2,
                (maxHeight - FLComponent.Height) / 2
            );
        }

        // Disable the context menu on a flash control added to form (by JayJayson)
        private void OnFormLoad(object sender, EventArgs e) {
            // Assign the handle of your flash control to the ControlWatcher class.  
            new ControlWatcher(FLComponent.Handle);
        }
    }
}

//Screen.PrimaryScreen.Bounds.Width
//Screen.PrimaryScreen.Bounds.Height

//FlashBridge.SendCommand(new FlashArgsSend("CLOSE_WINDOW", "box_email"));