using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace cshpdll {
    class WAppSettings {

        /*
        <?xml version="1.0" encoding="utf-8" ?>
        <configuration>
            <appSettings>
                <add key="Key0" value="123" />      // int
                <add key="Key1" value="Helllo" />   // string
                <add key="Key2" value="1,2,3" />    // int Array
            </appSettings>
        </configuration>
        */

        /// <summary>
        /// Read a particular key from the config file 
        /// </summary>
        public static string GetSetting(string key) {

            string result;
            try {
                string val = Properties.Settings.Default[key].ToString();
                result = val ?? "Not Found";
                Console.WriteLine(result);
            }
            catch (ConfigurationErrorsException) {
                result = "Not Found";
                Console.WriteLine("Error reading app settings");
            }
            return result;
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
