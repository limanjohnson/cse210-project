namespace EternalQuest;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _xp;

    public Goal(string name, string description, int xp)
    {
        _name = name;
        _description = description;
        _xp = xp;
    }
    
    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public string GetDescription()
    {
        return _description;
    }
    
    public void SetDescription(string description)
    {
        _description = description;
    }

    public int GetXp()
    {
        return _xp;
    }

    public void SetXp(int xp)
    {
        _xp = xp;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        return $"{GetName()} - {GetDescription()}";
    }



}