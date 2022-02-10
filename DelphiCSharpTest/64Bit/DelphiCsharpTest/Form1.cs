using DelphiCSharpTestDll;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DelphiCsharpTest {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            TestSize();
            //TestVarsStatic();
            //TestVarsInstance();
        }

        private unsafe void TestSize() {
            //    var r = typeof(TMyRec);
            var rec = new TMyRec();
            
            //Log("rec: " + Marshal.SizeOf(r).ToString());
            //Log("rec: " + Marshal.SizeOf(typeof(TMyRec)).ToString());
            //Log("bool size: " + sizeof(bool).ToString());
            //Log("bool size: " + sizeof(typeof(rec.str1)).ToString());

        }

        private void TestVarsInstance() {
            
            DelphiTest inst = new DelphiTest();
            DelphiTest.GetInstance(ref inst);
            //inst.SayHello("Rene");

            var rec = new TMyRec {
                int1 = 1,
                int2 = 2
            };

            Log("Instance Delphi >" + Environment.NewLine + "\tRecord Send: ");
            Log("\t\tint1:" + rec.int1);
            Log("\t\tint2:" + rec.int2);

            var rec2 = inst.ModifyRecord(rec);

            Log("\tRecord Get: ");
            Log("\t\tint1:" + rec2.int1);
            Log("\t\tint2:" + rec2.int2);
        }

        private void Log(string str) => Label1.AppendText(Environment.NewLine + str);

        private void TestVarsStatic() {

            var rec = new TMyRec {
                int1 = 1,
                int2 = 2
            };

            Log("Static Delphi  >"+Environment.NewLine+"\tRecord Send: ");
            Log("\tint1:" + rec.int1);
            Log("\tint2:" + rec.int2);

            var rec2 = DelphiTest.TestVal(rec);

            Log("\tRecord Get: ");
            Log("\tint1:" + rec2.int1);
            Log("\tint2:" + rec2.int2);
        }

        //private unsafe void TestVars() {
        //    var r = typeof(TMyRec);
        //    Log("rec: " + Marshal.SizeOf(r).ToString());
        //    Log("rec: " + sizeof(TMyRec).ToString());
        //}

        //[DllExport]
        //public static TMyRec TestVal(TMyRec rec) {

        //    Log(" Delphi Record: ");
        //    Log("\tstr1:" + rec.str1);
        //    Log("\tstr2:" + rec.str2);
        //    Log("\tint1:" + rec.int1);
        //    Log("\tint2:" + rec.int2);
        //    Log("\tdbl1:" + rec.dbl1);
        //    Log("\tdbl2:" + rec.dbl2);
        //    Log("\tbool1:" + rec.bool1);
        //    Log("\tbool2:" + rec.bool1);

        //    rec.str1 = Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(rec.str1) + "a");
        //    rec.str2 = Marshal.StringToHGlobalUni(Marshal.PtrToStringUni(rec.str1) + "b");
        //    rec.int1 += 10;
        //    rec.int2 += 20;
        //    rec.dbl1 += 0.5;
        //    rec.dbl2 += 1.2;
        //    rec.bool1 = !rec.bool1;
        //    rec.bool2 = !rec.bool2;
        //    return rec;
        //}
    }
}
