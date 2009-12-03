using System;

namespace GIM.Quantities.Tests.Display {
    public class Display_Pounds : Display_Unit {
        public Display_Pounds() : base(
            () => MassUnit.Pounds,
            new DisplayForms("lb", "lbs", "pound", "pounds")
            ){}
    }
}
