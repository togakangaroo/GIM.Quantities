using System;

namespace GIM.Quantities.Display {
    public class SimpleQuantityUnitDisplayFormatter<UOM_TYPE> : ICustomFormatter where UOM_TYPE : UnitOfMeasure {
        private IProvideUnitDisplays _knownDisplaysFactory;
        private SimpleQuantity<UOM_TYPE> _quantity;
        public SimpleQuantityUnitDisplayFormatter(IProvideUnitDisplays knownDisplayFormats, SimpleQuantity<UOM_TYPE> quantity) {
            _quantity = quantity;
            _knownDisplaysFactory = knownDisplayFormats;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider) {
            var uom = arg as UOM_TYPE;
            if (uom.IsNull())
                return null;
            var display = _knownDisplaysFactory.Get(format, uom);
            return display.GetUnitDisplayFor(_quantity.Amount, uom);
        }

    }
}
