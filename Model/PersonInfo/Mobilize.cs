using System;
using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// سوابق بسیج
    /// </summary>
    [Table("Mobilizes")]
    public class Mobilize
    {
        [Key, ForeignKey(nameof(Person)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        /// <summary>
        /// شماره کارت بسیج
        /// </summary>
        [DisplayName("شماره کارت بسیج")]
        public string CardNumber { get; set; }

        /// <summary>
        /// نوع فعالیت
        /// </summary>
        [DisplayName("نوع فعالیت")]
        public MobilizeActionType? MobilizeActionType { get; set; }

        /// <summary>
        /// نام پایگاه
        /// </summary>
        [DisplayName("نام پایگاه")]
        public string CenterName { get; set; }

        /// <summary>
        /// مدت فعالیت
        /// </summary>
        [DisplayName("مدت فعالیت")]
        public int? ActiveTerm { get; set; }

        /// <summary>
        /// تاریخ عضویت
        /// </summary>
        [DisplayName("تاریخ عضویت")]
        public DateTime? MembershipDate { get; set; }

        /// <summary>
        /// آدرس
        /// </summary>
        [MaxLength(200), DisplayName("آدرس")]
        public string Address { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [MaxLength(200), DisplayName("توضیحات")]
        public string Comment { get; set; }

        public virtual AcademicPerson Person { get; set; }
    }
}
