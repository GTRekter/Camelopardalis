using AbacusNext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AbacusNext.Test
{
    [TestClass]
    public class LongStay
    {
        [TestMethod]
        public void LongStayLessThanOneDay()
        {
            var stay = new AbacusNext.LongStay(7.50, new DateTime(2017,09,07,16,50,00),new DateTime(2017,09,07,19,15,00));
            var cost = stay.CalculateCharge();
            Assert.AreEqual(cost, 7.50);
        }
        [TestMethod]
        public void LongStayThreeDays()
        {
            var stay = new AbacusNext.LongStay(7.50, new DateTime(2017, 09, 07, 07, 50, 00), new DateTime(2017, 09, 09, 05, 20, 00));
            var cost = stay.CalculateCharge();
            Assert.AreEqual(cost, 22.50);
        }
        [TestMethod]
        public void LongStayFiftyYears()
        {
            var stay = new AbacusNext.LongStay(7.50, new DateTime(1944, 09, 07, 07, 50, 00), new DateTime(2017, 09, 09, 05, 20, 00));
            var cost = stay.CalculateCharge();
            Assert.AreEqual(cost, 199995);
        }
    }
}
