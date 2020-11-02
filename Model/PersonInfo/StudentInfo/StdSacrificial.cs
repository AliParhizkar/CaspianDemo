using Model.Enums;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات ایثارگری دانشجو
    /// </summary>
    [Table("StdSacrificials", Schema = "dbo")]
    public class StdSacrificial : PersonSacrificial
    {
        /// <summary>
        /// نام و نام خانوادگی ایثارگر
        /// </summary>
        [DisplayName("نام و نام خانوادگی ایثارگر")]
        public string Name { get; set; }

        /// <summary>
        /// کد پرونده ایثارگری
        /// </summary>
        [DisplayName("کد پرونده ایثارگری")]
        public string FileNo { get; set; }

        /// <summary>
        /// کد استان محل پرونده
        /// </summary>
        [DisplayName("استان محل پرونده")]
        public int? ProvinceId { get; set; }

        /// <summary>
        /// مشخصات استان محل پرونده
        /// </summary>
        [ForeignKey(nameof(ProvinceId))]
        public virtual Province Province { get; set; }

        /// <summary>
        /// نوع ایثارگری
        /// </summary>
        [DisplayName("نوع ایثارگری")]
        public SacrificialType? SacrificialType { get; set; }

        /// <summary>
        /// والدین در قید حیات
        /// </summary>
        [DisplayName("والدین در قید حیات")]
        public ParentAlive? ParentAlive { get; set; }

        /// <summary>
        /// ازدواج مجدد والدین
        /// </summary>
        [DisplayName("ازدواج مجدد والدین")]
        public ParentAlive? Remarry { get; set; }

        /// <summary>
        /// رتبه در سهمیه
        /// </summary>
        [DisplayName("رتبه در سهمیه")]
        public int? RankWithQuotas { get; set; }

        /// <summary>
        /// رتبه بدون سهمیه
        /// </summary>
        [DisplayName("رتبه بدون سهمیه")]
        public int? RankWithoutQuotas { get; set; }

        /// <summary>
        /// نمره کل تراز
        /// </summary>
        [DisplayName("نمره کل تراز")]
        public decimal? TotalGrade { get; set; }

        /// <summary>
        /// ابداع یا اختراع دارد
        /// </summary>
        [DisplayName("ابداع یا اختراع دارد")]
        public bool? HasCreativity { get; set; }

        /// <summary>
        /// دارای مقالات پژوهشی
        /// </summary>
        [DisplayName("دارای مقالات پژوهشی")]
        public bool? HasArticle { get; set; }

        /// <summary>
        /// مشخصات دانشجو
        /// </summary>
        [ForeignKey("PersonId")]
        public virtual Student Student { get; set; }
    }
}
