//using System;
//using Model.Enums;
//using Model.BaseInfo;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Model.Timing
//{
//    /// <summary>
//    /// تعریف گروهی زمان برگزاری امتحانات
//    /// </summary>
//    public class ExamTimeGroup
//    {
//        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
//        public int Id { get; set; }

//        /// <summary>
//        /// ترم
//        /// </summary>
//        [DisplayName("ترم")]
//        public int Term { get; set; }

//        /// <summary>
//        /// کد دانشکده
//        /// </summary>
//        [DisplayName("دانشکده")]
//        public int FacultyId { get; set; }

//        /// <summary>
//        /// مشخصات دانشکده
//        /// </summary>
//        [ForeignKey(nameof(FacultyId))]
//        public virtual Faculty Faculty { get; set; }

//        /// <summary>
//        /// تعداد روز امتحان
//        /// </summary>
//        [DisplayName("تعداد روز امتحان")]
//        public short DaysCount { get; set; }
        
//        /// <summary>
//        /// سانس امتحانی
//        /// </summary>
//        [DisplayName("سانس امتحان")]
//        public ExamSanceType? ExamSanceType { get; set; }

//        /// <summary>
//        /// تاریخ شروع برگزاری امتحان
//        /// </summary>
//        [DisplayName("تاریخ شروع برگزاری امتحان")]
//        public DateTime ExamDate { get; set; }

//        /// <summary>
//        /// ساعت شروع
//        /// </summary>
//        [DisplayName("ساعت شروع")]
//        public TimeSpan StartTime { get; set; }

//        /// <summary>
//        /// ساعت پایان
//        /// </summary>
//        [DisplayName("ساعت پایان")]
//        public TimeSpan EndTime { get; set; }

//        /// <summary>
//        /// ظرفیت سانس
//        /// </summary>
//        [DisplayName("ظرفیت سانس")]
//        public int? Capacity { get; set; }

//        /// <summary>
//        /// اولویت نمایش
//        /// </summary>
//        [DisplayName("اولویت نمایش")]
//        public int Periority { get; set; }

//        /// <summary>
//        /// توضیحات
//        /// </summary>
//        [MaxLength(200), DisplayName("توضیحات")]
//        public string Comment { get; set; }
//    }
//}
