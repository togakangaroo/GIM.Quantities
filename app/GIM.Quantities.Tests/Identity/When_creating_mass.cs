using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Identity {
    public class When_creating_mass {
        [Test] public void pounds_gets_created_properly() {
            var q = new Mass(1500, MassUnit.Pounds);
            q.Amount.ShouldEqual(1500);
            q.Unit.ShouldEqual(MassUnit.Pounds);
        }
        [Test]
        public void can_use_extension_methods() {
            var q = 1500.Pounds();
            q.ShouldBeType<Mass>();
            q.Amount.ShouldEqual(1500);
            q.Unit.ShouldEqual(MassUnit.Pounds);
        }
    }
}