using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Arithmetic {
    [Category("Acceptance Spec")]
    [Ignore("Not yet ready")]
    public class Addition {
        Quantity x;
        [Test] public void Can_add_same_masses_correctly() {
            (10.Pounds() + 20.Pounds()).ShouldEqual(30.Pounds());
        }
        [Test] public void Can_add_same_volumes_correctly() {
            (1.Liters() + 20.Liters()).ShouldEqual(21.Liters());
        }
        [Test] public void Can_add_same_densitieswith_identical_denominators() {
            (new Density(10.Pounds(), 2.Gallons()) + new Density(5.Pounds(), 2.Gallons())).ShouldEqual(new Density(15.Pounds(), 2.Gallons()));
        }
        [Test] public void Can_add_same_densities_with_different_denominators() {
            (new Density(10.Pounds(), 2.Gallons()) + new Density(5.Pounds(), 3.Gallons())).ShouldEqual(new Density((5+5/3).Pounds(), 1.Gallons()));
        }
        [Test] public void Cannot_add_volumes_and_masses() {
            Assert.Throws<InvalidOperationException>(() => x = 1.Pounds() + 20.Liters());
        }
        [Test] public void Cannot_quantities_to_null() {
            Assert.Throws<InvalidOperationException>(() => x = 1.Pounds() + null);
            Assert.Throws<InvalidOperationException>(() => x = null + 1.Pounds());
        }
    }
}
