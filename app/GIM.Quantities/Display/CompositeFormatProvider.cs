using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class CompositeFormatProvider : IFormatProvider {
        private IFormatProvider[] _children;
        public CompositeFormatProvider(IEnumerable<IFormatProvider> children) {
            _children = children.IsNull() ? new IFormatProvider[0] : children.ToArray();
        }
        public CompositeFormatProvider() : this(null) { }
        public void Add(params IFormatProvider[] providers) {
            _children = _children.Concat(providers).ToArray();
        }
        public object GetFormat(Type formatType) {
            return _children.FirstOrDefault(x => !x.GetFormat(formatType).IsNull())
                .IfNotNull(x=>x.GetFormat(formatType));
        }
    }
}
