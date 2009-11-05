using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Arithmetic {
    [Category("Acceptance Spec")]
    public class Addition {
        Quantity x;
        [Test] public void Can_add_same_masses_correctly() {
            (10.Pounds() + 20.Pounds()).ShouldEqual(30.Pounds());
        }
        [Test] public void Can_add_same_volumes_correctly() {
            (1.Liters() + 20.Liters()).ShouldEqual(21.Liters());
        }
        [Test] public void Can_add_same_densities_with_identical_denominators() {
            (new Density(10.Pounds(), 2.Gallons()) + new Density(5.Pounds(), 2.Gallons())).ShouldEqual(new Density(15.Pounds(), 2.Gallons()));
        }
        [Test] public void Can_add_same_finite_densities_with_different_denominators() {
            (10.Pounds().Per(2.Gallons()) + 20.Pounds().Per(1.Gallons())).ShouldEqual(
                new Density(50.Pounds(), 2.Gallons()));
        }
        [Test] public void Can_add_same_infinite_densities_with_different_denominators() {
            (10.Pounds().Per(2.Gallons()) + 5.Pounds().Per(3.Gallons())).ShouldEqual(
                new Density((40d/6).Pounds(), 1.Gallons()));
        }
        [Test] public void Cannot_add_null_to_mass() {
            Assert.Throws<ArgumentNullException>(() => x = 1.Pounds() + null);
            Assert.Throws<ArgumentNullException>(() => x = null + 1.Pounds());
        }
        [Test] public void Cannot_add_null_to_volume() {
            Assert.Throws<ArgumentNullException>(() => x = 1.Gallons() + null);
            Assert.Throws<ArgumentNullException>(() => x = null + 1.Gallons());
        }
        [Test] public void Cannot_add_null_to_density() {
            Assert.Throws<ArgumentNullException>(() => x = 1.Pounds().Per(1.Gallons()) + null);
            Assert.Throws<ArgumentNullException>(() => x = null + 1.Pounds().Per(1.Gallons()));
        }
        [Test] public void Can_subtract_same_masses_correctly() {
            (25.Pounds() - 20.Pounds()).ShouldEqual(5.Pounds());
        }
        [Test] public void Can_subtract_same_volumes_correctly() {
            (21.Liters() - 2.Liters()).ShouldEqual(19.Liters());
        }
        [Test] public void Can_subtract_same_densities_with_identical_denominators() {
            (new Density(10.Pounds(), 2.Gallons()) - new Density(5.Pounds(), 2.Gallons()))
                .ShouldEqual(new Density(5.Pounds(), 2.Gallons()));
        }
        [Test] public void Can_subtract_same_finite_densities_with_different_denominators() {
            (40.Pounds().Per(2.Gallons()) - 20.Pounds().Per(1.Gallons())).ShouldEqual(
                new Density(0.Pounds(), 1.Gallons()));
        }
        [Test] public void Can_subtract_same_infinite_densities_with_different_denominators() {
            (10.Pounds().Per(2.Gallons()) - 5.Pounds().Per(3.Gallons())).ShouldEqual(
                new Density(((10d * 3d - 5d * 2d) / 6d).Pounds(), 1.Gallons()));
        }
        [Test]
        public void Cannot_subtract_null_from_mass() {
            Assert.Throws<ArgumentNullException>(() => x = 1.Pounds() - null);
            Assert.Throws<ArgumentNullException>(() => x = null - 1.Pounds());
        }
        [Test]
        public void Cannot_subtract_null_from_volume() {
            Assert.Throws<ArgumentNullException>(() => x = 1.Gallons() - null);
            Assert.Throws<ArgumentNullException>(() => x = null - 1.Gallons());
        }
        [Test]
        public void Cannot_subtract_null_from_density() {
            Assert.Throws<ArgumentNullException>(() => x = 1.Pounds().Per(1.Gallons()) - null);
            Assert.Throws<ArgumentNullException>(() => x = null - 1.Pounds().Per(1.Gallons()));
        }
    }
}
