using Challenge2Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2Console
{
    class ProgramUI
    {
        ClaimRepo _Queue = new ClaimRepo();
        public void Run()
        {
            SeedData();
            Menu();
        }
        private void Menu()
        {
            bool isRunning = true;
            while(isRunning == true)
            {
                Console.Clear();
                Console.WriteLine("1. See all Claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                Console.WriteLine("\nEnter a menu option...");
                bool isRunning2 = true;
                while (isRunning2 == true)
                {
                    int userInput = int.Parse(Console.ReadLine());
                    switch (userInput)
                    {
                        case 1:
                            ViewQueue();
                            isRunning2 = false;
                            break;
                        case 2:
                            DealClaimQueue();
                            isRunning2 = false;
                            break;
                        case 3:
                            AddNewClaim();
                            isRunning2 = false;
                            break;
                        case 4:
                            isRunning2 = false;
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a number 1-4...");
                            break;
                    }
                }
            }
        }
        private void ViewQueue()
        {
            Console.Clear();
            Console.Write($"{"ClaimID",-10}{"ClaimType",-10}{"Description",-30}{"ClaimAmount($)",-15}{"DateOfIncident",-20}{"DateOfClaim",-20}{"IsValid",-10}\n");
            Console.WriteLine("");
            Queue<Claim> queue = _Queue.ViewQueue();
            foreach (Claim claim in queue)
            {
                Console.Write($"{claim.ClaimID,-10}{claim.ClaimType,-10}{claim.Description,-30}${claim.ClaimAmount, -14}{claim.DateOfIncident.ToShortDateString(),-20}{claim.DateOfClaim.ToShortDateString(),-20}{claim.IsValid,-10}\n");
            }
            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
        private void DealClaimQueue()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                if (_Queue.CountQueueItems() == 0)
                {
                    Console.Clear();
                    Console.WriteLine("The queue is empty.");
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    isRunning = false;
                    return;
                }
                Console.Clear();
                Claim claim = _Queue.ViewTopClaim();
                Console.WriteLine("Here are the details for the next claim to be handled:");
                Console.WriteLine($"\nClaimID: {claim.ClaimID}\n" +
                    $"\nType: {claim.ClaimType}\n" +
                    $"\nDescription: {claim.Description}\n" +
                    $"\nAmount: ${claim.ClaimAmount}\n" +
                    $"\nDateOfIncident: {claim.DateOfIncident.ToShortDateString()}\n" +
                    $"\nDateOfClaim: {claim.DateOfClaim.ToShortDateString()}\n" +
                    $"\nIsValid: {claim.IsValid}\n");
                Console.WriteLine("\nDo you want to deal with this claim now(y/n)?");
                bool isRunning2 = true;
                while (isRunning2 == true)
                {
                    string userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "y":
                            _Queue.DequeueFromQueue();
                            Console.WriteLine("This claim was successfully pulled from the top of the queue.");
                            Console.WriteLine("\nTo view the next claim, press 1\n" +
                                "To return to the main menu, press 2");
                            bool isRunning3 = true;
                            while (isRunning3 == true)
                            {
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        isRunning3 = false;
                                        isRunning2 = false;
                                        break;
                                    case "2":
                                        isRunning3 = false;
                                        isRunning2 = false;
                                        isRunning = false;
                                        break;
                                    default:
                                        Console.WriteLine("Please enter a valid response...");
                                        break;
                                }
                            }
                            break;
                        case "n":
                            isRunning2 = false;
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid response...");
                            break;
                    }
                }
            }
        }
        private void AddNewClaim()
        {
            bool isRunning = true;
            while (isRunning == true)
            {
                bool isRunning2 = true;
                while (isRunning2 == true)
                {
                    Console.Clear();
                    Claim claim = new Claim();
                    Console.WriteLine("Enter a claim id:");
                    int userInput2 = int.Parse(Console.ReadLine());
                    if (_Queue.ViewByClaimID(userInput2) != null)
                    {
                        Console.WriteLine("Claim ID already in use.\n" +
                            "Press any key to return to the main menu...");
                        Console.ReadKey();
                        return;
                    }
                    claim.ClaimID = userInput2;
                    Console.Clear();
                    Console.WriteLine("Choose the claim type:\n" +
                        "1. Car\n" +
                        "2. Home\n" +
                        "3. Theft");
                    bool isRunning3 = true;
                    while (isRunning3 == true)
                    {
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                claim.ClaimType = ClaimType.Car;
                                isRunning3 = false;
                                break;
                            case "2":
                                claim.ClaimType = ClaimType.Home;
                                isRunning3 = false;
                                break;
                            case "3":
                                claim.ClaimType = ClaimType.Theft;
                                isRunning3 = false;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid option...");
                                break;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine("Enter a claim description:");
                    claim.Description = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Amount of Damage($):");
                    claim.ClaimAmount = decimal.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Date Of Incident (formatting example: YYYY,MM,DD)");
                    claim.DateOfIncident = DateTime.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Date Of Claim (formatting example: YYYY,MM,DD)");
                    claim.DateOfClaim = DateTime.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Is the claim valid?(y/n)");
                    isRunning3 = true;
                    while (isRunning3 == true)
                    {
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "y":
                                claim.IsValid = true;
                                isRunning3 = false;
                                break;
                            case "n":
                                claim.IsValid = false;
                                isRunning3 = false;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid option...");
                                break;
                        }
                    }
                    Console.Clear();
                    Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                        $"\nClaim Type: {claim.ClaimType}\n" +
                        $"\nClaim Description: {claim.Description}\n" +
                        $"\nAmount of Damage: ${claim.ClaimAmount}\n" +
                        $"\nDate Of Incident (MM/DD/YYYY): {claim.DateOfIncident.ToShortDateString()}\n" +
                        $"\nDate Of Claim (MM/DD/YYYY): {claim.DateOfClaim.ToShortDateString()}\n" +
                        $"\nIsValid: {claim.IsValid}\n");
                    Console.WriteLine("If the data is correct, enter 1 to store claim.\n" +
                        "If the data is incorrect, enter 2 to start over.\n" +
                        "To return to the main menu without saving claim, enter 3.");
                    isRunning3 = true;
                    while (isRunning3 == true)
                    {
                        string userInput = Console.ReadLine();
                        switch (userInput)
                        {
                            case "1":
                                _Queue.AddNewClaimToQueue(claim);
                                isRunning3 = false;
                                isRunning2 = false;
                                isRunning = false;
                                break;
                            case "2":
                                isRunning3 = false;
                                isRunning2 = false;
                                break;
                            case "3":
                                isRunning3 = false;
                                isRunning2 = false;
                                isRunning = false;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid option...");
                                break;
                        }
                    }
                }
            }
        }
        private void SeedData()
        {
            _Queue.AddNewClaimToQueue(new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27), true));
            _Queue.AddNewClaimToQueue(new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, new DateTime(2018, 4, 11), new DateTime(18, 4, 12), true));
            _Queue.AddNewClaimToQueue(new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00m, new DateTime(2018, 4, 27), new DateTime(18, 6, 01), false));
        }
    }
}
