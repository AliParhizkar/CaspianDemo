using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// سانس امتحان
    /// </summary>
    public enum ExamSanceType: byte
    {
        /// <summary>
        /// سانس اول
        /// </summary>
        [EnumField("سانس اول")]
        _1,

        /// <summary>
        /// سانس دوم
        /// </summary>
        [EnumField("سانس دوم")]
        _2,

        /// <summary>
        /// سانس سوم
        /// </summary>
        [EnumField("سانس سوم")]
        _3,

        /// <summary>
        /// سانس چهارم
        /// </summary>
        [EnumField("سانس چهارم")]
        _4,

        /// <summary>
        /// سانس پنجم
        /// </summary>
        [EnumField("سانس پنجم")]
        _5,

        /// <summary>
        /// سانس ششم
        /// </summary>
        [EnumField("سانس ششم")]
        _6,

        /// <summary>
        /// سانس هفتم
        /// </summary>
        [EnumField("سانس هفتم")]
        _7,

        /// <summary>
        /// سانس هشتم
        /// </summary>
        [EnumField("سانس هشتم")]
        _8,

        /// <summary>
        /// سانس نهم
        /// </summary>
        [EnumField("سانس نهم")]
        _9,

        /// <summary>
        /// سانس دهم
        /// </summary>
        [EnumField("سانس دهم")]
        _10
    }
}
