using System;
using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Threading;
using Mindfulness;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");

        Mindfulness.Activity mindfulActivity = new Mindfulness.Activity("Mindfulness", "Mindfulness is the practice of purposely bringing one's attention to experiences occurring in the present moment without judgment", 5);

        Console.WriteLine(mindfulActivity.DisplayStartingMessage());
        mindfulActivity.ShowCountdown();

    }
}