using System;
using System.Collections.Generic;
using Journal;

namespace MyJournal;

class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display entries");
            Console.WriteLine("3. Save entries");
            Console.WriteLine("4. Load entries");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            
            string menuOption = Console.ReadLine();

            bool isValidOption = int.TryParse(menuOption, out int option);

            if (!isValidOption)
            {
                Console.WriteLine("Sorry, you entered an invalid option. Please choose a number from the menu.");
            }

            switch (option)
            {
                case 1:
                    Journal.AddJournalEntry();
                    break;
                case 2:
                    Journal.DisplayAllEntries();
                    // Console.WriteLine("Display Entries functionality has not been implemented yet.");
                    break;
                case 3:
                    Console.WriteLine("Save Entries as a File functionality has not been implemented yet.");
                    break;
                case 4:
                    Console.WriteLine("Load Entries form a File funcitonality has not been implemented yet.");
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Ight mate, you done messed something up big time.");
                    break;
            }
        }

        
    }
    
    
}