namespace PAYNLSDK.Services
{
    public interface ISettingsService
    {
        /// <summary>
        /// PAYNL API TOKEN
        /// </summary>
        string ApiToken { get; }
        /// <summary>
        /// PAYNL SERVICE ID
        /// </summary>
        string ServiceId { get; }

        /// <summary>
        /// Method to set the api token and service id
        /// </summary>
        /// <param name="apiToken"></param>
        /// <param name="serviceId"></param>
        void SetApiToken(string apiToken, string serviceId);
    }
}
