using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class DepartmentService : SimpleService<Department>, ISimpleService<Department>
    {
        public DepartmentService()
        {
            RuleFor(t => t.FacultyId).Custom(t => t.FacultyId == null, "لطفا دانشکده را مشخص نمایید.");
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان باید مشخص باشد");
            CheckUniqueFor(t => t.Title, "گروهی با این عنوان در سیستم ثبت شده است");
        }
    }
}
