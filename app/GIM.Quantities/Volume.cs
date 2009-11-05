using System;

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
    }
}
