using Caspian.Common;
using Model.BaseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AcceptingInfo
{
    /// <summary>
    /// دانشکده پذیرش
    /// </summary>
    [Table("AcceptingFaculties", Schema = "acc")]
    public class AcceptingFaculty
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد
        /// </summary>
        [DisplayName("کد"), Unique("دانشکده ای با این کد در سیستم ثبت شده است")]
        public string Code { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [DisplayName("عنوان"), Unique("دانشکده ای با این عنوان در سیستم ثبت شده است"), Required]
        public string Title { get; set; }

        /// <summary>
        /// کد دانشگاه مورد پذیرش
        /// </summary>
        [DisplayName("دانشگاه مورد پذیرش")]
        public int? AcceptingUniversityId { get; set; }

        /// <summary>
        ///  مشخصات دانشگاه مورد پذیرش
        /// </summary>
        [ForeignKey(nameof(AcceptingUniversityId))]
        public virtual AcceptingUniversity AcceptingUniversity { get; set; }

        /// <summary>
        /// کد دانشکده من
        /// </summary>
        [DisplayName("دانشکده من")]
        public int? FacultyId { get; set; }

        /// <summary>
        /// مشخصات دانشکده ی من
        /// </summary>
        [ForeignKey(nameof(FacultyId))]
        public virtual Faculty Faculty { get; set; }

        /// <summary>
        /// رشته های تحصیلی مورد پذیرش
        /// </summary>
        [CheckOnDelete("دانشکده دارای رشته می باشد و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<AcceptingStudyField> AcceptingStudyFields { get; set; }
    }
}
