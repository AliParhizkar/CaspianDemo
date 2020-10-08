using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// نسبت خانوادگی/آشنایی
    /// </summary>
    public enum FamiliarityType : byte
    {
        /// <summary>
        /// مادر
        /// </summary>
        [EnumField("مادر")]
        Mother = 1,

        /// <summary>
        /// پدر
        /// </summary>
        [EnumField("پدر")]
        Father
    }
}
