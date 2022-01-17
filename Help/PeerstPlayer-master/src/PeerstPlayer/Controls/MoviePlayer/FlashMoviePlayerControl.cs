using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PeerstLib.Controls;
using PeerstPlayer.Controls.PecaPlayer;
using PeerstPlayer.Forms.Player;
using WMPLib;

namespace PeerstPlayer.Controls.MoviePlayer
{
	/// <summary>
	/// Flash video player control
	/// </summary>
	public partial class FlashMoviePlayerControl : UserControl, IMoviePlayer
	{
		private FlashMoviePlayerManager flashManager = null;

		public FlashMoviePlayerControl(PecaPlayerControl parent)
		{
			try
			{
				InitializeComponent();
			}
			catch (COMException)
			{
				MessageBox.Show("Flash Player is not installed.\nYou need to install Flash Player from Internet Explorer.",
					"ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			Dock = DockStyle.Fill;

			// Flash Manager initialization
			flashManager = new FlashMoviePlayerManager(axShockwaveFlash);
			flashManager.Initialized += (sender, args) =>
			{
				flashManager.EnableGpu(PlayerSettings.Gpu);
				flashManager.EnableRtmp(PlayerSettings.Rtmp);
				flashManager.SetBufferTime(PlayerSettings.BufferTime);
				flashManager.SetBufferTimeMax(PlayerSettings.BufferTimeMax);
			};
			// State change event
			flashManager.OpenStateChange += (sender, args) =>
			{
				if (isFirstMediaOpen)
				{
					var width = ((IMoviePlayer)this).ImageWidth;
					var height = ((IMoviePlayer)this).ImageHeight;
					axShockwaveFlash.Width = width;
					axShockwaveFlash.Height = height;
					movieStart(this, new EventArgs());
					isFirstMediaOpen = false;
				}

				// Correspondence for canceling mute when switching videos
				((IMoviePlayer)this).Mute = isMute;
				if (!isMute)
				{
					flashManager.ChangeVolume(volume);
				}
			};
			// Bump request event from player
			flashManager.RequestBump += (sender, args) => parent.Bump();
			// If the setting to use playback support is changed
			PlayerSettings.Changed += (s) =>
			{
				switch (s)
				{
				case "Gpu":
					flashManager.EnableGpu(PlayerSettings.Gpu);
					break;
				case "Rtmp":
					flashManager.EnableRtmp(PlayerSettings.Rtmp);
					break;
				case "BufferTime":
					flashManager.SetBufferTime(PlayerSettings.BufferTime);
					break;
				case "BufferTimeMax":
					flashManager.SetBufferTimeMax(PlayerSettings.BufferTimeMax);
					break;
				}
			};
			// Hook a Flash window
			FlashNativeWindow flash = new FlashNativeWindow(axShockwaveFlash);
			flash.MouseDownEvent += (sender, e) =>
			{
				mouseDownEvent(this, e);
				Focus();
			};
			flash.MouseUpEvent += (sender, e) => mouseUpEvent(this, e);
			flash.MouseMoveEvent += (sender, e) => mouseMoveEvent(this, e);
			flash.DoubleClickEvent += (sender, e) => doubleClickEvent(this, e);
			flash.KeyDownEvent += (sender, e) => keyDownEvent(this, e);
		}

		// Display video information
		public void ShowDebug()
		{
			flashManager.ShowDebug();
		}

		/// <summary>
		/// volume
		/// </summary>
		int volume = 0;
		int IMoviePlayer.Volume
		{
			get { return volume; }
			set
			{
				if (value < 0)
				{
					volume = 0;
				}
				else if (100 < value)
				{
					volume = 100;
				}
				else
				{
					volume = value;
				}

				// Unmute after changing volume
				isMute = false;

				flashManager.ChangeVolume(volume);
				volumeChange(this, new EventArgs());
			}
		}

		private int volumeBalance = 0;
		int IMoviePlayer.VolumeBalance
		{
			get { return volumeBalance; }
			set
			{
				if (value < -100)
				{
					volumeBalance = -100;
				}
				else if (100 < value)
				{
					volumeBalance = 100;
				}
				else
				{
					volumeBalance = value;
				}

				flashManager.ChangePan(volumeBalance);
			}
		}

		/// <summary>
		/// Volume change event
		/// </summary>
		event EventHandler IMoviePlayer.VolumeChange
		{
			add { volumeChange += value; }
			remove { volumeChange -= value; }
		}
		event EventHandler volumeChange = delegate { };

		/// <summary>
		/// Video playback start event
		/// </summary>
		event EventHandler IMoviePlayer.MovieStart
		{
			add { movieStart += value; }
			remove { movieStart -= value; }
		}
		event EventHandler movieStart = delegate { };

		/// <summary>
		/// mute
		/// </summary>
		private bool isMute = false;
		bool IMoviePlayer.Mute
		{
			get { return isMute; }
			set
			{
				isMute = value;
				if (isMute)
				{
					flashManager.ChangeVolume(0);
				}
				else
				{
					flashManager.ChangeVolume(volume);
				}
				volumeChange(this, new EventArgs());
			}
		}

		string IMoviePlayer.Duration
		{
			get { return flashManager.GetDurationString(); }
		}

		int IMoviePlayer.BufferingProgress
		{
			get { return 0; }
		}

		WMPLib.WMPPlayState IMoviePlayer.PlayState
		{
			get { return WMPPlayState.wmppsUndefined; }
		}

		WMPLib.WMPOpenState IMoviePlayer.OpenState
		{
			get { return WMPOpenState.wmposUndefined; }
		}

		float IMoviePlayer.AspectRate
		{
			get { return (float)((IMoviePlayer)this).ImageWidth / (float)((IMoviePlayer)this).ImageHeight; }
		}

		int IMoviePlayer.ImageWidth
		{
			get { return flashManager.GetVideoWidth() == 0 ? 800 : flashManager.GetVideoWidth(); }
		}

		int IMoviePlayer.ImageHeight
		{
			get { return flashManager.GetVideoHeight() == 0 ? 600 : flashManager.GetVideoHeight(); }
		}

		event AxWMPLib._WMPOCXEvents_MouseDownEventHandler mouseDownEvent = delegate { };
		event AxWMPLib._WMPOCXEvents_MouseDownEventHandler IMoviePlayer.MouseDownEvent
		{
			add { mouseDownEvent += value; }
			remove { mouseDownEvent -= value; }
		}

		event AxWMPLib._WMPOCXEvents_MouseUpEventHandler mouseUpEvent = delegate { };
		event AxWMPLib._WMPOCXEvents_MouseUpEventHandler IMoviePlayer.MouseUpEvent
		{
			add { mouseUpEvent += value; }
			remove { mouseUpEvent -= value; }
		}

		event AxWMPLib._WMPOCXEvents_MouseMoveEventHandler mouseMoveEvent = delegate { };
		event AxWMPLib._WMPOCXEvents_MouseMoveEventHandler IMoviePlayer.MouseMoveEvent
		{
			add { mouseMoveEvent += value; }
			remove { mouseMoveEvent += value; }
		}

		event AxWMPLib._WMPOCXEvents_DoubleClickEventHandler doubleClickEvent = delegate { };
		event AxWMPLib._WMPOCXEvents_DoubleClickEventHandler IMoviePlayer.DoubleClickEvent
		{
			add { doubleClickEvent += value; }
			remove { doubleClickEvent -= value; }
		}

		event AxWMPLib._WMPOCXEvents_KeyDownEventHandler keyDownEvent = delegate { };
		event AxWMPLib._WMPOCXEvents_KeyDownEventHandler IMoviePlayer.KeyDownEvent
		{
			add { keyDownEvent += value; }
			remove { keyDownEvent -= value; }
		}

		IntPtr IMoviePlayer.WMPHandle
		{
			get { return IntPtr.Zero; }
		}

		bool IMoviePlayer.EnableContextMenu
		{
			get { return false; }
			set { }
		}

		int IMoviePlayer.NowFrameRate
		{
			get { return flashManager.GetNowFrameRate(); }
		}

		int IMoviePlayer.FrameRate
		{
			get { return flashManager.GetFrameRate(); }
		}

		int IMoviePlayer.NowBitrate
		{
			get { return flashManager.GetNowBitRate(); }
		}

		int IMoviePlayer.Bitrate
		{
			get { return flashManager.GetBitRate(); }
		}

		Control IMoviePlayer.MovieControl
		{
			get { return this; }
		}

		/// <summary>
		/// First file open flag (used for MovieStart)
		/// </summary>
		private bool isFirstMediaOpen = true;

		void IMoviePlayer.PlayMoive(string streamUrl)
		{
			isFirstMediaOpen = true;
			axShockwaveFlash.LoadMovie(0, FormUtility.GetExeFolderPath() + "/FlvPlayer.swf");
			flashManager.PlayVideo(streamUrl);
		}

		/// <summary>
		/// Reconnects
		/// </summary>
		void IMoviePlayer.Retry()
		{
			flashManager.Retry();
		}
	}
}
