using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GIM.Quantities.Display.Registration {
    public class ReadyForDefaultsUnitDisplayRegistration : IUnitDisplayRegistration {
        private IDisplayUnits _unitsDisplay;
        HashSet<Type> _defaultTypes = new HashSet<Type>();
        private Regex _tagMatcher;
        public ReadyForDefaultsUnitDisplayRegistration(IDisplayUnits unitsDisplay, Regex tagMatcher) {
            _tagMatcher = tagMatcher;
            _unitsDisplay = unitsDisplay;
        }
        public IUnitDisplayRegistration DefaultFor<T>() where T : UnitOfMeasure {
            _defaultTypes.Add(typeof(T));
            return this;
        }
        public void RegisterTo(UnitsDisplayRepository repository) {
            repository.Add(_unitsDisplay, _tagMatcher, _defaultTypes);
        }
    }
}
