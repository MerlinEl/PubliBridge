using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//https://docs.microsoft.com/en-us/dotnet/
namespace cshpdll
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWPlayer
    {
        [return: MarshalAs(UnmanagedType.I4)]
        int Add();
        int Plus(int a, int b);
        string Str(string a, string b);
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
            MessageBox.Show(String.Format("cshpdll > Receive: Min({0}, {1})", X, Y), "CSharp MessageBox:");
            return Math.Min(X, Y);
        }

        [DllExport]
        public static int Max(int X, int Y) => Math.Max(X, Y);

        [DllExport]
        public static void ShowMsgBoxInt(int msg) => MessageBox.Show("Msg len:" + msg, "CSharp MessageBox:");

        [DllExport]
        //public static void ShowMsgBoxStr(String msg) =>  MessageBox.Show(msg, "CSharp MessageBox:");
        //public static void ShowMsgBoxStr([MarshalAs(UnmanagedType.LPStr)] string msg) =>  MessageBox.Show(msg, "CSharp MessageBox:");
        public static void ShowMsgBoxStr(IntPtr msg) => MessageBox.Show(Marshal.PtrToStringAnsi(msg), "CSharp MessageBox:");

        [DllExport]
        public static int SayHello(string userName)
        {

            //return "DLL say: Hello " + userName + "!";
            return userName.Length;
        }

        [DllExport]
        public static void ShowGalleryPanel() => new ImageGalleryForm().Show();

        //[DllExport]
        //public static void ShowSWFPanel() => new SWFLoader().Show();

        // PUBLIC METHODS 

        private int NumberOne = 4;
        private int NumberTwo = 5;
        public int Add()
        {
            return NumberOne + NumberTwo;
        }

        public string Str(string a, string b)
        {
            throw new NotImplementedException();
        }
        public int Plus(int a, int b)
        {
            return a + b;
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