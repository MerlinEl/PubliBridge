using System;
using System.IO;
using System.Windows.Forms;

namespace WalkerPlayer64 {
    public partial class Form1 : Form {
        public Form1() {
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
    }
}
