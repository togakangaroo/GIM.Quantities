using System;

namespace GIM.Quantities.Tests.Display {
    public class Display_Gallons : Display_Unit {
        public Display_Gallons()
            : base(
                () => VolumeUnit.Gallons,
                new DisplayForms("gal", "gals", "gallon", "gallons")
                ) { }
    }
}