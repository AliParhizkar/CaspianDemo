using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SelectUnitInfo
{
    /// <summary>
    /// مشخصات انتخاب واحد
    /// </summary>
    [Table("CourseGrades", Schema = "sun")]
    public class CourseGrade
    {
        [Key, ForeignKey(nameof(SelectUnitDetail))]
        public int SelectUnitDetailId { get; set; }

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

        /// <summary>
        /// نمره نهایی شده یا خیر
        /// </summary>
        public bool? IsFinal { get; set; }

        /// <summary>
        /// مشخص می کند که دانشجو درس را پاس کرده یا خیر
        /// درس پاس شده true
        /// درس پاس نشده false
        /// نامشخص null
        /// </summary>
        public bool? IsPassed { get; set; }

        public virtual SelectUnitDetail SelectUnitDetail { get; set; }
    }
}
