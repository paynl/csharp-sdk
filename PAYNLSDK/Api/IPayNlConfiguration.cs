namespace PAYNLSDK.API
{
    public interface IPayNlConfiguration
    {
        /// <summary>
        /// The security token
        /// </summary>
        string ApiToken { get; set; }
        /// <summary>
        /// The service Id,
        /// </summary>
        string ServiceId { get; set; }
    }
}