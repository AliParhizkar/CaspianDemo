using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// نوع والدین در قید حیات
    /// </summary>
    public enum ParentAlive: byte
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
        /// هردو
        /// </summary>
        [EnumField("هردو")]
        Both,

        /// <summary>
        /// هیچکدام
        /// </summary>
        [EnumField("هیچکدام")]
        Nor
    }
}
