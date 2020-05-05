using System;

namespace MW.TestableDateTime
{
    public interface IDateTimeSource
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }
    }
}