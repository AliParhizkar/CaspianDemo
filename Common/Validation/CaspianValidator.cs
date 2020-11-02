using System;
using System.Linq;
using FluentValidation;
using System.Reflection;
using System.ComponentModel;
using Caspian.Common.Service;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Caspian.Common.Extension;
using FluentValidation.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components;

namespace Caspian.Common
{
    public class CaspianValidator<TModel> : AbstractValidator<TModel>, ICaspianValidator
    {
        public CaspianValidator()
        {
            foreach (var info in typeof(TModel).GetProperties())
            {
                var type = info.PropertyType;
                if (type.IsEnum)
                    RuleForEnum(info);
                var attr = info.GetCustomAttribute<ForeignKeyAttribute>();
                if (attr != null)
                {
                    var infoId = typeof(TModel).GetProperty(attr.Name);
                    RuleForForeignKey(info, infoId);
                }
            }
            RuleSet("remove", () =>
            {
                var pkey = typeof(TModel).GetPrimaryKey();
                var param = Expression.Parameter(typeof(TModel), "t");
                Expression expr = Expression.Property(param, pkey);
                expr = Expression.Convert(expr, typeof(object));
                expr = Expression.Lambda(expr, param);
                CheckOnDelete(expr as Expression<Func<TModel, object>>);
            });
        }

        public IServiceProvider Provider { get; set; }

        public MyContext Context { get; set; }

        private void CheckOnDelete(Expression<Func<TModel, object>> expression)
        {
            var rule = PropertyRule.Create(expression);
            AddRule(rule);
            var ruleBuilder = new RuleBuilder<TModel, object>(rule, this);
            ruleBuilder.Custom((value, context) =>
            {
                foreach (var info in typeof(TModel).GetProperties())
                {
                    if (info.PropertyType.IsEnumerableType() && info.PropertyType != typeof(string))
                    {
                        var attr = info.GetCustomAttribute<CheckOnDeleteAttribute>();
                        if (attr == null)
                            throw new CaspianException("خطا: On type " + info.DeclaringType.Name + " property " + info.Name + " must has CheckOnDelete Attribute", 5);
                        var type = info.PropertyType.GetGenericArguments()[0];
                        var serviceType = typeof(ISimpleService<>).MakeGenericType(type);
                        var service = Provider.GetService(serviceType);
                        
                        IQueryable query = serviceType.GetMethod("GetAll").Invoke(service, new object[] { null }) as IQueryable;
                        var name = type.GetProperties().First(t => t.PropertyType == typeof(TModel)).GetCustomAttribute<ForeignKeyAttribute>().Name;
                        var fkIdInfo = type.GetProperties().Single(t => t.Name == name);
                        var param = Expression.Parameter(type, "t");
                        Expression expr = Expression.Property(param, fkIdInfo);
                        if (fkIdInfo.PropertyType.IsNullableType())
                            expr = Expression.Property(expr, "Value");
                        expr = Expression.Equal(expr, Expression.Constant(value));
                        var lamda = Expression.Lambda(expr, param);
                        if (query.Any(lamda))
                        {
                            context.AddFailure(attr.ErrorMessage);
                            break;
                        }
                    }
                }
            });

        }

        protected void CheckUniqueFor(Expression<Func<TModel, object>> expr, string message)
        {
            CheckUniqueFor(expr, null, null, null, message);
        }

        protected void CheckUniqueFor(Expression<Func<TModel, object>> expr, Expression<Func<TModel, object>> expr1, string message)
        {
            CheckUniqueFor(expr, expr1, null, null, message);
        }

        protected void CheckUniqueFor(Expression<Func<TModel, object>> expr, Expression<Func<TModel, object>> expr1, 
            Expression<Func<TModel, object>> expr2, string message)
        {
            CheckUniqueFor(expr, expr1, expr2, null, message);
        }

