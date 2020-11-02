using System;
using FluentValidation;
using System.Linq.Expressions;

namespace Caspian.Common
{
    public interface ICaspianValidator
    {
        IServiceProvider Provider { get; set; }
    }
}
