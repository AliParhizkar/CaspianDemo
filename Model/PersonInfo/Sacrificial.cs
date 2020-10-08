using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات ایثارگری فرد
    /// </summary>
    [Table("PeopelSacrificial", Schema = "dbo")]
    public class PersonSacrificial
    {
        [Key, ForeignKey(nameof(Person)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        /// <summary>
        /// مدت حضور در جبهه به ماه
        /// </summary>
        [DisplayName("مدت حضور در جبهه به ماه")]
        public byte? WareMonth { get; set; }

        /// <summary>
        /// مدت اسارت به ماه
        /// </summary>
        [DisplayName("مدت اسارت به ماه")]
        public byte? BondageMonth { get; set; }

        /// <summary>
        /// درصد جانبازی
        /// </summary>
        [DisplayName("درصد جانبازی")]
        public decimal? VeteranPercent { get; set; }

        /// <summary>
        /// کد نسبت ایثارگری
        /// </summary>
        [DisplayName("نسبت ایثارگری")]
        public int? SacrificialRelationId { get; set; }

        /// <summary>
        /// مشخصات نسبت ایثارگری
        /// </summary>
        [ForeignKey(nameof(SacrificialRelationId))]
        public virtual BaseDefination SacrificialRelation { get; set; }

        /// <summary>
        /// ملاحظات
        /// </summary>
        [MaxLength(200), DisplayName("ملاحضات")]
        public string Comment { get; set; }

        /// <summary>
        /// مشخصات استاد
        /// </summary>
        public virtual AcademicPerson Person { get; set; }
    }
}
