using AxShockwaveFlashObjects;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WalkerPlayer.utils;
using WalkerPlayerConsole;

namespace WalkerPlayer.player {
    class WPWindow {

        public static Size swfStartSize = new Size(1024, 768);

        internal static void Setup3DPlayer(WPlayerForm wPlayerForm, AxShockwaveFlash flControll, OWPlayer options) {

            flControll.WMode = "Direct";
        }

        internal static void SetupImagePlayer(WPlayerForm wPlayerForm, AxShockwaveFlash flControll, OWPlayer options) {

            string playerPath = options.RootDir + @"\ ImagePlayer.swf";
            WPGlobal.Log("CSharp", "WPWindow > SetupImagePlayer >\n\tRoot Dir:{0}\n\tPlayer Path:{1}", options.RootDir, playerPath);
            if (!File.Exists(playerPath)) throw new FileNotFoundException("This file was not found.\n" + playerPath);
            WPGlobal.Log("CSharp", "\tMedia Path:{0}\n\tLesson:{1}", playerPath, options.FilePath);

            // Setup Flash Component
            flControll.WMode = "Window";
            flControll.Location = new Point();
            flControll.Movie = playerPath;
            flControll.Playing = options.AutoPlay;
            wPlayerForm.IsMediaLoaded = true;

            SetupFormWindow(wPlayerForm, flControll, options);
        }

        internal static void SetupLessonPlayer(WPlayerForm wPlayerForm, AxShockwaveFlash flControll, OWPlayer options) {

            string playerPath = options.RootDir + @"\LessonPlayer.swf";
            WPGlobal.Log("CSharp", "WPWindow > SetupLessonPlayer >\n\tRoot Dir:{0}\n\tPlayer Path:{1}", options.RootDir, playerPath);
            if (!File.Exists(playerPath)) throw new FileNotFoundException("This file was not found.\n" + playerPath);
            WPGlobal.Log("CSharp", "\tMedia Path:{0}\n\tLesson:{1}", playerPath, options.FilePath);

            // Setup Flash Component
            flControll.WMode = "Window";
            flControll.Location = new Point();
            flControll.Movie = playerPath;
            flControll.Playing = options.AutoPlay;
            wPlayerForm.IsMediaLoaded = true;

            SetupFormWindow(wPlayerForm, flControll, options);
        }

        internal static void SetupAudioPlayer(WPlayerForm wPlayerForm, AxShockwaveFlash flControll, OWPlayer options) {

            string playerPath = options.RootDir + @"\AudioPlayer.swf";
            WPGlobal.Log("CSharp", "WPWindow > SetupAudioPlayer >\n\tRoot Dir:{0}\n\tPlayer Path:{1}", options.RootDir, playerPath);
            if (!File.Exists(playerPath)) throw new FileNotFoundException("This file was not found.\n" + playerPath);
            WPGlobal.Log("CSharp", "\tMedia Path:{0}\n\tAudio:{1}", playerPath, options.FilePath);

            // Setup Flash Component
            flControll.WMode = "Window";
            flControll.Location = new Point();
            flControll.Movie = playerPath;
            flControll.Playing = options.AutoPlay;
            wPlayerForm.IsMediaLoaded = true;

            SetupFormWindow(wPlayerForm, flControll, options);
        }

        private static void SetupFormWindow(WPlayerForm wPlayerForm, AxShockwaveFlash flControll, OWPlayer options) {

            switch (options.WindowSize) {

                case "AUTO":
                    flControll.Dock = DockStyle.Fill;
                    // TODO crop form to math controll size
                    //var cropSize = new Size();
                    //if (flControll.Size.Width > wPlayerForm.ClientSize.Width) cropSize.Width = flControll.Size.Width;
                    //if (flControll.Size.Height > wPlayerForm.ClientSize.Height) cropSize.Height = flControll.Size.Height;
                    //wPlayerForm.ClientSize = cropSize;
                    wPlayerForm.FormBorderStyle = options.Resizable ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;

                    break;
                case "FULLSCREEN":
                    wPlayerForm.SetFullScreen(true);
                    flControll.Dock = DockStyle.Fill;
                    break;
                default:  // Set custom size (width, height)
                    Size size = WPString.StringToSize(options.WindowSize);
                    if (size.IsEmpty) return;
                    wPlayerForm.ClientSize = size;
                    flControll.Size = size;
                    swfStartSize = new Size(size.Width, size.Height);
                    wPlayerForm.FormBorderStyle = options.Resizable ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
                    break;
            }

            if (options.WindowPos.Equals("CENTER")) {

                wPlayerForm.CenterWindowToScreen();

            } else { // Set custom position

                Point pos = WPString.StringToPoint(options.WindowPos);
                wPlayerForm.Location = pos;
            }
        }

