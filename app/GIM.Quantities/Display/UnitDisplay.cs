using System;

namespace GIM.Quantities.Display {
    public static class UnitDisplay {
        private readonly static IDisplayUnits _long = new LongUnitsDisplay();
        public static IDisplayUnits Long { get { return _long;}}
        private readonly static IDisplayUnits _short = new ShortUnitsDisplay();
        public static IDisplayUnits Short { get { return _short; } }

    }
}
