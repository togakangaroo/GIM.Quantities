using System;
using GIM.Quantities.Display.Registration;

namespace GIM.Quantities.Display {
    public interface IProvideUnitDisplays {
        IDisplayUnits Get(string tag, UnitOfMeasure targetUnit);
        IDisplayUnits Get(string tag, UnitOfMeasure targetUnit, UnitPlurality plurality);
        UnitsDisplayRepository Add(Func<UnitDisplayRegistrationStarter, IUnitDisplayRegistration> registrationTransform);
    }
}
