namespace EternalQuest;

public class EternalGoal : Goal
{
    public EternalGoal(string shortName, string description, int points) : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for {GetName()}!");
    }
    
    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal | {GetName()} | {GetDescription()} | {GetXp()} |";
    }
}