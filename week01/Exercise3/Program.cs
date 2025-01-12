using System;

class Program
{
    static int MagicNumber;
    static int UserGuess;
    static void Main(string[] args)
    {
        string PlayAgain;
        
        do
        {
            GetMagicNumber();
            do
            {
                GetUserGuess();
                CountGuesses();
                CompareGuess();
            } while (UserGuess != MagicNumber);
            
            Console.WriteLine($"You guessed the number in {counter} guesses.");
            Console.WriteLine("Would you like to play again? (yes/no)");
            PlayAgain = Console.ReadLine();

            while (PlayAgain.ToLower() != "yes" && PlayAgain.ToLower() != "no")
            {
                Console.WriteLine("Please enter yes or no.");
                Console.WriteLine("Would you like to play again? (yes/no)");
                PlayAgain = Console.ReadLine();
            }

        } while (PlayAgain.ToLower() == "yes");



    }

    static Random random = new Random();
    static void GetMagicNumber()
    {
        MagicNumber = random.Next(1, 101);
        Console.WriteLine("A magic number has been chosen.");
        
    }

    static void GetUserGuess()
    {
        Console.Write("What is your guess? ");
        while (!int.TryParse(Console.ReadLine(), out UserGuess))
        {
            Console.WriteLine("That is not a number. Please Try Again.");
            Console.Write("What is your guess?");
        }
    }

    static void CompareGuess()
    {
        if (UserGuess == MagicNumber)
        {
            Console.WriteLine("You guessed it!");
        }
        else if (UserGuess > MagicNumber)
        {
            Console.WriteLine("Too high!");
        }
        else
        {
            Console.WriteLine("Too low!");
        }
    }

    static int counter = 0;
    static void CountGuesses()
    {
        counter++;
    }
    
    
    
}