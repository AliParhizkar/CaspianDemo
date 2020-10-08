//using System;
//using Model.Enums;
//using System.ComponentModel;
//using System.Collections.Generic;
//using Model.PersonInfo.StudentInfo;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Model.Translate
//{
//    [Table("HostsTo", Schema = "trs")]
//    public class HostTo
//    {
//        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
//        public int Id { get; set; }

//        /// <summary>
//        /// کد دانشجو
//        /// </summary>
//        [DisplayName("دانشجو")]
//        public int? StudentId { get; set; }

//        /// <summary>
//        /// مشخصات دانشجو
//        /// </summary>
//        [ForeignKey(nameof(StudentId))]
//        public virtual Student Student { get; set; }

//        /// <summary>
//        /// دانشگاه مقصد
//        /// </summary>
//        [DisplayName("دانشگاه مقصد")]
//        public string TargentUniversity { get; set; }

//        /// <summary>
//        /// نوع مهمانی
//        /// </summary>
//        [DisplayName("نوع مهمانی"), Required]
//        public HostType? HostType { get; set; }

//        /// <summary>
//        /// ترم
//        /// </summary>
//        [DisplayName("ترم")]
//        public int? Term { get; set; }

//        /// <summary>
//        /// نام دوره
//        /// </summary>
//        [DisplayName("نام دوره")]
//        public string CourseTitle { get; set; }

//        /// <summary>
//        /// تاریخ شروع دوره
//        /// </summary>
//        [DisplayName("تاریخ شروع دوره")]
//        public DateTime? StartDate { get; set; }

//        /// <summary>
//        /// تاریخ پایان دوره
//        /// </summary>
//        [DisplayName("تاریخ پایان دوره")]
//        public DateTime? EndDate { get; set; }

//        /// <summary>
//        /// تاریخ نامه موافقت
//        /// </summary>
//        [DisplayName("تاریخ نامه موافقت")]
//        public DateTime? LetterDate { get; set; }

//        /// <summary>
//        /// شماره نامه موافقت
//        /// </summary>
//        [DisplayName("شماره نامه موافقت")]
//        public string LetterNo { get; set; }

//        /// <summary>
//        /// موافقت کننده
//        /// </summary>
//        [DisplayName("موافقت کننده")]
//        public Approval? Approval { get; set; }

//        /// <summary>
//        /// تعداد ترم
//        /// </summary>
//        [DisplayName("تعداد ترم")]
//        public TermCountType? TermCountType { get; set; }

//        /// <summary>
//        /// شرح علت مهمانی
//        /// </summary>
//        [DisplayName("شرح علت مهمانی")]
//        public string Descript { get; set; }

//        /// <summary>
//        /// توضیح اضافی
//        /// </summary>
//        [DisplayName("توضیح اضافی")]
//        public string Comment { get; set; }

//        /// <summary>
//        /// دروس مهمان به
//        /// </summary>
//        [CheckOnDelete("برای مهمان به، درس تعریف نشده است و امکان حذف آن وجود ندارد.")]
//        public virtual ICollection<HostToCourse> HostToCourses { get; set; }

//        /// <summary>
//        /// فیلدهای پویای مهمان به
//        /// </summary>
//        public virtual ICollection<HostToFields> HostToFields { get; set; }
//    }

//    [Table("HostToFields")]
//    public class HostToFields
//    {
//        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
//        public int Id { get; set; }

//        public int ParameterId { get; set; }

//        [ForeignKey(nameof(ParameterId))]
//        public virtual Parameter Parameter { get; set; }
//    }

//    /// <summary>
//    /// مشخصات پارامترهای پویای تعریف شده در سیستم
//    /// </summary>
//    [Table("Parameters")]
//    public class Parameter
//    {
//        [Key]
//        public int Id { get; set; }

//        /// <summary>
//        /// عنوان کنترل
//        /// </summary>
//        public string Title { get; set; }

//        /// <summary>
//        /// نوع کنترل
//        /// </summary>
//        public FormControlType FormControlType { get; set; }

//        /// <summary>
//        /// کد فرم
//        /// </summary>
//        public int FormId { get; set; }

//        /// <summary>
//        /// مشخصات فرم
//        /// </summary>
//        [ForeignKey(nameof(FormId))]
//        public virtual Form Form { get; set; }
//    }

//    /// <summary>
//    /// 
//    /// </summary>
//    [Table("ParametersValues")]
//    public class ParameterValue
//    {
//        /// <summary>
//        /// کد پارامتر
//        /// </summary>
//        [Key]
//        public int ParameterId { get; set; }

//        /// <summary>
//        /// مشخصات پارامتر
//        /// </summary>
//        [ForeignKey(nameof(ParameterId))]
//        public virtual Parameter Parameter { get; set; }

//        /// <summary>
//        /// مقدار پارامتر
//        /// </summary>
//        [Key]
//        public int Value { get; set; }

//        /// <summary>
//        /// عنوان پارامتر
//        /// </summary>
//        public string Text { get; set; }
//    }
//}
