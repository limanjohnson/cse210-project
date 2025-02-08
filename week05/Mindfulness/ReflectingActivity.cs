using System.Collections.Generic;

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

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {}

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        ShowCountDown(5);
        DisplayQuestion();
        DisplayEndingMessage();

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

    public void DisplayPrompt()
    {
        Console.WriteLine($"Reflect on this prompt: {GetRandomPrompt()}");
    }

    public void DisplayQuestion()
    {
        Queue<string> questionQueue = ShuffledQuestions();
        int elapsed = 0;

        while (elapsed < GetDuration())
        {
            if (questionQueue.Count == 0)
            {
                questionQueue = ShuffledQuestions();
            }
            
            string question = questionQueue.Dequeue();
            Console.WriteLine(question);
            ShowSpinner(15);
            elapsed += 15;
        }

    }

    private Queue<string> ShuffledQuestions()
    {
        Random random = new Random();
        List<string> shuffledQuestionList = new List<string>(_questions);
        
        // Fisher-Yates algorithm
        for (int i = shuffledQuestionList.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            (shuffledQuestionList[i], shuffledQuestionList[j]) = (shuffledQuestionList[j], shuffledQuestionList[i]);
        }
        return new Queue<string>(shuffledQuestionList);
    }


}