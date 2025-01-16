using System;
using System.Collections.Generic;
using Journal;
using System.Windows.Forms;

namespace MyJournal;

class Program
{
    private static void Main(string[] args)
    {

        while (true)
        {
            Console.WriteLine("\n===My Journal Menu===\n");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display entries");
            Console.WriteLine("3. Save entries");
            Console.WriteLine("4. Load entries");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter your choice (1-5): ");
            
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
                    break;
                case 3:
                    // Save Entries as a File
                    Journal.SaveEntries();
                    break;
                case 4:
                    Journal.LoadEntries();
                    break;
                case 5:
                    return;
                default:
                    Journal.DefaultErrorMessage();
                    break;
            }
        }

        
    }
    
    
}