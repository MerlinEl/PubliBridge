using System;
using System.Windows.Forms;
using Walker;

namespace WPTest {
    public partial class WPTestForm : Form {
        public WPTestForm() {
            InitializeComponent();
        }

        private void BtnLoadSWF_Click(object sender, EventArgs e) {
            string fpath = CbxFpath.Text + LbxFiles.Text;
            Console.WriteLine("Loading SWF:{0}", fpath);
            WPlayer wl = new WPlayer();
            wl.ShowPlayer();
            wl.LoadFile(fpath, ChkAutoPlay.Checked);
        }

        private void OnFormLoaded(object sender, EventArgs e) {
            CbxFpath.SelectedIndex = 0;
            LbxFiles.SelectedIndex = 0;
        }
    }
}
