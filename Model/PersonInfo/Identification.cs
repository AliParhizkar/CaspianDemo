using System;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات شناسنامه ای فرد
    /// </summary>
    [Table("Identification", Schema = "dbo")]
    public class Identification
    {
        [Key, ForeignKey(nameof(Person)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        /// <summary>
        /// نام پدر
        /// </summary>
        [DisplayName("نام پدر")]
        public string FatherName { get; set; }

        /// <summary>
        /// نام مادر
        /// </summary>
        [DisplayName("نام مادر")]
        public string MotherName { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        [DisplayName("تاریخ تولد")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// تاریخ صدور
        /// </summary>
        [DisplayName("تاریح صدور")]
        public DateTime? RegDate { get; set; }

        /// <summary>
        /// کد شهر محل تولد
        /// </summary>
        [DisplayName("شهر محل تولد")]
        public int? BirthCityId { get; set; }

        /// <summary>
        /// مشخصات شهر محل تولد
        /// </summary>
        [ForeignKey(nameof(BirthCityId))]
        public virtual City BirthCity { get; set; }

        /// <summary>
        /// کد شهر محل صدور شناسنامه
        /// </summary>
        [DisplayName("شهر محل صدور شناسنامه")]
        public int? RegCityId { get; set; }

        /// <summary>
        /// مشخصات شهر محل صدور شناسنامه
        /// </summary>
        [ForeignKey(nameof(RegCityId))]
        public virtual City RegCity { get; set; }

        /// <summary>
        /// شماره ی شناسنامه
        /// </summary>
        [DisplayName("شماره شناسنامه")]
        public string Number { get; set; }

        /// <summary>
        /// کد ملی
        /// </summary>
        [DisplayName("کد ملی")]
        public string NationalCode { get; set; }

        /// <summary>
        /// ملاحظه 
        /// </summary>
        [DisplayName("ملاحظه"), MaxLength(200)]
        public string Descript { get; set; }

        /// <summary>
        /// مشخصات اصلی فرد
        /// </summary>
        public virtual AcademicPerson Person { get; set; }
    }
}
