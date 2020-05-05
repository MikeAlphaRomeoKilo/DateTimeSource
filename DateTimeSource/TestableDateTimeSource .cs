using System;

namespace MW.TestableDateTime
{
    public class TestableDateTimeSource : IDateTimeSource
    {
        private readonly DateTime _dateTimeNow;
        private readonly DateTime _dateTimeNowUtc;

        public TestableDateTimeSource( DateTime source )
        {
            if( source.Kind == DateTimeKind.Utc )
            {
                _dateTimeNowUtc = source;
                _dateTimeNow = source.ToLocalTime();
            }
            else if( source.Kind == DateTimeKind.Local )
            {
                _dateTimeNowUtc = source.ToUniversalTime();
                _dateTimeNow = source;
            }
            else 
            {
                throw new ArgumentException( "The source DatTime must have a 'Kind' of 'Utc' or 'Local'", nameof(source) );
            }
        }

        public DateTime UtcNow
        {
            get
            {
                return _dateTimeNowUtc;
            }
        }

        public DateTime Now
        {
            get
            {
                return _dateTimeNow;
            }
        }
    }
}
