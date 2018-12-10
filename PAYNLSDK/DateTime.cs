using System;

namespace PayNLSdk
{
    /// <summary>
    /// A DateTime abstraction to make it easier to unittest DateTime.Now
    /// </summary>
    public interface IDateTime
    {
        /// <summary>
        /// Get the current dateTime
        /// </summary>
        DateTime Now { get; }
    }

    /// <inheritdoc />
    public class LocalDateTime : IDateTime
    {
        /// <inheritdoc />
        public DateTime Now => DateTime.Now;
    }

    /// <inheritdoc />
    public class UtcDateTime : IDateTime
    {
        /// <inheritdoc />
        public DateTime Now => DateTime.UtcNow;
    }
}
