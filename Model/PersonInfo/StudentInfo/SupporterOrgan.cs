using System;
using Model.Enums;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات سازمان حمایت کننده
    /// </summary>
    [Table("SupporterOrgans", Schema = "dbo")]
    public class SupporterOrgan
    {
        [Key, ForeignKey(nameof(Student))]
        public int SupporterOrganId { get; set; }

        /// <summary>
        /// نام سازمان حمایت کننده
        /// </summary>
        [DisplayName("نام سازمان حمایت کننده")]
        public SupporterOrganType? SupporterOrganType { get; set; }

        /// <summary>
        /// شماره نامه
        /// </summary>
        [DisplayName("شماره نامه")]
        public string LetterNo { get; set; }

        /// <summary>
        /// تاریخ نامه
        /// </summary>
        [DisplayName("تاریخ نامه")]
        public DateTime? LetterDate { get; set; }

        /// <summary>
        /// درصد پشتیبانی شهریه
        /// </summary>
        [DisplayName("درصد پشتیبانی شهریه")]
        public decimal? TuitionPercent { get; set; }

        /// <summary>
        /// نام بانک
        /// </summary>
        [DisplayName("نام بانک")]
        public string BankName { get; set; }

        /// <summary>
        /// نام شعبه
        /// </summary>
        [DisplayName("نام شعبه")]
        public string BranchName { get; set; }

        /// <summary>
        /// کد شعبه
        /// </summary>
        [DisplayName("کد شعبه")]
        public string BranchCode { get; set; }

        /// <summary>
        /// شماره حساب
        /// </summary>
        [DisplayName("شماره حساب")]
        public string AccountNo { get; set; }

        /// <summary>
        /// شماره 16 رقمی کارت
        /// </summary>
        [DisplayName("شماره 16 رقمی کارت")]
        public string CardNo { get; set; }

        /// <summary>
        /// کد شبا
        /// </summary>
        [DisplayName("کد شبا")]
        public string ShabaCode { get; set; }

        /// <summary>
        /// کد شناسه پرداخت
        /// </summary>
        [DisplayName("کد شناسه پرداخت")]
        public string PaymentCode { get; set; }

        /// <summary>
        /// کد بورسیه
        /// </summary>
        [DisplayName("بورسیه")]
        public int ScholarshipId { get; set; }

        /// <summary>
        /// مشخصات بورسیه
        /// </summary>
        [ForeignKey(nameof(ScholarshipId))]
        public virtual BaseDefination Scholarship { get; set; }

        /// <summary>
        /// ملاحظات
        /// </summary>
        [MaxLength(200), DisplayName("ملاحظات")]
        public string Comment { get; set; }

        /// <summary>
        /// مشخصات دانشجو
        /// </summary>
        public virtual Student Student { get; set; }
    }
}