        //private static void FitWindowToSwfSize(WPlayerForm form, AxShockwaveFlash flControll) {
        //    form.ClientSize = flControll.Size;
        //}

        //private static void FitControllToMediaSize(WPlayerForm form, AxShockwaveFlash flControll, string fpath) {
        //    WPGlobal.Log("CSharp", "WPWindow > LoadFile >\n\tw:{0} h:{1}", flControll.Width, flControll.Height);
        //    try {
        //        SwfParser swfParser = new SwfParser();
        //        Rectangle rectangle = swfParser.GetDimensions(fpath);
        //        Console.WriteLine("\tw:{0} h:{1}", rectangle.Width, rectangle.Height);
        //        swfStartSize = new Size(rectangle.Width, rectangle.Height);
        //        flControll.Width = swfStartSize.Width;
        //        flControll.Height = swfStartSize.Height;
        //        flControll.Location = new Point();
        //        //FitPlayerToProportionallyToWindow(form, flControll);
        //    }
        //    catch (Exception ex) {
        //        WPGlobal.Log("CSharp", "WPWindow > There is a problem with the swf file. " + ex.Message);
        //    }
        //    WPGlobal.Log("CSharp", "\tw:{0} h:{1}", flControll.Width, flControll.Height);
        //}

        //private static void FitPlayerToProportionallyToWindow(WPlayerForm form, AxShockwaveFlash flControll) {
        //    // Obtain form's inner width and height
        //    var maxWidth = form.ClientSize.Width;
        //    var maxHeight = form.ClientSize.Height;
        //    // Fit component to Winfow Form
        //    var ratioX = (double)maxWidth / swfStartSize.Width;
        //    var ratioY = (double)maxHeight / swfStartSize.Height;
        //    var ratio = Math.Min(ratioX, ratioY);
        //    flControll.Width = (int)(swfStartSize.Width * ratio);
        //    flControll.Height = (int)(swfStartSize.Height * ratio);
        //    // Center component to Window Form
        //    flControll.Location = new Point(
        //        (maxWidth - flControll.Width) / 2,
        //        (maxHeight - flControll.Height) / 2
        //    );
        //}

        //private static void SetWindowTransparent(WPlayerForm form) {

        //    form.FormBorderStyle = FormBorderStyle.None;
        //    form.BackColor = Color.FromArgb(125, 125, 125);
        //    form.TransparencyKey = Color.FromArgb(125, 125, 125);
        //}
    }
}

/*
FlashBridge.FlashOptions = options;
AxShockwaveFlash flComponent = CreateFlControll(options);
flComponent.LoadMovie(0, options.FilePath);

FLWindow2D.Menu = false;
FLWindow2D.Loop = false;

FLWindow2D.WMode = "Transparent";
FLWindow2D.BackgroundColor = 0x7D7D7D;
FLWindow2D.FlashVars = "auto_play=true&channel=adventuretimed&start_volume=25";
FLWindow2D.ControlAdded += new EventHandler(OnControlAdded);
FLWindow2D.FSCommand += FlashMovieFSCommand;
FLWindow2D.FlashCall += FlashMovieFlashCall;
FLWindow2D.LoadMovie(0, swf_Path);


if (!options.HiddenPlayer) Show();
if (options.FullScreen) SetFullScreen(true);
if (options.CenterToScreen) CenterToScreen();
if (options.FitToScreen) FitPlayerToMediaSize(options.FilePath);
FLWindow2D.AllowFullScreen = fullScreen ? "true" : "false";
 */
