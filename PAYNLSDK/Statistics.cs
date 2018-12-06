using PayNLSdk.API.Statistics.GetManagement;
using PAYNLSDK.Net;

namespace PAYNLSDK
{
    /// <summary>
    /// This is a part of the alliance SDK
    /// </summary>
    public class Statistics 
    {
        private readonly IClient _webClient;

        /// <inheritdoc />
        public Statistics(IClient webClient)
        {
            _webClient = webClient;
        }

        /// <inheritdoc />
        public GetStatsResult GetStats(Request request)
        {
            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetStatsResult>(response);
        }
    }

    /// <summary>
    /// Alliance methods
    /// </summary>
    public interface IStatistics
    {
        GetStatsResult GetStats(Request request);
    }
}
