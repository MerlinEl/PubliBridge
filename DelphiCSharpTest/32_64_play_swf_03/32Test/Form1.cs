using System;
using System.Windows.Forms;
using WalkerPlayer;

namespace _32Test {
    public partial class Form1 : Form {

        private IWPlayer wPlayer;

        public Form1() {
            InitializeComponent();
            WPlayer.GetInstance(ref wPlayer);
        }

        private void BtnSayHello_Click(object sender, EventArgs e) {
            wPlayer?.SayHello(TbxUserName.Text);
        }

        private void BtnOpenPanel_Click(object sender, EventArgs e) {
            wPlayer?.ShowPanel(true);
        }
    }
}
