# Mw DateTimeSource
## Overview
The .NET DateTime class presents certain difficulties in unit tests.  This library provides an IDateTimeSource interface, which contains two functions, Now() and UtcNow(), both of which return a DateTime object.  Two implementations of this interface are provided, DateTimeSource and TestableDateTime source.

DateTimeSource is a simple wrapper around DateTiime's Now() and UtcNow() functions.

TestableDateTimeSource is designed for use in unit tests.  It allows the test to specify the DateTime object that will be returned.

The library is written in C# and targets .NET Standard 2.0

## Exaple use of DateTimeSource
    class Program
    {
        static void Main( string[] args )
        {
            // instantiate the business object, injecting a DateTimeSource via the constructor
            Alerter alerter = new Alerter( new DateTimeSource() );

            // load some events
            alerter.AddEvent( new AlertableEvent() { When = DateTime.Now, Description = $"It is today, {DateTime.Now.DayOfWeek}" } );
            DateTime tomorrow = DateTime.Now.AddDays( 1 );
            alerter.AddEvent( new AlertableEvent() { When = tomorrow, Description = $"It is not yet tomorrow, {tomorrow.DayOfWeek}" } );

            // run the business function and print the results
            alerter.GetTodaysEvents().ForEach( x => Console.WriteLine( x.Description ) );
        }
    }


    public class AlertableEvent
    {
        public DateTime When { get; set; }
        public string Description { get; set; }
    }


    /// <summary>
    /// This is our business class that will tell us about today's events
    /// </summary>
    public class Alerter
    {
        private readonly IDateTimeSource _dateTimeSource;
        private readonly List<AlertableEvent> _events = new List<AlertableEvent>();

        public Alerter( IDateTimeSource dateTimeSource )
        {
            _dateTimeSource = dateTimeSource;
        }

        public void AddEvent( AlertableEvent eventToAdd )
        {
            _events.Add( eventToAdd );
        }

        /// <summary>
        /// provides a list of today's events
        /// </summary>
        /// <returns></returns>
        public List<AlertableEvent> GetTodaysEvents()
        {
            return _events.Where( x => x.When.Date == _dateTimeSource.Now.Date ).ToList();
        }
    }


## Example use of TestableDateTimeSource

        [TestMethod]
        public void Alerter_GetTodaysEvents_TestableDateTimeWorks()
        {
            // configure the test.  Our test will pretend that today is 4th May 2020 
            TestableDateTimeSource dateTimeSource = new TestableDateTimeSource( new DateTime( 2020, 5, 4, 0,0,0, DateTimeKind.Local ));
            // inject the TestableDateTimeSource into the business object
            Alerter alerter = new Alerter( dateTimeSource );
            // add 4 events, two of which will be on the day of interest
            alerter.AddEvent( new AlertableEvent() { When = new DateTime( 1066, 9, 28, 0, 0, 0, DateTimeKind.Local ), Description = "William lands" } );
            alerter.AddEvent( new AlertableEvent() { When = new DateTime( 1215, 6, 15, 0, 0, 0, DateTimeKind.Local ), Description = "Magna carta agreed" } );
            alerter.AddEvent( new AlertableEvent() { When = new DateTime( 2020, 5, 4, 18, 10, 0, DateTimeKind.Local ), Description = "I am writing this test" } );
            alerter.AddEvent( new AlertableEvent() { When = new DateTime( 2020, 5, 4, 19, 0, 0, DateTimeKind.Local ), Description = "I will start dinner" } );

            // call the function under test
            var events = alerter.GetTodaysEvents();

            // we expect to find 2 events for the 4th May 2020
            Assert.AreEqual( 2, events.Count );
        }
```
