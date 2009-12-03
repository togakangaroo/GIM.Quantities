using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public static class ProvideUnitDisplaysFactory {
        private static IProvideUnitDisplays _instance;
        static ProvideUnitDisplaysFactory() {
            ResetToDefault();
        }
        public static IProvideUnitDisplays Instance {
            get { return _instance; }
        }
        //static IDictionary<UnitPlurality, IProvideUnitDisplays> _displayProviders = new Dictionary<UnitPlurality, IProvideUnitDisplays>();
        //public static IProvideUnitDisplays GetDisplayForPlurality(UnitPlurality plurality) {
        //    return _displayProviders.First(kv => kv.Key == plurality).Value;
        //}
        public static void ResetToDefault() {
            _instance = new UnitsDisplayRepository()
                            .Add(x => x.Instance(new ShortUnitsDisplay()).WithTags("short").DefaultFor<UnitOfMeasure>())
                            .Add(x => x.Instance(new LongUnitsDisplay()).WithTags("long"));
            //var instancePlural = new UnitsDisplayRepository()
            //    .Add(x => x.Instance(new ShortUnitsDisplay()).WithTags("short").DefaultFor<UnitOfMeasure>())
            //    .Add(x => x.Instance(new LongUnitsDisplay()).WithTags("long"));
            //_displayProviders.Add(UnitPlurality.Single, _instance);
            //_displayProviders.Add(UnitPlurality.Plural, instancePlural);
        }
    }
}
