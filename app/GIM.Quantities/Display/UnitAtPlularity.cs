using System;

namespace GIM.Quantities.Display {
    public struct UnitAtPlularity {
        public readonly UnitOfMeasure Unit;
        public readonly UnitPlurality Plurality;
        public UnitAtPlularity(UnitOfMeasure unit, UnitPlurality plurality) {
            Unit = unit;
            Plurality = plurality;
        }
    }
}
