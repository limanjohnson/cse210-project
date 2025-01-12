using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    
    static void Main(string[] args)
    {
        
        List<int> UserNumbers = UserList();
        
        List<int> OrderedNumbers = UserNumbers.OrderBy(x => x).ToList();
        Console.WriteLine("The list is ordered least to greatest: ");
        foreach (var num in OrderedNumbers)
        {
            Console.WriteLine(num);
        }
        
        int? SmallestPositiveNumber = FindSmallestPositive(UserNumbers);

        if (SmallestPositiveNumber.HasValue)
        {
            Console.WriteLine($"The smallest positive number is {SmallestPositiveNumber.Value}.");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in this list.");
        }
        
        int SumTotal = UserNumbers.Sum();
        Console.WriteLine($"The sum of all the numbers is {SumTotal}.");
        Console.WriteLine($"The average of all the numbers is {ListAverage(UserNumbers)}.");
        Console.WriteLine($"The largest number is {UserNumbers.Max()}.");
        
        Console.WriteLine($"You entered {UserNumbers.Count} numbers.");
    }

    // Find smallest positive number closest to 0
    static int? FindSmallestPositive(List<int> numbers)
    {
        // Filter positive numbers and find the minimum
        var positiveNumbers = numbers.Where(x => x > 0);
        return positiveNumbers.Any() ? positiveNumbers.Min() : (int?) null;
    }
    
    static double ListAverage(List<int> UserNumbers)
    {
        return Math.Round(UserNumbers.Average(), 2);
    }
    
    // Create a List of Numbers
    static List<int> UserList()
    {
        List<int> UserNumbers = new List<int>();

        while (true)
        {
            Console.WriteLine("Enter a number to add to the list (type 'exit' to quit): ");
            string UserInput = Console.ReadLine();
            

            if (UserInput.ToLower() == "exit")
            {
                break;
            }
            
            try
            {
                int number = int.Parse(UserInput); // convert string to int
                UserNumbers.Add(number); // add number to list
                Console.WriteLine($"{number} added to the list.");
            }
            catch (FormatException) // Validate that the user is entering a number
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        //Display the list to the user
        // Console.WriteLine("Your List of numbers:");
        // foreach (var num in UserNumbers)
        // {
        //     Console.WriteLine(num);
        // }
        
        return UserNumbers;
    }
    
}