using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caspian.Common;

namespace Model.Translate
{
    /// <summary>
    /// مشخصات دانشگاه مقصد در نقل و انتقالات
    /// </summary>
    [Table("TargetUnivesities", Schema = "trs")]
    public class TargetUnivesity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("دانشگاهی با این عنوان در سیستم وجود دارد.")]
        public string Title { get; set; }

        /// <summary>
        /// دانشکد ه های دانشگاه
        /// </summary>
        [CheckOnDelete("دانشگاه دارای دانشکده می باشد و امکان حذف آن وجود ندارد")]
        public virtual ICollection<TargetFaculity> Targetfaculities { get; set; }
    }
}
