namespace Journal;

public class Entry
{
    
    private static readonly string _date = DateTime.Now.ToString("MM/dd/yyyy");
    private static readonly string _promptText = "This is a prompt";
    private static readonly string _entryText = "This is a test entry";
    
    
    
    public static void Display()
    {
        Console.WriteLine($"{_date}\n{_promptText}:\n{_entryText}");
    }
    
}