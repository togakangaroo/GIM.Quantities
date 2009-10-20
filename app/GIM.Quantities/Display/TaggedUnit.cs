using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class TaggedUnit {
        List<object> _tags = new List<object>();
        public IEnumerable<object> Tags { get { return _tags; } }
        public UnitOfMeasure Unit { get; private set; }
        public TaggedUnit(UnitOfMeasure unit, params object[] tags) {
            Unit = unit;
            _tags.AddRange(tags);
        }
    }
}
