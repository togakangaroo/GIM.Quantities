using System;
using GIM.Quantities.Conversion;

namespace GIM.Quantities {
    public class Volume : SimpleQuantity<VolumeUnit> {
        public Volume(double amount, VolumeUnit unit)
            : base(amount, unit) { }
        protected override Quantity Create(double amount, UnitOfMeasure unit) {
            return SimpleCreate(unit, u => new Volume(amount, u));
        }
        public Volume Add(Volume rightHandQuantity) {
            if (rightHandQuantity.IsNull())
                throw new ArgumentNullException("Right hand quantity cannot be null");
            var q = Convert(rightHandQuantity, this.Unit);
            return (Volume)Create(this.Amount + q.Amount, this.Unit);
        }
        public static Volume operator +(Volume left, Volume right) {
            if (!left.IsNull())
                return left.Add(right);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public static Volume operator -(Volume left, Volume right) {
            if (!left.IsNull())
                return left.Add(-1*right);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public static Volume operator *(Volume volume, double scaleBy) {
            if (!volume.IsNull())
                return volume.ScaleBy(scaleBy);
            throw new ArgumentNullException("Cannot scale null quantity");
        }
        public static Volume operator *(double scaleBy, Volume volume) {
            if (!volume.IsNull())
                return volume.ScaleBy(scaleBy);
            throw new ArgumentNullException("Cannot scale null quantity");
        }
        public static Volume operator /(Volume mass, double scaleBy) {
            if (!mass.IsNull())
                return mass.ScaleBy(1 / scaleBy);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }

        public Volume ScaleBy(double scaleBy) {
            return new Volume(Amount * scaleBy, Unit);
        }
        public static double operator /(Volume volume1, Volume volume2) {
            if (!volume1.IsNull())
                return volume1.DivideBy(volume2);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public double DivideBy(Volume volume2) {
            if (volume2.IsNull())
                throw new ArgumentNullException();
            if (!this.Unit.Equals(volume2.Unit))
                throw new NotImplementedException("Units do not match");
            return this.Amount / volume2.Amount;
        }

        public Volume In(VolumeUnit unitTo) {
            return VolumeConversion.Instance.Convert(this, unitTo);
        }
    }
}
