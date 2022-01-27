using System.Text.RegularExpressions;

namespace WalkerPlayer.utils {
    class WPString {

        internal static string CondenseTabsAndNewLines(string str) => Regex.Replace(str, @"\s\s+", "");
    }
}
