using Caspian.Common;
using Model.AcceptingInfo;
using Caspian.Common.Service;

namespace Service.AcceptingInfo
{
    public class AcceptingFacultyService : SimpleService<AcceptingFaculty>, ISimpleService<AcceptingFaculty>
    {
        public AcceptingFacultyService()
        {
            RuleFor(t => t.Title).Required();
            CheckUniqueFor(t => t.Title, "دانشکده ای با این کد در سیستم ثبت شده است");
            CheckUniqueFor(t => t.Code, "دانشکده ای با این عنوان در سیستم ثبت شده است");
        }
    }
}
