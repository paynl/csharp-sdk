using Newtonsoft.Json;

namespace PayNLSdk.API.Statistics.GetManagement
{
    /// <summary>
    /// If 2 groupBy parameters are added to the request,
    /// we have a Top-level and a sublevel of data
    /// </summary>
    public class GetStatsMultiLevel : GetStatsResultBase
    {
        [JsonProperty("arrStatsData")]
        public TopLevelStatsData[] TopLevelGroup { get; set; }
    }

    public class TopLevelStatsData
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public GetStatsResultBase.StatsData[] Data { get; set; }
    }

   


}
