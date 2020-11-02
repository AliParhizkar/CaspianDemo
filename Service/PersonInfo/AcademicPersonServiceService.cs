using Caspian.Common;
using Model.PersonInfo;
using FluentValidation;
using Caspian.Common.Service;

namespace Service
{
    public class AcademicPersonService : SimpleService<AcademicPerson>, ISimpleService<AcademicPerson>
    {
        public AcademicPersonService()
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
        }
    }
}
