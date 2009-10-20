using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GIM.Quantities.Display.Registration;

namespace GIM.Quantities.Display {
    public class UnitsDisplayRepository : IProvideUnitDisplays {
        IDictionary<Regex, IDisplayUnits> _displays = new Dictionary<Regex, IDisplayUnits>();
        IDictionary<Type, IDisplayUnits> _defaults = new Dictionary<Type, IDisplayUnits>();
        public UnitsDisplayRepository Add(IDisplayUnits display, Regex tagMatcher, IEnumerable<Type> defaultFor) {
            if (display == null)
                throw new ArgumentNullException("display", "display is null.");
            if (tagMatcher == null)
                throw new ArgumentNullException("tagMatcher", "tags is null.");
            if (defaultFor == null)
                throw new ArgumentNullException("defaultFor", "defaultFor is null.");
            _displays.Add(tagMatcher, display);
            defaultFor.ToList().ForEach(d => {
                if (!typeof(UnitOfMeasure).IsAssignableFrom(d))
                    throw new ArgumentException("Default types must all inherit from UnitOfMeasure but {0} was provided".Use(d.FullName));
                _defaults.Add(d, display);
            });
            return this;
        }
        public virtual UnitsDisplayRepository Add(Func<UnitDisplayRegistrationStarter, IUnitDisplayRegistration> registrationTransform) {
            registrationTransform(new UnitDisplayRegistrationStarter()).RegisterTo(this);
            return this;
        }
        public IDisplayUnits GetByTag(string tag) {
            var d = _displays.FirstOrDefault(kv=>kv.Key.IsMatch(tag)).IfNotNull(kv=>kv.Value);
            if(d.IsNull())
                throw new UnknownUnitDisplayFormatException(tag, this);
            return d;
        }
        public IDisplayUnits Get(string tag, UnitOfMeasure targetUnit) {
            if (String.IsNullOrEmpty(tag))
                if (!_defaults.Any(kv => kv.Key.IsAssignableFrom(targetUnit.GetType())))
                    throw new InvalidOperationException("No tag was provided and no default is available for type {0}".Use(targetUnit));
                else
                    return _defaults.First(kv => kv.Key.IsAssignableFrom(targetUnit.GetType())).Value;
            else
                return GetByTag(tag);
        }
    }
}
