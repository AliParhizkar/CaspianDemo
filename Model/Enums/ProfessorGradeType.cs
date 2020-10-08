using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// نوع مقطع تحصیلی
    /// </summary>
    public enum PersonGradeType: byte
    {
        /// <summary>
        /// لیسانس
        /// </summary>
        [EnumField("لیسانس")]
        Mse = 1
    }
}
