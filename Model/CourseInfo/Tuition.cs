using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseInfo
{
    /// <summary>
    /// روش محاسبه ی شهریه
    /// </summary>
    [Table("Tuitions", Schema = "crs")]
    public class Tuition
    {
        [Key, ForeignKey(nameof(Course)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? CourseId { get; set; }

        /// <summary>
        /// کد نوع درس از لحاظ شهریه تئوری
        /// </summary>
        [DisplayName("نوع درس از لحاظ شهریه تئوری")]
        public int? TeoriaTuitionId { get; set; }

        /// <summary>
        /// مشخصات نوع درس از لحاظ شهریه تئوری
        /// </summary>
        [ForeignKey(nameof(TeoriaTuitionId))]
        public virtual BaseDefination TeoriaTuition { get; set; }

        /// <summary>
        /// کد نوع درس از لحاظ شهریه عملی
        /// </summary>
        [DisplayName("نوع درس از لحاظ شهریه عملی")]
        public int? FuncTuitionId { get; set; }

        /// <summary>
        /// مشخصات نوع درس از لحاظ شهریه عملی
        /// </summary>
        [ForeignKey(nameof(FuncTuitionId))]
        public virtual BaseDefination FuncTuition { get; set; }

        /// <summary>
        /// کد نوع درس از لحاظ شهریه کارگاهی
        /// </summary>
        [DisplayName("نوع درس از لحاظ شهریه کارگاهی")]
        public int? WorkTuitionId { get; set; }

        /// <summary>
        /// مشخصات نوع درس از لحاظ شهریه کارگاهی
        /// </summary>
        [ForeignKey(nameof(WorkTuitionId))]
        public virtual BaseDefination WorkTuition { get; set; }

        /// <summary>
        /// تعداد واحد تئوری شهریه
        /// </summary>
        [DisplayName("تعداد واحد تئوری شهریه")]
        public short? TeoriaUnitsTuition { get; set; }

        /// <summary>
        /// تعداد واحد عملی شهریه
        /// </summary>
        [DisplayName("تعداد واحد عملی شهریه")]
        public short? FuncUnitsTuition { get; set; }

        /// <summary>
        /// تعداد واحد کارگاهی شهریه
        /// </summary>
        [DisplayName("تعداد واحد کارگاهی شهریه")]
        public short? WorkUnitsTuition { get; set; }

        /// <summary>
        /// کد رشته پایه محاسبات شهریه
        /// </summary>
        [DisplayName("رشته پایه محاسبات شهریه")]
        public int? StudyFieldId { get; set; }

        /// <summary>
        /// مشخصات رشته پایه محاسبات شهریه
        /// </summary>
        [ForeignKey(nameof(StudyFieldId))]
        public virtual StudyField StudyField { get; set; }

        /// <summary>
        /// درصد افزایش شهریه
        /// </summary>
        [DisplayName("درصد افزایش شهریه")]
        public decimal? IncPercent { get; set; }

        /// <summary>
        /// در صورت اخذ تنها این درس شهریه ثابت نصف شود
        /// </summary>
        [DisplayName("در صورت اخذ تنها این درس شهریه ثابت نصف شود")]
        public bool? IsHalf { get; set; }

        /// <summary>
        /// مشخصات درس
        /// </summary>
        public virtual Course Course { get; set; }
    }
}
