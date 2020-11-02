using System;
using Caspian.Common;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SelectUnitInfo
{
    /// <summary>
    /// مشخصات زمانبندی انتخاب واحد
    /// </summary>
    [Table("SelectUnitTimings", Schema = "sun")]
    public class SelectUnitTiming
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("ترم"), Required]
        public int? Term { get; set; }

        /// <summary>
        /// از سال ورود
        /// </summary>
        [DisplayName("از سال ورود"), Required]
        public int? FromYear { get; set; }

        /// <summary>
        /// تا سال ورود
        /// </summary>
        [DisplayName("تا سال ورود"), Required]
        public int? ToYear { get; set; }

        /// <summary>
        /// از تاریخ
        /// </summary>
        [DisplayName("از تاریخ"), Required]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// تا تاریخ
        /// </summary>
        [DisplayName("تا تاریخ"), Required]
        public DateTime? TODate { get; set; }

        /// <summary>
        /// از زمان
        /// </summary>
        [DisplayName("از زمان")]
        public TimeSpan? FromTime { get; set; }

        /// <summary>
        /// تا زمان
        /// </summary>
        [DisplayName("تا زمان")]
        public TimeSpan? ToTime { get; set; }

        /// <summary>
        /// از حرف اول نام خانوادگی
        /// </summary>
        [DisplayName("از حرف اول نام خانوادگی"), MaxLength(1)]
        public string FromFirstFamilyChar { get; set; }

        /// <summary>
        /// تا حرف اول نام خانوادگی
        /// </summary>
        [DisplayName("تا حرف اول نام خانوادگی"), MaxLength(1)]
        public string ToFirstFamilyChar { get; set; }

        /// <summary>
        /// از کل واحد پاس شده
        /// </summary>
        [DisplayName("از کل واحد پاس شده"), Range(1, 500)]
        public int? FromPassedUnit { get; set; }

        /// <summary>
        /// تا کل واحد پاس شده
        /// </summary>
        [DisplayName("تا کل واحد پاس شده"), Range(1, 500)]
        public int? ToPassedUnit { get; set; }

        /// <summary>
        /// از معدل ترم پیش
        /// </summary>
        [DisplayName("از معدل ترم پیش"), Range(1, 20)]
        public decimal? FromAvrage { get; set; }

        /// <summary>
        /// تا معدل ترم پیش
        /// </summary>
        [DisplayName("تا معدل ترم پیش"), Range(1, 20)]
        public decimal? ToAvrage { get; set; }

        /// <summary>
        /// از معدل کل
        /// </summary>
        [DisplayName("از معدل کل"), Range(1, 20)]
        public decimal? FromTotalAvrage { get; set; }

        /// <summary>
        /// تا معدل کل
        /// </summary>
        [DisplayName("تا معدل کل"), Range(1, 20)]
        public decimal? ToTotalAvrage { get; set; }

        /// <summary>
        /// انتخاب واحدهایی که برای این زمانبندی ثبت شده اند
        /// </summary>
        [CheckOnDelete("برای این زمانبندی انتخاب واحد ثبت شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<SelectUnit> SelectUnits { get; set; }
    }
}
