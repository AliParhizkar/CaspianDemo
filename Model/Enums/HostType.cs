using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نوع مهمانی
    /// </summary>
    public enum HostType: byte
    {
        /// <summary>
        /// برخی از دروس
        /// </summary>
        [EnumField("برخی از دروس")]
        SomeOfCourse = 1,

        /// <summary>
        /// کامل
        /// </summary>
        [EnumField("کامل")]
        Total,

        /// <summary>
        /// دوره
        /// </summary>
        [EnumField("دوره")]
        Course
    }

    /// <summary>
    /// موافقت کننده
    /// </summary>
    public enum Approval
    {
        /// <summary>
        /// این دانشگاه
        /// </summary>
        [EnumField("این دانشگاه")]
        ThisUn,

        /// <summary>
        /// آن دانشگاه
        /// </summary>
        [EnumField("آن دانشگاه")]
        ThatUn,

        /// <summary>
        /// سازمان مرکزی
        /// </summary>
        [EnumField("سازمان مرکزی")]
        CentericOrgan
    }

    /// <summary>
    /// تعداد ترم
    /// </summary>
    public enum TermCountType
    {
        /// <summary>
        /// یک ترم
        /// </summary>
        [EnumField("یک ترم")]
        ATerm,

        /// <summary>
        /// دو ترم
        /// </summary>
        [EnumField("دو ترم")]
        TowTerm,

        /// <summary>
        /// انتقال دائم
        /// </summary>
        [EnumField("انتقال دائم")]
        Allterms
    }
}
