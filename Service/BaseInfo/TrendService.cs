using Caspian.Common;
using Model.BaseInfo;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class TrendService : SimpleService<Trend>, ISimpleService<Trend>
    {
        public TrendService()
        {
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "گرایش باید مشخص باشد");
            CheckUniqueFor(t => t.Title, "گرایشی با این عنوان در سیستم ثبت شده است");
        }
    }
}
