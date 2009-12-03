using System;

namespace GIM.Quantities.Display {
    public class NullPluralizationConvention : IPluralizationConvention {
        public string Convert(string word, UnitPlurality desiredPlurality) {
            return word;
        }

        public string Convert(string word) {
            return word;
        }
    }
}
