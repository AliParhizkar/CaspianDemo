using Caspian.Common;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseInfo
{
    /// <summary>
    /// مشخصات درس وزیر درس
    /// </summary>
    [Table("Courses", Schema = "crs")]
    public class CourseStudy
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد رشته
        /// </summary>
        [DisplayName("رشته"), Required]
        public int? StudyFieldId { get; set; }

        /// <summary>
        /// مشخصات رشته
        /// </summary>
        [ForeignKey(nameof(StudyFieldId))]
        public virtual StudyField StudyField { get; set; }

        /// <summary>
        /// از ترم
        /// </summary>
        [DisplayName("از ترم"), Required]
        public int? Term { get; set; }

        /// <summary>
        /// عنوان درس
        /// </summary>
        [DisplayName("عنوان درس"), Required]
        public string Title { get; set; }

        /// <summary>
        /// عنوان لاتین درس
        /// </summary>
        [DisplayName("عنوان لاتین درس")]
        public string TitleEn { get; set; }

        /// <summary>
        /// کد درس
        /// </summary>
        [DisplayName("کد درس"), Required, Unique("درسی با این کد در سیستم ثبت شده است")]
        public string Code { get; set; }

        /// <summary>
        /// کد قدیمی درس
        /// </summary>
        [DisplayName("کد قدیمی درس")]
        public string OldCode { get; set; }

        /// <summary>
        /// کد نوع درس از لحاظ آموزشی
        /// </summary>
        [DisplayName("نوع درس از لحاظ آموزشی")]
        public int? CourseTypeId { get; set; }

        /// <summary>
        /// نوع درس از لحاظ آموزشی
        /// </summary>
        [ForeignKey(nameof(CourseTypeId))]
        public virtual BaseDefination CourseType { get; set; }

        /// <summary>
        /// تعداد موثر در انتخاب واحد
        /// </summary>
        [DisplayName("تعداد موثر در انتخاب واحد")]
        public short? EffectiveUnits { get; set; }

        /// <summary>
        /// تعداد واحد تئوری
        /// </summary>
        [DisplayName("تعداد واحد تئوری")]
        public short? TeoriaUnits { get; set; }

        /// <summary>
        /// ساعت تئوری
        /// </summary>
        [DisplayName("ساعت تئوری")]
        public string TeoriaHoures { get; set; }

        /// <summary>
        /// تعداد واحد عملی
        /// </summary>
        [DisplayName("تعداد واحد عملی")]
        public short? FuncUnits { get; set; }

        /// <summary>
        /// ساعت عملی
        /// </summary>
        [DisplayName("ساعت عملی")]
        public string FuncHoures { get; set; }

        /// <summary>
        /// تعداد واحد کار(آموزی، ورزی، گاه)
        /// </summary>
        [DisplayName("تعداد واحد کار(آموزی، ورزی، گاه)")]
        public short? WorkUnits { get; set; }

        /// <summary>
        /// تعداد ساعت کار(آموزی، ورزی، گاه)
        /// </summary>
        [DisplayName("تعداد ساعت کار(آموزی، ورزی، گاه)")]
        public string WorkHoures { get; set; }

        /// <summary>
        /// حداقل واحد گذرانده
        /// </summary>
        [DisplayName("حداقل واحد گذرانده")]
        public short? MinUnits { get; set; }

        /// <summary>
        /// حداکثر واحد گذرانده
        /// </summary>
        [DisplayName("حداکثر واحد گذرانده")]
        public short? MaxUnits { get; set; }

        /// <summary>
        /// تعداد ساعات درس
        /// </summary>
        [DisplayName("تعداد ساعات درس")]
        public string CourseHoures { get; set; }

        /// <summary>
        /// وضعیت فعال بودن
        /// </summary>
        [DisplayName("وضعیت فعال بودن")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// ضرایب حق التدریسی درس
        /// </summary>
        public virtual TeachingCourseRight TeachingCourseRight { get; set; }

        /// <summary>
        /// شیوه ی نمره دهی
        /// </summary>
        public virtual Grading Grading { get; set; }
    }
}
