using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// برچسب درس
    /// </summary>
    public enum CourseLable: byte
    {
        /// <summary>
        /// تئوری
        /// </summary>
        [EnumField("تئوری")]
        Theory,

        /// <summary>
        /// عملی
        /// </summary>
        [EnumField("عملی")]
        Practical
    }



}
