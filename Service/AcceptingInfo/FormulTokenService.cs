using Model.Enums;
using Caspian.Common;
using FluentValidation;
using Model.AcceptingInfo;
using Caspian.Common.Service;
using Caspian.Common.Extension;

namespace Service.AcceptingInfo
{
    public class FormulTokenService : SimpleService<FormulToken>, ISimpleService<FormulToken>
    {
        public FormulTokenService()
        {
            RuleFor(t => t.CodeGeneratorFieldType).Custom(t => t.CodeGeneratorFieldType == null, "نوع فیلد تولید کد آموزشی باید مشخص باشد.");
            RuleFor(t => t.ConstValue).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.ConstValue && !t.ConstValue.HasValue(),
                "لطفا مقدار ثابت را مشخص نمایید");
            RuleFor(t => t.StartValue).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.Counter && t.StartValue == null, 
                "مقدار شروع شمارنده باید مشخص باشد");
            RuleFor(t => t.IncValue).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.Counter && t.IncValue == null,
                "مقدار افزایشی شمارنده باید مشخص باشد");
            RuleFor(t => t.FirstTerm).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.EntranceTerm && t.FirstTerm == null,
                "مقدار ثابت برای ترم اول باید مشخص باشد");
            RuleFor(t => t.SecondTerm).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.EntranceTerm && t.SecondTerm == null,
                "مقدار ثابت برای ترم دوم باید مشخص باشد");
            RuleFor(t => t.MaleValue).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.Gender && t.MaleValue == null,
                "مقدار ثابت برای جنسیت-مرد باید مشخص باشد");
            RuleFor(t => t.FemaleValue).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.Gender && t.FemaleValue == null,
                "مقدار ثابت برای جنسیت-زن باید مشخص باشد");
            RuleFor(t => t.FromChar).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.NationalCode && t.FromChar == null,
                "کاراکتر شروع کد ملی باید مشخص باشد");
            RuleFor(t => t.Length).Custom(t => t.CodeGeneratorFieldType == CodeGeneratorFieldType.NationalCode && t.Length == null,
                "طول کد باید مشخص باشد");
        }

        public override void Add(FormulToken entity)
        {
            ClearData(entity);
            base.Add(entity);
        }

        private void ClearData(FormulToken entity)
        {
            var constValue = entity.ConstValue;
            entity.ConstValue = null;
            var startValue = entity.StartValue;
            var incValue = entity.IncValue;
            entity.StartValue = null;
            entity.IncValue = null;
            var firstTerm = entity.FirstTerm;
            var secondTerm = entity.SecondTerm;
            entity.FirstTerm = null;
            entity.SecondTerm = null;
            var maleValue = entity.MaleValue;
            var FemaleValue = entity.FemaleValue;
            entity.MaleValue = null;
            entity.FemaleValue = null;
            var fromChar = entity.FromChar;
            var length = entity.Length;
            switch (entity.CodeGeneratorFieldType)
            {
                case CodeGeneratorFieldType.ConstValue:
                    entity.ConstValue = constValue;
                    break;
                case CodeGeneratorFieldType.Counter:
                     entity.StartValue = startValue;
                    entity.IncValue = incValue;
                    break;
                case CodeGeneratorFieldType.EntranceTerm:
                    entity.FirstTerm = firstTerm;
                    entity.SecondTerm = secondTerm;
                    break;
                case CodeGeneratorFieldType.Gender:
                    entity.MaleValue = maleValue;
                    entity.FemaleValue = FemaleValue;
                    break;
                case CodeGeneratorFieldType.NationalCode:
                    entity.FromChar = fromChar;
                    entity.Length = length;
                    break;
            }
        }

        public override void Update(FormulToken entity)
        {
            ClearData(entity);
            base.Update(entity);
        }
    }
}
