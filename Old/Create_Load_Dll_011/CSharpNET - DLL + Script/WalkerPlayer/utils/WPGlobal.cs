using System;
using WalkerPlayer.bridge;
using WalkerPlayerConsole;
using static WalkerPlayerConsole.ConsoleCommands;

namespace WalkerPlayer.utils {
    class WPGlobal {
        private static ConsoleForm CConsole;
        public static bool IsConsoleVisible => CConsole != null && CConsole.Visible;

        /// <summary>
        /// CConsole = new McConsole(progBar);
        /// CConsole.Log("hello!"); // main console tab
        /// CConsole.Log("", "The {0} is {1} years old.", "Tifany", 12); // main console tab
        /// CConsole.Log("The {0} is {1} years old.", new object[] {"Tifany", 12}); // main console tab
        /// CConsole.Log("Console", "The {0} is {1} years old.", "Tifany", 12); // main console tab
        /// CConsole.Log("The {0} is {1} years old.", new object[] {"John", 33});
        /// CConsole.Log("Personal", "hello Body"); //ok
        /// CConsole.Log("Formated", "The {0} is {1} years old.", new object[] { "Monika", 22});
        /// </summary>
        internal static void Log(string msg) => AddConsoleText("Console", msg);
        internal static void Log(string msg, params object[] args) => AddConsoleText("Console", msg, args);
        internal static void Log(string tabName, string msg) => AddConsoleText(tabName, msg);
        internal static void Log(string tabName, string msg, params object[] args) => AddConsoleText(tabName, msg, args);
        private static void AddConsoleText(string tabName, string msg, params object[] args) {

            if (args.Length > 0) msg = string.Format(msg, args);
            CConsole?.Log(tabName, msg, args);
        }

        internal static void ShowConsole(bool state) {
            
            if (state) {
                CConsole.Show(); 
            } else {
                CConsole.Hide();
            }
        }

        internal static void CreateConsole(WPlayerForm wLoader) {
            
            // Create console ( hidden )
            CConsole = new ConsoleForm(wLoader, true, true); 
            CConsole.DockTo(ConsoleCommands.DockSide.Bottom);

            // Add console custom commands
            var cc_001 = new ConsoleExternalCommand("Exit", "ExitWPlayer");
            cc_001.FromClassName("WPGlobal"); // using this class
            CConsole.AddCustomCommand(cc_001);
        }

        public void ExitWPlayer() {
            CConsole.Close();
            WPlayer.wLoader.Close();
            CConsole = null;
            WPlayer.wLoader = null;
        }

        internal static void ConsoleHiddenMode(bool state) {
            CConsole.HiddenMode = state;
        }

        internal static void DisposeConsole() {
            CConsole.Close();
            CConsole = null;
        }
    }
}


//CConsole.Log("hello!"); // main console tab
//CConsole.CConsole.Log("IUcGlobal", "SendEmail > emailArgs: {0}", emailArgs.ToString());
//CConsole.Log("", "The {0} is {1} years old.", "Tifany", 12); // main console tab
//CConsole.Log("The {0} is {1} years old.", new object[] { "Tifany", 12 }); // main console tab
//CConsole.Log("Console", "The {0} is {1} years old.", "Tifany", 12); // main console tab
//CConsole.Log("The {0} is {1} years old.", new object[] { "John", 33 });
//CConsole.Log("Personal", "hello Body"); //ok
//CConsole.Log("Formated", "The {0} is {1} years old.", new object[] { "Monika", 22 });