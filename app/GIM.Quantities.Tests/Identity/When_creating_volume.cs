using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Identity {
    [Category("Acceptance Spec")]
    public class When_creating_volume {
        [Test]
        public void gallons_instantiated_properly() {
            var g = new Volume(1000, VolumeUnit.Gallons);
            g.Amount.ShouldEqual(1000);
            g.Unit.ShouldEqual(VolumeUnit.Gallons);
        }
        [Test]
        public void can_use_extension_methods() {
            var q = 1500.Gallons();
            q.ShouldBeType<Volume>();
            q.Amount.ShouldEqual(1500);
            q.Unit.ShouldEqual(VolumeUnit.Gallons);
        }
    }
}
