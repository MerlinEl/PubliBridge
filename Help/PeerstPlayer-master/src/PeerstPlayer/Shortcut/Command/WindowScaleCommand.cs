﻿using System.Drawing;
using System.Windows.Forms;
using PeerstPlayer.Controls.PecaPlayer;

namespace PeerstPlayer.Shortcut.Command
{
	/// <summary>
	/// ウィンドウ拡大率指定コマンド
	/// </summary>
	class WindowScaleCommand : IShortcutCommand
	{
		private Form form;
		private PecaPlayerControl pecaPlayer;

		public WindowScaleCommand(Form form, PecaPlayerControl pecaPlayer)
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

			WindowScaleCommandArgs args = (WindowScaleCommandArgs)commandArgs;
			int width = (int)(pecaPlayer.ImageWidth * args.Scale);
			int height = (int)(pecaPlayer.ImageHeight * args.Scale);
			pecaPlayer.SetSize(width, height);
		}

		string IShortcutCommand.GetDetail(CommandArgs commandArgs)
		{
			WindowScaleCommandArgs args = (WindowScaleCommandArgs)commandArgs;
			return string.Format("サイズ ({0}%)", args.Scale * 100);
		}
	}
}
