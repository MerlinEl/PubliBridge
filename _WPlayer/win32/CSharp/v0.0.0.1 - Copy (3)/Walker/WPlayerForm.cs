using System;
using System.IO;
using System.Windows.Forms;

namespace Walker {
    public partial class WPlayerForm : Form {
        public WPlayerForm() {
            InitializeComponent();
        }

        internal void LoadFile(string fpath, bool play) {
            Console.WriteLine("LoadFile > Start!");
            if (!File.Exists(fpath)) throw new FileNotFoundException("This file was not found.\n" + fpath);
            //FLComponent.Movie = fpath;
            //RemoveSWFComponent();
            //AddSWFComponent();
            //FLComponent.LoadMovie(0, fpath);
            //if (play) FLComponent.Play();
        }

        internal void RemoveSWFComponent() {
            throw new NotImplementedException();
        }
    }
}
