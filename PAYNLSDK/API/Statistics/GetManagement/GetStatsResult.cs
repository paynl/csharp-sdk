using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace PayNLSdk.API.Statistics.GetManagement
{

    /// <summary>
    /// The result of the Statistics/Management call
    /// With a maximum of one group
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GetStatsResult : GetStatsResultBase
    {
        [JsonProperty("arrStatsData")]
        public StatsData[] ArrStatsData { get; set; }
    }
}

