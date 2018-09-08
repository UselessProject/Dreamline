using System;
using System.Diagnostics;

namespace Dreamlines.Utils {
    
    [DebuggerStepThrough]
    public static class AssertArguments {

        public static void NotNull<TValue>(TValue value, string paramName) where TValue: class {
            NotNull(value, "Value cannot be null.", paramName);
        }
        
        public static void NotNull<TValue>(TValue value, string message, string paramName) where TValue: class {
            if (value == null) {
                throw new ArgumentNullException(paramName, message);
            }
        }

        public static void IsTrue(bool condition, string paramName) {
            IsTrue(condition, "Value is not valid.", paramName);
        }

        public static void IsTrue(bool condition, string message, string paramName) {
            if (!condition) {
                throw new ArgumentException(message, paramName);
            }
        }
        
    }
    
}