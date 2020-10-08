using System;
using Model.Enums;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات بستگان در مسابقات
    /// </summary>
    [Table("RaceRelations", Schema = "dbo")]
    public class RaceRelation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [DisplayName("نام")]
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        [DisplayName("جنسیت")]
        public Gender? Gender { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        [DisplayName("تاریخ تولد")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// کد تحصیلات
        /// </summary>
        [DisplayName("تحصیلات")]
        public int? EducationId { get; set; }

        /// <summary>
        /// مشخصات تحصیلات
        /// </summary>
        [ForeignKey(nameof(EducationId))]
        public virtual BaseDefination Education { get; set; }

        /// <summary>
        /// شغل
        /// </summary>
        [DisplayName("شغل")]
        public string Job { get; set; }

        /// <summary>
        /// نسبت
        /// </summary>
        [DisplayName("نسبت")]
        public FamiliarityType? FamiliarityType { get; set; }

        /// <summary>
        /// کد نوع مسابقه/جشنواره
        /// </summary>
        [DisplayName("نوع مسابقه/جشنواره")]
        public int? RaceTypeId { get; set; }

        /// <summary>
        /// مشخصات مسابقه/جشنواره
        /// </summary>
        [ForeignKey(nameof(RaceTypeId))]
        public virtual BaseDefination RaceType { get; set; }

        /// <summary>
        /// عنوان مسابقه/جشنواره
        /// </summary>
        [DisplayName("عنوان مسابقه/جشنواره"), MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// سال اخذ مقام
        /// </summary>
        [DisplayName("سال اخذ مقام")]
        public int? DignityYear { get; set; }

        /// <summary>
        /// مقام کسب شده
        /// </summary>
        [DisplayName("مقام کسب شده")]
        public Dignity? Dignity { get; set; }

        /// <summary>
        /// محل برگزاری
        /// </summary>
        [DisplayName("محل برگزاری")]
        public string Location { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [DisplayName("توضیحات"), MaxLength(200)]
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
