using Caspian.Common.Attributes;

namespace Model.Enums
{

    /// <summary>
    /// مرحله تحصیلی
    /// </summary>
    public enum StudyStemp : byte
    {
        /// <summary>
        /// علوم پایه
        /// </summary>
        [EnumField("علوم پایه")]
        Science = 1,

        /// <summary>
        /// فیزیو
        /// </summary>
        [EnumField("فیزیو")]
        Physio,

        /// <summary>
        /// کارآموزی
        /// </summary>
        [EnumField("کارآموزی")]
        Internship,

        /// <summary>
        /// کارورزی
        /// </summary>
        [EnumField("کارورزی")]
        Novitiate
    }
}
