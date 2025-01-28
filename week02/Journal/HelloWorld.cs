namespace Journal;

public class HelloWorld
{
    public static void DisplayGreeting()
    {
        
        //when \n is used
        Console.WriteLine("Hello\nWorld");
        Console.Write("Hello\nWorld");

        //when \x0A is used
        Console.WriteLine("Hello\x0AWorld");

        //when Console.WriteLine() is used
        Console.WriteLine();

    }
}