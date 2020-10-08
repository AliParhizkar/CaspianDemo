using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نوع نمره دهی
    /// </summary>
    public enum GradeType: byte
    {
        /// <summary>
        /// درصدی
        /// </summary>
        [EnumField("درصدی")]
        Percent = 1,

        /// <summary>
        /// تجمیعی
        /// </summary>
        [EnumField("تجمیعی")]
        Accumulative
    }
}
