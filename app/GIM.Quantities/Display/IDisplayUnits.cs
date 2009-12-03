using System;

namespace GIM.Quantities.Display {
    public interface IDisplayUnits {
        string GetUnitDisplayFor(UnitAtPlularity unitAtPlularity);
    }
}
