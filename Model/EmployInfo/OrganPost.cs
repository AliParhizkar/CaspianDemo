using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EmployInfo
{
    /// <summary>
    /// مشخصات پست سازمانی
    /// </summary>
    [Table("OrganPosts", Schema = "emp")]
    public class OrganPost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان پست سازمانی
        /// </summary>
        [DisplayName("عنوان")]
        public string Title { get; set; }

        /// <summary>
        /// کد پست سازمانی
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// کد رسته شغلی
        /// </summary>
        [DisplayName("رسته شغلی")]
        public int? JobCategoryId { get; set; }

        /// <summary>
        /// مشخصات رسته ی شغلی
        /// </summary>
        [ForeignKey(nameof(JobCategoryId))]
        public virtual JobCategory JobCategory { get; set; }

        /// <summary>
        /// کد واحد سازمانی
        /// </summary>
        public int? OrganUnitId { get; set; }

        /// <summary>
        /// مشخصات واحد سازمانی
        /// </summary>
        [ForeignKey(nameof(OrganUnitId))]
        public virtual OrganUnit OrganUnit { get; set; }

        /// <summary>
        /// کد رشته ی شغلی
        /// </summary>
        [DisplayName("رشته شغلی")]
        public int? OccupationId { get; set; }

        /// <summary>
        /// مشخصات رشته ی شغلی
        /// </summary>
        [ForeignKey(nameof(OccupationId))]
        public virtual Occupation Occupation { get; set; }
    }
}
