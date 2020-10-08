using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// سطح مسابقات
    /// </summary>
    public enum ExerciseRate : byte
    {
        /// <summary>
        /// بین المللی
        /// </summary>
        [EnumField("بین المللی")]
        Nationality = 1,

        /// <summary>
        /// کشوری
        /// </summary>
        [EnumField("کشوری")]
        Country,

        /// <summary>
        /// استانی
        /// </summary>
        [EnumField("استانی")]
        Province,

        /// <summary>
        /// شهری
        /// </summary>
        [EnumField("شهری")]
        City,

        /// <summary>
        /// دانشگاهی
        /// </summary>
        [EnumField("دانشگاهی")]
        University
    }

    /// <summary>
    /// عنوان مقام
    /// </summary>
    public enum RankTitle: byte
    {
        /// <summary>
        /// اول
        /// </summary>
        [EnumField("اول")]
        _1 = 1,

        /// <summary>
        /// دوم
        /// </summary>
        [EnumField("دوم")]
        _2,

        /// <summary>
        /// سوم
        /// </summary>
        [EnumField("سوم")]
        _3
    }
}
