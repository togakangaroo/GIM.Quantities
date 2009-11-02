using System;
using System.Collections.Generic;

namespace GIM.Quantities.Display {
    public class ShortUnitsDisplay : IDisplayUnits {
        readonly FuncHash<UnitAtPlularity, UnitAtPlularity, string> _unitConverter;
        public ShortUnitsDisplay() {
            _unitConverter = new FuncHash<UnitAtPlularity,UnitAtPlularity,string>(
                new Dictionary<Func<UnitAtPlularity, bool>, Func<UnitAtPlularity, string>>() {
                {u => u.Unit==MassUnit.Pounds, u =>"lb"},
                {u => u.Unit==MassUnit.Kilograms, u =>"kg"},
                {u => u.Unit==VolumeUnit.Gallons, u =>"gal"},
                {u => u.Unit==VolumeUnit.Liters, u =>"ltr"},
                {u => u.Unit is DensityUnit, u =>{
                    var x = u.Unit as DensityUnit;
                    return "{0}/{1}".Use(
                        x.MassUnit.ToString(this, u.Plurality), x.VolumeUnit.ToString(this, UnitPlurality.Single));
                }},
            });
        }

        public string GetUnitDisplayFor(double amount, UnitOfMeasure unit) {
            throw new NotImplementedException();
        }

        public string GetUnitDisplayFor(UnitAtPlularity unitAtPlularity) {
            return unitAtPlularity.Plurality.Pluralizer.Convert(
                _unitConverter.ExecuteFirstOrDefault(unitAtPlularity, unitAtPlularity));
        }
    }
}
