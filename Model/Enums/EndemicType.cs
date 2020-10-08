using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// وضعیت بومی
    /// </summary>
    public enum EndemicType: byte
    {
        /// <summary>
        /// بومی
        /// </summary>
        [EnumField("بومی")]
        Endemic = 1,

        /// <summary>
        /// غیربومی
        /// </summary>
        [EnumField("غیربومی")]
        Unendemic
    }
}
