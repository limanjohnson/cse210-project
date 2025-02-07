namespace Mindfulness;

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you were really proud of yourself.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };


    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(string name, string description, int duration) : base(name, description, duration)
    {
    }

    public void Run()
    {
        Console.WriteLine(DisplayStartingMessage());
        ShowCountdown();
        Console.WriteLine(DisplayEndingMessage());
    }

    public string GetRandomPrompt()
    {
        int promptCount = _prompts.Count;

        // Check if there are prompts in the list
        if (_prompts.Count == 0)
        {
            return "There is an error with the prompts.";
        }

        // Select random prompt from _prompts list
        Random randomPrompt = new Random();
        int index = randomPrompt.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        int questionCount = _questions.Count;

        // Check if there are questions in the list
        if (_questions.Count == 0)
        {
            return "There is an error with the questions.";
        }

        // Select random question from _questions list
        Random randomQuestion = new Random();
        int index = randomQuestion.Next(_questions.Count);
        return _questions[index];
    }

    public void GetPrompt()
    {
        GetRandomPrompt();
    }

    public void GetQuestion()
    {
        GetRandomQuestion();
    }


}