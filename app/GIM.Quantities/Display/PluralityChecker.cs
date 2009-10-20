using System;

namespace GIM.Quantities.Display {
    public class PluralityChecker {
        public bool IsSingular(double number) {
            return number == 1 || number == -1;
        }
        public UnitPlurality GetPlurality(double number) {
            return IsSingular(number) ? UnitPlurality.Single : UnitPlurality.Plural;
        }
    }
}
