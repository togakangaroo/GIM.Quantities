using System;

namespace GIM.Quantities.Display {
    public interface IProvideUnitDisplays {
        IDisplayUnits Get(string tag, UnitOfMeasure targetUnit);
    }
}
