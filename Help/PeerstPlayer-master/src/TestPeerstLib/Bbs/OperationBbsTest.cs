﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeerstLib.Bbs.Data;
using PeerstLib.Bbs.Strategy;

namespace TestPeerstLib
{
	[TestClass]
	public class OperationBbsTest
	{
		//-------------------------------------------------------------
		// 確認：指定URLから取得した掲示板名が正しいか確認
		//-------------------------------------------------------------
		[TestMethod]
		public void OperationBbs_UpdateBbsName()
		{
			// 新したらば
			CheckBbsName("http://jbbs.shitaraba.net/game/45037/", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/game/45037", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/game/45037/1286755510/", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/game/45037/1286755510", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/bbs/read.cgi/game/45037", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1286755510/", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1286755510", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1286755510/l50", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1286755510/50", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1286755510/50-", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1286755510/50n-", "シュール・備長炭と愉快な仲間たち");

			// 旧したらば
			CheckBbsName("http://jbbs.livedoor.jp/game/45037/", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/game/45037", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/game/45037/1286755510/", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/game/45037/1286755510", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1286755510/", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1286755510", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1286755510/l50", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1286755510/50", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1286755510/50-", "シュール・備長炭と愉快な仲間たち");
			CheckBbsName("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1286755510/50n-", "シュール・備長炭と愉快な仲間たち");

			// 2ch互換
			//CheckBbsName("http://sepia0330.dyndns.org/eicar/", "これは酷いな避難所BBS");	// TODO 別サーバタイプとする？
			//CheckBbsName("http://sepia0330.dyndns.org/eicar", "これは酷いな避難所BBS");

			// 未対応
			CheckBbsName("", "");
			CheckBbsName("http://bayonet.ddo.jp/sp/", "");
			CheckBbsName("http://bayonet.ddo.jp/sp/xgame.html#xanc_31", "");
			CheckBbsName("http://listeners.reep.info/index.php?%A5%A4%A5%D9%A5%F3%A5%C8%C6%FC%C4%F8/2013-06-01", "");
			CheckBbsName("http://takami98.sakura.ne.jp/peca-navi/turf-page/index.php", "");
			CheckBbsName("http://temp.orz.hm/yp/uptest/", "");
			CheckBbsName("http://twitter.com/twityp", "");
			CheckBbsName("http://www.gamers-review.net/title.php?title=441", "");
		}

		//-------------------------------------------------------------
		// 概要：指定URLから取得した掲示板名と想定結果を確認
		//-------------------------------------------------------------
		private void CheckBbsName(string url, string bbsName)
		{
			BbsStrategy strategy = BbsStrategyFactory.Create(url);
			strategy.UpdateBbsName();
			Assert.AreEqual(bbsName, strategy.BbsInfo.BbsName);
		}

		//-------------------------------------------------------------
		// 概要：レス書き込み確認
		//-------------------------------------------------------------
		[TestMethod]
		public void OperationBbs_Write()
		{
			//-------------------------------------------------------------
			// 新したらば
			//-------------------------------------------------------------

			// TODO 2013/11/24時点ではAPIが対応されていないため、テストに失敗する

			// 正常書き込み
			CheckWrite(true, "http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1310263750/", "シュール", "sage", "message");

			// 時間制限
			CheckWrite(false, "http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1310263750/", "シュール", "sage", "message");

			// 本文なし
			CheckWrite(false, "http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1310263750/", "", "", "");

			// 過去ログ
			CheckWrite(false, "http://jbbs.shitaraba.net/game/43934/1232972032/", "シュール", "sage", "message");

			// 掲示板番号が不正
			CheckWrite(false, "http://jbbs.shitaraba.net/bbs/read.cgi/game/99999/1268147268/", "シュール", "sage", "message");

			// スレッド番号が不正（パラメータ間違い）
			CheckWrite(false, "http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/126814727/", "シュール", "sage", "message");

			// 該当するスレッドは存在しない
			CheckWrite(false, "http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/9999999999/", "シュール", "sage", "message");

			// 1000レス
			CheckWrite(false, "http://jbbs.shitaraba.net/bbs/read.cgi/game/45037/1268147268/", "シュール", "sage", "message");

			//-------------------------------------------------------------
			// 旧したらば
			//-------------------------------------------------------------

			// 正常書き込み
			CheckWrite(true, "http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1310263750/", "シュール", "sage", "message");

			// 時間制限
			CheckWrite(false, "http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1310263750/", "シュール", "sage", "message");

			// 本文なし
			CheckWrite(false, "http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1310263750/", "", "", "");

			// 過去ログ
			CheckWrite(false, "http://jbbs.livedoor.jp/game/43934/1232972032/", "シュール", "sage", "message");

			// 掲示板番号が不正
			CheckWrite(false, "http://jbbs.livedoor.jp/bbs/read.cgi/game/99999/1268147268/", "シュール", "sage", "message");

			// スレッド番号が不正（パラメータ間違い）
			CheckWrite(false, "http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/126814727/", "シュール", "sage", "message");

			// 該当するスレッドは存在しない
			CheckWrite(false, "http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/9999999999/", "シュール", "sage", "message");

			// 1000レス
			CheckWrite(false, "http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1268147268/", "シュール", "sage", "message");

			//-------------------------------------------------------------
			// 2ch互換
			//-------------------------------------------------------------
			/*
			CheckWrite(true, "http://sepia0330.dyndns.org/test/read.cgi/eicar/1307720374/", "", "sage", "test");
			*/
			
			//-------------------------------------------------------------
			// 未対応
			//-------------------------------------------------------------

			CheckWrite(false, "", "test", "sage", "message");
			CheckWrite(false, "http://bayonet.ddo.jp/sp/", "test", "sage", "message");
			CheckWrite(false, "http://bayonet.ddo.jp/sp/xgame.html#xanc_31", "test", "sage", "message");
			CheckWrite(false, "http://listeners.reep.info/index.php?%A5%A4%A5%D9%A5%F3%A5%C8%C6%FC%C4%F8/2013-06-01", "test", "sage", "message");
			CheckWrite(false, "http://takami98.sakura.ne.jp/peca-navi/turf-page/index.php", "test", "sage", "message");
			CheckWrite(false, "http://temp.orz.hm/yp/uptest/", "test", "sage", "message");
			CheckWrite(false, "http://twitter.com/twityp", "test", "sage", "message");
			CheckWrite(false, "http://www.gamers-review.net/title.php?title=441", "test", "sage", "message");
		}

