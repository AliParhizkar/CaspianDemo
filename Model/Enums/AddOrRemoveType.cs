using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// وضعیت حذف و اضافه
    /// </summary>
    public enum AddOrRemoveType: byte
    {
        /// <summary>
        /// فقط امکان حذف
        /// </summary>
        [EnumField("فقط امکان حذف درس")]
        RemoveOnly = 1,

        /// <summary>
        /// فقط امکان اخذ درس
        /// </summary>
        [EnumField("فقط امکان اخذ درس")]
        AddOnly,

        /// <summary>
        /// حذف و اخذ درس مجاز
        /// </summary>
        [EnumField("حذف و اخذ درس مجاز")]
        AddRemove
    }
}
