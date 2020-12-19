using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;
namespace MetarDecoder.Tests.Utils
{
    class Comparator<T> : IEqualityComparer<T> where T: class
    {
        public bool Equals([AllowNull] T x, [AllowNull] T y)
        {   if (x.GetType() != y.GetType())
            {
                return false;
            }
            foreach (var property in x.GetType().GetProperties())
            {
                var a = property.GetValue(x, null);
                var b = property.GetValue(y, null);
                if (!variableCompare(property.PropertyType ,a, b))
                {
                    return false;
                }

            }
            return true;
        }
        public int GetHashCode([DisallowNull] T obj)
        {
            return 0;
        }
        private bool variableCompare(Type type, object a, object b)
       {
            if (type.IsEnum)
            {
                Enum _a = (Enum)a;
                Enum _b = (Enum)b;
                return _a.CompareTo(_b) == 0 ? true : false;
            }
            
            else if (type.IsValueType)
            {
                return a.Equals(b) ? true : false;
            }
            return false;
        }
    }
}
