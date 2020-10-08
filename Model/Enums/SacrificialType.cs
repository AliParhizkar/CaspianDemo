using Caspian.Common.Attributes;

namespace Model.Enums
{
    public enum SacrificialType: byte
    {
        /// <summary>
        /// شهید
        /// </summary>
        [EnumField("شهید")]
        Martyr = 1,

        /// <summary>
        /// جانباز
        /// </summary>
        [EnumField("جانباز")]
        Veteran,

        /// <summary>
        /// آزاده
        /// </summary>
        [EnumField("آزاده")]
        Free,

        /// <summary>
        /// جانباز-آزاده
        /// </summary>
        [EnumField("جانباز-آزاده")]
        VeteranFree,

        /// <summary>
        /// جانباز-متوفی
        /// </summary>
        [EnumField("جانباز-متوفی")]
        VeteranDeceased,

        /// <summary>
        /// آزاده-متوفی
        /// </summary>
        [EnumField("آزاده-متوفی")]
        FreeDeceased,

        /// <summary>
        /// شهیده
        /// </summary>
        [EnumField("شهیده")]
        Martyr1,

        /// <summary>
        /// ایثارگر
        /// </summary>
        [EnumField("ایثارگر")]
        Sacrificial
    }
}
