using System;
using GIM.Quantities.Conversion;

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
        public static Mass operator -(Mass left, Mass right) {
            if (!left.IsNull())
                return left.Add(-1*right);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public static Mass operator *(Mass mass, double scaleBy) {
            if (!mass.IsNull())
                return mass.ScaleBy(scaleBy);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public static Mass operator *(double scaleBy, Mass mass) {
            if (!mass.IsNull())
                return mass.ScaleBy(scaleBy);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public static Mass operator /(Mass mass, double scaleBy) {
            if (!mass.IsNull())
                return mass.ScaleBy(1/scaleBy);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public Mass ScaleBy(double scaleBy) {
            return new Mass(Amount * scaleBy, Unit);
        }
        public static double operator /(Mass mass1, Mass mass2) {
            if (!mass1.IsNull())
                return mass1.DivideBy(mass2);
            throw new ArgumentNullException("Left hand quantity cannot be null");
        }
        public double DivideBy(Mass mass2) {
            if (mass2.IsNull())
                throw new ArgumentNullException();
            if (!this.Unit.Equals(mass2.Unit))
                throw new NotImplementedException("Units do not match");
            return this.Amount / mass2.Amount;
        }
        public Mass In(MassUnit unitTo) {
            return MassConversion.Instance.Convert(this, unitTo);
        }
    }
}
