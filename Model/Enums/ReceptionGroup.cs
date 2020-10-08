using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// گروه آزمایشی پذیرش ورودی
    /// </summary>
    public enum ReceptionGroup: byte
    {
        /// <summary>
        /// علوم انسانی
        /// </summary>
        [EnumField("علوم انسانی")]
        Humanities,

        /// <summary>
        /// علوم تجربی
        /// </summary>
        [EnumField("علوم تجربی")]
        Science,

        /// <summary>
        /// ریاضی و فیزیک
        /// </summary>
        [EnumField("ریاضی و فیزیک")]
        MathAndPhysics,

        /// <summary>
        /// هنر
        /// </summary>
        [EnumField("هنر")]
        Atr,

        /// <summary>
        /// سایر
        /// </summary>
        [EnumField("سایر")]
        Other,

        /// <summary>
        /// زبانهای خارجی
        /// </summary>
        [EnumField("زبانهای خارجی")]
        ForeignLanguage,

        /// <summary>
        /// چند گروهی
        /// </summary>
        [EnumField("چند گروهی")]
        MultiGroup
    }
}
