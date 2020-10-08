using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// محدودیت های گروه درسی
    /// </summary>
    [Table("CourseGroupLimitations")]
    public class CourseGroupLimitation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد گروه درسی
        /// </summary>
        [DisplayName("گروه درسی"), Required]
        public int? CourseGroupId { get; set; }

        /// <summary>
        /// مشخصات گروه درسی
        /// </summary>
        [ForeignKey(nameof(CourseGroupId))]
        public virtual CourseGroup CourseGroup { get; set; }

        /// <summary>
        /// کد زیرگروه
        /// </summary>
        [DisplayName("گروه درسی")]
        public int? UnderGroupId { get; set; }

        /// <summary>
        /// مشخصات زیرگروه
        /// </summary>
        [ForeignKey(nameof(UnderGroupId))]
        public virtual BaseDefination UnderGroup { get; set; }

        /// <summary>
        /// ظرفیت مجاز
        /// </summary>
        [DisplayName("ظرفیت مجاز")]
        public short? Capacity { get; set; }

        /// <summary>
        /// از سال ورود
        /// </summary>
        [DisplayName("از سال ورود")]
        public short? EntryYearFrom { get; set; }

        /// <summary>
        /// تا سال ورود
        /// </summary>
        [DisplayName("تا سال ورود")]
        public short? EntryYearTo { get; set; }
    }
}
