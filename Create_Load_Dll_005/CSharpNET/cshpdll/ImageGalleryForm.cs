using System;
using System.Windows.Forms;

namespace cshpdll
{
    public partial class ImageGalleryForm : Form {
        public ImageGalleryForm() {
            InitializeComponent();
        }

        private void CbxImageList_SelectedIndexChanged(object sender, EventArgs e) {
            switch (CbxImageList.SelectedIndex) {

                case 0:PicBox.Image = Properties.Resources.icons_01; break;
                case 1:PicBox.Image = Properties.Resources.icons_02; break;
                case 2:PicBox.Image = Properties.Resources.icons_03; break;
            }
        }
    }
}
