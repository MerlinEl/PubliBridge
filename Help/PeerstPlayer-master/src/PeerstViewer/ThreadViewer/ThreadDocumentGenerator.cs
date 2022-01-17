﻿
using PeerstLib.Bbs;
using PeerstLib.Bbs.Data;
using PeerstLib.Util;
using System;
using System.IO;
using System.Text;
namespace PeerstViewer.ThreadViewer
{
	/// <summary>
	/// スレッドドキュメントの生成クラス
	/// </summary>
	class ThreadDocumentGenerator
	{
		private const string FooterFileName = "Footer.html";
		private const string HeaderFileName = "Header.html";
		private const string NewResFileName = "NewRes.html";
		private const string PopupResFileName = "PopupRes.html";
		private const string ResFileName = "Res.html";
		private const string NewMarkFileName = "NewMark.html";

		private string FooterText = string.Empty;
		private string HeaderText = string.Empty;
		private string NewResText = string.Empty;
		private string PopupResText = string.Empty;
		private string ResText = string.Empty;
		private string NewMarkText = string.Empty;

		/// <summary>
		/// スキンのフォルダパス
		/// </summary>
		private string skinFolderPath = string.Empty;

		public ThreadDocumentGenerator(string skinFolderPath)
		{
			Logger.Instance.DebugFormat("ThreadDocumentGenerator[skinFolderPath:{0}]", skinFolderPath);
			this.skinFolderPath = skinFolderPath;
			ReadSkin(skinFolderPath);
		}

		/// <summary>
		/// スキンファイルの読み込み
		/// </summary>
		public void ReadSkin(string skinFolderPath)
		{
			Logger.Instance.DebugFormat("ReadSkin[skinFolderPath:{0}]", skinFolderPath);
			FooterText = ReadFile(Path.Combine(skinFolderPath, FooterFileName));
			HeaderText = ReadFile(Path.Combine(skinFolderPath, HeaderFileName));
			NewResText = ReadFile(Path.Combine(skinFolderPath, NewResFileName));
			PopupResText = ReadFile(Path.Combine(skinFolderPath, PopupResFileName));
			ResText = ReadFile(Path.Combine(skinFolderPath, ResFileName));
			NewMarkText = ReadFile(Path.Combine(skinFolderPath, NewMarkFileName));
		}

		/// <summary>
		/// ファイル読み込み
		/// </summary>
		private string ReadFile(string filePath)
		{
			Logger.Instance.DebugFormat("ReadFile[filePath:{0}]", filePath);
			string text;
			using (StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("Shift_JIS")))
			{
				text = sr.ReadToEnd();
				return text;
			}
		}

		/// <summary>
		/// ドキュメント生成
		/// </summary>
		public string Generate(OperationBbs operationBbs, int oldResNum)
		{
			Logger.Instance.DebugFormat("Generate[oldResNum:{0}]", oldResNum);

			// ヘッダー追加
			string documentText = ReplaceData(HeaderText, operationBbs);

			foreach (var res in operationBbs.ResList)
			{
				string resText = string.Empty;
				int resNo = 0;
				int.TryParse(res.ResNo, out resNo);

				if (resNo == oldResNum + 1)
				{
					resText = ReplaceResData(NewMarkText, res);
				}

				if (resNo <= oldResNum)
				{
					resText += ReplaceResData(ResText, res);
				}
				else
				{
					resText += ReplaceResData(NewResText, res);
				}

				documentText += ReplaceData(resText, operationBbs);
				documentText += Environment.NewLine;
			}

			// フッター追加
			documentText += ReplaceData(FooterText, operationBbs);

			return documentText;
		}

		/// <summary>
		/// レスデータの置換
		/// </summary>
		private static string ReplaceResData(string documentText, ResInfo res)
		{
			return documentText
				.Replace("<NUMBER/>", res.ResNo)
				.Replace("<PLAINNUMBER/>", res.ResNo)
				.Replace("<NAME/>", res.Name.Replace("<b>", ""))
				.Replace("<MAILNAME/>", string.Format("{0} : {1}", res.Mail, res.Name))
				.Replace("<MAIL/>", res.Mail)
				.Replace("<DATE/>", res.Date)
				.Replace("<MESSAGE/>", res.Message)
				.Replace("<ID/>", res.Id);
		}

		/// <summary>
		/// 特殊文字列の置換
		/// </summary>
		private string ReplaceData(string documentText, OperationBbs operationBbs)
		{
			return documentText
				.Replace("<THREADNAME/>", operationBbs.SelectThread.ThreadTitle)
				.Replace("<THREADURL/>", operationBbs.ThreadUrl)
				.Replace("<SKINPATH/>", skinFolderPath)
				.Replace("<GETRESCOUNT/>", 0.ToString())
				.Replace("<NEWRESCOUNT/>", operationBbs.ResList.Count.ToString())
				.Replace("<ALLRESCOUNT/>", operationBbs.ResList.Count.ToString())
				.Replace("<BBSNAME/>", operationBbs.BbsInfo.BbsName)
				.Replace("<BOARDNAME/>", operationBbs.BbsInfo.BbsName)
				.Replace("<BOARDURL/>", operationBbs.BoardUrl);
		}
	}
}
