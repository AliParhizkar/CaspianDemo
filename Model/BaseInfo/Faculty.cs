using Model.Timing;
using Caspian.Common;
using Model.AcceptingInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات دانشکده ها
    /// </summary>
    [Table("Faculties", Schema = "dbo")]
    public class Faculty
    {
        /// <summary>
        /// کد دانشکده
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان دانشکده
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("دانشکده ای با این عنوان در سیستم ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// کد دانشکده
        /// </summary>
        [DisplayName("کد دانشکده"), Unique("دانشکده ای با این کد در سیستم ثبت شده است")]
        public string Code { get; set; }

        /// <summary>
        /// کد دانشگاه
        /// </summary>
        [DisplayName("دانشگاه")]
        public int UniversityId { get; set; }

        /// <summary>
        /// مشخصات دانشگاه
        /// </summary>
        [ForeignKey(nameof(UniversityId))]
        public virtual University University { get; set; }

        /// <summary>
        /// مشخصات گروههای آموزشی
        /// </summary>
        [CheckOnDelete("دانشکده دراای گروه می باشد و امکان حذف وی آن وجود ندارد")]
        public virtual ICollection<Department> Departments { get; set; }

        /// <summary>
        /// مشخصات دانشکده های مورد پذیرش
        /// </summary>
        [CheckOnDelete("برای دانشکده دانشکده پذیرش ثبت شده است و امکان حذف ان وجود ندارد")]
        public virtual ICollection<AcceptingFaculty> AcceptingFaculties { get; set; }

        /// <summary>
        /// زمان امتحاناتی که در این دانشکده برگزار می شوند
        /// </summary>
        [CheckOnDelete("این دانشکده بعنوان محل برگزاری امتحانات تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<ExamTime> ExamTimes { get; set; }

        /// <summary>
        /// کلاس های درس دانشکده
        /// </summary>
        [CheckOnDelete("برای این دانشکده کلاس درس تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<Classroom> Classrooms { get; set; }
    }
}
