using Caspian.Common;
using System.ComponentModel;
using Caspian.Common.Extension;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Caspian.Common.Attributes;
using Model.BaseInfo;
using Model.AcceptingInfo;

namespace Service
{
    public class Context : MyContext
    {
        public DbSet<Province> Provinces { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<StudentCodeFormula> StudentCodeFormulas { get; set; }

        public DbSet<FormulToken> FormulTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [DisplayName("نام")]
        public string FName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [DisplayName("نام خانوادگی")]
        public string LName { get; set; }

        public PersonType? PersonType { get; set; }

        /// <summary>
        /// سن
        /// </summary>
        [DisplayName("سن")]
        public int? Age { get; set; }

        /// <summary>
        /// کد منطقه
        /// </summary>
        public int? AreaId { get; set; }

        /// <summary>
        /// مشخصات منطقه
        /// </summary>
        [ForeignKey(nameof(AreaId))]
        public virtual Area Area { get; set; }

        /// <summary>
        /// کد شهر
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// مشخصات شهر
        /// </summary>
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        [DisplayName("جنسیت")]
        public Gender? Gender { get; set; }

        /// <summary>
        /// نام شرکت
        /// </summary>
        [DisplayName("نام شرکت")]
        public string CompanyName { get; set; }

        /// <summary>
        /// سال تاسیس
        /// </summary>
        [DisplayName("سال تاسیس")]
        public int? BuildYear { get; set; }

        /// <summary>
        /// همراه
        /// </summary>
        [DisplayName("همراه")]
        public string MobileNumber { get; set; }

        /// <summary>
        /// تلفن
        /// </summary>
        [DisplayName("تلفن")]
        public string TellNumber { get; set; }

        /// <summary>
        /// لیست سفارشها
        /// </summary>
        public virtual List<Order> Orders { get; set; }
    }

    public class Order
    {
        [Key]
        public int Id { get; set; }

        public OrderType OrderType { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }
    }



    public enum Gender : byte
    {
        [EnumField("مرد")]
        Male = 1,

        [EnumField("زن")]
        Female
    }

    public enum PersonType : byte
    {
        [EnumField("حقیقی")]
        Real = 1,

        [EnumField("حقوقی")]
        Legal
    }

    [Table("RegionAreas")]
    public class Area
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }
    }

    public enum PerssiType
    {
        [EnumField("حضوری")]
        Hozoi,

        [EnumField("غیرحضوری")]
        UnHozori
    }
    public enum OrderType
    {
        [EnumField("سالن")]
        Salon,

        [EnumField("بیرون یر")]
        Packaging,

        [EnumField("تلفنی")]
        Tel,

        [EnumField("اینترنتی")]
        Internet
    }
}
