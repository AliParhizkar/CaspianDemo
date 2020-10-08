using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نوع تعاریف اولیه
    /// </summary>
    public enum BaseDefinationType: byte
    {
        /// <summary>
        /// نوع پرونده
        /// </summary>
        [EnumField("نوع پرونده")]
        FileType = 1,

        /// <summary>
        /// نظام وظیفه
        /// </summary>
        [EnumField("نظام وظیفه")]
        DutySystem,

        /// <summary>
        /// محل اقامت
        /// </summary>
        [EnumField("محل اقامت")]
        ResidencePlace,

        /// <summary>
        /// گروه تحصیلی استاد
        /// </summary>
        [EnumField("گروه تحصیلی استاد")]
        ProfessorDepartment,

        /// <summary>
        /// وضعیت تحصیلی استاد
        /// </summary>
        [EnumField("وضعیت تحصیلی استاد")]
        ProfessorStudy,

        /// <summary>
        /// نوع حکم استاد
        /// </summary>
        [EnumField("نوع حکم استاد")]
        Employment,

        /// <summary>
        /// نوع ارزشیابی استاد
        /// </summary>
        [EnumField("نوع ارزشیابی استاد")]
        Assessment,

        /// <summary>
        /// مقطع درمانی
        /// </summary>
        [EnumField("مقطع درمانی")]
        Healing,

        /// <summary>
        /// نوع ورزش
        /// </summary>
        [EnumField("نوع ورزش")]
        ExerciseType,

        /// <summary>
        /// سطح علوم حوزوی
        /// </summary>
        [EnumField("سطح علوم حوزوی")]
        SeminaryLevel,

        /// <summary>
        /// سهمیه قبولی
        /// </summary>
        [EnumField("سهمیه قبولی")]
        AcceptQuotas,

        /// <summary>
        /// تخصص علوم حوزوی
        /// </summary>
        [EnumField("تخصص علوم حوزوی")]
        SeminaryExpreince,

        /// <summary>
        /// نسبت ایثارگری
        /// </summary>
        [EnumField("نسبت ایثارگری")]
        SacrificialRelation,

        /// <summary>
        /// نوع بیمه
        /// </summary>
        [EnumField("نوع بیمه")]
        InsuranceType,

        /// <summary>
        /// نوع فعالیت سیاسی
        /// </summary>
        [EnumField("نوع فعالیت سیاسی")]
        PoliticsActionType,

        /// <summary>
        /// نوع عضویت در فعالیت سیاسی
        /// </summary>
        [EnumField("نوع عضویت در فعالیت سیاسی")]
        MembershipType,

        /// <summary>
        /// نوع مدرک امداد و نجات
        /// </summary>
        [EnumField("نوع مدرک امداد و نجات")]
        RescueGradeType,

        /// <summary>
        /// تحصیلات
        /// </summary>
        [EnumField("تحصیلات")]
        Education,

        /// <summary>
        /// نوع مسابقات
        /// </summary>
        [EnumField("نوع مسابقات")]
        RaceType,

        /// <summary>
        /// سهمیه نهایی
        /// </summary>
        [EnumField("سهمیه نهایی")]
        FinalQuotas,

        /// <summary>
        /// نوع اسکن
        /// </summary>
        [EnumField("نوع اسکن")]
        ScanType,

        /// <summary>
        /// موضوع پرداخت
        /// </summary>
        [EnumField("موضوع پرداخت")]
        PaymentIssue,

        /// <summary>
        /// آیتم پرداخت
        /// </summary>
        [EnumField("آیتم پرداخت")]
        ItemPayment,

        /// <summary>
        /// نوع درس از لحاظ آموزشی
        /// </summary>
        [EnumField("نوع درس از لحاظ آموزشی")]
        CourseType,

        /// <summary>
        /// شهریه عملی
        /// </summary>
        [EnumField("شهریه عملی")]
        TeoriaTuition,

        /// <summary>
        /// مقطع پاسی
        /// </summary>
        [EnumField("مقطع پاسی")]
        PassageSection,

        /// <summary>
        /// سیستم آموزشی
        /// </summary>
        [EnumField("سیستم آموزشی")]
        LearningSystem,

        /// <summary>
        /// وضعیت تحصیلی نهایی
        /// </summary>
        [EnumField("وضعیت تحصیلی نهایی")]
        FinalStatus,

        /// <summary>
        /// وضعیت تحصیلی تکمیلی
        /// </summary>
        [EnumField("وضعیت تحصیلی تکمیلی")]
        SupplementaryStatus,

        /// <summary>
        /// مراکز تحقیقاتی
        /// </summary>
        [EnumField("مراکز تحقیقاتی")]
        SearchCenter,

        /// <summary>
        /// نوع پذیرش
        /// </summary>
        [EnumField("نوع پذیرش")]
        Reception,

        /// <summary>
        /// سهمیه ثبت نامی
        /// </summary>
        [EnumField("سهمیه ثبت نامی")]
        RegisterQuotas,

        /// <summary>
        /// سهمیه قبولی/نهایی
        /// </summary>
        [EnumField("سهمیه قبولی/نهایی")]
        Quotas,

        /// <summary>
        /// نوع مدرک پایه
        /// </summary>
        [EnumField("نوع مدرک پایه")]
        BaseDegree,

        /// <summary>
        /// بورسیه
        /// </summary>
        [EnumField("بورسیه")]
        Scholarship,

        /// <summary>
        /// تعداد زیرگروه ها
        /// </summary>
        [EnumField("تعداد زیرگروهها")]
        SubGroupCount,

        /// <summary>
        /// زیرگروه
        /// </summary>
        [EnumField("زیرگروه")]
        UnderGroup,

        /// <summary>
        /// جزء بسته بندی
        /// </summary>
        [EnumField("جزء بسته بندی")]
        Grouping,

        /// <summary>
        /// طریقه ورود به دانشگاه
        /// </summary>
        [EnumField("طریقه ورود به دانشگاه")]
        EntireMethod,

        /// <summary>
        /// وضعیت فعلی اشتغال
        /// </summary>
        [EnumField("وضعیت فعلی اشتغال")]
        CurentJobStatus,

        /// <summary>
        /// تابعیت
        /// </summary>
        [EnumField("تابعیت")]
        Citizenship,

        /// <summary>
        /// مرتبه علمی
        /// </summary>
        [EnumField("مرتبه علمی")]
        SienceRank,

        /// <summary>
        /// نوع چارت اول
        /// </summary>
        [EnumField("نوع چارت اول")]
        ChartType1,

        /// <summary>
        /// نوع چارت دوم
        /// </summary>
        [EnumField("نوع چارت دوم")]
        ChartType2,

        /// <summary>
        /// ماهیت درس
        /// </summary>
        [EnumField("ماهیت درس")]
        CourseNature,

        /// <summary>
        /// دیسپلین
        /// </summary>
        [EnumField("دیسپلین")]
        Dispiline 
    }
}
