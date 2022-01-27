using WalkerPlayer.utils;

namespace WalkerPlayer.bridge {
    class FlashCalls {
        
        public static OWPlayer FlashOptions;
        public static void OnFlashCall(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEvent e) {

            FlashArgsGet data = FlashBridge.GetCommand(e.request);
            WPGlobal.Log("CSharp", "WPlayerForm > OnFlashCall >\n\tsender:{0}\n\tData:{1}", sender, data);
            switch (data.ProcessType) {
                case "FLASH_UI_READY":
                    // When flash loads send it RottDir ( directory with xml settings )
                    string rootDir = FlashOptions.RootDir;
                    FlashBridge.SendCommand(WPlayer.wLoader.FLWindow2D, new FlashArgsSend("GET_APP_DIR", "flashWalkerCallback", rootDir));
                    break;
                case "FLASH_LOG":
                    // Flash debug output displayed in CSharp console
                    string[] logArgs = FlashDataParser.GetLogDataFromStringArray(data.ParamsList);
                    WPGlobal.Log(logArgs[0], logArgs[1]);
                    break;
                case "FLASH_APP_EXIT":
                    WPlayer.wLoader.Close();
                    break;
                case "READ_FILE":
                    // Read a file and send result back to Flash
                    string text = WPFso.ReadFile(data.ParamsList[0]);
                    FlashBridge.SendCommand(WPlayer.wLoader.FLWindow2D, new FlashArgsSend("READ_FILE", "flashWalkerCallback", text));
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
                    FlashBridge.SendCommand(WPlayer.wLoader.FLWindow2D, new FlashArgsSend("GET_FILES", "flashCallback", string.Join(",", files)));
                    break;
                case "LOAD_3D_PROJECTOR":
                    WModelWiewer.Load3DProjector(WPlayer.wLoader.FLWindow3D, FlashOptions.RootDir, data.ParamsList);
                    break;
            }
        }
    }
}
