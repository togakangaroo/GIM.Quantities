using System;
using NUnit.Framework;
using GIM.Quantities.Display;

namespace GIM.Quantities.Tests.Display {
    [Category("Acceptance Spec")]
    public class When_formatting_mass_with_ToString : StringFormatQuantityTests {
        readonly Mass lb1 = new Mass(1, MassUnit.Pounds);
        readonly Mass lb100 = new Mass(100, MassUnit.Pounds);
        readonly Mass lb1000 = new Mass(1000, MassUnit.Pounds);
        readonly Mass lb9876p543 = new Mass(9876.543, MassUnit.Pounds);
        readonly Mass kg1000 = new Mass(1000, MassUnit.Kilograms);
        [Test] public void can_specify_short_format() {
            lb100.ToString("{0} - {1:short}").ShouldEqual("100 - lbs");
        }
        [Test] public void can_specify_long_format() {
            lb100.ToString("{0} - {1:long}").ShouldEqual("100 - pounds");
        }
        [Test] public void default_is_short_format() {
            lb100.ToString().ShouldEqual("100 lbs");
        }
        [Test] public void unit_default_is_short_format() {
            lb100.ToString("{0:n2} ({1})").ShouldEqual("100.00 (lbs)");
        }
        [Test] public void default_will_have_comma_placeholders() {
            lb1000.ToString().ShouldEqual("1,000 lbs");
        }
        [Test] public void can_round_decimal_places_using_number_formatting() {
            lb9876p543.ToString("{0:n2} {1:long}").ShouldEqual("9,876.54 pounds");
        }
        [Test] public void can_pad_decimal_places_using_number_formatting() {
            lb1.ToString("{0:n2} {1:short}").ShouldEqual("1.00 lb");
        }
        [Test] public void can_show_kilograms_as_well_as_lbs() {
            lb1000.ToString().ShouldEqual("1,000 lbs");
            kg1000.ToString().ShouldEqual("1,000 kgs");
        }
        [Test] public void can_show_number_only() {
            lb1.ToString("{0}").ShouldEqual("1");
        }
        [Test] public void can_show_unit_only() {
            lb1.ToString("{1}").ShouldEqual("lb");
        }
        [Test] public void format_with_extra_placeholders_will_throw_error() {
            Assert.Throws<FormatException>(() =>
                lb1.ToString("{0} {1} {2}"));
        }
        [Test] public void format_with_unknown_unit_display_format_throw_error() {
            Assert.Throws<UnknownUnitDisplayFormatException>(()=>
                lb1.ToString("{0} {1:test-format}"));
        }
    }
}
