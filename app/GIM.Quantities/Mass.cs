using System;

namespace GIM.Quantities {
    public class Mass : SimpleQuantity<MassUnit> {
        public Mass(double amount, MassUnit unit)
            : base(amount, unit) { }
    }
}
