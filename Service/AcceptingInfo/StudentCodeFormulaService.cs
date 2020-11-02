using Caspian.Common;
using FluentValidation;
using Model.AcceptingInfo;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service.AcceptingInfo
{
    public class StudentCodeFormulaService : SimpleService<StudentCodeFormula>, ISimpleService<StudentCodeFormula>
    {
        public StudentCodeFormulaService()
        {
            RuleFor(t => t.Title).Custom(t => !t.Title.HasValue(), "عنوان باید مشخص باشد");
            CheckUniqueFor(t => t.Title, "فرمولی با این عنوان در سیستم ثبت شده است");
            CheckUniqueFor(t => t.Code, "فرمولی با این کد در سیستم ثبت شده است");
        }
    }
}