        protected void CheckUniqueFor(Expression<Func<TModel, object>> expr, Expression<Func<TModel, object>> expr1,
            Expression<Func<TModel, object>> expr2, Expression<Func<TModel, object>> expr3, string message)
        {
            var rule = PropertyRule.Create(expr);
            AddRule(rule);
            var ruleBuilder = new RuleBuilder<TModel, object>(rule, this);
            ruleBuilder.Custom((value, context) =>
            {
                var param = Expression.Parameter(typeof(TModel), "t");
                Expression mainExpr = AddToExoresion(context.InstanceToValidate, null, expr, param);
                mainExpr = AddToExoresion(context.InstanceToValidate, mainExpr, expr1, param);
                mainExpr = AddToExoresion(context.InstanceToValidate, mainExpr, expr2, param);
                mainExpr = AddToExoresion(context.InstanceToValidate, mainExpr, expr3, param);
                var pKey = typeof(TModel).GetPrimaryKey();
                var id = pKey.GetValue(context.InstanceToValidate);
                if (!id.Equals(0))
                {
                    Expression idExpr = Expression.Property(param, pKey);
                    idExpr = Expression.NotEqual(idExpr, Expression.Constant(id));
                    if (mainExpr != null)
                        mainExpr = Expression.And(mainExpr, idExpr);
                }
                if (mainExpr != null)
                {
                    var lambda = Expression.Lambda(mainExpr, param);
                    var service = Provider.GetService<ISimpleService<TModel>>();
                    service.Context = Context;
                    var result = service.GetAll(default(TModel)).Any(lambda);
                    if (result)
                        context.AddFailure(message);
                }
            });
        }

        private Expression AddToExoresion(object obj, Expression mainExpression, LambdaExpression expression, ParameterExpression param)
        {
            if (expression != null)
            {
                var expr = expression.Body;
                if (expr.NodeType == ExpressionType.Convert)
                    expr = (expr as UnaryExpression).Operand;
                var value = obj.GetMyValue(expr as MemberExpression, false);
                if (value != null)
                {
                    var memberExpr = expr as MemberExpression;
                    Expression tempExpr = param.ReplaceParameter(memberExpr);
                    if (memberExpr.Type.IsNullableType())
                        tempExpr = Expression.Property(tempExpr, "Value");
                    tempExpr = Expression.Equal(tempExpr, Expression.Constant(value));
                    if (mainExpression == null)
                        return tempExpr;
                    return Expression.And(tempExpr, mainExpression);
                }
            }
            return mainExpression;
        }

        private IRuleBuilderInitial<TModel, object> RuleForForeignKey(PropertyInfo info, PropertyInfo infoId)
        {
            var param = Expression.Parameter(typeof(TModel), "t");
            Expression expr = Expression.Property(param, infoId);
            expr = Expression.Convert(expr, typeof(object));
            expr = Expression.Lambda(expr, param);
            var rule = PropertyRule.Create(expr as Expression<Func<TModel, object>>);
            AddRule(rule);
            var ruleBuilder = new RuleBuilder<TModel, object>(rule, this);
            ruleBuilder.Custom((value, context) =>
            {
                if (value != null)
                {
                    var displayAttr = infoId.GetCustomAttribute<DisplayNameAttribute>() ?? info.GetCustomAttribute<DisplayNameAttribute>();
                    var message = "";
                    if (value.Equals(0))
                    {
                        message = "لطفا " + (displayAttr?.DisplayName ?? infoId.Name) + " را مشخص نمایید";
                        context.AddFailure(message);
                    }
                    else
                    {
                        message = (displayAttr?.DisplayName ?? infoId.Name) + "ی با کد " + value + " وجود ندارد.";
                        var type = typeof(ISimpleService<>).MakeGenericType(info.PropertyType);
                        var service = Provider.GetService(type) as IEntity;
                        if (service == null)
                            throw new Exception("خطا: Service of type " + type + " not implimented");
                        service.Context = Context;
                        var entity = type.GetMethod("SingleOrDefault").Invoke(service, new Object[] { value });
                        if (entity == null)
                            context.AddFailure(message);
                    }
                }
            });
            return ruleBuilder;
        }

        private IRuleBuilderInitial<TModel, object> RuleForEnum(PropertyInfo info)
        {
            var param = Expression.Parameter(typeof(TModel), "t");
            Expression expr = Expression.Property(param, info);
            expr = Expression.Convert(expr, typeof(object));
            expr = Expression.Lambda(expr, param);
            var rule = PropertyRule.Create(expr as Expression<Func<TModel, object>>);
            AddRule(rule);
            var ruleBuilder = new RuleBuilder<TModel, object>(rule, this);
            ruleBuilder.Custom((value, context) =>
            {
                if (value != null && !Enum.IsDefined(info.PropertyType, value))
                {
                    var message = "خطا: In type " + info.PropertyType.Name + " value " + value + " is invalid";
                    context.AddFailure(message);
                }
            });
            return ruleBuilder;
        }
    }
}
