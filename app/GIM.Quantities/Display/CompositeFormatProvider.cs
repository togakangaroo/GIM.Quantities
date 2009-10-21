using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class CompositeFormatProvider : IFormatProvider {
        private List<IFormatProvider> _children;
        public CompositeFormatProvider(IEnumerable<IFormatProvider> children) {
            _children = children.IsNull() ? new List<IFormatProvider>() : children.ToList();
        }
        public CompositeFormatProvider() : this(null) { }
        public void Add(params IFormatProvider[] providers) {
            _children.AddRange(providers);
        }
        public object GetFormat(Type formatType) {
            return _children.FirstOrDefault(x => !x.GetFormat(formatType).IsNull()).IfNotNull(x=>x.GetFormat(formatType));
        }
    }
}
