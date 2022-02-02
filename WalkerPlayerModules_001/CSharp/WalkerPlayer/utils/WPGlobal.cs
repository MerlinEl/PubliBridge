using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WalkerPlayerConsole;
using static WalkerPlayerConsole.ConsoleCommands;

namespace WalkerPlayer.utils {
    class WPGlobal {
        private static ConsoleForm CConsole;
        public static bool IsConsoleVisible => CConsole != null && CConsole.Visible;

        /// <summary>
        /// CConsole = new McConsole(progBar);
        /// CConsole.Log("hello!"); // main console tab
        /// CConsole.Log("", "The {0} is {1} years old.", "Tifany", 12); // main console tab
        /// CConsole.Log("The {0} is {1} years old.", new object[] {"Tifany", 12}); // main console tab
        /// CConsole.Log("Console", "The {0} is {1} years old.", "Tifany", 12); // main console tab
        /// CConsole.Log("The {0} is {1} years old.", new object[] {"John", 33});
        /// CConsole.Log("Personal", "hello Body"); //ok
        /// CConsole.Log("Formated", "The {0} is {1} years old.", new object[] { "Monika", 22});
        /// </summary>
        internal static void Log(string msg) => AddConsoleText("Console", msg);
        internal static void Log(string msg, params object[] args) => AddConsoleText("Console", msg, args);
        internal static void Log(string tabName, string msg) => AddConsoleText(tabName, msg);
        internal static void Log(string tabName, string msg, params object[] args) => AddConsoleText(tabName, msg, args);
        private static void AddConsoleText(string tabName, string msg, params object[] args) {

            if (args.Length > 0) msg = string.Format(msg, args);
            CConsole?.Log(tabName, msg, args);
        }

        internal static void ShowConsole(bool state) {
            
            if (state) {
                CConsole.Show(); 
            } else {
                CConsole.Hide();
            }
        }

        internal static void CreateConsole(WPlayerForm wLoader) {
            
            // Create console ( hidden )
            CConsole = new ConsoleForm(wLoader, true, true); 
            CConsole.DockTo(ConsoleCommands.DockSide.Bottom);

            // Add console custom commands
            var cc_001 = new ConsoleExternalCommand("Exit", "ExitWPlayer");
            cc_001.FromClassName("WPGlobal"); // using this class
            CConsole.AddCustomCommand(cc_001);
        }

        public void ExitWPlayer() {
            CConsole.Close();
            WPlayer.wLoader.Close();
            CConsole = null;
            WPlayer.wLoader = null;
        }

        internal static void ConsoleHiddenMode(bool state) {
            CConsole.HiddenMode = state;
        }

        internal static void DisposeConsole() {
            CConsole.Close();
            CConsole = null;
        }

        internal static string GetPlayerPath(string bookDir, string mediaType) {

            string playerPath = bookDir + "\\";
            switch (mediaType) {

                case "AUDIO"    : playerPath += "AudioPlayer.swf"; break;
                case "VIDEO"    : playerPath += "VideoPlayer.swf"; break;
                case "IMAGES"   : playerPath += "ImagePlayer.swf"; break;
                case "LESSONS"   : playerPath += "LessonPlayer.swf"; break;
                case "STAGE3D"  : playerPath += "3DPlayer.swf"; break;
            }
            return playerPath;
        }

        internal static string[] GetImagesComments(string xmlFile, string[] images) {

            XElement element = WPFso.ReadXmlFile(xmlFile);
            if (element == null) return new string[] { };
            List<string> comments = new List<string>();
            foreach (string f in images) {

                string fName = Path.GetFileName(f); // 31_01_02_nebezpečí plastů v oceánech.jpg
                string imgID = fName.Substring(0, fName.LastIndexOf("_")); // 31_01_02
                imgID = imgID.Substring(0, imgID.LastIndexOf("_")); // 31_01
                string comment = "EMPTY";
                foreach (XElement el in element.Elements()) {

                    string n = el.Name.LocalName; // text_31_01_02
                    int firstUnderscore = n.IndexOf("_");
                    n = n.Substring(firstUnderscore + 1); // 31_01_02
                    int lastUnderscore = n.LastIndexOf("_");
                    n = n.Substring(0, lastUnderscore); // 31_01
                    //WPGlobal.Log("CSharp ( WPGlobal )", "GetImagesByButtonID > n:{0} id:{1} match:{2}", n, imgID, n == imgID);
                    //WPGlobal.Log("CSharp ( WPGlobal )", "GetImagesByButtonID > add:{0}", el.Attribute("label").Value);
                    if (n == imgID) comment = el.Attribute("label").Value;
                }
                comments.Add(comment);
            }
            return comments.ToArray();
        }
        internal static string[] GetImagesByButtonID(OWPlayer options) {

            string imagesDir = options.BookDir + "\\photos";
            string[] images = WPFso.GetFiles(imagesDir, new string[] { "*.jpg" });
            List<string> imagesSet = new List<string>();
            foreach (string f in images) {
                string fName = Path.GetFileName(f);
                string fId = GetIdFromFileName(fName);
                if (fId == options.ButtonID) imagesSet.Add(f);
            }
            return imagesSet.ToArray();
        }
        // input > fname = 101_01_01_alej topolů.jpg
        // out > id = 101_01
        internal static string GetIdFromFileName(string fname) {

            int firstUnderscore = fname.IndexOf("_");
            int secondUnderscore = fname.IndexOf("_", firstUnderscore+1);
            return fname.Substring(0, secondUnderscore);
        }

        // Can't be used outside of C# ( need SharpZlib.dll at executable dir)
        internal static Size GetPlayerSize(string playerPath) {

            Size mediaSize = Size.Empty;
            try {
                SwfParser swfParser = new SwfParser();
                Rectangle rectangle = swfParser.GetDimensions(playerPath);
                Log("CSharp", "WPGlobal > GetMediaSize > w:{0} h:{1}", rectangle.Width, rectangle.Height);
                mediaSize = new Size(rectangle.Width, rectangle.Height);
            }
            catch (Exception ex) {
                
                WPGlobal.Log("CSharp", "WPGlobal > GetMediaSize > There is a problem with the swf file. " + ex.Message);
            }
            return mediaSize;
        }
    }
}


//CConsole.Log("hello!"); // main console tab
//CConsole.CConsole.Log("IUcGlobal", "SendEmail > emailArgs: {0}", emailArgs.ToString());
//CConsole.Log("", "The {0} is {1} years old.", "Tifany", 12); // main console tab
//CConsole.Log("The {0} is {1} years old.", new object[] { "Tifany", 12 }); // main console tab
//CConsole.Log("Console", "The {0} is {1} years old.", "Tifany", 12); // main console tab
//CConsole.Log("The {0} is {1} years old.", new object[] { "John", 33 });
//CConsole.Log("Personal", "hello Body"); //ok
//CConsole.Log("Formated", "The {0} is {1} years old.", new object[] { "Monika", 22 });