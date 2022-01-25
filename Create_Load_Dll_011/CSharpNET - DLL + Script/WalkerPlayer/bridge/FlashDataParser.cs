using System;

namespace WalkerPlayer.bridge {
    class FlashDataParser {
        //from flash > [ flashMsg ]
        //from flash > [ tabName , flashMsg ]
        internal static string[] GetLogDataFromStringArray(string[] data_arr) {

            string tabName = data_arr.Length > 1 ? data_arr[0] : "Flash";
            string msg = data_arr.Length == 1 ? data_arr[0] : data_arr[1];
            return new string[]{ tabName, msg };
        }
    }
}
