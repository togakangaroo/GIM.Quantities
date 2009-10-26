using System;
using System.Linq;
using NUnit.Framework;
using GIM.Quantities.Display;

namespace GIM.Quantities.Tests.Display.Extensibility {
    [TestFixture]
    [Category("Acceptance Spec")]
    public class When_adding_new_display_format {
 
        class TestDisplay1 : IDisplayUnits {
            public string GetUnitDisplayFor(double amount, UnitOfMeasure _unit) { return "test1"; } }
        [Test] public void can_use_it_with_the_exact_case() {
            ProvideUnitDisplaysFactory.Instance
                       .Add(x => x.Instance(new TestDisplay1()).WithTags("test"));
            Assert.That(10.Pounds().ToString("{0} {1:test1}"), Is.EqualTo("10 test1"));
        }
         [TearDown]
         public void TearDown() {
            ProvideUnitDisplaysFactory.ResetToDefault();
         }
    }
}
