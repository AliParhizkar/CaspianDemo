using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.PersonInfo
{
    /// <summary>
    /// مشخصات لاتین فرد
    /// </summary>
    [Table("EnglishInfos", Schema = "dbo")]
    public class EnglishInfo
    {
        [Key, ForeignKey(nameof(Person))]
        public int PersonId { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// نام پدر
        /// </summary>
        [DisplayName("Father Name")]
        public string FatherName { get; set; }

        /// <summary>
        /// شماره پاسپورت
        /// </summary>
        [DisplayName("Passport No")]
        public string PassportNo { get; set; }

        [DisplayName("Sponser")]
        public string Sponser { get; set; }

        [DisplayName("Place Of Issue")]
        public string PlaceOfIssue { get; set; }

        [DisplayName("Visa Issue Date")]
        public DateTime? VisaIssueDate { get; set; }

        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Nationality")]
        public string Nationality { get; set; }

        [DisplayName("Visa Expiration Date")]
        public DateTime? VisaExpirationDate { get; set; }

        [DisplayName("Final Degree")]
        public string FinalDegree { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Comment")]
        public string Comment { get; set; }

        public virtual AcademicPerson Person { get; set; }
    }
}
