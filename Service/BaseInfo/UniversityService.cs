using System;
using System.Linq;
using Model.BaseInfo;
using Caspian.Common;
using FluentValidation;
using Caspian.Common.Service;

namespace Service
{
    public class UniversityService : SimpleService<University>, ISimpleService<University>
    {
        public UniversityService()
        {
            RuleFor(t => t.Title).Custom(t => true, "امکان تغییر مشخصات دانشگاه وجود ندارد.");
        }
    }
}
