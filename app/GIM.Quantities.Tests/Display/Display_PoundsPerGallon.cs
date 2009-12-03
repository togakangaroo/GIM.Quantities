using System;

namespace GIM.Quantities.Tests.Display {
    public class Display_PoundsPerGallon : Display_Unit {

        public Display_PoundsPerGallon()
            : base(
                () => DensityUnit.Of(MassUnit.Pounds).Per(VolumeUnit.Gallons),
                new DisplayForms("lb/gal", "lbs/gal", "pound per gallon", "pounds per gallon")
                ) { }
    }
}
