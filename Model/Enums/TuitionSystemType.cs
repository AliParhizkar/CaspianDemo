using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// نظام پرداخت شهریه
    /// </summary>
    public enum TuitionSystemType: byte
    {
        /// <summary>
        /// کلا رایگان
        /// </summary>
        [EnumField("کلا رایگان")]
        Free = 1,

        /// <summary>
        /// فقط پرداخت دروس افتاده
        /// </summary>
        [EnumField("فقط پرداخت دروس افتاده")]
        Refused,

        /// <summary>
        /// پرداخت کامل شهریه
        /// </summary>
        [EnumField("پرداخت کامل شهریه")]
        TuitionTotal
    }
}