		//-------------------------------------------------------------
		// 概要：レス書き込みの想定結果確認
		//-------------------------------------------------------------
		private void CheckWrite(bool result, string url, string name, string mail, string text)
		{
			BbsStrategy strategy = BbsStrategyFactory.Create(url);
			try
			{
				strategy.Write(name, mail, text);
			}
			catch
			{
				if (result)
				{
					Assert.Fail(string.Format("書き込みに失敗しました。\nname:{0}\nmail:{1}\ntext:{2}", name, mail, text));
				}
				return;
			}

			if (!result)
			{
				Assert.Fail(string.Format("スローされませんでした。\nname:{0}\nmail:{1}\ntext:{2}", name, mail, text));
			}
		}

		//-------------------------------------------------------------
		// 確認：掲示板設定の取得確認
		//-------------------------------------------------------------
		[TestMethod]
		public void BbsStrategyTest_UpdateBbsSetting()
		{
			var strategy = BbsStrategyFactory.Create("http://jbbs.shitaraba.net/game/45037/");
			strategy.UpdateBbsSetting();
			Assert.AreEqual(strategy.BbsInfo.Setting["BBS"], "45037");
			Assert.AreEqual(strategy.BbsInfo.Setting["CATEGORY"], "ゲーム/囲碁/将棋");
			Assert.AreEqual(strategy.BbsInfo.Setting["TOP"], "http://jbbs.shitaraba.net/game/45037/");
		}

		//-------------------------------------------------------------
		// 確認：掲示板一覧の取得確認
		//-------------------------------------------------------------
		[TestMethod]
		public void BbsStrategyTest_AnalyzeSubjectText()
		{
			BbsStrategy strategy = new ShitarabaBbsStrategy(new BbsInfo { });
			PrivateObject accessor = new PrivateObject(strategy);
			List<ThreadInfo> threadList = (List<ThreadInfo>)accessor.Invoke("AnalyzeSubjectText", new object[] { SubjectText.Replace("\r\n", "\n").Split('\n') });

			// スレッド一覧数のチェック
			Assert.AreEqual(threadTitleList.Length, threadList.Count);

			for (int i = 0; i < threadList.Count; i++)
			{
				Assert.AreEqual(threadNoList[i], threadList[i].ThreadNo);
				Assert.AreEqual(threadTitleList[i], threadList[i].ThreadTitle);
				Assert.AreEqual(resCountList[i], threadList[i].ResCount);
				// TODO レス勢い取得：未実装 Assert.AreEqual(threadNoList[i], threadList[i].ThreadSpeed);
			}
		}

