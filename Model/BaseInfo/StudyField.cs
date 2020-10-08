using Caspian.Common;
using Model.CourseInfo;
using Model.AcceptingInfo;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات رشته های تحصیلی
    /// </summary>
    [Table("StudyFields", Schema = "dbo")]
    public class StudyField
    {
        /// <summary>
        /// کد رشته
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان رشته
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("رشته ای با این عنوان ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// کد آموزشی
        /// </summary>
        [DisplayName("کد آموزشی"), Unique("رشته ای با این کد ثبت شده است")]
        public string Code { get; set; }

        /// <summary>
        /// کد گروه تحصیلی
        /// </summary>
        [DisplayName("گروه تحصیلی"), Required]
        public int? DepartmentId { get; set; }

        /// <summary>
        /// مشخصات گروه
        /// </summary>
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        /// <summary>
        /// رشته های پذیرفته شدگان این رشته
        /// </summary>
        [CheckOnDelete("برای رشته پذیرفته شده نصب شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<AcceptingStudyField> AcceptingStudyFields { get; set; }

        /// <summary>
        /// تمامی دانشجویان این رشته تحصیلی
        /// </summary>
        [CheckOnDelete("این رشته دارای دانشجو می باشد و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<Student> Students { get; set; }

        /// <summary>
        /// دروسی که دانشجو باید در این رشته پاس کند
        /// </summary>
        [CheckOnDelete("برای رشته درس تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<CourseStudy> Courses { get; set; }
    }
}
