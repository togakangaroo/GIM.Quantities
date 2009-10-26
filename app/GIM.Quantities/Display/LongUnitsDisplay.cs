using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class LongUnitsDisplay : IDisplayUnits {
        IDictionary<Func<double, UnitOfMeasure, bool>, Func<double, UnitOfMeasure, string>> _typeNames2;
        IDictionary<Func<UnitOfMeasure, bool>, Func<UnitOfMeasure, string>> _typeNames;
        static PluralityChecker _plurality = new PluralityChecker();
        static IPluralizationConvention _pluralizationConvention = new SimpleEnglishPluralizationConvention();
        private static string Pl(double d, string s) {
            return _pluralizationConvention.Convert(s, _plurality.GetPlurality(d));
        }
        public LongUnitsDisplay() {
            _typeNames2 = new Dictionary<Func<double, UnitOfMeasure, bool>, Func<double, UnitOfMeasure, string>>() {
                {(d,u) => u==MassUnit.Pounds, (d,u) =>Pl(d,"pound")},
                {(d,u) => u==MassUnit.Kilograms, (d,u) =>Pl(d,"kilogram")},
                {(d,u) => u==VolumeUnit.Gallons, (d,u) =>Pl(d,"gallon")},
                {(d,u) => u==VolumeUnit.Liters, (d,u) =>Pl(d,"liter")},
                {(d,u) => u is DensityUnit, (d,u) =>{
                    var x = u as DensityUnit;
                    return "{0} per {1}".Use(
                        GetUnitDisplayFor(d, x.MassUnit),
                        GetUnitDisplayFor(UnitPlurality.Single.Example, x.VolumeUnit));
                }},
            };
            _typeNames = new Dictionary<Func<UnitOfMeasure, bool>, Func<UnitOfMeasure, string>>() {
                {u => u==MassUnit.Pounds, u =>"pound"},
                {u => u==MassUnit.Kilograms, u =>"kilogram"},
                {u => u==VolumeUnit.Gallons, u =>"gallon"},
                {u => u==VolumeUnit.Liters, u =>"liter"},
                {u => u is DensityUnit, u =>{
                    var x = u as DensityUnit;
                    return "{0} per {1}".Use(x.MassUnit,
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
