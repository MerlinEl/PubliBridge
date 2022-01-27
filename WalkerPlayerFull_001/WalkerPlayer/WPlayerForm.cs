using AxShockwaveFlashObjects;
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

        /// <summary>
        /// All Flash Interfaces (AudioPlayer, VideoPlayer, LessonPlayer, Projector3DPlayer, etc..) will be loaded only in FLWindow2D component
        /// If is 2D will be in mode Window and if is 3D will be in mode Direct
        /// </summary>
        internal void LoadFile(OWPlayer options) {

            //FlashBridge.FlashOptions = options;
            //AxShockwaveFlash flComponent = CreateFlControll(options);
            //flComponent.LoadMovie(0, options.FilePath);

            WPGlobal.Log("CSharp", "WPlayerForm > LoadFile >\n\tfpath:{0}", options.FilePath);
            WPGlobal.Log("CSharp", "WPlayerForm > LoadFile >\n\tViewMode:{0}", options.ViewMode);
            FlashBridge.FlashOptions = options;
            if (!File.Exists(options.FilePath)) throw new FileNotFoundException("This file was not found.\n" + options.FilePath);
            //FLWindow2D.Menu = false;
            //FLWindow2D.Loop = false;
            FLWindow2D.WMode = options.ViewMode == "2D" ? "Window" : "Direct";
            FLWindow2D.AllowScriptAccess = "Always";
            FLWindow2D.Quality2 = "High";
            //FLWindow2D.FlashVars = "auto_play=true&channel=adventuretimed&start_volume=25";
            //FLWindow2D.ControlAdded += new EventHandler(OnControlAdded);
            //FLWindow2D.FSCommand += FlashMovieFSCommand;
            //FLWindow2D.FlashCall += FlashMovieFlashCall;
            //FLWindow2D.LoadMovie(0, swf_Path);
            FLWindow2D.Movie = options.FilePath;
            FLWindow2D.Playing = options.AutoPlay;
            if (options.FitToScreen) FitPlayerToMediaSize(options.FilePath);
            if (options.CenterToScreen) CenterToScreen();
            SetFullScreen(options.FullScreen);
            // FLWindow2D.AllowFullScreen = fullScreen ? "true" : "false";
            if (!options.HiddenPlayer) Show();
            _isMediaLoaded = true;
        }

        private void ReloadSwfMedia(AxShockwaveFlash flComponent, string fpath) {
            
            //byte[] fileContent = File.ReadAllBytes(Application.StartupPath + @"\yourflashfile.swf");
            byte[] fileContent = File.ReadAllBytes(fpath);

            if (fileContent != null && fileContent.Length > 0) {
                using (MemoryStream stm = new MemoryStream()) {
                    using (BinaryWriter writer = new BinaryWriter(stm)) {
                        /* Write length of stream for AxHost.State */
                        writer.Write(8 + fileContent.Length);
                        /* Write Flash magic 'fUfU' */
                        writer.Write(0x55665566);
                        /* Length of swf file */
                        writer.Write(fileContent.Length);
                        writer.Write(fileContent);
                        stm.Seek(0, SeekOrigin.Begin);
                        /* 1 == IPeristStreamInit */
                        //Same as LoadMovie()
                        flComponent.OcxState = new AxHost.State(stm, 1, false, null);
                    }
                }
                fileContent = null;
                GC.Collect();
            }
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

        private AxShockwaveFlash CreateFlControll(OWPlayer options) {

            if (FLWindow2D != null) RemoveFLControll();
            //switch (options.ViewMode) {

            //    case "2D":
            //        break;

            //    case "3D":
            //        break;
            //}
            ComponentResourceManager resources = new ComponentResourceManager(typeof(WPlayerForm));
            FLWindow2D = new AxShockwaveFlash();
            ((ISupportInitialize)(this.FLWindow2D)).BeginInit();
            FLWindow2D.Location = new Point();
            FLWindow2D.Name = "axFlash";
            FLWindow2D.TabIndex = 0;

            // Get controll which is embeded in to resources WPlayer.resx
            //ComponentResourceManager resources = new ComponentResourceManager(typeof(WPlayerForm));
            //FLWindow2D.OcxState = ((AxHost.State)(resources.GetObject("FLWindow2D.OcxState")));

            // loading flash.dll from Project Resources
            //byte[] inputBytes = Resources.Flash;
            //Stream stream = new MemoryStream(inputBytes);
            //FLWindow2D.OcxState = new AxHost.State(stream, 1, false, null);

            FLWindow2D.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(this.OnFlashWalkerCall);
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

        private void RemoveFLControll() {

            WPGlobal.Log("CSharp", "WPlayerForm > RemoveFLControll >\n\tfpath:{0}", FLWindow2D);
            this.Controls.Remove(FLWindow2D);
            FLWindow2D.Dispose();
        }

        internal void ShowPanel(bool state) {
            if (state) this.Show(); else this.Hide();
        }

        private void OnFlashWalkerCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
            FlashBridge.OnFlashWalkerCall((AxShockwaveFlash)sender, e);
        }

        private void OnFlashProjectorCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
            FlashBridge.OnFlashProjectorCall((AxShockwaveFlash)sender, e);
        }
        
        // Disable the context menu on a flash control added to form (by JayJayson)
        private void OnFormLoad(object sender, System.EventArgs e) {
            // Assign the handle of your flash control to the ControlWatcher class.  
            new ControlWatcher(FLWindow2D.Handle);
        }

        private void OnFormResize(object sender, System.EventArgs e) {

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
    }
}
