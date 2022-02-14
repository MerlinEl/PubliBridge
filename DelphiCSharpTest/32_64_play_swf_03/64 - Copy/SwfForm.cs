using System;
using System.IO;
using System.Windows.Forms;

namespace WalkerPlayer {
    public partial class SwfForm : Form {
        public SwfForm() {
            InitializeComponent();
        }

        private void BtnLoadSwf_Click(object sender, EventArgs e) {
            string appDir = Path.GetDirectoryName(Application.ExecutablePath);
            string fPath = Path.Combine(appDir, TbxSwfPath.Text);
            axShockwaveFlash1.LoadMovie(0, fPath);
        }

        internal void ShowPanel(bool state) {
            if (state) Show(); else Hide();
        }

        internal void Log(string tabName, string msg) {
            TbxSwfPath.AppendText(Environment.NewLine + tabName + " > " + msg);
        }
    }
}
