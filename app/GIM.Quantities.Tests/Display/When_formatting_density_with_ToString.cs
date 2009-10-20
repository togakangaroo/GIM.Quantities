using System;
using NUnit.Framework;
using GIM.Quantities.Display;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Tests.Display {
    public class When_formatting_density_with_ToString {
        Density lbPerGal5 = new Density(10.Pounds(), 2.Gallons());
        [Test] public void default_is_n2_single_number_short_units() {
            lbPerGal5.ToString().ShouldEqual("5.00 lbs/gal");
        }
        [Test]
        public void can_get_single_numeric_value_only_with_custom_formatting() {
            string pattern = "{0:n3}";
            lbPerGal5.ToString(pattern).ShouldEqual("5.000", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_add_custom_formatting_between_number_and_unit() {
            string pattern = "{0} - {1}";
            lbPerGal5.ToString(pattern).ShouldEqual("5.00 - lbs/gal", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_custom_format_numeric_component() {
            string pattern = "{0:n0} {1}";
            lbPerGal5.ToString(pattern).ShouldEqual("5 lbs/gal", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_custom_format_unit_component() {
            string pattern = "{0} {1:long}";
            lbPerGal5.ToString(pattern).ShouldEqual("5.00 pounds per gallon", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_custom_format_each_unit_component() {
            string pattern = "{0} {1:short} per {2:long}";
            lbPerGal5.ToString(pattern).ShouldEqual("5.00 lbs per gallon", "Pattern: {0}".Use(pattern));
        }
        [Test]
        public void can_display_all_components_separately() {
            string pattern = "{0}/{3} {1}/{2}";
            lbPerGal5.ToString(pattern).ShouldEqual("10/2 lbs/gal", "Pattern: {0}".Use(pattern));
        }

    }
}
