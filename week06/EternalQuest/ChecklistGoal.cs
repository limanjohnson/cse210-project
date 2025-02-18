namespace EternalQuest;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _amountTarget;
    private int _bonusXP;

    public ChecklistGoal(string shortName, string description, int points, int amountTarget, int bonusXP) : base(shortName,
        description, points)
    {
        _amountCompleted = 0;
        _amountTarget = amountTarget;
        _bonusXP = bonusXP;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _amountTarget;
    }

    public override string GetDetailsString()
    {
        return $"{GetName()} - {GetDescription()} ({_amountCompleted}/{_amountTarget})";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal | {GetName()} | {GetDescription()} | {GetXp()} | {_amountCompleted} | {_amountTarget} | {_bonusXP} ";
    }
}