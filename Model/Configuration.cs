//using Common;
//using System;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Model.BaseInfo
//{
//    /// <summary>
//    /// تنظیمات سیستم
//    /// </summary>
//    public class Configuration
//    {
//        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
//        public int Id { get; set; }

//        /// <summary>
//        /// روز شروع ترم اول
//        /// </summary>
//        [DisplayName("روز شروع ترم اول"), Range(1, 31)]
//        public byte? FirstTermStartDay { get; set; }

//        /// <summary>
//        /// ماه شروع ترم اول
//        /// </summary>
//        [DisplayName("ماه شروع ترم اول")]
//        public PersianMonth? FirstTermStartMonth { get; set; }

//        /// <summary>
//        /// روز شروع ترم دوم
//        /// </summary>
//        [DisplayName("روز شروع ترم دوم")]
//        public byte? SecondTermStartDay { get; set; }

//        /// <summary>
//        /// ماه شروع ترم دوم
//        /// </summary>
//        [DisplayName("ماه شروع ترم دوم")]
//        public PersianMonth? SecondTermStartMonth { get; set; }

//        /// <summary>
//        /// روز شروع ترم تابستانی
//        /// </summary>
//        [DisplayName("روز شروع ترم تابستانی")]
//        public byte? SummeryTermStartDay { get; set; }

//        /// <summary>
//        /// ماه شروع ترم تابستانی
//        /// </summary>
//        [DisplayName("ماه شروع ترم تابستانی")]
//        public PersianMonth? SummeryTermStartMonth { get; set; }

//        /// <summary>
//        /// روز شروع ترم اول
//        /// </summary>
//        [DisplayName("روز شروع ترم اول"), Range(1, 31)]
//        public byte? FirstTermEndDay { get; set; }

//        /// <summary>
//        /// ماه شروع ترم اول
//        /// </summary>
//        [DisplayName("ماه شروع ترم اول")]
//        public PersianMonth? FirstTermEndMonth { get; set; }

//        /// <summary>
//        /// روز شروع ترم دوم
//        /// </summary>
//        [DisplayName("روز شروع ترم دوم")]
//        public byte? SecondTermEndDay { get; set; }

//        /// <summary>
//        /// ماه شروع ترم دوم
//        /// </summary>
//        [DisplayName("ماه شروع ترم دوم")]
//        public PersianMonth? SecondTermEndMonth { get; set; }

//        /// <summary>
//        /// روز شروع ترم تابستانی
//        /// </summary>
//        [DisplayName("روز شروع ترم تابستانی")]
//        public byte? SummeryTermEndDay { get; set; }

//        /// <summary>
//        /// ماه شروع ترم تابستانی
//        /// </summary>
//        [DisplayName("ماه شروع ترم تابستانی")]
//        public PersianMonth? SummeryTermEndMonth { get; set; }
//    }
//}
