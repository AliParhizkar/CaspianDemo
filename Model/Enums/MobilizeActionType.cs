using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// نوع فعالیت
    /// </summary>
    public enum MobilizeActionType : byte
    {
        /// <summary>
        /// عادی
        /// </summary>
        [EnumField("عادی")]
        Normal = 1,

        /// <summary>
        /// فعال
        /// </summary>
        [EnumField("فعال")]
        Active,

        /// <summary>
        /// سایر
        /// </summary>
        [EnumField("سایر")]
        Other
    }
}
