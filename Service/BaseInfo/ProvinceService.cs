using System.Linq;
using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public class ProvinceService : SimpleService<Province>, ISimpleService<Province>
    {
        CityService cityService;
        public ProvinceService(System.IServiceProvider provider)
            : base(provider)
        {

            var q = provider.GetService<CityService>();
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان باید مشخص باشد")
                .Custom(t => t.Title.HasValue() && GetAll(null).Any(u => u.Title == t.Title && u.Id != t.Id), "استانی با این عنوان در سیستم ثبت شده است");
        }
    }
}
