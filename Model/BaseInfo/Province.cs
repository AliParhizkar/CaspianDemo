using Caspian.Common;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using Model.PersonInfo.ProfessorInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات استانها
    /// </summary>
    [Table("Provinces", Schema = "dbo")]
    public class Province
    {
        /// <summary>
        /// کد استان
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان استان
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("استانی با این عنوان در سیستم ثبت شده است")]
        public string Title { get; set; }

        /// <summary>
        /// مشخصات شهرها
        /// </summary>
        [CheckOnDelete("استان دارای شهر می باشد و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<City> Cities { get; set; }

        /// <summary>
        /// استان محل خدمت استاد
        /// </summary>
        [CheckOnDelete("این استان محل خدمت برخی از اساتید می باشد و امکان حذف آن وجود ندارد")]
        public virtual ICollection<ProfessorEmployment> ProfessorEmployments { get; set; }

        /// <summary>
        /// دانشجویانی که سهمیه استان آنها این استان می باشد
        /// </summary>
        [CheckOnDelete("این استان سهمیه دانشجویان می باشد و امکان حذف آن وجود ندارد")]
        public virtual ICollection<JobInfo> JobInfos { get; set; }

        /// <summary>
        /// استان محل پرونده ایثارگری دانشجو
        /// </summary>
        [CheckOnDelete("این استان محل پرونده ایثارگری دانشجو می باشد و امکان حذف آن وجود ندارد")]
        public virtual ICollection<StdSacrificial> StdSacrificials { get; set; }
    }
}