		#region テストデータ
		string SubjectText = @"1367939035.cgi,毒ｃｈ6(22)
1286755510.cgi,PeerstPlayer総合スレ３(680)
1350051999.cgi,毒ｃｈ5(1000)
1362306973.cgi,【すんごくいいよ】ちなみに何のシュールch76【リリースしてこ】(56)
1352127309.cgi,【qwebview.html】当たり前だろ！シュールch75【流行らない・・】(1000)
1355824176.cgi,17ch(11)
1355658044.cgi,◆Map1e3XIx. だよ～ん！1355655961(1)
1345901480.cgi,【へーい彼女】早く寝ないとシュールch74【箱○】(1000)
1275728367.cgi,17chサミタ進出(1000)
1323941313.cgi,毒ｃｈ4(1000)
1305550104.cgi,備長炭73(466)
1333880462.cgi,しっかりシュールｃｈ＠花見 73(1000)
1345388758.cgi,しっかりシュールｃｈ避難所(1)
1340716570.cgi,てｓｔ(3)
1315052535.cgi,【3項演算子は時々使う】ラクダ式シュールch72【中村光一】(1000)
1271120868.cgi,PeerstPlayer要望・バグ報告スレ(84)
1305481327.cgi,毒ｃｈ3(1000)
1322791673.cgi,このゲームで最強の国作ろうずｗｗｗｗｗｗｗ(1)
1314363306.cgi,【おっぱい】ケツマンコシュールch71【(*‘ω‘ *)】(1000)
1300706900.cgi,【愉快な家族】フライパンは？？シュールch70【ある意味企画通り】(1000)
1310263750.cgi,PeerstPlayer テストスレ(5)
1224956379.cgi,NyankoR ch(539)
1291373749.cgi,備長炭72(1000)
1282898727.cgi,毒ｃｈ2(1000)
1281290179.cgi,【ばっふぁやべぇわ】ごめんシュールch69【詳しくないのであれだが】(1000)
1273468521.cgi,シャクレ73cm(30)
1282394871.cgi,リーシェch 28匹目のイヌ(860)
1286113908.cgi,備長炭71(1000)
1268147268.cgi,PeerstPlayer総合スレ２(1000)
1277634960.cgi,備長炭70(1000)
1221288855.cgi,毒ｃｈ(1000)
1278475349.cgi,リーシェch 27発目のFB(1000)
1278684875.cgi,【ホワイトアウト】今度こそ恋！！！シュールch68【助かりますー】(1000)
1277191342.cgi,【ソースって自作？】今日も元気だシュールch67【股間が熱い】(1000)
1276308171.cgi,リーシェch 26回目のRTA(1000)
1273486417.cgi,備長炭69(1000)
1274012933.cgi,【青姦は】もっとつっこめシュールch66【シリの穴】(1000)
1271125295.cgi,PeerstPlayerツール妄想スレ(16)
1271266845.cgi,リーシェch 25度目の全滅(1000)
1268733406.cgi,17ch(1000)
1273468497.cgi,シャクレ72cm(1000)
1272265821.cgi,【シュールがうんこなのは】ヴァッシュールch65【俺のPCのせいね】(1000)
1269940371.cgi,備長炭68(1000)
1262628141.cgi,シャクレ71cm(1000)
1269785225.cgi,シャクレ71cm(1000)
1271226435.cgi,【一応間に合った】ウイング付きシュールch64【でも少し漏れた】(1000)
1269521054.cgi,リーシェch 24回目のマロール(1000)
1270049434.cgi,【イカ臭い】LO大好きシュールch63片栗粉X【ドラッグストア　モリ】(1000)
1262873550.cgi,【てんが】ライトホモシュールch62【初体験】(1000)
1268143305.cgi,備長炭67(1000)
1262628058.cgi,ツャクレ70cm(1000)
1268568428.cgi,リーシェch 23回目のデュマピック(1000)
1267515207.cgi,17ｃｈ2スレ目(1000)
1266403289.cgi,リーシェch 22回目の就活(1000)
1259968638.cgi,PeerstPlayer総合スレ(1000)
1266590338.cgi,備長炭66(1000)
1262628007.cgi,シャクレ69cm(1000)
1241542445.cgi,17ｃｈ1スレ目(1000)
1265038630.cgi,備長炭y65(1000)
1265560484.cgi,リーシェch 21回目の乱入(1000)
1262627977.cgi,シャクレch　ドナルドTAで68分(1000)
1263900407.cgi,リーシェch 20回目のサクリファイス(1000)
1264491279.cgi,備長炭64(1000)
1262846405.cgi,備長炭63(1000)
1263544675.cgi,リーシェch 19回目の閃き(1000)
1263310068.cgi,リーシェch 18回目のおつかい(1000)
1263026017.cgi,リーシェch 17回目の閃き(1000)
1261849073.cgi,リーシェch Epi16(1000)
1261648600.cgi,【おいアゴチンコ】アッーシュールch61【メリークルシミマス】(1000)
1261064749.cgi,備長炭62(1000)
1262022289.cgi,シャクレ67cm(1000)
1261762152.cgi,シャクレ66cm(1000)
1261790141.cgi,リーシェch　Epi15(1000)
1261623118.cgi,リーシェch その14(1000)
1260360071.cgi,シャクレ65cm(1000)
1255411438.cgi,【クソだったけど】午後どれ選ぶ？シュールch60【擬似言語死ねｗｗ】(1000)
1259130807.cgi,リーシェch その13(1000)
1260540956.cgi,備長炭61(1000)
1259941084.cgi,備長炭60(1000)
1259749826.cgi,64万里(1000)
1259310976.cgi,備長炭59(1000)
1259163260.cgi,63番目の顎(1000)
1258903004.cgi,備長炭58(1000)
1258815983.cgi,62って素敵な数字だよね、まるでシャクレのようだ。(1000)
1256904726.cgi,リーシェch その12(1000)
1258875370.cgi,備長炭57(1000)
1258546090.cgi,備長炭56(1000)
1257609066.cgi,シャックレ60cm(1000)
1257658502.cgi,備長炭55(1000)
1257609045.cgi,シャクレ60cm(1000)
1256994450.cgi,備長炭54(1000)
1257169378.cgi,シャクレ59cm(1000)
1253263515.cgi,シャクレ58cm(1000)
1256661731.cgi,備長炭53(1000)
1254539230.cgi,リーシェch 11(1000)
1256191096.cgi,備長炭52(1000)
1255928433.cgi,備長炭51(1000)
1255896831.cgi,備長炭50(1000)
1255758568.cgi,備長炭49(1000)
1255170816.cgi,備長炭48(1000)
1252863598.cgi,【クソゲ学園】ちん子とさせ子とシュールch59【ファックだぴょん♪】(1000)
1254904316.cgi,備長炭47(1000)
1254565590.cgi,備長炭46(1000)
1254034724.cgi,備長炭45(1000)
1251644106.cgi,リーシェch 10(1000)
1254533102.cgi,ちんたらｃｈ　01(9)
1253706948.cgi,備長炭44(1000)
1253251026.cgi,備長炭43(1000)
1252313802.cgi,シャクレ57cm(1000)
1252401858.cgi,備長炭42(1000)
1251261966.cgi,【oiちんこ自重】KEIKOの鼻シュールch58【マルチスレッド化だ！！】(1000)
1250682964.cgi,備長炭41(1000)
1251818000.cgi,シャクレ56cm(1000)
1251297050.cgi,シャクレ55cm(1000)
1250499598.cgi,リーシェch 09(1000)
1251126397.cgi,シャクレ54cm(1000)
1251019643.cgi,【小麦粉】肉買ったシュールch57【ちんこ祭り】(1000)
1250856166.cgi,シャクレ53cm(1000)
1250827157.cgi,【ちんこ】ちんこシュールch56【ちんこ阻止】(1000)
1250175089.cgi,シャクレ52cm(1000)
1250791222.cgi,【歩くガンプラ】しっかりシュールch55【びんちんたん】(1000)
1250760104.cgi,【ちんこ】勃起したシュールch54【まんこ】(1000)
1250062372.cgi,【くそミソ】時にぶっかけるシュールch53【やったねチンコないよ】(1000)
1250663541.cgi,備長炭40(1000)
1247218015.cgi,備長炭39(1000)
1248955681.cgi,リーシェｃｈ 08(1000)
1250160950.cgi,シャクレ51cm(1000)
1249923253.cgi,シャクレ50cm(1000)
1249748674.cgi,【ちんこ】ちんこシュールch52【スペ３であがるとか】(1000)
1249484992.cgi,シャクレ49cm(1000)
1248624884.cgi,【ち○こ花火】菊門は花火みたいなシュールch52【ちんこ】(1000)
1249384543.cgi,シャクレ48cm(1000)
1249039911.cgi,シャクレ47cm(1000)
1217248155.cgi,連絡用スレ(65)
1243420160.cgi,リーシェch 07(1000)
1248694242.cgi,シャクレ46cm(1000)
1248439663.cgi,syakiure45vm(1000)
1247482300.cgi,【配信しよう】今北ちーっすシュールch51【ちんこ】(1000)
1248281793.cgi,シャクレ44cm(1000)
1248186035.cgi,シャクレ43cm(1000)
1247849725.cgi,シャクレ42cm(1000)
1247755741.cgi,シャクレ41cm(1000)
1247663296.cgi,シャクレ40cm(1000)
1247496086.cgi,シャクレ39cm(1000)
1242047726.cgi,isokiriテスト(1000)
1247059082.cgi,シャクレ　小田ちゃんへのアプローチ38回目(1000)
1246177790.cgi,【ちんこ】フリーズシュールch50【ちんこ好きな童貞次長しろ】(1000)
1241399191.cgi,ぶらっく08(294)
1245144482.cgi,備長炭38(1000)
1246549550.cgi,シャクレ37cm(1000)
1246377652.cgi,シャクレ36cm(1000)
1246290546.cgi,シャクレ35cm(1000)
1245862274.cgi,シャクレ34cm(1000)
1245851819.cgi,【レッドエイト】気の利いたシュールch49【終わってるぞｗｗｗ】(1000)
1245668550.cgi,シャクレ33cm(1000)
1245567475.cgi,【とりあえず脱ごうか】魔法少女シュールch48【触手プレイ】(1000)
1245161013.cgi,シャクレ32cm(1000)
1243139810.cgi,【熟れた肉便器】家畜シュールch47【奥さん米屋です】(1000)
1244561288.cgi,シャクレ31cm(1000)
1244539319.cgi,備長炭37(1000)
1244041031.cgi,シャクレ30cm(1000)
1243960555.cgi,備長炭36(1000)
1243174411.cgi,シャクレ　28cm(1000)
1243869724.cgi,備長炭35(1000)
1243052632.cgi,備長炭34(1000)
1231490533.cgi,めぢ　1(134)
1243174397.cgi,シャクレ28cm(1000)
1240828122.cgi,リーシェch 06(1000)
1242392265.cgi,シャクレ27cm(1000)
1242536764.cgi,【ぺこ可愛いよ】エロいのかｋｗｓｋシュールch46【みせてー】(1000)
1240062611.cgi,備長炭33(1000)
1241633793.cgi,【とにかく早いうちに】終わらないシュールch45【はじめられない】(1000)
1241181189.cgi,シャクレ26cm(1000)
1240412787.cgi,【sage】シュールへタレダナシュールch44【age】(1000)
1239472324.cgi,ぶらっく07(1000)
1240331374.cgi,シャクレ25cm(1000)
1238990447.cgi,リーシェch 05(1000)
1239726244.cgi,【プログラムは作業】ぶらっく就職シュールch43【就職は計画的に】(1000)
1239634340.cgi,シャクレ24cm(1000)
1238298720.cgi,備長炭32(1000)
1238594126.cgi,【富樫仕事しろ】マジｷﾁシュールch42【蘇るイナゴ】(1000)
1237818618.cgi,シャクレ23cm(1000)
1225203807.cgi,ぶらっく06(1000)
1232971544.cgi,リーシェch 04(1000)
1238430799.cgi,【シュールが揺れてますよ！】ｹﾞｽﾄ放置シュールch41【ちんこ】(1000)
1237599881.cgi,【マンキン】妊娠シュールch40【キンタマン】(1000)
1237600795.cgi,備長炭31(1000)
1236860630.cgi,シャクレ22ｾﾝﾁﾐｰﾀﾛﾝｸﾞ(1000)
1236142117.cgi,備長炭30(1000)
1236782530.cgi,【おっぱい】えっちなシュールch39【いっぱい】(1000)
1236171980.cgi,シャクレ21cm(1000)
1236261185.cgi,【くぱぁ】ぽんぽん痛いシュールch38【ぬるぬる】(1000)
1236171304.cgi,【かぷっちゅー】漢字も英語も読めないシュールch37【またここかよ】(1000)
1234965644.cgi,シャクレ19cm(1000)
1235411218.cgi,【毀誉褒貶】懐かしのシュールch36【黯然銷魂】(1000)
1235281452.cgi,備長炭29(1000)
1235378863.cgi,【ぬれあわび】チリシュールch35【まんこ】(1000)
1235333808.cgi,【ものまねしとりにいこうぜ】果汁100%シュールch34【クッパ】(1000)
1235076982.cgi,【くぱぁ】ｋｓｋｓｔシュールch(スレ数)【くぱぁびっち】(1000)
1234965628.cgi,アゴ19(1000)
1234080129.cgi,備長炭28(1000)
1234961219.cgi,【○ンコ】歩く猥褻物シュールch32【くぱぁ】(1000)
1234703647.cgi,sシャクレ18cm(1000)
1234624698.cgi,【運打開乙】くぱぁシュールch31【ょぅι゛ょの味方】(1000)
1234391731.cgi,シャクレ17cm(1000)
1234500305.cgi,【ｿﾌﾄｰｸDJしゅーる 】くぱぁｼｭｰﾙch30【バイトあんの？ 】(1000)
1234201522.cgi,【シャクレが義弟】しっかりシュールch29ファック【勝っちゃった♪】(1000)
1234022741.cgi,シャクレ16cm(1000)
1230311748.cgi,【おいしそうな】しっかりシュールch28プログラムできません【がっ】(1000)
1232208027.cgi,【裏白録画】備長炭27【どうして・・・】(1000)
1233666516.cgi,シャクレ15階（笑）(1000)
1232901887.cgi,シャクレ14cm(1000)
1229247430.cgi,リーシェch 03(1000)
1232352756.cgi,シャクレ13cm(1000)
1231857761.cgi,シャクレ12cm(1000)
1231828423.cgi,備長炭２６(1000)
1231690605.cgi,シャクレ11cm(1000)
1228492574.cgi,備長炭２５(1000)
1231253483.cgi,シャクレ10cm(1000)
1230696252.cgi,Frappuccino(3)
1230214358.cgi,シャクレ9cm(1000)
1229872577.cgi,【妹可愛い】しっかりシュールch27ばれるだろ！【シュール派　３％】(1000)
1229866814.cgi,シャクレ8cm(1000)
1229371508.cgi,【やっぱりびっちが】しっかりシュールch26分かってる【おっぱい！】(1000)
1229511837.cgi,シャクレ7cm(1000)
1229168889.cgi,シャクレ6cm(1000)
1228922976.cgi,【二次ロリ好き】しっかりシュールch25自信あるの？【三次興味無い】(1000)
1226659986.cgi,リーシェch 02(1000)
1228755509.cgi,シャクレ5cm(1000)
1228583340.cgi,【前聞いたんだが】しっかりシュールch24大阪人って【･･･ｇｋｒ】(1000)
1228492741.cgi,シャクレ　4cm(1000)
1228316092.cgi,【jetstream】しっかりシュールch23オブジェクト指向【==じゃね？】(1000)
1228316372.cgi,備長炭２４(1000)
1228145849.cgi,シャクレ3cm(1000)
1227515101.cgi,備長炭２３(1000)
1227464037.cgi,【酒】しっかりシュールch22しゃくれ【煙草】(1000)
1227616996.cgi,シャクレ2cm(1000)
1226677319.cgi,シャクレ(1000)
1226233433.cgi,備長炭２２(1000)
1226934136.cgi,【サル頭】しっかりシュールch21(21)【黒縁メガネ】(1000)
1226847530.cgi,【リア充乙】しっかりシュールch20誰に凸るの？【たのしいさんすう】(1000)
1226486978.cgi,【ポ　ラ　ロイド】しっかりシュールch1989【ちんちんお！】(1000)
1220508820.cgi,リーシェch 01(1000)
1226056432.cgi,【くそみそ】しっかりシュールch18歳のテク【アッー！】(1000)
1225613488.cgi,備長炭２１(1000)
1225986448.cgi,【びちょびちょ】シュールch17というのはガセ【にゃんにゃんお】(1000)
1225723544.cgi,【C#厨】しっかりシュールch16はつべｃｈ【にゃんにゃんお！】(1000)
1225510774.cgi,【あげさげ】しっかりシュールch15回生【乳○くっきり】(1000)
1225438006.cgi,備長炭２０(1000)
1225325730.cgi,【勃起した】しっかりシュールch【ロリコンでガチホモ】(1000)
1225355985.cgi,備長炭１９(1000)
1225127599.cgi,備長炭１８(1000)
1225140644.cgi,あかーいはーんてーんきーせまーしょか(1000)
1221288899.cgi,ぶらっく05(1000)
1224781320.cgi,ガビョウ 踏むと痛い(1000)
1224750971.cgi,備長炭１７(1000)
1224424310.cgi,重度の依存症(1000)
1224491816.cgi,備長炭１６(1000)
1221575674.cgi,削除依頼スレ(6)
1224406349.cgi,備長炭１５(1000)
1224266043.cgi,びんたんちゅきちゅき～byしゅーる(1000)
1224373275.cgi,備長炭１４(1000)
1224124466.cgi,備長炭１３(1000)
1224106620.cgi,びんたんすきですbyしゅーる(1000)
1224073186.cgi,備長炭１２(1000)
1223928088.cgi,ｓ(1000)
1223587604.cgi,備長炭１１(1000)
1223758960.cgi,びんちょうたんじゃねーしシュールだし(1000)
1223360092.cgi,スレタイなんてなかった(1000)
1223165977.cgi,備長炭１０(1000)
1222779435.cgi,ベル鯖ってまだ無料なの？(1000)
1222784502.cgi,備長炭９(1000)
1222514593.cgi,備長炭８(1000)
1222357050.cgi,【意味わかーん】しっかしシュールかーん？　４期【親の日】(1000)
1222329030.cgi,備長炭７(1000)
1221970284.cgi,とても】しっかりシュールｃｈ 3期【親（ひと）しい】(1000)
1222073716.cgi,備長炭６(1000)
1221739041.cgi,備長炭５(1000)
1221656410.cgi,【盲腸だから】しっかりシュールch ２期【病室配信】(1000)
1221410021.cgi,備長炭４(1000)
1220200083.cgi,【数々の】しっかりシュールch １期【名言出します】(1000)
1221223442.cgi,備長炭3(1000)
1219772818.cgi,俺が安価を踏む！！！！！！！！　ぶらっく04(1000)
1220816857.cgi,備長炭2(1000)
1220748149.cgi,セシリス＝リンス(65)
1220410832.cgi,備長炭(1000)
1220749552.cgi,みかかch(30)
1220072693.cgi,癌蓄(55)
1219243550.cgi,ぶらっく03(1000)
1218005865.cgi,ぶらっく02(1000)
1216968259.cgi,ぶらっく01(1000)
1367939035.cgi,毒ｃｈ6(22)";

