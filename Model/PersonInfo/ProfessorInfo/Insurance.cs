using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.ProfessorInfo
{
    /// <summary>
    /// مشخصات بیمه ای
    /// </summary>
    [Table("Insurances", Schema = "dbo")]
    public class Insurance
    {
        /// <summary>
        /// کد استاد
        /// </summary>
        [Key, ForeignKey(nameof(Professor))]
        public int ProfessorId { get; set; }

        /// <summary>
        /// شماره ی بیمه
        /// </summary>
        [DisplayName("شماره بیمه")]
        public string InsuranceNo { get; set; }

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
        /// بیمه ی تکمیلی عمر و حوادث
        /// </summary>
        [DisplayName("بیمه تکمیلی عمر و حوادث")]
        public string LIfeAccidents { get; set; }

        /// <summary>
        /// شماره بیمه تکمیلی عمر و حوادث
        /// </summary>
        [DisplayName("شماره بیمه تکمیلی عمر و حوادث")]
        public string LIfeAccidentsNo { get; set; }

        /// <summary>
        /// بیمه تکمیلی درمان
        /// </summary>
        [DisplayName("بیمه تکمیلی درمان")]
        public string Health { get; set; }

        /// <summary>
        /// شماره ی بیمه ی تکمیلی درمان
        /// </summary>
        [DisplayName("شماره بیمه تکمیلی درمان")]
        public string HealthNo { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [MaxLength(200), DisplayName("توضیحات")]
        public string Comment { get; set; }

        /// <summary>
        /// مشخصات استاد
        /// </summary>
        public virtual Professor Professor { get; set; }
    }
}
