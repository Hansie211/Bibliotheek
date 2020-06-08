using System;
using Bibliotheek.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BibliotheekTests {
    [TestClass]
    public class MembershipTests {

        private const string ExpectedValue = "9999 1164 0000 0001";

        [TestMethod]
        public void CardNumber() {

            Membership membership = new Membership {
                ID = 1,
            };

            Assert.AreEqual( ExpectedValue, membership.GetCardNumber() );
        }
    }
}
