using Model.Timing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// مشخصات امتحانات گروه درسی
    /// </summary>
    [Table("CourseGroupExams", Schema = "crg")]
    public class CourseGroupExam
    {
        [Key, ForeignKey(nameof(CourseGroup)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseGroupId { get; set; }

        /// <summary>
        /// کد امتحان میان ترم
        /// </summary>
        [DisplayName("امتحان میان ترم")]
        public int? MidTermExamId { get; set; }

        /// <summary>
        /// مشخصات امتحان میان ترم
        /// </summary>
        [ForeignKey(nameof(MidTermExamId))]
        public virtual ExamTime MidtermExam { get; set; }

        /// <summary>
        /// کد امتحان پایان ترم
        /// </summary>
        [DisplayName("امتحان پایان ترم"), Required]
        public int? FinalTermExamId { get; set; }

        /// <summary>
        /// مشخصات امتحان پایان ترم
        /// </summary>
        [ForeignKey(nameof(FinalTermExamId))]
        public virtual ExamTime FinalTermExam { get; set; }

        /// <summary>
        /// مشخصات گروه درسی
        /// </summary>
        public virtual CourseGroup CourseGroup { get; set; }
    }
}
