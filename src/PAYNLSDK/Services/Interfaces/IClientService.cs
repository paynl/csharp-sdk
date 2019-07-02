using System.Threading.Tasks;
using PAYNLSDK.API;

namespace PAYNLSDK.Services
{
    public interface IClientService
    {
        /// <summary>
        /// API VERSION
        /// </summary>
        string ApiVersion { get; }

        /// <summary>
        /// Performs an actual request
        /// </summary>
        /// <param name="request">Specific request implementation to perform</param>
        /// <returns>raw response string</returns>
        Task<string> PerformPostRequestAsync(RequestBase request);
    }
}
