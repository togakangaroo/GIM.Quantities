using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GIM.Quantities.Conversion {
    public class MassConversion {
        const double _lbs_In_1_Kg = 2.20462262;
        private MassConversion() { }
        public Mass Convert(Mass from, MassUnit to) {
            if (from.Unit.Equals(to))
                return new Mass(from.Amount, to);

            if (from.Unit.Equals(MassUnit.Kilograms) && to.Equals(MassUnit.Pounds))
                return new Mass(from.Amount * _lbs_In_1_Kg, to);
            if (from.Unit.Equals(MassUnit.Pounds) && to.Equals(MassUnit.Kilograms))
                return new Mass(from.Amount / _lbs_In_1_Kg, to);
            throw new NotImplementedException();
        }
        private static MassConversion _instance = new MassConversion();
        public static MassConversion Instance {
            get { return _instance; }
        }
    }
}
