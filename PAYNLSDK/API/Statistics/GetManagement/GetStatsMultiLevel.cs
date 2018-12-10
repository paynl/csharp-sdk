using Newtonsoft.Json;

namespace PayNLSdk.API.Statistics.GetManagement
{
    public class GetStatsMultiLevel : GetStatsResultBase
    {
        [JsonProperty("arrStatsData")]
        public TopLevelStatsData[] ToplevelGroup { get; set; }
    }

    public class TopLevelStatsData
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public GetStatsResultBase.StatsData[] Data { get; set; }
    }

   


}
