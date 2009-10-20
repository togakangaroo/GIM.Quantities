using System;

namespace GIM.Quantities {
    public class Volume : SimpleQuantity<VolumeUnit> {
        public Volume(double amount, VolumeUnit unit)
            : base(amount, unit) { }
    }
}
