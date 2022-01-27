using RGiesecke.DllExport;
using System;
//https://docs.microsoft.com/en-us/dotnet/
namespace cshpdll {
    public class Class1 {

        //[DllExport("add", CallingConvention = CallingConvention.Cdecl)]
        [DllExport]
        public static int Plus(int left, int right) => left + right;
        [DllExport]
        public static int Min(int X, int Y) => Math.Min(X, Y);
        [DllExport]
        public static int Max(int X, int Y) => Math.Max(X, Y);
    }
}
