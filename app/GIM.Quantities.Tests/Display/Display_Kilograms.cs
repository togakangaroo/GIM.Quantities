using System;

namespace GIM.Quantities.Tests.Display {
    public class Display_Kilograms : Display_Unit {
        public Display_Kilograms()
            : base(
                () => MassUnit.Kilograms,
                new DisplayForms("kg", "kgs", "kilogram", "kilograms")
                ) { }
    }
}
