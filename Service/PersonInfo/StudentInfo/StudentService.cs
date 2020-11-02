using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Model.PersonInfo.StudentInfo;

namespace Service
{
    public class StudentService : SimpleService<Student>, ISimpleService<Student>
    {
        public StudentService()
        {
            RuleFor(t => t.FName).Required();
            RuleFor(t => t.Code).Required();
            RuleFor(t => t.LName).Required();
            RuleFor(t => t.Email).EmailAddress();
            RuleFor(t => t.Tel).TelNumber();
            RuleFor(t => t.Mobile).MobileNumber();
            RuleFor(t => t.EmergencyCall).CallNumber();
            RuleFor(t => t.Descript).Custom(t => t.Descript != null && t.Descript.Length > 200, 
                "طول شرح حداکثر می تواند 200 کاراکتر باشد");
            RuleFor(t => t.EntranceYear).Required().CustomValue(t => t >= 1350, "سال ورود باید بزرگتر از 1350 باشد");
            RuleFor(t => t.FinancialYear).CustomValue(t => t >= 1350, "سال مالی باید بزرگتر از 1350 باشد");
        }
    }
}
