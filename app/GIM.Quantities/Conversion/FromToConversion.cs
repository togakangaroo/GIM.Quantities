
namespace GIM.Quantities.Conversion {
    internal class FromToConversion {
        public UnitOfMeasure To { get; private set; }
        public UnitOfMeasure From { get; private set; }
        public FromToConversion(UnitOfMeasure from, UnitOfMeasure to) {
            To = to; From = from;
        }
        public override bool Equals(object obj) {
            if (obj.IsNull() || !(obj is FromToConversion))
                return false;
            var tfc = (FromToConversion)obj;
            return Equals(tfc.From, tfc.To);
        }
        public bool Equals(UnitOfMeasure from, UnitOfMeasure to) {
            return To.Equals(to) && From.Equals(from);
        }
        public override int GetHashCode() {
            return To.GetHashCode() ^ From.GetHashCode();
        }
    }
}
