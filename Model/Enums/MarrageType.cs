using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// وضعیت تاهل
    /// </summary>
    public enum MarrageType: byte
    {
        /// <summary>
        /// متاهل
        /// </summary>
        [EnumField("متاهل")]
        Married = 1,

        /// <summary>
        /// مجرد
        /// </summary>
        [EnumField("مجرد")]
        Single,

        /// <summary>
        /// متارکه
        /// </summary>
        [EnumField("متارکه")]
        Seprated,

        /// <summary>
        /// همسر فوت کرده
        /// </summary>
        [EnumField("همسر فوت کرده")]
        WifeDied
    }
}
