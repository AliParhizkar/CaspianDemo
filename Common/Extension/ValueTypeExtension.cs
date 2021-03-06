﻿using System;
using System.Linq;
using System.Reflection;
using System.Globalization;
using Caspian.Common.Extension;
using System.Collections.Generic;
using Caspian.Common.Attributes;

namespace Caspian.Common
{
    public static class ValueTypeExtension
    {
        public static string Seprate3Digit(this int value)
        {
            return string.Format("{0:#,0}", value);
        }

        public static string Seprate3Digit(this long value)
        {
            return string.Format("{0:#,0}", value);
        }

        public static string Seprate3Digit(this int? value)
        {
            if (value.HasValue)
                return string.Format("{0:#,0}", value);
            return "";
        }

        public static string ToStringValue(this int? value)
        {
            if (value.HasValue)
                return value.ToString();
            return "";
        }

        public static string Seprate3Digit(this long? value)
        {
            if (value.HasValue)
                return string.Format("{0:#,0}", value);
            return "";
        }

        public static string LongString(this TimeSpan time)
        {
            var str = "";
            if (time.Hours < 10)
                str += "0";
            str += time.Hours.ToString() + ":";
            if (time.Minutes < 10)
                str += "0";
            str += time.Minutes;
            if (time.Seconds < 10)
                str += "0";
            str += time.Seconds;
            return str;
        }

        public static string ShortString(this TimeSpan time)
        {
            var str = "";
            if (time.Hours < 10)
                str += "0";
            str += time.Hours.ToString() + ":";
            if (time.Minutes < 10)
                str += "0";
            str += time.Minutes;
            return str;
        }

        public static string Seprate3Digit(this decimal value)
        {
            return string.Format("{0:#,0}", value);
        }

        public static string Seprate3Digit(this decimal? value)
        {
            if (value.HasValue)
            {
                var str = string.Format("{0:#,0}", value);
                return str;
            }
            return "";
        }

        public static PersianDate ToPersianDate(this DateTime date)
        {
            var calendar = new PersianCalendar();
            return new PersianDate(calendar.GetYear(date), (PersianMonth)calendar.GetMonth(date), calendar.GetDayOfMonth(date), date.Hour, 
                date.Minute, date.Second);
        }

        public static string ToPersianDateString(this DateTime date)
        {
            return date.ToPersianDate().ToString();
        }

        public static int? ConvertToInt(this Enum curentEnum)
        {
            if (curentEnum == null)
                return null;
            return Convert.ToInt32(curentEnum);
        }

        public static string ToPersianDateStringDayOfWeek(this DateTime date)
        {
            var pdate = date.ToPersianDate();
            return pdate.DayOfWeek.FaText() + " " + pdate.ToString();
        }

        public static string ToPersianDateString(this DateTime? date)
        {
            if (date.HasValue)
                return date.Value.ToPersianDateString();
            return "";
        }

        public static Dictionary<TValue, string> GetEnumFields<TValue>(this Enum currentEnum)
        {
            var enumes = new Dictionary<TValue, string>();
            foreach (FieldInfo fi in currentEnum.GetType().GetFields().Where(t => !t.IsSpecialName))
            {
                EnumFieldAttribute da = (EnumFieldAttribute)Attribute.GetCustomAttribute(fi, typeof(EnumFieldAttribute));
                if (da != null)
                    enumes.Add((TValue)fi.GetValue(currentEnum), da.DisplayName);
                else
                    enumes.Add((TValue)fi.GetValue(currentEnum), fi.Name);
            }
            return enumes;
        }

        public static string CallSeprator(this string number, char chr)
        {
            if (number.HasValue() && number.Length == 11)
                return number.Substring(0, 4) + chr + number.Substring(4, 3) + chr + number.Substring(7, 4);
            return number;
        }

        public static string ToCheckBox(this bool value)
        {
            return  "<span>" + value + "</span>";
        }

        public static string FaText(this Enum field)
        {
            EnumFieldAttribute da;
            if (field == null)
                return null;
            var fi = field.GetType().GetField(field.ToString());
            if (fi == null)
                throw new Exception("هیچ فیلدی برای " + field.GetType().Name + " با مقدار " + field + " تعریف نشده است.");
            da = (EnumFieldAttribute)Attribute.GetCustomAttribute(fi, typeof(EnumFieldAttribute));
            if (da != null)
                return da.DisplayName;
            return Convert.ToString(field);
        }
    }
}
