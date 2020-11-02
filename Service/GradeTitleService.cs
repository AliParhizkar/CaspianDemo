using System;
using Caspian.Common;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Caspian.Common.Service;
using Caspian.Common.Extension;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Service
{
    public class GradeTitleService : SimpleService<GradeTitle>, ISimpleService<GradeTitle>
    {
        private bool isFirst = true;

        public override Task<ValidationResult> ValidateAsync(ValidationContext<GradeTitle> context, CancellationToken cancellation = default)
        {
            if (isFirst)
            {
                var obj = context.InstanceToValidate;
                RuleForEach(t => t.CourseGroups).ChildRules(t =>
                {
                    ///The first grade

                    t.RuleFor(u => u.Grade1)
                        .Custom(t => t.IsFinal && t.Grade1 == null, "نمره " + obj.Title1 + " باید مشخص باشد")
                        .Custom(t => t.IsFinal && (t.Grade1 < 0 || t.Grade1 > obj.Grade1), "نمره " + obj.Title1 + " باید بین صفر و " + obj.Grade1 + " باشد.");
                    ///The Second grade
                    if (obj.Title2.HasValue())
                    {
                        t.RuleFor(u => u.Grade2)
                            .Custom(t => t.IsFinal && t.Grade2 == null, "نمره " + obj.Title2 + " باید مشخص باشد")
                            .Custom(t => t.IsFinal && (t.Grade2 < 0 || t.Grade2 > obj.Grade2), "نمره " + obj.Title2 + " باید بین صفر و " + obj.Grade2 + " باشد.");
                    }
                    else
                    {
                        t.RuleFor(u => u.Grade2).Custom(t => t.IsFinal && t.Grade2 != null, "نمره " + obj.Title2 + " باید مشخص باشد.");
                    }
                    ///The Thired grade
                    if (obj.Title3.HasValue())
                    {
                        t.RuleFor(u => u.Grade3)
                            .Custom(t => t.IsFinal && t.Grade3 == null, "نمره " + obj.Title3 + " باید مشخص باشد")
                            .Custom(t => t.IsFinal && (t.Grade3 < 0 || t.Grade3 > obj.Grade3), "نمره " + obj.Title3 + " باید بین صفر و " + obj.Grade3 + " باشد.");
                    }
                    else
                    {
                        t.RuleFor(u => u.Grade3).Custom(t => t.IsFinal && t.Grade3 != null, "نمره " + obj.Title3 + " باید مشخص باشد.");
                    }
                    ///The Forth Grade
                    if (obj.Title4.HasValue())
                    {
                        t.RuleFor(u => u.Grade4)
                            .Custom(t => t.IsFinal && t.Grade4 == null, "نمره " + obj.Title4 + " باید مشخص باشد")
                            .Custom(t => t.IsFinal && (t.Grade4 < 0 || t.Grade4 > obj.Grade4), "نمره " + obj.Title4 + " باید بین صفر و " + obj.Grade4 + " باشد.");
                    }
                    else
                    {
                        t.RuleFor(u => u.Grade4).Custom(t => t.IsFinal && t.Grade4 != null, "نمره " + obj.Title4 + " باید مشخص باشد.");
                    }
                    ///The Fifth Grade
                    if (obj.Title5.HasValue())
                    {
                        t.RuleFor(u => u.Grade5)
                            .Custom(t => t.IsFinal && t.Grade5 == null, "نمره " + obj.Title5 + " باید مشخص باشد")
                            .Custom(t => t.IsFinal && (t.Grade5 < 0 || t.Grade5 > obj.Grade5), "نمره " + obj.Title5 + " باید بین صفر و " + obj.Grade5 + " باشد.");
                    }
                    else
                    {
                        t.RuleFor(u => u.Grade5).Custom(t => t.IsFinal && t.Grade5 != null, "نمره " + obj.Title5 + " باید مشخص باشد.");
                    }
                    t.RuleFor(u => u.FinalGrade).Custom(u => u.IsFinal && u.Grade1 + u.Grade2.GetValueOrDefault() + u.Grade3.GetValueOrDefault() +
                        u.Grade4.GetValueOrDefault() + u.Grade5.GetValueOrDefault() != u.FinalGrade.GetValueOrDefault(), "نمره نهایی باید برایر مجموه نمرات قبلی باشد");

                    t.RuleFor(u => u.IsPassed).Custom(u => u.IsPassed != null && !u.IsFinal, "در صورت نهایی نبودن نمره وضعیت نمره نمی تواند مشخص باشد.")
                        .Custom(u => u.IsPassed == null && u.IsFinal, "وضعیت پاسی نمره باید مشخص باشد")
                        .Custom(u => u.IsPassed == true && u.Grade1 + u.Grade2.GetValueOrDefault() + u.Grade3.GetValueOrDefault() + u.Grade4.GetValueOrDefault() +
                            u.Grade5.GetValueOrDefault() < obj.MinPassGrade, "جمع نمرات کمتر از حدنصاب نمره برای پاس می باشد و دانشجو پاس شده است.")
                        .Custom(u => u.IsPassed == true && u.Grade1 + u.Grade2.GetValueOrDefault() + u.Grade3.GetValueOrDefault() + u.Grade4.GetValueOrDefault() +
                            u.Grade5.GetValueOrDefault() < obj.MinPassGrade, "جمع نمرات بیشتر از حدنصاب نمره برای پاس می باشد و دانشجو پاس نشده است."); ;
                });
                isFirst = false;
            }
            return base.ValidateAsync(context, cancellation);
        }
    }

    public class Course
    {
        public int Id { get; set; }


    }

    public class CourseGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Grade1 { get; set; }

        public decimal? Grade2 { get; set; }

        public decimal? Grade3 { get; set; }

        public decimal? Grade4 { get; set; }

        public decimal? Grade5 { get; set; }

        public decimal? FinalGrade { get; set; }

        public bool IsFinal { get; set; }

        public bool? IsPassed { get; set; }
    }

    public class GradeTitle
    {
        public string Title1 { get; set; }

        public decimal Grade1 { get; set; }

        public string Title2 { get; set; }

        public decimal? Grade2 { get; set; }

        public string Title3 { get; set; }

        public decimal? Grade3 { get; set; }

        public string Title4 { get; set; }

        public decimal? Grade4 { get; set; }

        public string Title5 { get; set; }

        public decimal? Grade5 { get; set; }

        public decimal MinPassGrade { get; set; }

        public virtual IList<CourseGroup> CourseGroups { get; set; }
    }
}
