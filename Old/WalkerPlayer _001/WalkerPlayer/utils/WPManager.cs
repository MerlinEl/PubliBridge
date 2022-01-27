using System.Drawing;
using System.Linq;
using WalkerPlayer.bridge;
using WalkerPlayerConsole;

namespace WalkerPlayer.utils {
    class WPManager {
        /// <summary>
        /// Play 3D Models in FLWindow (flWindow WMode must be Direct)
        /// </summary>
        internal static void Load3DProjector(AxShockwaveFlash flWindow3D, string rootDir, string[] paramsList) {

            string modelPath = rootDir + "\\projector.swf";
            string displayMode = paramsList[0]; // "FULL_SCREEN" or "IN_WINDOW"
            string[] displayTM = paramsList[1].Split(','); // "x,y,width,height"
            string modelName = paramsList[2];
            string btnNames = paramsList[3]; // "exit", "zoom", "rotate", "audio"
            WPGlobal.Log("CSharp (WPManager)", "Load3DProjector > Flash need load Model\n\tmodelPath:{0}\n\tmode:{1}\n\twindowTM:\n\t\t{2}", 
                modelPath, displayMode, displayTM.Join("\n\t\t")
            );
            flWindow3D.Visible = true;
            // Load projector only one time
            if (flWindow3D.ReadyState == 0) flWindow3D.Movie = modelPath;
            switch (displayMode) {

                case "FULL_SCREEN":
                    WPGlobal.Log("CSharp (WPManager)", "Load3DProjector > WPlayer.wLoader x:{0} y:{1} w:{2} h:{3}", 
                        WPlayer.wLoader.Bounds.Left,
                        WPlayer.wLoader.Bounds.Top,
                        WPlayer.wLoader.Bounds.Width,
                        WPlayer.wLoader.Bounds.Height
                    );
                    flWindow3D.Bounds = new Rectangle(0,0, WPlayer.wLoader.Bounds.Width, WPlayer.wLoader.Bounds.Height);
                    displayTM = new string[] { "0", "0", WPlayer.wLoader.Bounds.Width.ToString(), WPlayer.wLoader.Bounds.Height.ToString() };
                    break;
                case "IN_WINDOW":
                    //flWindow3D.Bounds = new Rectangle(
                    //    new Point(Int32.Parse(displayTM[0]), Int32.Parse(displayTM[1])), 
                    //    new Size(Int32.Parse(displayTM[2]), Int32.Parse(displayTM[3]))
                    //);
                    break;
            }
            FlashBridge.SendCommand(flWindow3D, new FlashArgsSend( 
                "PROJECTOR3D_UI_READY", 
                "flashProjectorCallback", 
                new string[] { modelName, btnNames, displayTM.Join(",") }
            ));
        }
    }
}
