using System;

namespace GIM.Quantities.Display {
    public interface IDisplayUnits {
        string GetUnitDisplayFor(double amount, UnitOfMeasure _unit);
        //string GetUnitDisplayFor(UnitPlurality plurality, UnitOfMeasure _unit);
    }
}
