using System;

namespace GIM.Quantities.Display {
    public class SimpleEnglishPluralizationConvention : IPluralizationConvention {
        public string Convert(string word, UnitPlurality desiredPlurality) {
            if (desiredPlurality == UnitPlurality.Plural)
                return "{0}s".Use(word);
            return word;
        }
    }
}
