using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public class Quantity {
        private readonly double _amount;
        private readonly UnitOfMeasure _unit;
        public Quantity(double amount, UnitOfMeasure unit) {
            _amount = amount;
            _unit = unit;
        }
        public double Amount { get { return _amount; } }
        public UnitOfMeasure Unit { get { return _unit; } }
    }
    public abstract class SimpleQuantity<UOM_TYPE> : Quantity where UOM_TYPE : UnitOfMeasure {
        protected readonly CorrectPluralityFormatProvider _formatProvider;
        private readonly UOM_TYPE _unit;

        public SimpleQuantity(double amount, UOM_TYPE unit) : base(amount, unit) {
            _unit = unit;
            _formatProvider = new CorrectPluralityFormatProvider(this);
        }
        public new UOM_TYPE Unit {
            get { return _unit; }
        }
        public override string ToString() {
            return ToString("{0:n0} {1}");
        }
        public virtual string ToString(string format) {            
            return String.Format(_formatProvider, format, Amount, Unit);
        }
    }
}
