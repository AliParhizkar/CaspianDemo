using Model.Enums;
using Caspian.Common;
using Model.PersonInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات مقاطع تحصیلی
    /// </summary>
    [Table("Grades", Schema = "dbo")]
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان مقطع تحصیلی
        /// </summary>
        [DisplayName("عنوان مقطع تحصیلی")]
        public string Title { get; set; }

        /// <summary>
        /// نوع مقاطع تحصیلی
        /// </summary>
        [DisplayName("نوع مقطع تحصیلی")]
        public PersonGradeType? PersonGradeType { get; set; }

        /// <summary>
        /// مدارک تحصیلی این مقطع تحصیلی
        /// </summary>
        [CheckOnDelete("مقطع تحصیلی دارای مدرک می باشد و امکان حذف آن وجود ندارد")]
        public virtual ICollection<Degree> Degrees { get; set; }
    }
}
