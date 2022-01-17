using System.Drawing;
using System.Windows.Forms;

namespace Walker {

    public partial class WPlayerForm : Form {

        private AxShockwaveFlashObjects.AxShockwaveFlash FLComponent;
        private Size DefaultPlayerSize = new Size(1024, 768);
        private Point Margins = new Point(2, 2);
        public WPlayerForm() {
            InitializeComponent();
        }

        internal void LoadFile(string fpath, bool play) {

            RemoveSWFComponent();
            AddSWFComponent();
            FLComponent.LoadMovie(0, fpath);
            if(play) FLComponent.Play();
        }

        private void RemoveSWFComponent() {

            // One component each time (unload before load)
            // TODO check if all flash events was unloaded / stoped too !!! (events, sounds, tweens, etc...)
            if (FLComponent != null) this.Controls.Remove(FLComponent);
        }

        private void AddSWFComponent() {

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WPlayerForm));
            FLComponent = new AxShockwaveFlashObjects.AxShockwaveFlash();
            FLComponent.BeginInit();
            FLComponent.Dock = System.Windows.Forms.DockStyle.Fill;
            FLComponent.Enabled = true;
            FLComponent.Location = new Point(Margins.X, Margins.Y);
            FLComponent.Name = "FLComponent";
            FLComponent.TabIndex = 1;
            FLComponent.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FLComponent.OcxState")));
            FLComponent.Size = new Size(DefaultPlayerSize.Width + Margins.X * 2, DefaultPlayerSize.Height + Margins.Y * 2);
            FLComponent.EndInit();
            this.Controls.Add(FLComponent);
        }
    }
}
