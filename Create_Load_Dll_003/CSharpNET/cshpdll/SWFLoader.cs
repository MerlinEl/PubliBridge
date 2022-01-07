using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cshpdll {
    public partial class SWFLoader : Form {
        public SWFLoader() {
            InitializeComponent();
        }

        private void BtnLoadSWF_Click(object sender, EventArgs e) {
            //String path = Application.StartupPath +@"\"+ Tbx_Swf_Path.Text;
            String path = TbxSwfPath.Text;
            if (!File.Exists(path)) throw new FileNotFoundException("This file was not found.\n" + path);
            axShockwaveFlash1.Movie = path;
            axShockwaveFlash1.Playing = false;
        }

        private void BtnPlaySWF_Click(object sender, EventArgs e) {
            axShockwaveFlash1.Playing = true;
        }

        private void BtnPauseSWF_Click(object sender, EventArgs e) {
            axShockwaveFlash1.Playing = false;
        }
    }
}
