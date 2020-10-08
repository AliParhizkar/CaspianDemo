using System.Linq;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;
using Microsoft.Extensions.DependencyInjection;
using Model.BaseInfo;
using System;

namespace Service
{
    public class CustomerService : SimpleService<Customer>, ISimpleService<Customer>
    {
        CityService cityService;
        AreaService areaService;
        public CustomerService(IServiceProvider provider)
            : base(provider)
        {
            RuleFor(t => t.FName).Custom(t => t.PersonType == PersonType.Real && t.FName == null, "نام باید مشخص باشد");
            RuleFor(t => t.LName).Custom(t => t.PersonType == PersonType.Real && t.LName == null, "نام خانوادگی باید مشخص باشد");
            RuleFor(t => t.Age).Custom(t => t.PersonType == PersonType.Real && t.Age == null, "سن باید مشخص باشد")
                .Custom(t => t.PersonType == PersonType.Real && (t.Age < 18 || t.Age > 50), "فقط افراد بین 18-50 سال مجاز به ثبت نام هستند");
            RuleFor(t => t.Gender).Custom(t => t.PersonType == PersonType.Real && t.Gender == null, "جنسیت باید مشخص باشد");
            RuleFor(t => t.MobileNumber).Custom(t => t.MobileNumber == null, "شماره همراه باید مشخص باشد")
                .Custom(t => t.MobileNumber != null && (t.MobileNumber.Length != 11 || !t.MobileNumber.StartsWith("09")), "همراه باید 11 رقم باشد و با 09 شروع شود")
                .Custom(t => GetAll(null).Any(u => u.MobileNumber == t.MobileNumber), "مشتری با این شماره همراه ذخیره شده است.");
            ///حقوقی
            RuleFor(t => t.CompanyName).Custom(t => t.PersonType == PersonType.Legal && t.CompanyName == null, "عنوان شرکت باید مشخص باشد");
            RuleFor(t => t.TellNumber).Custom(t => t.PersonType == PersonType.Legal && t.TellNumber == null, "شماره تلفن شرکت باید مشخص باشد")
                .Custom(t => t.TellNumber != null && !t.TellNumber.StartsWith("0"), "لطفا تلفن را به همراه کد وارد نمایید")
                .Custom(t => t.TellNumber != null && t.TellNumber.Length < 7, "شماره تلفن حداقل باید 7 رقم باشد")
                .Custom(t => t.TellNumber != null && GetAll(null).Any(u => u.Id != t.Id && u.TellNumber == t.TellNumber), "مشتری با این شماره تلفن در سیستم ثبت شده است");
            RuleFor(t => t.BuildYear).Custom(t => t.PersonType == PersonType.Legal && (t.BuildYear == null || t.BuildYear < 1300 || t.BuildYear > 1399),
                "سال تاسیس باید مشخص و بین 1300 تا 1400 باشد");
            ///کلی
            RuleFor(x => x.MobileNumber).Custom(t => t.MobileNumber.HasValue() && GetAll(null).Any(u => u.MobileNumber == t.MobileNumber &&
                u.Id != t.Id), "مشتری با این شماره موبایل در سیستم ثبت شده است");
            RuleFor(x => x.CityId).Custom(t => t.CityId == 0, "شهر محل زندگی(ثبت) باید مشخص باشد.")
                .Custom(t => t.CityId != 0 && !cityService.GetAll(null).Any(u => u.Id == t.CityId), "شهری با این کد در سیستم ثبت نشده است.");
            RuleFor(x => x.AreaId).Custom(t => t.AreaId.HasValue && !areaService.GetAll(null).Any(u => u.Id == t.AreaId &&
                u.CityId == t.CityId), "مشخصات شهر درست وارد نشده است");
        }
    }





    public class AreaService : SimpleService<Area>, ISimpleService<Area>
    {
        CityService cityService;

        public AreaService(System.IServiceProvider provider)
            : base(provider)
        {
            RuleFor(t => t.CityId).Custom(t => t.CityId == 0, "شهر باید مشخص باشد.");
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان منطقه باید مشخص باشد.");
        }
    }
}
