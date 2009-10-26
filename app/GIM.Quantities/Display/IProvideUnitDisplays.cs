using System;
using GIM.Quantities.Display.Registration;

namespace GIM.Quantities.Display {
    public interface IProvideUnitDisplays {
        IDisplayUnits Get(string tag, UnitOfMeasure targetUnit);
        UnitsDisplayRepository Add(Func<UnitDisplayRegistrationStarter, IUnitDisplayRegistration> registrationTransform);
    }
}
