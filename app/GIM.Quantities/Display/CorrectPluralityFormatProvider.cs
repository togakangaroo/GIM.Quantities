using System;

namespace GIM.Quantities.Display {
    public class CorrectPluralityFormatProvider : IFormatProvider, ICustomFormatter {
        private UnitPlurality _plurality;
        public CorrectPluralityFormatProvider(Quantity quantity, IDeterminePlurality pluralityChecker) {
            _plurality = pluralityChecker.GetPlurality(quantity.Amount);
        }
        public CorrectPluralityFormatProvider(Quantity quantity) : this(quantity, new PluralityChecker()) { }

        public object GetFormat(Type formatType) {
            if (!typeof(ICustomFormatter).IsAssignableFrom(formatType))
                return null;
            return this;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider) {
            var uom = arg as UnitOfMeasure;
            if (uom.IsNull()) return null;
            return ProvideUnitDisplaysFactory.Instance.Get(format, uom, _plurality).GetUnitDisplayFor(new UnitAtPlularity(uom, _plurality));
        }
    }
}
