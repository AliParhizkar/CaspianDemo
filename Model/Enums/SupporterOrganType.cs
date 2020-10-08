using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// سازمان حمایت کننده
    /// </summary>
    public enum SupporterOrganType: byte
    {
        /// <summary>
        /// جانبازان
        /// </summary>
        [EnumField("جانبازان")]
        Janbazan = 1,

        /// <summary>
        /// بهزیستی
        /// </summary>
        [EnumField("بهزیستی")]
        Behzisti,

        /// <summary>
        /// کمیته امداد
        /// </summary>
        [EnumField("کمیته امداد")]
        Commite,

        /// <summary>
        /// خانواده جانباز
        /// </summary>
        [EnumField("خانواده جانباز")]
        JanbazanFamily,

        /// <summary>
        /// خانواده شهدا
        /// </summary>
        [EnumField("خانواده شهدا")]
        ShohadaFamily,

        /// <summary>
        /// بنیاد جانبازان و شهدا
        /// </summary>
        [EnumField("بنیاد جانبازان و شهدا")]
        Boniad,

        /// <summary>
        /// سایر
        /// </summary>
        [EnumField("سایر")]
        Other
    }
}
