using System.ComponentModel;

namespace Mindfulness;

class Activity {

    private string _name;
    private string _description;
    private int _duration;

    public Activity (string name, string description, int duration) 
    {

        _name = name;
        _description = description;
        _duration = duration;

    }

    public string GetName() 
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public string DisplayStartingMessage() 
    {
        return $"The {_name} activity has started. {GetDescription()}";

    }

    public string DisplayEndingMessage()
    {
        return $"The {_name} activity has ended. Thank you for participating!";
    }

    public string ShowSpinner()
    {
        while (true)
        {
            foreach (var c in "|/-\\")
            {
                Console.Write($"\r{c}");
                Thread.Sleep(100);
            }
        }
    }

    public int ShowCountdown()
    {
        for (int i = _duration; i > 0; i--)
        {
            Console.Write($"\r{i}");
            Thread.Sleep(1000);
        }
        return _duration;
    }




}