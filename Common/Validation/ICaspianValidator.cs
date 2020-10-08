using System;
using FluentValidation;
using System.Linq.Expressions;

namespace Caspian.Common
{
    public interface ICaspianValidator<TModel>
    {
        public IRuleBuilder<TModel, TProperty> Add<TProperty>(Expression<Func<TModel, TProperty>> expression);
    }
}
