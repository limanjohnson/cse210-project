namespace Journal;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string UserEntry { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string userEntry, string date)
    {
        Prompt = prompt;
        UserEntry = userEntry;
        Date = date;
    }

    public override string ToString()
    {
        return $"\n {Date} \n {Prompt} \n {UserEntry}\n";
    }
}