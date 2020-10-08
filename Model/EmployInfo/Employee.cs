using System;
using Model.Timing;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.BaseInfo;
using Caspian.Common;
using Model.Enums;

namespace Model.EmployInfo
{
    /// <summary>
    /// مشخصات کارمند
    /// </summary>
    [Table("Employees", Schema = "dbo")]
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد
        /// </summary>
        [DisplayName("کد"), Required, Unique("کارمندی با این کد در سیستم تعریف شده است")]
        public string Code { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [DisplayName("نام"), Required]
        public string FirstName { get; set; }

        /// <summary>
        /// تصویر کارمند
        /// </summary>
        [DisplayName("تصویر")]
        public byte[] Image { get; set; }

        [DisplayName("تصویر")]
        public string ImageId { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [DisplayName("نام خانوادگی"), Required]
        public string LastName { get; set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        [DisplayName("جنسیت"), Required]
        public Gender? Gender { get; set; }

        /// <summary>
        /// کد ملی
        /// </summary>
        [DisplayName("کد ملی"), Required]
        public string NatinalCode { get; set; }

        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        [DisplayName("شماره شناسنامه"), Required]
        public string CertificateNo { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        [DisplayName("تاریخ تولد")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// تاریخ صدور شناسنامه
        /// </summary>
        [DisplayName("تاریخ صدور شناسنامه")]
        public DateTime? RegisterDate { get; set; }

        /// <summary>
        /// کد محل تولد
        /// </summary>
        [DisplayName("شهر محل تولد")]
        [CheckOnInsert("شهری با کد {0} در سیستم وجود ندارد.")]
        public int? BirthCityId { get; set; }

        /// <summary>
        /// مشخصات شهر محل تولد
        /// </summary>
        [ForeignKey(nameof(BirthCityId))]
        public virtual City BirthCity { get; set; }

        /// <summary>
        /// کد شهر محل صدور شناسنامه
        /// </summary>
        [DisplayName("شهر محل صدور")]
        [CheckOnInsert("شهری با کد {0} در سیستم وجود ندارد.")]
        public int? RegisterCityId { get; set; }

        /// <summary>
        /// مشخصات شهر محل صدور شناسنامه
        /// </summary>
        [ForeignKey(nameof(RegisterCityId))]
        public virtual City RegisterCity { get; set; }

        /// <summary>
        /// نام پدر
        /// </summary>
        [DisplayName("نام پدر"), Required]
        public string ParentName { get; set; }

        /// <summary>
        /// نام سازمان
        /// </summary>
        [DisplayName("نام سازمان")]
        public string OrganName { get; set; }

        /// <summary>
        /// واحد سازمانی
        /// </summary>
        [DisplayName("واحد سازمانی")]
        public string OrganUnit { get; set; }

        /// <summary>
        /// پست سازمانی
        /// </summary>
        [DisplayName("پست سازمانی")]
        public string Post { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [DisplayName("توضیحات"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// مراقب های کارمند در امتحانات
        /// </summary>
        [CheckOnDelete("کارمند بعنوان مراقب ثبت شده و امکان حذف وی وجود ندارد.")]
        public virtual ICollection<Observing> Observings { get; set; }
    }
}
