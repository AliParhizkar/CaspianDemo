using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// وضعیت تسویه
    /// </summary>
    public enum LiquidationStatus: byte
    {
        /// <summary>
        /// تسویه کرده
        /// </summary>
        [EnumField("تسویه کرده")]
        Yes = 1,

        /// <summary>
        /// تسویه نکرده
        /// </summary>
        [EnumField("تسویه نکرده")]
        No
    }
}
