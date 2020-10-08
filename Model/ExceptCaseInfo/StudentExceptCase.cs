using System;
using Model.Enums;
using Model.CourseInfo;
using Model.SelectUnitInfo;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caspian.Common;

namespace Model.ExceptCaseInfo
{
    /// <summary>
    /// آئین نامه و موارد خاص
    /// </summary>
    [Table("ExceptCases", Schema = "exc")]
    public class StudentExceptCase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد دانشجو
        /// </summary>
        [DisplayName("دانشجو"), Required]
        public int? StudentId { get; set; }

        /// <summary>
        /// مشخصات دانشجو
        /// </summary>
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }

        /// <summary>
        /// نوع استثنا
        /// </summary>
        [DisplayName("نوع استثنا"), Required]
        public ExceptCase? ExceptCase { get; set; }

        /// <summary>
        /// کد درسی که دانشجو بدون رعایت پیش نیاز یا همنیاز 
        /// انتخاب واحد نموده است
        /// </summary>
        [DisplayName("درس")]
        public int? CourseId { get; set; }

        /// <summary>
        /// مشخصات درسی که دانشجو بدون رعایت پیش نیاز و یا هم نیاز انتخاب واحد نموده است
        /// </summary>
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

        /// <summary>
        /// تاریخ شروع محدوده مجاز انتخاب واحد
        /// </summary>
        [DisplayName("تاریخ شروع")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان محدوده مجاز انتخاب واحد
        /// </summary>
        [DisplayName("تاریخ پایان")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// ترم اعطای مجوز
        /// </summary>
        [DisplayName("ترم")]
        public int? Term { get; set; }

        /// <summary>
        /// کد محدودیت درس
        /// </summary>
        [DisplayName("محدودیت های درس")]
        public int? CourseLimitationId { get; set; }

        /// <summary>
        /// مشخصات محدودیت درس
        /// </summary>
        [ForeignKey(nameof(CourseLimitationId))]
        public virtual CourseLimitation CourseLimitation { get; set; }

        /// <summary>
        /// مشخصات انتخاب واحدهایی که براساس این آیین نامه ثبت شده است.
        /// </summary>
        [CheckOnDelete("براساس این آیین نامه انتخاب واحد ثبت شده و امکان حذف آن وجود ندارد.")]
        public virtual IList<SelectUnit> SelectUnits { get; set; }

        /// <summary>
        /// کد کاربر ثبت کننده آیین نامه
        /// </summary>
        public int UserId { get; set; }

        public DateTime InsertDate { get; set; }

        /// <summary>
        /// انتخاب واحد 
        /// </summary>
        public virtual SelectUnitDetail SelectUnitDetail { get; set; }
    }
}
