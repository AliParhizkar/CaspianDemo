using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{

    /// <summary>
    /// نوع درس از لحاظ فارغ التحصیلی
    /// </summary>
    public enum GraduatedCourseType
    {
        /// <summary>
        /// عمومی
        /// </summary>
        [EnumField("عمومی")]
        Public = 1,

        /// <summary>
        /// پایه الزامی
        /// </summary>
        [EnumField("پایه الزامی")]
        BaseNecessary,

        /// <summary>
        /// پایه اختیاری
        /// </summary>
        [EnumField("پایه اختیاری")]
        BaseOptional,

        /// <summary>
        /// الزامی مشترک(هسته)
        /// </summary>
        [EnumField("الزامی مشترک(هسته)")]
        NecessaryCommon,

        /// <summary>
        /// انتخابی
        /// </summary>
        [EnumField("انتخابی")]
        Selective,

        /// <summary>
        /// اختیاری
        /// </summary>
        [EnumField("اختیاری")]
        Optional,

        /// <summary>
        /// خارج از رشته
        /// </summary>
        [EnumField("خارج از رشته")]
        Other,

        /// <summary>
        /// کهاد
        /// </summary>
        [EnumField("کهاد")]
        Kehad,

        /// <summary>
        /// الزامی
        /// </summary>
        [EnumField("الزامی")]
        Necessary
    }
}
