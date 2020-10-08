using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// وضعیت جسمانی
    /// </summary>
    public enum physicalStatus : byte
    {
        /// <summary>
        /// سلامت کامل
        /// </summary>
        [EnumField("سلامت کامل")]
        Healthful = 1,

        /// <summary>
        /// معلول حرکتی
        /// </summary>
        [EnumField("معلول حرکتی")]
        MovementIll,

        /// <summary>
        /// معلول بینایی
        /// </summary>
        [EnumField("معلول بینایی")]
        Visionill,

        /// <summary>
        /// معلول شنوایی
        /// </summary>
        [EnumField("معلول شنوایی")]
        HearingIll,

        /// <summary>
        /// معلول گویایی
        /// </summary>
        [EnumField("معلول گویایی")]
        SpokenIll,

        /// <summary>
        /// جانباز
        /// </summary>
        [EnumField("جانباز")]
        Janbaz,

        /// <summary>
        /// نقص سایر اعضاء
        /// </summary>
        [EnumField("نقص سایر اعضاء")]
        Others
    }
}
