using System;
using FluentValidation;
using System.Linq.Expressions;

namespace Caspian.Common
{
    public static class CaspianValidatorExtensions
    {
        public static IRuleBuilderInitial<TModel, TProperty> Custom<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder,
            Expression<Func<TModel, bool>> expression, string message)
        {
            return ruleBuilder.Custom((value, context) =>
            {
                if (expression.Compile().Invoke((TModel)context.InstanceToValidate))
                    context.AddFailure(message);
            });
        }

        public static IRuleBuilderInitial<TModel, TProperty> MobileNumber<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder)
        {
            return ruleBuilder.Custom((mobileNumber, context) =>
            {
                if (!mobileNumber.Equals(null))
                {
                    var strMobileNumber = mobileNumber.ToString();
                    if (strMobileNumber.Length != 11 || !strMobileNumber.StartsWith("09"))
                        context.AddFailure("شماره همراه باید 11 رقم باشد و با 09 شروع شود");
                }
            });
        }

        public static IRuleBuilderInitial<TModel, TProperty> TelNumber<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder)
        {
            return ruleBuilder.Custom((telNumber, context) =>
            {
                if (!telNumber.Equals(null))
                {
                    var strTelNumber = telNumber.ToString();
                    if (strTelNumber.Length != 11)
                        context.AddFailure("شماره تلفن باید 11 رقم باشد.");
                    if (!strTelNumber.StartsWith("0") || strTelNumber.StartsWith("09"))
                        context.AddFailure("فرمت شماره تلفن نادرست است");
                }
            });
        }

        public static IRuleBuilderInitial<TModel, TProperty> ShortTelNumber<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder)
        {
            return ruleBuilder.Custom((telNumber, context) =>
            {
                if (!telNumber.Equals(null))
                {
                    var strTelNumber = telNumber.ToString();
                    if (strTelNumber.Length > 8 || strTelNumber.StartsWith("0"))
                        context.AddFailure("شماره تلفن باید 8 رقم باشد و با صفر شروع نشود.");
                }
            });
        }

        public static IRuleBuilderInitial<TModel, TProperty> CallNumber<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder)
        {
            return ruleBuilder.Custom((callNumber, context) =>
            {
                if (!callNumber.Equals(null))
                {
                    var strCallNumber = callNumber.ToString();
                    if (strCallNumber.Length != 11 || !strCallNumber.StartsWith("0"))
                        context.AddFailure("شماره تماس باید 11 رقم باشد و با صفر شروع شود.");
                }
            });
        }

        public static IRuleBuilderInitial<TModel, TProperty> Unless<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder,
            Expression<Func<TModel, bool>> expression, string message)
        {
            return ruleBuilder.Custom((value, context) =>
            {
                if (!expression.Compile().Invoke((TModel)context.InstanceToValidate))
                    context.AddFailure(message);
            });
        }


    }
}
