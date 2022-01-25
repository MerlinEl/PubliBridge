using System.Linq;
using WalkerPlayer.utils;

namespace WalkerPlayer.bridge {
    internal class FlashArgsSend {
        public readonly string ProcessType; // "check_internet", "progress_download", ....
        public readonly string[] ParamList;
        public readonly string CallbackName = "flashCallback";
        public FlashArgsSend(string process_type) {

            ProcessType = process_type;
            ParamList = new string[] { process_type };
        }
        public FlashArgsSend(string process_type, string str_param) {

            ProcessType = process_type;
            ParamList = new string[] { process_type, str_param };
        }
        public FlashArgsSend(string process_type, string[] str_params) {

            ProcessType = process_type;
            str_params[0] = process_type;
            ParamList = str_params;
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
