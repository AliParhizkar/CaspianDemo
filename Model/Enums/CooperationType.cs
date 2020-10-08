
using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نوع همکاری
    /// </summary>
    public enum CooperationType: byte
    {
        /// <summary>
        /// تمام وقت
        /// </summary>
        [EnumField("تمام وقت")]
        FullTime = 1,

        /// <summary>
        /// نیمه وقت
        /// </summary>
        [EnumField("نیمه وقت")]
        PartTime,

        /// <summary>
        /// مدعو
        /// </summary>
        [EnumField("مدعو")]
        Invited
    }
}
