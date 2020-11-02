using Caspian.Common;
using Model.BaseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AcceptingInfo
{
    /// <summary>
    /// دانشگاه مورد پذیرش
    /// </summary>
    [Table("AcceptingUniversities")]
    public class AcceptingUniversity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [DisplayName("عنوان")]
        public string Title { get; set; }

        /// <summary>
        /// کد دانشگاه
        /// </summary>
        [DisplayName("کد")]
        public string Code { get; set; }

        /// <summary>
        /// کد داشگاه من
        /// </summary>
        [DisplayName("دانشگاه من")]
        public int UniversityId { get; set; }

        /// <summary>
        /// مشخصات دانشگاه من
        /// </summary>
        [ForeignKey(nameof(UniversityId))]
        public virtual University University { get; set; }

        /// <summary>
        /// دانشکده مورد پذیرش
        /// </summary>
        [CheckOnDelete("برای دانشگاه دانشکده ثبت شده و امکان حذف آن وجود ندارد.")]
        public virtual IList<AcceptingFaculty> AcceptingFaculties { get; set; }
    }
}
