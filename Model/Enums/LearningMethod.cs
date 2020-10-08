using Caspian.Common.Attributes;

namespace Model.Enums
{
    /// <summary>
    /// شیوه ی آموزشی
    /// </summary>
    public enum LearningMethod: byte
    {
        /// <summary>
        /// ترمی
        /// </summary>
        [EnumField("ترمی")]
        Term = 1,

        /// <summary>
        /// پودمانی
        /// </summary>
        [EnumField("پودمانی")]
        Podeman,

        /// <summary>
        /// پزشکی
        /// </summary>
        [EnumField("پزشکی")]
        Medical,

        /// <summary>
        /// دوره
        /// </summary>
        [EnumField("دوره")]
        Period,

        /// <summary>
        /// آموزش محور
        /// </summary>
        [EnumField("آموزش محور")]
        LearnCenteric,

        /// <summary>
        /// آموزشی و پژوهشی
        /// </summary>
        [EnumField("آموزشی و پژوهشی")]
        LearnSearch,

        /// <summary>
        /// پژوهشی محور
        /// </summary>
        [EnumField("پژوهشی محور")]
        SearchCenteric
    }
}
