﻿using AxShockwaveFlashObjects;
using System;
using WalkerPlayer.utils;

namespace WalkerPlayer.bridge {
    internal class FlashBridge {
        public static OWPlayer FlashOptions;
        /// <summary>
        /// Calls from Flash to CSharp
        /// </summary>
        /// <param name="flash">AxShockwaveFlashObjects.AxShockwaveFlash</param>
        /// <param name="e">AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent</param>
        /// 
        public static void OnFlashWalkerCall(AxShockwaveFlash flashWalker, _IShockwaveFlashEvents_FlashCallEvent e) {

            FlashArgsGet data = GetCommand(e.request);
            WPGlobal.Log("CSharp", "WPlayerForm > OnFlashWalkerCall >> [ {0} ]", data.ProcessType);
            //WPGlobal.Log("CSharp", "WPlayerForm > OnFlashWalkerCall >\n\tsender:{0}\n\tevent:{1}\n\tData:{2}", sender, e, data);
            switch (data.ProcessType) {
                case "FLASH_LOG":
                    // Flash debug output displayed in CSharp console
                    string[] logArgs = FlashDataParser.GetLogDataFromStringArray(data.ParamsList);
                    WPGlobal.Log(logArgs[0], logArgs[1]);
                    break;
                case "SWITCH_TO_FULL_SCREEN_MODE":
                    WPlayer.wLoader.SetFullScreen(true);
                    break;
                case "SWITCH_TO_WINDOW_MODE":
                    WPlayer.wLoader.SetFullScreen(false);
                    break;
                case "AUDIO_PLAYER_UI_READY":
                    // When flash Player loaded, send back commnd to play file
                    WPGlobal.Log("CSharp", "WPlayerForm > OnFlashWalkerCall > filePath:\n\t{0}", FlashOptions.FilePath);
                    SendCommand(flashWalker, new FlashArgsSend("CSHARP_COMMAND", "flashWalkerCallback", FlashOptions.FilePath));
                    break;
                case "LESSON_PLAYER_UI_READY":
                    // When flash Player loaded, send back commnd to play file
                    WPGlobal.Log("CSharp", "WPlayerForm > OnFlashWalkerCall > filePath:\n\t{0}", FlashOptions.FilePath);
                    string[] fl_params = new string[] {
                        FlashOptions.FilePath,
                        FlashOptions.WindowSize == "FULLSCREEN" ? "TRUE" : "FALSE"
                    };
                    SendCommand(flashWalker, new FlashArgsSend("CSHARP_COMMAND", "flashWalkerCallback", fl_params));
                    break;
                case "IMAGE_PLAYER_UI_READY":
                    // When flash Player loaded, send back commnd to play file
                    string xmlName = data.ParamsList[0]; // "PhotoText.xml"
                    // 24 > page     > number of current page
                    // 01 > set      > group of images
                    // 01 > count    > sequence index                                      
                    string imageID = data.ParamsList[1]; // 24_01_01

                    WPGlobal.Log("CSharp", "WPlayerForm > OnFlashWalkerCall > filePath:\n\t{0}", FlashOptions.FilePath);
                    SendCommand(flashWalker, new FlashArgsSend("CSHARP_COMMAND", "flashWalkerCallback", FlashOptions.FilePath));
                    break;
                case "CLOSE_WINDOW":
                    WPlayer.wLoader.CloseWindow();
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
                    WPGlobal.Log("CSharp", "WPlayerForm > OnFlashWalkerCall > fl_params:\n\t{0}", String.Join("\n\t", fl_params));
                    SendCommand(WPlayer.wLoader.FLWindow2D, new FlashArgsSend("CSHARP_UI_READY", "flashWalkerCallback", fl_params));
                    break;
                case "FLASH_APP_EXIT":
                    WPlayer.wLoader.Close();
                    break;
                case "READ_FILE":
                    // Read a file and send result back to Flash
                    string text = WPFso.ReadFile(data.ParamsList[0]);
                    //WPGlobal.Log("CSharp", "WPlayerForm > OnFlashWalkerCall > ReadFile > text:\n\t{0}", text);
                    SendCommand(WPlayer.wLoader.FLWindow2D, new FlashArgsSend(data.ProcessType, "flashCallback", text));
                    break;
                case "SAVE_FILE":

                    break;
                case "GET_FILES":
                    string methodName = data.ParamsList[0];
                    WPGlobal.Log("CSharp", "WPlayerForm > Flash need response from method:", methodName);
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