using Challenge1Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge1Tests
{
    [TestClass]
    public class Tests1
    {
        [TestMethod]
        public void Add_ShouldGetCorrectBool()
        {
            Menu menu = new Menu();
            MenuRepo menuRepo = new MenuRepo();
            bool success = menuRepo.AddToMenu(menu);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void Remove_ShouldGetCorrectBool()
        {
            Menu menu = new Menu();
            MenuRepo menuRepo = new MenuRepo();
            menuRepo.AddToMenu(menu);
            bool success = menuRepo.RemoveFromMenu(menu);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void LookupBy_ShouldReturnEqual()
        {
            MenuRepo menuRepo = new MenuRepo();
            List<string> item1Ingredients = new List<string>();
            item1Ingredients.Add("wheat bread");
            item1Ingredients.Add("butter");
            Menu item1 = new Menu(1, "toast", "Two slices with butter", item1Ingredients, 1.99m);
            menuRepo.AddToMenu(item1);
            Menu search = menuRepo.GetItemByNumber(1);

            Assert.AreEqual("toast", search.Name);
        }
    }
}
