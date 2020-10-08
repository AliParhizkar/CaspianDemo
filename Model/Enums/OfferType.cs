using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// نوع ارائه
    /// </summary>
    public enum OfferType: byte
    {
        /// <summary>
        /// حضوری
        /// </summary>
        [EnumField("حضوری")]
        Verbal = 1,

        /// <summary>
        /// مجازی
        /// </summary>
        [EnumField("مجازی")]
        Virtual
    }
}
