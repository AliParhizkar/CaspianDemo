using Caspian.Common.Attributes;
using System.ComponentModel;

namespace Model.Enums
{
    /// <summary>
    /// سمت مراقب
    /// </summary>
    public enum ObservingPost : byte
    {
        /// <summary>
        /// مراقب
        /// </summary>
        [EnumField("مراقب")]
        Observing,

        /// <summary>
        /// رئیس جلسه
        /// </summary>
        [EnumField("رئیس جلسه")]
        Matser
    }
}
