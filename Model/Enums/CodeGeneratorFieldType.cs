using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نوع فیلد تولید کد آموزشی
    /// </summary>
    public enum CodeGeneratorFieldType : byte
    {
        /// <summary>
        /// سال ورود
        /// </summary>
        [EnumField("سال ورود")]
        EntranceYear = 1,

        /// <summary>
        /// کد رشته ی تحصیلی
        /// </summary>
        [EnumField("کد رشته تحصیلی")]
        FieldStudyCode,

        /// <summary>
        /// شمارنده
        /// </summary>
        [EnumField("شمارنده")]
        Counter,

        /// <summary>
        /// مقدار ثابت
        /// </summary>
        [EnumField("مقدار ثابت")]
        ConstValue,

        /// <summary>
        /// جنسیت
        /// </summary>
        [EnumField("جنسیت")]
        Gender,

        /// <summary>
        /// ترم ورود
        /// </summary>
        [EnumField("ترم ورود")]
        EntranceTerm,

        /// <summary>
        /// کدملی
        /// </summary>
        [EnumField("کدملی")]
        NationalCode,

        /// <summary>
        /// کد دانشکده
        /// </summary>
        [EnumField("کد دانشکده")]
        FaculityCode
    }
}
