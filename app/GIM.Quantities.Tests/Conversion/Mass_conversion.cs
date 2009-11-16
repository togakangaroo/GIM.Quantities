using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Conversion {
    public class Mass_conversion {
        [Test]
        public void Can_explicitly_convert_kgs_to_lbs() {
            1.Kilograms().In(MassUnit.Pounds).ShouldEqualToPrecision(2.20462262.Pounds(), 8);
        }
        [Test]
        public void Can_explicitly_convert_lbs_to_kgs() { 
            1.Pounds().In(MassUnit.Kilograms).ShouldEqualToPrecision(0.45359237.Kilograms(), 8);
        }
        [Test]
        public void Can_explicitly_convert_kilograms_to_kilograms() {
            3.Kilograms().In(MassUnit.Kilograms).ShouldEqual(3.Kilograms());
        }
        [Test]
        public void Can_explicitly_convert_kgs_to_lbs_with_extension() {
            1.Kilograms().In(x=>x.Pounds()).ShouldEqualToPrecision(2.20462262.Pounds(), 8);
        }
    }
}
