using System;
using System.Diagnostics.CodeAnalysis;

namespace PAYNLSDK.API.Validate.GetServerIps
{
    /// <summary>
    /// Response object for the <see cref="PAYNLSDK.API.Validate.GetServerIps.Request"/>.
    /// Implements the <see cref="PAYNLSDK.API.ResponseBase" />
    /// </summary>
    /// <seealso cref="PAYNLSDK.API.ResponseBase" />
    public class Response : ResponseBase
    {
        /// <summary>
        /// Gets or sets the ip addresses.
        /// </summary>
        /// <value>The ip addresses.</value>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public string[] IPAddresses { get; set; }
    }
}
