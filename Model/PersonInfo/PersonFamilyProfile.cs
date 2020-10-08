using Model.Enums;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات خانوادگی فرد
    /// </summary>
    [Table("PeopelFamilyProfile")]
    public class PersonFamilyProfile
    {
        [Key, ForeignKey(nameof(Person)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }

        /// <summary>
        /// وضعیت تاهل
        /// </summary>
        [DisplayName("وضعیت تاهل")]
        public MarrageType? MarrageType { get; set; }

        /// <summary>
        /// کد ملی همسر
        /// </summary>
        [DisplayName("کد ملی همسر")]
        public string HusbandNatinalCode { get; set; }

        /// <summary>
        /// نام همسر
        /// </summary>
        [DisplayName("نام همسر")]
        public string HusbandName { get; set; }

        /// <summary>
        /// شغل همسر
        /// </summary>
        [DisplayName("شغل همسر")]
        public string HusbandJob { get; set; }

        /// <summary>
        /// تعداد افراد تحت تکفل
        /// </summary>
        [DisplayName("تعداد افراد تحت تکفل")]
        public byte? DependentsCount { get; set; }

        /// <summary>
        /// تعداد فرزندان
        /// </summary>
        [DisplayName("تعداد فرزندان")]
        public byte? ChildrenCount { get; set; }

        /// <summary>
        /// نام فرزندان
        /// </summary>
        [DisplayName("نام فرزندان")]
        public string ChildrenName { get; set; }

        /// <summary>
        /// کد مذهب
        /// </summary>
        [DisplayName("مذهب")]
        public int? SubRegionId { get; set; }

        /// <summary>
        /// مشخصات مذهب
        /// </summary>
        [ForeignKey(nameof(SubRegionId))]
        public virtual SubRegion SubRegion { get; set; }

        /// <summary>
        /// کد تابعیت
        /// </summary>
        [DisplayName("تابعیت")]
        public int? CitizenshipId { get; set; }

        /// <summary>
        /// مشخصات تابعیت
        /// </summary>
        [ForeignKey(nameof(CitizenshipId))]
        public virtual BaseDefination Citizenship { get; set; }

        /// <summary>
        /// کد وضعیت نظام وظیفه
        /// </summary>
        [DisplayName("وضعیت نظام وظیفه")]
        public int? DutySystemId { get; set; }

        /// <summary>
        /// مشخصات وضعیت نظام وظیفه
        /// </summary>
        [ForeignKey(nameof(DutySystemId))]
        public virtual BaseDefination DutySystem { get; set; }

        /// <summary>
        /// کد محل اقامت
        /// </summary>
        [DisplayName("محل اقامت")]
        public int? ResidencePlaceId { get; set; }

        /// <summary>
        /// مشخصات محل اقامت
        /// </summary>
        [ForeignKey(nameof(ResidencePlaceId))]
        public virtual BaseDefination ResidencePlace { get; set; }

        /// <summary>
        /// وضعیت بومی
        /// </summary>
        [DisplayName("وضعیت بومی")]
        public EndemicType? EndemicType { get; set; }

        /// <summary>
        /// میزان اجاره
        /// </summary>
        [DisplayName("میزان اجاره")]
        public int? RentPayment { get; set; }

        /// <summary>
        /// مشخصات اصلی فرد
        /// </summary>
        public virtual AcademicPerson Person { get; set; }
    }
}
