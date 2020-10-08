using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// نوع ترم
    /// </summary>
    public enum TermKind : byte
    {
        /// <summary>
        /// اول
        /// </summary>
        [EnumField("اول")]
        First = 1,

        /// <summary>
        /// دوم
        /// </summary>
        [EnumField("دوم")]
        Second,

        /// <summary>
        /// تابستان
        /// </summary>
        [EnumField("تابستان")]
        Summery
    }
}
