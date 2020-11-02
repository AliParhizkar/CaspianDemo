using Caspian.Common;
using Model.BaseInfo;
using Model.CourseGroupInfo;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.ProfessorInfo
{
    /// <summary>
    /// مشخصات اصلی استاد
    /// </summary>
    public class Professor : AcademicPerson
    {
        /// <summary>
        /// کد گروه آموزشی
        /// </summary>
        [DisplayName("گروه آموزشی"), Required]
        public int? DepartmentId { get; set; }

        /// <summary>
        /// مشخصات گروه آموزشی
        /// </summary>
        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        /// <summary>
        /// شهرت دانشگاهی
        /// </summary>
        [DisplayName("شهرت دانشگاهی")]
        public string Reputation { get; set; }

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
        /// آدرس شغلی
        /// کد شهر
        /// </summary>
        [DisplayName("شهر")]
        public int? JobCityId { get; set; }

        /// <summary>
        /// آدرس شغلی
        /// شهر
        /// </summary>
        [ForeignKey(nameof(JobCityId))]
        public virtual City JobCity { get; set; }

        /// <summary>
        /// آدرس شغلی
        /// خیابان-کوچه-پلاک-واحد
        /// </summary>
        [DisplayName("خیابان-کوچه-پلاک-واحد")]
        public string JobAddress { get; set; }

        /// <summary>
        /// آدرس شغلی
        /// کد پستی
        /// </summary>
        [DisplayName("کد پستی")]
        public string JobPostalCode { get; set; }

        /// <summary>
        /// استاد
        /// </summary>
        [DisplayName("استاد")]
        public bool? IsProfessor { get; set; }

        /// <summary>
        /// پژوهشگر
        /// </summary>
        [DisplayName("پژوهشگر")]
        public bool? IsResearcher { get; set; }

        /// <summary>
        /// داور خارجی
        /// </summary>
        [DisplayName("داور خارجی")]
        public bool? IsReferee { get; set; }

        /// <summary>
        /// مشخصات پایه ای حکم
        /// </summary>
        public virtual ProfessorEmployment Employment { get; set; }

        /// <summary>
        /// مشخصات حساب بانکی
        /// </summary>
        public virtual BankAccount BankAccount { get; set; }

        /// <summary>
        /// سوابق بیمه ای
        /// </summary>
        public virtual Insurance Insurance { get; set; }

        /// <summary>
        /// تمامی دانشجویانی که این استاد راهنمای آنها می باشد
        /// </summary>
        [CheckOnDelete("تمامی دانشجویانی که این استاد راهنمای آنها می باشد")]
        public virtual ICollection<Student> Students { get; set; }

        /// <summary>
        /// گروههای درسی ای که توسط این استاد ارائه شده اند
        /// </summary>
        [CheckOnDelete("این استاد ارائه کننده برخی از دروس می باشد و امکان حذف وی وجود ندارد.")]
        public virtual ICollection<CourseGroupProfessor> CourseGroupProfessors { get; set; }
    }
}
