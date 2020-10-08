using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات نسبت با نخبگان کشور
    /// </summary>
    [Table("EliteRelations", Schema = "dbo")]
    public class EliteRelation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [DisplayName("نام")]
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [DisplayName("نام خانوادگی")]
        public string LastName { get; set; }

        /// <summary>
        /// پست
        /// </summary>
        [DisplayName("پست")]
        public string Post { get; set; }

        /// <summary>
        /// ارگان/سازمان
        /// </summary>
        [DisplayName("ارگان/سازمان")]
        public string Organ { get; set; }

        /// <summary>
        /// مدت آشنایی
        /// </summary>
        [DisplayName("مدت آشنایی")]
        public int? FamiliarityTerm { get; set; }

        /// <summary>
        /// نسبت
        /// </summary>
        [DisplayName("نسبت")]
        public FamiliarityType? FamiliarityType { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [MaxLength(200), DisplayName("توضیحات")]
        public string Comment { get; set; }

        /// <summary>
        /// کد فرد
        /// </summary>
        [DisplayName("فرد")]
        public int PersonId { get; set; }

        /// <summary>
        /// مشخصات فرد
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual AcademicPerson Person { get; set; }
    }
}
