using System;

namespace GIM.Quantities {
    public class Mass : SimpleQuantity<MassUnit> {
        public Mass(double amount, MassUnit unit)
            : base(amount, unit) { }
        protected override Quantity Create(double amount, UnitOfMeasure unit) {
            return SimpleCreate(unit, u=> new Mass(amount, u));
        }
        public Mass Add(Mass rightHandQuantity) {
            if (rightHandQuantity.IsNull())
                throw new ArgumentNullException("Right hand quantity cannot be null");
            var q = Convert(rightHandQuantity, this.Unit);
            return (Mass)Create(this.Amount + q.Amount, this.Unit);
        }
        public static Mass operator +(Mass left, Mass right) {
            if (!left.IsNull())
                return left.Add(right);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
    }
}
