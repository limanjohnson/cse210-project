namespace ExerciseTracking;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes() => _minutes;
    public DateTime GetDate() => _date;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"==================" +
               $"\n{GetType().Name}" +
               $"\n{_date: dd/MM/yyyy} " +
               $"\n{GetType().Name} - {_minutes} minutes" +
               $"\nDistance: {GetDistance():0.0} km," +
               $"\nSpeed {GetSpeed():0.0} kph" +
               $"\nPace {GetPace():0.0} min/km" +
               $"\n==================";
    }
}