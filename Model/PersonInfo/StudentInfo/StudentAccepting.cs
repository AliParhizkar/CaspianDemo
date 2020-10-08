using System;
using Model.Enums;
using Model.BaseInfo;
using Model.AcceptingInfo;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo.StudentInfo
{
    /// <summary>
    /// مشخصات پذیرش دانشجو
    /// </summary>
    [Table("StudentAcceptings", Schema = "dbo")]
    public class StudentAccepting
    {
        [Key, ForeignKey(nameof(Student)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StudentAcceptingId { get; set; }

        /// <summary>
        /// کد پذیرش
        /// </summary>
        [DisplayName("پذیرش")]
        public int? AcceptingId { get; set; }

        /// <summary>
        /// مشخصلات پذیرش
        /// </summary>
        [ForeignKey(nameof(AcceptingId))]
        public virtual Accepting Accepting { get; set; }

        /// <summary>
        /// کد داوطلبی
        /// </summary>
        [DisplayName("کد داوطلبی")]
        public int? VolunteerCode { get; set; }

        /// <summary>
        /// رتبه پذیرش
        /// </summary>
        [DisplayName("رتبه پذیرش")]
        public int? ReceptionRank { get; set; }

        /// <summary>
        /// امتیاز پذیرش
        /// </summary>
        [DisplayName("امتیاز پذیرش")]
        public int? ReceptionPrivilege { get; set; }

        /// <summary>
        /// گروه آزمایشی پذیرش ورودی
        /// </summary>
        [DisplayName("گروه آزمایشی پذیرش ورودی"), Required]
        public ReceptionGroup? ReceptionGroup { get; set; }

        /// <summary>
        /// شماره پرونده پذیرش
        /// </summary>
        [DisplayName("شماره پرونده پذیرش")]
        public int? ReceptionFileNo { get; set; }

        /// <summary>
        /// ردیف پذیرش
        /// </summary>
        [DisplayName("ردیف پذیرش")]
        public int? ReceptionRow { get; set; }

        /// <summary>
        /// صفحه ی پذیرش
        /// </summary>
        [DisplayName("صفحه پذیرش")]
        public string ReceptionPage { get; set; }

        /// <summary>
        /// کد نوع پذیرش
        /// </summary>
        [DisplayName("نوع پذیرش")]
        public int ReceptionId { get; set; }

        /// <summary>
        /// مشخصات نوع پذیرش
        /// </summary>
        [ForeignKey(nameof(ReceptionId))]
        public virtual BaseDefination Reception { get; set; }

        /// <summary>
        /// کد سهمیه ثبت نامی
        /// </summary>
        [DisplayName("سهمیه ثبت نامی")]
        public int RegisterQuotasId { get; set; }

        /// <summary>
        /// مشخصات سهمیه ثبت نامی
        /// </summary>
        [ForeignKey(nameof(RegisterQuotasId))]
        public virtual BaseDefination RegisterQuotas { get; set; }

        /// <summary>
        /// کد سهمیه نهایی
        /// </summary>
        [DisplayName("سهمیه نهایی")]
        public int FinalQuotasId { get; set; }

        /// <summary>
        /// مشخصات سهمیه نهایی
        /// </summary>
        [ForeignKey(nameof(FinalQuotasId))]
        public virtual BaseDefination FinalQuotas { get; set; }

        /// <summary>
        /// کد سهمیه قبولی
        /// </summary>
        [DisplayName("سهمیه قبولی")]
        public int AcceptQuotasId { get; set; }

        /// <summary>
        /// مشخصات سهمیه قبولی
        /// </summary>
        [ForeignKey(nameof(AcceptQuotasId))]
        public virtual BaseDefination AcceptQuotas { get; set; }

        /// <summary>
        /// نام درس1
        /// </summary>
        [DisplayName("نام درس1")]
        public string CourseName1 { get; set; }

        /// <summary>
        /// درصد درس1
        /// </summary>
        [DisplayName("درصد درس1")]
        public decimal CoursePercet1 { get; set; }

        /// <summary>
        /// نام درس2
        /// </summary>
        [DisplayName("نام درس2")]
        public string CourseName2 { get; set; }

        /// <summary>
        /// درصد درس2
        /// </summary>
        [DisplayName("درصد درس2")]
        public decimal CoursePercet2 { get; set; }

        /// <summary>
        /// نام درس3
        /// </summary>
        [DisplayName("نام درس3")]
        public string CourseName3 { get; set; }

        /// <summary>
        /// درصد درس3
        /// </summary>
        [DisplayName("درصد درس3")]
        public decimal CoursePercet3 { get; set; }

        /// <summary>
        /// نام درس4
        /// </summary>
        [DisplayName("نام درس4")]
        public string CourseName4 { get; set; }

        /// <summary>
        /// درصد درس4
        /// </summary>
        [DisplayName("درصد درس4")]
        public decimal CoursePercet4 { get; set; }

        /// <summary>
        /// نام درس5
        /// </summary>
        [DisplayName("نام درس5")]
        public string CourseName5 { get; set; }

        /// <summary>
        /// درصد درس5
        /// </summary>
        [DisplayName("درصد درس5")]
        public decimal CoursePercet5 { get; set; }

        /// <summary>
        /// نام درس6
        /// </summary>
        [DisplayName("نام درس6")]
        public string CourseName6 { get; set; }

        /// <summary>
        /// درصد درس6
        /// </summary>
        [DisplayName("درصد درس6")]
        public decimal CoursePercet6 { get; set; }

        /// <summary>
        /// کد نوع مدرک پایه
        /// </summary>
        [DisplayName("نوع مدرک پایه")]
        public int BaseDegreeId { get; set; }

        /// <summary>
        /// مشخصات مدرک پایه
        /// </summary>
        [ForeignKey(nameof(BaseDegreeId))]
        public virtual BaseDefination BaseDegree { get; set; }

        /// <summary>
        /// کد طریقه ورود به دانشگاه
        /// </summary>
        [DisplayName("طریقه ورود به دانشگاه")]
        public int EntireMethodId { get; set; }

        /// <summary>
        /// مشخصات طریقه ورود به دانشگاه
        /// </summary>
        [ForeignKey(nameof(EntireMethodId))]
        public virtual BaseDefination EntireMethod { get; set; }

        /// <summary>
        /// عنوان مدرک پایه
        /// </summary>
        [DisplayName("عنوان مدرک پایه")]
        public string DegreeTitle { get; set; }

        /// <summary>
        /// محل اخذ مدرک پایه
        /// </summary>
        [DisplayName("محل اخذ مدرک پایه")]
        public string DegreeLocation { get; set; }

        /// <summary>
        /// تاریخ اخذ مدرک پایه
        /// </summary>
        [DisplayName("تاریخ اخذ مدرک پایه")]
        public DateTime? DegreeDate { get; set; }

        /// <summary>
        /// معدل مدرک پایه
        /// </summary>
        [DisplayName("معدل مدرک پایه")]
        public decimal? DegreeAvrage { get; set; }

        /// <summary>
        /// شماره تائیدیه تحصیلی
        /// </summary>
        [DisplayName("شماره تائیدیه تحصیلی")]
        public string VerificationNo { get; set; }

        /// <summary>
        /// تاریخ تائیدیه تحصیلی
        /// </summary>
        [DisplayName("تاریخ تائیدیه تحصیلی")]
        public DateTime? VerificationDate { get; set; }

        /// <summary>
        /// شماره صلاحیت عمومی
        /// </summary>
        [DisplayName("شماره صلاحیت عمومی")]
        public string QualificationNo { get; set; }

        /// <summary>
        /// تاریخ صلاحیت عمومی
        /// </summary>
        [DisplayName("تاریخ صلاحیت عمومی")]
        public DateTime? QualificationDate { get; set; }

        /// <summary>
        /// کد مرکزی
        /// </summary>
        [DisplayName("کد مرکزی")]
        public string MainCode { get; set; }

        /// <summary>
        /// کد رشته در آزمون
        /// </summary>
        [DisplayName("کد رشته در آزمون")]
        public string StudyFieldCode { get; set; }

        /// <summary>
        /// نام رشته در آزمون
        /// </summary>
        [DisplayName("نام رشته در آزمون")]
        public string StudyFieldName { get; set; }

        /// <summary>
        /// مناطق محروم
        /// </summary>
        [DisplayName("مناطق محروم")]
        public string DeprivedAreas { get; set; }

        /// <summary>
        /// محل تعهد خدمت
        /// </summary>
        [DisplayName("محل تعهد خدمت")]
        public string ObligationLocation { get; set; }

        /// <summary>
        /// توضیخات
        /// </summary>
        [DisplayName("توضیحات"), MaxLength()]
        public string Comment { get; set; }

        /// <summary>
        /// مشخصات دانشجو
        /// </summary>
        public virtual Student Student { get; set; }
    }
}
