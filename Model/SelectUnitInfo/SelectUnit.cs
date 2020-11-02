using Caspian.Common;
using Model.ExceptCaseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SelectUnitInfo
{
    /// <summary>
    /// مشخصات انتخاب واحد
    /// </summary>
    [Table("SelectUnit", Schema = "sun")]
    public class SelectUnit
    {
        [Key]
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
        /// ترم
        /// </summary>
        [DisplayName("ترم"), Required]
        public int? Term { get; set; }

        /// <summary>
        /// نهایی شده
        /// </summary>
        [DisplayName("نهایی شده")]
        public bool? IsFinal { get; set; }

        /// <summary>
        /// کد زمانبندی انتخاب واحد
        /// </summary>
        [DisplayName("زمانبندی انتخاب واحد"), Required]
        public int? SelectUnitTimingId { get; set; }

        /// <summary>
        /// مشخصات زمانبندی انتخاب واحد
        /// </summary>
        [ForeignKey(nameof(SelectUnitTimingId))]
        public virtual SelectUnitTiming SelectUnitTiming { get; set; }

        /// <summary>
        /// تعداد واحد اخذ شده
        /// </summary>
        [DisplayName("تعداد واحد اخذ شده"), Required]
        public byte? PrehensionUnit { get; set; }

        /// <summary>
        /// تعداد واحد گذرانده
        /// </summary>
        [DisplayName("تعداد واحد گذرانده")]
        public byte? PassedUnit { get; set; }

        /// <summary>
        /// معدل ترم
        /// </summary>
        [DisplayName("معدل ترم")]
        public decimal? Avrage { get; set; }

        /// <summary>
        /// کد مورد استثناء در ثبت نام 
        /// </summary>
        [DisplayName("مورد استثناء")]
        public int? StudentExceptCaseId { get; set; }

        /// <summary>
        /// مشخصات مورد استثناء در ثبت نام
        /// </summary>
        [ForeignKey(nameof(StudentExceptCaseId))]
        public virtual StudentExceptCase StudentExceptCase { get; set; }

        /// <summary>
        /// جزئیات انتخاب واحد
        /// </summary>
        [CheckOnDelete("برای این انتخاب واحد جزئیات انتخاب واحد ثبت شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<SelectUnitDetail> SelectUnitDetails { get; set; }
    }
}
