using System;
using System.Linq;
/*
 * @usage
    var ec = new ExternalCommand("ClearConsole"); //args = string[]{"All", "True"}
    ec.FromClassName("CustomCommandsClass")
    ConsoleCommands.ExternalCommands.Add(ec);
*/
namespace WalkerPlayerConsole {
    public partial class ConsoleCommands {
        public class ConsoleExternalCommand {

            private object _classInstance;
            private bool _isValid = false;
            private readonly string _cmdName;
            private readonly string _methodName;
            private readonly string[] _args;
            public string MethodName => _methodName;
            public string CmdName => _cmdName;
            public bool IsValid => _isValid;

            public ConsoleExternalCommand(string cmdName, string methodName, string[] args = null) {
                _cmdName = cmdName;
                _methodName = methodName;
                _args = args;
            }

            public void FromClassName(string className) {
                // scan for the class type
                var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                            from t in assembly.GetTypes()
                            where t.Name == className  // you could use the t.FullName as well
                            select t).FirstOrDefault();

                if (type == null) throw new InvalidOperationException("Type not found");
                _classInstance = Activator.CreateInstance(type);
                if (_classInstance != null) _isValid = true;
            }

            internal void Execute() {
                if (!IsValid) return;
                // Use reflection to get the Method
                var type = _classInstance.GetType();
                var methodInfo = type?.GetMethod(_methodName);
                // Invoke the method here
                methodInfo?.Invoke(_classInstance, _args); // args can be null
            }
        }
    }
}
