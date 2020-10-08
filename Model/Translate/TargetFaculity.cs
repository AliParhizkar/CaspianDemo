using Caspian.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Translate
{
    /// <summary>
    /// مشخصات دانشکده مقصد در نقل و انتقالات
    /// </summary>
    [Table("TargetFaculities", Schema = "trs")]
    public class TargetFaculity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("دانشکده ای با این عنوان در این دانشگاه ثبت شده است", nameof(TargetUnivesityId))]
        public string Title { get; set; }

        /// <summary>
        /// کد دانشگاه
        /// </summary>
        [DisplayName("دانشگاه")]
        public int TargetUnivesityId { get; set; }

        /// <summary>
        /// مشخصات دانشگاه
        /// </summary>
        [ForeignKey(nameof(TargetUnivesityId))]
        public virtual TargetUnivesity TargetUnivesity { get; set; }
    }
}
