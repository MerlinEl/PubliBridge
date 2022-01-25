using AxShockwaveFlashObjects;
using WalkerPlayer.utils;

namespace WalkerPlayer.bridge {
    internal class FlashBridge {

        internal static void Update(AxShockwaveFlash Fplayer) => Fplayer.Update();
        /// <summary>
        /// Send command in to flash player(container)
        /// </summary>
        /// <param name="fn_name">name = Flash function</param>
        /// <param name="args_str">arguments = function parameters</param>
        //internal static void SendCommand(AxShockwaveFlash player, mcFlashSendArgs cmd) => player.CallFunction(cmd.ToXML());
        internal static FlashArgsGet GetCommand(string xml_str) {
            //WPGlobal.Log("CSharp", "FlashBridge > FlashArgsGet >\n\txml_str:{0}", xml_str);
            return new FlashArgsGet(xml_str);
        }

        internal static void SendCommand(AxShockwaveFlash Fplayer, FlashArgsSend flash_args) => Fplayer.CallFunction(flash_args.ToXML());
    }
}
