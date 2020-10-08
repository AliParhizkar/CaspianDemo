using System;
using Caspian.Common;
using Model.BaseInfo;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class CityService : SimpleService<City>, ISimpleService<City>
    {
        ProvinceService service;
        public CityService(IServiceProvider provider)
            : base(provider)
        {

            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان شهر باید مشخص باشد");
            RuleFor(t => t.ProvinceId).Custom(t => t.ProvinceId == null, "لطفا استان را مشخص نمایید");
            //CheckUniqueFor(t => t.Title, t => t.ProvinceId, "شهری با این عنوان در سیستم ثبت شده است");
        }
    }
}
