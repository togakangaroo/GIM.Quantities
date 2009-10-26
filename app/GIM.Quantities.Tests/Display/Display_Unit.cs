using System;
using GIM.Quantities.Display;
using NUnit.Framework;
using System.Collections.Generic;

namespace GIM.Quantities.Tests.Display {
    public abstract class Display_Unit {
        private readonly static IDisplayUnits _long = new LongUnitsDisplay();
        private readonly static IDisplayUnits _short = new ShortUnitsDisplay();

        private Func<UnitOfMeasure> _create;
        private DisplayForms _displayForms;
        public Display_Unit(Func<UnitOfMeasure> create, DisplayForms displayForms) {
            _displayForms = displayForms;
            _create = create;
        }
        [Test]
        public void in_short_plural_form() {
            _create().ToString(_short, UnitPlurality.Plural).ShouldEqual(_displayForms.ShortPlural);
        }
        [Test]
        public void in_short_single_form() {
            _create().ToString(_short, UnitPlurality.Single).ShouldEqual(_displayForms.ShortSingle);
        }
        [Test]
        public void in_long_plural_form() {
            _create().ToString(_long, UnitPlurality.Plural).ShouldEqual(_displayForms.LongPlural);
        }
        [Test]
        public void in_long_single_form() {
            _create().ToString(_long, UnitPlurality.Single).ShouldEqual(_displayForms.LongSingle);
        }
        [Test]
        public void short_format_for_singulars() {
            TestSingularTitle(i => _short.GetUnitDisplayFor(i, _create()), _displayForms.ShortSingle);
        }
        [Test]
        public void short_format_for_plurals() {
            TestPluralTitle(i => _short.GetUnitDisplayFor(i, _create()), _displayForms.ShortPlural);
        }
        [Test]
        public void long_format_for_singulars() {
            TestSingularTitle(i => _long.GetUnitDisplayFor(i, _create()), _displayForms.LongSingle);
        }
        [Test]
        public void long_format_for_plurals() {
            TestPluralTitle(i => _long.GetUnitDisplayFor(i, _create()), _displayForms.LongPlural);
        }
        private void TestSingularTitle(Func<double, string> createTitle, string desiredTitle) {
            new List<double> { -1, 1 }.ForEach(i => createTitle(i).ShouldEqual(desiredTitle, "For input {0}".Use(i)));
        }
        private void TestPluralTitle(Func<double, string> createTitle, string desiredTitle) {
            new List<double> { -10, -3, -1.02, 0, .567, 4, 10000 }.ForEach(i => createTitle(i).ShouldEqual(desiredTitle, "For input {0}".Use(i)));
        }
    }

    public class DisplayForms {
        public DisplayForms(string shortSingle, string shortPlural, string longSingle, string longPlural) {
            ShortSingle = shortSingle;
            ShortPlural = shortPlural;
            LongSingle = longSingle;
            LongPlural = longPlural;
        }
        public string ShortSingle { get; private set; }
        public string ShortPlural { get; private set; }
        public string LongSingle { get; private set; }
        public string LongPlural { get; private set; }
    }

}
