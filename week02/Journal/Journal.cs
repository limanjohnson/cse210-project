using Journal;
using System;
using System.IO;

namespace MyJournal;

public static class Journal
{
    
    private static List<JournalEntry> _entries = new List<JournalEntry>();
    private static string filePath = "C:/Users/liamj/School/CSE210/cse210-project/week02/Journal/Journal.txt";
    public static void AddJournalEntry()
    {
        string prompt = PromptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        
        string userEntry = Console.ReadLine();
        string todayDate = DateTime.Today.ToString("dddd, dd MMMM yyyy");

        JournalEntry entry = new JournalEntry(prompt, userEntry, todayDate);
        _entries.Add(entry);
        
        Console.WriteLine($"You have entered: {userEntry} on {todayDate}");
    }
    
    public static void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries to display.");
            return;
        }
        
        Console.WriteLine("\n=== Journal Entries ===");
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public static void SaveEntries()
    {
        try
        {
            using (StreamWriter journalLog = new StreamWriter(filePath ,false))
            {
                foreach (var entry in _entries)
                {
                    journalLog.WriteLine(entry);    
                }
            }
            Console.WriteLine("Your entry has been saved.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"There was an error saving your entry: {e.Message}");
        }
        
    }

    public static void LoadEntries()
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("There are no saved journal files");
                return;
            }

            _entries.Clear();
            var lines = File.ReadAllLines(filePath);
            
            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue; // Skip blank lines
                
                string date = lines[i].Trim();

                if (i + 1 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 1]))
                {
                    string prompt = lines[i + 1].Trim();

                    if (i + 2 < lines.Length && !string.IsNullOrWhiteSpace(lines[i + 2]))
                    {
                        string userEntry = lines[i + 2].Trim();
                        _entries.Add(new JournalEntry(prompt, userEntry, date));
                    }
                }
            }
            
            Console.WriteLine("Your entries have been loaded.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"There are no saved journal files: {e.Message}");
        }
    }

    public static void DefaultErrorMessage()
    {
        Console.WriteLine("There was an error. Please try again.");
    }

}