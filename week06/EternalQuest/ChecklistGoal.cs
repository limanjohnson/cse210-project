namespace EternalQuest;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _amountTarget;
    private int _bonusXp;

    public ChecklistGoal(string shortName, string description, int points, int amountTarget, int bonusXP) : base(shortName,
        description, points)
    {
        _amountCompleted = 0;
        _amountTarget = amountTarget;
        _bonusXp = bonusXP;
    }

    public override void RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            if (IsComplete())
            {
                Console.WriteLine($"Bonus XP! +{_bonusXp} XP awarded for completing the checklist goal: {GetName()}");
            }
        }
    }

    public int GetBonusXp()
    {
        return _bonusXp;
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
        return $"ChecklistGoal | {GetName()} | {GetDescription()} | {GetXp()} | {_amountCompleted} | {_amountTarget} | {_bonusXp} ";
    }
}