﻿using System;
using System.Drawing;
using System.Windows.Forms;
using PeerstPlayer.Controls.PecaPlayer;

namespace PeerstPlayer.Shortcut.Command
{
	/// <summary>
	/// ウィンドウサイズ指定コマンド
	/// </summary>
	class WindowSizeCommand : IShortcutCommand
	{
		private Form form;
		private PecaPlayerControl pecaPlayer;

		public WindowSizeCommand(Form form, PecaPlayerControl pecaPlayer)
		{
			this.form = form;
			this.pecaPlayer = pecaPlayer;
		}

		void IShortcutCommand.Execute(CommandArgs commandArgs)
		{
			// ウィンドウ状態が通常の場合にのみ実行する
			if (form.WindowState != FormWindowState.Normal)
			{
				return;
			}

			WindowSizeCommandArgs args = (WindowSizeCommandArgs)commandArgs;
			Size size = args.Size;
			pecaPlayer.SetSize(size.Width, size.Height);
		}

		string IShortcutCommand.GetDetail(CommandArgs commandArgs)
		{
			WindowSizeCommandArgs args = (WindowSizeCommandArgs)commandArgs;
			Size size = args.Size;
			return string.Format("サイズ ({0}x{1})", size.Width, size.Height);
		}
	}
}
