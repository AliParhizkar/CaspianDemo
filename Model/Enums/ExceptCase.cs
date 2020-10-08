using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// آئین نامه و موارد خاص
    /// </summary>
    public enum ExceptCase : byte
    {
        /// <summary>
        /// آیا دانشجوی دارای محدودیت بتواند وارد سیستم شود.
        /// </summary>
        [EnumField("آیا دانشجوی دارای محدودیت بتواند وارد سیستم شود؟")]
        SystemLogin = 1,

        /// <summary>
        /// امکان انتخاب واحد خارج از انتخاب واحد
        /// </summary>
        [EnumField("امکان انتخاب واحد خارج از زمان انتخاب واحد")]
        SelectUnitTime,

        /// <summary>
        /// امکان انتخاب واحد بدون رعایت پیش نیاز
        /// </summary>
        [EnumField("امکان انتخاب واحد بدون رعایت پیش نیاز")]
        PreRequired,

        /// <summary>
        /// امکان انتخاب واحد بدون رعایت هم نیاز
        /// </summary>
        [EnumField("امکان انتخاب واحد بدون رعایت هم نیاز")]
        ByRequired,

        /// <summary>
        /// محدودیت دروس
        /// </summary>
        [EnumField("محدودیت دروس")]
        CourseLimitation
    }
}
