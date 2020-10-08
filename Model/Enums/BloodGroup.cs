using Caspian.Common.Attributes;
using Caspian.Common.Extension;

namespace Model.Enums
{
    /// <summary>
    /// گروه های خونی
    /// </summary>
    public enum BloodGroup: byte
    {
        /// <summary>
        /// A+
        /// </summary>
        [EnumField("A+")]
        APos = 1,

        /// <summary>
        /// A-
        /// </summary>
        [EnumField("A-")]
        ANeg,

        /// <summary>
        /// B+
        /// </summary>
        [EnumField("B+")]
        BPos,

        /// <summary>
        /// B-
        /// </summary>
        [EnumField("B-")]
        BNeg,

        /// <summary>
        /// AB+
        /// </summary>
        [EnumField("AB+")]
        ABPos,

        /// <summary>
        /// AB-
        /// </summary>
        [EnumField("AB-")]
        ABNeg,

        /// <summary>
        /// O+
        /// </summary>
        [EnumField("O+")]
        OPos,

        /// <summary>
        /// O-
        /// </summary>
        [EnumField("O-")]
        ONeg
    }
}
