using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// نوع امتحان زبان
    /// </summary>
    public enum LanguageTestType : byte
    {
        /// <summary>
        /// Ielse
        /// </summary>
        [EnumField("Ielse")]
        Ielse = 1,

        /// <summary>
        /// Tofel
        /// </summary>
        [EnumField("Tofel")]
        Tofel,

        /// <summary>
        /// تولیمو
        /// </summary>
        [EnumField("تولیمو")]
        Tolimo,

        /// <summary>
        /// MSHE
        /// </summary>
        [EnumField("MSHE")]
        Mshe
    }
}
