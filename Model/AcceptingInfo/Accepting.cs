using System;
using Model.Enums;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caspian.Common;

namespace Model.AcceptingInfo
{
    /// <summary>
    /// مشخصات پذیرش
    /// </summary>
    [Table("Acceptings")]
    public class Accepting
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان پذیرش
        /// </summary>
        [DisplayName("عنوان پذیرش"), Required, Unique("پذیرشی با این عنوان در سیستم ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// سال ورود
        /// </summary>
        [DisplayName("سال ورود")]
        public short? EntranceYear { get; set; }

        /// <summary>
        /// نیمسال ورودی
        /// </summary>
        [DisplayName("نیمسال ورود")]
        public TermKind? EntranceTerm { get; set; }

        /// <summary>
        /// ضریب شهریه
        /// </summary>
        [DisplayName("ضریب شهریه")]
        public decimal? TuitionFactor { get; set; }

        /// <summary>
        /// پذیرش فعال باشد
        /// </summary>
        [DisplayName("پذیرش فعال باشد")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// تاریخ شروع ثبت نام
        /// </summary>
        [DisplayName("تاریخ شروع ثبت نام")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان ثبت نام
        /// </summary>
        [DisplayName("تاریخ پایان ثبت نام")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// فرمولهای تولید کد
        /// </summary>
        //[CheckOnDelete("برای پذیرش فرمول ثبت شده است و امکان حذف آن وجود ندارد.")]
        //public virtual ICollection<StudentCodeFormula> StudentCodeFormulas { get; set; }

        /// <summary>
        /// پرداخت های پذیرش
        /// </summary>
        [CheckOnDelete("برای پذیرش پرداخت ثبت شده است و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<Payments> Payments { get; set; }

        /// <summary>
        /// اسناد مورد نیاز پذیرش
        /// </summary>
        [CheckOnDelete("برای پذیرش سند ثبت شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<AcceptingDocuments> AcceptingDocuments { get; set; }

        /// <summary>
        /// دانشجویان پذیرفته شده
        /// </summary>
        [CheckOnDelete("برای پذیرش دانشجو ثبت شده و امکان حذف آن وجود ندارد")]
        public virtual ICollection<StudentAccepting> Students { get; set; }
    }
}
