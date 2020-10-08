using Caspian.Common;
using Model.PersonInfo;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using Model.PersonInfo.ProfessorInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.EmployInfo;

namespace Model.BaseInfo
{
    /// <summary>
    /// مشخصات شهرها
    /// </summary>
    [Table("Cities", Schema = "dbo")]
    public class City
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان شهرستان
        /// </summary>
        [DisplayName("عنوان"), Required, Unique("شهری با این عنوان برای این استان ثبت شده است", nameof(ProvinceId))]
        public string Title { get; set; }

        /// <summary>
        /// کد استان
        /// </summary>
        [DisplayName("استان"), Required]
        [CheckOnInsert("استانی با کد {0} در سیستم وجود ندارد")]
        public int? ProvinceId { get; set; }

        /// <summary>
        /// مشخصات استان
        /// </summary>
        [ForeignKey(nameof(ProvinceId))]
        public virtual Province Province { get; set; }

        /// <summary>
        /// دانشگاه های شهر
        /// </summary>
        [CheckOnDelete("برای این شهر دانشگاه ثبت شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<University> Universities { get; set; }

        /// <summary>
        /// مشخصات اساتیدی که محل سکونت آنها این شهر می باشد
        /// </summary>
        [CheckOnDelete("این شهر بعنوان محل سکونت برخی از اساتید تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("CurentCity")]
        public virtual ICollection<Professor> ProfessorsCurentCity { get; set; }

        /// <summary>
        /// مشخصات اساتیدی که محل سکونت قبلی آنها این شهر می باشد.
        /// </summary>
        [CheckOnDelete("این شهر بعنوان محل سکونت قبلی برخی از اساتید تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("PreCity")]
        public virtual ICollection<Professor> ProfessorsPreCity { get; set; }

        /// <summary>
        /// مشخصات اساتیدی که آدرس شغلی آنها این شهر می باشد.
        /// </summary>
        [CheckOnDelete("این شهر بعنوان آدرس شغلی برخی از اساتید تعریف شده و امکان حذف آن وجود ندراد.")]
        [InverseProperty("JobCity")]
        public virtual ICollection<Professor> ProfessorsJobCity { get; set; }

        /// <summary>
        /// مشخصات افرادی که محل تولد آنها این شهر می باشد
        /// </summary>
        [CheckOnDelete("این شهر محل تولد برخی از افراد می باشد و امکان حذف آن وجود ندارد.")]
        [InverseProperty("BirthCity")]
        public virtual ICollection<Identification> Identifications { get; set; }

        /// <summary>
        /// مشخصات افرادی که محل ثبت شناسنامه آنها این شهر می باشد
        /// </summary>
        [CheckOnDelete("این شهر محل ثبت شناسنامه برخی از افراد می باشد و امکان حذف آن وجود ندارد.")]
        [InverseProperty("RegCity")]
        public virtual ICollection<Identification> Identifications1 { get; set; }

        /// <summary>
        /// شمخصات دانشجویانی که شهر محل سکونت آنها این شهر می باشد
        /// </summary>
        [CheckOnDelete("این شهر محل سکونت برخی از دانشجویان می باشد و امکان حذف آن وجود ندارد")]
        [InverseProperty("CurentCity")]
        public virtual ICollection<StudentFamilyProfile> StudentFamilyProfiles { get; set; }

        /// <summary>
        /// مشخصات دانشجویانی که شهر محل سکونت قبلی آنها این شهر می باشد
        /// </summary>
        [CheckOnDelete("این شهر محل سکونت قبلی برخی از دانشجویان می باشد و امکان حذف آن وجود ندارد")]
        [InverseProperty("PreCity")]
        public virtual ICollection<StudentFamilyProfile> StudentFamilyProfiles1 { get; set; }

        /// <summary>
        /// کارمندانی که محل تولد آنها این شهر می باشد
        /// </summary>
        [CheckOnDelete("این شهر محل تولد برخی از کارمندان می باشد و امکان حذف آن وجود ندارد.")]
        [InverseProperty("BirthCity")]
        public virtual ICollection<Employee> EmployeesBirthCity { get; set; }

        /// <summary>
        /// کارمندانی که محل صدور شناسنامه آنها این شهر می باشد
        /// </summary>
        [CheckOnDelete("این شهر محل صدور شناسنامه برخی از کارمندان می باشد و امکان حذف آن وجود ندارد.")]
        [InverseProperty("RegisterCity")]
        public virtual ICollection<Employee> EmployeesRegisterCity { get; set; }

    }
}
