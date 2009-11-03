using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Arithmetic {
    public class Addition {
        [Test]
        public void Can_add_same_masses_correctly() {
            (10.Pounds() + 20.Pounds()).ShouldEqual(30.Pounds());
        }
    }
}
