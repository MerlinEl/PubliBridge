using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WalkerPlayer;

namespace WPTest {
    class WPTest {

        internal static WPTestForm WPF => WPTestForm.form;

        internal static void PlayLesson(string fname) {
            // Button ID ( 04 ) < 04.swf
            string buttonId = Path.GetFileNameWithoutExtension(fname);
            Console.WriteLine("Loading Button ID:{0}", buttonId);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.Name = "Lesson Player:";
            options.MediaType = "LESSONS";
            options.WindowSize = WPF.IWindowSize;
            options.BookDir = GetBookDir();
            options.FileName = fname; // 004.swf
            options.ButtonID = buttonId;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = WPF.IResizable;
            WPF.LogClear();
            WPF.Log("Options:{0}", options);
            wl.LoadFile(options);
        }
        internal static void Play3D(string fname) {
            // Button ID ( 158 ) < 158.swf
            string buttonId = Path.GetFileNameWithoutExtension(fname);
            Console.WriteLine("Loading Button ID:{0}", buttonId);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.Name = "3D Player:";
            options.MediaType = "STAGE3D";
            options.WindowSize = WPF.IWindowSize;
            options.BookDir = GetBookDir();
            options.FileName = fname; // 158.swf
            options.ButtonID = buttonId;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = WPF.IResizable;
            WPF.LogClear();
            WPF.Log("Options{0}", options.ToString());
            wl.LoadFile(options);
        }
        internal static void PlayVideo(string fname) {
            // Button ID ( 158 or WEBLINK or 'WEBSTREAM' ) < 158.swf or https://www...
            string buttonId = GetVideoID(fname);
            Console.WriteLine("Loading Button ID:{0}", buttonId);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.Name = "Video Player:";
            options.MediaType = "VIDEO";
            options.WindowSize = WPF.IWindowSize;
            options.BookDir = GetBookDir();
            options.FileName = fname; // 158.swf or https://www...
            options.ButtonID = buttonId;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = WPF.IResizable;
            WPF.LogClear();
            WPF.Log("Options{0}", options.ToString());
            wl.LoadFile(options);
        }
        internal static void PlayAudio(string fname) {
            // Button ID ( 04_01 ) < 04_01.swf
            // 04 > page     > number of current page
            // 01 > count    > sequence index
            string buttonId = Path.GetFileNameWithoutExtension(fname);
            Console.WriteLine("Loading Button ID:{0}", buttonId);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.Name = "Video Player:";
            options.MediaType = "AUDIO";
            options.WindowSize = "240,140";
            options.WindowPos = "CENTER";
            options.BookDir = GetBookDir();
            options.FileName = fname; // 04_01.swf
            options.ButtonID = buttonId;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = WPF.IResizable;
            WPF.LogClear();
            WPF.Log("Options{0}", options.ToString());
            wl.LoadFile(options);
        }

        internal static void PlayImages(string fname) {
            // IMAGE_ID ( 24_01_01 ) < 20_01_01_mečoun obecný.jpg
            // 24 > page     > number of current page
            // 01 > set      > images group
            // 01 > count    > sequence index
            string buttonId = Path.GetFileNameWithoutExtension(fname);
            buttonId = GetImageId(buttonId);
            Console.WriteLine("Loading Button ID:{0}", buttonId);
            WPlayer wl = new WPlayer();
            var options = new OWPlayer().GetDefault();
            options.Name = "Video Player:";
            options.MediaType = "IMAGES";
            options.WindowSize = WPF.IWindowSize;
            options.BookDir = GetBookDir();
            options.FileName = fname; // 20_01_01_mečoun obecný.jpg
            options.ButtonID = buttonId;
            options.AutoPlay = true;
            options.HiddenPlayer = false;
            options.Resizable = WPF.IResizable;
            WPF.LogClear();
            WPF.Log("Options{0}", options.ToString());
            wl.LoadFile(options);
        }

        internal static void FillMediaListByType() {

            FillMediaList(WPF.ILessonList, GetFilesDirByType("lessons"), "swf");
            FillMediaList(WPF.I3DList, GetFilesDirByType("3d"), "swf");
            FillMediaList(WPF.IVideoList, GetFilesDirByType("video"), "flv");
            FillMediaList(WPF.IAudioList, GetFilesDirByType("audio"), "mp3");
            FillMediaList(WPF.IImageList, GetFilesDirByType("photos"), "jpg");
        }

        private static void FillMediaList(ComboBox cbx, string dir, string extension) {

            //cbx.Items.Clear();
            if (!Directory.Exists(dir)) {

                WPF.Log("WPTest > FillSWFList > Directory not found at:{0}", dir);

            } else {

                // get files
                //var ext = new List<string> { "jpg", "png", "swf", "flv", "mp3" };
                var ext = new List<string> { extension };
                var files = Directory
                    .EnumerateFiles(dir, "*.*", SearchOption.TopDirectoryOnly)
                    .Where(s => ext.Contains(Path.GetExtension(s).TrimStart('.').ToLowerInvariant()));
                // fill list
                foreach (string f in files) {
                    cbx.Items.Add(Path.GetFileName(f));
                }
                if (cbx.Items.Count > 0) cbx.SelectedIndex = 0;
            }
            WPF.Log("Loaded Dir:{0} Files:{1}", dir, cbx.Items.Count);
        }

        private static string GetFilesDirByType(string swfDir) {

            return GetBookDir() + "\\" + swfDir;
        }

        internal static string GetBookDir() {

            return "C:\\Users\\" + WPF.IUserName + "\\" + WPF.IBookDir;
        }

        internal static string GetImageId(string fname) {

            int firstUnderscore = fname.IndexOf("_");
            int secondUnderscore = fname.IndexOf("_", firstUnderscore + 1);
            return fname.Substring(0, secondUnderscore);
        }

        private static string GetVideoID(string fname) {
            
            string buttonId;
            if (IsWebStream(fname)) {

                buttonId = "WEBSTREAM"; // play video embeded

            } else if (IsWebLink(fname)) {

                buttonId = "WEBLINK"; // open video in browser

            } else {

                buttonId = Path.GetFileNameWithoutExtension(fname); // play video from hd
            }
            return buttonId;
        }

        private static Boolean IsWebStream(string str) => str.IndexOf(".mp4") > -1;
        private static Boolean IsWebLink(string str) => str.IndexOf(": //") > -1;
    }
}
