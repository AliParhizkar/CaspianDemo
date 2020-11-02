using Caspian.Common;
using Model.CourseInfo;
using FluentValidation;
using Caspian.Common.Service;
using Caspian.Common.Extension;
using Model.Enums;

namespace Service.CourseInfo
{
    public class GradingService : SimpleService<Grading>, ISimpleService<Grading>
    {
        public GradingService()
        {
            RuleFor(t => t.MinPassGrade).Custom(t => t.MinPassGrade == null, "حداقل نمره پاسی باید مشخص باشد")
                .Custom(t => t.MinPassGrade.GetValueOrDefault() < 0 || t.MinPassGrade.GetValueOrDefault() > 20, "حداقل نمره پاسی باید بین صفر تا بیست باشد");
            RuleFor(t => t.MinPassGradeHostTo).Custom(t => t.MinPassGradeHostTo == null, "حداقل نمره پاسی مهمان به باید مشخص باشد")
                .Custom(t => t.MinPassGradeHostTo.GetValueOrDefault() < 0 || t.MinPassGradeHostTo.GetValueOrDefault() > 20, "حداقل نمره پاسی مهمان به باید بین صفر تا بیست باشد");
            RuleFor(t => t.MinPassGradeTransfer).Custom(t => t.MinPassGradeTransfer == null, "حداقل نمره پاسی انتقال از باید مشخص باشد")
                .Custom(t => t.MinPassGradeTransfer.GetValueOrDefault() < 0 || t.MinPassGradeTransfer.GetValueOrDefault() > 20, "حداقل نمره پاسی انتقال از باید بین صفر تا بیست باشد");
            RuleFor(t => t.MinMatchGrade).Custom(t => t.MinMatchGrade == null, "حداقل نمره پاسی تطبیق درس باید مشخص باشد")
                .Custom(t => t.MinMatchGrade.GetValueOrDefault() < 0 || t.MinMatchGrade.GetValueOrDefault() > 20, "حداقل نمره پاسی تطبیق درس باید بین صفر تا بیست باشد");
            RuleFor(t => t.GradeType).Custom(t => t.GradeType == null, "نوع نمره دهی باید مشخص باشد");
            RuleFor(t => t.Title1).Custom(t => t.Title1 == null, "عنوان اول باید مشخص باشد");
            RuleFor(t => t.Max1).Custom(t => t.Max1 == null, "درصد/حداکثر نمره اول باید مشخص باشد");
            var titleMessage = "بعلت پر بودن فیلد بعدی مقدار این فیلد باید مشخص باشد";
            RuleFor(t => t.Title2).Custom(t => t.Title3.HasValue(), titleMessage);
            RuleFor(t => t.Title3).Custom(t => t.Title4.HasValue(), titleMessage);
            RuleFor(t => t.Title4).Custom(t => t.Title5.HasValue(), titleMessage);
            var geadMessage = "در صورت مشخص بودن عنوان نمره هم باید مشخص باشد.";
            RuleFor(t => t.Max2).Custom(t => t.Title2.HasValue(), geadMessage);
            RuleFor(t => t.Max3).Custom(t => t.Title3.HasValue(), geadMessage);
            RuleFor(t => t.Max4).Custom(t => t.Title4.HasValue(), geadMessage);
            RuleFor(t => t.Max5).Custom(t => t.Title5.HasValue(), geadMessage);
            RuleFor(t => t.CourseId).Custom(t =>  
                {
                    var sum = t.Max1 + t.Max2.GetValueOrDefault() + t.Max3.GetValueOrDefault() + t.Max4.GetValueOrDefault() +
                        t.Max5.GetValueOrDefault();
                    if (t.GradeType == GradeType.Accumulative && sum != 20)
                        return false;
                    if (t.GradeType == GradeType.Percent && sum != 100)
                        return false;
                    return true;
                }, "جمع نمره در حالت تجمیعی باید برابر 20 و در حالت درصدی برابر 100 باشد.");
        }
    }
}
