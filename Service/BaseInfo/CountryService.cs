using System;
using System.Linq;
using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class CountryService : SimpleService<Country>, ISimpleService<Country>
    {
        public CountryService()
        {
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان کشور باید مشخص باشد.")
                .Custom(t => t.Title.HasValue() && GetAll(null).Any(u => u.Id != t.Id && u.Title == t.Title),
                "کشوری با این عنوان ثبت شده است");
        }
    }
}
