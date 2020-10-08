using Caspian.Common.Attributes;

namespace Model.Enums
{

    /// <summary>
    /// وضعیت انجام خدمات نیروی انسانی
    /// </summary>
    public enum ManpowerStatusType : byte
    {
        /// <summary>
        /// نامشخص
        /// </summary>
        [EnumField("نامشخص")]
        Namoshakhas,

        /// <summary>
        /// پایان طرح
        /// </summary>
        [EnumField("پایان طرح")]
        PayanTarh,

        /// <summary>
        /// در حال گذراندن طرح
        /// </summary>
        [EnumField("در حال گذراندن طرح")]
        DarHalGozarandanTarh,

        /// <summary>
        /// معاف از طرح
        /// </summary>
        [EnumField("معاف از طرح")]
        MoaphAzTarh
    }
}
