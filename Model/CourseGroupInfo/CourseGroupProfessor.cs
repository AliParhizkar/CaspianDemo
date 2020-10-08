using Model.Enums;
using Model.BaseInfo;
using System.ComponentModel;
using Model.PersonInfo.ProfessorInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// مشخصات گروههای درس-استاد
    /// </summary>
    [Table("CourseGroupProfessors")]
    public class CourseGroupProfessor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد زیرگروه
        /// </summary>
        [DisplayName("زیرگروه")]
        public int? UnderGroupId { get; set; }

        /// <summary>
        /// مشخصات زیرگروه
        /// </summary>
        [ForeignKey(nameof(UnderGroupId))]
        public virtual BaseDefination UnderGroup { get; set; }

        /// <summary>
        /// کد استاد
        /// </summary>
        [DisplayName("استاد"), Required]
        public int? ProfessorId { get; set; }

        [ForeignKey(nameof(ProfessorId))]
        public virtual Professor Professor { get; set; }

        /// <summary>
        /// کد گروه درسی
        /// </summary>
        [Required, DisplayName("گروه درسی")]
        public int CourseGroupId { get; set; }

        /// <summary>
        /// مشخصات گروه درسی
        /// </summary>
        [ForeignKey(nameof(CourseGroupId))]
        public virtual CourseGroup CourseGroup { get; set; }

        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [DisplayName("اولویت نمایش")]
        public int Periority { get; set; }

        /// <summary>
        /// برچسب
        /// </summary>
        [DisplayName("برچسب")]
        public CourseLable? CourseLable { get; set; }

        /// <summary>
        /// آیا با تداخل ثبت شود
        /// </summary>
        [DisplayName("ثبت با تداخل")]
        public bool? SaveByInterference { get; set; }

        /// <summary>
        /// عدم ارزشیابی
        /// </summary>
        [DisplayName("عدم ارزشیابی")]
        public bool? WidthoutValuing { get; set; }

        /// <summary>
        /// مشخصات نمره دهی
        /// </summary>
        public virtual CourseGroupGrading Grading { get; set; }
    }
}
