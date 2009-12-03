using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public class Density : SimpleQuantity<DensityUnit> {
        private readonly Mass _mass;
        private readonly Volume _volume;
        private readonly static DensityFormatterFactory _factory = new DensityFormatterFactory();

        public Density(Mass mass, Volume volume) : 
            base(mass.Amount/volume.Amount, new DensityUnit(mass.Unit, volume.Unit)) {
            _volume = volume;
            _mass = mass;
        }
        public Mass Mass {
            get {
                return _mass;
            }
        }
        public Volume Volume {
            get {
                return _volume;
            }
        }
        protected override Quantity Create(double amount, UnitOfMeasure unit) {
            return SimpleCreate(unit, u => new Density(new Mass(amount, u.MassUnit), new Volume(1, u.VolumeUnit)));
        }

        public override string ToString() {
            return ToString("{0:n2} {1}");
        }
        public override string ToString(string format) {
            var formatter = _factory.GetForPattern(format);
            return formatter.Format(format, this);
        }
        public Density Add(Density rightHandQuantity) {
            if (rightHandQuantity.IsNull())
                throw new ArgumentNullException("Right hand quantity cannot be null");
            var q = (Density)Convert(rightHandQuantity, this.Unit);
            return new Density(new Mass(Amount + q.Amount, Mass.Unit), new Volume(1, Volume.Unit));
        }
        public static Density operator +(Density left, Density right) {
            if (!left.IsNull())
                return left.Add(right);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public static Density operator -(Density left, Density right) {
            if (!left.IsNull())
                return left.Add(-1 * right);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public static Density operator *(Density quantity, double scaleBy) {
            if (!quantity.IsNull())
                return quantity.ScaleBy(scaleBy);
            throw new ArgumentNullException("Cannot scale null quantity");
        }
        public static Density operator *(double scaleBy, Density quantity) {
            if (!quantity.IsNull())
                return quantity.ScaleBy(scaleBy);
            throw new ArgumentNullException("Cannot scale null quantity");
        }
        public static Density operator /(Density quantity, double scaleBy) {
            if (!quantity.IsNull())
                return quantity.ScaleBy(1 / scaleBy);
            throw new ArgumentNullException("Cannot scale null quantity");
        }

        public Density ScaleBy(double scaleBy) {
            return new Density(new Mass(Amount * scaleBy, Unit.MassUnit), new Volume(1, Unit.VolumeUnit));
        }

    }
}
