using Challenge1Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1Console
{
    class ProgramUI
    {
        public MenuRepo _MenuItems = new MenuRepo();
        public void Run()
        {
            SeedData();
            Menu();
        }
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Clear();
                Console.WriteLine("1. Add Menu Item\n" +
                    "2. Remove Menu Item\n" +
                    "3. View Menu Items\n" +
                    "4. Exit");
                Console.WriteLine("\nEnter a number to select an option...");
                int userInput = int.Parse(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        AddMenuItem();
                        break;
                    case 2:
                        RemoveMenuItem();
                        break;
                    case 3:
                        ViewMenu();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option");
                        Console.WriteLine("Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddMenuItem()
        {
            Console.Clear();
            Menu item = new Menu();
            Console.WriteLine("To create a new menu item, enter the following information...\n");
            Console.WriteLine("Menu Number:");
            item.Number = int.Parse(Console.ReadLine());
            if (_MenuItems.GetItemByNumber(item.Number) != null)
            {
                Console.WriteLine("\nThere is already a Menu item with this number.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\nName:");
            item.Name = Console.ReadLine();
            Console.WriteLine("\nDescription:");
            item.Description = Console.ReadLine();
            Console.WriteLine("\nIngredients (seperate each ingredient by a comma):");
            string ingredientsString = Console.ReadLine();
            List<string> ingredients = ingredientsString.Split(',').ToList();
            item.Ingredients = ingredients;
            Console.WriteLine("\nPrice($):");
            item.Price = decimal.Parse(Console.ReadLine());
            _MenuItems.AddToMenu(item);
            Console.Clear();
            Console.WriteLine($"Item #{item.Number} was successfully added to the menu.");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            return;
        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            Console.WriteLine("To view a menu item to remove, enter the item number:");
            bool isRunning = true;
            while (isRunning == true)
            {
                int userInput = int.Parse(Console.ReadLine());
                Console.Clear();
                Menu item = _MenuItems.GetItemByNumber(userInput);
                if (item == null)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter an existing menu item number...");
                }
                else if (item != null)
                {
                    Console.WriteLine($"Number: {item.Number}\n" +
                    $"Name: {item.Name}\n" +
                    $"Description: {item.Description}");
                    Console.Write("Ingredients:");
                    foreach (string ingredient in item.Ingredients)
                    {
                        Console.Write($" {ingredient},");
                    }
                    Console.WriteLine($"\nPrice($): {item.Price}");
                    Console.WriteLine("\nDelete this item from the menu? (yes/no)");
                    bool isRunning2 = true;
                    while (isRunning2 == true)
                    {
                        string userInput2 = Console.ReadLine();
                        switch (userInput2)
                        {
                            case "yes":
                                _MenuItems.RemoveFromMenu(item);
                                Console.WriteLine($"\nItem #{item.Number} was successfully removed from the menu.");
                                Console.WriteLine("Press any key to return to the main menu...");
                                Console.ReadKey();
                                isRunning2 = false;
                                isRunning = false;
                                break;
                            case "no":
                                Console.WriteLine("\nNo changes were made.\n" +
                                    "Press any key to return to the main menu...");
                                Console.ReadKey();
                                isRunning2 = false;
                                isRunning = false;
                                break;
                            default:
                                Console.WriteLine("Please enter \"yes\" or \"no\"");
                                break;
                        }
                    }
                }
            }
        }
        private void ViewMenu()
        {
            Console.Clear();
            List<Menu> menuItems = _MenuItems.ViewMenu();
            foreach (Menu item in menuItems)
            {
                Console.WriteLine($"Number: {item.Number}\n" +
                        $"Name: {item.Name}\n" +
                        $"Description: {item.Description}");
                Console.Write("Ingredients:");
                foreach (string ingredient in item.Ingredients)
                {
                    Console.Write($" {ingredient},");
                }
                Console.WriteLine($"\nPrice($): {item.Price}\n");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
        private void SeedData()
        {
            List<string> item1Ingredients = new List<string>();
            item1Ingredients.Add("wheat bread");
            item1Ingredients.Add("butter");
            Menu item1 = new Menu(1, "toast", "Two slices with butter", item1Ingredients, 1.99m);
            List<string> item2Ingredients = new List<string>();
            item2Ingredients.Add("wheat bread");
            item2Ingredients.Add("butter");
            item2Ingredients.Add("ham");
            item2Ingredients.Add("cheese");
            Menu item2 = new Menu(2, "ham sandwich", "grilled with melted cheese", item2Ingredients, 7.99m);
            _MenuItems.AddToMenu(item1);
            _MenuItems.AddToMenu(item2);
        }
    }
}
