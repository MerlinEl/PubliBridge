using WalkerPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WPTest {

    public partial class WPTestForm : Form {

        // Static form. Null if no form created yet.
        internal static WPTestForm form = null;

        public WPTestForm() => InitializeComponent();
        private void OnFormLoaded(object sender, EventArgs e) => Init();
        private void OnBookDirChanged(object sender, EventArgs e) => WPTest.FillMediaListByType();
        private void OnMediaDirChanged(object sender, EventArgs e) => WPTest.FillMediaListByType();
        private void BtnLoadLesson_Click(object sender, EventArgs e) => WPTest.PlayLesson(CbxLessonList.Text);
        private void BtnPlay3D_Click(object sender, EventArgs e) => WPTest.Play3D(Cbx3DList.Text);
        private void BtnPlayVideo_Click(object sender, EventArgs e) => WPTest.PlayVideo(CbxVideoList.Text);
        private void BtnLoadAudio_Click(object sender, EventArgs e) => WPTest.PlayAudio(CbxAudioList.Text);
        private void BtnLoadImages_Click(object sender, EventArgs e) => WPTest.PlayImages(CbxImageList.Text);
        private void Init() {

            form = this;
            TbxUserName.Text = Environment.UserName;
            CbxBookDir.SelectedIndex = 0;
            CbxWindowSize.SelectedIndex = 0;
            Log("User Name:{0}", TbxUserName.Text);
        }
        internal void Log(string a, string b) => TbxConsole.AppendText(Environment.NewLine + String.Format(a, b));
        internal void Log(string msg, params object[] args) => TbxConsole.AppendText(Environment.NewLine + String.Format(msg, args));
        internal void LogClear() => TbxConsole.Clear();
        internal string IBookDir => CbxBookDir.Text;
        internal string IWindowSize => CbxWindowSize.Text;
        internal Boolean IResizable => ChkResizable.Checked;
        internal string IUserName => TbxUserName.Text;
        internal ComboBox ILessonList => CbxLessonList;
        internal ComboBox I3DList => Cbx3DList;
        internal ComboBox IVideoList => CbxVideoList;
        internal ComboBox IAudioList => CbxAudioList;
        internal ComboBox IImageList => CbxImageList;
    }
}
