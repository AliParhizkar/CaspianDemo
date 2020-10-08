using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات خانوادگی دانشجو
    /// </summary>
    public class StudentFamilyProfile : PersonFamilyProfile
    {
        /// <summary>
        /// شماره همراه پدر
        /// </summary>
        [DisplayName("شماره همراه پدر")]
        public string FatherMobile { get; set; }

        /// <summary>
        /// شماره همراه مادر
        /// </summary>
        [DisplayName("شماره همراه مادر")]
        public string MotherMobile { get; set; }

        /// <summary>
        /// آدرس فعلی
        /// کد شهر محل سکونت
        /// </summary>
        [DisplayName("شهر محل سکونت")]
        public int? CurentCityId { get; set; }

        /// <summary>
        /// مشخصات شهر محل سکونت در آدرس فعلی
        /// </summary>
        [ForeignKey(nameof(CurentCityId))]
        public virtual City CurentCity { get; set; }

        /// <summary>
        /// آدرس فعلی
        /// خیابان-کوچه-پلاک-واحد
        /// </summary>
        [DisplayName("خیابان-کوچه-پلاک-واحد")]
        public string CurentAddress { get; set; }

        /// <summary>
        /// کد پستی در آدرس فعلی
        /// </summary>
        [DisplayName("کد پستی")]
        public string CurentPostalCode { get; set; }

        /// <summary>
        /// کد شهر سکونت در آدرس قبلی
        /// </summary>
        [DisplayName("شهر سکونت")]
        public int? PreCityId { get; set; }

        /// <summary>
        /// مشخصات شهر محل سکونت در آدرس قبلی
        /// </summary>
        [ForeignKey(nameof(PreCityId))]
        public virtual City PreCity { get; set; }

        /// <summary>
        /// آدرس قبلی
        /// خیابان-کوچه-پلاک-واحد
        /// </summary>
        [DisplayName("خیابان-کوچه-پلاک-واحد")]
        public string PreAddress { get; set; }

        /// <summary>
        /// کد پستی در آدرس قبلی
        /// </summary>
        [DisplayName("کدپستی")]
        public string PrePostalCode { get; set; }

        /// <summary>
        /// مشخصات دانشجو
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual Student Student { get; set; }
    }
}
