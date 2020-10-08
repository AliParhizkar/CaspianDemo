using Model.CourseInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Translate
{
    /// <summary>
    /// دروس مهمان به
    /// </summary>
    [Table("HostToCourses", Schema = "trs")]
    public class HostToCourse
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// کد مهمان به
        /// </summary>
        [DisplayName("مهمام به")]
        public int HostTodId { get; set; }

        ///// <summary>
        ///// مشخصات مهمان به
        ///// </summary>
        //[ForeignKey(nameof(HostTodId))]
        //public virtual HostTo HostTo { get; set; }

        /// <summary>
        /// کد درس
        /// </summary>
        [DisplayName("درس")]
        public int CourseId { get; set; }

        /// <summary>
        /// مشخصات درس
        /// </summary>
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
