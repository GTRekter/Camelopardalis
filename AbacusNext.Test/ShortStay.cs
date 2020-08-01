using AbacusNext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AbacusNext.Test
{
    [TestClass]
    public class ShortStay
    {
        [TestMethod]
        public void ShortStayTwoEntireWeekendDays()
        {
            var stay = new AbacusNext.ShortStay(1.10, new DateTime(2017, 09, 09, 5, 50, 00), new DateTime(2017, 09, 010, 19, 15, 00), new TimeSpan(08, 00, 00), new TimeSpan(18, 00, 00));
            var cost = stay.CalculateCharge();
            Assert.AreEqual(Math.Round(cost, 2), 0.00);
        }
        [TestMethod]
        public void ShortStayTwoEntireWeekDays()
        {
            var stay = new AbacusNext.ShortStay(1.10, new DateTime(2017, 09, 07, 5, 50, 00), new DateTime(2017, 09, 09, 19, 15, 00), new TimeSpan(08, 00, 00), new TimeSpan(18, 00, 00));
            var cost = stay.CalculateCharge();
            Assert.AreEqual(Math.Round(cost, 2), 22.00);
        }
        [TestMethod]
        public void ShortStayTwoPartialWeekDays()
        {
            var stay = new AbacusNext.ShortStay(1.10, new DateTime(2017, 09, 07, 16, 50, 00), new DateTime(2017, 09, 09, 19, 15, 00), new TimeSpan(08, 00, 00), new TimeSpan(18, 00, 00));
            var cost = stay.CalculateCharge();
            Assert.AreEqual(Math.Round(cost,2), 12.28);
        }
        [TestMethod]
        public void ShortStayArrivalAfterLeaveDate()
        {
            var exception = Assert.ThrowsException<IndexOutOfRangeException>(() => new AbacusNext.ShortStay(1.10, new DateTime(2017, 09, 09, 16, 50, 00), new DateTime(2017, 09, 07, 19, 15, 00), new TimeSpan(08, 00, 00), new TimeSpan(18, 00, 00)));
            Assert.IsNotNull(exception);
        }
    }
}
