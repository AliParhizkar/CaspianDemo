using System;
using Model.Enums;
using Model.Timing;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseInfo
{
    /// <summary>
    /// جزئیات دروس
    /// </summary>
    [Table("CourseDetails", Schema = "crs")]
    public class CourseDetail
    {
        [Key, ForeignKey(nameof(Course)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        /// <summary>
        /// کد امتحان
        /// </summary>
        [DisplayName("امتحان")]
        public int? ExamTimeId { get; set; }

        /// <summary>
        /// مشخصات امتحان
        /// </summary>
        [ForeignKey(nameof(ExamTimeId))]
        public virtual ExamTime ExamTime { get; set; }

        /// <summary>
        /// مرحله تحصیلی
        /// </summary>
        [DisplayName("مرحله تحصیلی")]
        public StudyStemp? StudyStemp { get; set; }

        /// <summary>
        /// مرحله تحصیلی ارائه درس
        /// </summary>
        [DisplayName("مرحله تحصیلی ارائه درس")]
        public StudyStemp? StudyStempOffer { get; set; }

        /// <summary>
        /// کد مقطع پاسی
        /// </summary>
        [DisplayName("مقطع پاسی")]
        public int? PassageSectionId { get; set; }

        /// <summary>
        /// مشخصات مقطع پاسی
        /// </summary>
        [ForeignKey(nameof(PassageSectionId))]
        public virtual BaseDefination PassageSection { get; set; }

        /// <summary>
        /// کد مقطع درمانی
        /// </summary>
        [DisplayName("مقطع درمانی")]
        public int? HealingId { get; set; }

        /// <summary>
        /// مشخصات مقطع درمانی
        /// </summary>
        [ForeignKey(nameof(HealingId))]
        public virtual BaseDefination Healing { get; set; }

        /// <summary>
        /// کد گرایش
        /// </summary>
        [DisplayName("گرایش")]
        public int? TrendId { get; set; }

        /// <summary>
        /// مشخصات گرایش
        /// </summary>
        [ForeignKey(nameof(TrendId))]
        public virtual Trend Trend { get; set; }

        /// <summary>
        /// کد زیرگرایش
        /// </summary>
        [DisplayName("زیرگرایش")]
        public int? SubTrendId { get; set; }

        /// <summary>
        /// مشخصات زیرگرایش
        /// </summary>
        [ForeignKey(nameof(SubTrendId))]
        public virtual SubTrend SubTrend { get; set; }

        /// <summary>
        /// از سال ورود
        /// </summary>
        [DisplayName("از سال ورود")]
        public int? EntranceYearFrom { get; set; }

        /// <summary>
        /// تا سال ورود
        /// </summary>
        [DisplayName("تا سال ورود")]
        public int? EntranceYearTo { get; set; }

        /// <summary>
        /// تعداد روزهای خالی جهت اخذ
        /// </summary>
        [DisplayName("تعداد روزهای خالی جهت اخذ")]
        public byte? DaysCount { get; set; }

        /// <summary>
        /// حداکثر ساعت ارائه درهر روز
        /// </summary>
        [DisplayName("حداکثر ساعت ارائه در هر روز")]
        public TimeSpan? MaxHoureInDay { get; set; }

        /// <summary>
        /// کد نوع چارت اول
        /// </summary>
        [DisplayName("نوع چارت اول")]
        public int? Chart1TypeId { get; set; }

        /// <summary>
        /// مشخصات نوع چارت اول
        /// </summary>
        [ForeignKey(nameof(Chart1TypeId))]
        public virtual BaseDefination Chart1Type { get; set; }

        /// <summary>
        /// کد نوع چارت دوم
        /// </summary>
        [DisplayName("نوع چارت دوم")]
        public int? Chart2TypeId { get; set; }

        /// <summary>
        /// مشخصات نوع چارت دوم
        /// </summary>
        [ForeignKey(nameof(Chart2TypeId))]
        public virtual BaseDefination Chart2Type { get; set; }

        /// <summary>
        /// کد ماهیت درس
        /// </summary>
        [DisplayName("ماهیت درس")]
        public int? CourseNatureId { get; set; }

        /// <summary>
        /// ماهیت درس
        /// </summary>
        [ForeignKey(nameof(CourseNatureId))]
        public virtual BaseDefination CourseNature { get; set; }

        /// <summary>
        /// نوع درس از لحاظ فارغ التحصیلی
        /// </summary>
        [DisplayName("نوع درس از لحاظ فارغ التحصیلی")]
        public GraduatedCourseType? GraduatedCourseType { get; set; }

        /// <summary>
        /// عضو دسته
        /// </summary>
        [DisplayName("عضو دسته")]
        public GroupMember? GroupMember { get; set; }

        /// <summary>
        /// کد درس در سازمان بالادستی
        /// </summary>
        [DisplayName("کد درس در سازمان بالادستی")]
        public string CourseCode { get; set; }

        /// <summary>
        /// دیسپلین درس
        /// </summary>
        [DisplayName("دیسپلین درس")]
        public int? DispilineId { get; set; }

        /// <summary>
        /// مشخصات دسپلین درس
        /// </summary>
        [ForeignKey(nameof(DispilineId))]
        public virtual BaseDefination Dispiline { get; set; }

        /// <summary>
        /// ترم انتخابی
        /// </summary>
        [DisplayName("ترم انتخابی")]
        public SelectTrm? SelectTrm { get; set; }

        /// <summary>
        /// کد نوع ارزشیابی دانشجو از استاد
        /// </summary>
        [DisplayName("نوع ارزشیابی دانشجو از استاد")]
        public int? ProfessorValidationId { get; set; }

        /// <summary>
        /// مشخصات نوع ارزشیابی دانشجو از استاد
        /// </summary>
        [ForeignKey(nameof(ProfessorValidationId))]
        public virtual BaseDefination ProfessorValidation { get; set; }

        /// <summary>
        /// کد نو ع ارزشیابی دانشجو از استاد
        /// </summary>
        [DisplayName("نوع ارشیابی دانشجو از استاد")]
        public int? StudentValidationId { get; set; }

        /// <summary>
        /// مشخصات نوع ارزشیابی دانشجو از استاد
        /// </summary>
        [ForeignKey(nameof(StudentValidationId))]
        public virtual BaseDefination StudentValidation { get; set; }

        /// <summary>
        /// مشخصات درس
        /// </summary>
        [Required]
        public virtual Course Course { get; set; }

    }
}
