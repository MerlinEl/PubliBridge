using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace WalkerPlayer {

    public partial class Form1 : Form {

        private AxShockwaveFlash axShockwaveFlash1 = new AxShockwaveFlash();

        public Form1() {
            InitializeComponent();
            InitAxShockwaveFlash();
        }
        #region イベント
        private void Form1_Load(object sender, EventArgs e) {
            try {
                //swfファイルならなんでもいい
                axShockwaveFlash1.LoadMovie(0, Application.StartupPath + "\\test.swf");
                axShockwaveFlash1.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(axShockwaveFlash1_FlashCall);
            }
            catch {
                MessageBox.Show("Flashがインストールされていないようですが・・(^ω^;)");
            }
        }

        private void axShockwaveFlash1_FlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
            
            var document = new XmlDocument();
            document.LoadXml(e.request);

            XmlNodeList list = document.GetElementsByTagName("arguments");
            //ResizePlayer(Convert.ToInt32(list[0].FirstChild.InnerText), Convert.ToInt32(list[0].ChildNodes[1].InnerText));

            var width = int.Parse(list[0].ChildNodes[0].InnerText);
            var height = int.Parse(list[0].ChildNodes[1].InnerText);

            this.ClientSize = new System.Drawing.Size(width, height);
            axShockwaveFlash1.ClientSize = this.axShockwaveFlash1.Size;
        }

        /// <summary>
        /// DragDrop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            LoadFLV(files[0]);
        }

        /// <summary>
        /// DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false)) {
                e.Effect = DragDropEffects.All;
            }
        }
        #endregion

        #region メソッド
        /// <summary>
        /// AxShockwaveFlashの設定
        /// </summary>
        private void InitAxShockwaveFlash() {
            this.axShockwaveFlash1.AllowFullScreen = "false";
            this.axShockwaveFlash1.BGColor = "000000";
            this.axShockwaveFlash1.AllowNetworking = "all";

            this.axShockwaveFlash1.CtlScale = "NoScale";
            //this.axShockwaveFlash1.CtlScale = "NoBorder ";
            //this.axShockwaveFlash1.CtlScale = "ExactFit";
            //this.axShockwaveFlash1.CtlScale = "ShowAll";

            this.axShockwaveFlash1.DeviceFont = false;
            this.axShockwaveFlash1.EmbedMovie = true;

            this.axShockwaveFlash1.FrameNum = -1;
            this.axShockwaveFlash1.Loop = true;
            this.axShockwaveFlash1.Playing = true;
            this.axShockwaveFlash1.Profile = true;
            this.axShockwaveFlash1.Quality2 = "High";
            this.axShockwaveFlash1.SAlign = "LT";
            this.axShockwaveFlash1.WMode = "Window";
            this.axShockwaveFlash1.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// FLVファイルのロード
        /// </summary>
        /// <param name="videoPath"></param>
        private void LoadFLV(string videoPath) {
            axShockwaveFlash1.CallFunction("<invoke name=\"loadAndPlayVideo\" returntype=\"xml\"><arguments><string>" + videoPath + "</string></arguments></invoke>");
        }
        #endregion
    }
}
