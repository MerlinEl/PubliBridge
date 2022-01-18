using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace cshpdll {
    public partial class WPlayerForm : Form {

        private Size swfStartSize = new Size(1024, 768);
        private OWPlayer _options;
        private bool _isLoaded;
        public WPlayerForm() => InitializeComponent();

        public void LoadFile(OWPlayer options) {

            _options = options;
            if (!File.Exists(options.FilePath)) throw new FileNotFoundException("This file was not found.\n" + options.FilePath);
            MessageBox.Show(
                "LoadFile >\n\tFullScreen:"+ options.FullScreen +
                "\n\tFitToScreen:" + options.FitToScreen + 
                "\n\tHidden:"+ options.Hidden + 
                "\n\tFilePath:" + options.FilePath, "CSharp MessageBox:"
            );
            //if (FLComponent.Movie != null) UnloadSWF();
            FLComponent.Movie = options.FilePath;
            FLComponent.Playing = options.AutoPlay;
            if (options.FitToScreen) FitPlayerToMediaSize(options.FilePath);
            FullScreenMode = options.FullScreen;
            // FLComponent.AllowFullScreen = fullScreen ? "true" : "false";
            if (!options.Hidden) Show();
            _isLoaded = true;
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

        public void RemoveAll() {


            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WPlayerForm));
            //this.FLComponent = new AxShockwaveFlashObjects.AxShockwaveFlash();
            //((System.ComponentModel.ISupportInitialize)(this.FLComponent)).BeginInit();
            //this.SuspendLayout();
            //// 
            //// FLComponent
            //// 
            //this.FLComponent.Enabled = true;
            //this.FLComponent.Location = new System.Drawing.Point(12, 12);
            //this.FLComponent.Name = "FLComponent";
            //this.FLComponent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FLComponent.OcxState")));
            //this.FLComponent.Size = new System.Drawing.Size(543, 401);
            //this.FLComponent.TabIndex = 2;
            //// 
            //// WPlayerForm
            //// 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.ClientSize = new System.Drawing.Size(1008, 729);
            //this.Controls.Add(this.FLComponent);
            //this.Name = "WPlayerForm";
            //this.Text = "WLoader";
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnFormKeyDown);
            //this.Resize += new System.EventHandler(this.OnFormResize);
            //((System.ComponentModel.ISupportInitialize)(this.FLComponent)).EndInit();
            //this.ResumeLayout(false);
        }

        private void UnloadSWF() {
            //FLComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            //FLComponent.Enabled = true;
            //FLComponent.Location = new System.Drawing.Point(0, 0);
            //FLComponent.Name = "flashMovie";
            //FLComponent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flashMovie.OcxState")));
            //FLComponent.Size = new System.Drawing.Size(571, 367);
            //FLComponent.TabIndex = 0;
            //var loader:Loader = new Loader();
            //loader.unloadAndStop(); //unload all content, do some garbage cleanup
            //mov_contentLoader.removeChildAt(0); //just to be safe, a second layer of reassurance ??
            //loader.contentLoaderInfo.addEventListener(Event.UNLOAD, cleanUp);

            //function cleanUp(e:Event):void{
            //    SoundMixer.stopAll(); //stop all sounds...
            //}
            Console.WriteLine("UnloadSWF > fpath:{0} components:{1}", FLComponent.Movie, FLComponent.EmbedMovie);
        }

        internal void Display(bool state) {
            if (state) this.Show(); else this.Hide();
        }

        /// <summary>
        /// Replace "(X) Close" button function with "Hide"
        /// </summary>
        private bool _allowClose = false;
        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            if (!_allowClose && e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                Hide();
            }
        }
        // To enable Form Keyboard Events set KeyPreview = true;
        private void OnFormKeyDown(object sender, KeyEventArgs e) {
            if (e.Alt && e.KeyCode == Keys.F4) {
                
                _allowClose = true;
            }
            else if (e.KeyCode == Keys.Escape) {
                FullScreenMode = false;
                // prevent child controls from handling this event as well
                e.SuppressKeyPress = true;
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

        private bool fullScreen;
        public bool FullScreenMode {
            get { return this.fullScreen; }
            set {
                if (value) {
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Bounds = Screen.PrimaryScreen.Bounds;
                } else {
                    this.WindowState = FormWindowState.Normal;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    //if (_isLoaded) FitPlayerToMediaSize(_options.FilePath);
                    this.ClientSize = new Size(swfStartSize.Width, swfStartSize.Height);
                    CenterToScreen();
                }
                this.fullScreen = value;
            }
        }
    }
}

//Screen.PrimaryScreen.Bounds.Width
//Screen.PrimaryScreen.Bounds.Height