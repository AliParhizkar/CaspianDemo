using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// وضعیت جسمانی
    /// </summary>
    [Table("physicalIStates")]
    public class physicalIState
    {
        [Key, ForeignKey(nameof(Person))]
        public int PersonId { get; set; }

        /// <summary>
        /// گروه خونی
        /// </summary>
        [DisplayName("گروه خونی")]
        public BloodGroup? BloodGroup { get; set; }

        /// <summary>
        /// وضعیت جسمانی
        /// </summary>
        [DisplayName("وضعیت جسمانی")]
        public physicalStatus? PhysicalStatus { get; set; }

        /// <summary>
        /// بیماری خاص
        /// </summary>
        [DisplayName("بیماری خاص")]
        public bool? SpesialIll { get; set; }

        /// <summary>
        /// شرح بیماری خاص
        /// </summary>
        [DisplayName("شرح بیماری خاص"), MaxLength(200)]
        public string SpesialIllComment { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [DisplayName("توضیحات"), MaxLength(200)]
        public string Comment { get; set; }

        /// <summary>
        /// مشخصات فرد
        /// </summary>
        public virtual AcademicPerson Person { get; set; }
    }
}
