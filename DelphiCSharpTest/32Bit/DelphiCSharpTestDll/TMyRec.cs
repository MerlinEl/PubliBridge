using System;
using System.Runtime.InteropServices;

namespace DelphiCSharpTestDll {

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 1), Serializable]
    public struct TMyRec {


        [MarshalAs(UnmanagedType.LPWStr)] public string str1;
        [MarshalAs(UnmanagedType.LPWStr)] public string str2;
        //public CharPtr str1;
        //public CharPtr str2;
        public int int1;
        public int int2;
        public Double dbl1;
        public Double dbl2;
        public bool bool1;
        public bool bool2;
    }
}
