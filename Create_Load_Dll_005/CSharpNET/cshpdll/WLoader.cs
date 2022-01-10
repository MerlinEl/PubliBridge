using System;
using System.IO;
using System.Windows.Forms;

namespace cshpdll {
    public partial class WLoader : Form {
        public WLoader() => InitializeComponent();

        private void BtnLoad_Click(object sender, EventArgs e) => LoadFileFromEditBox();

        private void BtnPlay_Click(object sender, EventArgs e) => FLComponent.Playing = true;

        private void BtnStop_Click(object sender, EventArgs e) => FLComponent.Playing = false;

        public void SetPath(string fpath) => TbxFpath.Text = fpath;

        public void LoadFileFromEditBox() => LoadFile(TbxFpath.Text);

        public void LoadFile(string fpath) {

            if (!File.Exists(fpath)) throw new FileNotFoundException("This file was not found.\n" + fpath);
            //MessageBox.Show("LoadFile.\n" + fpath, "CSharp MessageBox:");
            FLComponent.Movie = fpath;
            FLComponent.Playing = false;
        }
    }
}
 //String path = Application.StartupPath +@"\"+ Tbx_Swf_Path.Text;