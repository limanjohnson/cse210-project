namespace ExerciseTracking;

public class Cycling : Activity
{
    private int _speed;

    public Cycling(DateTime date, int minutes, int speed) : base(date, minutes)
    {
        _speed = speed;
    }
    
    public override double GetSpeed() => _speed;
    public override double GetDistance() => (GetSpeed() * GetMinutes()) / 60;
    public override double GetPace() => 60 / GetSpeed();
}