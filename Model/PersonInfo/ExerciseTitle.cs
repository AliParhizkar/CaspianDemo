using Model.Enums;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// عناوین ورزشی
    /// </summary>
    [Table("ExerciseTitles", Schema = "dbo")]
    public class ExerciseTitle
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// کد نوع ورزش
        /// </summary>
        [DisplayName("نوع ورزش")]
        public int? ExerciseTypeId { get; set; }

        /// <summary>
        /// مشخصات نوع ورزش
        /// </summary>
        [ForeignKey(nameof(ExerciseTypeId))]
        public virtual BaseDefination ExerciseType { get; set; }

        /// <summary>
        /// رده ی سنی
        /// </summary>
        [DisplayName("رده سنی")]
        public AgeRateType? AgeRateType { get; set; }

        /// <summary>
        /// عنوان مسابقات
        /// </summary>
        [DisplayName("عنوان مسابقات"), MaxLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// عنوان مقام
        /// </summary>
        [DisplayName("عنوان مقام")]
        public RankTitle? RankTitle { get; set; }

        /// <summary>
        /// سطح مسابقات
        /// </summary>
        [DisplayName("سطح مسابقات")]
        public ExerciseRate? ExerciseRate { get; set; }

        /// <summary>
        /// سال مسابقه
        /// </summary>
        [DisplayName("سال مسابقه")]
        public short? Year { get; set; }

        /// <summary>
        /// شرح
        /// </summary>
        [DisplayName("شرح")]
        public string Comment { get; set; }

        /// <summary>
        /// کد فرد
        /// </summary>
        [DisplayName("فرد")]
        public int? PersonId { get; set; }

        /// <summary>
        /// مشخصات فرد
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual AcademicPerson Person { get; set; }
    }
}
