using System;

namespace GIM.Quantities.Display {
    public static class ProvideUnitDisplaysFactory {
        private readonly static IProvideUnitDisplays _instance;
        static ProvideUnitDisplaysFactory() {
            _instance = new UnitsDisplayRepository()
                .Add(x => x.Instance(new ShortUnitsDisplay()).WithTags("short").DefaultFor<UnitOfMeasure>())
                .Add(x => x.Instance(new LongUnitsDisplay()).WithTags("long"));
        }
        
        public static IProvideUnitDisplays Instance {
            get { return _instance; }
        }
    }
}
