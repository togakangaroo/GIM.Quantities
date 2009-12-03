using System;

namespace GIM.Quantities.Display {
    public class SimpleEnglishPluralizationConvention : IPluralizationConvention {
        public string Convert(string word, UnitPlurality desiredPlurality) {
            if (desiredPlurality == UnitPlurality.Plural)
                return Convert(word);
            return word;
        }
        private string SplitAndPluralize(string word, string splitOn) {
            var split = word.Split(new[]{splitOn}, StringSplitOptions.None);
            if (split.Length <= 1) return null;
            split[0] = Convert(split[0]);
            return String.Join(splitOn, split);
        }
        public string Convert(string word) {
            string s = SplitAndPluralize(word, "/");
            if (!s.IsNull())
                return s;
            s = SplitAndPluralize(word, " per ");
            if (!s.IsNull())
                return s;
            return "{0}s".Use(word);
            
        }
    }
}
