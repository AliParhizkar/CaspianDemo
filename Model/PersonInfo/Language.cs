using System;
using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات زبانهای خارجی
    /// </summary>
    [Table("Languages", Schema = "dbo")]
    public class Language
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// نوع ربان
        /// </summary>
        [DisplayName("نوع زبان")]
        public LanguageType? LanguageType { get; set; }

        /// <summary>
        /// نوع امتحان زبان
        /// </summary>
        [DisplayName("نوع امتحان زبان")]
        public LanguageTestType? LanguageTestType { get; set; }

        /// <summary>
        /// نمره ی روخوانی
        /// </summary>
        [DisplayName("نمره روخوانی")]
        public decimal? Reading { get; set; }

        /// <summary>
        /// نمره ی نوشتن
        /// </summary>
        [DisplayName("نمره نوشتن")]
        public decimal? Writing { get; set; }

        /// <summary>
        /// نمره ی شنیدن
        /// </summary>
        [DisplayName("نمره شنیدن")]
        public decimal? Listening { get; set; }

        /// <summary>
        /// نمره ی صحبت کردن
        /// </summary>
        [DisplayName("نمره صحبت کردن")]
        public decimal? Speaking { get; set; }

        /// <summary>
        /// نمره ی لغت
        /// </summary>
        [DisplayName("نمره لغت")]
        public decimal? Vocabulary { get; set; }

        /// <summary>
        /// نمره کمی
        /// </summary>
        [DisplayName("نمره کمی")]
        public decimal? Quantity { get; set; }

        /// <summary>
        /// تاریخ آزمون
        /// </summary>
        [DisplayName("تاریخ آزمون")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// آیا آخرین آزمون است
        /// </summary>
        [DisplayName("آیا آخرین آزمون است")]
        public bool? IsLast { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [DisplayName("توضیحات"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// کد فرد
        /// </summary>
        [DisplayName("فرد")]
        public int PersonId { get; set; }

        /// <summary>
        /// مشخصات فرد
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual AcademicPerson Person { get; set; }
    }
}
