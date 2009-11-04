using System;
using System.Diagnostics;

namespace GIM.Quantities {
    [DebuggerDisplay("{ToString()}")]
    public abstract class Quantity {
        private readonly double _amount;
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
            return Amount == qnt.Amount && Unit == qnt.Unit;
        }
        public static Quantity operator +(Quantity left, Quantity right) {
            if (left.Unit != right.Unit)
                throw new NotImplementedException("Cannot do operations on quantities of different units");
            throw new NotImplementedException();
        }

    }
}
