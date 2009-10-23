using System;
using System.Text.RegularExpressions;
using GIM.Quantities.Display;

namespace GIM.Quantities {
    public class Density : SimpleQuantity<DensityUnit> {
        private readonly Mass _mass;
        private readonly Volume _volume;
        CompositeFormatProvider _compositeFormatProvider = new CompositeFormatProvider();

        public Density(Mass mass, Volume volume) : 
            base(mass.Amount/volume.Amount, new DensityUnit(mass.Unit, volume.Unit)) {
            _volume = volume;
            _mass = mass;
            _compositeFormatProvider = new CompositeFormatProvider(new IFormatProvider[] {
                new CorrectPluralityFormatProvider(this),
                new CorrectPluralityFormatProvider(Mass),
                new CorrectPluralityFormatProvider(Volume),
            });
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
            var placeholderMatcher = new Regex(@"{\d+(:\w+)*}");
            var placeholders = placeholderMatcher.Matches(format);
            if (placeholders.Count == 1 || placeholders.Count == 2)
                return String.Format(_compositeFormatProvider, format, Amount, Unit);
            else if (placeholders.Count == 3)
                return String.Format(_compositeFormatProvider, format, Amount, Mass.Unit, Volume.Unit, UnitPlurality.Single.Example);
            return String.Format(_compositeFormatProvider, format, Mass.Amount, Mass.Unit, Volume.Unit, Volume.Amount);
        }

    }
}
