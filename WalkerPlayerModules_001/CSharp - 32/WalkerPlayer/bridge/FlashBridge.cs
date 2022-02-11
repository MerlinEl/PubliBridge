using AxShockwaveFlashObjects;
using System.Linq;
using WalkerPlayer.player;
using WalkerPlayer.utils;
using WalkerPlayerConsole;

namespace WalkerPlayer.bridge {
    internal class FlashBridge {
        public static OWPlayer FlashOptions;
        /// <summary>
        /// Calls from Flash to CSharp
        /// </summary>
        /// <param name="flash">AxShockwaveFlashObjects.AxShockwaveFlash</param>
        /// <param name="e">AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent</param>
        /// 
        public static void OnFlashWalkerCall(AxShockwaveFlash flashComponent, _IShockwaveFlashEvents_FlashCallEvent e) {

            FlashArgsGet data = GetCommand(e.request);
            WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall >> [ {0} ]", data.ProcessType);
            //WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall >\n\tsender:{0}\n\tevent:{1}\n\tData:{2}", sender, e, data);
            string[] fl_params;
            switch (data.ProcessType) {
                case "FLASH_LOG":
                    // Flash debug output displayed in CSharp console
                    string[] logArgs = FlashDataParser.GetLogDataFromStringArray(data.ParamsList);
                    WPGlobal.Log(logArgs[0], logArgs[1]);
                    break;
                case "CLOSE_WINDOW":
                    WPlayer.wLoader.CloseWindow();
                    break;
                case "IS_FULL_SCREEN_MODE":
                    string is_fullscreen = WPlayer.wLoader.IsFullScreen ? "TRUE" : "FALSE";
                    SendCommand(flashComponent, new FlashArgsSend(data.ProcessType, "flashCallback", is_fullscreen));
                    break;
                case "SWITCH_TO_FULL_SCREEN_MODE":
                    WPlayer.wLoader.SetFullScreen(true);
                    break;
                case "SWITCH_TO_WINDOW_MODE":
                    WPlayer.wLoader.SetFullScreen(false);
                    break;
                case "READ_FILE":
                    // Read a file and send result back to Flash
                    string text = WPFso.ReadFile(data.ParamsList[0]);
                    //WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall > ReadFile > text:\n\t{0}", text);
                    SendCommand(flashComponent , new FlashArgsSend(data.ProcessType, "flashCallback", text));
                    break;
                //case "RELOAD_MEDIA":
                //    WPWindow.ReloadMedia(WPlayer.wLoader, flashComponent, FlashOptions);
                //    break;
                case "AUDIO_PLAYER_UI_READY":
                    // When flash Player loaded, send back commnd to play file
                    // Index Explanation ( 04_01 ) < 04_01.mp3
                    // 04 > page     > number of current page
                    // 01 > count    > sequence index
                    WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall > filePath:\n\t{0}", FlashOptions.FileName);
                    SendCommand(flashComponent, new FlashArgsSend("CSHARP_COMMAND", "flashWalkerCallback", FlashOptions.FileName));
                    break;
                case "LESSON_PLAYER_UI_READY":
                    // When flash Player loaded, send back commnd to play file
                    WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall > filePath:\n\t{0}", FlashOptions.FileName);
                    fl_params = new string[] {
                        FlashOptions.FileName,  // 004.swf
                        FlashOptions.BookDir,
                        FlashOptions.WindowSize == "FULLSCREEN" ? "TRUE" : "FALSE"
                    };
                    SendCommand(flashComponent, new FlashArgsSend("CSHARP_COMMAND", "flashWalkerCallback", fl_params));
                    break;
                case "IMAGE_PLAYER_UI_READY":
                    // When flash Player loaded, send back commnd to play file
                    string xmlFile = FlashOptions.BookDir + "\\" + data.ParamsList[0]; // "PhotoText.xml"
                    string imageID = FlashOptions.CustomTag;
                    WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall >\n\txmlFile:{0}\n\timageID:{1}", xmlFile, imageID);
                    // IMAGE_ID ( 24_01_01 ) < 20_01_01_mečoun obecný.jpg
                    // 24 > page     > number of current page
                    // 01 > set      > group of images
                    // 01 > count    > sequence index                                      
                    string[] imagesSet = WPGlobal.GetImagesByButtonID(FlashOptions);
                    string[] imagesComment = WPGlobal.GetImagesComments(xmlFile, imagesSet);
                    fl_params = new string[] {
                        imagesSet.Join("|"),
                        imagesComment.Join("|"),
                        FlashOptions.WindowSize == "FULLSCREEN" ? "TRUE" : "FALSE"
                    };
                    WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall > imageID:\n\t{0}", imageID);
                    WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall > imagesSet:\n\t{0}", imagesSet.Join("\n\t"));
                    WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall > imagesComment:\n\t{0}", imagesComment.Join("\n\t"));
                    SendCommand(flashComponent, new FlashArgsSend("CSHARP_COMMAND", "flashWalkerCallback", fl_params));
                    break;
                case "VIDEO_PLAYER_UI_READY":
                    fl_params = new string[] {
                        FlashOptions.CustomTag, // Video Type: ( LOCAL, WEBSTREAM, or WEBLINK) 
                        FlashOptions.FileName,  // 158.swf or https://www...
                        FlashOptions.WindowSize == "FULLSCREEN" ? "TRUE" : "FALSE"
                    };
                    SendCommand(flashComponent, new FlashArgsSend("CSHARP_COMMAND", "flashWalkerCallback", fl_params));
                    break;
                case "3D_PLAYER_UI_READY":
                    fl_params = new string[] {
                        FlashOptions.FileName,  // 20.swf
                        FlashOptions.WindowSize == "FULLSCREEN" ? "TRUE" : "FALSE"
                    };
                    WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall > FileName:\n\t{0}", FlashOptions.FileName);
                    SendCommand(flashComponent, new FlashArgsSend("CSHARP_COMMAND", "flashWalkerCallback", fl_params));
                    break;
            }
        }

