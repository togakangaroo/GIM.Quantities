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
    }
}
