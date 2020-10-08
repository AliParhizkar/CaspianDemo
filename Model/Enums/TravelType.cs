using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// نوع مسافرت
    /// </summary>
    public enum TravelType : byte
    {
        /// <summary>
        /// فرصت مطالعاتی
        /// </summary>
        [EnumField("فرصت مطالعاتی")]
        Research = 1,

        /// <summary>
        /// ارائه ی مقاله
        /// </summary>
        [EnumField("ارائه مقاله")]
        Article,

        /// <summary>
        /// ادامه ی تحصیل
        /// </summary>
        [EnumField("ادامه تحصیل")]
        Study
    }
}
