using System;

namespace GIM.Quantities.Display {
    public abstract class UnitPlurality {
        public abstract double Example { get; }
        private readonly static UnitPlurality _plural = new UnitPluralityPlural();
        public static UnitPlurality Plural { get { return _plural; } }
        private readonly static UnitPlurality _single = new UnitPluralitySingle();
        public static UnitPlurality Single { get { return _single; } }
    }
    public class UnitPluralityPlural : UnitPlurality {
        [Obsolete("Use UnitPlurality.Plural")]
        public UnitPluralityPlural() { }
        public override double Example { get { return 10; } }
    }
    public class UnitPluralitySingle : UnitPlurality {
        [Obsolete("Use UnitPlurality.Single")]
        public UnitPluralitySingle() { }
        public override double Example { get { return 1; } }
    }
}
