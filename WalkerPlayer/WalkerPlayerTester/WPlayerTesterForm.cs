using System;
using System.Windows.Forms;
using WalkerPlayer;

namespace WalkerPlayerTester {
    public partial class WPlayerTesterForm : Form {
        public WPlayerTesterForm() {
            InitializeComponent();
            LbxPaths.SelectedIndex = 0;
        }

        private void CreateFPInstance() {
            WPlayerForm flForm = new WPlayerForm();
            flForm.Show();
            flForm.LoadSWFFile(LbxPaths.SelectedItem.ToString());
        }

        private void BtnLoadSwfFile_Click(object sender, EventArgs e) {
            CreateFPInstance();
        }
    }
}