        public static void Update(AxShockwaveFlash Fplayer) => Fplayer.Update();

        /// <summary>
        /// Send command in to flash player(container)
        /// </summary>
        /// <param name="fn_name">name = Flash function</param>
        /// <param name="args_str">arguments = function parameters</param>
        //internal static void SendCommand(AxShockwaveFlash player, mcFlashSendArgs cmd) => player.CallFunction(cmd.ToXML());
        private static FlashArgsGet GetCommand(string xml_str) {
            //WPGlobal.Log("CSharp", "FlashBridge > FlashArgsGet >\n\txml_str:{0}", xml_str);
            return new FlashArgsGet(xml_str);
        }

        public static void SendCommand(AxShockwaveFlash fPlayer, FlashArgsSend flashArgs) {

            fPlayer.CallFunction(flashArgs.ToXML());
        }
    }
}


/*

                case "FLASH_UI_READY":
                    // When flash load finished, FILL SOME VARIABLES:
                    string[] fl_params = new string[] {
                        FlashOptions.RootDir, // directory with xml settings
                        FlashOptions.FullScreen == true ? "TRUE" : "FALSE",
                        FlashOptions.SkipLogo == true ? "TRUE" : "FALSE"
                    };
                    WPGlobal.Log("CSharp", "FlashBridge > OnFlashWalkerCall > fl_params:\n\t{0}", String.Join("\n\t", fl_params));
                    SendCommand(WPlayer.wLoader.FLWindow2D, new FlashArgsSend("CSHARP_UI_READY", "flashWalkerCallback", fl_params));
                    break;
                case "FLASH_APP_EXIT":
                    WPlayer.wLoader.Close();
                    break;
                case "SAVE_FILE":

                    break;
                case "GET_FILES":
                    string methodName = data.ParamsList[0];
                    WPGlobal.Log("CSharp", "FlashBridge > Flash need response from method:", methodName);
                    string filesDir = data.ParamsList[0];
                    string[] extensions = data.ParamsList[1].Split(',');
                    // convert {"jpg","png","gif"} in to {"*.jpg","*.png","*.gif"}
                    for (int i = 0; i < extensions.Length; i++) {
                        extensions[i] = "*." + extensions[i];
                    }
                    string[] files = WPFso.GetFiles(filesDir, extensions);
                    SendCommand(WPlayer.wLoader.FLWindow2D, new FlashArgsSend(data.ProcessType, "flashCallback", string.Join(",", files)));
                    break;
                case "LOAD_3D_PROJECTOR":
                    //WPManager.Load3DProjector(WPlayer.wLoader.FLWindow3D, FlashOptions.RootDir, data.ParamsList);
                    break;

                //case "FLASH_LOG":
                    // Flash debug output displayed in CSharp console
                    //string[] logArgs = FlashDataParser.GetLogDataFromStringArray(data.ParamsList);
                    //WPGlobal.Log(logArgs[0], logArgs[1]);
                    //break;
                //case "HIDE_3D_PROJECTOR":
                    // Hide C# component (flash content was unloaded before this call)
                    //WPlayer.wLoader.FLWindow3D.Visible = false;
                    //break;
 */