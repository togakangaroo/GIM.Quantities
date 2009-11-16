using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Arithmetic {
    [Category("Acceptance Spec")]
    public class Divide {
        [Test]
        public void Can_divide_two_masses_to_get_a_scalar() {
            (10.Pounds() / 20.Pounds()).ShouldEqual(.5);
        }
        [Test]
        public void Can_divide_two_volumes_to_get_a_scalar() {
            (30.Pounds() / 10.Pounds()).ShouldEqual(3);
        }
        [Test]
        public void Numerator_can_be_zero() {
            (0.Pounds() / 10.Pounds()).ShouldEqual(0);
        }
    }
}
