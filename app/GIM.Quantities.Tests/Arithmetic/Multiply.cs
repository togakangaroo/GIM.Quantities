using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Arithmetic {
    [Category("Acceptance Spec")]
    public class Multiply {
        [Test] public void Can_multiply_mass_correctly() {
            (2*10.Pounds()).ShouldEqual(20.Pounds());
        }
        [Test] public void Can_multiply_volume_correctly() {
            (1.5 * 20.Liters()).ShouldEqual(30.Liters());
        }
        [Test] public void Can_multiply_density_correctly() {
            (10.Pounds().Per(1.Gallons()) * .5d).ShouldEqual(new Density(5.Pounds(), 1.Gallons()));
        }
        [Test] public void Can_divide_mass_correctly() {
            ((10d).Pounds() / 3d).ShouldEqual((10d / 3d).Pounds());
        }
        [Test] public void Can_divide_volume_correctly() {
            (20.Liters()/.5).ShouldEqual(40.Liters());
        }
        [Test] public void Can_divide_density_correctly() {
            (10.Pounds().Per(1.Gallons()) / 2d).ShouldEqual(new Density(5.Pounds(), 1.Gallons()));
        }
        [Test] public void Cant_divide_volume_by_zero() {
            Assert.Throws<DivideByZeroException>(delegate { var _ = 20.Liters() / 0; });
        }
        [Test]
        public void Cant_divide_mass_by_zero() {
            Assert.Throws<DivideByZeroException>(delegate { var _ = 20.Kilograms() / 0; });
        }
        [Test] public void Cant_divide_density_by_zero() {
            Assert.Throws<DivideByZeroException>(delegate{var _=10.Pounds().Per(1.Gallons()) / 0;});
        }
    }
}
