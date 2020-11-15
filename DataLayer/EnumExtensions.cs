using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class EnumExtensions
    {
        public static String GetDescription(this Enum value)
        {
            var enumType = value.GetType();
            var valueInfo = enumType.GetMember(value.ToString());

            if (valueInfo != null && valueInfo.Length > 0)
            {
                var attrs = valueInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)attrs.ElementAt(0)).Description;
                }
            }

            return value.ToString();
        }
    }
}
