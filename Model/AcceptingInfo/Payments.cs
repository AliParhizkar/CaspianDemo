using Model.BaseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AcceptingInfo
{
    /// <summary>
    /// پرداخت های الکترونیکی
    /// </summary>
    public class Payments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان پرداخت
        /// </summary>
        [DisplayName("عنوان پرداخت")]
        public string Title { get; set; }

        /// <summary>
        /// کد موضوع پرداخت
        /// </summary>
        [DisplayName("موضوع پرداخت")]
        public int PaymentIssueId { get; set; }

        /// <summary>
        /// موضوع پرداخت
        /// </summary>
        [ForeignKey(nameof(PaymentIssueId))]
        public virtual BaseDefination PaymentIssue { get; set; }

        /// <summary>
        /// کد آیتم پرداخت
        /// </summary>
        [DisplayName("آیتم پرداخت")]
        public int ItemPaymentId { get; set; }

        /// <summary>
        /// مشخصات آیتم پرداخت
        /// </summary>
        [ForeignKey(nameof(ItemPaymentId))]
        public virtual BaseDefination ItemPayment { get; set; }

        /// <summary>
        /// مبلغ پرداخت
        /// </summary>
        [DisplayName("مبلغ پرداخت")]
        public int PaymentValue { get; set; }

        /// <summary>
        /// شناسه پرداخت
        /// </summary>
        [DisplayName("شناسه پرداخت")]
        public string PaymentIdentifire { get; set; }

        /// <summary>
        /// اولویت نمایش
        /// </summary>
        [DisplayName("اولویت نمایش")]
        public int Ordering { get; set; }

        /// <summary>
        /// کد پذیرش
        /// </summary>
        [DisplayName("پذیرش")]
        public int AcceptingId { get; set; }

        /// <summary>
        /// مشخصات پذیرش
        /// </summary>
        [ForeignKey(nameof(AcceptingId))]
        public virtual Accepting Accepting { get; set; }
    }
}
