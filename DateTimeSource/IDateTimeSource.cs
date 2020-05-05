using System;

namespace MW.TestableDateTime
{
    /// <summary>
    /// An interface that represents an object that implements Now() and UtcNow()
    /// </summary>
    public interface IDateTimeSource
    {
        /// <summary>
        /// Gets a DateTime object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// Gets a DateTime object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        DateTime UtcNow { get; }
    }
}