using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace cshpdll {
    class WSettings {

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
                var appSettings = ConfigurationManager.AppSettings;
                result = appSettings[key] ?? "Not Found";
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

        /// <summary>
        /// Read all the keys from the config file.
        /// </summary>
        public static void ReadAllSettings() {

            try {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0) {
                    Console.WriteLine("AppSettings is empty.");
                } else {
                    foreach (var key in appSettings.AllKeys) {
                        Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (ConfigurationErrorsException) {
                Console.WriteLine("Error reading app settings");
            }
        }

        public static void AddOrUpdateAppSetting(string key, string value) {
            try {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null) {
                    settings.Add(key, value);
                } else {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
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
