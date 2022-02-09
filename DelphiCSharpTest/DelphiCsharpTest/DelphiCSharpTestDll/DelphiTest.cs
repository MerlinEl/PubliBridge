using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DelphiCSharpTestDll {
    // Interface
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDelphiTest {
        void SayHello(string msg);
        TMyRec ModifyRecord(TMyRec rec);
    }
    // Class
    public class DelphiTest : IDelphiTest {

        [DllExport("TestVal", CallingConvention = CallingConvention.StdCall)]
        public static TMyRec TestVal(TMyRec rec) {

            //rec.str1 = Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(rec.str1) + "a");
            //rec.str2 = Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(rec.str1) + "b");
            rec.int1 = (int)rec.int1 + 10;
            rec.int2 = (int)rec.int2 + 20;
            //rec.dbl1 += 0.5;
            //rec.dbl2 += 1.2;
            //rec.bool1 = !rec.bool1;
            //rec.bool2 = !rec.bool2;
            return rec;
        }

        [DllExport("TestValRef", CallingConvention = CallingConvention.StdCall)]
        public static bool TestValRef(ref TMyRec rec) {

            //rec.str1 = Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(rec.str1) + "a");
            //rec.str2 = Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(rec.str1) + "b");
            rec.int1 = (int)rec.int1 + 10;
            rec.int2 = (int)rec.int2 + 20;
            //rec.dbl1 += 0.5;
            //rec.dbl2 += 1.2;
            //rec.bool1 = !rec.bool1;
            //rec.bool2 = !rec.bool2;
            return true;
        }

        //public static TMyRec TestStr(TMyRec rec) {

        //    rec.str1 = Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(rec.str1) + "a");
        //    rec.str2 = Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(rec.str1) + "b");
        //    return rec;
        //}

        [DllExport("Plus", CallingConvention = CallingConvention.StdCall)]
        public static int Plus(int n) {

            return n + 10;
        }

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref DelphiTest x) {

            x = new DelphiTest(); // create self instance
            return true;
        }

        public void SayHello(string msg) => MessageBox.Show("CSharp say:" + msg);

        public TMyRec ModifyRecord(TMyRec rec) {
            
            rec.int1 += 10;
            rec.int2 += 20;
            return rec;
        }
    }
}

/*

            Form form = new Form1Dll();
            form.Show();
            form.Log(" Delphi Record: ");
            form.Log("\tstr1:" + rec.str1);
            form.Log("\tstr2:" + rec.str2);
            form.Log("\tint1:" + rec.int1);
            form.Log("\tint2:" + rec.int2);
            form.Log("\tdbl1:" + rec.dbl1);
            form.Log("\tdbl2:" + rec.dbl2);
            form.Log("\tbool1:" + rec.bool1);
            form.Log("\tbool2:" + rec.bool1);
 */
