using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Arithmetic {
    [Category("Acceptance Spec")]
    public class Equality_of_simple_quantities {
        [Test] public void Equivalent_masses_are_equal() {
            Assert.AreEqual(10.Kilograms(), new Mass(10, MassUnit.Kilograms)); 
        }
        [Test] public void Equivalent_volumes_are_equal() {
            Assert.AreEqual(100.Liters(), new Volume(100, VolumeUnit.Liters)); 
        }
        [Test] public void Different_amount_same_unit_masses_are_not_equal() {
            Assert.AreNotEqual(9.Kilograms(), 10.Kilograms()); 
        }
        [Test] public void Different_amount_same_unit_volumes_are_not_equal() {
            Assert.AreNotEqual(9.Gallons(), 10.Gallons()); 
        }
        [Test] public void Mass_will_not_equal_null() {
            Assert.AreNotEqual(9.Kilograms(), null); 
        }
        [Test] public void Volume_will_not_equal_null() {
            Assert.AreNotEqual(9.Gallons(), null); 
        }
        [Test] 
        [ExpectedException(typeof(NotImplementedException))]
        public void Different_unit_masses_cannot_be_compared() {
            var b = 10.Pounds() == new Mass(10, MassUnit.Kilograms); 
        }
        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void Different_unit_volumes_cannot_be_compared() {
            var b = 100.Liters() == new Volume(100, VolumeUnit.Barrels); 
        }
    }
    [Category("Acceptance Spec")]
    public class Equality_of_densities {
        [Test] public void Densities_with_equivalent_numerators_and_denominators_are_equal() {
            Assert.AreEqual(10.Pounds().Per(2.Barrels()), 10.Pounds().Per(2.Barrels()));
        }
        [Test] public void Densities_with_equivalent_units_and_finite_amounts_are_equal() {
            Assert.AreEqual(10.Pounds().Per(2.Barrels()), new Density(20.Pounds(), 4.Barrels()));
        }
        [Test] public void Densities_with_equivalent_units_and_infinite_amounts_are_equal() {
            Assert.AreEqual(10.Pounds().Per(3.Barrels()), (10d/3).Pounds().Per(x=>x.Barrels()));
        }
        [Test] public void Density_does_not_equal_null() {
            Assert.AreNotEqual(10.Pounds().Per(3.Barrels()), null);
        }
        [Test] public void Density_with_equivalent_units_and_different_amounts_are_not_equal() {
            Assert.AreNotEqual(10.Pounds().Per(2.Barrels()), 1.Pounds().Per(1.Barrels()));
        }
        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void Different_numerator_units_cannot_be_compared() {
            var b  = 10.Pounds().Per(1.Liters()) == 10.Kilograms().Per(1.Liters());
        }
        [Test]
        [ExpectedException(typeof(NotImplementedException))]
        public void Different_denominator_units_cannot_be_compared() {
            var b  = 10.Kilograms().Per(1.Gallons()) == 10.Kilograms().Per(1.Liters());
        }
    }
}
