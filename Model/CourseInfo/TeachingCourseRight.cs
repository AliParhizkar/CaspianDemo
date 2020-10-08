using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseInfo
{
    /// <summary>
    /// ضرایب حق التدریسی درس
    /// </summary>
    [Table("TeachingCourseRights", Schema = "crs")]
    public class TeachingCourseRight
    {
        [Key, ForeignKey(nameof(Course)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        /// <summary>
        /// تعداد جلسات تئوری
        /// </summary>
        [DisplayName("تعداد جلسات تئوری")]
        public CourseType? TeoriaCourse { get; set; }

        /// <summary>
        /// تعداد جلسات عملی
        /// </summary>
        [DisplayName("تعداد جلسات عملی")]
        public CourseType? FuncCourse { get; set; }

        /// <summary>
        /// تعداد جلسات کارگاهی
        /// </summary>
        [DisplayName("تعداد جلسات کارگاهی")]
        public CourseType? WorkCourse { get; set; }

        /// <summary>
        /// ضریب واحد تئوری
        /// </summary>
        [DisplayName("ضریب واحد تئوری")]
        public decimal? TeoriaFactor { get; set; }

        /// <summary>
        /// ضریب واحد عملی
        /// </summary>
        [DisplayName("ضریب واحد عملی")]
        public decimal? FuncFactor { get; set; }

        /// <summary>
        /// ضریب واحد کارگاهی
        /// </summary>
        [DisplayName("ضریب واحد کارگاهی")]
        public decimal? WorkFactor { get; set; }

        /// <summary>
        /// ضریب تعداد دانشجو
        /// </summary>
        [DisplayName("ضریب تعداد دانشجو")]
        public decimal? StudentsCountFactor { get; set; }

        /// <summary>
        /// ضریب زبان
        /// </summary>
        [DisplayName("ضریب زبان")]
        public decimal? LanguageFactor { get; set; }

        /// <summary>
        /// ضریب خاص
        /// </summary>
        [DisplayName("ضریب خاص")]
        public decimal? SpecialFactor { get; set; }

        /// <summary>
        /// واحد معادل خاص
        /// </summary>
        [DisplayName("واحد معادل خاص")]
        public decimal? EqualUnit { get; set; }

        /// <summary>
        /// مبلغ حق التدریسی خاص
        /// </summary>
        [DisplayName("مبلغ حق التدریسی خاص")]
        public int? SpecialValue { get; set; }

        public virtual CourseStudy Course { get; set; }
    }
}
