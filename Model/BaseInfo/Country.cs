using Caspian.Common;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات کشورها
    /// </summary>
    [Table("Countries", Schema = "dbo")]
    public class Country
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// عنوان کشور
        /// </summary>
        [DisplayName("عنوان")]
        public string Title { get; set; }

        /// <summary>
        /// مشخصات دانشجویانی که محل تولد آنها این شهر می باشد
        /// </summary>
        [CheckOnDelete("این کشور محل تولد برخی از دانشجویان می باشد و امکان حذف آن وجود ندارد")]
        public virtual ICollection<StdIdentification> StdIdentifications { get; set; }
    }
}
