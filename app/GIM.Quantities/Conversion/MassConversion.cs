using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GIM.Quantities.Conversion {
    public class MassConversion {
        const double _lbs_In_1_Kg = 2.20462262;
        const double _lbs_In_1_Ton = 2000;
        static readonly IDictionary<FromToConversion, double> _knownConversions = new Dictionary<FromToConversion, double>() {
            {new FromToConversion(MassUnit.Kilograms, MassUnit.Pounds), _lbs_In_1_Kg},
            {new FromToConversion(MassUnit.Pounds, MassUnit.Kilograms), 1/_lbs_In_1_Kg},
            {new FromToConversion(MassUnit.Tons, MassUnit.Pounds), _lbs_In_1_Ton},
            {new FromToConversion(MassUnit.Pounds, MassUnit.Tons), 1/_lbs_In_1_Ton},
        };
        private MassConversion() { }
        public Mass Convert(Mass from, MassUnit to) {
            if (from.Unit.Equals(to))
                return new Mass(from.Amount, to);
            var tfs = new FromToConversion(from.Unit, to);
            if(!_knownConversions.ContainsKey(tfs))
                throw new NotImplementedException("This conversion has not yet been implemented");
            return new Mass(from.Amount * _knownConversions[tfs], to);
        }
        private static MassConversion _instance = new MassConversion();
        public static MassConversion Instance {
            get { return _instance; }
        }
    }
}
