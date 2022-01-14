using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace cshpdll {
    class WUserSettings {
        private static string AssemblyFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string ConfigFile => Path.Combine(AssemblyFolder, "cshpdll.config");

        /*
        <?xml version="1.0" encoding="utf-8" ?>
        <configuration>
	        <SWFPaths>
		        <item value="E:\Aprog\Orien\FlashC#\PubliBridge\Resources\swf\"/>
		        <item value="C:\Aprog\Orien\FlashC#\PubliBridge\Resources\swf\"/>
	        </SWFPaths>
        </configuration>
        */

        /// <summary>
        /// Read a particular key from the config file 
        /// </summary>
        public static string GetSetting(string key) {

            Console.WriteLine("GetSetting > ConfigFile:{0} found:{1}", ConfigFile, File.Exists(ConfigFile));
            if (!File.Exists(ConfigFile)) return "Not Found";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ConfigFile);
            XmlNodeList childNodes = doc.SelectNodes(key);
            if (childNodes == null) return "Not Found";
            foreach (XmlElement node in childNodes) {

                Console.WriteLine("list node:{0}", node.Name);
                if (node.Name == key) return node.Value;
            }

            //nodeList = root.SelectNodes("descendant::book[author/last-name='Austen']");
            return "Not Found";
        }

        /// <summary>
        /// Read multiple Values from a single Key
        /// </summary>
        public static List<string> GetSettings(string key) {

            string val = GetSetting(key);
            return val == "Not Found" ? new List<string>() : val.Split('|').ToList();
        }

        public static void AddOrUpdateAppSetting(string key, string value) {
            try {
                Properties.Settings.Default[key] = value;
                Properties.Settings.Default.Save();
            }
            catch (ConfigurationErrorsException) {
                Console.WriteLine("Error writing app settings");
            }
        }

        /// <summary>
        /// Add multiple Values under single Key
        /// </summary>
        public static void AddOrUpdateAppSettings(string key, List<string> values) {

            AddOrUpdateAppSetting(key, string.Join("|", values));
        }
    }
}
