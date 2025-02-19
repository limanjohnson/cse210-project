namespace ExerciseTracking;

public class Running : Activity
{
    private int _distance;

    public Running(DateTime date, int minutes, int distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => (GetDistance() / GetMinutes()) * 60;
    public override double GetPace() => GetMinutes() / GetDistance();
}