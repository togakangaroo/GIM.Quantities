using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace GIM.Quantities.Display {
    public class DensityFormatterFactory {

        private readonly Regex _has23PlaceholdersRegex = new Regex(@"{[^01](:\w+)*}");
        private readonly Regex _has3PlaceholdersRegex = new Regex(@"{3(:\w+)*}");
        private readonly Regex _hasIllegalPlaceholdersRegex = new Regex(@"{[^0123](:\w+)*}");
        public ICompundQuantityFormatter GetForPattern(string pattern) {
            if (_hasIllegalPlaceholdersRegex.IsMatch(pattern))
                throw new ArgumentException("Pattern '{0}' has incorrect placeholders, please use only placeholders 0-3".Use(pattern));
            else if (_has3PlaceholdersRegex.IsMatch(pattern))
                return new CompoundDensityFormatter();
            else if (_has23PlaceholdersRegex.IsMatch(pattern))
                return new CompoundUnitDensityFormatter();
            return new SimpleDensityFormatter();
        }
    }
    public interface ICompundQuantityFormatter {
        string Format(string format, Density density);

    }
    public class SimpleDensityFormatter : ICompundQuantityFormatter {
        public string Format(string format, Density density) {
            var provider = new CorrectPluralityFormatProvider(density);
            return String.Format(provider, format, density.Amount, density.Unit);
        }
    }
    public class CompoundDensityFormatter : ICompundQuantityFormatter {
        readonly Regex placeholder1 = new Regex(@"{1(:\w+)*}");
        readonly Regex placeholder2 = new Regex(@"{2(:\w+)*}");
        public string Format(string format, Density density) {
            string workingFormat = format;
            var massProvider = new CorrectPluralityFormatProvider(density.Mass);
            foreach (var m in placeholder1.Matches(format).Cast<Match>())
                workingFormat = workingFormat.Replace(m.Value, String.Format(massProvider, m.Value, null, density.Mass.Unit));
            var volumeProvider = new CorrectPluralityFormatProvider(density.Volume);
            foreach (var m in placeholder2.Matches(format).Cast<Match>())
                workingFormat = workingFormat.Replace(m.Value, String.Format(volumeProvider, m.Value, null, null, density.Volume.Unit));

            return String.Format(workingFormat, density.Mass.Amount, null, null, density.Volume.Amount);
        }
    }
    public class CompoundUnitDensityFormatter : ICompundQuantityFormatter {
        readonly Regex placeholder1 = new Regex(@"{1(:\w+)*}");
        readonly Regex placeholder2 = new Regex(@"{2(:\w+)*}");
        public string Format(string format, Density density) {
            string workingFormat = format;
            var massProvider = new CorrectPluralityFormatProvider(new Mass(density.Amount, density.Mass.Unit));
            foreach (var m in placeholder1.Matches(format).Cast<Match>())
                workingFormat = workingFormat.Replace(m.Value, String.Format(massProvider, m.Value, null, density.Mass.Unit));
            var volumeProvider = new CorrectPluralityFormatProvider(new Volume(UnitPlurality.Single.Example, density.Volume.Unit));
            foreach (var m in placeholder2.Matches(format).Cast<Match>())
                workingFormat = workingFormat.Replace(m.Value, String.Format(volumeProvider, m.Value, null, null, density.Volume.Unit));

            return String.Format(workingFormat, density.Amount, null, null);
        }
    }
}
