using System;

namespace GIM.Quantities.Display {
    public class UnitFormatter : ICustomFormatter {

        private UnitPlurality _plurality;
        public UnitFormatter(UnitPlurality plurality) {
            _plurality = plurality;
                                                       
        }

        public string Format(string format, object arg, IFormatProvider formatProvider) {
            var uom = arg as UnitOfMeasure;
            if (uom.IsNull()) return null;
            return ProvideUnitDisplaysFactory.Instance.Get(format, uom).GetUnitDisplayFor(_plurality.Example, uom);
        }
    }
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
