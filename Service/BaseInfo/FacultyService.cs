using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;
using FluentValidation.Results;

namespace Service
{
    public class FacultyService : SimpleService<Faculty>, ISimpleService<Faculty>
    {
        public FacultyService()
        {
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان باید مشخص باشد");
            CheckUniqueFor(t => t.Title, "دانشکده ای با این عنوان در سیستم ثبت شده است.");
            CheckUniqueFor(t => t.Code, "دانشکده ای با این کد در سیستم ثبت شده است.");
        }
    }
}
