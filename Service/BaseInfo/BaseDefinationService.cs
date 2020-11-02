using System;
using System.Linq;
using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service
{
    public class BaseDefinationService : SimpleService<BaseDefination>, ISimpleService<BaseDefination>
    {
        public BaseDefinationService()
        {
            RuleFor(t => t.BaseDefinationType).IsInEnum();
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان باید مشخص باشد")
                .Custom(t => t.Title.HasValue() && GetAll(null).Any(u => u.Title == t.Title && u.Id != t.Id), "استانی با این عنوان در سیستم ثبت شده است");
        }
    }
}
