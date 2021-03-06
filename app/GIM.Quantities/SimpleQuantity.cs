using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
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
        protected SimpleQuantity<UOM_TYPE> SimpleCreate(UnitOfMeasure unit, Func<UOM_TYPE, SimpleQuantity<UOM_TYPE>> creation) {
            var mu = unit as UOM_TYPE;
            if (mu.IsNull())
                throw new InvalidOperationException("Cannot create {0} form unit {1}".Use(this.GetType(), unit.GetType()));
            return creation(mu);
        }
        public override string ToString(string format) {            
            return String.Format(_formatProvider, format, Amount, Unit);
        }
    }
}
