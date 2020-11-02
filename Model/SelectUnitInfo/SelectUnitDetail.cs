using Model.ExceptCaseInfo;
using System.ComponentModel;
using Model.CourseGroupInfo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SelectUnitInfo
{
    /// <summary>
    /// جزئیات انتخاب واحد
    /// </summary>
    [Table("SelectUnitDetails", Schema = "sun")]
    public class SelectUnitDetail
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// کد انتخاب واحد
        /// </summary>
        [DisplayName("انتخاب واحد"), Required]
        public int? SelectUnitId { get; set; }

        /// <summary>
        /// مشخصات انتخاب واحد
        /// </summary>
        [ForeignKey(nameof(SelectUnitId))]
        public virtual SelectUnit SelectUnit { get; set; }

        /// <summary>
        /// کد گروه درسی
        /// </summary>
        [DisplayName("گروه درسی"), Required]
        public int? CourseGroupId { get; set; }

        /// <summary>
        /// مشخصات گروه درسی
        /// </summary>
        [ForeignKey(nameof(CourseGroupId))]
        public virtual CourseGroup CourseGroup { get; set; }

        /// <summary>
        /// تعداد واحد درس
        /// </summary>
        [DisplayName("تعداد واحد"), Required]
        public int? UnitCount { get; set; }

        /// <summary>
        /// کد مورد استثناء در ثبت نام 
        /// </summary>
        [DisplayName("مورد استثناء")]
        public int? StudentExceptCaseId { get; set; }

        /// <summary>
        /// مشخصات مورد استثناء در ثبت نام
        /// </summary>
        [ForeignKey(nameof(StudentExceptCaseId))]
        public virtual StudentExceptCase StudentExceptCase { get; set; }

        /// <summary>
        /// نمرات دانشجو در درس
        /// </summary>
        [DisplayName("نمرات")]
        public virtual CourseGrade CourseGrade { get; set; }

        /// <summary>
        /// نمرات دانشجو در انتخاب واحد
        /// </summary>
        public virtual ICollection<SubCourceGrade> SubCourceGrades { get; set; }
    }
}
