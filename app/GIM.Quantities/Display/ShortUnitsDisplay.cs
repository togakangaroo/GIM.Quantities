using System;
using System.Collections.Generic;

namespace GIM.Quantities.Display {
    public class ShortUnitsDisplay : IDisplayUnits {
        readonly FuncHash<UnitAtPlularity, UnitAtPlularity, string> _unitConverter;
        public ShortUnitsDisplay() {
            _unitConverter = new FuncHash<UnitAtPlularity,UnitAtPlularity,string>(
                new Dictionary<Func<UnitAtPlularity, bool>, Func<UnitAtPlularity, string>>() {
                {u => u.Unit==MassUnit.Pounds, u =>u.ConvertPlural("lb")},
                {u => u.Unit==MassUnit.Kilograms, u =>u.ConvertPlural("kg")},
                {u => u.Unit==VolumeUnit.Gallons, u =>u.ConvertPlural("gal")},
                {u => u.Unit==VolumeUnit.Liters, u =>u.ConvertPlural("ltr")},
                {u => u.Unit==VolumeUnit.Barrels, u =>u.ConvertPlural("brl")},
                {u => u.Unit is DensityUnit, u =>{
                    var x = u.Unit as DensityUnit;
                    return "{0}/{1}".Use(
                        x.MassUnit.ToString(this, u.Plurality), x.VolumeUnit.ToString(this, UnitPlurality.Single));
                }},
            });
        }

        public string GetUnitDisplayFor(UnitAtPlularity unitAtPlularity) {
            return _unitConverter.ExecuteFirstOrDefault(unitAtPlularity, unitAtPlularity);
        }
    }
}
