using Caspian.Common;
using Model.AcceptingInfo;
using Caspian.Common.Service;

namespace Service.AcceptingInfo
{
    public class AcceptingUniversityService : SimpleService<AcceptingUniversity>, ISimpleService<AcceptingUniversity>
    {
        public AcceptingUniversityService()
        {
            RuleFor(t => t.Title).Required();
            CheckUniqueFor(t => t.Title, "دانشگاه ای با این کد در سیستم ثبت شده است");
            CheckUniqueFor(t => t.Code, "دانشگاه ای با این عنوان در سیستم ثبت شده است");
        }
    }
}
