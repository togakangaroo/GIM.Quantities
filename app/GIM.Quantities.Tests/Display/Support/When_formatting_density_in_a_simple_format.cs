using System;
using NUnit.Framework;
using GIM.Quantities.Display;

namespace GIM.Quantities.Tests.Display.Support {
    [TestFixture]
    [Category("QuantityTests")]
    public class When_formatting_density_in_a_simple_format {
        readonly SimpleDensityFormatter _formatter = new SimpleDensityFormatter();
        readonly Density lbPerGal5 = new Density(10.Pounds(), 2.Gallons());
        readonly Density lbPerGal1 = new Density(1.Pounds(), 1.Gallons());
        readonly Density kgPerLtr2_1 = new Density(2.Kilograms(), 1.Liters());
        [Test]
        public void when_numerator_is_singular_will_be_formatted_that_way() {
            string pattern = "{0:n0} {1:long}";
            _formatter.Format(pattern, lbPerGal1).ShouldEqual("1 pound per gallon", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_get_single_numeric_value_only_with_custom_formatting() {
            string pattern = "{0:n3}";
            _formatter.Format(pattern, lbPerGal5).ShouldEqual("5.000", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_add_custom_formatting_between_number_and_unit() {
            string pattern = "{0:n1} - {1}";
            _formatter.Format(pattern, lbPerGal5).ShouldEqual("5.0 - lbs/gal", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_custom_format_numeric_component() {
            string pattern = "{0:n0} {1}";
            _formatter.Format(pattern, lbPerGal5).ShouldEqual("5 lbs/gal", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_custom_format_unit_component() {
            string pattern = "{0:n2} {1:long}";
            _formatter.Format(pattern, lbPerGal5).ShouldEqual("5.00 pounds per gallon", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_output_multiple_formats_of_density_unit() {
            string pattern = "{0:n2} {1:short} ({1:long})";
            _formatter.Format(pattern, kgPerLtr2_1).ShouldEqual("2.00 kgs/ltr (kilograms per liter)", "Pattern: {0}".Use(pattern));
        }
    }
}
