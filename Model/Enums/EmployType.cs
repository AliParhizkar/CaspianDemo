using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نوع استخدام
    /// </summary>
    public enum EmployType : byte
    {
        /// <summary>
        /// آزمایشی
        /// </summary>
        [EnumField("آزمایشی")]
        Azemaieshi,

        /// <summary>
        /// پیمانی
        /// </summary>
        [EnumField("پیمانی")]
        Pimany,

        /// <summary>
        /// رسمی
        /// </summary>
        [EnumField("رسمی")]
        Rasmi,

        /// <summary>
        /// روزمزد
        /// </summary>
        [EnumField("روزمزد")]
        RozMoz,

        /// <summary>
        /// قراردادی
        /// </summary>
        [EnumField("قراردادی")]
        Gharardadi,

        /// <summary>
        /// قانون کار
        /// </summary>
        [EnumField("قانون کار")]
        GhanonKar
    }
}
