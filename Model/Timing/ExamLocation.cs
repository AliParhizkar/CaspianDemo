using Model.BaseInfo;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caspian.Common;

namespace Model.Timing
{
    /// <summary>
    /// مشخصات محل برگزاری امتحانات
    /// </summary>
    public class ExamLocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// نام/محل امتحان
        /// </summary>
        [DisplayName("نام/محل امتحان")]
        public string Title { get; set; }

        /// <summary>
        /// از شماره صندلی
        /// </summary>
        [DisplayName("از شماره صندلی")]
        public int? FromChairNo { get; set; }

        /// <summary>
        /// تا شماره صندلی
        /// </summary>
        [DisplayName("تا شماره صندلی")]
        public int? ToChairNo { get; set; }

        /// <summary>
        /// کد دانشکده
        /// </summary>
        [DisplayName("دانشکده")]
        public int FacultyId { get; set; }

        /// <summary>
        /// مشخصات دانشکده
        /// </summary>
        [ForeignKey(nameof(FacultyId))]
        public virtual Faculty Faculty { get; set; }

        /// <summary>
        /// کد امتحان
        /// </summary>
        [DisplayName("مشخصات امتحان")]
        public int ExamTimeId { get; set; }

        /// <summary>
        /// مشخصات امتحان
        /// </summary>
        [ForeignKey(nameof(ExamTimeId))]
        public virtual ExamTime ExamTime { get; set; }

        /// <summary>
        /// مشخصات مراقبین محل امتحان
        /// </summary>
        [CheckOnDelete("برای محل امتحان مراقب تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual IList<Observing> Observings { get; set; }
    }
}
