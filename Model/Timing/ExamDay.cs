using Caspian.Common;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Timing
{
    /// <summary>
    /// مشخصات روز امتحان
    /// </summary>
    public class ExamDay
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان 
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("روزی با این عنوان در سیستم ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// مقدار
        /// </summary>
        [DisplayName("مقدار"), Required, Range(1, 500), Unique("این مقدار تکراری است")]
        public int Value { get; set; }

        /// <summary>
        /// زمانهای برگزاری امتحانات
        /// </summary>
        [CheckOnDelete("برای این روز امتحان تعریف شده و امکان حذف آن وجود ندارد")]
        public virtual ICollection<ExamTime> ExamTimes { get; set; }
    }
}
