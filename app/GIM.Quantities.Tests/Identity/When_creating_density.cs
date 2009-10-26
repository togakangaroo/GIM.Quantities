using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Identity {
    [Category("Acceptance Spec")]
    public class When_creating_density {
        [Test] public void can_use_mass_volume_constructor() {
            Mass m = new Mass(10, MassUnit.Pounds);
            Volume v = new Volume(2, VolumeUnit.Gallons);
            var d = new Density(m, v);
            d.Mass.ShouldEqual(m);
            d.Volume.ShouldEqual(v);
        }
    }
}
