using System;

namespace MW.TestableDateTime
{
    public class DateTimeSource : IDateTimeSource
    {
        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
