using Caspian.Common;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EmployInfo
{
    /// <summary>
    /// مشخصات رشته شغلی
    /// </summary>
    [Table("Occupation", Schema = "emp")]
    public class Occupation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد رسته ی شغلی
        /// </summary>
        [DisplayName("رسته ی شغلی"), Required]
        public int JobCategoryId { get; set; }

        /// <summary>
        /// مشخصات رسته ی شغلی
        /// </summary>
        [ForeignKey(nameof(JobCategoryId))]
        public virtual JobCategory JobCategory { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("برای این رسته شغلی رشته ای با این عنوان ثبت شده است", nameof(JobCategoryId))]
        public string Title { get; set; }

        /// <summary>
        /// پستهای سازمانی رشته ی شغلی
        /// </summary>
        [CheckOnDelete("این رشته ی شغلی دارای پست سازمانی می باشد و امکان حذف آن وجود ندراد.")]
        public virtual IList<OrganPost> OrganPosts { get; set; }
    }
}
