    using System;
    using NUnit.Framework;

    namespace GIM.Quantities.Tests.Display {
        [Category("Acceptance Spec")]
        public class When_formatting_density_with_ToString : StringFormatQuantityTests {
            Density lbPerGal5 = new Density(10.Pounds(), 2.Gallons());
            Density lbPerGal1 = new Density(1.Pounds(), 1.Gallons());
            Density kgPerLtr2_1 = new Density(2.Kilograms(), 1.Liters());
            [Test]
            public void default_is_n2_single_number_short_units() {
                lbPerGal5.ToString().ShouldEqual("5.00 lbs/gal");
            }
            [Test] public void when_numerator_is_singular_will_be_formatted_that_way() {
                lbPerGal1.ToString("{0:n0} {1:long}").ShouldEqual("1 pound per gallon");
            }
            [Test]
            public void can_get_single_numeric_value_only_with_custom_formatting() {
                string pattern = "{0:n3}";
                lbPerGal5.ToString(pattern).ShouldEqual("5.000", "Pattern: {0}".Use(pattern));
            }
            [Test]
            public void can_add_custom_formatting_between_number_and_unit() {
                string pattern = "{0:n1} - {1}";
                lbPerGal5.ToString(pattern).ShouldEqual("5.0 - lbs/gal", "Pattern: {0}".Use(pattern));
            }
            [Test]
            public void can_custom_format_numeric_component() {
                string pattern = "{0:n0} {1}";
                lbPerGal5.ToString(pattern).ShouldEqual("5 lbs/gal", "Pattern: {0}".Use(pattern));
            }
            [Test]
            public void can_custom_format_unit_component() {
                string pattern = "{0:n2} {1:long}";
                lbPerGal5.ToString(pattern).ShouldEqual("5.00 pounds per gallon", "Pattern: {0}".Use(pattern));
            }
            [Test]
            public void can_custom_format_each_unit_component() {
                string pattern = "{0:n2} {1:short} per {2:long}";
                lbPerGal5.ToString(pattern).ShouldEqual("5.00 lbs per gallon", "Pattern: {0}".Use(pattern));
            }
            [Test]
            public void can_display_all_components_separately_when_volume_quantity_is_plural() {
                string pattern = "{0}/{3} {1}/{2}";
                lbPerGal5.ToString(pattern).ShouldEqual("10/2 lbs/gals", "Pattern: {0}".Use(pattern));
            }
            [Test]
            public void can_display_all_components_separately_when_volume_quantity_is_single() {
                string pattern = "{0} {1} for every {2}";
                kgPerLtr2_1.ToString(pattern).ShouldEqual("2 kgs for every ltr", "Pattern: {0}".Use(pattern));
            }
            [Test]
            public void can_output_complicated_units_of_measure_only() {
                string pattern = "{1:long} in a {2:long}";
                kgPerLtr2_1.ToString(pattern).ShouldEqual("kilograms in a liter", "Pattern: {0}".Use(pattern));
            }
            [Test]
            public void can_output_multiple_formats_of_density_unit() {
                string pattern = "{0:n2} {1:short} ({1:long})";
                kgPerLtr2_1.ToString(pattern).ShouldEqual("2.00 kgs/ltr (kilograms per liter)", "Pattern: {0}".Use(pattern));
            }
        }
    }
