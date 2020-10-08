using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// مشخصات نمره دهی گروه های درسی استاد
    /// </summary>
    [Table("CourseGroupsProfessors")]
    public class CourseGroupGrading
    {
        [Key, ForeignKey(nameof(CourseGroupProfessor)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseGroupProfessorId { get; set; }

        /// <summary>
        /// سهم استاد در نمره کل
        /// </summary>
        [DisplayName("سهم استاد در نمره کل")]
        public decimal? ProfessorPortion { get; set; }

        /// <summary>
        /// سهم بخش اول در کل نمره
        /// </summary>
        [DisplayName("سهم بخش اول")]
        public decimal Percent1 { get; set; }

        /// <summary>
        /// سهم بخش دوم در کل نمره
        /// </summary>
        [DisplayName("سهم بخش دوم")]
        public decimal? Percent2 { get; set; }

        /// <summary>
        /// سهم بخش سوم در کل نمره
        /// </summary>
        [DisplayName("سهم بخش سوم")]
        public decimal? Percent3 { get; set; }

        /// <summary>
        /// سهم بخش چهارم در کل نمره
        /// </summary>
        [DisplayName("سهم بخش چهارم")]
        public decimal? Percent4 { get; set; }

        /// <summary>
        /// مشخصات گروه درسی استاد
        /// </summary
        public virtual CourseGroupProfessor CourseGroupProfessor { get; set; }
    }
}
