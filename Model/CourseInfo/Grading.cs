using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseInfo
{
    /// <summary>
    /// شیوه ی نمره دهی 
    /// </summary>
    [Table("Gradings", Schema = "crs")]
    public class Grading
    {
        [Key, ForeignKey(nameof(Course)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        /// <summary>
        /// حداقل نمره ی پاسی
        /// </summary>
        [DisplayName("حداقل نمره پاسی")]
        public decimal? MinPassGrade { get; set; }

        /// <summary>
        /// حداقل نمره ی پاسی مهمانی به
        /// </summary>
        [DisplayName("حداقل نمره پاسی مهمان به")]
        public decimal? MinPassGradeHostTo { get; set; }

        /// <summary>
        /// حداقل نمره ی پاسی انتقال از
        /// </summary>
        [DisplayName("حداقل نمره پاسی انتقال از")]
        public decimal? MinPassGradeTransfer { get; set; }

        /// <summary>
        /// حداقل نمره ی پاسی تطبیق درس
        /// </summary>
        [DisplayName("حداقل نمره پاسی تطبیق درس"), Required, Range(0, 20)]
        public decimal? MinMatchGrade { get; set; }

        /// <summary>
        /// عدم موثر
        /// </summary>
        [DisplayName("عدم موثر")]
        public bool Noteffective { get; set; }

        /// <summary>
        /// در کارنامه نمایش داده نشود
        /// </summary>
        [DisplayName("در کارنامه نمایش داده نشود")]
        public bool WorkbookHide { get; set; }

        /// <summary>
        /// نوع نمره دهی
        /// </summary>
        [DisplayName("نوع نمره دهی")]
        public GradeType? GradeType { get; set; }

        /// <summary>
        /// عنوان اول-میان ترم
        /// </summary>
        [DisplayName("عنوان اول"), Required]
        public string Title1 { get; set; }

        /// <summary>
        /// درصد/حداکثر نمره ی اول
        /// </summary>
        [DisplayName("حداکثر نمره اول"), Required, Range(0, 20)]
        public decimal? Max1 { get; set; }

        /// <summary>
        /// عنوان دوم-طول ترم
        /// </summary>
        [DisplayName("عنوان دوم")]
        public string Title2 { get; set; }

        /// <summary>
        /// درصد/حداکثر نمره دوم
        /// </summary>
        [DisplayName("حداکثر نمره دوم")]
        public decimal? Max2 { get; set; }

        /// <summary>
        /// عنوان سوم-پروژه ترم
        /// </summary>
        [DisplayName("عنوان سوم")]
        public string Title3 { get; set; }

        /// <summary>
        /// درصد/حداکثر نمره سوم
        /// </summary>
        [DisplayName("حداکثر نمره سوم")]
        public decimal? Max3 { get; set; }

        /// <summary>
        /// عنوان چهارم-پروژه ترم
        /// </summary>
        [DisplayName("عنوان چهارم")]
        public string Title4 { get; set; }

        /// <summary>
        /// درصد/حداکثر نمره چهارم
        /// </summary>
        [DisplayName("حداکثر نمره چهارم")]
        public decimal? Max4 { get; set; }

        /// <summary>
        /// عنوان پنجم-پایان ترم
        /// </summary>
        [DisplayName("عنوان پنجم")]
        public string Title5 { get; set; }

        /// <summary>
        /// درصد/حداکثر نمره پنجم
        /// </summary>
        [DisplayName("حداکثر نمره پنجم")]
        public decimal? Max5 { get; set; }

        /// <summary>
        /// مشخصات درس
        /// </summary>
        public virtual CourseStudy Course { get; set; }
    }
}
