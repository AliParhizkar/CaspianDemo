using Caspian.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.EmployInfo
{
    /// <summary>
    /// مشخصات واحد سازمانی
    /// </summary>
    [Table("OrganUnits", Schema = "emp")]
    public class OrganUnit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان واحد سازمانی
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("واحد سازمانی با این عنوان برای این گروه تعریف شده است", nameof(ParentOrganUnitId))]
        public string Title { get; set; }

        /// <summary>
        /// کد واحد سازمانی
        /// </summary>
        [DisplayName("کد"), Unique("واحد سازمانی با این کد در سستم تعریف شده است.")]
        public string Code { get; set; }

        /// <summary>
        /// کد واحد سازمانی مافوق
        /// </summary>
        [DisplayName("واحد سازمانی")]
        public int? ParentOrganUnitId { get; set; }

        /// <summary>
        /// مشخصات واحد سازمانی مافوق
        /// </summary>
        [ForeignKey(nameof(ParentOrganUnitId))]
        public virtual OrganUnit PrentOrganUnit { get; set; }

        /// <summary>
        /// زیرگروه های این واحد سازمانی
        /// </summary>
        [CheckOnDelete("واحد سازمانی دارای زیرگروه می باشد و امکان حذف آن وجود ندارد.")]
        public virtual IList<OrganUnit> Children { get; set; }

        /// <summary>
        /// پست های سازمانی این واحد سازمانی
        /// </summary>
        [CheckOnDelete("برای این واحد سازمانی پست سازمانی تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual IList<OrganPost> OrganPosts { get; set; }

        [DisplayName("غیرفعال")]
        public bool? IsDisable { get; set; }


    }
}
