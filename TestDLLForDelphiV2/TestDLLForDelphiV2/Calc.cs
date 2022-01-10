using RGiesecke.DllExport;
using System;
using System.Runtime.InteropServices;

namespace TestDLLForDelphiV2
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICalc
    {
        [return: MarshalAs(UnmanagedType.I4)]
        int Add();
        int Plus(int a, int b);
        string Str(string a, string b);
    }

    public class Calc : ICalc
    {
        private int numberOne = 4;
        private int numberTwo = 5;

        // Add two integers
        public int Add()
        {
            return numberOne + numberTwo;
        }

        public int Plus(int a, int b)
        {
            return a + b;
        }

        public string Str(string a, string b) => a + b;

        [DllExport("GetInstance", CallingConvention = CallingConvention.StdCall)]
        public static bool GetInstance(ref ICalc x)
        {
            x = new Calc();
            return true;
        }
    }
}
