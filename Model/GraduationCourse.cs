//using Model.BaseInfo;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace LearningModel
//{
//    /// <summary>
//    /// دروس لازم برای فارغ التحصیلی
//    /// </summary>
//    public class GraduationCourse
//    {
//        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
//        public int Id { get; set; }

//        /// <summary>
//        /// کد رشته تحصیلی
//        /// </summary>
//        [DisplayName("رشته تحصیلی")]
//        public int StudyFieldId { get; set; }

//        /// <summary>
//        /// مشخصات رشته تحصیلی
//        /// </summary>
//        [ForeignKey(nameof(StudyFieldId))]
//        public virtual StudyField StudyField { get; set; }

//        /// <summary>
//        /// کد نوع درس از لحاظ آموزشی
//        /// </summary>
//        [DisplayName("نوع درس")]
//        public int CourseTypeId { get; set; }

//        /// <summary>
//        /// مشخصات نوع درس از لحاظ آموزشی
//        /// </summary>
//        [ForeignKey(nameof(CourseTypeId))]
//        public virtual BaseDefination CourseType { get; set; }

//        /// <summary>
//        /// تعداد واحد های لازم
//        /// </summary>
//        public byte? CourseUnitsCount { get; set; }
//    }
//}
