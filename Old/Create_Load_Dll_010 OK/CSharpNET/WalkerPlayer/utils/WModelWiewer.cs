using System.Linq;
using System.Windows.Forms;
using WalkerPlayerConsole;

namespace WalkerPlayer.utils {
    class WModelWiewer {
        /// <summary>
        /// Play 3D Models in FLWindow (flWindow WMode must be Direct)
        /// </summary>
        internal static void LoadModel(AxShockwaveFlashObjects.AxShockwaveFlash flWindow, string rootDir, string[] paramsList) {

            string modelPath = rootDir + "/" + paramsList[0]; // relative path to 3d model: 3d/model.swf
            string[] buttonsList = paramsList[1].Split(','); // "zoom,scale,paly,..."
            string displayMode = paramsList[2]; // "FULL_SCREEN" or "IN_WINDOW"
            string displayTM = paramsList[3]; // "x,y,width,height"
            WPGlobal.Log("CSharp", "WPlayerForm > Flash need load Model\n\tmodelPath:{0}\n\tbuttonsList:{1}", modelPath, buttonsList.Join(","));
            flWindow.Visible = true;
            flWindow.Movie = modelPath;
            switch (displayMode) {

                case "FULL_SCREEN":
                    //flWindow.Size = flWindow.Parent.ClientSize;
                    break;
                case "IN_WINDOW":
                    break;
            }
        }
    }
}
