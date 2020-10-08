using System;
using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// مشخصات حق التدریسی گروه درسی
    /// </summary>
    public class TeachingCourseGroupRight
    {
        [Key, ForeignKey(nameof(CourseGroupProfessor)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeachingCourseGroupRightId { get; set; }

        /// <summary>
        /// برچسب
        /// </summary>
        [DisplayName("برچسب")]
        public CourseLable? CourseLable { get; set; }

        /// <summary>
        /// حوزه پرداخت
        /// </summary>
        [DisplayName("حوزه پرداخت")]
        public PaymentArea? PaymentArea { get; set; }

        /// <summary>
        /// تعداد واحد تئوری
        /// </summary>
        [DisplayName("تعداد واحد تئوری")]
        public decimal? TheoryUnit { get; set; }

        /// <summary>
        /// تعداد واحد عملی
        /// </summary>
        [DisplayName("تعداد واحد عملی")]
        public decimal? PracticalUnit { get; set; }

        /// <summary>
        /// تعداد واحد کارگاهی
        /// </summary>
        [DisplayName("تعداد واحد کارگاهی")]
        public decimal? WorkUnit { get; set; }

        /// <summary>
        /// ساعت تئوری
        /// </summary>
        [DisplayName("ساعت تئوری")]
        public TimeSpan? TheoryHoure { get; set; }

        /// <summary>
        /// ساعت عملی
        /// </summary>
        [DisplayName("ساعت عملی")]
        public TimeSpan? PracticalHoure { get; set; }

        /// <summary>
        /// ساعت کارگاهی
        /// </summary>
        [DisplayName("ساعت کارگاهی")]
        public TimeSpan? WorkHoure { get; set; }

        /// <summary>
        /// تعداد جلسات تئوری
        /// </summary>
        [DisplayName("تعداد جلسات تئوری")]
        public CourseType? TheoryCourse { get; set; }

        /// <summary>
        /// تعداد جلسات عملی
        /// </summary>
        [DisplayName("تعداد جلسات عملی")]
        public CourseType? PracticalCourse { get; set; }

        /// <summary>
        /// تعداد جلسات کارگاهی
        /// </summary>
        [DisplayName("تعداد جلسات کارگاهی")]
        public CourseType? WorkCourse { get; set; }

        /// <summary>
        /// ضریب واحد تئوری
        /// </summary>
        [DisplayName("ضریب واحد تئوری")]
        public decimal? TheoryFactor { get; set; }

        /// <summary>
        /// ضریب واحد عملی
        /// </summary>
        [DisplayName("ضریب واحد عملی")]
        public decimal? PracticalFactor { get; set; }

        /// <summary>
        /// ضریب واحد کارگاهی
        /// </summary>
        [DisplayName("ضریب واحد کارگاهی")]
        public decimal? WorkFactor { get; set; }

        /// <summary>
        /// ضریب تعداد دانشجو
        /// </summary>
        [DisplayName("ضریب تعداد دانشجو")]
        public decimal? StudentsFactor { get; set; }

        /// <summary>
        /// ضریب زبان
        /// </summary>
        [DisplayName("ضریب زبان")]
        public decimal? Language { get; set; }

        /// <summary>
        /// ضریب مقطع
        /// </summary>
        [DisplayName("ضریب مقطع")]
        public decimal? SectionFactor { get; set; }

        /// <summary>
        /// مازاد اولین بار ارائه
        /// </summary>
        [DisplayName("مازاد اولین بار ارائه")]
        public decimal? MoreOne { get; set; }

        /// <summary>
        /// ضریب خاص
        /// </summary>
        [DisplayName("ضریب خاص")]
        public decimal? SpecialFactor { get; set; }

        /// <summary>
        /// واحد معادل خاص
        /// </summary>
        [DisplayName("واحد معادل خاص")]
        public int EqualSpecial { get; set; }

        /// <summary>
        /// مبلغ حق التدریسی خاص
        /// </summary>
        [DisplayName("مبلغ حق التدریسی خاص")]
        public int SpecialPayment { get; set; }

        /// <summary>
        /// مشخصات گروه درسی استاد
        /// </summary>
        public virtual CourseGroupProfessor CourseGroupProfessor { get; set; }
    }
}
