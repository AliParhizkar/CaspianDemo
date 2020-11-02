using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class StudyFieldService : SimpleService<StudyField>, ISimpleService<StudyField>
    {
        public StudyFieldService()
        {
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان باید مشخص باشد");
            RuleFor(t => t.DepartmentId).Custom(t => t.DepartmentId == null, "گروه تحصیلی باید مشخص باشد");
            CheckUniqueFor(t => t.Title, "رشته ی تحصیلی با این عنوان ثبت شده است");
            CheckUniqueFor(t => t.Code, "رشته ی تحصیلی با این کد ثبت شده است");
        }
    }
}
