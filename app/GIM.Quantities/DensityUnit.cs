using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public class DensityUnitBuilder {
    	private MassUnit _massUnit;
        internal DensityUnitBuilder(MassUnit massUnit) {_massUnit = massUnit; }
        public DensityUnit Per(VolumeUnit volumeUnit) { return new DensityUnit(_massUnit, volumeUnit); }
    }
    public class DensityUnit : UnitOfMeasure {
        private MassUnit _massUnit;
        private VolumeUnit _volumeUnit;
        [Obsolete("Use DensityUnit.Of(MassUnit.Pounds).Per(VolumeUnit.Gallon)")]
        public DensityUnit(MassUnit massUnit, VolumeUnit volumeUnit) {
            _volumeUnit = volumeUnit;
            _massUnit = massUnit;
        }
        public override string ToString(IDisplayUnits displayFormat, UnitPlurality plurality) {
            return "{0}/{1}".Use(displayFormat.GetUnitDisplayFor(plurality.Example, _massUnit),
                displayFormat.GetUnitDisplayFor(UnitPlurality.Single.Example, _volumeUnit));
        }
        public static DensityUnitBuilder Of(MassUnit massUnit) { return new DensityUnitBuilder(massUnit); }
    }
}
