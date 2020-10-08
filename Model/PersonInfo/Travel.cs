using System;
using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات سفرهای خارجی فرد
    /// </summary>
    [Table("Travels", Schema = "dbo")]
    public class Travel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// نام کشور
        /// </summary>
        [DisplayName("نام کشور")]
        public string CountryName { get; set; }

        /// <summary>
        /// نوع مسافرت
        /// </summary>
        [DisplayName("نوع مسافرت")]
        public TravelType? TravelType { get; set; }

        /// <summary>
        /// نام سازمان مامور کننده
        /// </summary>
        [DisplayName("سازمان مامور کننده")]
        public string OrganName { get; set; }

        /// <summary>
        /// تاریخ رفت
        /// </summary>
        [DisplayName("تاریخ رفت")]
        public DateTime? DepartureDate { get; set; }

        /// <summary>
        /// تاریخ برگشت
        /// </summary>
        [DisplayName("تاریخ برگشت")]
        public DateTime? RefDate { get; set; }

        /// <summary>
        /// دستیابی به هدف
        /// </summary>
        [DisplayName("دستیابی به هدف")]
        public bool? Achievement { get; set; }

        /// <summary>
        /// اهداف مسافرت
        /// </summary>
        [MaxLength(200), DisplayName("اهداف مسافرت")]
        public string Target { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [MaxLength(200), DisplayName("توضیحات")]
        public string Comment { get; set; }

        /// <summary>
        /// کد فرد
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// مشخصات فرد
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual AcademicPerson Person { get; set; }
    }
}
