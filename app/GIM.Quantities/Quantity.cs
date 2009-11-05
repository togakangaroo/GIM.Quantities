using System;
using System.Diagnostics;

namespace GIM.Quantities {
    [DebuggerDisplay("{ToString()}")]
    public abstract class Quantity {
        private readonly double _amount;
        private static readonly NotImplementedException _imiplicitConversionErr = new NotImplementedException("Implcit conversions not yet supported");
        private readonly UnitOfMeasure _unit;
        public Quantity(double amount, UnitOfMeasure unit) {
            _amount = amount;
            _unit = unit;
        }
        public double Amount { get { return _amount; } }
        public UnitOfMeasure Unit { get { return _unit; } }
        public abstract string ToString(string format);
        public static bool operator ==(Quantity left, Quantity right) {
            if (!left.IsNull())
                return left.Equals(right);
            if (!right.IsNull())
                return right.Equals(left);
            return true;
        }
        public static bool operator !=(Quantity left, Quantity right) {
            return !(left == right);
        }
        public override int GetHashCode() {
            return Amount.GetHashCode() ^ Unit.GetHashCode();
        }
        public override bool Equals(object obj) {
            var qnt = obj as Quantity;
            if (qnt.IsNull())
                return false;
            if (qnt.Unit != this.Unit) {
                throw _imiplicitConversionErr;
            }
            return Math.Round(Amount, 14) == Math.Round(qnt.Amount, 14) && Unit == qnt.Unit;
        }
        protected abstract Quantity Create(double amount, UnitOfMeasure unit);
        protected Quantity Convert(Quantity q, UnitOfMeasure targetUnit) {
            if (q.Unit != targetUnit)
                throw _imiplicitConversionErr;
            return q;
        }
    }
}
