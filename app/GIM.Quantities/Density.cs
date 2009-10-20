using System;
using GIM.Quantities.Display;
using System.Text.RegularExpressions;

namespace GIM.Quantities {
    public class Density {
        private readonly Mass _mass;
        private readonly Volume _volume;
        public Density(Mass mass, Volume volume) {
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
            return ToString("{0} {1}");
        }
        public string ToString(string format) {
            var numPlaceholders = new Regex(@"{\d+(:\w+)?}").Matches(format).Count;
            return numPlaceholders.ToString();
        }

    }
}
