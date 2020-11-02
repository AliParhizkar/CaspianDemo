using System;
using Caspian.Common;
using System.ComponentModel;
using Model.CourseGroupInfo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Timing
{
    /// <summary>
    /// سانس برگزاری کلاسها
    /// </summary>
    [Table("ClassTimes", Schema = "tim")]
    public class ClassTime
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// زمان شروع سانس
        /// </summary>
        [DisplayName("زمان شروع سانس"), Required]
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// زمان پایان سانس
        /// </summary>
        [DisplayName("زمان پایان سانس"), Required]
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// روز هفته
        /// </summary>
        [DisplayName("روز هفته"), Required]
        public DayOfPersianWeek? DayOfWeek { get; set; }

        /// <summary>
        /// ملاحظه
        /// </summary>
        [DisplayName("ملاحظه"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// کد کلاس
        /// </summary>
        [DisplayName("کلاس")]
        public int ClassromId { get; set; }

        /// <summary>
        /// مشخصات کلاس
        /// </summary>
        [ForeignKey(nameof(ClassromId))]
        public virtual Classroom Classrom { get; set; }

        /// <summary>
        /// مشخصات زمانبندی گروه درسی
        /// </summary>
        [CheckOnDelete("برای این سانس زمانبندی گروه درسی تعریف شده و امکان حذف آن وجود ندارد")]
        public virtual ICollection<CourseGroupClassTime> CourseGroupClassTimes { get; set; }
    }
}
