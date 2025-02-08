/*
 * Creativity:
 *
 * The reflecting activity has a method ShuffleQuestions(). This method shuffles the questions so that they are in a different order each time the activity is selected. This method is also responsible for selecting random questions and ensuring that a previously asked question is not asked a second time.
 *
 * The user is given specific amount of times they can complete an activity for. If they desire to choose a specific amount of time for the activity, that option is available as well. No activity can be completed for less than 30 seconds though. If a user trys select a time duration less than 30 seconds, they will be notified that they need to make a different selection.
 */
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
            Console.WriteLine("\n1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter your choice (1-4): ");

            string userMenuOption = Console.ReadLine();

            bool isValidOption = int.TryParse(userMenuOption, out int option);

            if (!isValidOption)
            {
                Console.WriteLine("Valid choices are 1-4. Please try again.");
            }

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
                    Thread.Sleep(1500); // Pause before displaying the menu again
                    break;
            }
        }
    }
}