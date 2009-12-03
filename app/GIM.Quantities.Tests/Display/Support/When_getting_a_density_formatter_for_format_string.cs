using System;
using System.Collections.Generic;
using NUnit.Framework;
using GIM.Quantities.Display;

namespace GIM.Quantities.Tests.Display.Support {
    [TestFixture]
    [Category("QuantityTests")]
    public class When_getting_a_density_formatter_for_format_string {
        DensityFormatterFactory _selector = new DensityFormatterFactory();
        [Test]
        public void returns_SimpleDensityFormatter() {
            new List<string> { "", "a", "a {0}", "{1}", "{0} {1}", "{0} abc {1:short}", "{0} {0}", "{0} {1} {0}", "{0} {1} {0} abc {1}", }
            .ForEach(p => 
                Assert.That(
                    _selector.GetForPattern(p), Is.InstanceOf<SimpleDensityFormatter>(), 
                    "Pattern: {0}".Use(p)));
        }
        [Test]
        public void returns_CompoundUnitDensityFormatter() {
            new List<string> { "{0} {1} {2}", "{0} {1} {2}", "{0} {1} {2} {2}", "{2}", "{0} {2}", "{2:short} abc {0}", }
            .ForEach(p =>
                Assert.That(
                    _selector.GetForPattern(p), Is.InstanceOf<CompoundUnitDensityFormatter>(),
                    "Pattern: {0}".Use(p)));
        }
        [Test]
        public void returns_CompoundDensityFormatter() {
            new List<string> { "{0} {1} {2} {3}", "{0} {0} {3} {3}", "{3}", "{2:short} abc {3}", }
            .ForEach(p =>
                Assert.That(
                    _selector.GetForPattern(p), Is.InstanceOf<CompoundDensityFormatter>(),
                    "Pattern: {0}".Use(p)));
        }
        [Test]
        public void throws_error_for_unhandleable_pattern() {
            new List<string> { "{0} {1} {2} {3} {4}", "{0} {1} {2} {4}",}
            .ForEach(p =>
                Assert.Throws<ArgumentException>(()=>_selector.GetForPattern(p), "Pattern: {0}".Use(p)));
        }
    }
}
