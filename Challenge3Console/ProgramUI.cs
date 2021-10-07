using Challenge3Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3Console
{
    public class ProgramUI
    {
        BadgeRepo _DoorAccess = new BadgeRepo();
        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.Clear();
                System.Console.WriteLine("1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit\n" +
                    "\nSelect a menu option:");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ViewBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddBadge()
        {
            Console.Clear();
            Badge badge = new Badge();
            Console.WriteLine("Enter a badge ID number:");
            badge.BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the doors that it needs access to: (seperate each door with a ','");
            badge.AccessibleDoors = Console.ReadLine().Split(',').ToList();
            _DoorAccess.CreateBadge(badge);
            Console.WriteLine($"Badge \"{badge.BadgeID}\" was successfully created.");
        }
        private void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("Enter a badge ID to edit:");
            int userInput = int.Parse(Console.ReadLine());
            Console.Clear();
            if (_DoorAccess.LookUpByID(userInput) != null)
            {
                Console.WriteLine($"{userInput} has access to the following doors:");
                List<string> doors = _DoorAccess.LookUpByID(userInput);
                foreach (string door in doors)
                {
                    Console.WriteLine(door);
                }
                Console.WriteLine("");
                Console.WriteLine("Enter one of the following options:\n" +
                    "1. Remove a door\n" +
                    "2. Add a door");
                bool isRunning = true;
                while (isRunning == true)
                {
                    string userInput2 = Console.ReadLine();
                    switch (userInput2)
                    {
                        case "1":
                            Console.WriteLine("Which door would you like to remove?");
                            string userInput3 = Console.ReadLine();
                            if (doors.Contains(userInput3))
                            {
                                doors.Remove(userInput3);
                                Badge badge = new Badge();
                                badge.BadgeID = userInput;
                                badge.AccessibleDoors = doors;
                                _DoorAccess.removeBadge(userInput);
                                _DoorAccess.CreateBadge(badge);
                            }
                            isRunning = false;
                            break;
                        case "2":
                            Console.WriteLine("Which door would you like to add?");
                            userInput3 = Console.ReadLine();
                            if (!doors.Contains(userInput3))
                            {
                                doors.Add(userInput3);
                                Badge badge = new Badge();
                                badge.BadgeID = userInput;
                                badge.AccessibleDoors = doors;
                                _DoorAccess.removeBadge(userInput);
                                _DoorAccess.CreateBadge(badge);
                            }
                            isRunning = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Badge not found.\n" +
                    "Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }
        }
        private void ViewBadges()
{
    Console.Clear();
    Console.WriteLine("List of Badges\n");
    Dictionary<int, List<string>> dictionary = _DoorAccess.ViewBadges();
    foreach (var badgeID in dictionary)
    {
        Console.WriteLine($"\nBadgeID: {badgeID.Key}");
        Console.Write("Accessible Doors:");
        List<string> list = badgeID.Value;
        foreach (string door in list)
        {
            door.Trim();
            Console.Write($" {door},");
        }
    }
    Console.WriteLine("\n");
    Console.WriteLine("Press any key to return to the main menu...");
    Console.ReadKey();
}
    }
}
