using System;
using Bibliotheek.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BibliotheekTests {
    [TestClass]
    public class MembershipTests {

        private const int ExpectedID = 1;
        private readonly string ExpectedValue = string.Format( Membership.CardNumberFormat, ExpectedID );

        [TestMethod]
        public void CardNumber() {

            Membership membership = new Membership {
                ID = ExpectedID,
            };

            Assert.AreEqual( ExpectedValue, membership.GetCardNumber() );
        }
    }
}