		string[] threadNoList = { 
			"1367939035",
			"1286755510",
			"1350051999",
			"1362306973",
			"1352127309",
			"1355824176",
			"1355658044",
			"1345901480",
			"1275728367",
			"1323941313",
			"1305550104",
			"1333880462",
			"1345388758",
			"1340716570",
			"1315052535",
			"1271120868",
			"1305481327",
			"1322791673",
			"1314363306",
			"1300706900",
			"1310263750",
			"1224956379",
			"1291373749",
			"1282898727",
			"1281290179",
			"1273468521",
			"1282394871",
			"1286113908",
			"1268147268",
			"1277634960",
			"1221288855",
			"1278475349",
			"1278684875",
			"1277191342",
			"1276308171",
			"1273486417",
			"1274012933",
			"1271125295",
			"1271266845",
			"1268733406",
			"1273468497",
			"1272265821",
			"1269940371",
			"1262628141",
			"1269785225",
			"1271226435",
			"1269521054",
			"1270049434",
			"1262873550",
			"1268143305",
			"1262628058",
			"1268568428",
			"1267515207",
			"1266403289",
			"1259968638",
			"1266590338",
			"1262628007",
			"1241542445",
			"1265038630",
			"1265560484",
			"1262627977",
			"1263900407",
			"1264491279",
			"1262846405",
			"1263544675",
			"1263310068",
			"1263026017",
			"1261849073",
			"1261648600",
			"1261064749",
			"1262022289",
			"1261762152",
			"1261790141",
			"1261623118",
			"1260360071",
			"1255411438",
			"1259130807",
			"1260540956",
			"1259941084",
			"1259749826",
			"1259310976",
			"1259163260",
			"1258903004",
			"1258815983",
			"1256904726",
			"1258875370",
			"1258546090",
			"1257609066",
			"1257658502",
			"1257609045",
			"1256994450",
			"1257169378",
			"1253263515",
			"1256661731",
			"1254539230",
			"1256191096",
			"1255928433",
			"1255896831",
			"1255758568",
			"1255170816",
			"1252863598",
			"1254904316",
			"1254565590",
			"1254034724",
			"1251644106",
			"1254533102",
			"1253706948",
			"1253251026",
			"1252313802",
			"1252401858",
			"1251261966",
			"1250682964",
			"1251818000",
			"1251297050",
			"1250499598",
			"1251126397",
			"1251019643",
			"1250856166",
			"1250827157",
			"1250175089",
			"1250791222",
			"1250760104",
			"1250062372",
			"1250663541",
			"1247218015",
			"1248955681",
			"1250160950",
			"1249923253",
			"1249748674",
			"1249484992",
			"1248624884",
			"1249384543",
			"1249039911",
			"1217248155",
			"1243420160",
			"1248694242",
			"1248439663",
			"1247482300",
			"1248281793",
			"1248186035",
			"1247849725",
			"1247755741",
			"1247663296",
			"1247496086",
			"1242047726",
			"1247059082",
			"1246177790",
			"1241399191",
			"1245144482",
			"1246549550",
			"1246377652",
			"1246290546",
			"1245862274",
			"1245851819",
			"1245668550",
			"1245567475",
			"1245161013",
			"1243139810",
			"1244561288",
			"1244539319",
			"1244041031",
			"1243960555",
			"1243174411",
			"1243869724",
			"1243052632",
			"1231490533",
			"1243174397",
			"1240828122",
			"1242392265",
			"1242536764",
			"1240062611",
			"1241633793",
			"1241181189",
			"1240412787",
			"1239472324",
			"1240331374",
			"1238990447",
			"1239726244",
			"1239634340",
			"1238298720",
			"1238594126",
			"1237818618",
			"1225203807",
			"1232971544",
			"1238430799",
			"1237599881",
			"1237600795",
			"1236860630",
			"1236142117",
			"1236782530",
			"1236171980",
			"1236261185",
			"1236171304",
			"1234965644",
			"1235411218",
			"1235281452",
			"1235378863",
			"1235333808",
			"1235076982",
			"1234965628",
			"1234080129",
			"1234961219",
			"1234703647",
			"1234624698",
			"1234391731",
			"1234500305",
			"1234201522",
			"1234022741",
			"1230311748",
			"1232208027",
			"1233666516",
			"1232901887",
			"1229247430",
			"1232352756",
			"1231857761",
			"1231828423",
			"1231690605",
			"1228492574",
			"1231253483",
			"1230696252",
			"1230214358",
			"1229872577",
			"1229866814",
			"1229371508",
			"1229511837",
			"1229168889",
			"1228922976",
			"1226659986",
			"1228755509",
			"1228583340",
			"1228492741",
			"1228316092",
			"1228316372",
			"1228145849",
			"1227515101",
			"1227464037",
			"1227616996",
			"1226677319",
			"1226233433",
			"1226934136",
			"1226847530",
			"1226486978",
			"1220508820",
			"1226056432",
			"1225613488",
			"1225986448",
			"1225723544",
			"1225510774",
			"1225438006",
			"1225325730",
			"1225355985",
			"1225127599",
			"1225140644",
			"1221288899",
			"1224781320",
			"1224750971",
			"1224424310",
			"1224491816",
			"1221575674",
			"1224406349",
			"1224266043",
			"1224373275",
			"1224124466",
			"1224106620",
			"1224073186",
			"1223928088",
			"1223587604",
			"1223758960",
			"1223360092",
			"1223165977",
			"1222779435",
			"1222784502",
			"1222514593",
			"1222357050",
			"1222329030",
			"1221970284",
			"1222073716",
			"1221739041",
			"1221656410",
			"1221410021",
			"1220200083",
			"1221223442",
			"1219772818",
			"1220816857",
			"1220748149",
			"1220410832",
			"1220749552",
			"1220072693",
			"1219243550",
			"1218005865",
			"1216968259",
			// "1367939035", 不要データ
		};

