using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class LongUnitsDisplay : IDisplayUnits {
        readonly FuncHash<UnitAtPlularity, UnitAtPlularity, string> _unitConverter;
        public LongUnitsDisplay() {
            _unitConverter = new FuncHash<UnitAtPlularity, UnitAtPlularity, string>(
                new Dictionary<Func<UnitAtPlularity, bool>, Func<UnitAtPlularity, string>>() {
                {u => u.Unit==MassUnit.Pounds, u =>u.ConvertPlural("pound")},
                {u => u.Unit==MassUnit.Kilograms, u =>u.ConvertPlural("kilogram")},
                {u => u.Unit==VolumeUnit.Gallons, u =>u.ConvertPlural("gallon")},
                {u => u.Unit==VolumeUnit.Liters, u =>u.ConvertPlural("liter")},
                {u => u.Unit==VolumeUnit.Barrels, u =>u.ConvertPlural("barrel")},
                {u => u.Unit is DensityUnit, u =>{
                    var x = u.Unit as DensityUnit;
                    return "{0} per {1}".Use(
                        x.MassUnit.ToString(this, u.Plurality), x.VolumeUnit.ToString(this, UnitPlurality.Single));
                }},
            });
        }

        public string GetUnitDisplayFor(UnitAtPlularity unitAtPlularity) {
            return  _unitConverter.ExecuteFirstOrDefault(unitAtPlularity, unitAtPlularity);
        }
    }
}
