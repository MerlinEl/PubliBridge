using System.Diagnostics;
using AxShockwaveFlashObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using PeerstLib.Util;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace PeerstPlayer.Controls.MoviePlayer
{
	class FlashMoviePlayerManager
	{
		private AxShockwaveFlash flash;

		// Flashのコマンド
		private const string PlayVideoMethod = "PlayVideo";
		private const string RetryMethod = "Retry";
		private const string ChangeVolumeMethod = "ChangeVolume";
		private const string ChangePanMethod = "ChangePan";
		private const string GetVideoWidthMethod = "GetVideoWidth";
		private const string GetVideoHeightMethod = "GetVideoHeight";
		private const string GetDurationStringMethod = "GetDurationString";
		private const string GetNowFrameRateMethod = "GetNowFrameRate";
		private const string GetFrameRateMethod = "GetFrameRate";
		private const string GetNowBitRateMethod = "GetNowBitRate";
		private const string GetBitRateMethod = "GetBitRate";
		private const string EnableGpuMethod = "EnableGpu";
		private const string EnableRtmpMethod = "EnableRtmp";
		private const string SetBufferTimeMethod = "SetBufferTime";
		private const string SetBufferTimeMaxMethod = "SetBufferTimeMax";
		private const string ShowDebugMethod = "ShowDebug";

		public FlashMoviePlayerManager(AxShockwaveFlash flash)
		{
			this.flash = flash;

			flash.FlashCall += ExternalCall;
		}

		/// <summary>
		/// Call from Flash
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExternalCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
		{
			var doc = new XmlDocument();
			doc.Load(new StringReader(e.request));
			var methodName = doc.SelectSingleNode("invoke").Attributes["name"].Value;
			var nodes = doc.SelectSingleNode("invoke/arguments").ChildNodes;
			var args = new List<string>();
			foreach (XmlElement arg in nodes)
			{
				args.Add(arg.InnerText);
			}

			switch (methodName)
			{
				case "OpenStateChange":
					openStateChange(flash, new EventArgs());
					break;
				case "Initialized":
					initialized(flash, new EventArgs());
					break;
				case "RequestBump":
					requestBump(flash, new EventArgs());
					break;
				case "OutputLog":
					outputLog(flash, args.FirstOrDefault());
					break;
			}
		}

		public event EventHandler Initialized
		{
			add { initialized += value; }
			remove { initialized -= value; }
		}

		event EventHandler initialized = delegate { }; 

		public event EventHandler OpenStateChange
		{
			add { openStateChange += value; }
			remove { openStateChange -= value; }
		}
		event EventHandler openStateChange = delegate { };

		public event EventHandler RequestBump
		{
			add { requestBump += value; }
			remove { requestBump -= value; }
		}
		private event EventHandler requestBump = delegate { };

		private void outputLog(AxShockwaveFlash flash, string message)
		{
			Logger.Instance.Debug("[FLASH] - " + message);
		}

		/// <summary>
		/// Video playback
		/// </summary>
		/// <param name="streamUrl">Stream URL</param>
		public void PlayVideo(string streamUrl)
		{
			CallFlashMethod(PlayVideoMethod, streamUrl);
		}

		/// <summary>
		/// Reconnect
		/// </summary>
		public void Retry()
		{
			CallFlashMethod(RetryMethod);
		}

		/// <summary>
		/// Volume change
		/// </summary>
		/// <param name="volume">volume</param>
		public void ChangeVolume(double volume)
		{
			CallFlashMethod(ChangeVolumeMethod, (volume / 100).ToString());
		}

		/// <summary>
		/// Volume balance change
		/// </summary>
		/// <param name="pan">Volume balance</param>
		public void ChangePan(double pan)
		{
			CallFlashMethod(ChangePanMethod, (pan / 100).ToString());
		}

		/// <summary>
		/// Get vertical size
		/// </summary>
		public int GetVideoWidth()
		{
			int result;
			int.TryParse(CallFlashMethod(GetVideoWidthMethod), out result);
			return result;
		}

		/// <summary>
		/// Get horizontal size
		/// </summary>
		public int GetVideoHeight()
		{
			int result;
			int.TryParse(CallFlashMethod(GetVideoHeightMethod), out result);
			return result;
		}

		/// <summary>
		/// Get play time
		/// </summary>
		/// <returns></returns>
		public string GetDurationString()
		{
			return CallFlashMethod(GetDurationStringMethod);
		}

		/// <summary>
		/// Get the current frame rate
		/// </summary>
		public int GetNowFrameRate()
		{
			int result;
			int.TryParse(CallFlashMethod(GetNowFrameRateMethod), out result);
			return result;
		}

		/// <summary>
		/// Get frame rate
		/// </summary>
		/// <returns></returns>
		public int GetFrameRate()
		{
			int result;
			int.TryParse(CallFlashMethod(GetFrameRateMethod), out result);
			return result;
		}

		/// <summary>
		/// Get the current bitrate
		/// </summary>
		/// <returns></returns>
		public int GetNowBitRate()
		{
			int result;
			int.TryParse(CallFlashMethod(GetNowBitRateMethod), out result);
			return result;
		}

		/// <summary>
		/// Get bitrate
		/// </summary>
		/// <returns></returns>
		public int GetBitRate()
		{
			int result;
			int.TryParse(CallFlashMethod(GetBitRateMethod), out result);
			return result;
		}

		public void EnableGpu(bool gpu)
		{
			CallFlashMethod(EnableGpuMethod, gpu.ToString());
		}

		/// <summary>
		/// Whether to use RTMP playback
		/// </summary>
		public void EnableRtmp(bool rtmp)
		{
			CallFlashMethod(EnableRtmpMethod, rtmp.ToString());
		}

		/// <summary>
		/// Set the buffering time
		/// </summary>
		/// <param name="bufferTime"></param>
		public void SetBufferTime(double bufferTime)
		{
			CallFlashMethod(SetBufferTimeMethod, bufferTime.ToString());
		}

		/// <summary>
		/// Set the buffering time
		/// </summary>
		/// <param name="bufferTimeMax"></param>
		public void SetBufferTimeMax(double bufferTimeMax)
		{
			CallFlashMethod(SetBufferTimeMaxMethod, bufferTimeMax.ToString());
		}

		/// <summary>
		/// Display video information
		/// </summary>
		public void ShowDebug()
		{
			CallFlashMethod(ShowDebugMethod);
		}

		/// <summary>
		/// Execute a Flash function
		/// </summary>
		/// <param name="methodName"> Method name</param>
		/// <param name="param">Argument </param>
		private void CallFlashMethod(string methodName, string param)
		{
			if (flash.FrameLoaded(0))
			{
				var request = new XElement("invoke",
					new XAttribute("name", methodName),
					new XAttribute("returntype", "xml"),
						new XElement("arguments",
							new XElement("string", param)
						)
				);

				try
				{
					flash.CallFunction(request.ToString(SaveOptions.DisableFormatting));
				}
				catch (COMException)
				{
				}
			}
		}

		/// <summary>
		/// Execute a Flash function
		/// </summary>
		/// <param name="methodName">Method name</param>
		/// <param name="parameters">argument</param>
		private string CallFlashMethod(string methodName, params object[] parameters)
		{
			if (flash.FrameLoaded(0))
			{
				var request = new XElement("invoke",
					new XAttribute("name", methodName),
					new XAttribute("returntype", "xml"),
					new XElement("arguments",
						from param in parameters
						select new XElement("string", param.ToString())
					)
				);

				try
				{
					return CleanStringTag(flash.CallFunction(request.ToString(SaveOptions.DisableFormatting)));
				}
				catch (COMException)
				{
				}
			}
			return "";
		}

		private string CleanStringTag(string text)
		{
			return text.Replace("<string>", "").Replace("</string>", "");
		}
	}
}
