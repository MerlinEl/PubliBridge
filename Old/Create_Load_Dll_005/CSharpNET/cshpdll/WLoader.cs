using System;
using System.IO;
using System.Windows.Forms;

namespace cshpdll {
    public partial class WLoader : Form {
        public WLoader() {
            InitializeComponent();
            InitializeParematers();
        }

        private void InitializeParematers() {
            CbxFpath.SelectedIndex = 0;
            CbxFiles.SelectedIndex = 0;
        }

        private void BtnLoad_Click(object sender, EventArgs e) => LoadFileFromEditBox();

        private void BtnPlay_Click(object sender, EventArgs e) => FLComponent.Playing = true;

        private void BtnStop_Click(object sender, EventArgs e) => FLComponent.Playing = false;

        public void LoadFileFromEditBox() => LoadFile(CbxFpath.Text + CbxFiles.Text);

        public void LoadFile(string fpath) {

            if (!File.Exists(fpath)) throw new FileNotFoundException("This file was not found.\n" + fpath);
            //MessageBox.Show("LoadFile.\n" + fpath, "CSharp MessageBox:");
            //FLComponent.Dispose();
            //FLComponent.LoadMovie(0, fpath);
            //FLComponent.Loop = false;
            //FLComponent.Controls.Clear();
            //Console.WriteLine("UnloadSWF > haschildren:{0}", );
             if (FLComponent.Movie != null) UnloadSWF();
            FLComponent.Movie = fpath;
            FLComponent.Playing = false;
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
    }
}
//String path = Application.StartupPath +@"\"+ Tbx_Swf_Path.Text;
//string swfPath = System.Environment.CurrentDirectory;
/*
 * // Loading a Flash movie from a memory stream or a byte array
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YourForm));
System.Byte[] data = (System.Byte[])(resources.GetObject("FileName"));
*/
/*
public partial class Form1 : Form
{
    private AxShockwaveFlashObjects.AxShockwaveFlash axFlash;

    public Form1()
    {
        InitializeComponent();

        axFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();  
        axFlash.BeginInit();  
        axFlash.Location = new Point(50, 50);  
        axFlash.Name = "Load/unload test";  
        axFlash.TabIndex = 0; 
        axFlash.EndInit(); 
    }

    private void startButton_Click(object sender, EventArgs e)
    {
        axFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
        axFlash.BeginInit();
        axFlash.Location = new Point(50, 80);
        axFlash.Name = "Test Movie";
        axFlash.TabIndex = 0;

        axFlash.Size = new Size(640, 480);
        axFlash.EndInit();
        this.Controls.Add(axFlash);
        axFlash.LoadMovie(0, @"C:\Movies\MyMovie.swf");
    }

    private void unloadButton_Click(object sender, EventArgs e)
    {
        this.Controls.Remove(axFlash);
    }
}
 */