using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

namespace Mindfulness;

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you were really proud of yourself.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of an experience where your perseverance led to success",
        "Reflect on a moment when you maintained your composure during a tough situation.",
        "Think of a time when your kindness made someone’s day better.",
        "Recall a moment when you showed courage in the face of fear.",
        "Think of a time when you turned failure into a valuable learning experience.",
        "Reflect on a moment when you positively impacted someone’s life."
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
        "How can you keep this experience in mind in the future?",
        "What small details from this experience stand out the most to you, and why?",
        "How does this memory make you feel about your ability to handle future obstacles",
        "What did you find most surprising about this experience?",
        "In what ways have you changed or grown as a result of this experience?",
        "What advice would you give to someone facing a similar situation?",
        "How did this moment influence your values or priorities in life?",
        "If this experience became a story, what would the moral of the story be?",
        "Was there a particular decision or action that you feel made a significant difference? What was it?",
        "How did this experience give you a new perspective on yourself or others?",
        "What strengths did you rely on or discover during this moment?",
        "Who played a key role in this memory, and how did they impact the outcome?",
        "If you were to relive this experience, would you do anything differently?",
        "How might this experience shape your approach to future challenges?",
        "What emotions did you feel during this moment, and why?",
        "What challenges did you face during this experience, and how did you overcome them?"
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
        if (_prompts == null || _prompts.Count == 0)
        {
            return "There are not prompts available at the moment.";
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
        Queue<string> questionQueue = ShuffleQuestions();

        if (questionQueue.Count == 0)
        {
            Console.WriteLine("There are no questions available for this activity.");
            return;
        }
        
        int elapsed = 0;

        while (elapsed < GetDuration())
        {
            if (questionQueue.Count == 0)
            {
                questionQueue = ShuffleQuestions();
            }
            
            string question = questionQueue.Dequeue();
            Console.WriteLine(question);
            ShowSpinner(15);
            elapsed += 15;
        }

    }

    private Queue<string> ShuffleQuestions()
    {

        if (_questions == null || _questions.Count == 0)
        {
            Console.WriteLine("No questions are available for this activity.");
            return new Queue<string>();
        }
        
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