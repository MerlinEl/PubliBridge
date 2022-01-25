using AxShockwaveFlashObjects;
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

namespace WalkerPlayer {
    public partial class WPlayerForm : Form {
        
        private AxShockwaveFlash axFlash;
        public WPlayerForm() {
            InitializeComponent();
            InitializeFlash();
        }

        private void InitializeFlash() {

            axFlash = new AxShockwaveFlash();
            axFlash.BeginInit();
            axFlash.Location = new Point();
            axFlash.Name = "FLWindow3D";
            axFlash.TabIndex = 0;
            axFlash.EndInit();
            this.Controls.Add(axFlash);
        }

        public void CreateFlashComponentAndLoadMedia(string fpath) {
    
            this.Controls.Remove(axFlash);
            axFlash.Dispose();
            
            if (!File.Exists(fpath)) return;

            axFlash = new AxShockwaveFlash();
            axFlash.BeginInit();
            axFlash.Location = new Point();
            axFlash.Name = "FLWindow3D";
            axFlash.TabIndex = 0;
      
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WPlayerForm));
            //this.FLWindow3D.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FLWindow3D.OcxState")));
            axFlash.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(this.OnFlashWalkerCall);
            axFlash.Size = ClientSize;
            axFlash.EndInit();
            this.Controls.Add(axFlash);
            axFlash.WMode = "Direct"; // Direct or Window
            axFlash.AllowScriptAccess = "Always";
            axFlash.Quality2 = "High";
            axFlash.BGColor = "0xec9900";
            axFlash.LoadMovie(0, fpath);
        }

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
