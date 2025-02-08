namespace Mindfulness;

class ListingActivity : Activity
{
    private int _count;

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity",
        "This activity helps you reflect on the good things in your life by listing as many items as you can about a given prompt.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();
        ShowCountDown(3);
        
        List<string> userResponses = GetListFromUser();
        _count = userResponses.Count;
        
        Console.WriteLine("You have listed " + _count + " items.");
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        int promptCount = _prompts.Count;
        
        // Check if there are prompts in the list
        if (_prompts.Count == 0)
        {
            Console.WriteLine("There is an error with the prompts.");
        }
        
        // Select random prompt from _prompts list
        Random randomPrompt = new Random();
        int index = randomPrompt.Next(promptCount);
        Console.WriteLine(_prompts[index]);

    }

    public List<string> GetListFromUser()
    {
        List<string> userResponses = new List<string>();
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < GetDuration())
        {
            Console.Write("Enter a response: ");
            userResponses.Add(Console.ReadLine());
        }
        return userResponses;
    }
    

}