using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public class DensityUnitBuilder {
    	private MassUnit _massUnit;
        internal DensityUnitBuilder(MassUnit massUnit) {_massUnit = massUnit; }
        public DensityUnit Per(VolumeUnit volumeUnit) { return new DensityUnit(_massUnit, volumeUnit); }
    }
    public class DensityUnit : UnitOfMeasure {
        private readonly MassUnit _massUnit;
        private readonly VolumeUnit _volumeUnit;
        [Obsolete("Use DensityUnit.Of(MassUnit.Pounds).Per(VolumeUnit.Gallon)")]
        public DensityUnit(MassUnit massUnit, VolumeUnit volumeUnit) {
            _volumeUnit = volumeUnit;
            _massUnit = massUnit;
        }
        public MassUnit MassUnit { get { return _massUnit; } }
        public VolumeUnit VolumeUnit { get { return _volumeUnit; } }
        public override bool Equals(object obj) {
            var du = obj as DensityUnit;
            if (du.IsNull())
                return false;
            return MassUnit.Equals(du.MassUnit) && VolumeUnit.Equals(du.VolumeUnit);
        }
        public override int GetHashCode() {
            return MassUnit.GetHashCode() ^ VolumeUnit.GetHashCode();
        }
        public static DensityUnitBuilder Of(MassUnit massUnit) { return new DensityUnitBuilder(massUnit); }
    }
    public static partial class QuantityCreationExtensions {
        public static Density Per(this Mass mass, Volume volume) {
            return new Density(mass, volume);
        }
        public static Density Per(this Mass mass, Func<double, Volume> volumeBuilder) {
            return new Density(mass, volumeBuilder(1));
        }
    }
}
