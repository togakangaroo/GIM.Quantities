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
        public void Cant_divide_mass_by_zero() {
            Assert.Throws<DivideByZeroException>(delegate{ var _=30.Pounds() / 0.Pounds();});
        }
        [Test]
        public void Cant_divide_volume_by_zero() {
            Assert.Throws<DivideByZeroException>(delegate { var _ = 30.Liters() / 0.Liters(); });
        }
    }
}
