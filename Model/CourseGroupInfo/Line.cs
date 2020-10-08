using Caspian.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseGroupInfo
{
    /// <summary>
    /// کنترل لاین ها
    /// </summary>
    [Table("Lines", Schema = "crg")]
    public class Line
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// ترم
        /// </summary>
        [DisplayName("ترم"), Required]
        public int? Term { get; set; }

        /// <summary>
        /// عنوان لاین
        /// </summary>
        [DisplayName("عنوان لاین"), Required, Unique("لاینی با این عنوان تعریف شده است")]
        public string Title { get; set; }

        /// <summary>
        /// عنوان لاتین لاین
        /// </summary>
        [DisplayName("عنوان لاتین")]
        public string EnTitle { get; set; }

        /// <summary>
        /// غیرفعال
        /// </summary>
        [DisplayName("غیرفعال")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// ملاحظه
        /// </summary>
        [DisplayName("ملاحظه"), MaxLength(150)]
        public string Comment { get; set; }
    }
}
