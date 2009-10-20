using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public abstract class UnitOfMeasure {
        public virtual string ToString(IDisplayUnits displayFormat, UnitPlurality plurality) {
            return displayFormat.GetUnitDisplayFor(plurality.Example, this);
        }
        public static IProvideUnitDisplays CurrentDisplayFactory {
            get { return ProvideUnitDisplaysFactory.Instance; }
        }
    }
}
