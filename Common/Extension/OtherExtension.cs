using System;
using System.Linq.Expressions;

namespace Caspian.Common.Extension
{
    public static class OtherExtension
    {

        public static TModel Copy<TModel>(this TModel model, bool cascade = false)
        {
            var data = Activator.CreateInstance<TModel>();
            foreach(var info in typeof(TModel).GetProperties())
            {
                if (info.PropertyType.IsValueType || info.PropertyType == typeof(string))
                {
                    info.SetValue(data, info.GetValue(model));
                }
            }
            return data;
        }

        public static object GetMyValue(this object obj, MemberExpression expr, bool checkNull = true)
        {
            if (expr == null)
                return null;
            var str = expr.ToString();
            var index = str.IndexOf('.');
            str = str.Substring(index + 1);
            return obj.GetMyValue(str, checkNull);
        }

        public static object GetMyValue(this object obj, string strName, bool checkNull = true)
        {
            if (checkNull == false && obj == null)
                return null;
            object result = obj;
            var type = result.GetType();
            foreach (var str in strName.Split('.'))
            {
                var temp = type.GetProperty(str);
                result = temp.GetValue(result);
                if (result == null)
                {
                    var type1 = temp.PropertyType;
                    if (!checkNull)
                        return null;
                    else
                        if (!type1.IsNullableType() && type1 != typeof(string) && type1 != typeof(byte[]))
                            throw new CaspianException(null, 1);
                }
                type = temp.PropertyType;
            }
            return result;
        }
    }
}
