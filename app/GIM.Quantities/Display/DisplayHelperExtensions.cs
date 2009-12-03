using System;

namespace GIM.Quantities.Display {
    internal static class DisplayHelperExtensions {
        public static string ConvertPlural(this UnitAtPlularity unitAtPlularity, string str) {
            return unitAtPlularity.Plurality.Pluralizer.Convert(str);
        }
    }
}
