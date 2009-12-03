using System;
using NUnit.Framework;
using GIM.Quantities.Display;

namespace GIM.Quantities.Tests.Display.Support {
    [TestFixture]
    [Category("QuantityTests")]
    public class When_formatting_density_in_a_compound_format {
        readonly CompoundDensityFormatter _formatter = new CompoundDensityFormatter();
        readonly Density lbPerGal5 = new Density(10.Pounds(), 2.Gallons());
        readonly Density kgPerLtr1_1 = new Density(1.Kilograms(), 1.Liters());
        [Test]
        public void can_display_all_components_separately_when_volume_quantity_is_plural() {
            string pattern = "{0}/{3} {1}/{2}";
            _formatter.Format(pattern, lbPerGal5).ShouldEqual("10/2 lbs/gals", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_display_only_amounts() {
            string pattern = "Ratio: {0}:{3}";
            _formatter.Format(pattern, lbPerGal5).ShouldEqual("Ratio: 10:2", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_display_all_components_signular() {
            string pattern = "{0}/{3} {1:long}/{2:long}";
            _formatter.Format(pattern, kgPerLtr1_1).ShouldEqual("1/1 kilogram/liter", "Pattern: {0}".Use(pattern));
        }
    }
    [TestFixture]
    [Category("QuantityTests")]
    public class When_formatting_density_in_a_compound_unit_format {
        readonly CompoundUnitDensityFormatter _formatter = new CompoundUnitDensityFormatter();
        readonly Density lbPerGal5 = new Density(10.Pounds(), 2.Gallons());
        readonly Density kgPerLtr1_2 = new Density(1.Kilograms(), 2.Liters());
        readonly Density kgPerLtr2_2 = new Density(2.Kilograms(), 2.Liters());
        [Test]
        public void can_custom_format_each_unit_component() {
            string pattern = "{0:n2} {1:short} per {2:long}";
            _formatter.Format(pattern, lbPerGal5).ShouldEqual("5.00 lbs per gallon", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void denominator_will_always_be_singular() {
            string pattern = "{1:long} in a {2:long}";
            _formatter.Format(pattern, kgPerLtr1_2).ShouldEqual("kilograms in a liter", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_output_complicated_units_of_measure_repeatedly() {
            string pattern = "{0:n1} {1:short} ({1:long}) per {2:short} ({2:long})";
            _formatter.Format(pattern, kgPerLtr1_2).ShouldEqual("0.5 kgs (kilograms) per ltr (liter)", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_output_singular_numerator_unit() {
            string pattern = "{0:n1} {1:short} per {2:short}";
            _formatter.Format(pattern, kgPerLtr2_2).ShouldEqual("1.0 kg per ltr", "Pattern: {0}".Use(pattern));
        }
    }
}
