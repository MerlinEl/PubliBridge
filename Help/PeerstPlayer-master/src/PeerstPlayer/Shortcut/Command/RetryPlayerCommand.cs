using System;
using PeerstPlayer.Controls.PecaPlayer;

namespace PeerstPlayer.Shortcut.Command
{
	/// <summary>
	/// Reconnect (player) command
	/// </summary>
	class RetryPlayerCommand : IShortcutCommand
	{
		private PecaPlayerControl pecaPlayer;

		public RetryPlayerCommand(PecaPlayerControl pecaPlayer)
		{
			this.pecaPlayer = pecaPlayer;
		}

		void IShortcutCommand.Execute(CommandArgs commandArgs)
		{
			pecaPlayer.RetryPlayer();
		}

		string IShortcutCommand.GetDetail(CommandArgs commandArgs)
		{
			return "Reconnect (player)";
		}
	}
}
