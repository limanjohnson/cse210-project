using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();
        string Name = UserName();
        int Number = UserFavoriteNumber();
        NumberSquared(Name, Number);
        
    }

    static void WelcomeMessage()
    { 
        Console.WriteLine("Welcome to the program!");
    }

    static string UserName()
    {
        Console.Write("Please enter you name: ");
        return Console.ReadLine();
    }

    static int UserFavoriteNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int UserFavoriteNumber;
        while (!int.TryParse(Console.ReadLine(), out UserFavoriteNumber))
        {
            Console.WriteLine("That is not a number. Please Try Again.");
            Console.Write("What is your favorite number?");
        }
        return UserFavoriteNumber;
    }

    static void NumberSquared(string UserName, int FavoriteNumber)
    {
        Console.WriteLine($"{UserName}, the square of your number is {FavoriteNumber * FavoriteNumber}.");
    }
    
}
