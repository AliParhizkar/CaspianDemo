using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// مشخصات اعضاء خانواده
    /// </summary>
    public enum FamilyMemberType: byte
    {
        /// <summary>
        /// پدر
        /// </summary>
        [EnumField("پدر")]
        Father = 1,

        /// <summary>
        /// مادر
        /// </summary>
        [EnumField("مادر")]
        Mother,

        /// <summary>
        /// برادر
        /// </summary>
        [EnumField("برادر")]
        Brother,

        /// <summary>
        /// خواهر
        /// </summary>
        [EnumField("خواهر")]
        Sister,

        /// <summary>
        /// همسر
        /// </summary>
        [EnumField("همسر")]
        Husband,

        /// <summary>
        /// فرزند
        /// </summary>
        [EnumField("فرزند")]
        Child
    }
}
