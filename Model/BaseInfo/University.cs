using Caspian.Common;
using Model.AcceptingInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات دانشگاه
    /// </summary>
    [Table("Universities", Schema = "dbo")]
    public class University
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان دانشگاه
        /// </summary>
        [DisplayName("عنوان"), Required]
        public string Title { get; set; }

        /// <summary>
        /// آدرس دانشگاه
        /// </summary>
        [DisplayName("آدرس"), MaxLength(500)]
        public string Address { get; set; }

        /// <summary>
        /// کد شهر
        /// </summary>
        [DisplayName("شهر")]
        public int? CityId { get; set; }

        /// <summary>
        /// مشخصات شهر
        /// </summary>
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }

        /// <summary>
        /// مشخصات دانشکده ها
        /// </summary>
        [CheckOnDelete("دانشگاه دارای دانشکده می باشد و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<Faculty> Faculties { get; set; }

        /// <summary>
        /// مشخصات دانشکده های مورد پذیرش
        /// </summary>
        [CheckOnDelete("دانشگاه دارای دانشکده پذیرش می باشد و امکان حذف آن وجود ندارد.")]
        public virtual IList<AcceptingUniversity> AcceptingUniversities { get; set; }
    }
}
