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
        //[Test] public void Cannot_add_volumes_and_masses() {
        //    Assert.Throws<InvalidOperationException>(() => x = 1.Pounds() + 20.Liters());
        //}
        [Test] public void Cannot_quantities_to_null() {
            Assert.Throws<ArgumentNullException>(() => x = 1.Pounds() + null);
            Assert.Throws<ArgumentNullException>(() => x = null + 1.Pounds());
        }
    }
}
