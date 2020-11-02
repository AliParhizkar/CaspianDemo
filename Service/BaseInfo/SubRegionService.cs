using Caspian.Common;
using Model.BaseInfo;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class SubRegionService : SimpleService<SubRegion>, ISimpleService<SubRegion>
    {
        public SubRegionService()
        {

            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان مذهب باید مشخص باشد");
            RuleFor(t => t.RegionId).Custom(t => t.RegionId == null, "لطفا دین را مشخص نمایید");
            CheckUniqueFor(t => t.Title, "مذهبی با این عنوان در سیستم ثبت شده است");
        }
    }
}
