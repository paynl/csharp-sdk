using PAYNLSDK.API;

namespace PAYNLSDK.Net
{
    /// <summary>
    /// The wrapper for performing HTTP REST calls to the api
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Client version
        /// </summary>
        string ClientVersion { get; }

        /// <summary>
        /// User agent
        /// </summary>
        string UserAgent { get; }

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        string PerformRequest(RequestBase request);
    }
}
