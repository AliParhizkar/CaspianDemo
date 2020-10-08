using System;
using System.Collections;
using System.Linq.Expressions;

namespace Caspian.Common.Extension
{
    public static class OtherExtension
    {
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
