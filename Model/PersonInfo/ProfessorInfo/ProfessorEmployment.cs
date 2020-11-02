using System;
using Model.Enums;
using Model.BaseInfo;
using Caspian.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.ProfessorInfo
{
    /// <summary>
    /// مشخصات پایه ای حکم استاد
    /// </summary>
    [Table("ProfessorsEmployment", Schema = "dbo")]
    public class ProfessorEmployment
    {
        [Key, ForeignKey(nameof(Professor))]
        public int ProfessorId { get; set; }

        /// <summary>
        /// کد نوع حکم
        /// </summary>
        [DisplayName("نوع حکم")]
        public int? EmploymentId { get; set; }

        /// <summary>
        /// مشخصات نوع حکم
        /// </summary>
        [ForeignKey(nameof(EmploymentId))]
        public virtual BaseDefination Employment { get; set; }

        /// <summary>
        /// کد استان محل خدمت
        /// </summary>
        [DisplayName("استان محل خدمت")]
        public int? EmploymentProvinceId { get; set; }

        /// <summary>
        /// مشخصات استان محل خدمت
        /// </summary>
        [ForeignKey(nameof(EmploymentProvinceId))]
        public virtual Province EmploymentProvince { get; set; }

        /// <summary>
        /// شهرستان محل خدمت
        /// </summary>
        [DisplayName("شهرستان محل خدمت")]
        public string EmploymentCity { get; set; }

        /// <summary>
        /// کد نوع استخدام
        /// </summary>
        [DisplayName("نوع استخدام")]
        public int? EmployTypeId { get; set; }

        /// <summary>
        /// مشخصات نوع استخدام
        /// </summary>
        [ForeignKey(nameof(EmployTypeId))]
        public virtual BaseDefination EmployType { get; set; }

        /// <summary>
        /// سال استخدام
        /// </summary>
        [DisplayName("سال استخدام")]
        public int? EmployYear { get; set; }

        /// <summary>
        /// شماره استخدام
        /// </summary>
        [DisplayName("شماره استخدام")]
        public string EmployNo { get; set; }

        /// <summary>
        /// حقوق پایه
        /// </summary>
        [DisplayName("حقوق پایه")]
        public int? Basepayment { get; set; }

        /// <summary>
        /// کد مرتبه ی علمی
        /// </summary>
        [DisplayName("مرتبه علمی")]
        public int? SienceRankId { get; set; }

        /// <summary>
        /// مشخصات مرتبه ی علمی
        /// </summary>
        [ForeignKey(nameof(SienceRankId))]
        public virtual BaseDefination SienceRank { get; set; }

        /// <summary>
        /// پایه مرتبه علمی
        /// </summary>
        [DisplayName("پایه مرتبه علمی")]
        public int? BaseOfSienceRank { get; set; }

        /// <summary>
        /// نوع همکاری
        /// </summary>
        [DisplayName("نوع همکاری")]
        public CooperationType? CooperationType { get; set; }

        /// <summary>
        /// تعداد واحد معادل موظفی
        /// </summary>
        [DisplayName("تعداد واحد معادل موظفی")]
        public short? DutyTotalUnit { get; set; }

        /// <summary>
        /// سقف تدریس
        /// </summary>
        [DisplayName("سقف تدریس")]
        public TimeSpan? MaxTeaching { get; set; }

        /// <summary>
        /// حداکثر ساعات تدریس در روز
        /// </summary>
        [DisplayName("حداکثر ساعت تدریس در روز")]
        public TimeSpan? MaxTeachingInDay { get; set; }

        /// <summary>
        /// فوق العاده مخصوص
        /// </summary>
        [DisplayName("فوق العاده مخصوص")]
        public int? SpecialExtra { get; set; }

        /// <summary>
        /// مبلغ واحد معادل واحد
        /// </summary>
        [DisplayName("مبلغ واحد معادل واحد")]
        public int? EqualPayment { get; set; }

        /// <summary>
        /// ساعت موظفی
        /// </summary>
        [DisplayName("ساعت موظفی")]
        public TimeSpan? DutyHours { get; set; }

        /// <summary>
        /// ساعت غیرموظفی
        /// </summary>
        [DisplayName("ساعت غیرموظفی")]
        public TimeSpan? UndutyHours { get; set; }

        /// <summary>
        /// کد نوع ارزشیابی استاد از اساتید همکار
        /// </summary>
        [DisplayName("نوع ارزشیابی استاد از اساتید همکار")]
        public int? AssessmentId { get; set; }

        /// <summary>
        /// مشخصات نوع ارزشیابی استاد از اساتید همکار
        /// </summary>
        [ForeignKey(nameof(AssessmentId))]
        public virtual BaseDefination Assessment { get; set; }

        /// <summary>
        /// کد نوع ارزشیابی مدیران از استاد
        /// </summary>
        [DisplayName("نوع ارزشیابی مدیران از استاد")]
        public int? MasterAssessmentId { get; set; }

        /// <summary>
        /// مشخصات نوع ارزشیابی مدیران از استاد
        /// </summary>
        [ForeignKey(nameof(MasterAssessmentId))]
        public virtual BaseDefination MasterAssessment { get; set; }

        /// <summary>
        /// تاریخ آخرین ترفیع
        /// </summary>
        [DisplayName("تاریخ آخری ترفیع")]
        public DateTime? PromotionDate { get; set; }

        /// <summary>
        /// ماه آخرین ترفیع
        /// </summary>
        [DisplayName("ماه آخرین ترفیع")]
        public PersianMonth? PromotionMonth { get; set; }

        /// <summary>
        /// ذخیره ی امتیاز پژوهشی سال قبل
        /// </summary>
        [DisplayName("ذخیره امتیازپژوهشی سال قبل")]
        public int? PrivilageSearching { get; set; }

        /// <summary>
        /// عدم ارائه ی درس
        /// </summary>
        [DisplayName("عدم ارائه درس")]
        public bool? NoCoursePresentation { get; set; }

        /// <summary>
        /// مالیات کسر شود
        /// </summary>
        [DisplayName("مالیات کسر شود")]
        public bool? TaxDeduction { get; set; }

        /// <summary>
        /// مشخصات استاد
        /// </summary>
        public virtual Professor Professor { get; set; }
    }
}
