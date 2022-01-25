using System.Linq;
using WalkerPlayer.utils;
using WalkerPlayerConsole;

namespace WalkerPlayer.bridge {
    internal class FlashArgsSend {
        public readonly string ProcessType; // "check_internet", "progress_download", ....
        public readonly string[] ParamList;
        private readonly string CallbackName  = "flashWalkerCallback";
        public FlashArgsSend(string processType, string callbackName) {

            ProcessType = processType;
            CallbackName = callbackName;
            ParamList = new string[] { processType };
        }
        public FlashArgsSend(string processType, string callbackName, string strParams) {

            ProcessType = processType;
            CallbackName = callbackName;
            ParamList = new string[] { processType, strParams };
        }
        public FlashArgsSend(string processType, string callbackName, string[] strParams) {
           
            ProcessType = processType;
            CallbackName = callbackName;
            strParams[0] = processType;
            ParamList = strParams;
        }
        internal string ToXML() {

            // generate xml items
            string param_list = ParamList.Select(str => "<string>" + str + "</string>").ToArray().Join("");
            // build xml string
            string xml_cmd = $@"
            <invoke name=""{CallbackName}"" returntype='xml'>
                <arguments>{param_list}</arguments>
            </invoke>";
            //remove tabs and new lines
            xml_cmd = WPString.CondenseTabsAndNewLines(xml_cmd);
            return xml_cmd;
        }
    }
}
