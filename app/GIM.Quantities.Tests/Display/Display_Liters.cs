using System;

namespace GIM.Quantities.Tests.Display {
    public class Display_Liters : Display_Unit {
        public Display_Liters()
            : base(
                () => VolumeUnit.Liters,
                new DisplayForms("ltr", "ltrs", "liter", "liters")
                ) { }
    }
}
