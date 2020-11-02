using Model.CourseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SelectUnitInfo
{
    /// <summary>
    /// نمرات دانشجو در زیردروس درس
    /// </summary>
    [Table("SubCourceGrades", Schema = "sun")]
    public class SubCourceGrade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? SelectUnitDetailId { get; set; }

        [ForeignKey(nameof(SelectUnitDetailId))]
        public virtual SelectUnitDetail SelectUnitDetail { get; set; }

        [Required]
        public int? SubCourseId { get; set; }

        [ForeignKey(nameof(SubCourseId))]
        public virtual SubCourse SubCourse { get; set; }

        /// <summary>
        /// نمره اول
        /// </summary>
        public decimal? Grade1 { get; set; }

        /// <summary>
        /// نمره دوم
        /// </summary>
        public decimal? Grade2 { get; set; }

        /// <summary>
        /// نمره سوم
        /// </summary>
        public decimal? Grade3 { get; set; }

        /// <summary>
        /// نمره چهارم
        /// </summary>
        public decimal? Grade4 { get; set; }

        /// <summary>
        /// نمره پنجم
        /// </summary>
        public decimal? Grade5 { get; set; }

        /// <summary>
        /// نمره نهایی
        /// </summary>
        [DisplayName("نمره نهایی"), Required]
        public decimal? TotalGrade { get; set; }

    }
}
