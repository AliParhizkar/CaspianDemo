using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// پیشنهاد اردو
    /// </summary>
    public enum SuggestUrdoType : byte
    {
        /// <summary>
        /// تفریحی و ایرانگردی
        /// </summary>
        [EnumField("تفریحی و ایرانگردی")]
        Tafrihi,

        /// <summary>
        /// زیارتی
        /// </summary>
        [EnumField("زیارتی")]
        Ziarati,

        /// <summary>
        /// علمی
        /// </summary>
        [EnumField("علمی")]
        Elmi
    }
}
