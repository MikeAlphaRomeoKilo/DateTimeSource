using System;
using System.Collections.Generic;
using System.Linq;
using MW.TestableDateTime;

namespace DemoApp
{
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
}
