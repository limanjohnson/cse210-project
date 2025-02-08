using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
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
        ShowSpinner(3);
        Console.WriteLine(_description);
        ShowSpinner(3);

        bool validSelection = false;

        while (!validSelection)
        {
            Console.WriteLine("Select how long you would like to complete this activity in seconds: ");
            Console.WriteLine("\n1. 30 seconds");
            Console.WriteLine("2. 1 minute");
            Console.WriteLine("3. 2 minutes");
            Console.WriteLine("4. 5 minutes");
            Console.WriteLine("5. Custom time (greater than 30 seconds, less than 300 seconds)");
            Console.WriteLine("6. Return to the main menu");
            
            string userDurationSelection = Console.ReadLine();

            if (int.TryParse(userDurationSelection, out int selection))
            {
                switch (selection)
                {
                    case 1:
                        _duration = 30;
                        validSelection = true;
                        break;
                    case 2:
                        _duration = 60;
                        validSelection = true;
                        break;
                    case 3:
                        _duration = 120;
                        validSelection = true;
                        break;
                    case 4:
                        _duration = 300;
                        validSelection = true;
                        break;
                    case 5:
                        Console.Write("Enter a custom time in seconds (must be between 30 and 300 seconds): ");
                        string customInput = Console.ReadLine();
                        if (int.TryParse(customInput, out int customDuration) && customDuration >= 30 && customDuration <= 300)
                        {
                            _duration = customDuration;
                            validSelection = true;
                        }
                        else
                        {
                            Console.WriteLine("Valid choices are 30 seconds to 300 seconds. Please try again.");
                        }
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Valid choices are 1-6. Please try again.");
                        ShowSpinner(2);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Sorry, you entered an invalid option. Please choose a valid choice.");
                ShowSpinner(2);
            }
        }
        
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