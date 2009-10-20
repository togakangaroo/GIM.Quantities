using System;

namespace GIM.Quantities {
    public static class StringExtensions {
        public static Action<string> OutputAction = s => System.Diagnostics.Debug.WriteLine(s);
        public static string Use(this string format, params object[] args) {
            return String.Format(format, args);
        }
        public static void Output(this string msg) {
            OutputAction(msg);
        }
    }
    public static class ObjectExtensions {
        public static bool IsNull(this object obj) {
            return object.ReferenceEquals(null, obj);
        }
        public static R IfNotNull<T, R>(this T obj, Func<T, R> func) {
            if (obj.IsNull()) return default(R);
            return func(obj);
        }
    }

}
