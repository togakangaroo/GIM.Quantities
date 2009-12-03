using System;

namespace GIM.Quantities.Tests.Display {
    public class Display_KilogramsPerLiter : Display_Unit {
        public Display_KilogramsPerLiter()
            : base(
                () => DensityUnit.Of(MassUnit.Kilograms).Per(VolumeUnit.Liters),
                new DisplayForms("kg/ltr", "kgs/ltr", "kilogram per liter", "kilograms per liter")
                ) { }
    }
}
