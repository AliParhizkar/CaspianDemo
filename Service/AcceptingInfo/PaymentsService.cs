using System.Linq;
using Caspian.Common;
using Model.AcceptingInfo;
using Caspian.Common.Service;

namespace Service.AcceptingInfo
{
    public class PaymentsService : SimpleService<Payments>, ISimpleService<Payments>
    {
        public PaymentsService()
        {
            RuleFor(t => t.Title).Required();
            RuleFor(t => t.PaymentIdentifire).Required();
            CheckUniqueFor(t => t.Title, "پرداختی با این عنوان در سیستم ثبت شده است");
            CheckUniqueFor(t => t.PaymentIdentifire, "پرداختی با این شناسه در سیستم ثبت شده است");
            RuleFor(t => t.PaymentValue).Custom(t => t.PaymentValue <= 0, "مبلغ پرداخت باید بزرگتر از صفر باشد.");
        }

        public override void Add(Payments entity)
        {
            entity.Ordering = GetAll(null).Max(t => (int?)t.Ordering).GetValueOrDefault() + 1;
            base.Add(entity);
        }

        public override void Update(Payments entity)
        {
            entity.Ordering = Single(entity.Id).Ordering;
            base.Update(entity);
        }

        public void IncOrdering(Payments entity)
        {
            var ordering = Single(entity.Id).Ordering;
            var next = GetAll().Where(t => t.Ordering > ordering).OrderBy(t => t.Ordering).FirstOrDefault();
            entity.Ordering = next.Ordering ;
            next.Ordering = ordering;
            base.Update(entity);
        }

        public void DecOrdering(Payments entity)
        {
            var ordering = Single(entity.Id).Ordering;
            var pre = GetAll().Where(t => t.Ordering < ordering).OrderByDescending(t => t.Ordering).FirstOrDefault();
            entity.Ordering = pre.Ordering;
            pre.Ordering = ordering;
            base.Update(entity);
        }
    }
}
