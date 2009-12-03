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
        [Test]
        public void can_use_compound_digit_extension_method_constructor() {
            Density d = 10.Kilograms().Per(3.Liters());
            d.Amount.ShouldEqual(10d/3);
            d.Unit.ShouldEqual(DensityUnit.Of(MassUnit.Kilograms).Per(VolumeUnit.Liters));
        }

        [Test] public void can_use_simple_digit_extension_method_constructor() {
            Density d = 7.63d.Pounds().Per(u => u.Gallons());
            d.Amount.ShouldEqual(7.63);
            d.Unit.ShouldEqual(DensityUnit.Of(MassUnit.Pounds).Per(VolumeUnit.Gallons));
        }
    }
}
