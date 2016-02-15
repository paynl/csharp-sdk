using PAYNLSDK.Objects;
using System;

namespace PAYNLSDK.Exceptions
{
    /// <summary>
    /// ErrorException implementation
    /// </summary>
    public class ErrorException : Exception
    {
        private Error error;
        /// <summary>
        /// Error, if any
        /// </summary>
        public Error Error
        {
            get { return error; }
        }

        /// <summary>
        /// Retiurn whether or not there's an Error object associated with this Exception
        /// </summary>
        public bool HasError
        {
            get
            {
                return (error != null);
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
            this.error = error;
        }

        /// <summary>
        /// Create a new ErrorException with an Error attached
        /// </summary>
        /// <param name="error">Error object</param>
        public ErrorException(Error error)
            : base(error.Message, null)
        {
            this.error = error;
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
