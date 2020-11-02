using Caspian.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Translate
{
    /// <summary>
    /// مشخصات رشته تحصیلی مقصد در نقل و انتقالات
    /// </summary>
    [Table("TargetStudyFields", Schema = "trs")]
    public class TargetStudyField
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("رشته ای با این عنوان در این دانشگاه تعریف شده است", nameof(TargetUnivesityId))]
        public string Title { get; set; }

        /// <summary>
        /// کد دانشکده
        /// </summary>
        [DisplayName("دانشکده")]
        public int TargetUnivesityId { get; set; }

        /// <summary>
        /// مشخصات دانشکده
        /// </summary>
        public virtual TargetFaculity TargetFaculity { get; set; }
    }
}
