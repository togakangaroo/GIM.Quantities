using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GIM.Quantities.Display.Registration {
    public class UnitDisplayRegistrationTagsAdder {

        private IDisplayUnits _unitsDisplay;
        public UnitDisplayRegistrationTagsAdder(IDisplayUnits unitsDisplay) {
            _unitsDisplay = unitsDisplay;
        }
        public IUnitDisplayRegistration WithTags(params string[] tags) {
            if (tags.IsNull())
                tags = new[] { String.Empty };
            return new ReadyForDefaultsUnitDisplayRegistration(_unitsDisplay,
                new Regex(
                    String.Join("|",
                        tags.Select(t => "({0})".Use(t)).ToArray())
                    , RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace)
                );
        }

        public IUnitDisplayRegistration WithTags(Regex tagMatcher) {
            return new ReadyForDefaultsUnitDisplayRegistration(_unitsDisplay, tagMatcher);
        }
    }
}
