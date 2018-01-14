using PAYNLSDK.Objects;
using System;

namespace PAYNLSDK.Exceptions
{
    /// <summary>
    /// PayNlException implementation
    /// </summary>
    public class PayNlException : Exception
    {
        /// <summary>
        /// Error, if any
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Return whether or not there's an Error object associated with this Exception
        /// </summary>
        public bool HasError => Error != null;

        /// <summary>
        /// Create a new PayNlException with an Error attached
        /// </summary>
        /// <param name="error">Error object</param>
        /// <param name="innerException">Inner Exception</param>
        public PayNlException(Error error, Exception innerException)
            : base(error.Message, innerException)
        {
            this.Error = error;
        }

        /// <summary>
        /// Create a new PayNlException with an Error attached
        /// </summary>
        /// <param name="error">Error object</param>
        public PayNlException(Error error)
            : base(error.Message, null)
        {
            this.Error = error;
        }

        /// <summary>
        /// Creates an PayNlException from a string
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="innerException">inner Exception</param>
        public PayNlException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates an PayNlException from a string
        /// </summary>
        /// <param name="message">error message</param>
        public PayNlException(string message)
            : base(message)
        {
        }

    }
}