		string[] threadTitleList =
		{
			"毒ｃｈ6",
			"PeerstPlayer総合スレ３",
			"毒ｃｈ5",
			"【すんごくいいよ】ちなみに何のシュールch76【リリースしてこ】",
			"【qwebview.html】当たり前だろ！シュールch75【流行らない・・】",
			"17ch",
			"◆Map1e3XIx. だよ～ん！1355655961",
			"【へーい彼女】早く寝ないとシュールch74【箱○】",
			"17chサミタ進出",
			"毒ｃｈ4",
			"備長炭73",
			"しっかりシュールｃｈ＠花見 73",
			"しっかりシュールｃｈ避難所",
			"てｓｔ",
			"【3項演算子は時々使う】ラクダ式シュールch72【中村光一】",
			"PeerstPlayer要望・バグ報告スレ",
			"毒ｃｈ3",
			"このゲームで最強の国作ろうずｗｗｗｗｗｗｗ",
			"【おっぱい】ケツマンコシュールch71【(*‘ω‘ *)】",
			"【愉快な家族】フライパンは？？シュールch70【ある意味企画通り】",
			"PeerstPlayer テストスレ",
			"NyankoR ch",
			"備長炭72",
			"毒ｃｈ2",
			"【ばっふぁやべぇわ】ごめんシュールch69【詳しくないのであれだが】",
			"シャクレ73cm",
			"リーシェch 28匹目のイヌ",
			"備長炭71",
			"PeerstPlayer総合スレ２",
			"備長炭70",
			"毒ｃｈ",
			"リーシェch 27発目のFB",
			"【ホワイトアウト】今度こそ恋！！！シュールch68【助かりますー】",
			"【ソースって自作？】今日も元気だシュールch67【股間が熱い】",
			"リーシェch 26回目のRTA",
			"備長炭69",
			"【青姦は】もっとつっこめシュールch66【シリの穴】",
			"PeerstPlayerツール妄想スレ",
			"リーシェch 25度目の全滅",
			"17ch",
			"シャクレ72cm",
			"【シュールがうんこなのは】ヴァッシュールch65【俺のPCのせいね】",
			"備長炭68",
			"シャクレ71cm",
			"シャクレ71cm",
			"【一応間に合った】ウイング付きシュールch64【でも少し漏れた】",
			"リーシェch 24回目のマロール",
			"【イカ臭い】LO大好きシュールch63片栗粉X【ドラッグストア　モリ】",
			"【てんが】ライトホモシュールch62【初体験】",
			"備長炭67",
			"ツャクレ70cm",
			"リーシェch 23回目のデュマピック",
			"17ｃｈ2スレ目",
			"リーシェch 22回目の就活",
			"PeerstPlayer総合スレ",
			"備長炭66",
			"シャクレ69cm",
			"17ｃｈ1スレ目",
			"備長炭y65",
			"リーシェch 21回目の乱入",
			"シャクレch　ドナルドTAで68分",
			"リーシェch 20回目のサクリファイス",
			"備長炭64",
			"備長炭63",
			"リーシェch 19回目の閃き",
			"リーシェch 18回目のおつかい",
			"リーシェch 17回目の閃き",
			"リーシェch Epi16",
			"【おいアゴチンコ】アッーシュールch61【メリークルシミマス】",
			"備長炭62",
			"シャクレ67cm",
			"シャクレ66cm",
			"リーシェch　Epi15",
			"リーシェch その14",
			"シャクレ65cm",
			"【クソだったけど】午後どれ選ぶ？シュールch60【擬似言語死ねｗｗ】",
			"リーシェch その13",
			"備長炭61",
			"備長炭60",
			"64万里",
			"備長炭59",
			"63番目の顎",
			"備長炭58",
			"62って素敵な数字だよね、まるでシャクレのようだ。",
			"リーシェch その12",
			"備長炭57",
			"備長炭56",
			"シャックレ60cm",
			"備長炭55",
			"シャクレ60cm",
			"備長炭54",
			"シャクレ59cm",
			"シャクレ58cm",
			"備長炭53",
			"リーシェch 11",
			"備長炭52",
			"備長炭51",
			"備長炭50",
			"備長炭49",
			"備長炭48",
			"【クソゲ学園】ちん子とさせ子とシュールch59【ファックだぴょん♪】",
			"備長炭47",
			"備長炭46",
			"備長炭45",
			"リーシェch 10",
			"ちんたらｃｈ　01",
			"備長炭44",
			"備長炭43",
			"シャクレ57cm",
			"備長炭42",
			"【oiちんこ自重】KEIKOの鼻シュールch58【マルチスレッド化だ！！】",
			"備長炭41",
			"シャクレ56cm",
			"シャクレ55cm",
			"リーシェch 09",
			"シャクレ54cm",
			"【小麦粉】肉買ったシュールch57【ちんこ祭り】",
			"シャクレ53cm",
			"【ちんこ】ちんこシュールch56【ちんこ阻止】",
			"シャクレ52cm",
			"【歩くガンプラ】しっかりシュールch55【びんちんたん】",
			"【ちんこ】勃起したシュールch54【まんこ】",
			"【くそミソ】時にぶっかけるシュールch53【やったねチンコないよ】",
			"備長炭40",
			"備長炭39",
			"リーシェｃｈ 08",
			"シャクレ51cm",
			"シャクレ50cm",
			"【ちんこ】ちんこシュールch52【スペ３であがるとか】",
			"シャクレ49cm",
			"【ち○こ花火】菊門は花火みたいなシュールch52【ちんこ】",
			"シャクレ48cm",
			"シャクレ47cm",
			"連絡用スレ",
			"リーシェch 07",
			"シャクレ46cm",
			"syakiure45vm",
			"【配信しよう】今北ちーっすシュールch51【ちんこ】",
			"シャクレ44cm",
			"シャクレ43cm",
			"シャクレ42cm",
			"シャクレ41cm",
			"シャクレ40cm",
			"シャクレ39cm",
			"isokiriテスト",
			"シャクレ　小田ちゃんへのアプローチ38回目",
			"【ちんこ】フリーズシュールch50【ちんこ好きな童貞次長しろ】",
			"ぶらっく08",
			"備長炭38",
			"シャクレ37cm",
			"シャクレ36cm",
			"シャクレ35cm",
			"シャクレ34cm",
			"【レッドエイト】気の利いたシュールch49【終わってるぞｗｗｗ】",
			"シャクレ33cm",
			"【とりあえず脱ごうか】魔法少女シュールch48【触手プレイ】",
			"シャクレ32cm",
			"【熟れた肉便器】家畜シュールch47【奥さん米屋です】",
			"シャクレ31cm",
			"備長炭37",
			"シャクレ30cm",
			"備長炭36",
			"シャクレ　28cm",
			"備長炭35",
			"備長炭34",
			"めぢ　1",
			"シャクレ28cm",
			"リーシェch 06",
			"シャクレ27cm",
			"【ぺこ可愛いよ】エロいのかｋｗｓｋシュールch46【みせてー】",
			"備長炭33",
			"【とにかく早いうちに】終わらないシュールch45【はじめられない】",
			"シャクレ26cm",
			"【sage】シュールへタレダナシュールch44【age】",
			"ぶらっく07",
			"シャクレ25cm",
			"リーシェch 05",
			"【プログラムは作業】ぶらっく就職シュールch43【就職は計画的に】",
			"シャクレ24cm",
			"備長炭32",
			"【富樫仕事しろ】マジｷﾁシュールch42【蘇るイナゴ】",
			"シャクレ23cm",
			"ぶらっく06",
			"リーシェch 04",
			"【シュールが揺れてますよ！】ｹﾞｽﾄ放置シュールch41【ちんこ】",
			"【マンキン】妊娠シュールch40【キンタマン】",
			"備長炭31",
			"シャクレ22ｾﾝﾁﾐｰﾀﾛﾝｸﾞ",
			"備長炭30",
			"【おっぱい】えっちなシュールch39【いっぱい】",
			"シャクレ21cm",
			"【くぱぁ】ぽんぽん痛いシュールch38【ぬるぬる】",
			"【かぷっちゅー】漢字も英語も読めないシュールch37【またここかよ】",
			"シャクレ19cm",
			"【毀誉褒貶】懐かしのシュールch36【黯然銷魂】",
			"備長炭29",
			"【ぬれあわび】チリシュールch35【まんこ】",
			"【ものまねしとりにいこうぜ】果汁100%シュールch34【クッパ】",
			"【くぱぁ】ｋｓｋｓｔシュールch(スレ数)【くぱぁびっち】",
			"アゴ19",
			"備長炭28",
			"【○ンコ】歩く猥褻物シュールch32【くぱぁ】",
			"sシャクレ18cm",
			"【運打開乙】くぱぁシュールch31【ょぅι゛ょの味方】",
			"シャクレ17cm",
			"【ｿﾌﾄｰｸDJしゅーる 】くぱぁｼｭｰﾙch30【バイトあんの？ 】",
			"【シャクレが義弟】しっかりシュールch29ファック【勝っちゃった♪】",
			"シャクレ16cm",
			"【おいしそうな】しっかりシュールch28プログラムできません【がっ】",
			"【裏白録画】備長炭27【どうして・・・】",
			"シャクレ15階（笑）",
			"シャクレ14cm",
			"リーシェch 03",
			"シャクレ13cm",
			"シャクレ12cm",
			"備長炭２６",
			"シャクレ11cm",
			"備長炭２５",
			"シャクレ10cm",
			"Frappuccino",
			"シャクレ9cm",
			"【妹可愛い】しっかりシュールch27ばれるだろ！【シュール派　３％】",
			"シャクレ8cm",
			"【やっぱりびっちが】しっかりシュールch26分かってる【おっぱい！】",
			"シャクレ7cm",
			"シャクレ6cm",
			"【二次ロリ好き】しっかりシュールch25自信あるの？【三次興味無い】",
			"リーシェch 02",
			"シャクレ5cm",
			"【前聞いたんだが】しっかりシュールch24大阪人って【･･･ｇｋｒ】",
			"シャクレ　4cm",
			"【jetstream】しっかりシュールch23オブジェクト指向【==じゃね？】",
			"備長炭２４",
			"シャクレ3cm",
			"備長炭２３",
			"【酒】しっかりシュールch22しゃくれ【煙草】",
			"シャクレ2cm",
			"シャクレ",
			"備長炭２２",
			"【サル頭】しっかりシュールch21(21)【黒縁メガネ】",
			"【リア充乙】しっかりシュールch20誰に凸るの？【たのしいさんすう】",
			"【ポ　ラ　ロイド】しっかりシュールch1989【ちんちんお！】",
			"リーシェch 01",
			"【くそみそ】しっかりシュールch18歳のテク【アッー！】",
			"備長炭２１",
			"【びちょびちょ】シュールch17というのはガセ【にゃんにゃんお】",
			"【C#厨】しっかりシュールch16はつべｃｈ【にゃんにゃんお！】",
			"【あげさげ】しっかりシュールch15回生【乳○くっきり】",
			"備長炭２０",
			"【勃起した】しっかりシュールch【ロリコンでガチホモ】",
			"備長炭１９",
			"備長炭１８",
			"あかーいはーんてーんきーせまーしょか",
			"ぶらっく05",
			"ガビョウ 踏むと痛い",
			"備長炭１７",
			"重度の依存症",
			"備長炭１６",
			"削除依頼スレ",
			"備長炭１５",
			"びんたんちゅきちゅき～byしゅーる",
			"備長炭１４",
			"備長炭１３",
			"びんたんすきですbyしゅーる",
			"備長炭１２",
			"ｓ",
			"備長炭１１",
			"びんちょうたんじゃねーしシュールだし",
			"スレタイなんてなかった",
			"備長炭１０",
			"ベル鯖ってまだ無料なの？",
			"備長炭９",
			"備長炭８",
			"【意味わかーん】しっかしシュールかーん？　４期【親の日】",
			"備長炭７",
			"とても】しっかりシュールｃｈ 3期【親（ひと）しい】",
			"備長炭６",
			"備長炭５",
			"【盲腸だから】しっかりシュールch ２期【病室配信】",
			"備長炭４",
			"【数々の】しっかりシュールch １期【名言出します】",
			"備長炭3",
			"俺が安価を踏む！！！！！！！！　ぶらっく04",
			"備長炭2",
			"セシリス＝リンス",
			"備長炭",
			"みかかch",
			"癌蓄",
			"ぶらっく03",
			"ぶらっく02",
			"ぶらっく01",
			// "毒ｃｈ6", 不要データ
		};

