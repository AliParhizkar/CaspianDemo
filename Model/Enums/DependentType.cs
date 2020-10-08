using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نوع وابستگی
    /// </summary>
    public enum DependentType: byte
    {
        /// <summary>
        /// پیشنیاز
        /// </summary>
        [EnumField("پیشنیاز")]
        Prerequisite = 1,

        /// <summary>
        /// همنیاز
        /// </summary>
        [EnumField("همنیاز")]
        TheNeed,

        /// <summary>
        /// معادل
        /// </summary>
        [EnumField("معادل")]
        Equal
    }
}
