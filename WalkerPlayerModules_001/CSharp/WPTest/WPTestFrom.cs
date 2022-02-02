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

            TbxUserName.Text = Environment.UserName;
            FillPaths();
            FillFiles();
        }

        private void FillPaths() {

            CbxBookDir.SelectedIndex = 0;
            CbxMediaDir.SelectedIndex = 0;
        }

        private string GetBookDir() {
            return "C:\\Users\\" + TbxUserName.Text + "\\" + CbxBookDir.Text;
        }

        private void FillFiles() {

            LbxFiles.Items.Clear();
            string mediaDir = GetBookDir() + "\\" + CbxMediaDir.Text;
            Console.WriteLine("Media Dir:{0}", mediaDir);
            if (!Directory.Exists(mediaDir)) return;
            // get files
            var ext = new List<string> { "jpg", "png", "swf", "flv", "mp3" };
            var files = Directory
                .EnumerateFiles(mediaDir, "*.*", SearchOption.TopDirectoryOnly)
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

        internal static string GetIdFromFileName(string fname) {

            int firstUnderscore = fname.IndexOf("_");
            int secondUnderscore = fname.IndexOf("_", firstUnderscore + 1);
            return fname.Substring(0, secondUnderscore);
        }

        private void OnBookDirChanged(object sender, EventArgs e) => FillFiles();

        private void OnMediaDirChanged(object sender, EventArgs e) => FillFiles();
        private void BtnLoadLesson_Click(object sender, EventArgs e) {

            string buttonId = Path.GetFileNameWithoutExtension(LbxFiles.Text);
            Console.WriteLine("Loading Button ID:{0}", buttonId);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.MediaType = "LESSONS";
            options.WindowSize = "PLAYERSIZE";
            options.BookDir = GetBookDir();
            options.ButtonID = buttonId;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = false;
            wl.LoadFile(options);
        }

        private void BtnLoadAudio_Click(object sender, EventArgs e) {
            string buttonId = Path.GetFileNameWithoutExtension(LbxFiles.Text);
            Console.WriteLine("Loading Button ID:{0}", buttonId);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.MediaType = "AUDIO";
            options.WindowSize = "240,140";
            options.BookDir = GetBookDir();
            // Button ID ( 04_01 ) < 04_01.swf
            // 04 > page     > number of current page
            // 01 > count    > sequence index
            options.ButtonID = buttonId;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = ChkResizable.Checked;
            wl.LoadFile(options);
        }
        private void BtnLoadImages_Click(object sender, EventArgs e) {
            
            string fname = Path.GetFileNameWithoutExtension(LbxFiles.Text);
            string buttonId = GetIdFromFileName(fname);
            Console.WriteLine("Loading Button ID:{0}", buttonId);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.MediaType = "IMAGES";
            options.WindowSize = "PLAYERSIZE";
            options.BookDir = GetBookDir();
            options.ButtonID = buttonId;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = false;
            wl.LoadFile(options);
        }
    }
}
