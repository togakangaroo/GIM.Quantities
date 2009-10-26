using System;

namespace GIM.Quantities.Display {
    public interface IDeterminePlurality {
        UnitPlurality GetPlurality(double number);
    }
}
