using Caspian.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.ProfessorInfo
{
    /// <summary>
    /// مشخصات حساب بانکی
    /// </summary>
    [Table("BankAccounts", Schema = "dbo")]
    public class BankAccount
    {
        [Key, ForeignKey(nameof(Professor))]
        public int ProfessorId { get; set; }

        /// <summary>
        /// نام بانک
        /// </summary>
        [DisplayName("نام بانک"), Required]
        public string BankName { get; set; }

        /// <summary>
        /// نام شعبه
        /// </summary>
        [DisplayName("نام شعبه"), Required]
        public string BranchName { get; set; }

        /// <summary>
        /// کد شعبه
        /// </summary>
        [DisplayName("کد شعبه"), Required]
        public string BranchCode { get; set; }

        /// <summary>
        /// شماره حساب
        /// </summary>
        [DisplayName("شماره حساب"), Unique("این حساب قبلا ثبت شده است")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// شماره 16 رقمی کارت
        /// </summary>
        [DisplayName("شماره 16 رقمی کارت"), Unique("این شماره شبا قبلا ثبت شده است")]
        public string CardNumber { get; set; }

        /// <summary>
        /// کد شبا
        /// </summary>
        [DisplayName("کد شبا")]
        public string Shaba { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        [DisplayName("توضیحات"), MaxLength(200)]
        public string Descript { get; set; }

        /// <summary>
        /// مشخصات استاد
        /// </summary>
        public virtual Professor Professor { get; set; }
    }
}
