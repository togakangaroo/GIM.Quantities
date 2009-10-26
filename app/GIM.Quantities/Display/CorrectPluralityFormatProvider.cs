using System;

namespace GIM.Quantities.Display {
    public class CorrectPluralityFormatProvider : IFormatProvider {
        private UnitPlurality _plurality;
        public CorrectPluralityFormatProvider(Quantity quantity, IDeterminePlurality pluralityChecker) {
            _plurality = pluralityChecker.GetPlurality(quantity.Amount);
        }
        public CorrectPluralityFormatProvider(Quantity quantity) : this(quantity, new PluralityChecker()) { }

        public object GetFormat(Type formatType) {
            if (!typeof(ICustomFormatter).IsAssignableFrom(formatType))
                return null;
            return new UnitFormatter(_plurality);
        }
    }
}
