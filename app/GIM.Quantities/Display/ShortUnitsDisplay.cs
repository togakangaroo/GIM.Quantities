using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class ShortUnitsDisplay : IDisplayUnits {
        IDictionary<Func<double, UnitOfMeasure, bool>, Func<double, UnitOfMeasure, string>> _typeNames2;
        IDictionary<Func<UnitOfMeasure, bool>, Func<UnitOfMeasure, string>> _typeNames;
        static PluralityChecker _plurality = new PluralityChecker();
        static IPluralizationConvention _pluralizationConvention = new SimpleEnglishPluralizationConvention();
        private static string Pl(double d, string s) {
            return _pluralizationConvention.Convert(s, _plurality.GetPlurality(d));
        }
        public ShortUnitsDisplay() {
            _typeNames2 = new Dictionary<Func<double, UnitOfMeasure, bool>, Func<double, UnitOfMeasure, string>>() {
                {(d,u) => u==MassUnit.Pounds, (d,u) =>Pl(d,"lb")},
                {(d,u) => u==MassUnit.Kilograms, (d,u) =>Pl(d,"kg")},
                {(d,u) => u==VolumeUnit.Gallons, (d,u) =>Pl(d,"gal")},
                {(d,u) => u==VolumeUnit.Liters, (d,u) =>Pl(d,"ltr")},
                {(d,u) => u is DensityUnit, (d,u) =>{
                    var x = u as DensityUnit;
                    return "{0}/{1}".Use(
                        GetUnitDisplayFor(d, x.MassUnit),
                        GetUnitDisplayFor(UnitPlurality.Single.Example, x.VolumeUnit));
                }},
            };
            _typeNames = new Dictionary<Func<UnitOfMeasure, bool>, Func<UnitOfMeasure, string>>() {
                {u => u==MassUnit.Pounds, u =>"lb"},
                {u => u==MassUnit.Kilograms, u =>"kg"},
                {u => u==VolumeUnit.Gallons, u =>"gal"},
                {u => u==VolumeUnit.Liters, u =>"ltr"},
                {u => u is DensityUnit, u =>{
                    var x = u as DensityUnit;
                    return "{0}/{1}".Use(x.MassUnit, 
                        GetUnitDisplayFor(UnitPlurality.Single.Example, x.VolumeUnit));
                }},
            };
        }

        public string GetUnitDisplayFor(double amount, UnitOfMeasure unit) { 
            return _typeNames2.FirstOrDefault(kv => kv.Key(amount, unit)).IfNotNull(kv => kv.Value(amount, unit));
        }

        public string GetUnitDisplayFor(UnitOfMeasure unit) {
            return _typeNames.FirstOrDefault(kv => kv.Key(unit)).IfNotNull(kv => kv.Value(unit));
        }
    }
}
