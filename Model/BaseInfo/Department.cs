using Caspian.Common;
using System.ComponentModel;
using Model.CourseGroupInfo;
using System.Collections.Generic;
using Model.PersonInfo.ProfessorInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات گروههای آموزشی
    /// </summary>
    [Table("Departments", Schema = "dbo")]
    public class Department
    {
        /// <summary>
        /// کد گروه آموزشی
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان گروه آموزشی
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("گروهی با این عنوان در سیستم ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// کد دانشکده
        /// </summary>
        [DisplayName("دانشکده"), Required]
        public int? FacultyId { get; set; }

        /// <summary>
        /// مشخصات دانشکده
        /// </summary>
        [ForeignKey(nameof(FacultyId))]
        public virtual Faculty Faculty { get; set; }

        /// <summary>
        /// مشخصات رشته های تحصیلی این گروه تحصیلی
        /// </summary>
        [CheckOnDelete("برای گروه رشته تحصیلی ثبت شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<StudyField> StudyFields { get; set; }

        /// <summary>
        /// مشخصات اساتید گروه
        /// </summary>
        [CheckOnDelete("برای این گروه استاد تعریف شده و امکان حذف آن وجود ندراد.")]
        public virtual ICollection<Professor> Professors { get; set; }

        /// <summary>
        /// گروههای درسی ارائه شده توسط این گروه
        /// </summary>
        [CheckOnDelete("این گروه، دروسی را ارائه کرده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<CourseGroup> CourseGroups { get; set; }
    }
}
