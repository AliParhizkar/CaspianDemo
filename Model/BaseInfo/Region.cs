using Caspian.Common;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات دین
    /// </summary>
    [Table("Regions", Schema = "dbo")]
    public class Region
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان دین
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("دینی با این عنوان در سیستم ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// مشخصات مذاهب
        /// </summary>
        [CheckOnDelete("دین دارای مذهب می باشد و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<SubRegion> SubRegions{ get; set; }
    }
}
