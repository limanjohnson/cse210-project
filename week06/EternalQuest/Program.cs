using System;
using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Eternal Quest!\n");
            
            goalManager.DisplayPlayerInfo();
            
            Console.WriteLine("\nSelect an option: ...");
            Console.WriteLine("1. Create a Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record an Event");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter your choice(1-6): ");
            string userMenuChoice = Console.ReadLine();

            switch (userMenuChoice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    Console.WriteLine("Debug: Option 2 selected.");
                    goalManager.ListGoalDetails();
                    break;
                case "3":
                    goalManager.SaveGoals();
                    break;
                case "4":
                    goalManager.LoadGoals();
                    break;
                case "5":
                    goalManager.RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye");
                    Thread.Sleep(1000);
                    return;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    Thread.Sleep(1500);
                    break;
            }
            
        }
    }
}