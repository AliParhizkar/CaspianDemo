using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class ProvinceService : SimpleService<Province>, ISimpleService<Province>
    {
        public ProvinceService()
        {
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان باید مشخص باشد");
            CheckUniqueFor(t => t.Title, "استانی با این عنوان در سیستم ثبت شده است");
        }
    }
}
