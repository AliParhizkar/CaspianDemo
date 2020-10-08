using Caspian.Common;
using System.Collections.Generic;

namespace Model.CourseInfo
{
    /// <summary>
    /// مشخصات زیردرس
    /// </summary>
    public class SubCourse : CourseStudy
    {
        /// <summary>
        /// مشخصات زیردرسهای زیردرس
        /// </summary>
        [CheckOnDelete("این زیردرس بعنوان زیردرس دروس تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<SubCourseCourse> SubCourses { get; set; }
    }
}
