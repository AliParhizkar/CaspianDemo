using System;
using Model.Enums;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات شغلی دانشجو
    /// </summary>
    [Table("JobInfoes", Schema = "dbo")]
    public class JobInfo
    {
        [Key, ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        /// <summary>
        /// کد وضعیت فعلی اشتغال
        /// </summary>
        [DisplayName("وضعیت فعلی اشتغال")]
        public int? CurentJobStatusId { get; set; }

        /// <summary>
        /// مشخصات وضعیت فعلی اشتغال
        /// </summary>
        [ForeignKey(nameof(CurentJobStatusId))]
        public virtual BaseDefination CurentJobStatus { get; set; }

        /// <summary>
        /// کد سهمیه در استان
        /// </summary>
        [DisplayName("سهمیه در استان")]
        public int? ProvinceId { get; set; }

        /// <summary>
        /// مشخصات سهمیه در استان
        /// </summary>
        [ForeignKey(nameof(ProvinceId))]
        public virtual Province Province { get; set; }

        /// <summary>
        /// نوع استخدام
        /// </summary>
        [DisplayName("نوع استخدام")]
        public EmployType? EmployType { get; set; }

        /// <summary>
        /// محل خدمت
        /// </summary>
        [DisplayName("محل خدمت")]
        public string ServiceLocation { get; set; }

        /// <summary>
        /// نوع سازمان
        /// </summary>
        [DisplayName("نوع سازمان")]
        public OrganType? OrganType { get; set; }

        /// <summary>
        /// شماره سند ثبتی
        /// </summary>
        [DisplayName("شماره سند ثبتی")]
        public string VoucherNo { get; set; }

        /// <summary>
        /// پست سازمان
        /// </summary>
        [DisplayName("پست سازمانی")]
        public string OrganPost { get; set; }

        /// <summary>
        /// تاریخ تعهد
        /// </summary>
        [DisplayName("تاریخ تعهد")]
        public DateTime? CommitmentDate { get; set; }

        /// <summary>
        /// میزان حقوق ماهیانه
        /// </summary>
        [DisplayName("میزان حقوق ماهیانه")]
        public int? Pension { get; set; }

        /// <summary>
        /// محل تنظیم سند
        /// </summary>
        [DisplayName("محل تنظیم سند")]
        public string VoucherLocation { get; set; }

        /// <summary>
        /// نام و نام خانوادگی مسئول مستقیم
        /// </summary>
        [DisplayName("مسئول مستقیم")]
        public string UndertakingName { get; set; }

        /// <summary>
        /// شماره مستخدم
        /// </summary>
        [DisplayName("شماره مستخدم")]
        public string EmployeeNo { get; set; }

        /// <summary>
        /// کد پرسنلی
        /// </summary>
        [DisplayName("کد پرسنلی")]
        public string PersoneliCode { get; set; }

        /// <summary>
        /// محل تامین درآمد
        /// </summary>
        [DisplayName("محل تامین درآمد")]
        public string IncomeLocation { get; set; }

        /// <summary>
        /// کد نوع بیمه
        /// </summary>
        [DisplayName("نوع بیمه")]
        public int? InsuranceTypeId { get; set; }

        /// <summary>
        /// مشخصات نوع بیمه
        /// </summary>
        [ForeignKey(nameof(InsuranceTypeId))]
        public virtual BaseDefination InsuranceType { get; set; }

        /// <summary>
        /// عنوان شغلی
        /// </summary>
        [DisplayName("عنوان شغلی")]
        public string JobTitle { get; set; }

        /// <summary>
        /// پروانه پزشکی
        /// </summary>
        [DisplayName("پروانه پزشکی")]
        public string MedicalLicense { get; set; }

        /// <summary>
        /// وضعیت انجام خدمات نیروی انسانی
        /// </summary>
        [DisplayName("وضعیت انجام خدمات نیروی انسانی")]
        public ManpowerStatusType? ManpowerStatusType { get; set; }

        /// <summary>
        /// آدرس محل کار
        /// </summary>
        [DisplayName("آدرس محل کار"), MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// ملاحظات
        /// </summary>
        [DisplayName("ملاحظات"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// مشخصات دانشجو
        /// </summary>
        public virtual Student Student { get; set; }
    }
}
