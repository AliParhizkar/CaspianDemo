using System;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات فعالیت های سیاسی
    /// </summary>
    [Table("PoliticsActions", Schema = "dbo")]
    public class PoliticsAction
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان فعالیت
        /// </summary>
        [DisplayName("عنوان فعالیت"), Required]
        public string Title { get; set; }

        /// <summary>
        /// کد نوع فعالیت
        /// </summary>
        [DisplayName("نوع فعالیت")]
        public int? PoliticsActionTypeId { get; set; }

        /// <summary>
        /// مشخصات نوع فعالیت
        /// </summary>
        [ForeignKey(nameof(PoliticsActionTypeId))]
        public virtual BaseDefination PoliticsActionType { get; set; }

        /// <summary>
        /// کد نوع عضویت
        /// </summary>
        [DisplayName("نوع عضویت")]
        public int? MembershipTypeId { get; set; }

        /// <summary>
        /// مشخصات نوع عضویت
        /// </summary>
        [ForeignKey(nameof(MembershipTypeId))]
        public virtual BaseDefination MembershipType { get; set; }

        /// <summary>
        /// سمت
        /// </summary>
        [DisplayName("سمت")]
        public string Post { get; set; }

        /// <summary>
        /// محل فعالیت/سازمان
        /// </summary>
        [DisplayName("محل فعالیت/سازمان")]
        public string Organ { get; set; }

        /// <summary>
        /// تاریخ شروع
        /// </summary>
        [DisplayName("تاریخ شروع")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان
        /// </summary>
        [DisplayName("تاریخ پایان")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// ملاحضات
        /// </summary>
        [DisplayName("ملاحضات")]
        public string Comment { get; set; }

        /// <summary>
        /// کد فرد
        /// </summary>
        [DisplayName("استاد")]
        public int PersonId { get; set; }

        /// <summary>
        /// مشخصات فرد
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual AcademicPerson Person { get; set; }
    }
}
