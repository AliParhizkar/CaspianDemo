using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نوع استعداد درخشان
    /// </summary>
    public enum EliteType: byte
    {
        /// <summary>
        /// عادی
        /// </summary>
        [EnumField("عادی")]
        Normal = 1,

        /// <summary>
        /// استعداد درخشان
        /// </summary>
        [EnumField("استعداد درخشان")]
        Elite
    }
}
