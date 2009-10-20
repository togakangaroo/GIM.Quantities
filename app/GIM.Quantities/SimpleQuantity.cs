using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public abstract class SimpleQuantity<UOM_TYPE> where UOM_TYPE : UnitOfMeasure {
        private readonly double _amount;
        private readonly SimpleQuantityFormatProvider<UOM_TYPE> _formatProvider;
        private readonly UOM_TYPE _unit;

        public SimpleQuantity(double amount, UOM_TYPE unit) {
            _unit = unit;
            _amount = amount;
            _formatProvider = new SimpleQuantityFormatProvider<UOM_TYPE>(this);
        }
        public double Amount {
            get { return _amount; }
        }
        public UOM_TYPE Unit {
            get {
                return _unit;
            }
        }
        public override string ToString() {
            return this.ToString(UnitDisplay.Short);
        }
        public string ToString(IDisplayUnits displayFormat) {
            return ToString("{0:n0} {1}");
        }
        public string ToString(string format) {            
            return String.Format(_formatProvider, format, Amount, Unit);
        }
    }
}
