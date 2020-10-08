using Model.BaseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Enums;
using Caspian.Common;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات فرد
    /// </summary>
    [Table("People", Schema = "dbo")]
    public class AcademicPerson
    {
        /// <summary>
        /// کد فرد
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد فرد
        /// </summary>
        [DisplayName("کد")]
        public string Code { get; set; }

        /// <summary>
        /// نام 
        /// </summary>
        [DisplayName("نام")]
        public string FName { get; set; }

        [DisplayName("نام نام خانوادگی"), NotMapped]
        public string FLName { get; set; }

        /// <summary>
        /// نام خانوادگی 
        /// </summary>
        [DisplayName("نام خانوادگی"), Required]
        public string LName { get; set; }

        /// <summary>
        /// کد نوع پرونده
        /// </summary>
        [DisplayName("نوع پرونده")]
        public int? FileTypeId { get; set; }

        /// <summary>
        /// مشخصات نوع پرونده
        /// </summary>
        [ForeignKey(nameof(FileTypeId))]
        public virtual BaseDefination FileType { get; set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        [DisplayName("جنسیت"), Required]
        public Gender? Gender { get; set; }

        /// <summary>
        /// شماره پرونده
        /// </summary>
        [DisplayName("شماره پرونده")]
        public string FileNumber { get; set; }

        /// <summary>
        /// آدرس الکترونیکی
        /// </summary>
        [DisplayName("آدرس الکترونیکی"), EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// تلفن ثابت
        /// </summary>
        [DisplayName("تلفن ثابت")]
        public string Tel { get; set; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        [DisplayName("تلفن همراه")]
        public string Mobile { get; set; }

        /// <summary>
        /// ملاحضات
        /// </summary>
        [DisplayName("ملاحضات"), MaxLength(200)]
        public string Descript { get; set; }

        /// <summary>
        /// تماس اضطراری
        /// </summary>
        [DisplayName("تماس اضطراری")]
        public string EmergencyCall { get; set; }

        /// <summary>
        /// تصویر
        /// </summary>
        [DisplayName("تصویر")]
        public byte[] Image { get; set; }

        /// <summary>
        /// کد تصویر
        /// </summary>
        [DisplayName("تصویر")]
        public string ImageId { get; set; }

        /// <summary>
        /// مشخصا تشناسنامه ای فرد
        /// </summary>
        public virtual Identification Identification { get; set; }

        /// <summary>
        /// مشخصات خانوادگی
        /// </summary>
        public virtual PersonFamilyProfile FamilyProfile { get; set; }

        /// <summary>
        /// مشخصات فرد به لاتین
        /// </summary>
        public virtual EnglishInfo EnglishInfo { get; set; }

        /// <summary>
        /// سوابق بسیج
        /// </summary>
        public virtual Mobilize Mobilize { get; set; }

        /// <summary>
        /// وضعیت جسمانی
        /// </summary>
        public virtual physicalIState PhysicalIState { get; set; }

        /// <summary>
        /// فعالیتهای سیاسی
        /// </summary>
        [CheckOnDelete("برای این فرد فعالیت سیاسی ثبت شده و امکان حذف وی وجود ندارد.")]
        public virtual ICollection<PoliticsAction> PoliticsActions { get; set; }

        /// <summary>
        /// مدارک تحصیلی فرد
        /// </summary>
        [CheckOnDelete("برای این شخص مدارک تحصیلی تعریف شده و امکان حذف وی وجود ندارد.")]
        public virtual ICollection<Degree> Degrees { get; set; }

        /// <summary>
        /// مشخصات بستگان در مسابقات
        /// </summary>
        [CheckOnDelete("این فرد دارای بستگان در مسابقات می باشد و امکان حذف وی وجود ندارد")]
        public virtual ICollection<RaceRelation> RaceRelations { get; set; }

        /// <summary>
        /// فعالیتهای امداد و نجات
        /// </summary>
        [CheckOnDelete("برای این فرد فعالیت امداد و نجات ثبت شده و امکان حذف وی وجود ندارد")]
        public virtual ICollection<RescueAction> RescueActions { get; set; }

        /// <summary>
        /// تحصیلات حوزوی
        /// </summary>
        [CheckOnDelete("این فرد دارای تحصیلات حوزوی می باشد و امکان حذف وی وجود ندارد")]
        public virtual ICollection<Seminary> Seminaries { get; set; }

        /// <summary>
        /// سفرهای خارجی فرد
        /// </summary>
        [CheckOnDelete("برای این فرد سفر خارجی ثبت شده و امکان حذف وی وجود ندارد.")]
        public virtual ICollection<Travel> Travels { get; set; }

        /// <summary>
        /// عناوین ورزشی فرد
        /// </summary>
        [CheckOnDelete("برای این فرد عناوین ورزشی ثبت شده و امکان حذف وی وجود ندارد.")]
        public virtual ICollection<ExerciseTitle> ExerciseTitles { get; set; }

        /// <summary>
        /// مشخصات زبانهای فرد
        /// </summary>
        [CheckOnDelete("برای این فرد زبان خارجی تعریف شده و امکان حذف وی وجود ندارد")]
        public virtual ICollection<Language> Languages { get; set; }

        /// <summary>
        /// نسبت های این فرد با نخبگان
        /// </summary>
        [CheckOnDelete("برای این فرد نسبت با نخبگان ثبت شده و امکان حذف وی وجود ندارد.")]
        public virtual ICollection<EliteRelation> EliteRelations { get; set; }
    }
}
