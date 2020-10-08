using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// رده سنی
    /// </summary>
    public enum AgeRateType : byte
    {
        /// <summary>
        /// بزرگسالان
        /// </summary>
        [EnumField("بزرگسالان")]
        Adults = 1,

        /// <summary>
        /// جوانان
        /// </summary>
        [EnumField("جوانان")]
        Youth,

        /// <summary>
        /// نوجوانان
        /// </summary>
        [EnumField("نوجوانان")]
        Youth1,

        /// <summary>
        /// خردسالان
        /// </summary>
        [EnumField("خردسالان")]
        children
    }
}
