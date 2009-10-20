using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class LongUnitsDisplay : IDisplayUnits {
        IDictionary<TaggedUnit, string> _typeNames = new Dictionary<TaggedUnit, string>() {
		            {new TaggedUnit(MassUnit.Pounds, UnitPlurality.Single), "pound"},
		            {new TaggedUnit(MassUnit.Kilograms, UnitPlurality.Single), "kilogram"},
		            {new TaggedUnit(VolumeUnit.Gallons, UnitPlurality.Single), "gallon"},
		            {new TaggedUnit(VolumeUnit.Liters, UnitPlurality.Single), "liter"},
		        };
        PluralityChecker _plurality = new PluralityChecker();
        IPluralizationConvention _pluralizationConvention = new SimpleEnglishPluralizationConvention();

        public string GetUnitDisplayFor(double amount, UnitOfMeasure _unit) {
            return _typeNames.FirstOrDefault(kv => kv.Key.Unit == _unit).IfNotNull(kv =>
                    _pluralizationConvention.Convert(kv.Value, _plurality.GetPlurality(amount)));
        }
        public bool MatchesFormatTag(string tag) {
            return String.Equals("long", tag, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
