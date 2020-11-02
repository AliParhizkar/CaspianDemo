using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class RegionService : SimpleService<Region>, ISimpleService<Region>
    {
        public RegionService()
        {
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان باید مشخص باشد");
            CheckUniqueFor(t => t.Title, "دینی با این عنوان ثبت شده است");
        }
    }
}
