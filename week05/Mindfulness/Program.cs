using System;
using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Threading;
using Mindfulness;
using Activity = Mindfulness.Activity;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====Calm your Mind====");
            Console.WriteLine("\nSelect an activity:");
            Console.WriteLine("\n1. Breating Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice (1-4): ");

            string userMenuOption = Console.ReadLine();

            switch (userMenuOption)
            {
                case "1":
                    BreathingActivity guidedBreathing = new BreathingActivity();
                    guidedBreathing.Run();
                    break;
                case "2":
                    ReflectingActivity guidedReflection = new ReflectingActivity();
                    guidedReflection.Run();
                    break;
                case "3":
                    ListingActivity guidedListing = new ListingActivity();
                    guidedListing.Run();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    Thread.Sleep(1500); // Pause briefly before refreshing the menu
                    break;
            }
        }
    }
}