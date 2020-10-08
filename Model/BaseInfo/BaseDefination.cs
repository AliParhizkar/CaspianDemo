using Model.Enums;
using Model.CourseInfo;
using Model.PersonInfo;
using System.ComponentModel;
using System.Collections.Generic;
using Model.PersonInfo.StudentInfo;
using Model.PersonInfo.ProfessorInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.CourseGroupInfo;
using Caspian.Common;

namespace Model.BaseInfo
{
    /// <summary>
    /// تعاریف اصلی
    /// </summary>
    [Table("BaseDefinations", Schema = "dbo")]
    public class BaseDefination
    {
        /// <summary>
        /// کد 
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// عنوان 
        /// </summary>
        [DisplayName("عنوان"), Required,]
        public string Title { get; set; }

        /// <summary>
        /// نوع تعریف
        /// </summary>
        [DisplayName("نوع تعاریف اولیه"), Required]
        public BaseDefinationType BaseDefinationType { get; set; }

        /// <summary>
        /// مشخصات تمامی افرادی که پرونده آنها از این نوع تعریف شده است.
        /// </summary>
        [CheckOnDelete("این نوع پرونده برای برخی از افراد تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("FileType")]
        public virtual ICollection<AcademicPerson> People { get; set; }

        /// <summary>
        /// تمامی دانشجویانی که از این جزء بسته بندی بوده اند
        /// </summary>
        [CheckOnDelete("دانشجویانی از این جزءبسته بندی تعریف شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Grouping")]
        public virtual ICollection<Student> GroupingStudents { get; set; }

        /// <summary>
        /// تمامی دانشجویانی که از این سیستم آموزشی تعریف شده اند
        /// </summary>
        [CheckOnDelete("سیستم آموزشی دارای دانشجو می باشد و امکان حذف آن وجود ندارد")]
        [InverseProperty("LearningSystem")]
        public virtual ICollection<Student> LearningSystemStudents { get; set; }

        /// <summary>
        /// دانشجویانی که دارای این وضعیت تحصیلی نهایی هستند
        /// </summary>
        [CheckOnDelete("وضعیت تحصیلی نهایی دارای دانشجو می باشد و امکان حذف آن وجود ندارد.")]
        [InverseProperty("FinalStatus")]
        public virtual ICollection<Student> FinalStatusStudents { get; set; }

        /// <summary>
        /// دانشجویانی که دارای این وضعیت تحصیلی نهایی می باشند
        /// </summary>
        [CheckOnDelete("این وضعیت تحصیلی نهایی دارای دانشجو می باشد و امکان حذف آن وجود ندارد.")]
        [InverseProperty("SupplementaryStatus")]
        public virtual ICollection<Student> SupplementaryStatusStudents { get; set; }

        /// <summary>
        /// دانشجویانی که عضو این مرکز تحقیقاتی هستند
        /// </summary>
        [CheckOnDelete("این مرکز تحقیقاتی دارای دانشجو می باشد و امکان حذف آن وجود ندارد")]
        [InverseProperty("SearchCenter")]
        public virtual ICollection<Student> SearchCenterStudents { get; set; }

        /// <summary>
        /// مشخصات دروسی که از این نوع تعریف شده اند
        /// </summary>
        [CheckOnDelete("دروسی از این نوع تعریف شده اند و امکان حذف آنها وجود ندارد.")]
        [InverseProperty("CourseType")]
        public virtual ICollection<CourseStudy> CourseStudies { get; set; }

        /// <summary>
        /// اسناد پذیرش
        /// </summary>
        //[CheckOnDelete("برای این نوع اسناد پذیرش تعریف شده و امکان حذف آن وجود ندارد.")]
        //[InverseProperty("ScanType")]
        //public virtual ICollection<AcceptingDocuments> AcceptingDocuments { get; set; }

        /// <summary>
        /// مقطع درمانی
        /// </summary>
        [CheckOnDelete("برای این مقطع درمانی درس تعریف شده و امکان حذف آن وجود ندارد")]
        [InverseProperty("Healing")]
        public virtual ICollection<CourseDetail> HealingCourseDetails { get; set; }

        /// <summary>
        /// دروس مقطع پاسی
        /// </summary>
        [CheckOnDelete("برای این مقطع پاسی درس تعریف شده و امکان حذف آن وجود ندارد")]
        [InverseProperty("PassageSection")]
        public virtual ICollection<CourseDetail> PassageSectionCourseDetails { get; set; }

        /// <summary>
        /// دروس چارت اول
        /// </summary>
        [CheckOnDelete("برای این چارت درس تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Chart1Type")]
        public virtual ICollection<CourseDetail> Chart1TypeCourseDetails { get; set; }

        /// <summary>
        /// دروس چارت دوم
        /// </summary>
        [CheckOnDelete("برای این چارت درس تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Chart2Type")]
        public virtual ICollection<CourseDetail> Chart2TypeCourseDetails { get; set; }

        /// <summary>
        /// دروسی که دارای این ماهیت هستند
        /// </summary>
        [CheckOnDelete("برای این ماهیت، درس تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("CourseNature")]
        public virtual ICollection<CourseDetail> CourseNatureCourseDetails { get; set; }

        /// <summary>
        /// دروسی که دارای این دسپلین هستند
        /// </summary>
        [CheckOnDelete("برای این دیسپلین، درس تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Dispiline")]
        public virtual ICollection<CourseDetail> DispilineCourseDetails { get; set; }

        /// <summary>
        /// مشخصات دروس این ارزشیابی
        /// </summary>
        [CheckOnDelete("برای این نوع ارزشیابی درس تعریف شده است و امکان حذف آن وجود ندارد")]
        [InverseProperty("ProfessorValidation")]
        public virtual ICollection<CourseDetail> ProfessorValidationCourseDetails { get; set; }



        /// <summary>
        /// مشخصات افرادی که دارای این تابعیت هستند
        /// </summary>
        [CheckOnDelete("افرادی از این تابعیت تعریف شده اند و امکان حذف آنها وجود ندارد")]
        [InverseProperty("Citizenship")]
        public virtual ICollection<PersonFamilyProfile> PersonFamilyProfiles { get; set; }

        /// <summary>
        /// مشخصات افرادی که دارای این وضعیت نظام وظیفه می باشند
        /// </summary>
        [CheckOnDelete("افرادی دارای این نوع نظام وظیفه می باشند و امکان حذف آن وجود ندارد")]
        [InverseProperty("DutySystem")]
        public virtual ICollection<PersonFamilyProfile> PersonFamilyProfiles1 { get; set; }

        /// <summary>
        /// مشخصات افرادی که دارای این محل اقامت می باشند
        /// </summary>
        [CheckOnDelete("افرادی با این محل اقامت در سیستم ثبت شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("ResidencePlace")]
        public virtual ICollection<PersonFamilyProfile> ResidencePlaces { get; set; }

        /// <summary>
        /// مشخصات افرادی که با این نسبت ایثارگری تعریف شده اند
        /// </summary>
        [CheckOnDelete("افرادی با این نسبت ایثارگری تعریف شده اند و امکان حذف آنها وجود ندارد.")]
        [InverseProperty("SacrificialRelation")]
        public virtual ICollection<PersonSacrificial> PersonSacrificials { get; set; }

        /// <summary>
        /// مشخصات افرادی که دارای این تحصیلات می باشند
        /// </summary>
        [CheckOnDelete("افرادی با این تحصیلات در سیستم تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Education")]
        public virtual ICollection<RaceRelation> RaceRelations { get; set; }

        /// <summary>
        /// مشخصات افرادی که در این نوع مسابقه یا جشنواره ثبت نام کرده اند
        /// </summary>
        [CheckOnDelete("افرادی در این مسابقه/جشنواره ثبت نام کرده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("RaceType")]
        public virtual ICollection<RaceRelation> RaceRelations1 { get; set; }

        /// <summary>
        /// مشخصات افرادی که دارای این نوع فعالیت امداد و نجات بوده اند
        /// </summary>
        [CheckOnDelete("افرادی دارای این نوع فعالیت امداد و نجات بوده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("RescueGradeType")]
        public virtual ICollection<RescueAction> RescueActions { get; set; }

        /// <summary>
        /// مشخصات افرادی که دارای این نوع فعالیت سیاسی می باشند
        /// </summary>
        [CheckOnDelete("افرادی دارای این نوع فعالیت سیاسی می باشند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("PoliticsActionType")]
        public virtual ICollection<PoliticsAction> PoliticsActions { get; set; }

        /// <summary>
        /// مشخصات افرادی که دارای این نوع عضویت سیاسی می باشند
        /// </summary>
        [CheckOnDelete("افرادی با این نوع عضویت تعریف شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("MembershipType")]
        public virtual ICollection<PoliticsAction> PoliticsActions1 { get; set; }

        /// <summary>
        /// مشخصات افرادی که با این نوع ورزش درسیستم ثبت شده اند
        /// </summary>
        [CheckOnDelete("افرادی با این نوع ورزش در سیستم ثبت شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("ExerciseType")]
        public virtual ICollection<ExerciseTitle> ExerciseTitles { get; set; }

        /// <summary>
        /// مشخصات مدارکی که با این گروه تحصیلی تعریف شده اند
        /// </summary>
        [CheckOnDelete("مدارکی با این گروه تحصیلی تعریف شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Department")]
        public virtual ICollection<Degree> Degrees { get; set; }

        /// <summary>
        /// مشخصات بیمه هایی که از این نوع تعریف شده اند
        /// </summary>
        [CheckOnDelete("بیمه هایی از این نوع تعریف شده است و امکان حذف آن وجود ندارد.")]
        [InverseProperty("InsuranceType")]
        public virtual ICollection<Insurance> Insurances { get; set; }

        /// <summary>
        /// مشخصات اساتیدی که دارای این نوع حکم هستند
        /// </summary>
        [CheckOnDelete("اساتیدی با این نوع حکم در سیستم تعریف شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Employment")]
        public virtual ICollection<ProfessorEmployment> ProfessorEmployments { get; set; }

        /// <summary>
        /// مشخصات اساتیدی که با این نوع استخدام تعریف شده اند
        /// </summary>
        [CheckOnDelete("اساتیدی با این نوع استخدام در سیستم ثبت شده اند و امکان حذف آن وجود ندارد")]
        [InverseProperty("EmployType")]
        public virtual ICollection<ProfessorEmployment> ProfessorEmployments1 { get; set; }

        /// <summary>
        /// مشخصات اساتیدی با این نوع ارزشیابی استاد از اساتید همکار
        /// </summary>
        [CheckOnDelete("اساتیدی با این نوع ارزشیابی استاد از اساتید همکار در سیستم ثبت شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Assessment")]
        public virtual ICollection<ProfessorEmployment> ProfessorEmployments2 { get; set; }

        /// <summary>
        /// مشخصات اساتیدی با این نوع ارزشیابی مدیران از استاد
        /// </summary>
        [CheckOnDelete("اساتیدی با این نوع ارزشیابی مدیران از استاد در سیستم ثبت شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("MasterAssessment")]
        public virtual ICollection<ProfessorEmployment> ProfessorEmployments3 { get; set; }

        /// <summary>
        /// مشخصات افرادی با این وضعیت اشتغال
        /// </summary>
        [CheckOnDelete("افرادی با این وضعیت اشتغال تعریف شده اند و امکان حذف آن وجود ندارد")]
        [InverseProperty("CurentJobStatus")]
        public virtual ICollection<JobInfo> JobInfos { get; set; }

        /// <summary>
        /// مشخصات افرادی با این نوع بیمه
        /// </summary>
        [CheckOnDelete("افرادی با این نوع بیمه در سیستم تعریف شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("InsuranceType")]
        public virtual ICollection<JobInfo> JobInfos1 { get; set; }

        /// <summary>
        /// مشخصات افرادی با این نوع بورسیه
        /// </summary>
        [CheckOnDelete("افرادی با این نوع بورسیه در سیستم تعریف شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Scholarship")]
        public virtual ICollection<SupporterOrgan> SupporterOrgans { get; set; }

        /// <summary>
        /// مشخصات دانشجویانی با این نوع پذیرش
        /// </summary>
        [CheckOnDelete("دانشجویانی با این نوع پذیرش در سیستم تعریف شده اند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("Reception")]
        public virtual ICollection<StudentAccepting> StudentAcceptings { get; set; }

        /// <summary>
        /// مشخصات دانشجویانی با این نوع سهمیه ثبت نامی
        /// </summary>
        [CheckOnDelete("دانشجویانی با این نوع سهمیه ثبت نامی در سیستم وجود دارند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("RegisterQuotas")]
        public virtual ICollection<StudentAccepting> StudentAcceptings1 { get; set; }

        /// <summary>
        /// مشخصات دانشجویانی با این نوع سهمیه نهایی
        /// </summary>
        [CheckOnDelete("دانشجویانی با این نوع سهمیه نهایی در سیستم تعریف شده اند و امکان حذف آن وجود ندارد")]
        [InverseProperty("FinalQuotas")]
        public virtual ICollection<StudentAccepting> StudentAcceptings2 { get; set; }

        /// <summary>
        /// مشخصات دانشجویانی با این نوع سهمیه قبولی
        /// </summary>
        [CheckOnDelete("دانشجویانی با این نوع سهمیه قبولی در سیستم تعریف شده اند و امکان حذف آن وجود ندارد")]
        [InverseProperty("AcceptQuotas")]
        public virtual ICollection<StudentAccepting> StudentAcceptings3 { get; set; }

        /// <summary>
        /// مشخصات دانشجویانی با این نوع طریقه ورود
        /// </summary>
        [CheckOnDelete("دانشجویانی با این نوع طریقه ورود در سیستم وجود دارند و امکان حذف آن وجود ندارد.")]
        [InverseProperty("EntireMethod")]
        public virtual ICollection<StudentAccepting> StudentAcceptings4 { get; set; }

        /// <summary>
        /// تحصیلات حوزوی که برای این سطح تعریف شده است
        /// </summary>
        [CheckOnDelete("برای این سطح تحصیلا حوزوی تعریف شده و امکان حذف آن وجود ندارد")]
        [InverseProperty("SeminaryLevel")]
        public virtual ICollection<Seminary> SeminariesLevel { get; set; }

        /// <summary>
        /// تحصیلات حوزوی که برای این تخصص تعریف شده اند
        /// </summary>
        [CheckOnDelete("برای این تخصص تحصیلات حوزوی تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("SeminaryExpreince")]
        public virtual ICollection<Seminary> SeminariesExpreince { get; set; }

        /// <summary>
        /// شهریه های که برای این نوع دروس تئوری تعریف شده اند
        /// </summary>
        [CheckOnDelete("برای این نوع درس شهریه تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("TeoriaTuition")]
        public virtual ICollection<Tuition> TeoriaTuitions { get; set; }

        /// <summary>
        /// شهریه هایی که برای این نوع دروس عملی تعریف شده اند
        /// </summary>
        [CheckOnDelete("برای این نوع درس شهریه تعریف شده و امکان حذف آن وجود ندارد")]
        [InverseProperty("FuncTuition")]
        public virtual ICollection<Tuition> FuncTuitions { get; set; }

        /// <summary>
        /// شهریه های که برای این نوع درس کارگاهی تعریف شده اند
        /// </summary>
        [CheckOnDelete("برای این نوع درس شهریه تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("WorkTuition")]
        public virtual ICollection<Tuition> WorkTuitions { get; set; }

        /// <summary>
        /// محدودیت های زیرگروه
        /// </summary>
        [CheckOnDelete("برای این زیرگروه گروه تعریف شده و امکان حذف آن وجود ندارد.")]
        [InverseProperty("UnderGroup")]
        public virtual ICollection<CourseGroupLimitation> CourseGroupLimitations { get; set; }

        /// <summary>
        /// اساتید زیرگروه
        /// </summary>
        [CheckOnDelete("برای این زیرگروه استاد تعریف شده و امکان حذف آن وجود ندارد")]
        [InverseProperty("UnderGroup")]
        public virtual ICollection<CourseGroupProfessor> CourseGroupProfessors { get; set; }
    }
}
