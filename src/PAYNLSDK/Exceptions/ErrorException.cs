using PAYNLSDK.Objects;
using System;

namespace PAYNLSDK.Exceptions
{
    /// <summary>
    /// ErrorException implementation
    /// </summary>
    public class ErrorException : Exception
    {
        /// <summary>
        /// Error, if any
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Retiurn whether or not there's an Error object associated with this Exception
        /// </summary>
        public bool HasError
        {
            get
            {
                return Error != null;
            }
        }

        /// <summary>
        /// Create a new ErrorException with an Error attached
        /// </summary>
        /// <param name="error">Error object</param>
        /// <param name="innerException">Inner Exception</param>
        public ErrorException(Error error, Exception innerException)
            : base(error.Message, innerException)
        {
            this.Error = error;
        }

        /// <summary>
        /// Create a new ErrorException with an Error attached
        /// </summary>
        /// <param name="error">Error object</param>
        public ErrorException(Error error)
            : base(error.Message, null)
        {
            this.Error = error;
        }

        /// <summary>
        /// Creates an ErrorException from a string
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="innerException">inner Exception</param>
        public ErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Creates an ErrorException from a string
        /// </summary>
        /// <param name="message">error message</param>
        public ErrorException(string message)
            : base(message)
        {
        }
    }
}
