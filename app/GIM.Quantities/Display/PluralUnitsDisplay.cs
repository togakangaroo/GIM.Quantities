using System;

namespace GIM.Quantities.Display {
    public class PluralUnitsDisplay : IDisplayUnits {
        IDisplayUnits _inner;
        IPluralizationConvention _pluralizationConvention;
        public PluralUnitsDisplay(IDisplayUnits inner, IPluralizationConvention pluralizationConvention) {
            _inner = inner;
            _pluralizationConvention = pluralizationConvention;
        }
        PluralityChecker _helper = new PluralityChecker();
        public string GetUnitDisplayFor(double amount, UnitOfMeasure unit) {
            return _pluralizationConvention.Convert(_inner.GetUnitDisplayFor(amount, unit), _helper.GetPlurality(amount));
        }

        public string GetUnitDisplayFor(UnitOfMeasure unit) {
            return _pluralizationConvention.Convert(_inner.GetUnitDisplayFor(unit));
        }
    }
}
