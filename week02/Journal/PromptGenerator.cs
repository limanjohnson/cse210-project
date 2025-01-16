namespace MyJournal;

public class PromptGenerator
{
    // Create list of prompts
    public static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the most difficult thing I had to do today?",
        "What was the most important thing I learned today?",
        "What was the most memorable thing I did today?",
        "What made me laugh or smile today?",
    };

    public static string GetRandomPrompt()
    {
        int promptCount = _prompts.Count;
        
        if (_prompts.Count == 0)
        {
            return "There is an error with the prompts.";
        }
        // Select random prompt
        Random randomPrompt = new Random();
        int index = randomPrompt.Next(_prompts.Count);
        return _prompts[index];
    }

    // public static string DisplayRandomPrompt()
    // {
    //     return GetRandomPrompt();
    // }
}