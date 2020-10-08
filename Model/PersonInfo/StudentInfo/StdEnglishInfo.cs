using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات لاتین فرد
    /// </summary>
    public class StdEnglishInfo : EnglishInfo
    {
        /// <summary>
        /// کشور تولد
        /// </summary>
        [DisplayName("Birth Country")]
        public string BirthCountry { get; set; }

        /// <summary>
        /// شهر تولد
        /// </summary>
        [DisplayName("Birth City")]
        public string BirthCity { get; set; }

        /// <summary>
        /// تاریخ انقضاء گذرنامه
        /// </summary>
        [DisplayName("Pass Expire Date")]
        public DateTime? PassExpireDate { get; set; }

        /// <summary>
        /// شماره ویزا
        /// </summary>
        [DisplayName("Visa No")]
        public string VisaNo { get; set; }

        [DisplayName("ID No")]
        public string IdNo { get; set; }

        /// <summary>
        /// مشخصات اصلی دانشجو
        /// </summary>
        [ForeignKey("PersonId")]
        public virtual Student Student { get; set; }
    }
}
