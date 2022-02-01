using WalkerPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WPTest {
    public partial class WPTestForm : Form {
        public WPTestForm() {
            //if (IsDisposed) return;
            InitializeComponent();
        }

        private void OnFormLoaded(object sender, EventArgs e) {
            FillPaths();
            FillFiles();
        }

        private void FillPaths() {
            
            CbxBookDir.SelectedIndex = 0;
            CbxSWFDir.SelectedIndex = 0;
        }

        private void FillFiles() {
           
            LbxFiles.Items.Clear();
            string swfDir = CbxBookDir.Text + (CbxSWFDir.Text == "root" ? "" : "\\" + CbxSWFDir.Text);
            if (!Directory.Exists(swfDir)) return;
            // get files
            var ext = new List<string> { "jpg", "png", "swf", "flv", "mp3" };
            var files = Directory
                .EnumerateFiles(swfDir, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()));
            // fill list
            foreach (string f in files) {
                LbxFiles.Items.Add(Path.GetFileName(f));
            }
            if (files.ToArray().Length > 0) {
                LbxFiles.SelectedIndex = 0;
                int index = -1;
                for (int i = 0; i < LbxFiles.Items.Count; i++) {

                    if (LbxFiles.Items[i].ToString() == "Walker.swf") index = i;
                }
                if (index > -1) LbxFiles.SelectedIndex = index;
            }
        }

        private void OnSwfDirChanged(object sender, EventArgs e) {
            FillFiles();
        }
        private void BtnLoadSWF_Click(object sender, EventArgs e) {
        }

        private void BtnLoadSwf3D_Click(object sender, EventArgs e) {

        }
        private void BtnLoadLesson_Click(object sender, EventArgs e) {

            string fpath = CbxBookDir.Text + (CbxSWFDir.Text == "root" ? "" : "\\" + CbxSWFDir.Text) + "\\" + LbxFiles.Text;
            Console.WriteLine("Loading SWF:{0}", fpath);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.MediaType = "LESSONS";
            options.WindowSize = "FULLSCREEN";
            options.RootDir = CbxBookDir.Text;
            options.FilePath = fpath;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = false;
            wl.LoadFile(options);
        }

        private void BtnLoadAudio_Click(object sender, EventArgs e) {
            string fpath = CbxBookDir.Text + (CbxSWFDir.Text == "root" ? "" : "\\" + CbxSWFDir.Text) + "\\" + LbxFiles.Text;
            Console.WriteLine("Loading SWF:{0}", fpath);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.MediaType = "AUDIO";
            options.WindowSize = "240,140";
            options.RootDir = CbxBookDir.Text;
            options.FilePath = fpath;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = ChkResizable.Checked;
            wl.LoadFile(options);
        }
    }
}
