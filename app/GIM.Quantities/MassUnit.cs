using System;
using GIM.Quantities.SpecificUnits;

namespace GIM.Quantities {
    public abstract class MassUnit : UnitOfMeasure {
        static MassUnitPounds _pounds = new MassUnitPounds();
        public static MassUnit Pounds {
            get { return _pounds; }
        }
        static MassUnitKilograms _kilograms = new MassUnitKilograms();
        public static MassUnit Kilograms {
            get { return _kilograms; }
        }
    }
    public static partial class QuantityCreationExtensions {
        public static Mass Pounds(this double amount) {
            return new Mass(amount, MassUnit.Pounds);
        }
        public static Mass Pounds(this int amount) {
            return new Mass(amount, MassUnit.Pounds);
        }
        public static Mass Kilograms(this double amount) {
            return new Mass(amount, MassUnit.Kilograms);
        }
        public static Mass Kilograms(this int amount) {
            return new Mass(amount, MassUnit.Kilograms);
        }
    }
    public static partial class QuantityConversionExtensions {
        public static Mass In(this Mass mass, Func<double, Mass> massUnitProvider) {
            return mass.In(massUnitProvider(1).Unit);
        }
        public static Volume In(this Volume volume, Func<double, Volume> volumeUnitProvider) {
            return volume.In(volumeUnitProvider(1).Unit);
        }
    }
}
