using System;

namespace GIM.Quantities.Display {
    public class MassUnitDisplayFormatter : ICustomFormatter {
        private IProvideUnitDisplays _knownDisplaysFactory;
        private Mass _mass;
        public MassUnitDisplayFormatter(IProvideUnitDisplays knownDisplayFormats, Mass mass) {
            _mass = mass;
            _knownDisplaysFactory = knownDisplayFormats;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider) {
            var uom = arg as MassUnit;
            if (uom.IsNull()) 
                return null;
            var display = _knownDisplaysFactory.Get(format, uom); //ensure that the format exists
            return display.GetUnitDisplayFor(_mass.Amount, uom);
        }

    }
    public class MassUnitFormatProvider : IFormatProvider {
        private Mass _mass;
        public MassUnitFormatProvider(Mass mass) {
            _mass = mass;
        }
        public object GetFormat(Type formatType) {
            return typeof(ICustomFormatter).IsAssignableFrom(formatType) ? new MassUnitDisplayFormatter(ProvideUnitDisplaysFactory.Instance, _mass) : null;
        }
    }
}
