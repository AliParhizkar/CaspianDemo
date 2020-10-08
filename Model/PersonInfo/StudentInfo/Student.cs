using System;
using Model.Enums;
using Model.BaseInfo;
using Model.SelectUnitInfo;
using Model.ExceptCaseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.ProfessorInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caspian.Common;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات دانشجو
    /// </summary>
    public class Student : AcademicPerson
    {
        /// <summary>
        /// سال ورود
        /// </summary>
        [DisplayName("سال ورود"), Required]
        public int? EntranceYear { get; set; }

        /// <summary>
        /// سال مالی
        /// </summary>
        [DisplayName("سال مالی")]
        public int? FinancialYear { get; set; }

        /// <summary>
        /// نیمسال ورودی
        /// </summary>
        [DisplayName("نیمسال ورودی")]
        public TermKind? TermType { get; set; }

        /// <summary>
        /// تاریخ شروع به تحصیل
        /// </summary>
        [DisplayName("تاریخ شروع به تحصیل")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// کد جزء بسته بندی
        /// </summary>
        [DisplayName("جزء بسته بندی")]
        public int? GroupingId { get; set; }

        /// <summary>
        /// جزء بسته بندی
        /// </summary>
        [ForeignKey(nameof(GroupingId))]
        public virtual BaseDefination Grouping { get; set; }

        /// <summary>
        /// کد آموزشی قدیم
        /// </summary>
        [DisplayName("کد آموزش قدیم")]
        public string OldCode { get; set; }

        /// <summary>
        /// نظام پرداخت شهریه
        /// </summary>
        [DisplayName("نظام پرداخت شهریه")]
        public TuitionSystemType? TuitionSystemType { get; set; }

        /// <summary>
        /// شیوه آموزشی
        /// </summary>
        [DisplayName("شیوه آموزشی")]
        public LearningMethod? LearningMethod { get; set; }

        /// <summary>
        /// نوع استعداد درخشان
        /// </summary>
        [DisplayName("نوع استعداد درخشان")]
        public EliteType? EliteType { get; set; }

        /// <summary>
        /// کد سیستم آموزشی
        /// </summary>
        [DisplayName("سیستم آموزشی")]
        public int? LearningSystemId { get; set; }

        /// <summary>
        /// مشخصات سیستم آموزشی
        /// </summary>
        [ForeignKey(nameof(LearningSystemId))]
        public virtual BaseDefination LearningSystem { get; set; }

        /// <summary>
        /// کد وضعیت تحصیلی نهایی
        /// </summary>
        [DisplayName("وضعیت تحصیلی نهایی")]
        public int? FinalStatusId { get; set; }

        /// <summary>
        /// مشخصات وضعیت تحصیلی نهایی
        /// </summary>
        [ForeignKey(nameof(FinalStatusId))]
        public virtual BaseDefination FinalStatus { get; set; }

        /// <summary>
        /// تاریخ اعمال وضعیت نهایی
        /// </summary>
        [DisplayName("تاریخ اعمال وضعیت نهایی")]
        public DateTime? FinalStatusDate { get; set; }

        /// <summary>
        /// کد وضعیت تحصیلی تکمیلی
        /// </summary>
        [DisplayName("وضعیت تحصیلی تکمیلی")]
        public int? SupplementaryStatusId { get; set; }

        /// <summary>
        /// مشخصات وضعیت تحصیلی تکمیلی
        /// </summary>
        [ForeignKey(nameof(SupplementaryStatusId))]
        public virtual BaseDefination SupplementaryStatus { get; set; }

        /// <summary>
        /// وضعیت تسویه
        /// </summary>
        [DisplayName("وضعیت تسویه")]
        public virtual LiquidationStatus? LiquidationStatus { get; set; }

        /// <summary>
        /// کد مرکز تحقیقاتی
        /// </summary>
        [DisplayName("مرکز تحقیقاتی")]
        public int? SearchCenterId { get; set; }

        /// <summary>
        /// مشخصات مرکز تحقیقاتی
        /// </summary>
        [ForeignKey(nameof(SearchCenterId))]
        public virtual BaseDefination SearchCenter { get; set; }

        /// <summary>
        /// تاریخ تسویه
        /// </summary>
        [DisplayName("تاریخ تسویه")]
        public DateTime? LiquidationDate { get; set; }

        /// <summary>
        /// شماره پرونده
        /// </summary>
        [DisplayName("شماره پرونده")]
        public string FileNo { get; set; }

        /// <summary>
        /// کد دانشجو در رشته قبلی
        /// </summary>
        [DisplayName("کد دانشجو در رشته قبلی")]
        public string OldStudentCode { get; set; }

        /// <summary>
        /// کد استاد راهنما
        /// </summary>
        [DisplayName("استاد راهنما")]
        public int? LeaderId { get; set; }

        /// <summary>
        /// مشخصات استاد راهنما
        /// </summary>
        [ForeignKey(nameof(LeaderId))]
        public virtual Professor Leader { get; set; }

        /// <summary>
        /// کد رشته تحصیلی
        /// </summary>
        [DisplayName("رشته تحصیلی")]
        public int? StudyFieldId { get; set; }

        /// <summary>
        /// مشخصات رشته ی تحصیلی
        /// </summary>
        [ForeignKey(nameof(StudyFieldId))]
        public virtual StudyField StudyField { get; set; }

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
        [ForeignKey(nameof(SubTrendId))]
        public virtual SubTrend SubTrend { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [DisplayName("توضیحات"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// مشخصات شناسنامه ای دانشجو
        /// </summary>
        public virtual StdIdentification StdIdentification { get; set; }

        /// <summary>
        /// مشخصات لاتین دانشجو
        /// </summary>
        public virtual StdEnglishInfo StdEnglishInfo { get; set; }

        /// <summary>
        /// مشخصات خانوادگی دانشجو
        /// </summary>
        public virtual StudentFamilyProfile StudentFamilyProfile { get; set; }

        /// <summary>
        /// مشخصات پذیرش دانشجو
        /// </summary>
        public virtual StudentAccepting StudentAccepting { get; set; }

        /// <summary>
        /// مشخصات ایثارگری دانشجو
        /// </summary>
        public virtual StdSacrificial StdSacrificial { get; set; }

        /// <summary>
        /// سازمان حمایت کننده
        /// </summary>
        public virtual SupporterOrgan SupporterOrgan { get; set; }

        /// <summary>
        /// مشخصات شغلی
        /// </summary>
        public virtual JobInfo JobInfo { get; set; }

        /// <summary>
        /// فعالیت های فرهنگی
        /// </summary>
        public virtual CulturalAct CulturalAct { get; set; }

        /// <summary>
        /// اعضای خانواده دانشجو
        /// </summary>
        [CheckOnDelete("اعضای خانواده دانشجو در سیستم ثبت شده اند و امکان حذف آن وجود ندارد")]
        public virtual ICollection<StudentFamilyMember> Members { get; set; }

        /// <summary>
        /// موارد خاص دانشجو
        /// </summary>
        [CheckOnDelete("برای دانشجو مورد خاص ثبت شده و امکان حذف آن وجود ندارد")]
        public virtual ICollection<StudentExceptCase> StudentExceptCases { get; set; }

        /// <summary>
        /// انتخاب واحدهای دانشجو
        /// </summary>
        [CheckOnDelete("دانشجو دارای انتخاب واحد می باشد و امکان حذف وی وجود ندارد")]
        public virtual ICollection<SelectUnit> SelectUnits { get; set; }
    }
}
