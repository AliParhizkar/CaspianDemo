using Caspian.Common;
using Model.AcceptingInfo;
using Caspian.Common.Service;

namespace Service.AcceptingInfo
{
    public class AcceptingStudyFieldService : SimpleService<AcceptingStudyField>, ISimpleService<AcceptingStudyField>
    {
        public AcceptingStudyFieldService()
        {
            RuleFor(t => t.Title).Required();
            CheckUniqueFor(t => t.Title, "رشته ای با این کد در سیستم ثبت شده است");
            CheckUniqueFor(t => t.Code, "رشته ای با این عنوان در سیستم ثبت شده است");
        }
    }
}
