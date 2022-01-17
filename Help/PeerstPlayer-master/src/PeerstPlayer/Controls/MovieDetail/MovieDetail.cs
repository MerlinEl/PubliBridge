﻿using System;
using System.Windows.Forms;
using PeerstLib.Util;

namespace PeerstPlayer.Controls.MovieDetail
{
	//-------------------------------------------------------------
	// 概要：動画詳細コントロールクラス
	//-------------------------------------------------------------
	public partial class MovieDetailControl : UserControl
	{
		//-------------------------------------------------------------
		// 公開プロパティ
		//-------------------------------------------------------------

		// チャンネル詳細
		public string ChannelDetail
		{
			get { return ChannelDetailLabel.Text; }
			set { ChannelDetailLabel.Text = value; }
		}

		// 動画ステータス
		public string MovieStatus
		{
			get { return movieStatusLabel.Text; }
			set { movieStatusLabel.Text = value; }
		}

		// 音量
		public string Volume
		{
			get { return volumeLabel.Text; }
			set { volumeLabel.Text = value; }
		}

		// 動画詳細のクリックイベント
		public event MouseEventHandler ChannelDetailClick = delegate { };

		// 音量のクリックイベント
		public event EventHandler VolumeClick = delegate { };

		// マウスホバーイベント
		public event EventHandler MouseHoverEvent = delegate { };

		//-------------------------------------------------------------
		// 概要：コンストラクタ
		// 詳細：イベントの設定
		//-------------------------------------------------------------
		public MovieDetailControl()
		{
			Logger.Instance.Debug("MovieDetail()");
			InitializeComponent();

			// チャンネル詳細クリック
			MouseEventHandler action = (sender, e) =>
			{
				Logger.Instance.Info("チャンネル詳細をクリック");
				ChannelDetailClick(sender, e);
			};
			this.MouseClick += action;
			ChannelDetailLabel.MouseClick += action;
			movieStatusLabel.MouseClick += action;

			// 音量クリック
			volumeLabel.Click += (sender, e) =>
			{
				Logger.Instance.Info("音量ラベルをクリック");
				VolumeClick(sender, e);
			};

			// マウスホバーイベント
			ChannelDetailLabel.MouseHover += (sender, e) => MouseHoverEvent(sender, e);
			movieStatusLabel.MouseHover += (sender, e) => MouseHoverEvent(sender, e);
		}
	}
}
