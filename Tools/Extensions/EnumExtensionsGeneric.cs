using System;
using System.Collections.Generic;
using System.Linq;

namespace Tools.Extensions
{
    public static class EnumExtensionsGeneric<T> where T : struct
    {
        public static IEnumerable<T> GetValues()
        {
            CheckEnumTParam<T>();
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static T GetMaxValue()
        {
            CheckEnumTParam<T>();
            return GetValues().Max();
        }

        private static void CheckEnumTParam<T1>()
        {
            if(!typeof(T1).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated Type.");
            }
        }
    }
}
