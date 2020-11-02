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
    /// مشخصات زیرگرایش
    /// </summary>
    [Table("SubTrends", Schema = "dbo")]
    public class SubTrend
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان گزارش
        /// </summary>
        [DisplayName("عنوان")]
        public string Title { get; set; }

        /// <summary>
        /// کد گرایش
        /// </summary>
        [DisplayName("گرایش")]
        public int? TrendId { get; set; }

        /// <summary>
        /// مشخصات گرایش
        /// </summary>
        [ForeignKey(nameof(TrendId))]
        public virtual Trend Trend { get; set; }

        /// <summary>
        /// جزئیات دروس زیرگرایش
        /// </summary>
        [CheckOnDelete("دروسی برای این زیرگرایش تعریف شده اند و امکان حذف آن وجود ندراد.")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }

        /// <summary>
        /// مشخصات تمامی دانشجویانی از این نوع زیرگرایش
        /// </summary>
        [CheckOnDelete("برای این زیرگرایش دانشجو تعریف شده و امکان حذف آن وجود ندراد.")]
        public virtual ICollection<Student> Students { get; set; }
    }
}
