using Model.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// فعالیت های فرهنگی دانشجو
    /// </summary>
    [Table("CulturalActs", Schema = "dbo")]
    public class CulturalAct
    {
        [Key, ForeignKey(nameof(Student))]
        public int StudentId { get; set; }

        /// <summary>
        /// ادبی(شعر، داستان)
        /// </summary>
        [DisplayName("ادبی(شعر داستان)")]
        public bool? Literary { get; set; }

        /// <summary>
        /// طراحی(نقاشی کاریکاتور)
        /// </summary>
        [DisplayName("طراحی(نقاشی کاریکاتور)")]
        public bool? Design { get; set; }

        /// <summary>
        /// موسیقی
        /// </summary>
        [DisplayName("موسیقی")]
        public bool? Music { get; set; }

        /// <summary>
        /// ورزشی
        /// </summary>
        [DisplayName("ورزشی")]
        public bool? Sports { get; set; }

        /// <summary>
        /// عکاسی و فیلمبرداری
        /// </summary>
        [DisplayName("عکاسی و فیلمبرداری")]
        public bool? Photography { get; set; }

        /// <summary>
        /// حفظ، قرائت و تفسیر قرآن
        /// </summary>
        [DisplayName("حفظ، قرائت و تفسیر قرآن")]
        public bool? Ghoran { get; set; }

        /// <summary>
        /// تئاتر، فیلم و سینما
        /// </summary>
        [DisplayName("تئاتر، فیلم و سینما")]
        public bool? Sinama { get; set; }

        /// <summary>
        /// اجرای برنامه
        /// </summary>
        [DisplayName("اجرای برنامه")]
        public bool? Plan { get; set; }

        /// <summary>
        /// تایپ
        /// </summary>
        [DisplayName("تایپ")]
        public bool? Type { get; set; }

        /// <summary>
        /// احکام و معارف اسلامی
        /// </summary>
        [DisplayName("احکام و معارف اسلامی")]
        public bool? IslamicEducation { get; set; }

        /// <summary>
        /// ترجمه و مکالمه زبان خارجی
        /// </summary>
        [DisplayName("ترجمه و مکالمه زبان خارجی")]
        public bool? Translate { get; set; }

        /// <summary>
        /// آموزش های امدادی
        /// </summary>
        [DisplayName("آموزش های امدادی")]
        public bool? ReliefEducation { get; set; }

        /// <summary>
        /// خوشنویسی
        /// </summary>
        [DisplayName("خوشنویسی")]
        public bool? Calligraphy { get; set; }

        /// <summary>
        /// دبیری مجلات علمی دانشجویی
        /// </summary>
        [DisplayName("دبیری مجلات علمی دانشجویی")]
        public bool? SecretaryJournal { get; set; }

        /// <summary>
        /// مقاله نویسی و دیگر امور پژوهشی
        /// </summary>
        [DisplayName("مقاله نویسی و دیگر امور پژوهشی")]
        public bool? Article { get; set; }

        /// <summary>
        /// مداحی و تواشیح
        /// </summary>
        [DisplayName("مداحی و تواشیح")]
        public bool? Madahi { get; set; }

        /// <summary>
        /// انتشار نشریات دانشجویی
        /// </summary>
        [DisplayName("انتشار نشریات دانشجویی")]
        public bool? MagazinePropagation { get; set; }

        /// <summary>
        /// روزنامه نگاری و وبلاگ نویسی
        /// </summary>
        [DisplayName("روزنامه نگاری و وبلاگ نویسی")]
        public bool? Weblog { get; set; }

        /// <summary>
        /// دیگر مهارت های رایاته ای
        /// </summary>
        [DisplayName("دیگر مهارت های رایانه ای")]
        public bool? OtherComputerSkill { get; set; }

        /// <summary>
        /// پیشنهاد اردو
        /// </summary>
        [DisplayName("پیشنهاد اردو")]
        public SuggestUrdoType? SuggestUrdo { get; set; }

        /// <summary>
        /// سایر پیشنهاد اردو
        /// </summary>
        [DisplayName("سایر پیشنهاد اردو"), MaxLength(200)]
        public string OtherSuggestUrdo { get; set; }

        /// <summary>
        /// علایق همکاری 1
        /// </summary>
        [DisplayName("علایق همکاری 1")]
        public bool? CooperationInterests1 { get; set; }

        /// <summary>
        /// علایق همکاری 2
        /// </summary>
        [DisplayName("علایق همکاری 2")]
        public bool? CooperationInterests2 { get; set; }

        /// <summary>
        /// علایق همکاری 3
        /// </summary>
        [DisplayName("علایق همکاری 3")]
        public bool? CooperationInterests3 { get; set; }

        /// <summary>
        /// علایق همکاری 4
        /// </summary>
        [DisplayName("علایق همکاری 4")]
        public bool? CooperationInterests4 { get; set; }

        /// <summary>
        /// علایق همکاری 5
        /// </summary>
        [DisplayName("علایق همکاری 5")]
        public bool? CooperationInterests5 { get; set; }

        /// <summary>
        /// علایق همکاری 6
        /// </summary>
        [DisplayName("علایق همکاری 6")]
        public bool? CooperationInterests6 { get; set; }

        /// <summary>
        /// سایر علایق همکاری
        /// </summary>
        [DisplayName("سایر علایق همکاری"), MaxLength(200)]
        public string OtherCooperationInterests { get; set; }

        /// <summary>
        /// همکاری در دفتر امور فرهنگی
        /// </summary>
        [DisplayName("همکاری در دفتر امور فرهنگی")]
        public UnversityCooperationType? UnversityCooperationType { get; set; }

        /// <summary>
        /// ساعت همکاری در دانشگاه
        /// </summary>
        [DisplayName("ساعت همکاری در دانشگاه")]
        public decimal? UniversityHour { get; set; }

        /// <summary>
        /// ساعت همکاری در خوابگاه
        /// </summary>
        [DisplayName("ساعت همکاری در خوابگاه")]
        public decimal? DormHour { get; set; }

        /// <summary>
        /// دیگر انواع مهارت
        /// </summary>
        [DisplayName("دیگر انواع مهارت"), MaxLength(200)]
        public string OthersSkill { get; set; }

        /// <summary>
        /// سایر موارد
        /// </summary>
        [DisplayName("سایر موارد"), MaxLength(200)]
        public string OthersCases { get; set; }

        /// <summary>
        /// مشخصات دانشجو
        /// </summary>
        public virtual Student Student { get; set; }

    }
}
