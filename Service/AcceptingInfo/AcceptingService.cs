using Caspian.Common;
using Model.AcceptingInfo;
using Caspian.Common.Service;

namespace Service.AcceptingInfo
{
    public class AcceptingService : SimpleService<Accepting>, ISimpleService<Accepting>
    {
        public AcceptingService()
        {
            RuleFor(t => t.Id).Custom(t => t.Id < 10, "الکی دوست دارم گیر بدم");
            RuleFor(t => t.Title).Required();
            CheckUniqueFor(t => t.Title, "پدیرشی با این عنوان در سیستم ثبت شده است");
            RuleFor(t => t.EntranceYear).Required();
            RuleFor(t => t.TuitionFactor).Required();
            RuleFor(t => t.EntranceTerm).Required();
            RuleFor(t => t.StartDate).Required();
        }
    }
}
