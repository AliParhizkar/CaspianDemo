using System;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات مقاطع تحصیلی فرد
    /// </summary>
    [Table("Degrees", Schema = "dbo")]
    public class Degree
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// کد مقطع تحصیلی
        /// </summary>
        [DisplayName("مقطع تحصیلی"), Required]
        public int? GradeId { get; set; }

        /// <summary>
        /// مشخصات مقطع تحصیلی
        /// </summary>
        [ForeignKey(nameof(GradeId))]
        public virtual Grade Grade { get; set; }

        /// <summary>
        /// عنوان رشته تحصیلی
        /// </summary>
        [DisplayName("عنوان رشته تحصیلی"), Required]
        public string StudyFieldTitle { get; set; }

        /// <summary>
        /// کد گروه تحصیلی
        /// </summary>
        [DisplayName("گروه تحصیلی")]
        public int? DepartmentId { get; set; }

        /// <summary>
        /// گروه تحصیلی 
        /// </summary>
        [ForeignKey(nameof(DepartmentId))]
        public virtual BaseDefination Department { get; set; }

        /// <summary>
        /// گرایش تحصیلی
        /// </summary>
        [DisplayName("گرایش تحصیلی")]
        public string Orientation { get; set; }

        /// <summary>
        /// سال اخذ
        /// </summary>
        [DisplayName("سال اخذ")]
        public short? GraduateYear { get; set; }

        /// <summary>
        /// کشور محل اخذ
        /// </summary>
        [DisplayName("کشور محل اخذ")]
        public string GraduateCountry { get; set; }

        /// <summary>
        /// شهر محل اخذ
        /// </summary>
        [DisplayName("شهر محل اخذ")]
        public string GraduateCity { get; set; }

        /// <summary>
        /// معدل کل مدرک تحصیلی
        /// </summary>
        [DisplayName("معدل کل مدرک تحصیلی"), Range(10, 20)]
        public decimal? Average { get; set; }

        /// <summary>
        /// موسسه ی آموزش عالی محل اخذ
        /// </summary>
        [DisplayName("موسسه آموزش عالی محل اخذ")]
        public string GraduateInstitute { get; set; }

        /// <summary>
        /// کد وضعیت تحصیلی
        /// </summary>
        [DisplayName("وضعیت تحصیلی")]
        public int? StudyId { get; set; }

        /// <summary>
        /// مشخصات وضعیت تحصیلی
        /// </summary>
        [ForeignKey(nameof(StudyId))]
        public virtual BaseDefination Study { get; set; }

        /// <summary>
        /// تاریخ شروع
        /// </summary>
        [DisplayName("تاریخ شروع")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// تاریخ فراقت
        /// </summary>
        [DisplayName("تاریخ فراقت")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// تخصص
        /// </summary>
        [DisplayName("تخصص")]
        public string Expertise { get; set; }

        /// <summary>
        /// عنوان پایان نامه
        /// </summary>
        [DisplayName("عنوان پایان نامه"), MaxLength(100)]
        public string ThesisTitle { get; set; }

        /// <summary>
        /// آیا این آخرین مدرک هست
        /// </summary>
        [DisplayName("آخرین مدرک هست")]
        public bool? IsLastDegree { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [DisplayName("توضیحات"), MaxLength(200)]
        public string Descript { get; set; }

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
