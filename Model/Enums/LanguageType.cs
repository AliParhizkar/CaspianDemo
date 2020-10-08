using Caspian.Common.Attributes;

namespace Model.Enums
{
    public enum LanguageType : byte
    {
        /// <summary>
        /// انگلیسی
        /// </summary>
        [EnumField("انگلیسی")]
        En = 1,

        /// <summary>
        /// آلمانی
        /// </summary>
        [EnumField("آلمانی")]
        Ge,

        /// <summary>
        /// عربی
        /// </summary>
        [EnumField("عربی")]
        Ar
    }
}
