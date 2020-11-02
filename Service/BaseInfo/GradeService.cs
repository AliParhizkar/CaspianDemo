using Caspian.Common;
using Model.BaseInfo;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class GradeService : SimpleService<Grade>, ISimpleService<Grade>
    {
        public GradeService()
        {
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان مقطع تحصیلی باید مشخص باشد");
            RuleFor(t => t.PersonGradeType).Custom(t => t.PersonGradeType == null, "نوع مقطع تحصیلی باید مشخص باشد");
            CheckUniqueFor(t => t.Title, "مقطع تحصیلی با این عنوان در سیستم ثبت شده است");
        }
    }
}
