using System;

namespace GIM.Quantities.Display {
    public interface IPluralizationConvention {
        string Convert(string word, UnitPlurality desiredPlurality);
    }
}
