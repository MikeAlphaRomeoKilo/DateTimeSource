using System;
using DemoApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MW.TestableDateTime;

namespace DemoAppUnitTest
{
    [TestClass]
    public class AlerterUnitTest
    {
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
    }
}
