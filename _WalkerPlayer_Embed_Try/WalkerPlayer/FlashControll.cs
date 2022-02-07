using AxWalkerPlayer;
// flash controll extension
namespace WalkerPlayer {
    public class FlashControll : System.Windows.Forms.AxHost {

        private WalkerPlayer.IShockwaveFlash ocx;

        private AxShockwaveFlashEventMulticaster eventMulticaster;

        private System.Windows.Forms.AxHost.ConnectionPointCookie cookie;

        public FlashControll(string clsid) : base(clsid) {


        }
    }
}
