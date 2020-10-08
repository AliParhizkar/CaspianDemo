using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.AcceptingInfo
{
    /// <summary>
    /// توکن فرمول تولید کد آموزشی
    /// </summary>
    [Table("FormulTokens")]
    public class FormulToken
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// نوع فیلد تولید کد آموزشی
        /// </summary>
        [DisplayName("نوع فیلد"), Required]
        public CodeGeneratorFieldType? CodeGeneratorFieldType { get; set; }

        /// <summary>
        /// از کاراکتر-فیلدهای رشته ای
        /// </summary>
        [DisplayName("از کاراکتر")]
        public short? FromChar { get; set; }

        /// <summary>
        /// یطول-فیلدهای رشته ای
        /// </summary>
        [DisplayName("بطول")]
        public short? Length { get; set; }

        /// <summary>
        /// از مقدار-شمارنده
        /// </summary>
        [DisplayName("از مقدار")]
        public int? StartValue { get; set; }

        /// <summary>
        /// مقدار افزایشی-شمارنده
        /// </summary>
        [DisplayName("مقدار افزایشی")]
        public short? IncValue { get; set; }

        /// <summary>
        /// مقدار ثابت
        /// </summary>
        [DisplayName("مقدار ثابت"), MaxLength(10)]
        public string ConstValue { get; set; }

        /// <summary>
        /// مرد-مقدار ثابت
        /// </summary>
        [DisplayName("مقدار ثابت(مرد)"), MaxLength(10)]
        public string MaleValue { get; set; }

        /// <summary>
        /// زن-مقدار ثابت
        /// </summary>
        [DisplayName("مقدار ثابت(زن)"), MaxLength(10)]
        public string FemaleValue { get; set; }

        /// <summary>
        /// ترم اول-مقدار ثابت
        /// </summary>
        [DisplayName("مقدار ترم اول"), MaxLength(10)]
        public string FirstTerm { get; set; }

        /// <summary>
        /// ترم دوم-مقدار ثابت
        /// </summary>
        [DisplayName("مقدار ترم دوم"), MaxLength(10)]
        public string SecondTerm { get; set; }

        /// <summary>
        /// ترم تابستانی-مقدار ثابت
        /// </summary>
        [DisplayName("مقدار ترم تابستان"), MaxLength(10)]
        public string SummeryTerm { get; set; }

        /// <summary>
        /// کد فرمول تولید کد دانشجوئی
        /// </summary>
        [DisplayName("فرمول کد دانشجویی")]
        public int FormulaId { get; set; }

        /// <summary>
        /// مشخصات فرمول تولید کد دانشجوئی
        /// </summary>
        [ForeignKey(nameof(FormulaId))]
        public virtual StudentCodeFormula Formula { get; set; }

    }
}
