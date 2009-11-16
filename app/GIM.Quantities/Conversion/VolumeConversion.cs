using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GIM.Quantities.Conversion {
    public class VolumeConversion {
        const double _gals_In_1_Ltr = 0.264172052;
        const double _brls_In_1_Ltr = 0.00852167911;
        const double _gals_In_1_Brl = 31;
        private VolumeConversion() { }
        public Volume Convert(Volume from, VolumeUnit to) {
            if (from.Unit.Equals(to))
                return new Volume(from.Amount, to);

            if (from.Unit.Equals(VolumeUnit.Liters) && to.Equals(VolumeUnit.Gallons))
                return new Volume(from.Amount * _gals_In_1_Ltr, to);
            if (from.Unit.Equals(VolumeUnit.Gallons) && to.Equals(VolumeUnit.Liters))
                return new Volume(from.Amount / _gals_In_1_Ltr, to);
            if (from.Unit.Equals(VolumeUnit.Liters) && to.Equals(VolumeUnit.Barrels))
                return new Volume(from.Amount * _brls_In_1_Ltr, to);
            if (from.Unit.Equals(VolumeUnit.Barrels) && to.Equals(VolumeUnit.Liters))
                return new Volume(from.Amount / _brls_In_1_Ltr, to);
            if (from.Unit.Equals(VolumeUnit.Barrels) && to.Equals(VolumeUnit.Gallons))
                return new Volume(from.Amount * _gals_In_1_Brl, to);
            if (from.Unit.Equals(VolumeUnit.Gallons) && to.Equals(VolumeUnit.Barrels))
                return new Volume(from.Amount / _gals_In_1_Brl, to);
            throw new NotImplementedException();
        }
        private static VolumeConversion _instance = new VolumeConversion();
        public static VolumeConversion Instance {
            get { return _instance; }
        }
    }
}
