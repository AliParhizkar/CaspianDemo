using System;
using FluentValidation;
using System.Linq.Expressions;

namespace Caspian.Common
{
    public static class CaspianValidatorExtensions
    {
        public static IRuleBuilderInitial<TModel, TProperty> Custom<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder,
            Func<TModel, bool> func, string message)
        {
            return ruleBuilder.Custom((value, context) =>
            {
                if (func.Invoke((TModel)context.InstanceToValidate))
                    context.AddFailure(message);
            });
        }

        public static IRuleBuilderInitial<TModel, TProperty> CustomValue<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder,
            Func<TProperty, bool> func, string message)
        {
            return ruleBuilder.Custom((value, context) =>
            {
                if (func.Invoke(value))
                    context.AddFailure(message);
            });
        }


        public static IRuleBuilderInitial<TModel, TProperty> Required<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder, string message = null)
        {
            return ruleBuilder.Custom((value, context) =>
            {
                if (value == null)
                {
                    message = message ?? "لطفا " + context.DisplayName + " را مشخص نمایید";
                    context.AddFailure(message);
                }
            });
        }

        public static IRuleBuilderInitial<TModel, TProperty> Range<TModel, TProperty>(this IRuleBuilder<TModel, TProperty> ruleBuilder, TProperty min, TProperty max, string message = null) where TProperty : IComparable
        {
            return ruleBuilder.Custom((value, context) =>
            {
                if (value != null && (value.CompareTo(min) == -1 || value.CompareTo(max) == 1))
                {
                    message = message ?? "مقدار " + context.DisplayName + " باید بین {0} و {1} باشد";
                    context.AddFailure(string.Format(message, min, max));
                }
            });
        }

        public static IRuleBuilderInitial<TModel, string> MobileNumber<TModel>(this IRuleBuilder<TModel, string> ruleBuilder)
        {
            return ruleBuilder.Custom((mobileNumber, context) =>
            {
                if (mobileNumber != null)
                {
                    var strMobileNumber = mobileNumber.ToString();
                    if (strMobileNumber.Length != 11 || !strMobileNumber.StartsWith("09"))
                        context.AddFailure("شماره همراه باید 11 رقم باشد و با 09 شروع شود");
                }
            });
        }

        public static IRuleBuilderInitial<TModel, string> TelNumber<TModel>(this IRuleBuilder<TModel, string> ruleBuilder)
        {
            return ruleBuilder.Custom((telNumber, context) =>
            {
                if (telNumber != null)
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
                if (telNumber != null)
                {
                    var strTelNumber = telNumber.ToString();
                    if (strTelNumber.Length > 8 || strTelNumber.StartsWith("0"))
                        context.AddFailure("شماره تلفن باید 8 رقم باشد و با صفر شروع نشود.");
                }
            });
        }

        public static IRuleBuilderInitial<TModel, string> CallNumber<TModel>(this IRuleBuilder<TModel, string> ruleBuilder)
        {
            return ruleBuilder.Custom((callNumber, context) =>
            {
                if (callNumber != null)
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
