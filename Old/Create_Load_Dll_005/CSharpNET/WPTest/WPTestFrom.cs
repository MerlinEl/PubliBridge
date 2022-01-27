using cshpdll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPTest {
    public partial class WPTestForm : Form {
        public WPTestForm() {
            InitializeComponent();
        }

        private void BtnLoadSWF_Click(object sender, EventArgs e) {
            string fpath = CbxFpath.Text + LbxFiles.Text;
            Console.WriteLine("Loading SWF:{0}", fpath);
            WPlayer wl = new WPlayer();
            wl.IShowSWFPanelWithPath(fpath);
        }

        private void OnFormLoaded(object sender, EventArgs e) {
            CbxFpath.SelectedIndex = 0;
            LbxFiles.SelectedIndex = 0;
        }
    }
}
