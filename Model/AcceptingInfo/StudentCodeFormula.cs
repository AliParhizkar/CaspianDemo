using Caspian.Common;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AcceptingInfo
{
    /// <summary>
    /// مشخصات فرمول تولید کد آموزشی
    /// </summary>
    public class StudentCodeFormula
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        [DisplayName("عنوان")]
        public string Title { get; set; }

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

        /// <summary>
        /// کد فرمول
        /// </summary>
        [DisplayName("کد فرمول")]
        public string Code { get; set; }

        /// <summary>
        /// توکنهای فرمول
        /// </summary>
        [CheckOnDelete("فرمول دارای توکن می باشد و امکان حذف آن وجود ندارد")]
        public virtual ICollection<FormulToken> Tokens { get; set; }

        ///// <summary>
        ///// لیست پذیرشهای این فرمول
        ///// </summary>
        //[CheckOnDelete("فرمول دارای پذیرش می باشد و امکان حذف آن وجود ندارد.")]
        //public virtual ICollection<Accepting> Acceptings { get; set; }
    }
}
