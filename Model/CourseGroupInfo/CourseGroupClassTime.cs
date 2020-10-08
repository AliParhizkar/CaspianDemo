using System;
using Model.Enums;
using Model.Timing;
using Caspian.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// برنامه زمانی گروه درسی
    /// </summary>
    [Table("CourseGroupClassTimes", Schema = "crg")]
    public class CourseGroupClassTime
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد گروه درسی
        /// </summary>
        [DisplayName("گروه درسی"), Required, Unique("این سانس قبلا برای این گروه تعریف شده است.", nameof(ClassTimeId))]
        public int? CourseGroupId { get; set; }

        /// <summary>
        /// مشخصات گروه درسی
        /// </summary>
        [ForeignKey(nameof(CourseGroupId))]
        public virtual CourseGroup CourseGroup { get; set; }

        /// <summary>
        /// کد سانس کلاس
        /// </summary>
        [DisplayName("سانس کلاس"), Required]
        public int? ClassTimeId { get; set; }

        /// <summary>
        /// مشخصات سانس کلاس
        /// </summary>
        [ForeignKey(nameof(ClassTimeId))]
        public virtual ClassTime ClassTime { get; set; }

        /// <summary>
        /// تاریخ شروع
        /// </summary>
        [DisplayName("تاریخ شروع")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان
        /// </summary>
        [DisplayName("تاریخ پایان")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// اولویت
        /// </summary>
        [DisplayName("اولویت")]
        public int Periority { get; set; }

        /// <summary>
        /// جلسات برگزاری کلاس
        /// </summary>
        [DisplayName("جلسات برگزاری کلاس")]
        public CourseType1 ClassCourse { get; set; }
    }
}
