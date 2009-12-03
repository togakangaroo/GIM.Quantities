using System;

namespace GIM.Quantities.Display.Registration {
    public class UnitDisplayRegistrationStarter {

        public UnitDisplayRegistrationTagsAdder Instance(IDisplayUnits unitsDisplay) {
            return new UnitDisplayRegistrationTagsAdder(unitsDisplay);
        }
    }
}
