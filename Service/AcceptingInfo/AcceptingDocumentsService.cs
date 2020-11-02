using System.Linq;
using Caspian.Common;
using Model.AcceptingInfo;
using Caspian.Common.Service;

namespace Service.AcceptingInfo
{
    public class AcceptingDocumentsService : SimpleService<AcceptingDocuments>, ISimpleService<AcceptingDocuments>
    {
        public AcceptingDocumentsService()
        {
            RuleFor(t => t.Title).Required();
            CheckUniqueFor(t => t.Title, "نوع سندی با این عنوان در سیستم ثبت شده است");
        }

        public override void Add(AcceptingDocuments entity)
        {
            entity.Ordering = GetAll().Max(t => (int?)t.Ordering).GetValueOrDefault() + 1;
            base.Add(entity);
        }

        public override void Update(AcceptingDocuments entity)
        {
            var old = Single(entity.Id);
            entity.Ordering = old.Ordering;
            base.Update(entity);
        }

        public void IncOrdering(AcceptingDocuments entity)
        {
            var ordering = Single(entity.Id).Ordering;
            var next = GetAll().Where(t => t.Ordering > ordering).OrderBy(t => t.Ordering).FirstOrDefault();
            entity.Ordering = next.Ordering;
            next.Ordering = ordering;
            base.Update(entity);
        }

        public void DecOrdering(AcceptingDocuments entity)
        {
            var ordering = Single(entity.Id).Ordering;
            var pre = GetAll().Where(t => t.Ordering < ordering).OrderByDescending(t => t.Ordering).FirstOrDefault();
            entity.Ordering = pre.Ordering;
            pre.Ordering = ordering;
            base.Update(entity);
        }
    }
}
