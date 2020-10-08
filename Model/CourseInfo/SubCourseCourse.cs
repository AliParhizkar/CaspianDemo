using Caspian.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseInfo
{
    /// <summary>
    /// مشخصات زیردروس دروس
    /// </summary>
    [Table("SubCourseCourses", Schema = "crs")]
    public class SubCourseCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد درس اصلی
        /// </summary>
        [DisplayName("درس اصلی"), Required]
        public int? MainCourseId { get; set; }

        /// <summary>
        /// مشخصات درس اصلی
        /// </summary>
        [ForeignKey(nameof(MainCourseId))]
        public virtual Course MainCourse { get; set; }

        /// <summary>
        /// کد زیردرس
        /// </summary>
        [DisplayName("زیردرس"), Required, Unique("این زیردرس قبلا بعنوان زیردرس این درس تعریف شده است.", nameof(MainCourseId))]
        public int? SubCourseId { get; set; }

        /// <summary>
        /// مشخصات زیردرس
        /// </summary>
        [ForeignKey(nameof(SubCourseId))]
        public virtual SubCourse SubCourse { get; set; }

        /// <summary>
        /// نمره
        /// </summary>
        [DisplayName("نمره"), Required]
        public decimal? Grade { get; set; }
    }
}
