using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace WalkerPlayer.utils {
    class WPString {

        internal static string CondenseTabsAndNewLines(string str) => Regex.Replace(str, @"\s\s+", "");
        internal static Size StringToSize(string strSize) {
            if (String.IsNullOrEmpty(strSize)) return new Size(); // not valid string size 
            if (strSize.IndexOf(',') == -1) return new Size(); // not valid string size
            string[] strArraySize = strSize.Split(',');
            return new Size(Int32.Parse(strArraySize[0]), Int32.Parse(strArraySize[1]));
        }
        internal static Point StringToPoint(string strPoint) {
            if (String.IsNullOrEmpty(strPoint)) return new Point();
            string[] strArraySize = strPoint.Split(',');
            return new Point(Int32.Parse(strArraySize[0]), Int32.Parse(strArraySize[1]));
        }
    }
}
