using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Caspian.Common.Extension
{
    public static class ExpressionExtension
    {
        public static LambdaExpression CreateLambdaExpresion(this ParameterExpression param,params MemberExpression[] array)
        {
            return CreateLambdaExpresion(param, array.ToList());
        }

        public static LambdaExpression CreateLambdaExpresion(this ParameterExpression param, IList<MemberExpression> list)
        {
            var type = param.Type.CreateDynamicType(list);
            var memberExprList = new List<MemberAssignment>();
            foreach (var expr in list)
            {
                var str = expr.ToString();
                str = str.Substring(str.IndexOf('.') + 1);
                var info = type.GetProperty(str);
                var memberExpr = param.CreateMemberExpresion(str);
                memberExprList.Add(Expression.Bind(info, memberExpr));
            }
            var memberInit = Expression.MemberInit(Expression.New(type), memberExprList);
            return Expression.Lambda(memberInit, param);
        }

        /// <summary>
        /// این متد با توجه به مسیر ورودی خود یک <see cref="MemberExpression" تولید می کند/>
        /// </summary>
        public static MemberExpression CreateMemberExpresion(this ParameterExpression param, string path)
        {
            Expression expr = param;
            var type = param.Type;
            foreach (var str in path.Split('.'))
            {
                var info = type.GetProperty(str);
                if (info == null)
                    return null;
                type = info.PropertyType;
                expr = Expression.Property(expr, info);
            }
            return expr as MemberExpression;
        }

        public static MemberExpression ReplaceParameter(this ParameterExpression param, MemberExpression expr)
        {
            var path = expr.ToString();
            var index = path.IndexOf('.');
            path = path.Substring(index + 1);
            return param.CreateMemberExpresion(path);
        }

        public static LambdaExpression ReplaceParameter(this ParameterExpression param, LambdaExpression expr)
        {
            var body = param.ReplaceParameter(expr.Body as MemberExpression);
            return Expression.Lambda(body, param);
        }
    }
}
