using Model.Enums;
using Caspian.Common;
using Model.BaseInfo;
using Model.CourseInfo;
using Model.SelectUnitInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// مشخصات اصلی گروه درسی
    /// </summary>
    public class CourseGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد مشخصات درس
        /// </summary>
        [DisplayName("درس"), Required]
        public int? CourseId { get; set; }

        /// <summary>
        /// مشخصات درس
        /// </summary>
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

        /// <summary>
        /// ترم
        /// </summary>
        [DisplayName("ترم"), Required]
        public int? Term { get; set; }

        /// <summary>
        /// شماره گروه
        /// </summary>
        [DisplayName("شماره گروه")]
        public string GroupNo { get; set; }

        /// <summary>
        /// کد گروه ارائه کننده درس
        /// </summary>
        [DisplayName("گروه ارائه کننده"), Required]
        public int? DepartmentId { get; set; }

        /// <summary>
        /// مشخصات گروه ارائه کننده درس
        /// </summary>
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        /// <summary>
        /// کد تعداد زیرگروه
        /// </summary>
        [DisplayName("تعداد زیرگروه")]
        public int? SubGroupCountId { get; set; }

        /// <summary>
        /// مشخصات تعداد زیرگروه
        /// </summary>
        [ForeignKey(nameof(SubGroupCountId))]
        public virtual BaseDefination SubGroupCount { get; set; }

        /// <summary>
        /// ظرفیت حدنصاب
        /// </summary>
        [DisplayName("ظرفیت حدنصاب"), Range(1, 100)]
        public int? MinCapacity { get; set; }

        /// <summary>
        /// کد لاین
        /// </summary>
        [DisplayName("لاین")]
        public int? LineId { get; set; }

        /// <summary>
        /// مشخصات لاین
        /// </summary>
        [ForeignKey(nameof(LineId))]
        public virtual Line Line { get; set; }

        /// <summary>
        /// نوع ارائه
        /// </summary>
        [DisplayName("نوع ارائه")]
        public OfferType? OfferType { get; set; }

        /// <summary>
        /// وضعیت حذف و اخذ
        /// </summary>
        [DisplayName("وضعیت حذف و اخذ")]
        public AddOrRemoveType? AddOrRemoveType { get; set; }

        /// <summary>
        /// ملاحظه
        /// </summary>
        [DisplayName("ملاحظه"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// گروه قفل است
        /// </summary>
        [DisplayName("گروه قفل است")]
        public bool? IsLock { get; set; }

        /// <summary>
        /// مشخصات اساتید گروه درسی
        /// </summary>
        [CheckOnDelete("برای گروه درس استاد تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<CourseGroupProfessor> CourseGroupProfessors { get; set; }

        /// <summary>
        /// برنامه زمانی گروه درسی
        /// </summary>
        [CheckOnDelete("برای گروه درسی برنامه زمانی تعریف شده و امکان حذف آن وجود ندارد")]
        public virtual ICollection<CourseGroupClassTime> CourseGroupClassTime { get; set; }

        /// <summary>
        /// محدودیت های گروه درسی
        /// </summary>
        [CheckOnDelete("برای گروه درسی محدودیت تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<CourseGroupLimitation> CourseGroupLimitations { get; set; }

        /// <summary>
        /// مشخصات گروههایی که این گروه درسی معادل آنها است
        /// </summary>
        [InverseProperty("CourseGroup")]
        [CheckOnDelete("این گروه درسی معادل گروه(ها)ی درسی دیگری است و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<CourseGroupEqual> CourseGroups { get; set; }

        /// <summary>
        /// مشخصات گروههای درسی معادل این گروه درسی
        /// </summary>
        [InverseProperty("EqualCourseGroup")]
        [CheckOnDelete("برای این گروه درسی گروه درسی معادل تعریف شده و امکان حذف آن وجود ندراد.")]
        public virtual ICollection<CourseGroupEqual> CourseGroupEquals { get; set; }

        /// <summary>
        /// مشخصات انتخاب واحدهای این گروه درسی
        /// </summary>
        [CheckOnDelete("این گروه درسی در انتخاب واحد انتخاب شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<SelectUnitDetail> SelectUnitDetails { get; set; }

        /// <summary>
        /// مشخصات امتحانات گروه درسی
        /// </summary>
        public virtual CourseGroupExam CourseGroupExam { get; set; }
    }
}
