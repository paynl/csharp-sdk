namespace PAYNLSDK.API
{
    /// <summary>
    /// An object containing all configuration for 
    /// </summary>
    public interface IPayNlConfiguration
    {
        /// <summary>
        /// The security token
        /// </summary>
        string ApiToken { get;  }
        /// <summary>
        /// The service Id,
        /// </summary>
        string ServiceId { get; }
    }
}