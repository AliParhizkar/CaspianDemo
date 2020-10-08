using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات شناسنامه ای دانشجو
    /// </summary>
    public class StdIdentification : Identification
    {
        /// <summary>
        /// کد کشور محل تولد
        /// </summary>
        [DisplayName("کشور محل تولد")]
        public int? CountryId { get; set; }

        /// <summary>
        /// مشخصات کشور محل تولد
        /// </summary>
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        /// <summary>
        /// شماره سریال شناسنامه
        /// </summary>
        [DisplayName("سریال شناسنامه")]
        public string SerialNo { get; set; }

        /// <summary>
        /// نام قدیم
        /// </summary>
        [DisplayName("نام قدیم")]
        public string OldFirstName { get; set; }

        /// <summary>
        /// نام خانوادگی قدیم
        /// </summary>
        [DisplayName("نام خانوادگی قدیم")]
        public string OldLastName { get; set; }

        /// <summary>
        /// بخش محل تولد
        /// </summary>
        [DisplayName("بخش محل تولد")]
        public string BirthRegion { get; set; }

        /// <summary>
        /// مشخصات اصلی دانشجو
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual Student Student { get; set; }
    }
}
