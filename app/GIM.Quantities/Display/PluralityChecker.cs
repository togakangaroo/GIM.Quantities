using System;

namespace GIM.Quantities.Display {
    public class SinglePluralityChecker : IDeterminePlurality {        
        public UnitPlurality GetPlurality(double number) {
            return UnitPlurality.Single;
        }
    }
    public class PluralityChecker : IDeterminePlurality {
        private bool IsSingular(double number) {
            return number == 1 || number == -1;
        }
        public UnitPlurality GetPlurality(double number) {
            return IsSingular(number) ? UnitPlurality.Single : UnitPlurality.Plural;
        }
    }
}
