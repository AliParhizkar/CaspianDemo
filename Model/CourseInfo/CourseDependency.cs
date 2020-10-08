using Caspian.Common;
using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseInfo
{
    /// <summary>
    /// وابستکی دروس
    /// </summary>
    [Table("CourseDependencies", Schema = "crs")]
    public class CourseDependency
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد درس
        /// </summary>
        [DisplayName("درس"), Required]
        [Unique("این وابستگی قبلا تعریف شده است", nameof(DependentCourseId), nameof(EntiringYear))]
        public int? CourseId { get; set; }

        /// <summary>
        /// مشخصات درس
        /// </summary>
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

        /// <summary>
        /// کد درس وابسته
        /// </summary>
        [DisplayName("درس وابسته"), Required]
        public int? DependentCourseId { get; set; }

        /// <summary>
        /// درس وابسته
        /// </summary>
        [ForeignKey(nameof(DependentCourseId))]
        public virtual Course DependentCourse { get; set; }

        /// <summary>
        /// نوع وابستگی
        /// </summary>
        [DisplayName("نوع وابستگی"), Required]
        public DependentType? DependentType { get; set; }

        /// <summary>
        /// از سال ورود
        /// </summary>
        [DisplayName("سال ورود"), Required]
        public int? EntiringYear { get; set; }
    }
}
