namespace EternalQuest;

public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int xp) : base(name, description, xp)
    {
        _isCompleted = false;
    }

    public override void RecordEvent()
    {
        _isCompleted = true;
    }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal | {GetName()} | {GetDescription()} | {GetXp()} | {(_isCompleted ? 1 : 0)}";
    }
}