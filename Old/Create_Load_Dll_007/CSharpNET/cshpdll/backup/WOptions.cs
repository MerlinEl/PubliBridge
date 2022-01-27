using System;
using System.Collections.Generic;

namespace cshpdll {
    class WOptions {

        public bool Full_Screen { get; set; } = false;
        public bool Fit_To_Screen { get; set; } = false;

        internal Dictionary<string, string> ToDictionary() {
            
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //
            return dict;
        }

        internal WOptions FromDictionary(Dictionary<string, string> dict) {

            WOptions opt = new WOptions();
            //
            return opt;
        }
    }
}
