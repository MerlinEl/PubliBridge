using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//https://docs.microsoft.com/en-us/dotnet/
namespace Walker {
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer
    {
        [return: MarshalAs(UnmanagedType.I4)]
        void ISayHello(string a, string b);
        void LoadFile(string fpath);
        void ShowPlayer();
    }
    public class WPlayer : IWPlayer
    {
        // STATIC PUBLIC METHODS

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref IWPlayer x)
        {
            x = new WPlayer();
            return true;
        }

        public void ISayHello(string a, string b) => MessageBox.Show(a +" "+ b + "!", "CSharp MessageBox:");
        public void ShowPlayer() => new WLoader().Show();
        public void LoadFile(string fpath) {

            WLoader wl = new WLoader();
            wl.LoadFile(fpath);
            wl.Show();
        }
    }
}