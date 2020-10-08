using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// همکاری در دفتر امور فرهنگی
    /// </summary>
    public enum UnversityCooperationType : byte
    {
        /// <summary>
        /// در دانشگاه
        /// </summary>
        [EnumField("در دانشگاه")]
        InUniversity,

        /// <summary>
        /// در خوابگاه
        /// </summary>
        [EnumField("در خوابگاه")]
        InDorm,

        /// <summary>
        /// هر دو
        /// </summary>
        [EnumField("هر دو")]
        Both
    }
}
