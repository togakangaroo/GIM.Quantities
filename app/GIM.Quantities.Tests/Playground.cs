using System;
using System.Collections.Generic;

namespace GIM.Quantities {
    public class Playground {
        public class TestCustomFormatter : ICustomFormatter {

            public string Format(string format, object arg, IFormatProvider formatProvider) {
                "Format: {0}".Use(format).Output();
                return "{0}, {1}, {2}".Use(format, arg, formatProvider);
            }

        }
        public class TestFormatProvider : IFormatProvider {

            public object GetFormat(Type formatType) {
                formatType.ToString().Output();
                return typeof(ICustomFormatter).IsAssignableFrom(formatType) ? new TestCustomFormatter() : null;
            }
        }
        public void Test() {
            (5.2d).ToString("n4").Output();
            //String.Format(new TestFormatProvider(), "> {0:n0:n1}", 9876.541).Output();
        }
    }
}
