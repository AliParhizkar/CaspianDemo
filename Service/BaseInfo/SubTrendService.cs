using Caspian.Common;
using Model.BaseInfo;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class SubTrendService : SimpleService<SubTrend>, ISimpleService<SubTrend>
    {
        public SubTrendService()
        {

            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "زیرگرایش باید مشخص باشد");
            RuleFor(t => t.TrendId).Custom(t => t.TrendId == null, "لطفا گرایش را مشخص نمایید");
            CheckUniqueFor(t => t.Title, "زیرگرایشی با این عنوان در سیستم ثبت شده است");
        }
    }
}
