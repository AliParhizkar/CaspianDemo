using Caspian.Common;
using Model.ExceptCaseInfo;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.CourseInfo
{
    public class Course : CourseStudy
    {
        /// <summary>
        /// سایر مشخصات مربوط به درس
        /// </summary>
        public virtual CourseDetail Detail { get; set; }

        /// <summary>
        /// روش محاسبه شهریه
        /// </summary>
        public virtual Tuition Tuition { get; set; }

        /// <summary>
        /// دروس وابسته به درس
        /// </summary>
        [InverseProperty(nameof(Course))]
        [CheckOnDelete("برای درس دروس وابسته تعریف شده است و امکان حذف آن وجود ندارد")]
        public virtual ICollection<CourseDependency> Courses { get; set; }

        /// <summary>
        /// دروس وابسته به این درس
        /// </summary>
        [InverseProperty("DependentCourse")]
        [CheckOnDelete("برای درس دروس وابسته تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<CourseDependency> CourseDependencies { get; set; }

        /// <summary>
        /// محدودیت های درس
        /// </summary>
        [CheckOnDelete("برای درس محدودیت تعریف شده و امکان حذف آن وجود ندارد.")]
        public virtual ICollection<CourseLimitation> CourseLimitations { get; set; }

        /// <summary>
        /// زیردرسها
        /// </summary>
        [CheckOnDelete("برای درس زیردرس تعریف شده و امکان حذف آن وجود ندارد")]
        public virtual ICollection<SubCourseCourse> SubCourses { get; set; }

        /// <summary>
        /// آئین نامه هایی که برای این درس تعریف شده است
        /// </summary>
        [CheckOnDelete("برای این درس آئین نامه تعریف شده است و امکان حذف آن وجود ندارد")]
        public virtual ICollection<StudentExceptCase> StudentExceptCases { get; set; }

        /// <summary>
        /// با دریافت محدودیت های دانشجو چک می کند که آیا دانشجو می تواند درس را اخذ نماید یا خیر
        /// </summary>
        /// <param name="limitation"></param>
        /// <returns></returns>
        public bool IsLimited(CourseLimitation limitation)
        {
            if (CourseLimitations == null)
                return false;
            foreach (var limit in CourseLimitations)
                if (limit.IsLimited(limitation))
                    return true;
            return false;
        }
    }
}
