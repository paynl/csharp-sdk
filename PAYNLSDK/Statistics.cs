using System.Collections.Specialized;
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

        /// <summary>
        /// Get management statistics from the RestApi
        /// </summary>
        /// <param name="request"></param>
        /// <param name="groupByFieldName">The fieldname on which the grouping has to take place</param>
        /// <returns></returns>
        public GetStatsResult GetStats( Request request, string groupByFieldName = "")
        {
            if (string.IsNullOrWhiteSpace(groupByFieldName)) { groupByFieldName = "company_id"; }
            request.GroupByFieldNames.Clear();
            request.GroupByFieldNames.Add(groupByFieldName);

            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetStatsResult>(response);
        }

        /// <summary>
        /// Get management statistics from the Api using two group by fields
        /// </summary>
        /// <param name="request"></param>
        /// <param name="groupByFieldName"></param>
        /// <param name="groupByFieldName2"></param>
        /// <returns></returns>
        public GetStatsMultiLevel GetMultiLevelStats(Request request, string groupByFieldName, string groupByFieldName2 = "day")
        {
            if (string.IsNullOrWhiteSpace(groupByFieldName)) { groupByFieldName = "company_id"; }
            if (string.IsNullOrWhiteSpace(groupByFieldName2)) { groupByFieldName2 = "day"; }

            request.GroupByFieldNames.Clear();
            request.GroupByFieldNames.Add(groupByFieldName);
            request.GroupByFieldNames.Add(groupByFieldName2);

            var response = _webClient.PerformRequest(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GetStatsMultiLevel>(response);
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
