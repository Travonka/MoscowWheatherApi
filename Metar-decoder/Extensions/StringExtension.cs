using System;
using System.Collections.Generic;
using System.Text;

namespace Metar_decoder.Extensions
{
    public static class StringExtension
    {
        public static T ToEnum<T>(this string value, T defaulValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaulValue;
            }
            T result;
            return Enum.TryParse<T>(value, out result) ? result : defaulValue;
        }
    }
}
