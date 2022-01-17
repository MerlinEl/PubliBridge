using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerstPlayer.Shortcut.Command
{
	/// <summary>
	/// Empty command
	/// </summary>
	class NullCommand : IShortcutCommand
	{
		void IShortcutCommand.Execute(CommandArgs commandArgs)
		{
		}

		string IShortcutCommand.GetDetail(CommandArgs commandArgs)
		{
			return "No processing";
		}
	}
}
