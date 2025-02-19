using System;
using ExerciseTracking;
class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 02, 18), 60, 15),
            new Swimming(new DateTime(2025, 02, 18), 30, 30),
            new Cycling(new DateTime(2025, 02, 18), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}