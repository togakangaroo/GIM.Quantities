using System;
using NUnit.Framework;
using GIM.Quantities.Display;
using System.Text.RegularExpressions;

namespace GIM.Quantities.Tests.Display {
    public class UnitDisplayRepositoryTests {
        private UnitsDisplayRepository _repository;
        public UnitDisplayRepositoryTests() {
            _repository = new UnitsDisplayRepository();
            _repository.Add(x => x.Instance(new TestDisplay1()).WithTags(new Regex(@"regex-\d+")))
                       .Add(x => x.Instance(new TestDisplay2()).WithTags("test2a","test2b"))
                       .Add(x=>x.Instance(new LongUnitsDisplay()).WithTags("long").DefaultFor<MassUnit>())
                       .Add(x=>x.Instance(new ShortUnitsDisplay()).WithTags("short").DefaultFor<UnitOfMeasure>());
        }
        class TestDisplay1 : IDisplayUnits {
            public string GetUnitDisplayFor(double amount, UnitOfMeasure _unit) { return ""; }
            public string GetUnitDisplayFor(UnitAtPlularity unitAtPlularity) { return "test1"; }
        } 
        class TestDisplay2 : IDisplayUnits {
            public string GetUnitDisplayFor(double amount, UnitOfMeasure _unit) { return ""; }
            public string GetUnitDisplayFor(UnitAtPlularity unitAtPlularity) { return "test1"; }
        } 
        [Test] public void Can_resolve_correct_formatter_by_tag() {
            _repository.Get("short", MassUnit.Kilograms).ShouldBeType<ShortUnitsDisplay>(); }
        [Test] public void Resolving_by_tag_is_case_insensitve() {
            _repository.Get("ShoRt", MassUnit.Kilograms).ShouldBeType<ShortUnitsDisplay>(); }
        [Test] public void Resolving_by_several_tags() {
            _repository.Get("test2a", MassUnit.Kilograms).ShouldBeType<TestDisplay2>();
            _repository.Get("test2b", MassUnit.Kilograms).ShouldBeType<TestDisplay2>();
        }
        [Test] public void Resolving_by_regex_tag() {
            _repository.Get("regex-1234", MassUnit.Kilograms).ShouldBeType<TestDisplay1>(); }
        [Test] public void Can_resolve_specific_default() {
            _repository.Get(null, MassUnit.Pounds).ShouldBeType<LongUnitsDisplay>(); }
        [Test] public void Can_resolve_catch_all_default_when_no_tag() {
            _repository.Get(null, VolumeUnit.Gallons).ShouldBeType<ShortUnitsDisplay>(); }
        [Test] public void Can_resolve_catch_all_default_when_empty_tag() {
            _repository.Get(String.Empty, VolumeUnit.Gallons).ShouldBeType<ShortUnitsDisplay>(); }
        [Test] public void Throw_error_if_tag_does_not_match() {
            AssertThat.Throws<InvalidOperationException>(()=>
            _repository.Get("not-a-real-tag", VolumeUnit.Gallons).ShouldBeType<ShortUnitsDisplay>()); }
    }
}
