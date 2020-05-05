using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MW.TestableDateTime;

namespace DateTimeSourceUnitTest
{
    [TestClass]
    public class TestableDateTimeSourceUT
    {
        [TestMethod]
        public void TestableDateTimeSource_UtcNow_IsCorect()
        {
            DateTime dtUtc = new DateTime( 2020, 4, 11, 10, 30, 45, DateTimeKind.Utc );

            TestableDateTimeSource src = new TestableDateTimeSource( dtUtc );

            Assert.AreEqual( dtUtc, src.UtcNow );
        }

        [TestMethod]
        public void TestableDateTimeSource_Now_IsCorect()
        {
            DateTime dtLocal = new DateTime( 2020, 4, 11, 10, 30, 45, DateTimeKind.Local );

            TestableDateTimeSource src = new TestableDateTimeSource( dtLocal );

            Assert.AreEqual( dtLocal, src.Now );
        }

        [TestMethod]
        public void TestableDateTimeSource_Ctor_ConvertsLocalToUtc()
        {
            DateTime dtLocal = new DateTime( 2020, 4, 11, 10, 30, 45, DateTimeKind.Local );
            DateTime dtUtc = dtLocal.ToUniversalTime();

            TestableDateTimeSource src = new TestableDateTimeSource( dtLocal );

            Assert.AreEqual( dtUtc, src.UtcNow );
        }

        [TestMethod]
        public void TestableDateTimeSource_Ctor_ConvertsUtcToLocal()
        {
            DateTime dtUtc = new DateTime( 2020, 4, 11, 10, 30, 45, DateTimeKind.Utc );
            DateTime dtLocal = dtUtc.ToLocalTime();

            TestableDateTimeSource src = new TestableDateTimeSource( dtUtc );

            Assert.AreEqual( dtLocal, src.Now );
        }
    }
}
