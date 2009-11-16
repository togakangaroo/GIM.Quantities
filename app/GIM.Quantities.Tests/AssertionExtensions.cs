using System;
using NUnit.Framework;

namespace GIM.Quantities {
	public static class AssertionExtensions {
        public static void ShouldEqualToPrecision<T>(this T obj1, T obj2, int precision) where T : Quantity {
            Assert.AreEqual(obj2.Unit, obj1.Unit, "Cannot compare different units of measure");
            Assert.AreEqual(Math.Round(obj1.Amount, precision), Math.Round(obj2.Amount, precision),
                "Expected {0} == {1}".Use(obj1.ToString("{0:n"+precision+"} {1}"), obj2.ToString("{0:n"+precision+"} {1}"))
                );
        }
        public static void ShouldEqual<T>(this T obj1, T obj2) {
            Assert.AreEqual(obj2, obj1);
        }
        public static void ShouldEqual<T>(this T obj1, T obj2, string msg) {
            Assert.AreEqual(obj2, obj1, msg);
        }
        public static void ShouldNotBeNull<T>(this T obj1) {
            Assert.IsNotNull(obj1);
        }
        public static void ShouldBeType<T>(this object obj) {
            Assert.IsInstanceOf<T>(obj);
        }
    }
    public static class AssertThat {
        public static void Throws<E>(Action action) where E : Exception {
            try {
                action();
                Assert.Fail("Expected exception of type {0} but did not recieve one".Use(typeof(E).FullName));
            }
            catch(E) {}
            catch(Exception ex) {
                throw new Exception("Expected exception of type {0} but recieved {1}".Use(typeof(E).FullName, ex.GetType().FullName), ex);
            }
        }
    }
}
