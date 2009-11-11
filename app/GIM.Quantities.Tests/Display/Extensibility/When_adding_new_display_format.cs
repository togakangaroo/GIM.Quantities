using System;
using System.Linq;
using NUnit.Framework;
using GIM.Quantities.Display;

namespace GIM.Quantities.Tests.Display.Extensibility {
    [TestFixture]
    [Category("Acceptance Spec")]
    public class When_adding_new_display_format {
 
        class TestDisplay1 : IDisplayUnits {
            public string GetUnitDisplayFor(UnitAtPlularity unitAtPlularity) {return "test1"; }
        }
        [SetUp]
        public void Setup() {
            ProvideUnitDisplaysFactory.Instance
                       .Add(x => x.Instance(new TestDisplay1()).WithTags("test"));
        }
        [Test] public void can_use_it_in_a_pluralized_form() {
            Assert.That(10.Pounds().ToString("{0} {1:test}"), Is.EqualTo("10 test1"));
        }
        [Test] public void can_use_it_in_a_singular_form() {
            Assert.That(1.Liters().ToString("{0} {1:test}"), Is.EqualTo("1 test1"));
        }
         [TearDown]
         public void TearDown() {
            ProvideUnitDisplaysFactory.ResetToDefault();
         }
    }
}
