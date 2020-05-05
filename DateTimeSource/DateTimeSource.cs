using System;

namespace MW.TestableDateTime
{
    /// <summary>
    /// An implementation of IDateTimeSource that simply wraps and delegates to delegates to System.DateTime.
    /// </summary>
    public class DateTimeSource : IDateTimeSource
    {
        /// <summary>
        /// Gets a DateTime object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets a DateTime object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
