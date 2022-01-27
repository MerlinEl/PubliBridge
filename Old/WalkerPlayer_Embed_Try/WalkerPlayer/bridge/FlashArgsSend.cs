using System.Collections.Generic;
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
        public FlashArgsSend(string processType, string callbackName, string strParam) {

            ProcessType = processType;
            CallbackName = callbackName;
            ParamList = new string[] { processType, strParam };
        }
        public FlashArgsSend(string processType, string callbackName, string[] strParams) {
           
            ProcessType = processType;
            CallbackName = callbackName;
            List<string> list = strParams.ToList<string>();
            list.Insert(0, processType);
            ParamList = list.ToArray();
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
           WPGlobal.Log("CSharp", "FlashArgsSend > xml_cmd:\n\t{0}", xml_cmd);
            return xml_cmd;
        }
    }
}