		int[] resCountList =
		{
			22,
			680,
			1000,
			56,
			1000,
			11,
			1,
			1000,
			1000,
			1000,
			466,
			1000,
			1,
			3,
			1000,
			84,
			1000,
			1,
			1000,
			1000,
			5,
			539,
			1000,
			1000,
			1000,
			30,
			860,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			16,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			9,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			65,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			294,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			134,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			3,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			6,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			1000,
			65,
			1000,
			30,
			55,
			1000,
			1000,
			1000,
			// 22, 不要データ
		};
#endregion


		//-------------------------------------------------------------
		// 確認：スレッドの読み込み
		//-------------------------------------------------------------
		[TestMethod]
		public void BbsStrategyTest_ReadThread()
		{
			BbsStrategy strategy = BbsStrategyFactory.Create("http://jbbs.livedoor.jp/bbs/read.cgi/game/45037/1362306973/");
			PrivateObject accessor = new PrivateObject(strategy);
			List<ThreadInfo> threadList = (List<ThreadInfo>)accessor.Invoke("ReadThread", new object[] { });

			/*
			// スレッド一覧数のチェック
			Assert.AreEqual(threadTitleList.Length, threadList.Count);

			for (int i = 0; i < threadList.Count; i++)
			{
				Assert.AreEqual(threadNoList[i], threadList[i].ThreadNo);
				Assert.AreEqual(threadTitleList[i], threadList[i].ThreadTitle);
				Assert.AreEqual(resCountList[i], threadList[i].ResCount);
				// TODO レス勢い取得：未実装 Assert.AreEqual(threadNoList[i], threadList[i].ThreadSpeed);
			}
			 */
		}
	}
}
