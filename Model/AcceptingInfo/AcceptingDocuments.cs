using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AcceptingInfo
{
    /// <summary>
    /// مشخصات اسناد پذیرش
    /// </summary>
    public class AcceptingDocuments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد نوع اسکن
        /// </summary>
        [DisplayName("نوع اسکن")]
        public int ScanTypeId { get; set; }

        /// <summary>
        /// نوع اسکن
        /// </summary>
        [ForeignKey(nameof(ScanTypeId))]
        public virtual BaseDefination ScanType { get; set; }

        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [DisplayName("اولویت نمایش")]
        public int Ordering { get; set; }

        /// <summary>
        /// اجبار داده
        /// </summary>
        [DisplayName("اجبار داده")]
        public bool? IsRequired { get; set; }

        /// <summary>
        /// کد پذیرش
        /// </summary>
        public int AcceptingId { get; set; }

        /// <summary>
        /// مشخصات پذیرش
        /// </summary>
        [ForeignKey(nameof(AcceptingId))]
        public virtual Accepting Accepting { get; set; }
    }
}
