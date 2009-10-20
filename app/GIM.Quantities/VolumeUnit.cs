using System;
using GIM.Quantities.SpecificUnits;

namespace GIM.Quantities {
    public abstract class VolumeUnit : UnitOfMeasure {
        static VolumeUnitGallons _gallons = new VolumeUnitGallons();
        public static VolumeUnit Gallons {
            get { return _gallons; }
        }
        static VolumeUnitLiters _liters = new VolumeUnitLiters();
        public static VolumeUnit Liters {
            get { return _liters; }
        }
    }
    public static partial class QuantityCreationExtensions {
        public static Volume Gallons(this double amount) {
            return new Volume(amount, VolumeUnit.Gallons);
        }
        public static Volume Gallons(this int amount) {
            return new Volume(amount, VolumeUnit.Gallons);
        }
        public static Volume Liters(this double amount) {
            return new Volume(amount, VolumeUnit.Liters);
        }
        public static Volume Liters(this int amount) {
            return new Volume(amount, VolumeUnit.Liters);
        }
    }
}
