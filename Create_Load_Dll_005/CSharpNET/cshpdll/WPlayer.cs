using RGiesecke.DllExport;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//https://docs.microsoft.com/en-us/dotnet/
namespace cshpdll
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer
    {
        [return: MarshalAs(UnmanagedType.I4)]
        int IAdd();
        int IPlus(int a, int b);
        void ISayHello(string a, string b);
        void IShowSWFPanelWithPath(string fpath);
        void IShowSWFPanel();
        void IShowGallery();
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

        [DllExport]
        public static int Min(int X, int Y)
        {
            //MessageBox.Show(String.Format("cshpdll > Receive: Min({0}, {1})", X, Y), "CSharp MessageBox:");
            return Math.Min(X, Y);
        }

        [DllExport]
        public static int Max(int X, int Y) => Math.Max(X, Y);


        [DllExport]
        //public static void ShowMsgBox(String msg) => MessageBox.Show(msg, "CSharp MessageBox:");
        //public static void ShowMsgBox([MarshalAs(UnmanagedType.LPStr)] string msg) =>  MessageBox.Show(msg, "CSharp MessageBox:");
        public static void ShowMsgBox(IntPtr msg) => MessageBox.Show(Marshal.PtrToStringAnsi(msg), "CSharp MessageBox:");

        [DllExport]
        public static string CombineStrings([MarshalAs(UnmanagedType.LPStr)] string a, [MarshalAs(UnmanagedType.LPStr)] string b) {
            MessageBox.Show(String.Format("CombineStrings > a:{0} b:{1}", a, b), "CSharp MessageBox:");
            return a + " " + b;
        }

        [DllExport]
        public static void ShowGalleryPanel() => new ImageGalleryForm().Show();

        [DllExport]
        public static void ShowSWFPanel() => new WLoader().Show();

        [DllExport]
        public static void ShowSWFPanelWithPath(string fpath) => new WLoader().LoadFile(fpath);

        // Private Variables 
        private readonly int NumberOne = 4;
        private readonly int NumberTwo = 5;
        // Public Methods
        public int IAdd() => NumberOne + NumberTwo;
        public int IPlus(int a, int b) => a + b;
        public void ISayHello(string a, string b) => MessageBox.Show(a +" "+ b + "!", "CSharp MessageBox:");
        public void IShowGallery() => new ImageGalleryForm().Show();
        public void IShowSWFPanel() => new WLoader().Show();
        public void IShowSWFPanelWithPath(string fpath) {

            WLoader wl = new WLoader();
            wl.LoadFile(fpath);
            wl.Show();
        }
    }
}

// TODO fix text transfer Delphi <> Csharp
//.Replace("'", "\"")


/*
 9

After massive investigation I found the solution: it's all about registration parameters. The flag /codebase must be added to the regasm command.

Many posts out there suggest to use Guid and other COM attributes on the C# Com exposed object, I managed to deliver COM functionality using the ComVisible(true) attribute and regasm /tlb /codebse command.

The code:

[Guid("7DEE7A79-C1C6-41E0-9989-582D97E0D9F2")]
[ComVisible(true)]
public class ServicesTester
{
    public ServicesTester()
    {
    }

    //[ComVisible(true)]
    public void TestMethod()
    {
        MessageBox.Show("You are in TestMEthod Function");
    }
}
and as I mentioned I used regasm.exe /tlb /codebase to register it
 */