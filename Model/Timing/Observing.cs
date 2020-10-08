using Model.Enums;
using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.EmployInfo;

namespace Model.Timing
{
    /// <summary>
    /// مشخصات مراقبین
    /// </summary>
    [Table("Observings")]
    public class Observing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد کارمند
        /// </summary>
        [DisplayName("کارمند"), Required]
        public int? EmployeeId { get; set; }

        /// <summary>
        /// مشخصات کارمند
        /// </summary>
        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// سمت مراقب
        /// </summary>
        [DisplayName("سمت مراقب"), Required]
        public ObservingPost? ObservingPost { get; set; }

        /// <summary>
        /// از شماره صندلی
        /// </summary>
        [DisplayName("از شماره صندلی")]
        public short? FromChairNo { get; set; }

        /// <summary>
        /// تا شماره صندلی
        /// </summary>
        [DisplayName("تا شماره صندلی")]
        public short? ToChairNo { get; set; }

        /// <summary>
        /// کد محل امتحان مراقب
        /// </summary>
        [DisplayName("محل امتحان مراقب")]
        public int? ExamLocationId { get; set; }

        /// <summary>
        /// مشخصات محل امتحان مراقب
        /// </summary>
        [ForeignKey(nameof(ExamLocationId))]
        public virtual ExamLocation ExamLocation { get; set; }

        /// <summary>
        /// مشخصات کد امتحان
        /// </summary>
        [DisplayName("امتحان")]
        public int? ExamId { get; set; }

        /// <summary>
        /// مشخصات امتحان
        /// </summary>
        [ForeignKey(nameof(ExamId))]
        public virtual ExamTime ExamTime { get; set; }
    }
}
