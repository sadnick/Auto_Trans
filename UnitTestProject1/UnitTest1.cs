using Auto_Trans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var TravelTime = new TravelTime();
            var d1 = DateTime.Now;
            var d2 = DateTime.Now.AddDays(10);
            var timeTravel = d2 - d1;

            var result = TravelTime.GetTravelTime(d1, d2);

            Assert.AreEqual(timeTravel, result);
        }
    }
}

