using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caspian.Common.Extension
{
    public static class TypeExtension
    {
        public static bool IsNullableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type GetUnderlyingType(this Type type)
        {
            if (IsNullableType(type))
                return Nullable.GetUnderlyingType(type);
            return type;
        }

        public static PropertyInfo GetPrimaryKey(this Type type)
        {
            var keys = type.GetProperties().Where(t => t.CustomAttributes.Any(u => u.AttributeType == typeof(KeyAttribute))).ToList();
            if (keys.Count != 1)
                throw new Exception("خطا:Type " + type.Name + " must be has a key");
            return keys.SingleOrDefault();
        }

        public static PropertyInfo GetMyProperty(this Type type, string strName)
        {
            var array = strName.Split(new char[] { '.' });
            var propertyInfo = type.GetProperty(array[0]);
            type = propertyInfo.PropertyType;
            for (int i = 1; i < array.Length; i++)
            {
                propertyInfo = type.GetProperty(array[i]);
                type = propertyInfo.PropertyType;
            }
            return propertyInfo;
        }

        public static Type CreateDynamicType(this Type mainType, IList<MemberExpression> exprList)
        {
            var properties = new List<DynamicProperty>();
            foreach (var expr in exprList)
            {
                var str = expr.ToString();
                str = str.Substring(str.IndexOf('.') + 1);
                properties.Add(new DynamicProperty(str, expr.Type));
            }
            return DynamicClassFactory.CreateType(properties);
        }

        public static bool IsEnumerableType(this Type type)
        {
            return (type.GetInterface(nameof(IEnumerable)) != null);
        }

        public static bool IsCollectionType(this Type type)
        {
            return (type.GetInterface(nameof(ICollection)) != null);
        }
    }
}
