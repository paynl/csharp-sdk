using System;
using System.Linq;
using System.Runtime.Serialization;

namespace PAYNLSDK.Utilities
{
    /// <summary>
    /// Utility to convert Enum Values to EnumMember Values and vice versa.
    /// </summary>
    public class EnumUtil
    {
        /// <summary>
        /// Return the value of an EnumMember
        /// </summary>
        /// <typeparam name="T">Type of Enum</typeparam>
        /// <param name="type">Enum value</param>
        /// <returns>Value of the EnumMember attribute</returns>
        public static string ToEnumString<T>(T type)
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }

        /// <summary>
        /// 
        /// Return the value of an EnumMember
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <param name="enumType">Enum type</param>
        /// <returns>Value of the EnumMember attribute</returns>
        public static string ToEnumString(object value, Type enumType)
        {
            var name = Enum.GetName(enumType, value);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            return enumMemberAttribute.Value;
        }

        /// <summary>
        /// Transform the value for an EnumMember attribute to the Enum Value
        /// </summary>
        /// <typeparam name="T">Enum Type</typeparam>
        /// <param name="str">EnumMember Value</param>
        /// <returns>Enum Value</returns>
        public static T ToEnum<T>(string str)
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
            }
            return default(T);
        }

        /// <summary>
        /// Transform the value for an EnumMember attribute to the Enum Value
        /// </summary>
        /// <param name="str">EnumMember Value</param>
        /// <param name="enumType">Enum Type</param>
        /// <returns>Enum Value</returns>
        public static object ToEnum(string str, Type enumType)
        {
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == str) return Enum.Parse(enumType, name);
            }
            return Enum.Parse(enumType, enumType.GetEnumName(0));
        }
    }
}
