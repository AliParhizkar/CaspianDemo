using System;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات فعالیت های امداد و نجات
    /// </summary>
    [Table("RescueActions", Schema = "dbo")]
    public class RescueAction
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عضویت در مراکز امداد و نجات
        /// </summary>
        [DisplayName("عضویت در مراکز امداد و نجات")]
        public bool? RescueActionMembership { get; set; }

        /// <summary>
        /// دارای مدرک از مراکز امداد و نجات
        /// </summary>
        [DisplayName("دارای مدرک از مراکز امداد و نجات")]
        public bool? RescueActionGrade { get; set; }

        /// <summary>
        /// تاریخ شروع عضویت
        /// </summary>
        [DisplayName("تاریخ شروع عضویت")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان عضویت
        /// </summary>
        [DisplayName("تاریخ پایان عضویت")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// کد مدرک امداد و نجات
        /// </summary>
        [DisplayName("مدرک امداد و نجات")]
        public int? RescueGradeTypeId { get; set; }

        /// <summary>
        /// مشخصات مدرک امداد و نجات
        /// </summary>
        [ForeignKey(nameof(RescueGradeTypeId))]
        public virtual BaseDefination RescueGradeType { get; set; }

        /// <summary>
        /// تاریخ اخذ مدرک
        /// </summary>
        [DisplayName("تاریخ اخذ مدرک")]
        public DateTime? GraduateDate { get; set; }

        /// <summary>
        /// دارای سوابق اجرایی
        /// </summary>
        [DisplayName("دارای سوابق اجرایی")]
        public bool? HasRecords { get; set; }

        /// <summary>
        /// ملاحضات
        /// </summary>
        [DisplayName("ملاحظات"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// کد فرد
        /// </summary>
        [DisplayName("فرد")]
        public int PersonId { get; set; }

        /// <summary>
        /// مشخصات فرد
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual AcademicPerson Person { get; set; }

    }
}
