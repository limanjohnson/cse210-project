namespace MyJournal;

public static class Journal
{
    private static List<string> _entries = new List<string>();

    public static void AddJournalEntry()
    {
        PromptGenerator.DisplayRandomPrompt();
        string userEntry = Console.ReadLine();
        _entries.Add(userEntry);
        DateTime inputDateTime = DateTime.Today;
        string todayDate = DateTime.Today.ToString("dddd, dd MMMM yyyy");

        Console.WriteLine($"You have entered: {userEntry} on {todayDate}");
    }

    public static void DisplayAllEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }
    
    
}