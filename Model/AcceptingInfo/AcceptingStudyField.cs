using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AcceptingInfo
{
    /// <summary>
    /// رشته مورد پذیرش
    /// </summary>
    public class AcceptingStudyField
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان رشته
        /// </summary>
        [DisplayName("عنوان")]
        public string Title { get; set; }

        /// <summary>
        /// کد رشته
        /// </summary>
        [DisplayName("کد رشته")]
        public string Code { get; set; }

        /// <summary>
        /// کد مشخصات دانشکده مورد پذرش
        /// </summary>
        [DisplayName("دانشکده مورد پذیرش")]
        public int AcceptingFacultyId { get; set; }

        /// <summary>
        /// مشخصات دانشکده مورد پذیرش
        /// </summary>
        [ForeignKey(nameof(AcceptingFacultyId))]
        [DisplayName("دانشکده مورد پذیرش")]
        public virtual AcceptingFaculty AcceptingFaculty { get; set; }

        /// <summary>
        /// کد رشته تحصیلی من
        /// </summary>
        [DisplayName("رشته من")]
        public int StudyFieldId { get; set; }

        /// <summary>
        /// مشخصات رشته تحصیلی من
        /// </summary>
        [ForeignKey(nameof(StudyFieldId))]
        public virtual StudyField StudyField { get; set; }
    }
}
