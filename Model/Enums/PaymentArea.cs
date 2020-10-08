using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// مشخصات حوزه پرداخت
    /// </summary>
    public enum PaymentArea: byte
    {
        /// <summary>
        /// حوزه اصلی
        /// </summary>
        [EnumField("حوزه اصلی")]
        Main = 1,

        /// <summary>
        /// پردیس
        /// </summary>
        [EnumField("پردیس")]
        Pardis,

        /// <summary>
        /// مجازی
        /// </summary>
        [EnumField("مجازی")]
        Virtual
    }
}
