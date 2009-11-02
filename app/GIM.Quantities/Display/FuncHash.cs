using System;
using System.Collections.Generic;
using System.Linq;

namespace GIM.Quantities.Display {
    public class FuncHash<SELECTOR_INPUT, FUNCTION_INPUT, FUNCTION_OUTPUT> {
        IDictionary<Func<SELECTOR_INPUT, bool>, Func<FUNCTION_INPUT, FUNCTION_OUTPUT>> _hash;
        public FuncHash(IDictionary<Func<SELECTOR_INPUT, bool>, Func<FUNCTION_INPUT, FUNCTION_OUTPUT>> hash) {
            _hash = new Dictionary<Func<SELECTOR_INPUT, bool>, Func<FUNCTION_INPUT, FUNCTION_OUTPUT>>(hash);
        }
        public FUNCTION_OUTPUT ExecuteFirstOrDefault(SELECTOR_INPUT selectOn, FUNCTION_INPUT funcInput) {
            var func = _hash.FirstOrDefault(kv => kv.Key(selectOn)).IfNotNull(kv => kv.Value);
            if (func.IsNull())
                return default(FUNCTION_OUTPUT);
            return func(funcInput);
        }
    }
}
