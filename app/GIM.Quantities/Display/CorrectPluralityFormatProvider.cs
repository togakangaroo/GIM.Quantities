using System;

namespace GIM.Quantities.Display {
    public class CorrectPluralityFormatProvider : IFormatProvider {
        private static PluralityChecker _pluralityChecker = new PluralityChecker();
        private UnitPlurality _plurality;
        public CorrectPluralityFormatProvider(Quantity quantity) {
            _plurality = _pluralityChecker.GetPlurality(quantity.Amount);
        }
        public object GetFormat(Type formatType) {
            if (!typeof(ICustomFormatter).IsAssignableFrom(formatType))
                return null;
            return new UnitFormatter(_plurality);
        }
    }
}
