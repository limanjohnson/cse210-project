using System;

using ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {

        var reference1 = new Reference("John", 3, 16);
        var scripture1 = new Scripture(reference1,
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");

        var reference2 = new Reference("Moroni", 10, 4, 5);
        var scripture2 = new Scripture(reference2,
            "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost.\n\n And by the power of the Holy Ghost ye may know the truth of all things.");

        var reference3 = new Reference("Mosiah", 3, 19);
        var scripture3 = new Scripture(reference3,
            "For the natural man is an enemy to God, and has been from the fall of Adam, and will be, forever and ever, unless he yields to the enticings of the Holy Spirit, and putteth off the natural man and becometh a saint through the atonement of Christ the Lord, and becometh as a child, submissive, meek, humble, patient, full of love, willing to submit to all things which the Lord seeth fit to inflict upon him, even as a child doth submit to his father.");
        
        var favoriteScriptures = new List<Scripture> { scripture1, scripture2, scripture3 };
        
        Scripture selectedScripture = null;
        
        while (true)
        {
            Console.Clear();

            if (selectedScripture != null)
            {
                Console.WriteLine("\n=== Scripture Memorization ===\n");
                Console.WriteLine(selectedScripture.GetDisplayText());

                if (selectedScripture.IsCompletelyHidden())
                {
                    Console.WriteLine("You have memorized all of the words in this scripture.");
                    Console.WriteLine("\nType 'menu' to return to the main menu.\n");
                    while (Console.ReadLine()?.ToLower() != "menu") ;
                    selectedScripture.Reset();
                    selectedScripture = null;
                    continue;
                }

                Console.WriteLine("\nPress Enter to hide more words or type 'menu' to return to the main menu.");
                var input = Console.ReadLine();

                if (input == "menu")
                {
                    selectedScripture = null;
                }

                if (input == "quit")
                {
                    Console.WriteLine("Bye!");
                    break;
                }
                
                selectedScripture.HideRandomWords(5);
            }
            else
            {
                Console.WriteLine("\n=== Scripture Memorizer Menu ===\n");
                for (int i = 0; i < favoriteScriptures.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {favoriteScriptures[i].Reference.GetDisplayText()}");
                }
                Console.WriteLine("\nType 'quit' to exit.");

                string menuOption = Console.ReadLine()?.Trim();
                if (menuOption.ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }

                if (!int.TryParse(menuOption, out int option) || option < 1 || option > favoriteScriptures.Count)
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(1500); // Pause briefly before refreshing the menu
                    continue;
                }
             
                selectedScripture = favoriteScriptures[option - 1];
                
            }

                
        }

    }
}