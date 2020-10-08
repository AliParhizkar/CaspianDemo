using Caspian.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EmployInfo
{
    /// <summary>
    /// مشخصات رسته ی شغلی
    /// </summary>
    [Table("Jobcategories", Schema = "emp")]
    public class JobCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// مشخصات رسته ی شغلی
        /// </summary>
        [DisplayName("رسته شغلی"), Required, Unique("رسته ی شغلی با این عنوان در سیستم تعریف شده است")]
        public string Title { get; set; }

        /// <summary>
        /// رشته های شغلی این رسته شغلی
        /// </summary>
        [CheckOnDelete("این رسته ی شغلی دارای رشته ی شغلی می باشد و امکان حذف آن وجود ندارد.")]
        public virtual IList<Occupation> Occupations { get; set; }

        /// <summary>
        /// پستهای سازمانی رسته شغلی
        /// </summary>
        [CheckOnDelete("برای این رسته ی شغلی پست سازمانی تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual IList<OrganPost> OrganPosts { get; set; }
    }
}
