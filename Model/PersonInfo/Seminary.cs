using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// تحصیلا حوزوی
    /// </summary>
    [Table("Seminaries", Schema = "dbo")]
    public class Seminary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// نام مرکز
        /// </summary>
        [DisplayName("نام مرکز"), Required]
        public string Title { get; set; }

        /// <summary>
        /// شماره پرونده
        /// </summary>
        [DisplayName("شماره پرونده"), Required]
        public string FileNumber { get; set; }

        /// <summary>
        /// کد سطح 
        /// </summary>
        [DisplayName("سطح")]
        public int? SeminaryLevelId { get; set; }

        /// <summary>
        /// عنوان سطح
        /// </summary>
        [ForeignKey(nameof(SeminaryLevelId))]
        public virtual BaseDefination SeminaryLevel { get; set; }

        /// <summary>
        /// کد تخصص
        /// </summary>
        [DisplayName("تخصص")]
        public int? SeminaryExpreinceId { get; set; }

        /// <summary>
        /// مشخصات تخصص
        /// </summary>
        [ForeignKey(nameof(SeminaryExpreinceId))]
        public virtual BaseDefination SeminaryExpreince { get; set; }

        /// <summary>
        /// معدل
        /// </summary>
        [DisplayName("معدل")]
        public decimal? Average { get; set; }

        /// <summary>
        /// سال اخذ
        /// </summary>
        [DisplayName("سال اخذ")]
        public short? GraduateYear { get; set; }

        /// <summary>
        /// آدرس مرکز
        /// </summary>
        [DisplayName("آدرس مرکز"), MaxLength(200)]
        public string Address { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [MaxLength(200), DisplayName("توضیحات")]
        public string Comment { get; set; }

        /// <summary>
        /// کد فرد
        /// </summary>
        [DisplayName("فرد")]
        public int? PersonId { get; set; }

        /// <summary>
        /// مشخصات فرد
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public virtual AcademicPerson Person { get; set; }
    }
}
