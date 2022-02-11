using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace WalkerPlayer.utils {
    class WPFso {
        public static XDocument ReadXmlFileFromNet(string url) {
            XDocument doc;
            try {
                doc = XDocument.Load(url);
            }
            catch {

                var webRequest = WebRequest.Create(url);
                webRequest.Method = "GET";
                using (var response = webRequest.GetResponse())
                using (var content = response.GetResponseStream())
                using (var reader = new StreamReader(content)) {
                    doc = XDocument.Parse(reader.ReadToEnd());
                }
            }
            return doc;
        }
        public static XElement ReadXmlFile(string fpath) {
            
            if (!File.Exists(fpath)) return null;
            return XElement.Load(fpath);
        }

        public static void SaveXmlFile(XElement RootElement, string fpath) => RootElement.Save(fpath);

        public static string ReadFile(string fpath) {
            
            string text = "undefined";
            if (!File.Exists(fpath)) return text;
            try {
                text = File.ReadAllText(fpath);
            }
            catch (Exception e) {
                WPGlobal.Log("CSharp", "WPFso > ReadFile > Error:" + e.Message); 
            }
            return text;
        }

        public static bool SaveFile(string fpath, string text) {
            
            if (!File.Exists(fpath)) return false;
            try {
                File.WriteAllText(fpath, text);
            }
            catch (Exception e) {
                WPGlobal.Log("CSharp", "WPFso > SaveFile > Error:" + e.Message);
                return false;
            }
            return true;
        }

        public static string GetAppDir() {

            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        /// <summary>
        /// Ret files by extension type
        /// </summary>
        /// <param name="extensions">string[] extensions = new[] { "*.jpg", "*.png", "*.gif" }</param>
        public static string[] GetFiles(string dir, string[] extensions) {

            if (!Directory.Exists(dir)) return new string[] { };
            return extensions.SelectMany(f => Directory.GetFiles(dir, f)).ToArray();
        }
    }
}
