using Caspian.Common;
using Model.CourseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات گرایش
    /// </summary>
    [Table("Trends", Schema = "dbo")]
    public class Trend
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان گرایش
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("گرایشی با این عنوان در سیستم ثبت شده است .")]
        public string Title { get; set; }

        /// <summary>
        /// مشخصات زیرگرایش های گرایش
        /// </summary>
        [CheckOnDelete("گرایش دارای زیرگرایش می باشد و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<SubTrend> SubTrends { get; set; }

        /// <summary>
        /// تمامی دانشجویان این گرایش
        /// </summary>
        [CheckOnDelete("این گرایش دارای دانشجو می باشد و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<Student> Students { get; set; }

        /// <summary>
        /// مشخصات دروسی که برای این گرایش تعریف شده اند
        /// </summary>
        [CheckOnDelete("دورسی با این گرایش در سیستم ثبت شده اند و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }
    }
}
