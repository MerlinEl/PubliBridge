using AxShockwaveFlashObjects;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WalkerPlayer.utils;

namespace WalkerPlayer.player {
    class WPWindow {

        public static Size swfStartSize = new Size(1024, 768);
        /*
           switch (options.MediaType) {
                case "AUDIO": flControll.WMode = "Window"; break;
                case "VIDEO": flControll.WMode = "Window"; break;
                case "IMAGES": flControll.WMode = "Window"; break;
                case "LESSONS": flControll.WMode = "Window"; break;
                case "STAGE3D": flControll.WMode = "Direct"; break;
            }
         */
        internal static void SetupPlayer(WPlayerForm wPlayerForm, AxShockwaveFlash flControll, OWPlayer options) {

            string playerPath = WPGlobal.GetPlayerPath(options.BookDir, options.MediaType);
            WPGlobal.Log("CSharp", "WPWindow > SetupPlayer >\n\tRoot Dir:{0}\n\tPlayer Path:{1}", options.BookDir, playerPath);
            if (!File.Exists(playerPath)) throw new FileNotFoundException("This file was not found.\n" + playerPath);
            WPGlobal.Log("CSharp", "\tMedia Path:{0}\n\tButtonId:{1}", options.FileName, options.ButtonID);

            // Setup Flash Component
            flControll.WMode = options.MediaType == "STAGE3D" ? "Direct" : "Window";
            flControll.Location = new Point();
            flControll.Movie = playerPath;
            flControll.Playing = options.AutoPlay;
            wPlayerForm.IsMediaLoaded = true;

            SetupFormWindow(wPlayerForm, flControll, options);
        }

        private static void SetupFormWindow(WPlayerForm wPlayerForm, AxShockwaveFlash flControll, OWPlayer options) {

            WPGlobal.Log("CSharp", "WPWindow > SetupFormWindow >\n\tWindowSize:{0}\n\tWindowPos:{1}", options.WindowSize, options.WindowPos);
            switch (options.WindowSize) {

                case "PLAYERSIZE": // Fit Form to Player Size and Dock Media

                    Size playerSize = new Size(flControll.Width, flControll.Height);
                    if (!playerSize.IsEmpty) {
                        //WPGlobal.Log("CSharp", "\tcontrolSize w:{0} h:{1}", flControll.Width, flControll.Height);
                        swfStartSize = new Size(playerSize.Width, playerSize.Height);
                        wPlayerForm.ClientSize = playerSize;
                        flControll.Dock = DockStyle.Fill;
                        wPlayerForm.FormBorderStyle = options.Resizable ? FormBorderStyle.Sizable : FormBorderStyle.FixedSingle;
                    }
                    break;
                case "FULLSCREEN": // Set Player to FullScreen
                    wPlayerForm.SetFullScreen(true);
                    flControll.Dock = DockStyle.Fill;
                    break;
                default:  // Set Player to custom size
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
