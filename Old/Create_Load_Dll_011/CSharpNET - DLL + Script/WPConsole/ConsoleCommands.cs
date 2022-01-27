using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WalkerPlayerConsole {
    public partial class ConsoleCommands {
        
        // TODO get names from custom commands and add them in to popup list
        private static readonly List<ConsoleExternalCommand> ExternalCommands = new List<ConsoleExternalCommand>();

        public enum CMD {
            Help,
            Close,
            Clear,
            ClearAll,
            DockLeft,
            DockRight,
            DockTop,
            DockBottom
        }

        public enum DockSide { Left = 0, Right = 1, Top = 2, Bottom = 3 }

        // Add External Commands in to List
        internal static void AddCustomCommand(ConsoleExternalCommand customCommand) {
            ExternalCommands.Add(customCommand);
        }

        public static void RunCmd(ConsoleForm consoleForm, string cmd) {

            if (cmd.Length == 0) return;

            // Search in External Commands, is is found, will be executed
            if (ExternalCommands.Count > 0) {
                var externalCommand = ExternalCommands.SingleOrDefault(item => item.CmdName == cmd);
                if (externalCommand != null) {
                    externalCommand.Execute();
                    return;
                }
            }

            if (Enum.TryParse(cmd, true, out CMD n)) { //parse the enum with ignoreCase flag 
                Console.WriteLine("{0}", n);
                switch (n) {

                    case CMD.Help:
                        ShowCommands(consoleForm);
                        break;
                    case CMD.Close:
                        consoleForm.Hide();
                        break;
                    case CMD.Clear:
                        consoleForm.ClearConsole(); ;
                        break;
                    case CMD.ClearAll:
                        consoleForm.ClearAllTabs();
                        break;
                    case CMD.DockLeft:
                        consoleForm.DockTo(DockSide.Left);
                        break;
                    case CMD.DockRight:
                        consoleForm.DockTo(DockSide.Right);
                        break;
                    case CMD.DockTop:
                        consoleForm.DockTo(DockSide.Top);
                        break;
                    case CMD.DockBottom:
                        consoleForm.DockTo(DockSide.Bottom);
                        break;
                    default:
                        consoleForm.Log("\nCommand: ( " + cmd + " ) is not recognized.");
                        break;
                }
            } else {
                consoleForm.Log("\nCommand: ( " + cmd + " ) is not recognized.");
            }
        }

        private static void ShowCommands(ConsoleForm consoleForm) {
            consoleForm.Log("\nCommands List:");
            foreach (string s in Enum.GetNames(typeof(CMD))) {
                consoleForm.Log("\t" + s);
            }
        }
    }
}
