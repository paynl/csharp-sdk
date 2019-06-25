namespace PAYNLSDK.Services
{
    public class SettingsService : ISettingsService
    {
        public string ApiToken { get; private set; }
        public string ServiceId { get; private set; }

        public SettingsService(string apiToken, string serviceId)
        {
            SetApiToken(apiToken, serviceId);
        }

        public void SetApiToken(string apiToken, string serviceId)
        {
            ApiToken = apiToken;
            ServiceId = serviceId;
        }
    }
}
