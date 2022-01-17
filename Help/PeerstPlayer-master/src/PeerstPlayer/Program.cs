using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using log4net;
using PeerstLib.Util;
using PeerstPlayer.Forms.Setting;

namespace PeerstPlayer
{
	static class Program
	{
		// log4netの初期化
		private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Logger.Instance.Info("START:PeerstPlayer");
	
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Corresponds to PeerCast that violates the protocol
			WebUtil.SettingDisableResponseError();

			// Unhandled exception in main thread
			Application.ThreadException += (sender, e) => Logger.Instance.Fatal(e.Exception);

			// Unhandled exceptions other than the main thread
			Thread.GetDomain().UnhandledException += (sender, e) => Logger.Instance.Fatal(e.ExceptionObject as Exception);

			PlayerView playerView = new PlayerView();
			Application.Run(playerView);

			Logger.Instance.Info("END:PeerstPlayer");
		}
	}
}
