using System;
using System.IO;
using System.Windows.Forms;
using WalkerPlayer;

namespace WalkerPlayerTester {
    public partial class WPlayerTesterForm : Form {
        public WPlayerTesterForm() {
            InitializeComponent();
            CbxDirectories.SelectedIndex = 0;
            FillFilesList();
        }

        private void CreateFPInstance() {
            WPlayerForm flForm = new WPlayerForm();
            flForm.Show();
            flForm.LoadFile(LbxPaths.SelectedItem.ToString());
        }

        private void BtnLoadSwfFile_Click(object sender, EventArgs e) => CreateFPInstance();

        private void FillFilesList() {

            LbxPaths.Items.Clear();
            if (!Directory.Exists(CbxDirectories.Text)) return;
            var files = Directory.GetFiles(CbxDirectories.Text, "*.swf", SearchOption.TopDirectoryOnly);
            LbxPaths.Items.AddRange(files);
            if (LbxPaths.Items.Count > 0) LbxPaths.SelectedIndex = 0;
        }

        private void OnDirSelectionChanged(object sender, EventArgs e) => FillFilesList();

        private void OnDirTextChanged(object sender, EventArgs e) => FillFilesList();
    }
}
