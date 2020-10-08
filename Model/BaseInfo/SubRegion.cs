using Caspian.Common;
using Model.PersonInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات مذاهب
    /// </summary>
    [Table("SubRegions", Schema = "dbo")]
    public class SubRegion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان مذهب
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("مذهبی با این عنوان در سیستم ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// کد دین
        /// </summary>
        [DisplayName("دین"), Required]
        public int? RegionId { get; set; }

        /// <summary>
        /// مشخصات دین
        /// </summary>
        [ForeignKey(nameof(RegionId))]
        public virtual  Region Region { get; set; }

        /// <summary>
        /// مشخصات خانوادگی افرادی که دارای این مذهب می باشند
        /// </summary>
        [CheckOnDelete("این مذهب دارای افرادی می باشد و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<PersonFamilyProfile> PersonFamilyProfiles { get; set; }
    }
}
