using System;
using System.ComponentModel;
using System.Threading;

namespace Mindfulness;

class Activity {

    private string _name;
    private string _description;
    private int _duration;

    public Activity (string name, string description) 
    {

        _name = name;
        _description = description;

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

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting the {_name} activity...");
        Console.WriteLine(_description);
        Console.Write("Select how long you would like to complete this activity in seconds: ");

        Console.WriteLine("1. 30 seconds");
        Console.WriteLine("2. 1 minute");
        Console.WriteLine("3. 2 minutes");
        Console.WriteLine("4. 5 minutes");
        Console.WriteLine("5. Return to the main menu");
        
        string userDurationSelection = Console.ReadLine();

        bool isValidSelection = int.TryParse(userDurationSelection, out int selection);

        if (!isValidSelection)
        {
            Console.WriteLine("Sorry, you entered an invalid option. Please choose a valid choice.");
        }

        switch (selection)
        {
            case 1:
                _duration = 30;
                break;
            case 2:
                _duration = 60;
                break;
            case 3:
                _duration = 120;
                break;
            case 4:
                _duration = 300;
                break;
            case 5:
                return;
            default:
                Console.WriteLine("Sorry, you entered an invalid option. Please choose a valid choice.");
                break;
        }
        
        int durationSelection = int.Parse(userDurationSelection);
        
        _duration = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Get ready to start...");
        ShowSpinner(3);

    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("You completed the activity! Well done!");
        Thread.Sleep(3000);
        Console.WriteLine($"You completed the {_name} activity for {_duration} seconds.");
        Console.WriteLine("Returning to the main menu...");
        Thread.Sleep(2000);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int iterations = seconds * 10;
        for (int i = 0; i < iterations; i++)
        {
            Console.Write($"\r{spinner[i % spinner.Length]}");
            Thread.Sleep(100);
        }

        Console.Write("\r");
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i}");
            Thread.Sleep(1000);
        }
        Console.Write("\r");
    }




}