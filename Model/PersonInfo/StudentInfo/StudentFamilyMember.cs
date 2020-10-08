using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات اعضاء خانواده دانشجو
    /// </summary>
    [Table("StudentFamilyMembers", Schema = "dbo")]
    public class StudentFamilyMember
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// نسبت
        /// </summary>
        [DisplayName("نسبت"), Required]
        public FamilyMemberType? FamilyMemberType { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [DisplayName("نام"), Required]
        public string FName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [DisplayName("نام خانوادگی"), Required]
        public string LName { get; set; }

        /// <summary>
        /// سال تولد
        /// </summary>
        [DisplayName("سال تولد")]
        public int? BirthYear { get; set; }

        /// <summary>
        /// وضعیت تاهل
        /// </summary>
        [DisplayName("وضعیت تاهل")]
        public MarrageType? MarrageType { get; set; }

        /// <summary>
        /// شغل
        /// </summary>
        [DisplayName("شغل")]
        public string Job { get; set; }

        /// <summary>
        /// درآمد ماهیانه
        /// </summary>
        [DisplayName("درآمد ماهیانه")]
        public int? Income { get; set; }

        /// <summary>
        /// تحصیلات
        /// </summary>
        [DisplayName("تحصیلات")]
        public string Education { get; set; }

        /// <summary>
        /// ملاخظه
        /// </summary>
        [DisplayName("ملاحظه"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// کد دانشجو
        /// </summary>
        [DisplayName("دانشجو")]
        public int StudentId { get; set; }

        /// <summary>
        /// مشخصات دانشجو
        /// </summary>
        [ForeignKey(nameof(StudentId))]
        public virtual Student Student { get; set; }
    }
}
