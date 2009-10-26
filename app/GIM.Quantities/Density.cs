using System;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public class Density : SimpleQuantity<DensityUnit> {
        private readonly Mass _mass;
        private readonly Volume _volume;

        public Density(Mass mass, Volume volume) : 
            base(mass.Amount/volume.Amount, new DensityUnit(mass.Unit, volume.Unit)) {
            _volume = volume;
            _mass = mass;
        }
        public Mass Mass {
            get {
                return _mass;
            }
        }
        public Volume Volume {
            get {
                return _volume;
            }
        }

        public override string ToString() {
            return ToString("{0:n2} {1}");
        }
        public override string ToString(string format) {
            var factory = new DensityFormatterFactory();
            var formatter = factory.GetForPattern(format);
            return formatter.Format(format, this);
        }

    }
}
