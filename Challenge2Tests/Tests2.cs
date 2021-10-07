using Challenge2Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge2Tests
{
    [TestClass]
    public class Tests2
    {
        [TestMethod]
        public void Add_ShouldGetCorrectBool()
        {
            Claim claim = new Claim();
            ClaimRepo claimrepo = new ClaimRepo();
            bool success = claimrepo.AddNewClaimToQueue(claim);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void Count_ShouldEqualExpected()
        {
            Claim claim = new Claim();
            ClaimRepo claimrepo = new ClaimRepo();
            claimrepo.AddNewClaimToQueue(claim);
            int expectedCount = claimrepo.CountQueueItems();
            Assert.AreEqual(expectedCount, 1);
        }
        [TestMethod]
        public void LookupByID()
        {
              Claim claim = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true);
            ClaimRepo claimRepo = new ClaimRepo();
            claimRepo.AddNewClaimToQueue(claim);
            Claim expected = claimRepo.ViewByClaimID(1);
            Assert.AreEqual(expected.Description, "Car accident on 465.");
        }
    }
}
