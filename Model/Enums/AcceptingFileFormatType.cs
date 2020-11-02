using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// فرمت فایل ورودی
    /// </summary>
    public enum AcceptingFileFormatType : byte
    {
        /// <summary>
        /// دانشگاه آزاد
        /// </summary>
        [EnumField("دانشگاه آزاد")]
        AzadUn = 1,

        /// <summary>
        /// دانشگاه پیام نور
        /// </summary>
        [EnumField("دانشگاه پیام نور")]
        PayameNor,

        /// <summary>
        /// دانشگاه الکی
        /// </summary>
        [EnumField("دانشگاه الکی")]
        Alaki,

        /// <summary>
        /// دانشگاه راستکی
        /// </summary>
        [EnumField("دانشگاه راستکی")]
        Rastaki
    }

    public enum CourseStatus
    {
        /// <summary>
        /// نمره وارد نشده
        /// </summary>
        [EnumField("وارد نشده")]
        NotEntered,

        /// <summary>
        /// ثبت اولیه صورت گرفته
        /// </summary>
        [EnumField("ثبت اولیه")]
        InitialRegistration,

        /// <summary>
        /// ثبت نهایی انجام شده
        /// </summary>
        [EnumField("ثبت نهایی")]
        FinalRegister
    }

    public enum Gender
    {
        /// <summary>
        /// مرد
        /// </summary>
        [EnumField("مرد")]
        Male,

        /// <summary>
        /// زن
        /// </summary>
        [EnumField("زن")]
        Female
    }
}
