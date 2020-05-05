using System;

namespace MW.TestableDateTime
{
    /// <summary>
    /// An implementation of IDateTimeSource that for use in unit tests.
    /// </summary>
    public class TestableDateTimeSource : IDateTimeSource
    {
        private readonly DateTime _dateTimeNow;
        private readonly DateTime _dateTimeNowUtc;

        /// <summary>
        /// A constructor that accepts the DateTime value to return.  The parameter can be in either 
        /// </summary>
        /// <param name="source">The value to return.  It can be either DateTimeKind.Utc or DateTimeKind.Local</param>
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
