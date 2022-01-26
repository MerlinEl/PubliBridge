using System;
using System.Linq;
using System.Xml;
using WalkerPlayer.utils;
using WalkerPlayerConsole;

namespace WalkerPlayer.bridge {
    internal class FlashArgsGet {
        public readonly string ProcessType; // "check_internet", "progress_download", ....
        public readonly string[] ParamsList;

        public FlashArgsGet(string xml_str) {

            // message is in xml format so we need to parse it
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml_str);

            // get attributes to see which command flash is trying to call
            XmlAttributeCollection attributes = document.FirstChild.Attributes;
            ProcessType = attributes.Item(0).InnerText;
            // get parameters
            XmlNodeList list = document.GetElementsByTagName("arguments");
            //WPGlobal.Log("CSharp", "FlashArgsGet >\n\tProcessType:{0} Params:{1}", ProcessType, list.Count);
            ParamsList = list[0].InnerText.Split(new char[] { '|' });

            //CConsole.Log("Flash", " OnFlashWalkerCall > data:\n\t{0}", data);
            //CConsole.Log("Flash", " OnFlashProjectorCall > data:\n\t{0}", data);
        }

        override public string ToString() => String.Format("ProcessType:{0} Params({1}):\n\t\t{2}", ProcessType, ParamsList.Length, ParamsList.Join("n\t\t"));
    }
}
