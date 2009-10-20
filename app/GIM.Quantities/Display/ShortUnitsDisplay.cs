using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class ShortUnitsDisplay : IDisplayUnits {
        IDictionary<TaggedUnit, string> _typeNames = new Dictionary<TaggedUnit, string>() {
            {new TaggedUnit(MassUnit.Pounds, UnitPlurality.Single), "lb"},
            {new TaggedUnit(MassUnit.Kilograms, UnitPlurality.Single), "kg"},
            {new TaggedUnit(VolumeUnit.Gallons, UnitPlurality.Single), "gal"},
            {new TaggedUnit(VolumeUnit.Liters, UnitPlurality.Single), "ltr"},
        };
        PluralityChecker _plurality = new PluralityChecker();
        IPluralizationConvention _pluralizationConvention = new SimpleEnglishPluralizationConvention();

        public string GetUnitDisplayFor(double amount, UnitOfMeasure _unit) { 
            return _typeNames.FirstOrDefault(kv => kv.Key.Unit == _unit).IfNotNull(kv =>
                    _pluralizationConvention.Convert(kv.Value, _plurality.GetPlurality(amount)));
        }

        public bool MatchesFormatTag(string tag) {
            return String.Equals("short", tag, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
