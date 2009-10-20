using System;

namespace GIM.Quantities.Display {
    public class SimpleQuantityFormatProvider<UOM_TYPE> : IFormatProvider where UOM_TYPE : UnitOfMeasure {
        private SimpleQuantity<UOM_TYPE> _quantity;
        public SimpleQuantityFormatProvider(SimpleQuantity<UOM_TYPE> quantity) {
            _quantity = quantity;
        }
        public object GetFormat(Type formatType) {
            return typeof(ICustomFormatter).IsAssignableFrom(formatType) ? new SimpleQuantityUnitDisplayFormatter<UOM_TYPE>(ProvideUnitDisplaysFactory.Instance, _quantity) : null;
        }
    }
}
