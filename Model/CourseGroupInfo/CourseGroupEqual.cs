using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// گروه معادل گروه درسی
    /// </summary>
    [Table("CourseGroupsEqual", Schema = "crg")]
    public class CourseGroupEqual
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد گروه درسی
        /// </summary>
        [DisplayName("گروه درسی"), Required]
        public int? CourseGroupId { get; set; }

        /// <summary>
        /// مشخصات گروه درسی
        /// </summary>
        [ForeignKey(nameof(CourseGroupId))]
        public virtual CourseGroup CourseGroup { get; set; }

        /// <summary>
        /// کد گروه درسی معادل
        /// </summary>
        [DisplayName("گروه درسی معادل"), Required]
        public int? EqualCourseGroupId { get; set; }

        /// <summary>
        /// مشخصات گروه درسی معادل
        /// </summary>
        [ForeignKey(nameof(EqualCourseGroupId))]
        public virtual CourseGroup EqualCourseGroup { get; set; }

        /// <summary>
        /// مشخصات کاربر ثبت کننده
        /// </summary>
        public int? RegisterUserId { get; set; }
    }
}
