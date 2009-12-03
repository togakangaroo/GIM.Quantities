using System;
using NUnit.Framework;

namespace GIM.Quantities.Tests.Conversion {
    public class Volume_conversion {
        [Test]
        public void Can_explicitly_convert_ltrs_to_gals() {
            1.Liters().In(VolumeUnit.Gallons).ShouldEqualToPrecision(0.264172052.Gallons(), 8);
        }
        [Test]
        public void Can_explicitly_convert_gals_to_ltrs() {
            1.Gallons().In(VolumeUnit.Liters).ShouldEqualToPrecision(3.78541178.Liters(), 7);
        }
        [Test]
        public void Can_explicitly_convert_ltrs_to_brls() {
            1.Liters().In(VolumeUnit.Barrels).ShouldEqualToPrecision(0.00852167911.Barrels(), 8);
        }
        [Test]
        public void Can_explicitly_convert_brls_to_ltrs() {
            1.Barrels().In(VolumeUnit.Liters).ShouldEqualToPrecision(117.347765.Liters(), 6);
        }
        [Test]
        public void Can_explicitly_convert_brls_to_gals() {
            1.Barrels().In(VolumeUnit.Gallons).ShouldEqualToPrecision(31.Gallons(), 6);
        }
        [Test]
        public void Can_explicitly_convert_gals_to_brls() {
            1.Gallons().In(VolumeUnit.Barrels).ShouldEqualToPrecision(0.0322580645.Barrels(), 8);
        }

        [Test]
        public void Can_explicitly_convert_gals_to_gals() {
            3.Gallons().In(VolumeUnit.Gallons).ShouldEqual(3.Gallons());
        }
        [Test]
        public void Can_explicitly_convert_ltrs_to_gals_with_extension() {
            1.Liters().In(x => x.Gallons()).ShouldEqualToPrecision(0.264172052.Gallons(), 8);
        }
    }
}
