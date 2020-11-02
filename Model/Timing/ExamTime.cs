using System;
using Model.Enums;
using Model.BaseInfo;
using Caspian.Common;
using Model.CourseInfo;
using Model.CourseGroupInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Timing
{
    /// <summary>
    /// زمان برگزاری امتحاتات
    /// </summary>
    [Table("ExamTimes", Schema = "tim")]
    public class ExamTime
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ترم
        /// </summary>
        [DisplayName("ترم"), Required]
        public int? Term { get; set; }

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
        /// کد روز امتحان
        /// </summary>
        [DisplayName("روز امتحان")]
        public int? ExamDayId { get; set; }

        /// <summary>
        /// مشخصات روز امتحان
        /// </summary>
        //[ForeignKey(nameof(ExamDayId))]
        //public virtual ExamDay ExamDay { get; set; }

        /// <summary>
        /// سانس امتحانی
        /// </summary>
        [DisplayName("سانس امتحان")]
        public ExamSanceType? ExamSanceType { get; set; }

        /// <summary>
        /// تاریخ برگزاری امتحان
        /// </summary>
        [DisplayName("تاریخ برگزاری امتحان"), Required]
        public DateTime? ExamDate { get; set; }

        /// <summary>
        /// ساعت شروع
        /// </summary>
        [DisplayName("ساعت شروع"), Required]
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// ساعت پایان
        /// </summary>
        [DisplayName("ساعت پایان"), Required]
        public TimeSpan? EndTime { get; set; }

        /// <summary>
        /// ظرفیت سانس
        /// </summary>
        [DisplayName("ظرفیت سانس")]
        public int? Capacity { get; set; }

        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [DisplayName("اولویت نمایش")]
        public int Periority { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [MaxLength(200), DisplayName("توضیحات")]
        public string Comment { get; set; }

        /// <summary>
        /// مشخصات مراقبین امتحان
        /// </summary>
        [CheckOnDelete("برای این روز امتحان مراقب ثبت شده است و امکان حذف آن وجود ندارد")]
        public virtual ICollection<Observing> Observings { get; set; }

        /// <summary>
        /// مشخصات محل های برگزاری امتحان دانشکده
        /// </summary>
        [CheckOnDelete("برای دانشکده محل امتحان ثبت شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<ExamLocation> ExamLocations { get; set; }

        /// <summary>
        /// دروسی که براساس این زمانبندی ارائه شده اند
        /// </summary>
        [CheckOnDelete("این زمانبندی برای برخی امتحانات مورد استفاده قرار گرفته و امکان حذف آن وجود ندارد")]
        public virtual ICollection<CourseDetail> CourseDetails { get; set; }

        /// <summary>
        /// مشخصات امتحانات میان ترم که در این زمان ثبت شده اند
        /// </summary>
        [CheckOnDelete("برای این زمان، امتحان میان ترم تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("MidtermExam")]
        public virtual ICollection<CourseGroupExam> CourseGroupExams { get; set; }

        /// <summary>
        /// مشخصات امتحانات پایان ترم که در این زمان ثبت شده اند
        /// </summary>
        [CheckOnDelete("برای این زمان، امتحان پایان ترم تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("FinalTermExam")]
        public virtual ICollection<CourseGroupExam> CourseGroupExams1 { get; set; }
    }
}
