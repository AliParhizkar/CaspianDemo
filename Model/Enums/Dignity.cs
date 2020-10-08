using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{

    /// <summary>
    /// مشخصات مقام های کسب شده
    /// </summary>
    public enum Dignity : byte
    {
        /// <summary>
        /// اول
        /// </summary>
        [EnumField("اول")]
        First = 1,

        /// <summary>
        /// دوم
        /// </summary>
        [EnumField("دوم")]
        Second,

        /// <summary>
        /// سوم
        /// </summary>
        [EnumField("سوم")]
        Threed
    }
}
