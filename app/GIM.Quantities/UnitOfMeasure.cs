using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public abstract class UnitOfMeasure {
        public override string ToString() {
            return ToString(new ShortUnitsDisplay(), UnitPlurality.Single);
        }
        public virtual string ToString(IDisplayUnits displayFormat, UnitPlurality plurality) {
            return displayFormat.GetUnitDisplayFor(new UnitAtPlularity(this, plurality));
        }
        public static IProvideUnitDisplays CurrentDisplayFactory {
            get { return ProvideUnitDisplaysFactory.Instance; }
        }
    }
}
