using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Display {
    [Category("Acceptance Spec")]
    public class When_formatting_volume_with_ToString : StringFormatQuantityTests {
        readonly Volume lt1 = 1.Liters();
        readonly Volume lt100 = 100.Liters();
        readonly Volume gal1000 = 1000.Gallons();
        [Test]
        public void can_specify_short_format() {
            lt1.ToString("{0} - {1:short}").ShouldEqual("1 - ltr");
        }
        [Test]
        public void can_specify_long_format() {
            lt1.ToString("{0} - {1:long}").ShouldEqual("1 - liter");
        }
        [Test]
        public void default_is_short_format() {
            lt100.ToString().ShouldEqual("100 ltrs");
        }
        [Test]
        public void can_show_gals_as_well_as_ltrs() {
            lt100.ToString().ShouldEqual("100 ltrs");
            gal1000.ToString().ShouldEqual("1,000 gals");
        }
    }
}
