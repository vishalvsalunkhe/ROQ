using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Common.Helper
{
    public static class EnumExtensions
    {
        public static string ToFriendlyString(this Enum value)
        {

            // variables  
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            // return  
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }

        public static int GetValue(this Enum value)
        {
            int enumValue = Convert.ToInt32(value);
            return enumValue;
        }

        public static string GetStringValue(this Enum value)
        {
            int enumValue = GetValue(value);
            return enumValue.ToString();
        }

        public static string GetDescription(this Enum value)
        {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0 ? value.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
