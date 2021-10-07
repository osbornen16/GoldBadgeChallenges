using Challenge3Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3Tests
{
    [TestClass]
    public class Tests3
    {
        [TestMethod]
        public void Add_ShouldGetCorrectBool()
        {
            Badge badge = new Badge();
            BadgeRepo badgeRepo = new BadgeRepo();
            bool success = badgeRepo.CreateBadge(badge);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void Remove_ShouldGetCorrectBool()
        {
            Badge badge = new Badge();
            BadgeRepo badgeRepo = new BadgeRepo();
            badgeRepo.CreateBadge(badge);
            bool result = badgeRepo.removeBadge(badge.BadgeID);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LookUpByID_ShouldAssertTrue()
        {
            Badge badge = new Badge();
            badge.BadgeID = 123;
            List<string> list = new List<string>();
            list.Add("item1");
            list.Add("item2");
            badge.AccessibleDoors = list;
            BadgeRepo badgeRepo = new BadgeRepo();
            badgeRepo.CreateBadge(badge);
            bool result = badge.AccessibleDoors.Contains("item1");
            Assert.IsTrue(result);
        }
    }
}
