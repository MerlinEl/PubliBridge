using WalkerPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WalkerPlayer.Properties;

namespace WalkerPlayer {
    public partial class WPlayerForm : Form {
        
        public static AxShockwaveFlash axFlash;

        //AxShockwaveFlash axShockwaveFlash1 = new AxShockwaveFlash();
        //ComponentResourceManager resources = new ComponentResourceManager(typeof(WPlayerForm));

        public WPlayerForm() {
            InitializeComponent();
            InitializeFlash();

            //this.Load += new EventHandler(cartao_worten_Load);
            //Cursor.Hide();
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

        public void CreateFlashComponentAndLoadMedia(string fpath) {
    
            this.Controls.Remove(axFlash);
            axFlash.Dispose();
            
            if (!File.Exists(fpath)) return;
            
            ComponentResourceManager resources = new ComponentResourceManager(typeof(WPlayerForm));
            axFlash = new AxShockwaveFlash();
            ((ISupportInitialize)(axFlash)).BeginInit();
            axFlash.SuspendLayout();
            axFlash.Location = new Point();
            axFlash.Name = "axFlash";
            axFlash.TabIndex = 0;

            //axFlash.OcxState = ((AxHost.State)(resources.GetObject("axFlash.OcxState")));


            

            byte[] inputBytes = Resources.Flash32_14_0_0_176;
            Stream stream = new MemoryStream(inputBytes);


            //Type oComType = Type.GetTypeFromProgID("axFlash.OcxState");
            //dynamic oComInst = Activator.CreateInstance(oComType);

            axFlash.OcxState = new AxHost.State(inputBytes, 1, false, null);

            //axFlash.OcxState = ((AxHost.State)(o));

            axFlash.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(this.OnFlashWalkerCall);
            axFlash.Size = ClientSize;
            axFlash.EndInit();
            this.Controls.Add(axFlash);

            //axFlash.DeviceFont = false;
            //axFlash.FrameNum = -1;
            //axFlash.Loop = true;
            //axFlash.Playing = true;
            //axFlash.Profile = true;
            //axFlash.SAlign = "LT";
            axFlash.WMode = "Direct"; // Direct or Window
            axFlash.AllowScriptAccess = "Always";
            axFlash.AllowNetworking = "all";
            //axFlash.EmbedMovie = false;
            axFlash.Quality2 = "High";
            axFlash.BGColor = "0xec9900";
            axFlash.LoadMovie(0, fpath);
        }

        //void cartao_worten_Load(object sender, EventArgs e) {
        //    axShockwaveFlash1.MouseCaptureChanged += new EventHandler(axShockwaveFlash1_MouseCaptureChanged);
        //    axShockwaveFlash1.Dock = DockStyle.Fill;
        //    axShockwaveFlash1.OcxState = ((AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
        //    this.Controls.Add(axFlash);
        //    axShockwaveFlash1.Show();
        //    axShockwaveFlash1.Movie = Application.StartupPath + "\\CartaoCredito.swf";
        //    axShockwaveFlash1.Play();
        //}


        private void OnFlashWalkerCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
            throw new NotImplementedException();
        }

        internal void SetFullScreen(bool state) {
            throw new NotImplementedException();
        }

        public void LoadFile(OWPlayer options) {

            Show();
            CreateFlashComponentAndLoadMedia(options.FilePath);
        }

        public void LoadFile(string fpath) {

            CreateFlashComponentAndLoadMedia(fpath);
            Show();
        }

        internal void ShowPanel(bool state) {
            Show();
        }
    }
}

/*
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            this.SuspendLayout();
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(23, 25);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(192, 192);
            this.axShockwaveFlash1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axShockwaveFlash1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            this.ResumeLayout(false);
 */

/*
// Check to see if we need to use Invoke before wasting time with it
if (axFlash.InvokeRequired)
{
    // invoke Dispose on the control's native thread to avoid the COM exception
    axFlash.Invoke(() => axFlash.Dispose());
}
else
{
    // run dispose on this thread
    axFlash.Dispose();
}

//OR

public void Dispose()  
{  
    activexControl.Dispose();  
    Marshal.ReleaseComObject(activexControl);
}

//OR

private void RunStuff() 
{ 
    using (DoStuff stuff = new DoStuff())
    {
        stuff.PerformStuff(); 
    }
} 
 */