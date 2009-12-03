using System;

namespace GIM.Quantities.Tests.Display {
    public class Display_Barrels : Display_Unit {
        public Display_Barrels()
            : base(
                () => VolumeUnit.Barrels,
                new DisplayForms("brl", "brls", "barrel", "barrels")
                ) { }
    }
}
