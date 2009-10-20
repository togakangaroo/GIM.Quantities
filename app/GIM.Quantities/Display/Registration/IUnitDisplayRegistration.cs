using System;

namespace GIM.Quantities.Display.Registration {
    public interface IUnitDisplayRegistration {
        IUnitDisplayRegistration DefaultFor<T>() where T : UnitOfMeasure;
        void RegisterTo(UnitsDisplayRepository repository);
    }
}
