using Model.Enums;
using Model.BaseInfo;
using Model.ExceptCaseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caspian.Common;

namespace Model.CourseInfo
{
    /// <summary>
    /// محدودیت دروس
    /// </summary>
    public class CourseLimitation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان محدودیت
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("محدودیتی با این عنوان در سیستم وجود دارد.", nameof(CourseId))]
        public string Title { get; set; }

        /// <summary>
        /// متن پیغام
        /// </summary>
        [DisplayName("متن پیغام"), Required]
        public string ErrorMessage { get; set; }

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
        /// کد زیرگرایش
        /// </summary>
        [DisplayName("زیرگرایش")]
        public int? SubTrendId { get; set; }

        /// <summary>
        /// مشخصات زیرگرایش
        /// </summary>
        [DisplayName(nameof(SubTrendId))]
        public virtual SubTrend SubTrend { get; set; }

        /// <summary>
        /// از سال
        /// </summary>
        [DisplayName("از سال")]
        public int? FromYear { get; set; }

        /// <summary>
        /// تا سال
        /// </summary>
        [DisplayName("تا سال")]
        public int? ToYear { get; set; }

        /// <summary>
        /// کد نوع درس از لحاظ آموزشی
        /// </summary>
        [DisplayName("نوع درس از لحاظ آموزشی")]
        public int? CourseTypeId { get; set; }

        /// <summary>
        /// مشخصات نوع درس از لحاظ آموزشی
        /// </summary>
        [ForeignKey(nameof(CourseTypeId))]
        public virtual BaseDefination CourseType { get; set; }

        /// <summary>
        /// از نیمسال ورود
        /// </summary>
        [DisplayName("از نیمسال ورود")]
        public TermKind? FromEnteringTerm { get; set; }

        /// <summary>
        /// تا نیمسال ورود
        /// </summary>
        [DisplayName("تا نیمسال ورود")]
        public TermKind? ToEnteringTerm { get; set; }

        /// <summary>
        /// تعداد واحد تئوری
        /// </summary>
        [DisplayName("تعداد واحد تئوری")]
        public decimal? TheoryUnit { get; set; }

        /// <summary>
        /// تعداد واحد عملی
        /// </summary>
        [DisplayName("تعداد واحد عملی")]
        public decimal? PracticalUnit { get; set; }

        /// <summary>
        /// تعداد واحد کار(آموزی/ورزی/گاه)
        /// </summary>
        [DisplayName("تعداد واحد کار(آموزی/ورزی/گاه)")]
        public decimal? WorkUnit { get; set; }

        /// <summary>
        /// غیرفعال
        /// </summary>
        [DisplayName("غیرفعال")]
        public bool? IsDeActived { get; set; }

        [DisplayName("درس"), Required]
        public int? CourseId { get; set; }

        /// <summary>
        /// مشخصات درس
        /// </summary>
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

        /// <summary>
        /// مجوز هایی که برای این محدودیت صادر شده اند
        /// </summary>
        [CheckOnDelete("برای محدودیت مجوز صادر شده و امکان حذف آن وجود ندارد.")]
        public virtual IList<StudentExceptCase> StudentExcepts { get; set; }

        /// <summary>
        /// با دریافت محدودیت های دانشجو چک می کند که این محدودیت شامل وی می شود یا نه
        /// </summary>
        /// <param name="limitation">محدودیت های دانشجو</param>
        /// <returns></returns>
        public bool IsLimited(CourseLimitation limitation)
        {
            if (IsDeActived == true)
                return false;
            if (CourseTypeId.HasValue && CourseTypeId != limitation.CourseTypeId)
                return true;
            if (FromEnteringTerm.HasValue && FromEnteringTerm != limitation.FromEnteringTerm)
                return true;
            if (FromYear.HasValue && FromYear != limitation.FromYear)
                return true;
            if (PracticalUnit.HasValue && PracticalUnit != limitation.PracticalUnit)
                return true;
            if (SubTrendId.HasValue && SubTrendId != limitation.SubTrendId)
                return true;
            if (TheoryUnit.HasValue && TheoryUnit != limitation.TheoryUnit)
                return true;
            if (ToEnteringTerm.HasValue && ToEnteringTerm != limitation.ToEnteringTerm)
                return true;
            if (ToYear.HasValue && ToYear != limitation.ToYear)
                return true;
            if (TrendId.HasValue && TrendId != limitation.TrendId)
                return true;
            if (WorkUnit.HasValue && WorkUnit != limitation.WorkUnit)
                return true;
            return false;
        }
    }
}
