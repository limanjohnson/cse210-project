using System;
using System.IO;

namespace EternalQuest;

public class GoalManager
{
    private List<Goal> _goals;
    private int _totalPoints;
    private string _filePath = "C:/Users/liamj/School/CSE210/cse210-project/week06/EternalQuest/goals.txt";

    public GoalManager()
    {
        _goals = new List<Goal>();
        _totalPoints = 0;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Total XP: {_totalPoints}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }
        
        for (int i = 0; i < _goals.Count; i++)
        {
            var goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal.GetName()} - {goal.GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.Clear();
        Console.WriteLine("\nLoading goals...");
        Console.WriteLine("Please wait...");
        Thread.Sleep(1000);

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            Console.WriteLine("Returning to main menu...");
            Thread.Sleep(1000);
            return;
        }

        Console.WriteLine("\n=== Your Goals ===\n");
        foreach (var goal in _goals)
        {
            string status = goal.IsComplete() ? "[X]" : "[ ]";
            string goalDetails = goal.GetDetailsString();

            if (goal is EternalGoal || goal is SimpleGoal)
            {
                Console.WriteLine($"{status} {goalDetails}");
            } else if (goal is ChecklistGoal)
            {
                Console.WriteLine($"{status} {goalDetails} ");
            }
        }

        Console.WriteLine("\nPress any key to return to main menu...");
        Console.ReadKey();
        Console.Clear();
    }
    
    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine($"\nCurrent Goals Count: {_goals.Count}");
        
        Console.WriteLine("\nSelect the type of goal you want to create:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int choice;
        while (true)
        {
            Console.Write("Enter your choice (1-3): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3)
            {
                break;
            }

            Console.WriteLine("Sorry, you entered an invalid choice. Please select a valid choice from the menu.");
        }

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter a description: ");
        string description = Console.ReadLine();
        
        int points;
        while (true)
        {
            Console.Write("Enter the amount of points awarded for completing this goal: ");
            if (int.TryParse(Console.ReadLine(), out points) && points >= 0)
            {
                break;
            }

            Console.WriteLine(
                "Sorry, you entered an invalid amount of points. Please enter a number greater than or equal to 0.");
        }
        
        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                int amountTarget;
                while (true)
                {
                    Console.Write("Enter the amount of times you would like to complete this goal: ");
                    if (int.TryParse(Console.ReadLine(), out amountTarget) && amountTarget >= 0)
                    {
                        break;
                    }

                    Console.WriteLine("Invalid choice, you must enter a positive number.");
                }

                int bonusPoints;
                while (true)
                {
                    Console.Write("Enter bonus points awarded upon completion: ");
                    if (int.TryParse(Console.ReadLine(), out bonusPoints) && bonusPoints >= 0)
                    {
                        break;
                    }

                    Console.WriteLine("Invalid choice, you must enter a positive number.");
                }
                
                ChecklistGoal newGoal = new ChecklistGoal(name, description, points, amountTarget, bonusPoints);
                _goals.Add(newGoal);
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("There are no goals to record an event for.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            return;
        }

        // Filter only active (non-complete) goals or eternal goals
        var availableGoals = _goals.Where(goal => !goal.IsComplete() || goal is EternalGoal).ToList();

        if (availableGoals.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("No goals available to record progress for.");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Thread.Sleep(1000);
            Console.WriteLine("Returning to main menu...");
            return;
        }

        Console.Clear();
        Console.WriteLine("Select a goal to record an event for:");

        // Display filtered goals only
        for (int i = 0; i < availableGoals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableGoals[i].GetDetailsString()}");
        }

        if (availableGoals.Count == 1)
        {
            Console.Write("\nEnter your choise (1): ");
        } else if (availableGoals.Count > 1)
        {
            Console.Write("\nEnter your choice (number between 1 and {0}): ", availableGoals.Count);
        }

        // Verify user input
        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > availableGoals.Count)
        {
            Console.WriteLine("Invalid choice. Please try again.");
            Thread.Sleep(1000);
            return;
        }

        // Process the selected goal
        var selectedGoal = availableGoals[index - 1];
        selectedGoal.RecordEvent();

        // Increment total points for valid goals
        _totalPoints += selectedGoal.GetXp();

        if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
        {
            _totalPoints += checklistGoal.GetBonusXp();
            Console.WriteLine($"Bonus XP awarded: {checklistGoal.GetBonusXp()}!");
        }
        

        Console.WriteLine($"Event recorded successfully for {selectedGoal.GetName()}!");
        Console.WriteLine($"Total XP: {_totalPoints}");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
        Console.WriteLine("Returning to main menu...");
        Thread.Sleep(1000);
    }

    public void SaveGoals()
{
    try
    {
        Console.Clear();
        Console.WriteLine("Saving goals...");
        Console.WriteLine("Please wait...");
        Thread.Sleep(1000);
        Console.Clear();
        using (StreamWriter goalLog = new StreamWriter(_filePath))
        {
            goalLog.WriteLine(_totalPoints); // Save total points at the top

            foreach (var goal in _goals)
            {
                goalLog.WriteLine(goal.GetStringRepresentation()); // Ensure each goal correctly formats itself
            }
        }
        Console.WriteLine("Goals saved successfully.");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
        Console.WriteLine("Returning to main menu...");
        Thread.Sleep(1000);
        Console.Clear();
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error saving goals: {e.Message}");
    }
}

    public void LoadGoals()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("Loading goals...");
            Console.WriteLine("Please wait...");
            Thread.Sleep(1000);
            Console.Clear();
            if (!File.Exists(_filePath))
            {
                Console.WriteLine("No saved goals found.");
                return;
            }

            string[] lines = File.ReadAllLines(_filePath);
            if (lines.Length == 0 || !int.TryParse(lines[0], out _totalPoints))
            {
                Console.WriteLine("Error: Invalid total points format.");
                return;
            }

            _goals.Clear(); // Clear existing goals before loading

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|').Select(p => p.Trim()).ToArray(); // Trim spaces

                if (parts.Length < 4) // Check for minimum data requirement
                {
                    Console.WriteLine($"Warning: Skipping malformed goal entry on line {i + 1}.");
                    continue;
                }

                string type = parts[0].Replace(" ", ""); // Normalize type name
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                try
                {
                    if (type == "SimpleGoal")
                    {
                        bool isCompleted = parts.Length >= 5 && parts[4] == "1"; // Check if the goal was completed
                        SimpleGoal goal = new SimpleGoal(name, description, points);
                        if (isCompleted) goal.RecordEvent(); // Mark as completed
                        _goals.Add(goal);
                    }
                    else if (type == "EternalGoal")
                    {
                        _goals.Add(new EternalGoal(name, description, points));
                    }
                    else if (type == "ChecklistGoal" && parts.Length >= 7)
                    {
                        int amountCompleted = int.Parse(parts[4]);
                        int amountTarget = int.Parse(parts[5]);
                        int bonusXp = int.Parse(parts[6]);

                        ChecklistGoal checklistGoal =
                            new ChecklistGoal(name, description, points, amountTarget, bonusXp);
                        for (int j = 0; j < amountCompleted; j++)
                        {
                            checklistGoal.RecordEvent();
                        }

                        _goals.Add(checklistGoal);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Unrecognized goal type on line {i + 1}. Skipping.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing goal on line {i + 1}: {ex.Message}");
                }
            }

            Console.WriteLine($"Goals loaded successfully. Total goals: {_goals.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading goals: {ex.Message}");
        }
    }

}