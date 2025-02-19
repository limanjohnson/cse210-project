namespace ExerciseTracking;

public class Swimming : Activity
{
    private int _laps;
    private const double LapLength = 50; // meters

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => (_laps * LapLength) / 1000; // convert meters to kilometers
    public override double GetSpeed() => GetDistance() / GetMinutes();
    public override double GetPace() => GetMinutes() / GetDistance();
}