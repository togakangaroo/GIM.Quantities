using System;
using System.Diagnostics;

namespace GIM.Quantities {
    [DebuggerDisplay("{ToString()}")]
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
}
