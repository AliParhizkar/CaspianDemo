using Caspian.Common;
using Model.BaseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Timing
{
    /// <summary>
    /// کلاسهای برگزاری دروس
    /// </summary>
    [Table("Classroms", Schema = "tim")]
    public class Classroom
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// کد دانشکده
        /// </summary>
        [DisplayName("دانشکده"), Required]
        public int? FacultyId { get; set; }

        /// <summary>
        /// مشخصات دانشکده
        /// </summary>
        [ForeignKey(nameof(FacultyId))]
        public virtual Faculty Faculty { get; set; }

        /// <summary>
        /// عنوان کلاس
        /// </summary>
        [DisplayName("عنوان کلاس"), Required, Unique("کلاسی با این عنوان در سامانه ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// ظرفیت
        /// </summary>
        [DisplayName("ظرفیت")]
        public short? Capacity { get; set; }

        /// <summary>
        /// آیا قفل هست
        /// </summary>
        [DisplayName("آیا قفل هست")]
        public bool? IsLook { get; set; }

        /// <summary>
        /// آیا کلاس برای همه باز است
        /// </summary>
        [DisplayName("آیا کلاس برای همه باز است")]
        public bool? IsPublic { get; set; }

        /// <summary>
        /// مشخصات زمانبندی این کلاس
        /// </summary>
        [CheckOnDelete("این کلاس دارای زمانبندی می باشد و امکان حذف آن وجود ندراد")]
        public virtual ICollection<ClassTime> ClassTimes { get; set; }
    }
}
