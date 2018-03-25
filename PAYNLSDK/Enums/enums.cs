using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PAYNLSDK.Enums
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

    /// <summary>
    /// Gender enumeration
    /// </summary>
    public enum Gender
    {
        [EnumMember(Value="m")]
        Male,
        [EnumMember(Value = "f")]
        Female
    }

    /// <summary>
    /// TaxClass enumeration
    /// </summary>
    public enum TaxClass
    {
        [EnumMember(Value = "N")]
        None = 0,
        [EnumMember(Value = "L")]
        Low = 6,
        [EnumMember(Value = "H")]
        High = 21
    }

    /// <summary>
    /// PaymentMethodId enumeration
    /// </summary>
    public enum PaymentMethodId
    {
        /// <summary>
        /// Payment with SMS
        /// </summary>
        [EnumMember(Value = "1")]
        Sms = 1,
        /// <summary>
        /// Payment method with fixed price
        /// </summary>
        [EnumMember(Value = "2")]
        PayFixedPrice = 2,
        /// <summary>
        /// Pay per call
        /// </summary>
        [EnumMember(Value = "3")]
        PayPerCall = 3,
        /// <summary>
        /// Pay per transaction
        /// </summary>
        [EnumMember(Value = "4")]
        PayPerTransaction = 4,
        /// <summary>
        /// Pay per minute
        /// </summary>
        [EnumMember(Value = "5")]
        PayPerMinute = 5
    }

    /// <summary>
    /// ExchangeState enumeration
    /// </summary>
    public enum ExchangeState
    {
        [EnumMember(Value = "-1")]
        Failed = -1,
        [EnumMember(Value = "0")]
        NotCalled = 0,
        [EnumMember(Value = "1")]
        Success = 1
    }

    /// <summary>
    /// ActiveState enumeration
    /// </summary>
    public enum ActiveState
    {
        [EnumMember(Value = "0")]
        Inactive = 0,
        [EnumMember(Value = "1")]
        Active = 1
    }

    /// <summary>
    /// 3D Secure enumeration
    /// </summary>
    public enum Secure
    {
        [EnumMember(Value = "0")]
        NotSecure = 0,
        [EnumMember(Value = "1")]
        Secure3D = 1
    }

    /// <summary>
    /// Availability enumeration
    /// </summary>
    public enum Availability
    {
        [EnumMember(Value = "0")]
        Unavailable = 0,
        [EnumMember(Value = "1")]
        Available = 1
    }

    /// <summary>
    /// Blacklist type enumeration
    /// </summary>
    public enum Blacklist
    {
        [EnumMember(Value = "0")]
        NotBlacklisted = 0,
        [EnumMember(Value = "1")]
        Blacklisted = 1,
        [EnumMember(Value = "2")]
        BlacklistedByOthers = 2
    }

    /// <summary>
    /// Paymentstatus enumeration representing PAYNL Payment statusses
    /// </summary>
    public enum PaymentStatus
    {
        [EnumMember(Value = "-90")]
        CANCEL = -90,
        [EnumMember(Value = "-60")]
        CANCEL_2 = -60,
        [EnumMember(Value = "-82")]
        PARTIAL_REFUND = -82,
        [EnumMember(Value = "-81")]
        REFUND = -81,
        [EnumMember(Value = "-80")]
        EXPIRED = -80,
        [EnumMember(Value = "-71")]
        CHARGEBACK_1 = -71,
        [EnumMember(Value = "-70")]
        CHARGEBACK_2 = -70,
        [EnumMember(Value = "-51")]
        PAID_CHECKAMOUNT = -51,
        [EnumMember(Value = "0")]
        WAIT = 0,
        [EnumMember(Value = "20")]
        PENDING_1 = 20,
        [EnumMember(Value = "25")]
        PENDING_2 = 25,
        [EnumMember(Value = "50")]
        PENDING_3 = 50,
        [EnumMember(Value = "90")]
        PENDING_4 = 90,
        [EnumMember(Value = "60")]
        OPEN = 60,
        [EnumMember(Value = "75")]
        CONFIRMED_1 = 75,
        [EnumMember(Value = "76")]
        CONFIRMED_2 = 76,
        [EnumMember(Value = "80")]
        PARTIAL_PAYMENT = 80,
        [EnumMember(Value = "85")]
        VERIFY = 85,
        [EnumMember(Value = "100")]
        PAID = 100,
        [EnumMember(Value = "95")]
        AUTHORIZE = 95,
        [EnumMember(Value = "-63")]
        DENIED = -63,
    }

    /// <summary>
    /// Type of the order line. Possible values: ARTICLE, SHIPPING, HANDLING, DISCOUNT
    /// </summary>
    public enum ProductType
    {
        [EnumMember(Value = "ARTICLE")]
        ARTICLE,
        [EnumMember(Value = "SHIPPING")]
        SHIPPING,
        [EnumMember(Value = "HANDLING")]
        HANDLING,
        [EnumMember(Value = "DISCOUNT")]
        DISCOUNT,
    }
}
