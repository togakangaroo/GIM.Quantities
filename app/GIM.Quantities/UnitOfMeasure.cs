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
        public static bool operator ==(UnitOfMeasure left, UnitOfMeasure right) {
            if (!left.IsNull())
                return left.Equals(right);
            if(right.IsNull())
                return true;
            return false;
        }
        public static bool operator !=(UnitOfMeasure left, UnitOfMeasure right) {
            return !(left == right);
        }
        public override int GetHashCode() {
            return this.GetType().GetHashCode() ^ this.GetType().GetHashCode();
        }
        public override bool Equals(object obj) {
            if (obj.IsNull())
                return false;
            if (obj.GetType().IsAssignableFrom(this.GetType()) || this.GetType().IsAssignableFrom(obj.GetType()))
                return true;
            return false;
        }
    }
}
